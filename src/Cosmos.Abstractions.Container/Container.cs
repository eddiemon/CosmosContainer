﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Cosmos.Abstractions.Container
{
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Scripts;

    /// <inheritdoc cref="Container"/>
    public class Container<T> : IContainer<T>
    {
        private readonly Container _container;

        public Container(Container container)
        {
            _container = container;
        }

        /// <inheritdoc cref="Container.Id"/>
        public string Id => _container.Id;

        /// <inheritdoc cref="Container.Database"/>
        public Database Database => _container.Database;

        /// <inheritdoc cref="Container.Conflicts"/>
        public Conflicts Conflicts => _container.Conflicts;

        /// <inheritdoc cref="Container.Scripts"/>
        public Scripts Scripts => _container.Scripts;

        /// <inheritdoc cref="Container.CreateItemAsync{T}"/>
        public Task<ItemResponse<T>> CreateItemAsync(T item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.CreateItemAsync(item, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.CreateItemAsync{T}"/>
        public Task<ItemResponse<TT>> CreateItemAsync<TT>(TT item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.CreateItemAsync(item, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.CreateItemStreamAsync"/>
        public Task<ResponseMessage> CreateItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.CreateItemStreamAsync(streamPayload, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.CreateTransactionalBatch"/>
        public TransactionalBatch CreateTransactionalBatch(PartitionKey partitionKey) => _container.CreateTransactionalBatch(partitionKey);

        /// <inheritdoc cref="Container.DeleteContainerAsync"/>
        public Task<ContainerResponse> DeleteContainerAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.DeleteContainerAsync(requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.DeleteContainerStreamAsync"/>
        public Task<ResponseMessage> DeleteContainerStreamAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.DeleteContainerStreamAsync(requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.DeleteItemAsync{T}"/>
        public Task<ItemResponse<T>> DeleteItemAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.DeleteItemAsync<T>(id, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.DeleteItemAsync{T}"/>
        public Task<ItemResponse<TT>> DeleteItemAsync<TT>(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.DeleteItemAsync<TT>(id, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.DeleteItemStreamAsync"/>
        public Task<ResponseMessage> DeleteItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.DeleteItemStreamAsync(id, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.GetChangeFeedEstimator"/>
        public ChangeFeedEstimator GetChangeFeedEstimator(string processorName, Container leaseContainer) => _container.GetChangeFeedEstimator(processorName, leaseContainer);

        /// <inheritdoc cref="Container.GetChangeFeedEstimatorBuilder"/>
        public ChangeFeedProcessorBuilder GetChangeFeedEstimatorBuilder(string processorName, Container.ChangesEstimationHandler estimationDelegate, TimeSpan? estimationPeriod = null) => _container.GetChangeFeedEstimatorBuilder(processorName, estimationDelegate, estimationPeriod);

        /// <inheritdoc cref="Container.GetChangeFeedIterator{T}"/>
        public FeedIterator<T> GetChangeFeedIterator(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null) => _container.GetChangeFeedIterator<T>(changeFeedStartFrom, changeFeedMode, changeFeedRequestOptions);

        /// <inheritdoc cref="Container.GetChangeFeedIterator{T}"/>
        public FeedIterator<TT> GetChangeFeedIterator<TT>(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null) => _container.GetChangeFeedIterator<TT>(changeFeedStartFrom, changeFeedMode, changeFeedRequestOptions);

        /// <inheritdoc cref="Container.GetChangeFeedProcessorBuilder{T}(string,Microsoft.Azure.Cosmos.Container.ChangesHandler{T})"/>
        public ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilder(string processorName, Container.ChangesHandler<T> onChangesDelegate) => _container.GetChangeFeedProcessorBuilder(processorName, onChangesDelegate);

        /// <inheritdoc cref="Container.GetChangeFeedProcessorBuilder"/>
        public ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilder(string processorName, Container.ChangeFeedStreamHandler onChangesDelegate) => _container.GetChangeFeedProcessorBuilder(processorName, onChangesDelegate);

        /// <inheritdoc cref="Container.GetChangeFeedProcessorBuilderWithManualCheckpoint{T}"/>
        public ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilderWithManualCheckpoint(string processorName, Container.ChangeFeedHandlerWithManualCheckpoint<T> onChangesDelegate) => _container.GetChangeFeedProcessorBuilderWithManualCheckpoint(processorName, onChangesDelegate);

        /// <inheritdoc cref="Container.GetChangeFeedProcessorBuilderWithManualCheckpoint"/>
        public ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilderWithManualCheckpoint(string processorName, Container.ChangeFeedStreamHandlerWithManualCheckpoint onChangesDelegate) => _container.GetChangeFeedProcessorBuilderWithManualCheckpoint(processorName, onChangesDelegate);

        /// <inheritdoc cref="Container.GetChangeFeedStreamIterator"/>
        public FeedIterator GetChangeFeedStreamIterator(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null) => _container.GetChangeFeedStreamIterator(changeFeedStartFrom, changeFeedMode, changeFeedRequestOptions);

        /// <inheritdoc cref="Container.GetFeedRangesAsync"/>
        public Task<IReadOnlyList<FeedRange>> GetFeedRangesAsync(CancellationToken cancellationToken = default) => _container.GetFeedRangesAsync(cancellationToken);

        /// <inheritdoc cref="Container.GetItemLinqQueryable{T}"/>
        public IOrderedQueryable<T> GetItemLinqQueryable(bool allowSynchronousQueryExecution = false, string? continuationToken = null, QueryRequestOptions? requestOptions = null, CosmosLinqSerializerOptions? linqSerializerOptions = null) => _container.GetItemLinqQueryable<T>(allowSynchronousQueryExecution, continuationToken, requestOptions, linqSerializerOptions);

        /// <inheritdoc cref="Container.GetItemLinqQueryable{T}"/>
        public IOrderedQueryable<TT> GetItemLinqQueryable<TT>(bool allowSynchronousQueryExecution = false, string? continuationToken = null, QueryRequestOptions? requestOptions = null, CosmosLinqSerializerOptions? linqSerializerOptions = null) => _container.GetItemLinqQueryable<TT>(allowSynchronousQueryExecution, continuationToken, requestOptions, linqSerializerOptions);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        public FeedIterator<T> GetItemQueryIterator(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null) => _container.GetItemQueryIterator<T>(queryDefinition, continuationToken, requestOptions);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(Microsoft.Azure.Cosmos.FeedRange,Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        public FeedIterator<T> GetItemQueryIterator(FeedRange feedRange, QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null) => _container.GetItemQueryIterator<T>(feedRange, queryDefinition, continuationToken, requestOptions);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        public FeedIterator<TT> GetItemQueryIterator<TT>(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null) => _container.GetItemQueryIterator<TT>(queryDefinition, continuationToken, requestOptions);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(Microsoft.Azure.Cosmos.FeedRange,Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        public FeedIterator<TT> GetItemQueryIterator<TT>(FeedRange feedRange, QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null) => _container.GetItemQueryIterator<TT>(feedRange, queryDefinition, continuationToken, requestOptions);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(string,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        public FeedIterator<T> GetItemQueryIterator(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null) => _container.GetItemQueryIterator<T>(queryText, continuationToken, requestOptions);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(string,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        public FeedIterator<TT> GetItemQueryIterator<TT>(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null) => _container.GetItemQueryIterator<TT>(queryText, continuationToken, requestOptions);

        /// <inheritdoc cref="Container.GetItemQueryStreamIterator(Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        public FeedIterator GetItemQueryStreamIterator(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null) => _container.GetItemQueryStreamIterator(queryDefinition, continuationToken, requestOptions);

        /// <inheritdoc cref="Container.GetItemQueryStreamIterator(Microsoft.Azure.Cosmos.FeedRange,Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        public FeedIterator GetItemQueryStreamIterator(FeedRange feedRange, QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null) => _container.GetItemQueryStreamIterator(queryDefinition, continuationToken, requestOptions);

        /// <inheritdoc cref="Container.GetItemQueryStreamIterator(string,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        public FeedIterator GetItemQueryStreamIterator(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null) => _container.GetItemQueryStreamIterator(queryText, continuationToken, requestOptions);

        /// <inheritdoc cref="Container.PatchItemAsync{T}"/>
        public Task<ItemResponse<T>> PatchItemAsync(string id, PartitionKey partitionKey, IReadOnlyList<PatchOperation> patchOperations, PatchItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default) => _container.PatchItemAsync<T>(id, partitionKey, patchOperations, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.PatchItemAsync{T}"/>
        public Task<ItemResponse<TT>> PatchItemAsync<TT>(string id, PartitionKey partitionKey, IReadOnlyList<PatchOperation> patchOperations, PatchItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default) => _container.PatchItemAsync<TT>(id, partitionKey, patchOperations, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.PatchItemStreamAsync"/>
        public Task<ResponseMessage> PatchItemStreamAsync(string id, PartitionKey partitionKey, IReadOnlyList<PatchOperation> patchOperations, PatchItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default) => _container.PatchItemStreamAsync(id, partitionKey, patchOperations, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReadContainerAsync"/>
        public Task<ContainerResponse> ReadContainerAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReadContainerAsync(requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReadContainerStreamAsync"/>
        public Task<ResponseMessage> ReadContainerStreamAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReadContainerStreamAsync(requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReadItemAsync{T}"/>
        public Task<ItemResponse<T>> ReadItemAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReadItemAsync<T>(id, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReadItemAsync{T}"/>
        public Task<ItemResponse<TT>> ReadItemAsync<TT>(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReadItemAsync<TT>(id, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReadItemStreamAsync"/>
        public Task<ResponseMessage> ReadItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReadItemStreamAsync(id, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReadManyItemsAsync{T}"/>
        public Task<FeedResponse<T>> ReadManyItemsAsync(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default) => _container.ReadManyItemsAsync<T>(items, readManyRequestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReadManyItemsAsync{T}"/>
        public Task<FeedResponse<TT>> ReadManyItemsAsync<TT>(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default) => _container.ReadManyItemsAsync<TT>(items, readManyRequestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReadManyItemsStreamAsync"/>
        public Task<ResponseMessage> ReadManyItemsStreamAsync(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default) => _container.ReadManyItemsStreamAsync(items, readManyRequestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReadThroughputAsync(System.Threading.CancellationToken)"/>
        public Task<int?> ReadThroughputAsync(CancellationToken cancellationToken = default) => _container.ReadThroughputAsync(cancellationToken);

        /// <inheritdoc cref="Container.ReadThroughputAsync(Microsoft.Azure.Cosmos.RequestOptions,System.Threading.CancellationToken)"/>
        public Task<ThroughputResponse> ReadThroughputAsync(RequestOptions requestOptions, CancellationToken cancellationToken = default) => _container.ReadThroughputAsync(requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReplaceContainerAsync"/>
        public Task<ContainerResponse> ReplaceContainerAsync(ContainerProperties containerProperties, ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReplaceContainerAsync(containerProperties, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReplaceContainerStreamAsync"/>
        public Task<ResponseMessage> ReplaceContainerStreamAsync(ContainerProperties containerProperties, ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReplaceContainerStreamAsync(containerProperties, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReplaceItemAsync{T}"/>
        public Task<ItemResponse<T>> ReplaceItemAsync(T item, string id, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReplaceItemAsync<T>(item, id, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReplaceItemAsync{T}"/>
        public Task<ItemResponse<TT>> ReplaceItemAsync<TT>(TT item, string id, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReplaceItemAsync<TT>(item, id, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReplaceItemStreamAsync"/>
        public Task<ResponseMessage> ReplaceItemStreamAsync(Stream streamPayload, string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReplaceItemStreamAsync(streamPayload, id, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReplaceThroughputAsync(int,Microsoft.Azure.Cosmos.RequestOptions,System.Threading.CancellationToken)"/>
        public Task<ThroughputResponse> ReplaceThroughputAsync(int throughput, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReplaceThroughputAsync(throughput, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.ReplaceThroughputAsync(Microsoft.Azure.Cosmos.ThroughputProperties,Microsoft.Azure.Cosmos.RequestOptions,System.Threading.CancellationToken)"/>
        public Task<ThroughputResponse> ReplaceThroughputAsync(ThroughputProperties throughputProperties, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.ReplaceThroughputAsync(throughputProperties, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.UpsertItemAsync{T}"/>
        public Task<ItemResponse<T>> UpsertItemAsync(T item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.UpsertItemAsync<T>(item, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.UpsertItemAsync{T}"/>
        public Task<ItemResponse<TT>> UpsertItemAsync<TT>(TT item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.UpsertItemAsync<TT>(item, partitionKey, requestOptions, cancellationToken);

        /// <inheritdoc cref="Container.UpsertItemStreamAsync"/>
        public Task<ResponseMessage> UpsertItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default) => _container.UpsertItemStreamAsync(streamPayload, partitionKey, requestOptions, cancellationToken);
    }
}
