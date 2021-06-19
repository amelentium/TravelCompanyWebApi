using System.Collections.Generic;
using System.Text.Json;

namespace TravelCompanyClient.Shared
{
    public static class EnumExtentions
	{
		public static IEnumerable<T> toEnumerableOfObject<T>(this IEnumerable<JsonElement> elements)
		{
			List<T> list = new List<T>();

			foreach (var element in elements)
			{
				var json = element.GetRawText();
				list.Add(JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				}));
			}

			return list;
		}
	}
}
