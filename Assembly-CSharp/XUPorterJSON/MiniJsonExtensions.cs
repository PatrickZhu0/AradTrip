using System;
using System.Collections;
using System.Collections.Generic;

namespace XUPorterJSON
{
	// Token: 0x02000156 RID: 342
	public static class MiniJsonExtensions
	{
		// Token: 0x060009E2 RID: 2530 RVA: 0x000341E4 File Offset: 0x000325E4
		public static string toJson(this Hashtable obj)
		{
			return MiniJSON.jsonEncode(obj);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x000341EC File Offset: 0x000325EC
		public static string toJson(this Dictionary<string, string> obj)
		{
			return MiniJSON.jsonEncode(obj);
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x000341F4 File Offset: 0x000325F4
		public static ArrayList arrayListFromJson(this string json)
		{
			return MiniJSON.jsonDecode(json) as ArrayList;
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x00034201 File Offset: 0x00032601
		public static Hashtable hashtableFromJson(this string json)
		{
			return MiniJSON.jsonDecode(json) as Hashtable;
		}
	}
}
