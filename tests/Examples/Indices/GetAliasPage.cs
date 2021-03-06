// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Nest;
using System.ComponentModel;

namespace Examples.Indices
{
	public class GetAliasPage : ExampleBase
	{
		[U(Skip = "Example not implemented")]
		[Description("indices/get-alias.asciidoc:12")]
		public void Line12()
		{
			// tag::265ba62e416d27b3408fb8a2f698627d[]
			var response0 = new SearchResponse<object>();
			// end::265ba62e416d27b3408fb8a2f698627d[]

			response0.MatchesExample(@"GET /twitter/_alias/alias1");
		}

		[U(Skip = "Example not implemented")]
		[Description("indices/get-alias.asciidoc:76")]
		public void Line76()
		{
			// tag::8118bad980d7afd31677b5060361ecd2[]
			var response0 = new SearchResponse<object>();
			// end::8118bad980d7afd31677b5060361ecd2[]

			response0.MatchesExample(@"PUT /logs_20302801
			{
			  ""aliases"" : {
			    ""current_day"" : {},
			    ""2030"" : {
			      ""filter"" : {
			          ""term"" : {""year"" : 2030 }
			      }
			    }
			  }
			}");
		}

		[U(Skip = "Example not implemented")]
		[Description("indices/get-alias.asciidoc:94")]
		public void Line94()
		{
			// tag::e85f2b38878f745a16edc575e78d7cde[]
			var response0 = new SearchResponse<object>();
			// end::e85f2b38878f745a16edc575e78d7cde[]

			response0.MatchesExample(@"GET /logs_20302801/_alias/*");
		}

		[U(Skip = "Example not implemented")]
		[Description("indices/get-alias.asciidoc:127")]
		public void Line127()
		{
			// tag::a71c929ed2e322f91092d5dc625b6440[]
			var response0 = new SearchResponse<object>();
			// end::a71c929ed2e322f91092d5dc625b6440[]

			response0.MatchesExample(@"GET /_alias/2030");
		}

		[U(Skip = "Example not implemented")]
		[Description("indices/get-alias.asciidoc:158")]
		public void Line158()
		{
			// tag::56aa1bff647d1db49dabf175c1e56919[]
			var response0 = new SearchResponse<object>();
			// end::56aa1bff647d1db49dabf175c1e56919[]

			response0.MatchesExample(@"GET /_alias/20*");
		}
	}
}
