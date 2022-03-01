using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200052B RID: 1323
	public class NewbieGuideTable : IFlatbufferObject
	{
		// Token: 0x1700121C RID: 4636
		// (get) Token: 0x060043F5 RID: 17397 RVA: 0x000DBB28 File Offset: 0x000D9F28
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060043F6 RID: 17398 RVA: 0x000DBB35 File Offset: 0x000D9F35
		public static NewbieGuideTable GetRootAsNewbieGuideTable(ByteBuffer _bb)
		{
			return NewbieGuideTable.GetRootAsNewbieGuideTable(_bb, new NewbieGuideTable());
		}

		// Token: 0x060043F7 RID: 17399 RVA: 0x000DBB42 File Offset: 0x000D9F42
		public static NewbieGuideTable GetRootAsNewbieGuideTable(ByteBuffer _bb, NewbieGuideTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060043F8 RID: 17400 RVA: 0x000DBB5E File Offset: 0x000D9F5E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060043F9 RID: 17401 RVA: 0x000DBB78 File Offset: 0x000D9F78
		public NewbieGuideTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700121D RID: 4637
		// (get) Token: 0x060043FA RID: 17402 RVA: 0x000DBB84 File Offset: 0x000D9F84
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1395428350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700121E RID: 4638
		// (get) Token: 0x060043FB RID: 17403 RVA: 0x000DBBD0 File Offset: 0x000D9FD0
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060043FC RID: 17404 RVA: 0x000DBC12 File Offset: 0x000DA012
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700121F RID: 4639
		// (get) Token: 0x060043FD RID: 17405 RVA: 0x000DBC20 File Offset: 0x000DA020
		public NewbieGuideTable.eNewbieGuideTask NewbieGuideTask
		{
			get
			{
				int num = this.__p.__offset(8);
				return (NewbieGuideTable.eNewbieGuideTask)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001220 RID: 4640
		// (get) Token: 0x060043FE RID: 17406 RVA: 0x000DBC64 File Offset: 0x000DA064
		public int Order
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1395428350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001221 RID: 4641
		// (get) Token: 0x060043FF RID: 17407 RVA: 0x000DBCB0 File Offset: 0x000DA0B0
		public int IsOpen
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1395428350 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001222 RID: 4642
		// (get) Token: 0x06004400 RID: 17408 RVA: 0x000DBCFC File Offset: 0x000DA0FC
		public NewbieGuideTable.eNewbieGuideType NewbieGuideType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (NewbieGuideTable.eNewbieGuideType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001223 RID: 4643
		// (get) Token: 0x06004401 RID: 17409 RVA: 0x000DBD40 File Offset: 0x000DA140
		public NewbieGuideTable.eGuideSubType GuideSubType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (NewbieGuideTable.eGuideSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001224 RID: 4644
		// (get) Token: 0x06004402 RID: 17410 RVA: 0x000DBD84 File Offset: 0x000DA184
		public bool CloseFrames
		{
			get
			{
				int num = this.__p.__offset(18);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17001225 RID: 4645
		// (get) Token: 0x06004403 RID: 17411 RVA: 0x000DBDD0 File Offset: 0x000DA1D0
		public string ScriptDataPath
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004404 RID: 17412 RVA: 0x000DBE13 File Offset: 0x000DA213
		public ArraySegment<byte>? GetScriptDataPathBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x06004405 RID: 17413 RVA: 0x000DBE24 File Offset: 0x000DA224
		public int AudioIDListArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (1395428350 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001226 RID: 4646
		// (get) Token: 0x06004406 RID: 17414 RVA: 0x000DBE74 File Offset: 0x000DA274
		public int AudioIDListLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004407 RID: 17415 RVA: 0x000DBEA7 File Offset: 0x000DA2A7
		public ArraySegment<byte>? GetAudioIDListBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17001227 RID: 4647
		// (get) Token: 0x06004408 RID: 17416 RVA: 0x000DBEB6 File Offset: 0x000DA2B6
		public FlatBufferArray<int> AudioIDList
		{
			get
			{
				if (this.AudioIDListValue == null)
				{
					this.AudioIDListValue = new FlatBufferArray<int>(new Func<int, int>(this.AudioIDListArray), this.AudioIDListLength);
				}
				return this.AudioIDListValue;
			}
		}

		// Token: 0x06004409 RID: 17417 RVA: 0x000DBEE8 File Offset: 0x000DA2E8
		public static Offset<NewbieGuideTable> CreateNewbieGuideTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), NewbieGuideTable.eNewbieGuideTask NewbieGuideTask = NewbieGuideTable.eNewbieGuideTask.None, int Order = 0, int IsOpen = 0, NewbieGuideTable.eNewbieGuideType NewbieGuideType = NewbieGuideTable.eNewbieGuideType.NGT_None, NewbieGuideTable.eGuideSubType GuideSubType = NewbieGuideTable.eGuideSubType.GST_NONE, bool CloseFrames = false, StringOffset ScriptDataPathOffset = default(StringOffset), VectorOffset AudioIDListOffset = default(VectorOffset))
		{
			builder.StartObject(10);
			NewbieGuideTable.AddAudioIDList(builder, AudioIDListOffset);
			NewbieGuideTable.AddScriptDataPath(builder, ScriptDataPathOffset);
			NewbieGuideTable.AddGuideSubType(builder, GuideSubType);
			NewbieGuideTable.AddNewbieGuideType(builder, NewbieGuideType);
			NewbieGuideTable.AddIsOpen(builder, IsOpen);
			NewbieGuideTable.AddOrder(builder, Order);
			NewbieGuideTable.AddNewbieGuideTask(builder, NewbieGuideTask);
			NewbieGuideTable.AddName(builder, NameOffset);
			NewbieGuideTable.AddID(builder, ID);
			NewbieGuideTable.AddCloseFrames(builder, CloseFrames);
			return NewbieGuideTable.EndNewbieGuideTable(builder);
		}

		// Token: 0x0600440A RID: 17418 RVA: 0x000DBF50 File Offset: 0x000DA350
		public static void StartNewbieGuideTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x0600440B RID: 17419 RVA: 0x000DBF5A File Offset: 0x000DA35A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600440C RID: 17420 RVA: 0x000DBF65 File Offset: 0x000DA365
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x0600440D RID: 17421 RVA: 0x000DBF76 File Offset: 0x000DA376
		public static void AddNewbieGuideTask(FlatBufferBuilder builder, NewbieGuideTable.eNewbieGuideTask NewbieGuideTask)
		{
			builder.AddInt(2, (int)NewbieGuideTask, 0);
		}

		// Token: 0x0600440E RID: 17422 RVA: 0x000DBF81 File Offset: 0x000DA381
		public static void AddOrder(FlatBufferBuilder builder, int Order)
		{
			builder.AddInt(3, Order, 0);
		}

		// Token: 0x0600440F RID: 17423 RVA: 0x000DBF8C File Offset: 0x000DA38C
		public static void AddIsOpen(FlatBufferBuilder builder, int IsOpen)
		{
			builder.AddInt(4, IsOpen, 0);
		}

		// Token: 0x06004410 RID: 17424 RVA: 0x000DBF97 File Offset: 0x000DA397
		public static void AddNewbieGuideType(FlatBufferBuilder builder, NewbieGuideTable.eNewbieGuideType NewbieGuideType)
		{
			builder.AddInt(5, (int)NewbieGuideType, 0);
		}

		// Token: 0x06004411 RID: 17425 RVA: 0x000DBFA2 File Offset: 0x000DA3A2
		public static void AddGuideSubType(FlatBufferBuilder builder, NewbieGuideTable.eGuideSubType GuideSubType)
		{
			builder.AddInt(6, (int)GuideSubType, 0);
		}

		// Token: 0x06004412 RID: 17426 RVA: 0x000DBFAD File Offset: 0x000DA3AD
		public static void AddCloseFrames(FlatBufferBuilder builder, bool CloseFrames)
		{
			builder.AddBool(7, CloseFrames, false);
		}

		// Token: 0x06004413 RID: 17427 RVA: 0x000DBFB8 File Offset: 0x000DA3B8
		public static void AddScriptDataPath(FlatBufferBuilder builder, StringOffset ScriptDataPathOffset)
		{
			builder.AddOffset(8, ScriptDataPathOffset.Value, 0);
		}

		// Token: 0x06004414 RID: 17428 RVA: 0x000DBFC9 File Offset: 0x000DA3C9
		public static void AddAudioIDList(FlatBufferBuilder builder, VectorOffset AudioIDListOffset)
		{
			builder.AddOffset(9, AudioIDListOffset.Value, 0);
		}

		// Token: 0x06004415 RID: 17429 RVA: 0x000DBFDC File Offset: 0x000DA3DC
		public static VectorOffset CreateAudioIDListVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004416 RID: 17430 RVA: 0x000DC019 File Offset: 0x000DA419
		public static void StartAudioIDListVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004417 RID: 17431 RVA: 0x000DC024 File Offset: 0x000DA424
		public static Offset<NewbieGuideTable> EndNewbieGuideTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<NewbieGuideTable>(value);
		}

		// Token: 0x06004418 RID: 17432 RVA: 0x000DC03E File Offset: 0x000DA43E
		public static void FinishNewbieGuideTableBuffer(FlatBufferBuilder builder, Offset<NewbieGuideTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001904 RID: 6404
		private Table __p = new Table();

		// Token: 0x04001905 RID: 6405
		private FlatBufferArray<int> AudioIDListValue;

		// Token: 0x0200052C RID: 1324
		public enum eNewbieGuideTask
		{
			// Token: 0x04001907 RID: 6407
			None,
			// Token: 0x04001908 RID: 6408
			FirstFight,
			// Token: 0x04001909 RID: 6409
			AutoTraceGuide,
			// Token: 0x0400190A RID: 6410
			GuanKaGuide,
			// Token: 0x0400190B RID: 6411
			DoubleClickRunGuide,
			// Token: 0x0400190C RID: 6412
			DungeonRewardGuide,
			// Token: 0x0400190D RID: 6413
			ReturnToTownGuide,
			// Token: 0x0400190E RID: 6414
			EquipmentGuide,
			// Token: 0x0400190F RID: 6415
			AutoTraceGuide2,
			// Token: 0x04001910 RID: 6416
			JumpBackGuide,
			// Token: 0x04001911 RID: 6417
			QuickEquipGuide,
			// Token: 0x04001912 RID: 6418
			RewardBoxGuide,
			// Token: 0x04001913 RID: 6419
			EvaluateGuide,
			// Token: 0x04001914 RID: 6420
			DrugGuide,
			// Token: 0x04001915 RID: 6421
			SuperArmorGuide,
			// Token: 0x04001916 RID: 6422
			CounterGuide,
			// Token: 0x04001917 RID: 6423
			MagicPotGuide,
			// Token: 0x04001918 RID: 6424
			SkillGuide,
			// Token: 0x04001919 RID: 6425
			DrugSetGuide,
			// Token: 0x0400191A RID: 6426
			SkillLevelUpGuide,
			// Token: 0x0400191B RID: 6427
			RankListGuide,
			// Token: 0x0400191C RID: 6428
			WelfareGuide,
			// Token: 0x0400191D RID: 6429
			ForgeGuide,
			// Token: 0x0400191E RID: 6430
			DuelGuide,
			// Token: 0x0400191F RID: 6431
			MakeEquipGuide,
			// Token: 0x04001920 RID: 6432
			EntourageGuide,
			// Token: 0x04001921 RID: 6433
			EntourageSkillGuide,
			// Token: 0x04001922 RID: 6434
			EntourageSkillLvUpGuide,
			// Token: 0x04001923 RID: 6435
			AutoFightGuide,
			// Token: 0x04001924 RID: 6436
			MarketGuide,
			// Token: 0x04001925 RID: 6437
			DailyTaskGuide,
			// Token: 0x04001926 RID: 6438
			TitleGuide,
			// Token: 0x04001927 RID: 6439
			BattlePreJobSkillGuide,
			// Token: 0x04001928 RID: 6440
			ArmorMasterGuide,
			// Token: 0x04001929 RID: 6441
			BufferSkillGuide,
			// Token: 0x0400192A RID: 6442
			DeathTowerGuide,
			// Token: 0x0400192B RID: 6443
			BeatCowGuide,
			// Token: 0x0400192C RID: 6444
			GuildGuide,
			// Token: 0x0400192D RID: 6445
			EnchantGuide,
			// Token: 0x0400192E RID: 6446
			DegeneratorGuide,
			// Token: 0x0400192F RID: 6447
			ChangeJobChoiceGuide,
			// Token: 0x04001930 RID: 6448
			TeamBossGuide,
			// Token: 0x04001931 RID: 6449
			EntourageWashGuide,
			// Token: 0x04001932 RID: 6450
			FriendGuide,
			// Token: 0x04001933 RID: 6451
			TeamGuide,
			// Token: 0x04001934 RID: 6452
			MissionGuide,
			// Token: 0x04001935 RID: 6453
			ChangeJobSkillGuide,
			// Token: 0x04001936 RID: 6454
			FirstChargeGuide,
			// Token: 0x04001937 RID: 6455
			ArmorPunishGuide,
			// Token: 0x04001938 RID: 6456
			BreakDownHaveWhiteGuide,
			// Token: 0x04001939 RID: 6457
			BreakDownHavenotWhiteGuide,
			// Token: 0x0400193A RID: 6458
			NextBoxGuide,
			// Token: 0x0400193B RID: 6459
			SkillComboGuide1,
			// Token: 0x0400193C RID: 6460
			SkillComboGuide2,
			// Token: 0x0400193D RID: 6461
			TwoWeaponsGuide,
			// Token: 0x0400193E RID: 6462
			AbyssGuide1,
			// Token: 0x0400193F RID: 6463
			AbyssGuide2,
			// Token: 0x04001940 RID: 6464
			AbyssGuide3,
			// Token: 0x04001941 RID: 6465
			HandbookGuide,
			// Token: 0x04001942 RID: 6466
			ExchangeShopGuide,
			// Token: 0x04001943 RID: 6467
			AncientGuide,
			// Token: 0x04001944 RID: 6468
			YiJieOpenGuide
		}

		// Token: 0x0200052D RID: 1325
		public enum eNewbieGuideType
		{
			// Token: 0x04001946 RID: 6470
			NGT_None,
			// Token: 0x04001947 RID: 6471
			NGT_FORCE,
			// Token: 0x04001948 RID: 6472
			NGT_WEAK,
			// Token: 0x04001949 RID: 6473
			NGT_ALL
		}

		// Token: 0x0200052E RID: 1326
		public enum eGuideSubType
		{
			// Token: 0x0400194B RID: 6475
			GST_NONE,
			// Token: 0x0400194C RID: 6476
			GST_ALONE,
			// Token: 0x0400194D RID: 6477
			GST_FINISH_TALK_DIALOG,
			// Token: 0x0400194E RID: 6478
			GST_ACCEPT_MISSION,
			// Token: 0x0400194F RID: 6479
			GST_FINISH_MISSION,
			// Token: 0x04001950 RID: 6480
			GST_RECEIVE_MISSION_AWARD
		}

		// Token: 0x0200052F RID: 1327
		public enum eCrypt
		{
			// Token: 0x04001952 RID: 6482
			code = 1395428350
		}
	}
}
