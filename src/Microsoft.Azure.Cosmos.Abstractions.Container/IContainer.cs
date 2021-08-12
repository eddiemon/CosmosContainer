﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Microsoft.Azure.Cosmos.Abstractions.Container
{
    using Microsoft.Azure.Cosmos;
    using Microsoft.Azure.Cosmos.Scripts;

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

        /// <inheritdoc cref="Container.CreateItemAsync"/>
        Task<ItemResponse<T>> CreateItemAsync(T item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.CreateItemStreamAsync"/>
        Task<ResponseMessage> CreateItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.CreateTransactionalBatch"/>
        TransactionalBatch CreateTransactionalBatch(PartitionKey partitionKey);

        /// <inheritdoc cref="Container.DeleteContainerAsync"/>
        Task<ContainerResponse> DeleteContainerAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.DeleteContainerStreamAsync"/>
        Task<ResponseMessage> DeleteContainerStreamAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.DeleteItemAsync"/>
        Task<ItemResponse<T>> DeleteItemAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.DeleteItemStreamAsync"/>
        Task<ResponseMessage> DeleteItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.GetChangeFeedEstimator"/>
        ChangeFeedEstimator GetChangeFeedEstimator(string processorName, Container leaseContainer);

        /// <inheritdoc cref="Container.GetChangeFeedEstimatorBuilder"/>
        ChangeFeedProcessorBuilder GetChangeFeedEstimatorBuilder(string processorName, Container.ChangesEstimationHandler estimationDelegate, TimeSpan? estimationPeriod = null);

        /// <inheritdoc cref="Container.GetChangeFeedIterator"/>
        FeedIterator<T> GetChangeFeedIterator(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null);

        /// <inheritdoc cref="Container.GetChangeFeedProcessorBuilder"/>
        ChangeFeedProcessorBuilder GetChangeFeedProcessorBuilder(string processorName, Container.ChangesHandler<T> onChangesDelegate);

        /// <inheritdoc cref="Container.GetChangeFeedStreamIterator"/>
        FeedIterator GetChangeFeedStreamIterator(ChangeFeedStartFrom changeFeedStartFrom, ChangeFeedMode changeFeedMode, ChangeFeedRequestOptions? changeFeedRequestOptions = null);

        /// <inheritdoc cref="Container.GetFeedRangesAsync"/>
        Task<IReadOnlyList<FeedRange>> GetFeedRangesAsync(CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.GetItemLinqQueryable"/>
        IOrderedQueryable<T> GetItemLinqQueryable(bool allowSynchronousQueryExecution = false, string? continuationToken = null, QueryRequestOptions? requestOptions = null, CosmosLinqSerializerOptions? linqSerializerOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryIterator"/>
        FeedIterator<T> GetItemQueryIterator(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryIterator"/>
        FeedIterator<T> GetItemQueryIterator(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryStreamIterator"/>
        FeedIterator GetItemQueryStreamIterator(string? queryText = null, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.GetItemQueryStreamIterator"/>
        FeedIterator GetItemQueryStreamIterator(QueryDefinition queryDefinition, string? continuationToken = null, QueryRequestOptions? requestOptions = null);

        /// <inheritdoc cref="Container.ReadContainerAsync"/>
        Task<ContainerResponse> ReadContainerAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadContainerStreamAsync"/>
        Task<ResponseMessage> ReadContainerStreamAsync(ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadItemAsync"/>
        Task<ItemResponse<T>> ReadItemAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadItemStreamAsync"/>
        Task<ResponseMessage> ReadItemStreamAsync(string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadManyItemsAsync"/>
        Task<FeedResponse<T>> ReadManyItemsAsync(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadManyItemsStreamAsync"/>
        Task<ResponseMessage> ReadManyItemsStreamAsync(IReadOnlyList<(string id, PartitionKey partitionKey)> items, ReadManyRequestOptions? readManyRequestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadThroughputAsync"/>
        Task<int?> ReadThroughputAsync(CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReadThroughputAsync"/>
        Task<ThroughputResponse> ReadThroughputAsync(RequestOptions requestOptions, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceContainerAsync"/>
        Task<ContainerResponse> ReplaceContainerAsync(ContainerProperties containerProperties, ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceContainerStreamAsync"/>
        Task<ResponseMessage> ReplaceContainerStreamAsync(ContainerProperties containerProperties, ContainerRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceItemAsync"/>
        Task<ItemResponse<T>> ReplaceItemAsync(T item, string id, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceItemStreamAsync"/>
        Task<ResponseMessage> ReplaceItemStreamAsync(Stream streamPayload, string id, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceThroughputAsync"/>
        Task<ThroughputResponse> ReplaceThroughputAsync(int throughput, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.ReplaceThroughputAsync"/>
        Task<ThroughputResponse> ReplaceThroughputAsync(ThroughputProperties throughputProperties, RequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.UpsertItemAsync"/>
        Task<ItemResponse<T>> UpsertItemAsync(T item, PartitionKey? partitionKey = null, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);

        /// <inheritdoc cref="Container.UpsertItemStreamAsync"/>
        Task<ResponseMessage> UpsertItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);
    }
}
