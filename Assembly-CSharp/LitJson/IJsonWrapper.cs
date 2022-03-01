using System;
using System.Collections;
using System.Collections.Specialized;

namespace LitJson
{
	// Token: 0x02004699 RID: 18073
	public interface IJsonWrapper : IList, IOrderedDictionary, ICollection, IEnumerable, IDictionary
	{
		// Token: 0x170020DE RID: 8414
		// (get) Token: 0x060198C5 RID: 104645
		bool IsArray { get; }

		// Token: 0x170020DF RID: 8415
		// (get) Token: 0x060198C6 RID: 104646
		bool IsBoolean { get; }

		// Token: 0x170020E0 RID: 8416
		// (get) Token: 0x060198C7 RID: 104647
		bool IsDouble { get; }

		// Token: 0x170020E1 RID: 8417
		// (get) Token: 0x060198C8 RID: 104648
		bool IsInt { get; }

		// Token: 0x170020E2 RID: 8418
		// (get) Token: 0x060198C9 RID: 104649
		bool IsLong { get; }

		// Token: 0x170020E3 RID: 8419
		// (get) Token: 0x060198CA RID: 104650
		bool IsObject { get; }

		// Token: 0x170020E4 RID: 8420
		// (get) Token: 0x060198CB RID: 104651
		bool IsString { get; }

		// Token: 0x060198CC RID: 104652
		bool GetBoolean();

		// Token: 0x060198CD RID: 104653
		double GetDouble();

		// Token: 0x060198CE RID: 104654
		int GetInt();

		// Token: 0x060198CF RID: 104655
		JsonType GetJsonType();

		// Token: 0x060198D0 RID: 104656
		long GetLong();

		// Token: 0x060198D1 RID: 104657
		string GetString();

		// Token: 0x060198D2 RID: 104658
		void SetBoolean(bool val);

		// Token: 0x060198D3 RID: 104659
		void SetDouble(double val);

		// Token: 0x060198D4 RID: 104660
		void SetInt(int val);

		// Token: 0x060198D5 RID: 104661
		void SetJsonType(JsonType type);

		// Token: 0x060198D6 RID: 104662
		void SetLong(long val);

		// Token: 0x060198D7 RID: 104663
		void SetString(string val);

		// Token: 0x060198D8 RID: 104664
		string ToJson();

		// Token: 0x060198D9 RID: 104665
		void ToJson(JsonWriter writer);
	}
}
