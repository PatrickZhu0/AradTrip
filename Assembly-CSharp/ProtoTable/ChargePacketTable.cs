using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000314 RID: 788
	public class ChargePacketTable : IFlatbufferObject
	{
		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x06001F23 RID: 7971 RVA: 0x00083744 File Offset: 0x00081B44
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001F24 RID: 7972 RVA: 0x00083751 File Offset: 0x00081B51
		public static ChargePacketTable GetRootAsChargePacketTable(ByteBuffer _bb)
		{
			return ChargePacketTable.GetRootAsChargePacketTable(_bb, new ChargePacketTable());
		}

		// Token: 0x06001F25 RID: 7973 RVA: 0x0008375E File Offset: 0x00081B5E
		public static ChargePacketTable GetRootAsChargePacketTable(ByteBuffer _bb, ChargePacketTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001F26 RID: 7974 RVA: 0x0008377A File Offset: 0x00081B7A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001F27 RID: 7975 RVA: 0x00083794 File Offset: 0x00081B94
		public ChargePacketTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x06001F28 RID: 7976 RVA: 0x000837A0 File Offset: 0x00081BA0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1353523056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x06001F29 RID: 7977 RVA: 0x000837EC File Offset: 0x00081BEC
		public int Sort
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1353523056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x06001F2A RID: 7978 RVA: 0x00083838 File Offset: 0x00081C38
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001F2B RID: 7979 RVA: 0x0008387A File Offset: 0x00081C7A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06001F2C RID: 7980 RVA: 0x00083888 File Offset: 0x00081C88
		public int OldPrice
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1353523056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06001F2D RID: 7981 RVA: 0x000838D4 File Offset: 0x00081CD4
		public int Price
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1353523056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x06001F2E RID: 7982 RVA: 0x00083920 File Offset: 0x00081D20
		public int VipScore
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1353523056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x06001F2F RID: 7983 RVA: 0x0008396C File Offset: 0x00081D6C
		public int StartTime
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1353523056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06001F30 RID: 7984 RVA: 0x000839B8 File Offset: 0x00081DB8
		public int EndTime
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1353523056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06001F31 RID: 7985 RVA: 0x00083A04 File Offset: 0x00081E04
		public int limitDailyNum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1353523056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06001F32 RID: 7986 RVA: 0x00083A50 File Offset: 0x00081E50
		public int limitTotalNum
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1353523056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06001F33 RID: 7987 RVA: 0x00083A9C File Offset: 0x00081E9C
		public string rewards
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001F34 RID: 7988 RVA: 0x00083ADF File Offset: 0x00081EDF
		public ArraySegment<byte>? GetRewardsBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06001F35 RID: 7989 RVA: 0x00083AF0 File Offset: 0x00081EF0
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001F36 RID: 7990 RVA: 0x00083B33 File Offset: 0x00081F33
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x06001F37 RID: 7991 RVA: 0x00083B44 File Offset: 0x00081F44
		public static Offset<ChargePacketTable> CreateChargePacketTable(FlatBufferBuilder builder, int ID = 0, int Sort = 0, StringOffset NameOffset = default(StringOffset), int OldPrice = 0, int Price = 0, int VipScore = 0, int StartTime = 0, int EndTime = 0, int limitDailyNum = 0, int limitTotalNum = 0, StringOffset rewardsOffset = default(StringOffset), StringOffset IconOffset = default(StringOffset))
		{
			builder.StartObject(12);
			ChargePacketTable.AddIcon(builder, IconOffset);
			ChargePacketTable.AddRewards(builder, rewardsOffset);
			ChargePacketTable.AddLimitTotalNum(builder, limitTotalNum);
			ChargePacketTable.AddLimitDailyNum(builder, limitDailyNum);
			ChargePacketTable.AddEndTime(builder, EndTime);
			ChargePacketTable.AddStartTime(builder, StartTime);
			ChargePacketTable.AddVipScore(builder, VipScore);
			ChargePacketTable.AddPrice(builder, Price);
			ChargePacketTable.AddOldPrice(builder, OldPrice);
			ChargePacketTable.AddName(builder, NameOffset);
			ChargePacketTable.AddSort(builder, Sort);
			ChargePacketTable.AddID(builder, ID);
			return ChargePacketTable.EndChargePacketTable(builder);
		}

		// Token: 0x06001F38 RID: 7992 RVA: 0x00083BBC File Offset: 0x00081FBC
		public static void StartChargePacketTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x06001F39 RID: 7993 RVA: 0x00083BC6 File Offset: 0x00081FC6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001F3A RID: 7994 RVA: 0x00083BD1 File Offset: 0x00081FD1
		public static void AddSort(FlatBufferBuilder builder, int Sort)
		{
			builder.AddInt(1, Sort, 0);
		}

		// Token: 0x06001F3B RID: 7995 RVA: 0x00083BDC File Offset: 0x00081FDC
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x06001F3C RID: 7996 RVA: 0x00083BED File Offset: 0x00081FED
		public static void AddOldPrice(FlatBufferBuilder builder, int OldPrice)
		{
			builder.AddInt(3, OldPrice, 0);
		}

		// Token: 0x06001F3D RID: 7997 RVA: 0x00083BF8 File Offset: 0x00081FF8
		public static void AddPrice(FlatBufferBuilder builder, int Price)
		{
			builder.AddInt(4, Price, 0);
		}

		// Token: 0x06001F3E RID: 7998 RVA: 0x00083C03 File Offset: 0x00082003
		public static void AddVipScore(FlatBufferBuilder builder, int VipScore)
		{
			builder.AddInt(5, VipScore, 0);
		}

		// Token: 0x06001F3F RID: 7999 RVA: 0x00083C0E File Offset: 0x0008200E
		public static void AddStartTime(FlatBufferBuilder builder, int StartTime)
		{
			builder.AddInt(6, StartTime, 0);
		}

		// Token: 0x06001F40 RID: 8000 RVA: 0x00083C19 File Offset: 0x00082019
		public static void AddEndTime(FlatBufferBuilder builder, int EndTime)
		{
			builder.AddInt(7, EndTime, 0);
		}

		// Token: 0x06001F41 RID: 8001 RVA: 0x00083C24 File Offset: 0x00082024
		public static void AddLimitDailyNum(FlatBufferBuilder builder, int limitDailyNum)
		{
			builder.AddInt(8, limitDailyNum, 0);
		}

		// Token: 0x06001F42 RID: 8002 RVA: 0x00083C2F File Offset: 0x0008202F
		public static void AddLimitTotalNum(FlatBufferBuilder builder, int limitTotalNum)
		{
			builder.AddInt(9, limitTotalNum, 0);
		}

		// Token: 0x06001F43 RID: 8003 RVA: 0x00083C3B File Offset: 0x0008203B
		public static void AddRewards(FlatBufferBuilder builder, StringOffset rewardsOffset)
		{
			builder.AddOffset(10, rewardsOffset.Value, 0);
		}

		// Token: 0x06001F44 RID: 8004 RVA: 0x00083C4D File Offset: 0x0008204D
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(11, IconOffset.Value, 0);
		}

		// Token: 0x06001F45 RID: 8005 RVA: 0x00083C60 File Offset: 0x00082060
		public static Offset<ChargePacketTable> EndChargePacketTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChargePacketTable>(value);
		}

		// Token: 0x06001F46 RID: 8006 RVA: 0x00083C7A File Offset: 0x0008207A
		public static void FinishChargePacketTableBuffer(FlatBufferBuilder builder, Offset<ChargePacketTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F56 RID: 3926
		private Table __p = new Table();

		// Token: 0x02000315 RID: 789
		public enum eCrypt
		{
			// Token: 0x04000F58 RID: 3928
			code = -1353523056
		}
	}
}
