using System;
using System.Collections;
using System.Collections.Specialized;

namespace YouMe
{
	// Token: 0x02004AC5 RID: 19141
	public interface IJsonWrapper : IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x17002594 RID: 9620
		// (get) Token: 0x0601BC6F RID: 113775
		bool IsArray { get; }

		// Token: 0x17002595 RID: 9621
		// (get) Token: 0x0601BC70 RID: 113776
		bool IsBoolean { get; }

		// Token: 0x17002596 RID: 9622
		// (get) Token: 0x0601BC71 RID: 113777
		bool IsDouble { get; }

		// Token: 0x17002597 RID: 9623
		// (get) Token: 0x0601BC72 RID: 113778
		bool IsInt { get; }

		// Token: 0x17002598 RID: 9624
		// (get) Token: 0x0601BC73 RID: 113779
		bool IsLong { get; }

		// Token: 0x17002599 RID: 9625
		// (get) Token: 0x0601BC74 RID: 113780
		bool IsObject { get; }

		// Token: 0x1700259A RID: 9626
		// (get) Token: 0x0601BC75 RID: 113781
		bool IsString { get; }

		// Token: 0x0601BC76 RID: 113782
		bool GetBoolean();

		// Token: 0x0601BC77 RID: 113783
		double GetDouble();

		// Token: 0x0601BC78 RID: 113784
		int GetInt();

		// Token: 0x0601BC79 RID: 113785
		JsonType GetJsonType();

		// Token: 0x0601BC7A RID: 113786
		long GetLong();

		// Token: 0x0601BC7B RID: 113787
		string GetString();

		// Token: 0x0601BC7C RID: 113788
		void SetBoolean(bool val);

		// Token: 0x0601BC7D RID: 113789
		void SetDouble(double val);

		// Token: 0x0601BC7E RID: 113790
		void SetInt(int val);

		// Token: 0x0601BC7F RID: 113791
		void SetJsonType(JsonType type);

		// Token: 0x0601BC80 RID: 113792
		void SetLong(long val);

		// Token: 0x0601BC81 RID: 113793
		void SetString(string val);

		// Token: 0x0601BC82 RID: 113794
		string ToJson();

		// Token: 0x0601BC83 RID: 113795
		void ToJson(JsonWriter writer);
	}
}
