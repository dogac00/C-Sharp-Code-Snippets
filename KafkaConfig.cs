public class KafkaConfiguration : ConsumerConfig
    {
        public Action<IConsumer<string, string>, Error> ErrorHandler { get; set; }
        public Action<IConsumer<string, string>, LogMessage> LogHandler { get; set; }
        public Action<IConsumer<string, string>, string> StatisticsHandler { get; set; }
        public Action<IConsumer<string, string>, string> OAuthBearerTokenRefreshHandler { get; set; }
        public IDeserializer<string> KeyDeserializer { get; set; }
        public IDeserializer<string> ValueDeserializer { get; set; }
        public Func<IConsumer<string, string>, List<TopicPartition>, IEnumerable<TopicPartitionOffset>>
            PartitionsAssignedHandler { get; set; }
        public Action<IConsumer<string, string>, CommittedOffsets> OffsetsCommittedHandler { get; set; }
    }
