using System;
using System.Collections;
using System.Collections.Specialized;

namespace YIMEngine
{
	// Token: 0x02004A76 RID: 19062
	public interface IJsonWrapper : IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x170024E8 RID: 9448
		// (get) Token: 0x0601B999 RID: 113049
		bool IsArray { get; }

		// Token: 0x170024E9 RID: 9449
		// (get) Token: 0x0601B99A RID: 113050
		bool IsBoolean { get; }

		// Token: 0x170024EA RID: 9450
		// (get) Token: 0x0601B99B RID: 113051
		bool IsDouble { get; }

		// Token: 0x170024EB RID: 9451
		// (get) Token: 0x0601B99C RID: 113052
		bool IsInt { get; }

		// Token: 0x170024EC RID: 9452
		// (get) Token: 0x0601B99D RID: 113053
		bool IsLong { get; }

		// Token: 0x170024ED RID: 9453
		// (get) Token: 0x0601B99E RID: 113054
		bool IsObject { get; }

		// Token: 0x170024EE RID: 9454
		// (get) Token: 0x0601B99F RID: 113055
		bool IsString { get; }

		// Token: 0x0601B9A0 RID: 113056
		bool GetBoolean();

		// Token: 0x0601B9A1 RID: 113057
		double GetDouble();

		// Token: 0x0601B9A2 RID: 113058
		int GetInt();

		// Token: 0x0601B9A3 RID: 113059
		JsonType GetJsonType();

		// Token: 0x0601B9A4 RID: 113060
		long GetLong();

		// Token: 0x0601B9A5 RID: 113061
		string GetString();

		// Token: 0x0601B9A6 RID: 113062
		void SetBoolean(bool val);

		// Token: 0x0601B9A7 RID: 113063
		void SetDouble(double val);

		// Token: 0x0601B9A8 RID: 113064
		void SetInt(int val);

		// Token: 0x0601B9A9 RID: 113065
		void SetJsonType(JsonType type);

		// Token: 0x0601B9AA RID: 113066
		void SetLong(long val);

		// Token: 0x0601B9AB RID: 113067
		void SetString(string val);

		// Token: 0x0601B9AC RID: 113068
		string ToJson();

		// Token: 0x0601B9AD RID: 113069
		void ToJson(JsonWriter writer);
	}
}
