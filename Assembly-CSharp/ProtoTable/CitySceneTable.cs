using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000356 RID: 854
	public class CitySceneTable : IFlatbufferObject
	{
		// Token: 0x170007D3 RID: 2003
		// (get) Token: 0x06002495 RID: 9365 RVA: 0x00091520 File Offset: 0x0008F920
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002496 RID: 9366 RVA: 0x0009152D File Offset: 0x0008F92D
		public static CitySceneTable GetRootAsCitySceneTable(ByteBuffer _bb)
		{
			return CitySceneTable.GetRootAsCitySceneTable(_bb, new CitySceneTable());
		}

		// Token: 0x06002497 RID: 9367 RVA: 0x0009153A File Offset: 0x0008F93A
		public static CitySceneTable GetRootAsCitySceneTable(ByteBuffer _bb, CitySceneTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x00091556 File Offset: 0x0008F956
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002499 RID: 9369 RVA: 0x00091570 File Offset: 0x0008F970
		public CitySceneTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170007D4 RID: 2004
		// (get) Token: 0x0600249A RID: 9370 RVA: 0x0009157C File Offset: 0x0008F97C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1787894359 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007D5 RID: 2005
		// (get) Token: 0x0600249B RID: 9371 RVA: 0x000915C8 File Offset: 0x0008F9C8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600249C RID: 9372 RVA: 0x0009160A File Offset: 0x0008FA0A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170007D6 RID: 2006
		// (get) Token: 0x0600249D RID: 9373 RVA: 0x00091618 File Offset: 0x0008FA18
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x0009165A File Offset: 0x0008FA5A
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170007D7 RID: 2007
		// (get) Token: 0x0600249F RID: 9375 RVA: 0x00091668 File Offset: 0x0008FA68
		public int AreaID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1787894359 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007D8 RID: 2008
		// (get) Token: 0x060024A0 RID: 9376 RVA: 0x000916B4 File Offset: 0x0008FAB4
		public int TownID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1787894359 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x060024A1 RID: 9377 RVA: 0x00091700 File Offset: 0x0008FB00
		public int BirthCity
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1787894359 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x060024A2 RID: 9378 RVA: 0x0009174C File Offset: 0x0008FB4C
		public int TraditionSceneID
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1787894359 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007DB RID: 2011
		// (get) Token: 0x060024A3 RID: 9379 RVA: 0x00091798 File Offset: 0x0008FB98
		public int BudoSceneID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1787894359 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007DC RID: 2012
		// (get) Token: 0x060024A4 RID: 9380 RVA: 0x000917E4 File Offset: 0x0008FBE4
		public string ResPath
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060024A5 RID: 9381 RVA: 0x00091827 File Offset: 0x0008FC27
		public ArraySegment<byte>? GetResPathBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x060024A6 RID: 9382 RVA: 0x00091838 File Offset: 0x0008FC38
		public CitySceneTable.eSceneType SceneType
		{
			get
			{
				int num = this.__p.__offset(22);
				return (CitySceneTable.eSceneType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007DE RID: 2014
		// (get) Token: 0x060024A7 RID: 9383 RVA: 0x0009187C File Offset: 0x0008FC7C
		public CitySceneTable.eSceneSubType SceneSubType
		{
			get
			{
				int num = this.__p.__offset(24);
				return (CitySceneTable.eSceneSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x060024A8 RID: 9384 RVA: 0x000918C0 File Offset: 0x0008FCC0
		public int SyncRange
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1787894359 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060024A9 RID: 9385 RVA: 0x0009190C File Offset: 0x0008FD0C
		public string ChapterDataArray(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x060024AA RID: 9386 RVA: 0x00091954 File Offset: 0x0008FD54
		public int ChapterDataLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x060024AB RID: 9387 RVA: 0x00091987 File Offset: 0x0008FD87
		public FlatBufferArray<string> ChapterData
		{
			get
			{
				if (this.ChapterDataValue == null)
				{
					this.ChapterDataValue = new FlatBufferArray<string>(new Func<int, string>(this.ChapterDataArray), this.ChapterDataLength);
				}
				return this.ChapterDataValue;
			}
		}

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x060024AC RID: 9388 RVA: 0x000919B8 File Offset: 0x0008FDB8
		public string BGMPath
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060024AD RID: 9389 RVA: 0x000919FB File Offset: 0x0008FDFB
		public ArraySegment<byte>? GetBGMPathBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x060024AE RID: 9390 RVA: 0x00091A0C File Offset: 0x0008FE0C
		public int LevelLimit
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (1787894359 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x060024AF RID: 9391 RVA: 0x00091A58 File Offset: 0x0008FE58
		public string ExchangeStoreEntrance
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060024B0 RID: 9392 RVA: 0x00091A9B File Offset: 0x0008FE9B
		public ArraySegment<byte>? GetExchangeStoreEntranceBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x060024B1 RID: 9393 RVA: 0x00091AAC File Offset: 0x0008FEAC
		public static Offset<CitySceneTable> CreateCitySceneTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset DescOffset = default(StringOffset), int AreaID = 0, int TownID = 0, int BirthCity = 0, int TraditionSceneID = 0, int BudoSceneID = 0, StringOffset ResPathOffset = default(StringOffset), CitySceneTable.eSceneType SceneType = CitySceneTable.eSceneType.SceneType_None, CitySceneTable.eSceneSubType SceneSubType = CitySceneTable.eSceneSubType.NULL, int SyncRange = 0, VectorOffset ChapterDataOffset = default(VectorOffset), StringOffset BGMPathOffset = default(StringOffset), int LevelLimit = 0, StringOffset ExchangeStoreEntranceOffset = default(StringOffset))
		{
			builder.StartObject(16);
			CitySceneTable.AddExchangeStoreEntrance(builder, ExchangeStoreEntranceOffset);
			CitySceneTable.AddLevelLimit(builder, LevelLimit);
			CitySceneTable.AddBGMPath(builder, BGMPathOffset);
			CitySceneTable.AddChapterData(builder, ChapterDataOffset);
			CitySceneTable.AddSyncRange(builder, SyncRange);
			CitySceneTable.AddSceneSubType(builder, SceneSubType);
			CitySceneTable.AddSceneType(builder, SceneType);
			CitySceneTable.AddResPath(builder, ResPathOffset);
			CitySceneTable.AddBudoSceneID(builder, BudoSceneID);
			CitySceneTable.AddTraditionSceneID(builder, TraditionSceneID);
			CitySceneTable.AddBirthCity(builder, BirthCity);
			CitySceneTable.AddTownID(builder, TownID);
			CitySceneTable.AddAreaID(builder, AreaID);
			CitySceneTable.AddDesc(builder, DescOffset);
			CitySceneTable.AddName(builder, NameOffset);
			CitySceneTable.AddID(builder, ID);
			return CitySceneTable.EndCitySceneTable(builder);
		}

		// Token: 0x060024B2 RID: 9394 RVA: 0x00091B44 File Offset: 0x0008FF44
		public static void StartCitySceneTable(FlatBufferBuilder builder)
		{
			builder.StartObject(16);
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x00091B4E File Offset: 0x0008FF4E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x00091B59 File Offset: 0x0008FF59
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x00091B6A File Offset: 0x0008FF6A
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(2, DescOffset.Value, 0);
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x00091B7B File Offset: 0x0008FF7B
		public static void AddAreaID(FlatBufferBuilder builder, int AreaID)
		{
			builder.AddInt(3, AreaID, 0);
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x00091B86 File Offset: 0x0008FF86
		public static void AddTownID(FlatBufferBuilder builder, int TownID)
		{
			builder.AddInt(4, TownID, 0);
		}

		// Token: 0x060024B8 RID: 9400 RVA: 0x00091B91 File Offset: 0x0008FF91
		public static void AddBirthCity(FlatBufferBuilder builder, int BirthCity)
		{
			builder.AddInt(5, BirthCity, 0);
		}

		// Token: 0x060024B9 RID: 9401 RVA: 0x00091B9C File Offset: 0x0008FF9C
		public static void AddTraditionSceneID(FlatBufferBuilder builder, int TraditionSceneID)
		{
			builder.AddInt(6, TraditionSceneID, 0);
		}

		// Token: 0x060024BA RID: 9402 RVA: 0x00091BA7 File Offset: 0x0008FFA7
		public static void AddBudoSceneID(FlatBufferBuilder builder, int BudoSceneID)
		{
			builder.AddInt(7, BudoSceneID, 0);
		}

		// Token: 0x060024BB RID: 9403 RVA: 0x00091BB2 File Offset: 0x0008FFB2
		public static void AddResPath(FlatBufferBuilder builder, StringOffset ResPathOffset)
		{
			builder.AddOffset(8, ResPathOffset.Value, 0);
		}

		// Token: 0x060024BC RID: 9404 RVA: 0x00091BC3 File Offset: 0x0008FFC3
		public static void AddSceneType(FlatBufferBuilder builder, CitySceneTable.eSceneType SceneType)
		{
			builder.AddInt(9, (int)SceneType, 0);
		}

		// Token: 0x060024BD RID: 9405 RVA: 0x00091BCF File Offset: 0x0008FFCF
		public static void AddSceneSubType(FlatBufferBuilder builder, CitySceneTable.eSceneSubType SceneSubType)
		{
			builder.AddInt(10, (int)SceneSubType, 0);
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x00091BDB File Offset: 0x0008FFDB
		public static void AddSyncRange(FlatBufferBuilder builder, int SyncRange)
		{
			builder.AddInt(11, SyncRange, 0);
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x00091BE7 File Offset: 0x0008FFE7
		public static void AddChapterData(FlatBufferBuilder builder, VectorOffset ChapterDataOffset)
		{
			builder.AddOffset(12, ChapterDataOffset.Value, 0);
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x00091BFC File Offset: 0x0008FFFC
		public static VectorOffset CreateChapterDataVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x00091C42 File Offset: 0x00090042
		public static void StartChapterDataVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x00091C4D File Offset: 0x0009004D
		public static void AddBGMPath(FlatBufferBuilder builder, StringOffset BGMPathOffset)
		{
			builder.AddOffset(13, BGMPathOffset.Value, 0);
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x00091C5F File Offset: 0x0009005F
		public static void AddLevelLimit(FlatBufferBuilder builder, int LevelLimit)
		{
			builder.AddInt(14, LevelLimit, 0);
		}

		// Token: 0x060024C4 RID: 9412 RVA: 0x00091C6B File Offset: 0x0009006B
		public static void AddExchangeStoreEntrance(FlatBufferBuilder builder, StringOffset ExchangeStoreEntranceOffset)
		{
			builder.AddOffset(15, ExchangeStoreEntranceOffset.Value, 0);
		}

		// Token: 0x060024C5 RID: 9413 RVA: 0x00091C80 File Offset: 0x00090080
		public static Offset<CitySceneTable> EndCitySceneTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<CitySceneTable>(value);
		}

		// Token: 0x060024C6 RID: 9414 RVA: 0x00091C9A File Offset: 0x0009009A
		public static void FinishCitySceneTableBuffer(FlatBufferBuilder builder, Offset<CitySceneTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040010FC RID: 4348
		private Table __p = new Table();

		// Token: 0x040010FD RID: 4349
		private FlatBufferArray<string> ChapterDataValue;

		// Token: 0x02000357 RID: 855
		public enum eSceneType
		{
			// Token: 0x040010FF RID: 4351
			SceneType_None,
			// Token: 0x04001100 RID: 4352
			NORMAL,
			// Token: 0x04001101 RID: 4353
			SINGLE = 9,
			// Token: 0x04001102 RID: 4354
			DUNGEON_ENTRY,
			// Token: 0x04001103 RID: 4355
			PK_PREPARE,
			// Token: 0x04001104 RID: 4356
			PK,
			// Token: 0x04001105 RID: 4357
			ACTIVITY,
			// Token: 0x04001106 RID: 4358
			BATTLE = 4,
			// Token: 0x04001107 RID: 4359
			BATTLEPEPARE = 14,
			// Token: 0x04001108 RID: 4360
			TEAMDUPLICATION,
			// Token: 0x04001109 RID: 4361
			CHAMPIONSHIP = 17
		}

		// Token: 0x02000358 RID: 856
		public enum eSceneSubType
		{
			// Token: 0x0400110B RID: 4363
			NULL,
			// Token: 0x0400110C RID: 4364
			TRADITION,
			// Token: 0x0400110D RID: 4365
			BUDO,
			// Token: 0x0400110E RID: 4366
			GuildBattle,
			// Token: 0x0400110F RID: 4367
			MoneyRewards,
			// Token: 0x04001110 RID: 4368
			Pk3v3,
			// Token: 0x04001111 RID: 4369
			CrossGuildBattle,
			// Token: 0x04001112 RID: 4370
			CrossPk3v3,
			// Token: 0x04001113 RID: 4371
			Guild,
			// Token: 0x04001114 RID: 4372
			Battle,
			// Token: 0x04001115 RID: 4373
			BattlePrepare,
			// Token: 0x04001116 RID: 4374
			FairDuelPrepare,
			// Token: 0x04001117 RID: 4375
			TeamDuplicationBuid,
			// Token: 0x04001118 RID: 4376
			TeamDuplicationFight,
			// Token: 0x04001119 RID: 4377
			Melee2v2Cross,
			// Token: 0x0400111A RID: 4378
			ChampionshipEntry = 17
		}

		// Token: 0x02000359 RID: 857
		public enum eCrypt
		{
			// Token: 0x0400111C RID: 4380
			code = 1787894359
		}
	}
}
