using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000441 RID: 1089
	public class FunctionUnLock : IFlatbufferObject
	{
		// Token: 0x17000CD7 RID: 3287
		// (get) Token: 0x0600340D RID: 13325 RVA: 0x000B6148 File Offset: 0x000B4548
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600340E RID: 13326 RVA: 0x000B6155 File Offset: 0x000B4555
		public static FunctionUnLock GetRootAsFunctionUnLock(ByteBuffer _bb)
		{
			return FunctionUnLock.GetRootAsFunctionUnLock(_bb, new FunctionUnLock());
		}

		// Token: 0x0600340F RID: 13327 RVA: 0x000B6162 File Offset: 0x000B4562
		public static FunctionUnLock GetRootAsFunctionUnLock(ByteBuffer _bb, FunctionUnLock obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003410 RID: 13328 RVA: 0x000B617E File Offset: 0x000B457E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003411 RID: 13329 RVA: 0x000B6198 File Offset: 0x000B4598
		public FunctionUnLock __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000CD8 RID: 3288
		// (get) Token: 0x06003412 RID: 13330 RVA: 0x000B61A4 File Offset: 0x000B45A4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CD9 RID: 3289
		// (get) Token: 0x06003413 RID: 13331 RVA: 0x000B61F0 File Offset: 0x000B45F0
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003414 RID: 13332 RVA: 0x000B6232 File Offset: 0x000B4632
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000CDA RID: 3290
		// (get) Token: 0x06003415 RID: 13333 RVA: 0x000B6240 File Offset: 0x000B4640
		public FunctionUnLock.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (FunctionUnLock.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CDB RID: 3291
		// (get) Token: 0x06003416 RID: 13334 RVA: 0x000B6284 File Offset: 0x000B4684
		public FunctionUnLock.eFuncType FuncType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (FunctionUnLock.eFuncType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CDC RID: 3292
		// (get) Token: 0x06003417 RID: 13335 RVA: 0x000B62C8 File Offset: 0x000B46C8
		public int CommDescID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CDD RID: 3293
		// (get) Token: 0x06003418 RID: 13336 RVA: 0x000B6314 File Offset: 0x000B4714
		public int StartLevel
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CDE RID: 3294
		// (get) Token: 0x06003419 RID: 13337 RVA: 0x000B6360 File Offset: 0x000B4760
		public int FinishLevel
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CDF RID: 3295
		// (get) Token: 0x0600341A RID: 13338 RVA: 0x000B63AC File Offset: 0x000B47AC
		public bool IsOpen
		{
			get
			{
				int num = this.__p.__offset(18);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000CE0 RID: 3296
		// (get) Token: 0x0600341B RID: 13339 RVA: 0x000B63F8 File Offset: 0x000B47F8
		public int StartTaskID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CE1 RID: 3297
		// (get) Token: 0x0600341C RID: 13340 RVA: 0x000B6444 File Offset: 0x000B4844
		public int FinishTaskID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CE2 RID: 3298
		// (get) Token: 0x0600341D RID: 13341 RVA: 0x000B6490 File Offset: 0x000B4890
		public int PosPriority
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CE3 RID: 3299
		// (get) Token: 0x0600341E RID: 13342 RVA: 0x000B64DC File Offset: 0x000B48DC
		public string TargetBtnPos
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600341F RID: 13343 RVA: 0x000B651F File Offset: 0x000B491F
		public ArraySegment<byte>? GetTargetBtnPosBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000CE4 RID: 3300
		// (get) Token: 0x06003420 RID: 13344 RVA: 0x000B6530 File Offset: 0x000B4930
		public int bPlayAnim
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CE5 RID: 3301
		// (get) Token: 0x06003421 RID: 13345 RVA: 0x000B657C File Offset: 0x000B497C
		public int bShowBtn
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CE6 RID: 3302
		// (get) Token: 0x06003422 RID: 13346 RVA: 0x000B65C8 File Offset: 0x000B49C8
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003423 RID: 13347 RVA: 0x000B660B File Offset: 0x000B4A0B
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000CE7 RID: 3303
		// (get) Token: 0x06003424 RID: 13348 RVA: 0x000B661C File Offset: 0x000B4A1C
		public int AreaID
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CE8 RID: 3304
		// (get) Token: 0x06003425 RID: 13349 RVA: 0x000B6668 File Offset: 0x000B4A68
		public string Award
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003426 RID: 13350 RVA: 0x000B66AB File Offset: 0x000B4AAB
		public ArraySegment<byte>? GetAwardBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17000CE9 RID: 3305
		// (get) Token: 0x06003427 RID: 13351 RVA: 0x000B66BC File Offset: 0x000B4ABC
		public string Explanation
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003428 RID: 13352 RVA: 0x000B66FF File Offset: 0x000B4AFF
		public ArraySegment<byte>? GetExplanationBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17000CEA RID: 3306
		// (get) Token: 0x06003429 RID: 13353 RVA: 0x000B6710 File Offset: 0x000B4B10
		public FunctionUnLock.eExpandType ExpandType
		{
			get
			{
				int num = this.__p.__offset(40);
				return (FunctionUnLock.eExpandType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CEB RID: 3307
		// (get) Token: 0x0600342A RID: 13354 RVA: 0x000B6754 File Offset: 0x000B4B54
		public FunctionUnLock.eBindType BindType
		{
			get
			{
				int num = this.__p.__offset(42);
				return (FunctionUnLock.eBindType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CEC RID: 3308
		// (get) Token: 0x0600342B RID: 13355 RVA: 0x000B6798 File Offset: 0x000B4B98
		public int ShowFunctionOpen
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (1970490982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600342C RID: 13356 RVA: 0x000B67E4 File Offset: 0x000B4BE4
		public static Offset<FunctionUnLock> CreateFunctionUnLock(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), FunctionUnLock.eType Type = FunctionUnLock.eType.Type_None, FunctionUnLock.eFuncType FuncType = FunctionUnLock.eFuncType.None, int CommDescID = 0, int StartLevel = 0, int FinishLevel = 0, bool IsOpen = false, int StartTaskID = 0, int FinishTaskID = 0, int PosPriority = 0, StringOffset TargetBtnPosOffset = default(StringOffset), int bPlayAnim = 0, int bShowBtn = 0, StringOffset IconPathOffset = default(StringOffset), int AreaID = 0, StringOffset AwardOffset = default(StringOffset), StringOffset ExplanationOffset = default(StringOffset), FunctionUnLock.eExpandType ExpandType = FunctionUnLock.eExpandType.ET_Null, FunctionUnLock.eBindType BindType = FunctionUnLock.eBindType.BT_RoleBind, int ShowFunctionOpen = 0)
		{
			builder.StartObject(21);
			FunctionUnLock.AddShowFunctionOpen(builder, ShowFunctionOpen);
			FunctionUnLock.AddBindType(builder, BindType);
			FunctionUnLock.AddExpandType(builder, ExpandType);
			FunctionUnLock.AddExplanation(builder, ExplanationOffset);
			FunctionUnLock.AddAward(builder, AwardOffset);
			FunctionUnLock.AddAreaID(builder, AreaID);
			FunctionUnLock.AddIconPath(builder, IconPathOffset);
			FunctionUnLock.AddBShowBtn(builder, bShowBtn);
			FunctionUnLock.AddBPlayAnim(builder, bPlayAnim);
			FunctionUnLock.AddTargetBtnPos(builder, TargetBtnPosOffset);
			FunctionUnLock.AddPosPriority(builder, PosPriority);
			FunctionUnLock.AddFinishTaskID(builder, FinishTaskID);
			FunctionUnLock.AddStartTaskID(builder, StartTaskID);
			FunctionUnLock.AddFinishLevel(builder, FinishLevel);
			FunctionUnLock.AddStartLevel(builder, StartLevel);
			FunctionUnLock.AddCommDescID(builder, CommDescID);
			FunctionUnLock.AddFuncType(builder, FuncType);
			FunctionUnLock.AddType(builder, Type);
			FunctionUnLock.AddName(builder, NameOffset);
			FunctionUnLock.AddID(builder, ID);
			FunctionUnLock.AddIsOpen(builder, IsOpen);
			return FunctionUnLock.EndFunctionUnLock(builder);
		}

		// Token: 0x0600342D RID: 13357 RVA: 0x000B68A4 File Offset: 0x000B4CA4
		public static void StartFunctionUnLock(FlatBufferBuilder builder)
		{
			builder.StartObject(21);
		}

		// Token: 0x0600342E RID: 13358 RVA: 0x000B68AE File Offset: 0x000B4CAE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600342F RID: 13359 RVA: 0x000B68B9 File Offset: 0x000B4CB9
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003430 RID: 13360 RVA: 0x000B68CA File Offset: 0x000B4CCA
		public static void AddType(FlatBufferBuilder builder, FunctionUnLock.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06003431 RID: 13361 RVA: 0x000B68D5 File Offset: 0x000B4CD5
		public static void AddFuncType(FlatBufferBuilder builder, FunctionUnLock.eFuncType FuncType)
		{
			builder.AddInt(3, (int)FuncType, 0);
		}

		// Token: 0x06003432 RID: 13362 RVA: 0x000B68E0 File Offset: 0x000B4CE0
		public static void AddCommDescID(FlatBufferBuilder builder, int CommDescID)
		{
			builder.AddInt(4, CommDescID, 0);
		}

		// Token: 0x06003433 RID: 13363 RVA: 0x000B68EB File Offset: 0x000B4CEB
		public static void AddStartLevel(FlatBufferBuilder builder, int StartLevel)
		{
			builder.AddInt(5, StartLevel, 0);
		}

		// Token: 0x06003434 RID: 13364 RVA: 0x000B68F6 File Offset: 0x000B4CF6
		public static void AddFinishLevel(FlatBufferBuilder builder, int FinishLevel)
		{
			builder.AddInt(6, FinishLevel, 0);
		}

		// Token: 0x06003435 RID: 13365 RVA: 0x000B6901 File Offset: 0x000B4D01
		public static void AddIsOpen(FlatBufferBuilder builder, bool IsOpen)
		{
			builder.AddBool(7, IsOpen, false);
		}

		// Token: 0x06003436 RID: 13366 RVA: 0x000B690C File Offset: 0x000B4D0C
		public static void AddStartTaskID(FlatBufferBuilder builder, int StartTaskID)
		{
			builder.AddInt(8, StartTaskID, 0);
		}

		// Token: 0x06003437 RID: 13367 RVA: 0x000B6917 File Offset: 0x000B4D17
		public static void AddFinishTaskID(FlatBufferBuilder builder, int FinishTaskID)
		{
			builder.AddInt(9, FinishTaskID, 0);
		}

		// Token: 0x06003438 RID: 13368 RVA: 0x000B6923 File Offset: 0x000B4D23
		public static void AddPosPriority(FlatBufferBuilder builder, int PosPriority)
		{
			builder.AddInt(10, PosPriority, 0);
		}

		// Token: 0x06003439 RID: 13369 RVA: 0x000B692F File Offset: 0x000B4D2F
		public static void AddTargetBtnPos(FlatBufferBuilder builder, StringOffset TargetBtnPosOffset)
		{
			builder.AddOffset(11, TargetBtnPosOffset.Value, 0);
		}

		// Token: 0x0600343A RID: 13370 RVA: 0x000B6941 File Offset: 0x000B4D41
		public static void AddBPlayAnim(FlatBufferBuilder builder, int bPlayAnim)
		{
			builder.AddInt(12, bPlayAnim, 0);
		}

		// Token: 0x0600343B RID: 13371 RVA: 0x000B694D File Offset: 0x000B4D4D
		public static void AddBShowBtn(FlatBufferBuilder builder, int bShowBtn)
		{
			builder.AddInt(13, bShowBtn, 0);
		}

		// Token: 0x0600343C RID: 13372 RVA: 0x000B6959 File Offset: 0x000B4D59
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(14, IconPathOffset.Value, 0);
		}

		// Token: 0x0600343D RID: 13373 RVA: 0x000B696B File Offset: 0x000B4D6B
		public static void AddAreaID(FlatBufferBuilder builder, int AreaID)
		{
			builder.AddInt(15, AreaID, 0);
		}

		// Token: 0x0600343E RID: 13374 RVA: 0x000B6977 File Offset: 0x000B4D77
		public static void AddAward(FlatBufferBuilder builder, StringOffset AwardOffset)
		{
			builder.AddOffset(16, AwardOffset.Value, 0);
		}

		// Token: 0x0600343F RID: 13375 RVA: 0x000B6989 File Offset: 0x000B4D89
		public static void AddExplanation(FlatBufferBuilder builder, StringOffset ExplanationOffset)
		{
			builder.AddOffset(17, ExplanationOffset.Value, 0);
		}

		// Token: 0x06003440 RID: 13376 RVA: 0x000B699B File Offset: 0x000B4D9B
		public static void AddExpandType(FlatBufferBuilder builder, FunctionUnLock.eExpandType ExpandType)
		{
			builder.AddInt(18, (int)ExpandType, 0);
		}

		// Token: 0x06003441 RID: 13377 RVA: 0x000B69A7 File Offset: 0x000B4DA7
		public static void AddBindType(FlatBufferBuilder builder, FunctionUnLock.eBindType BindType)
		{
			builder.AddInt(19, (int)BindType, 0);
		}

		// Token: 0x06003442 RID: 13378 RVA: 0x000B69B3 File Offset: 0x000B4DB3
		public static void AddShowFunctionOpen(FlatBufferBuilder builder, int ShowFunctionOpen)
		{
			builder.AddInt(20, ShowFunctionOpen, 0);
		}

		// Token: 0x06003443 RID: 13379 RVA: 0x000B69C0 File Offset: 0x000B4DC0
		public static Offset<FunctionUnLock> EndFunctionUnLock(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FunctionUnLock>(value);
		}

		// Token: 0x06003444 RID: 13380 RVA: 0x000B69DA File Offset: 0x000B4DDA
		public static void FinishFunctionUnLockBuffer(FlatBufferBuilder builder, Offset<FunctionUnLock> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400150E RID: 5390
		private Table __p = new Table();

		// Token: 0x02000442 RID: 1090
		public enum eType
		{
			// Token: 0x04001510 RID: 5392
			Type_None,
			// Token: 0x04001511 RID: 5393
			Func,
			// Token: 0x04001512 RID: 5394
			Area
		}

		// Token: 0x02000443 RID: 1091
		public enum eFuncType
		{
			// Token: 0x04001514 RID: 5396
			None,
			// Token: 0x04001515 RID: 5397
			Forge = 3,
			// Token: 0x04001516 RID: 5398
			Achievement,
			// Token: 0x04001517 RID: 5399
			Ranklist,
			// Token: 0x04001518 RID: 5400
			Welfare,
			// Token: 0x04001519 RID: 5401
			Duel,
			// Token: 0x0400151A RID: 5402
			Entourage,
			// Token: 0x0400151B RID: 5403
			EntourageLvUp,
			// Token: 0x0400151C RID: 5404
			DailyTask,
			// Token: 0x0400151D RID: 5405
			Title,
			// Token: 0x0400151E RID: 5406
			DeathTower = 14,
			// Token: 0x0400151F RID: 5407
			Guild,
			// Token: 0x04001520 RID: 5408
			BeatCow,
			// Token: 0x04001521 RID: 5409
			Enchant,
			// Token: 0x04001522 RID: 5410
			Auction,
			// Token: 0x04001523 RID: 5411
			Degenerator,
			// Token: 0x04001524 RID: 5412
			MagicMale,
			// Token: 0x04001525 RID: 5413
			WashEntourage,
			// Token: 0x04001526 RID: 5414
			DeepDungeon = 23,
			// Token: 0x04001527 RID: 5415
			AncientDungeon,
			// Token: 0x04001528 RID: 5416
			ArmorMastery,
			// Token: 0x04001529 RID: 5417
			Team = 30,
			// Token: 0x0400152A RID: 5418
			Friend,
			// Token: 0x0400152B RID: 5419
			ActivitySevenDays,
			// Token: 0x0400152C RID: 5420
			FirstReChargeActivity = 34,
			// Token: 0x0400152D RID: 5421
			Shop,
			// Token: 0x0400152E RID: 5422
			Jar,
			// Token: 0x0400152F RID: 5423
			Mall,
			// Token: 0x04001530 RID: 5424
			FashionMerge = 45,
			// Token: 0x04001531 RID: 5425
			FashionAttrSel = 54,
			// Token: 0x04001532 RID: 5426
			Fashion,
			// Token: 0x04001533 RID: 5427
			AutoFight,
			// Token: 0x04001534 RID: 5428
			OnLineGift,
			// Token: 0x04001535 RID: 5429
			ActivityJar,
			// Token: 0x04001536 RID: 5430
			Pet,
			// Token: 0x04001537 RID: 5431
			Legend,
			// Token: 0x04001538 RID: 5432
			BattleDrugs,
			// Token: 0x04001539 RID: 5433
			TAPSystem,
			// Token: 0x0400153A RID: 5434
			ActivityLimitTime,
			// Token: 0x0400153B RID: 5435
			FestivalActivity,
			// Token: 0x0400153C RID: 5436
			Bead = 66,
			// Token: 0x0400153D RID: 5437
			AchievementG,
			// Token: 0x0400153E RID: 5438
			MagicJarLv55,
			// Token: 0x0400153F RID: 5439
			SideWeapon,
			// Token: 0x04001540 RID: 5440
			EquipHandBook,
			// Token: 0x04001541 RID: 5441
			YijieAreaOpen = 75,
			// Token: 0x04001542 RID: 5442
			RandomTreasure,
			// Token: 0x04001543 RID: 5443
			HorseGambling,
			// Token: 0x04001544 RID: 5444
			VanityFracture = 80,
			// Token: 0x04001545 RID: 5445
			ReportingFunction = 82,
			// Token: 0x04001546 RID: 5446
			WeaponLease,
			// Token: 0x04001547 RID: 5447
			EquipUpgrade,
			// Token: 0x04001548 RID: 5448
			BlackMarket,
			// Token: 0x04001549 RID: 5449
			AdventureTeam,
			// Token: 0x0400154A RID: 5450
			PVETrain,
			// Token: 0x0400154B RID: 5451
			PVEDamage,
			// Token: 0x0400154C RID: 5452
			DailyTodo,
			// Token: 0x0400154D RID: 5453
			KingTower,
			// Token: 0x0400154E RID: 5454
			TeamCopy,
			// Token: 0x0400154F RID: 5455
			Inscription,
			// Token: 0x04001550 RID: 5456
			AdventurePassSeason,
			// Token: 0x04001551 RID: 5457
			Questionnaire,
			// Token: 0x04001552 RID: 5458
			Honour,
			// Token: 0x04001553 RID: 5459
			Enhance,
			// Token: 0x04001554 RID: 5460
			SendDoor = 98,
			// Token: 0x04001555 RID: 5461
			TeamCopyTwo = 102
		}

		// Token: 0x02000444 RID: 1092
		public enum eExpandType
		{
			// Token: 0x04001557 RID: 5463
			ET_Null,
			// Token: 0x04001558 RID: 5464
			ET_TopRight
		}

		// Token: 0x02000445 RID: 1093
		public enum eBindType
		{
			// Token: 0x0400155A RID: 5466
			BT_RoleBind,
			// Token: 0x0400155B RID: 5467
			BT_AccBind
		}

		// Token: 0x02000446 RID: 1094
		public enum eCrypt
		{
			// Token: 0x0400155D RID: 5469
			code = 1970490982
		}
	}
}
