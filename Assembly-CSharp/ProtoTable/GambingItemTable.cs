using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000447 RID: 1095
	public class GambingItemTable : IFlatbufferObject
	{
		// Token: 0x17000CED RID: 3309
		// (get) Token: 0x06003446 RID: 13382 RVA: 0x000B69FC File Offset: 0x000B4DFC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003447 RID: 13383 RVA: 0x000B6A09 File Offset: 0x000B4E09
		public static GambingItemTable GetRootAsGambingItemTable(ByteBuffer _bb)
		{
			return GambingItemTable.GetRootAsGambingItemTable(_bb, new GambingItemTable());
		}

		// Token: 0x06003448 RID: 13384 RVA: 0x000B6A16 File Offset: 0x000B4E16
		public static GambingItemTable GetRootAsGambingItemTable(ByteBuffer _bb, GambingItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003449 RID: 13385 RVA: 0x000B6A32 File Offset: 0x000B4E32
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600344A RID: 13386 RVA: 0x000B6A4C File Offset: 0x000B4E4C
		public GambingItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000CEE RID: 3310
		// (get) Token: 0x0600344B RID: 13387 RVA: 0x000B6A58 File Offset: 0x000B4E58
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CEF RID: 3311
		// (get) Token: 0x0600344C RID: 13388 RVA: 0x000B6AA4 File Offset: 0x000B4EA4
		public int ActId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CF0 RID: 3312
		// (get) Token: 0x0600344D RID: 13389 RVA: 0x000B6AF0 File Offset: 0x000B4EF0
		public int Num
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CF1 RID: 3313
		// (get) Token: 0x0600344E RID: 13390 RVA: 0x000B6B3C File Offset: 0x000B4F3C
		public int Sort
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CF2 RID: 3314
		// (get) Token: 0x0600344F RID: 13391 RVA: 0x000B6B88 File Offset: 0x000B4F88
		public string GambingItem
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003450 RID: 13392 RVA: 0x000B6BCB File Offset: 0x000B4FCB
		public ArraySegment<byte>? GetGambingItemBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000CF3 RID: 3315
		// (get) Token: 0x06003451 RID: 13393 RVA: 0x000B6BDC File Offset: 0x000B4FDC
		public string TotalGrops
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003452 RID: 13394 RVA: 0x000B6C1F File Offset: 0x000B501F
		public ArraySegment<byte>? GetTotalGropsBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000CF4 RID: 3316
		// (get) Token: 0x06003453 RID: 13395 RVA: 0x000B6C30 File Offset: 0x000B5030
		public int CopiesOfEachGruop
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CF5 RID: 3317
		// (get) Token: 0x06003454 RID: 13396 RVA: 0x000B6C7C File Offset: 0x000B507C
		public int CostCurrencyId
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CF6 RID: 3318
		// (get) Token: 0x06003455 RID: 13397 RVA: 0x000B6CC8 File Offset: 0x000B50C8
		public int UnitPrice
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CF7 RID: 3319
		// (get) Token: 0x06003456 RID: 13398 RVA: 0x000B6D14 File Offset: 0x000B5114
		public int CoolDownIntervalBetweenGroups
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CF8 RID: 3320
		// (get) Token: 0x06003457 RID: 13399 RVA: 0x000B6D60 File Offset: 0x000B5160
		public string RewardsPerCopy
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003458 RID: 13400 RVA: 0x000B6DA3 File Offset: 0x000B51A3
		public ArraySegment<byte>? GetRewardsPerCopyBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000CF9 RID: 3321
		// (get) Token: 0x06003459 RID: 13401 RVA: 0x000B6DB4 File Offset: 0x000B51B4
		public int WeightingStepSize
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CFA RID: 3322
		// (get) Token: 0x0600345A RID: 13402 RVA: 0x000B6E00 File Offset: 0x000B5200
		public int WeightingValue
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CFB RID: 3323
		// (get) Token: 0x0600345B RID: 13403 RVA: 0x000B6E4C File Offset: 0x000B524C
		public int IsAnnounce
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (781587562 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600345C RID: 13404 RVA: 0x000B6E98 File Offset: 0x000B5298
		public static Offset<GambingItemTable> CreateGambingItemTable(FlatBufferBuilder builder, int ID = 0, int ActId = 0, int Num = 0, int Sort = 0, StringOffset GambingItemOffset = default(StringOffset), StringOffset TotalGropsOffset = default(StringOffset), int CopiesOfEachGruop = 0, int CostCurrencyId = 0, int UnitPrice = 0, int CoolDownIntervalBetweenGroups = 0, StringOffset RewardsPerCopyOffset = default(StringOffset), int WeightingStepSize = 0, int WeightingValue = 0, int IsAnnounce = 0)
		{
			builder.StartObject(14);
			GambingItemTable.AddIsAnnounce(builder, IsAnnounce);
			GambingItemTable.AddWeightingValue(builder, WeightingValue);
			GambingItemTable.AddWeightingStepSize(builder, WeightingStepSize);
			GambingItemTable.AddRewardsPerCopy(builder, RewardsPerCopyOffset);
			GambingItemTable.AddCoolDownIntervalBetweenGroups(builder, CoolDownIntervalBetweenGroups);
			GambingItemTable.AddUnitPrice(builder, UnitPrice);
			GambingItemTable.AddCostCurrencyId(builder, CostCurrencyId);
			GambingItemTable.AddCopiesOfEachGruop(builder, CopiesOfEachGruop);
			GambingItemTable.AddTotalGrops(builder, TotalGropsOffset);
			GambingItemTable.AddGambingItem(builder, GambingItemOffset);
			GambingItemTable.AddSort(builder, Sort);
			GambingItemTable.AddNum(builder, Num);
			GambingItemTable.AddActId(builder, ActId);
			GambingItemTable.AddID(builder, ID);
			return GambingItemTable.EndGambingItemTable(builder);
		}

		// Token: 0x0600345D RID: 13405 RVA: 0x000B6F20 File Offset: 0x000B5320
		public static void StartGambingItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(14);
		}

		// Token: 0x0600345E RID: 13406 RVA: 0x000B6F2A File Offset: 0x000B532A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600345F RID: 13407 RVA: 0x000B6F35 File Offset: 0x000B5335
		public static void AddActId(FlatBufferBuilder builder, int ActId)
		{
			builder.AddInt(1, ActId, 0);
		}

		// Token: 0x06003460 RID: 13408 RVA: 0x000B6F40 File Offset: 0x000B5340
		public static void AddNum(FlatBufferBuilder builder, int Num)
		{
			builder.AddInt(2, Num, 0);
		}

		// Token: 0x06003461 RID: 13409 RVA: 0x000B6F4B File Offset: 0x000B534B
		public static void AddSort(FlatBufferBuilder builder, int Sort)
		{
			builder.AddInt(3, Sort, 0);
		}

		// Token: 0x06003462 RID: 13410 RVA: 0x000B6F56 File Offset: 0x000B5356
		public static void AddGambingItem(FlatBufferBuilder builder, StringOffset GambingItemOffset)
		{
			builder.AddOffset(4, GambingItemOffset.Value, 0);
		}

		// Token: 0x06003463 RID: 13411 RVA: 0x000B6F67 File Offset: 0x000B5367
		public static void AddTotalGrops(FlatBufferBuilder builder, StringOffset TotalGropsOffset)
		{
			builder.AddOffset(5, TotalGropsOffset.Value, 0);
		}

		// Token: 0x06003464 RID: 13412 RVA: 0x000B6F78 File Offset: 0x000B5378
		public static void AddCopiesOfEachGruop(FlatBufferBuilder builder, int CopiesOfEachGruop)
		{
			builder.AddInt(6, CopiesOfEachGruop, 0);
		}

		// Token: 0x06003465 RID: 13413 RVA: 0x000B6F83 File Offset: 0x000B5383
		public static void AddCostCurrencyId(FlatBufferBuilder builder, int CostCurrencyId)
		{
			builder.AddInt(7, CostCurrencyId, 0);
		}

		// Token: 0x06003466 RID: 13414 RVA: 0x000B6F8E File Offset: 0x000B538E
		public static void AddUnitPrice(FlatBufferBuilder builder, int UnitPrice)
		{
			builder.AddInt(8, UnitPrice, 0);
		}

		// Token: 0x06003467 RID: 13415 RVA: 0x000B6F99 File Offset: 0x000B5399
		public static void AddCoolDownIntervalBetweenGroups(FlatBufferBuilder builder, int CoolDownIntervalBetweenGroups)
		{
			builder.AddInt(9, CoolDownIntervalBetweenGroups, 0);
		}

		// Token: 0x06003468 RID: 13416 RVA: 0x000B6FA5 File Offset: 0x000B53A5
		public static void AddRewardsPerCopy(FlatBufferBuilder builder, StringOffset RewardsPerCopyOffset)
		{
			builder.AddOffset(10, RewardsPerCopyOffset.Value, 0);
		}

		// Token: 0x06003469 RID: 13417 RVA: 0x000B6FB7 File Offset: 0x000B53B7
		public static void AddWeightingStepSize(FlatBufferBuilder builder, int WeightingStepSize)
		{
			builder.AddInt(11, WeightingStepSize, 0);
		}

		// Token: 0x0600346A RID: 13418 RVA: 0x000B6FC3 File Offset: 0x000B53C3
		public static void AddWeightingValue(FlatBufferBuilder builder, int WeightingValue)
		{
			builder.AddInt(12, WeightingValue, 0);
		}

		// Token: 0x0600346B RID: 13419 RVA: 0x000B6FCF File Offset: 0x000B53CF
		public static void AddIsAnnounce(FlatBufferBuilder builder, int IsAnnounce)
		{
			builder.AddInt(13, IsAnnounce, 0);
		}

		// Token: 0x0600346C RID: 13420 RVA: 0x000B6FDC File Offset: 0x000B53DC
		public static Offset<GambingItemTable> EndGambingItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GambingItemTable>(value);
		}

		// Token: 0x0600346D RID: 13421 RVA: 0x000B6FF6 File Offset: 0x000B53F6
		public static void FinishGambingItemTableBuffer(FlatBufferBuilder builder, Offset<GambingItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400155E RID: 5470
		private Table __p = new Table();

		// Token: 0x02000448 RID: 1096
		public enum eCrypt
		{
			// Token: 0x04001560 RID: 5472
			code = 781587562
		}
	}
}
