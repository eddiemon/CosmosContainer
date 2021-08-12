using System.Reflection;
using Xunit;

namespace Abstractions.Container.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Abstractions.Container;
    using Xunit.Abstractions;

    public class IContainerTests
    {
        private readonly ITestOutputHelper output;

        public IContainerTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void AllPublicMethodsShouldBeInInterface()
        {
            var containerPublicMethods = typeof(Container).GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            var interfacePublicMethods = typeof(IContainer<>).GetMethods(BindingFlags.Public | BindingFlags.Instance);

            var errors = new List<string>();
            foreach (var method in containerPublicMethods)
            {
                try
                {
                    interfacePublicMethods.Single(m => m.Name == method.Name && ParameterTypesMatch(m.GetParameters(), method.GetParameters()));
                }
                catch (InvalidOperationException)
                {
                    errors.Add($"Method '{method.Name}({string.Join(',', method.GetParameters().Select(p => p.ParameterType.Name))})' is not reflected in {typeof(IContainer<>).Name}.");
                }
            }

            foreach (var error in errors)
            {
                output.WriteLine(error);
            }

            Assert.Empty(errors);
        }

        private bool ParameterTypesMatch(ParameterInfo[] a, ParameterInfo[] b)
        {
            if (a.Count() != b.Count())
                return false;

            for (int i = 0; i < a.Count(); i++)
            {
                if ((a[i].ParameterType != b[i].ParameterType && a[i].ParameterType.IsGenericType != b[i].ParameterType.IsGenericType) ||
                    a[i].Name != b[i].Name)
                    return false;
            }

            return true;
        }
    }
}
