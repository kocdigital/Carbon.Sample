namespace Carbon.Sample.API.Infrastructure
{
	public static class CacheKeyConstants
	{
		public const string SampleEntity = "SampleEntity";
		public static string GenerateKeyById(this string key, object id)
		{
			return $"{key}:Id#{id}";
		}
	}
}
