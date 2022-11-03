using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Cosmos.Abstractions.Container
{
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Scripts;
    using static Microsoft.Azure.Cosmos.Container;

    public interface IContainer<T>
    {
        /// <inheritdoc cref="Container.Conflicts"/>
        Conflicts Conflicts { get; }

        /// <inheritdoc cref="Container.Database"/>
        Database Database { get; }

        /// <inheritdoc cref="Container.Id"/>
        string Id { get; }

        /// <inheritdoc cref="Container.Scripts"/>
        Scripts Scripts { get; }

        /// <inheritdoc cref="Container.CreateItemAsync{T}"/>
        Task<ItemResponse<T>> CreateItemAsync(T item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.CreateItemAsync{T}"/>
        Task<ItemResponse<TT>> CreateItemAsync<TT>(TT item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.CreateItemStreamAsync"/>
        Task<ResponseMessage> CreateItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.CreateTransactionalBatch"/>
        TransactionalBatch CreateTransactionalBatch(PartitionKey partitionKey);

        /// <inheritdoc cref="Container.DeleteContainerAsync"/>
        Task<ContainerResponse> DeleteContainerAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.DeleteContainerStreamAsync"/>
        Task<ResponseMessage> DeleteContainerStreamAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.DeleteItemAsync{T}"/>
        Task<ItemResponse<T>> DeleteItemAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.DeleteItemAsync{T}"/>
        Task<ItemResponse<TT>> DeleteItemAsync<TT>(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.DeleteItemStreamAsync"/>
        Task<ResponseMessage> DeleteItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.GetChangeFeedEstimator"/>
        ChangeFeedEstimator GetChangeFeedEstimator(string processorName, Container leaseContainer);

        /// <inheritdoc cref="Container.GetChangeFeedEstimatorBuilder"/>
        ChangeFeedProcessorBuilder GetChangeFeedEstimatorBuilder(string processorName, Container.ChangesEstimationHandler estimationDelegate, TimeSpan? estimationPeriod = null);

        /// <inheritdoc cref="Container.GetChangeFeedIterator{T}"/>
        FeedIterator<T> GetChangeFeedIterator(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null);

        /// <inheritdoc cref="Container.GetChangeFeedIterator{T}"/>
        FeedIterator<TT> GetChangeFeedIterator<TT>(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null);

        /// <inheritdoc cref="Container.GetChangeFeedProcessorBuilder"/>
        ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilder(string processorName, Container.ChangesHandler<T> onChangesDelegate);

        /// <inheritdoc cref="Container.GetChangeFeedStreamIterator"/>
        FeedIterator GetChangeFeedStreamIterator(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null);

        /// <inheritdoc cref="Container.GetFeedRangesAsync"/>
        Task<IReadOnlyList<FeedRange>> GetFeedRangesAsync(CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.GetItemLinqQueryable{T}(bool,string,Microsoft.Azure.Cosmos.QueryRequestOptions,Microsoft.Azure.Cosmos.CosmosLinqSerializerOptions)"/>
        IOrderedQueryable<T> GetItemLinqQueryable(bool allowSynchronousQueryExecution = false, string? continuationToken = null, QueryRequestOptions? requestOptions = null, CosmosLinqSerializerOptions? linqSerializerOptions = null);

        /// <inheritdoc cref="Container.GetItemLinqQueryable{T}(bool,string,Microsoft.Azure.Cosmos.QueryRequestOptions,Microsoft.Azure.Cosmos.CosmosLinqSerializerOptions)"/>
        IOrderedQueryable<TT> GetItemLinqQueryable<TT>(bool allowSynchronousQueryExecution = false, string? continuationToken = null, QueryRequestOptions? requestOptions = null, CosmosLinqSerializerOptions? linqSerializerOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(string,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        FeedIterator<T> GetItemQueryIterator(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(string,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        FeedIterator<TT> GetItemQueryIterator<TT>(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        FeedIterator<T> GetItemQueryIterator(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(Microsoft.Azure.Cosmos.FeedRange, Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        FeedIterator<T> GetItemQueryIterator(FeedRange feedRange, QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        FeedIterator<TT> GetItemQueryIterator<TT>(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryIterator{T}(Microsoft.Azure.Cosmos.FeedRange, Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        FeedIterator<TT> GetItemQueryIterator<TT>(FeedRange feedRange, QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryStreamIterator(string,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        FeedIterator GetItemQueryStreamIterator(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryStreamIterator(Microsoft.Azure.Cosmos.FeedRange,Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        FeedIterator GetItemQueryStreamIterator(FeedRange feedRange, QueryDefinition queryDefinition, string continuationToken, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryStreamIterator(Microsoft.Azure.Cosmos.QueryDefinition,string,Microsoft.Azure.Cosmos.QueryRequestOptions)"/>
        FeedIterator GetItemQueryStreamIterator(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.ReadContainerAsync"/>
        Task<ContainerResponse> ReadContainerAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadContainerStreamAsync"/>
        Task<ResponseMessage> ReadContainerStreamAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadItemAsync{T}"/>
        Task<ItemResponse<T>> ReadItemAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadItemAsync{T}"/>
        Task<ItemResponse<TT>> ReadItemAsync<TT>(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadItemStreamAsync"/>
        Task<ResponseMessage> ReadItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadManyItemsAsync{T}"/>
        Task<FeedResponse<T>> ReadManyItemsAsync(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadManyItemsAsync{T}"/>
        Task<FeedResponse<TT>> ReadManyItemsAsync<TT>(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadManyItemsStreamAsync"/>
        Task<ResponseMessage> ReadManyItemsStreamAsync(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadThroughputAsync(System.Threading.CancellationToken)"/>
        Task<int?> ReadThroughputAsync(CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadThroughputAsync(System.Threading.CancellationToken)"/>
        Task<ThroughputResponse> ReadThroughputAsync(RequestOptions requestOptions, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceContainerAsync"/>
        Task<ContainerResponse> ReplaceContainerAsync(ContainerProperties containerProperties, ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceContainerStreamAsync"/>
        Task<ResponseMessage> ReplaceContainerStreamAsync(ContainerProperties containerProperties, ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceItemAsync{T}"/>
        Task<ItemResponse<T>> ReplaceItemAsync(T item, string id, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceItemAsync{T}"/>
        Task<ItemResponse<TT>> ReplaceItemAsync<TT>(TT item, string id, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceItemStreamAsync"/>
        Task<ResponseMessage> ReplaceItemStreamAsync(Stream streamPayload, string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceThroughputAsync(int,Microsoft.Azure.Cosmos.RequestOptions,System.Threading.CancellationToken)"/>
        Task<ThroughputResponse> ReplaceThroughputAsync(int throughput, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceThroughputAsync(int,Microsoft.Azure.Cosmos.RequestOptions,System.Threading.CancellationToken)"/>
        Task<ThroughputResponse> ReplaceThroughputAsync(ThroughputProperties throughputProperties, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.UpsertItemAsync{T}"/>
        Task<ItemResponse<T>> UpsertItemAsync(T item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.UpsertItemAsync{T}"/>
        Task<ItemResponse<TT>> UpsertItemAsync<TT>(TT item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.UpsertItemStreamAsync"/>
        Task<ResponseMessage> UpsertItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.GetChangeFeedProcessorBuilderWithManualCheckpoint{T}(string, ChangeFeedHandlerWithManualCheckpoint{T})"/>
        ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilderWithManualCheckpoint(string processorName, ChangeFeedHandlerWithManualCheckpoint<T> onChangesDelegate);

        /// <inheritdoc cref="Container.GetChangeFeedProcessorBuilder"/>
        ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilder(string processorName, ChangeFeedStreamHandler onChangesDelegate);

        /// <inheritdoc cref="Container.GetChangeFeedProcessorBuilderWithManualCheckpoint"/>
        ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilderWithManualCheckpoint(string processorName, ChangeFeedStreamHandlerWithManualCheckpoint onChangesDelegate);

        /// <inheritdoc cref="Container.PatchItemAsync{T}"/>
        Task<ItemResponse<T>> PatchItemAsync(string id, PartitionKey partitionKey, IReadOnlyList<PatchOperation> patchOperations, PatchItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <inheritdoc cref="Container.PatchItemAsync{T}"/>
        Task<ItemResponse<TT>> PatchItemAsync<TT>(string id, PartitionKey partitionKey, IReadOnlyList<PatchOperation> patchOperations, PatchItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <inheritdoc cref="Container.PatchItemStreamAsync"/>
        Task<ResponseMessage> PatchItemStreamAsync(string id, PartitionKey partitionKey, IReadOnlyList<PatchOperation> patchOperations, PatchItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
