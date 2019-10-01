using System.Collections.Generic;
using System.Linq;
using Elasticsearch.Net.Utf8Json;

namespace Nest
{
	internal class SingleOrEnumerableFormatter<T> : IJsonFormatter<IEnumerable<T>>
	{
		public IEnumerable<T> Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			var token = reader.GetCurrentJsonToken();
			return token == JsonToken.BeginArray
				? formatterResolver.GetFormatter<IEnumerable<T>>().Deserialize(ref reader, formatterResolver)
				: new[] { formatterResolver.GetFormatter<T>().Deserialize(ref reader, formatterResolver) };
		}

		public void Serialize(ref JsonWriter writer, IEnumerable<T> value, IJsonFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}

			var formatter = formatterResolver.GetFormatter<IEnumerable<T>>();
			formatter.Serialize(ref writer, value, formatterResolver);
		}
	}

	internal class SerializeAsSingleFormatter<T> : IJsonFormatter<IEnumerable<T>>
	{
		public IEnumerable<T> Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			var token = reader.GetCurrentJsonToken();
			return token == JsonToken.BeginArray
				? formatterResolver.GetFormatter<IEnumerable<T>>().Deserialize(ref reader, formatterResolver)
				: new[] { formatterResolver.GetFormatter<T>().Deserialize(ref reader, formatterResolver) };
		}

		public void Serialize(ref JsonWriter writer, IEnumerable<T> value, IJsonFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				writer.WriteNull();
				return;
			}

			var enumerator = value.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				writer.WriteNull();
				return;
			}

			var firstValue = enumerator.Current;
			var formatter = formatterResolver.GetFormatter<T>();
			formatter.Serialize(ref writer, firstValue, formatterResolver);
		}
	}
}