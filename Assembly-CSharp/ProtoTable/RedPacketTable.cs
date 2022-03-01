using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000579 RID: 1401
	public class RedPacketTable : IFlatbufferObject
	{
		// Token: 0x17001374 RID: 4980
		// (get) Token: 0x06004816 RID: 18454 RVA: 0x000E50E8 File Offset: 0x000E34E8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004817 RID: 18455 RVA: 0x000E50F5 File Offset: 0x000E34F5
		public static RedPacketTable GetRootAsRedPacketTable(ByteBuffer _bb)
		{
			return RedPacketTable.GetRootAsRedPacketTable(_bb, new RedPacketTable());
		}

		// Token: 0x06004818 RID: 18456 RVA: 0x000E5102 File Offset: 0x000E3502
		public static RedPacketTable GetRootAsRedPacketTable(ByteBuffer _bb, RedPacketTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004819 RID: 18457 RVA: 0x000E511E File Offset: 0x000E351E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600481A RID: 18458 RVA: 0x000E5138 File Offset: 0x000E3538
		public RedPacketTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001375 RID: 4981
		// (get) Token: 0x0600481B RID: 18459 RVA: 0x000E5144 File Offset: 0x000E3544
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-860454163 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001376 RID: 4982
		// (get) Token: 0x0600481C RID: 18460 RVA: 0x000E5190 File Offset: 0x000E3590
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600481D RID: 18461 RVA: 0x000E51D2 File Offset: 0x000E35D2
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001377 RID: 4983
		// (get) Token: 0x0600481E RID: 18462 RVA: 0x000E51E0 File Offset: 0x000E35E0
		public RedPacketTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (RedPacketTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001378 RID: 4984
		// (get) Token: 0x0600481F RID: 18463 RVA: 0x000E5224 File Offset: 0x000E3624
		public int TotalMoney
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-860454163 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004820 RID: 18464 RVA: 0x000E5270 File Offset: 0x000E3670
		public int NumArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-860454163 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001379 RID: 4985
		// (get) Token: 0x06004821 RID: 18465 RVA: 0x000E52C0 File Offset: 0x000E36C0
		public int NumLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004822 RID: 18466 RVA: 0x000E52F3 File Offset: 0x000E36F3
		public ArraySegment<byte>? GetNumBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700137A RID: 4986
		// (get) Token: 0x06004823 RID: 18467 RVA: 0x000E5302 File Offset: 0x000E3702
		public FlatBufferArray<int> Num
		{
			get
			{
				if (this.NumValue == null)
				{
					this.NumValue = new FlatBufferArray<int>(new Func<int, int>(this.NumArray), this.NumLength);
				}
				return this.NumValue;
			}
		}

		// Token: 0x1700137B RID: 4987
		// (get) Token: 0x06004824 RID: 18468 RVA: 0x000E5334 File Offset: 0x000E3734
		public int MinMoney
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-860454163 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700137C RID: 4988
		// (get) Token: 0x06004825 RID: 18469 RVA: 0x000E5380 File Offset: 0x000E3780
		public int MaxMoney
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-860454163 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700137D RID: 4989
		// (get) Token: 0x06004826 RID: 18470 RVA: 0x000E53CC File Offset: 0x000E37CC
		public int CostMoneyID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-860454163 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700137E RID: 4990
		// (get) Token: 0x06004827 RID: 18471 RVA: 0x000E5418 File Offset: 0x000E3818
		public int GetMoneyID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-860454163 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700137F RID: 4991
		// (get) Token: 0x06004828 RID: 18472 RVA: 0x000E5464 File Offset: 0x000E3864
		public RedPacketTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(22);
				return (RedPacketTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001380 RID: 4992
		// (get) Token: 0x06004829 RID: 18473 RVA: 0x000E54A8 File Offset: 0x000E38A8
		public RedPacketTable.eThirdType ThirdType
		{
			get
			{
				int num = this.__p.__offset(24);
				return (RedPacketTable.eThirdType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600482A RID: 18474 RVA: 0x000E54EC File Offset: 0x000E38EC
		public static Offset<RedPacketTable> CreateRedPacketTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescOffset = default(StringOffset), RedPacketTable.eType Type = RedPacketTable.eType.Type_None, int TotalMoney = 0, VectorOffset NumOffset = default(VectorOffset), int MinMoney = 0, int MaxMoney = 0, int CostMoneyID = 0, int GetMoneyID = 0, RedPacketTable.eSubType SubType = RedPacketTable.eSubType.SubType_None, RedPacketTable.eThirdType ThirdType = RedPacketTable.eThirdType.INVALID)
		{
			builder.StartObject(11);
			RedPacketTable.AddThirdType(builder, ThirdType);
			RedPacketTable.AddSubType(builder, SubType);
			RedPacketTable.AddGetMoneyID(builder, GetMoneyID);
			RedPacketTable.AddCostMoneyID(builder, CostMoneyID);
			RedPacketTable.AddMaxMoney(builder, MaxMoney);
			RedPacketTable.AddMinMoney(builder, MinMoney);
			RedPacketTable.AddNum(builder, NumOffset);
			RedPacketTable.AddTotalMoney(builder, TotalMoney);
			RedPacketTable.AddType(builder, Type);
			RedPacketTable.AddDesc(builder, DescOffset);
			RedPacketTable.AddID(builder, ID);
			return RedPacketTable.EndRedPacketTable(builder);
		}

		// Token: 0x0600482B RID: 18475 RVA: 0x000E555C File Offset: 0x000E395C
		public static void StartRedPacketTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x0600482C RID: 18476 RVA: 0x000E5566 File Offset: 0x000E3966
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600482D RID: 18477 RVA: 0x000E5571 File Offset: 0x000E3971
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(1, DescOffset.Value, 0);
		}

		// Token: 0x0600482E RID: 18478 RVA: 0x000E5582 File Offset: 0x000E3982
		public static void AddType(FlatBufferBuilder builder, RedPacketTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x0600482F RID: 18479 RVA: 0x000E558D File Offset: 0x000E398D
		public static void AddTotalMoney(FlatBufferBuilder builder, int TotalMoney)
		{
			builder.AddInt(3, TotalMoney, 0);
		}

		// Token: 0x06004830 RID: 18480 RVA: 0x000E5598 File Offset: 0x000E3998
		public static void AddNum(FlatBufferBuilder builder, VectorOffset NumOffset)
		{
			builder.AddOffset(4, NumOffset.Value, 0);
		}

		// Token: 0x06004831 RID: 18481 RVA: 0x000E55AC File Offset: 0x000E39AC
		public static VectorOffset CreateNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004832 RID: 18482 RVA: 0x000E55E9 File Offset: 0x000E39E9
		public static void StartNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004833 RID: 18483 RVA: 0x000E55F4 File Offset: 0x000E39F4
		public static void AddMinMoney(FlatBufferBuilder builder, int MinMoney)
		{
			builder.AddInt(5, MinMoney, 0);
		}

		// Token: 0x06004834 RID: 18484 RVA: 0x000E55FF File Offset: 0x000E39FF
		public static void AddMaxMoney(FlatBufferBuilder builder, int MaxMoney)
		{
			builder.AddInt(6, MaxMoney, 0);
		}

		// Token: 0x06004835 RID: 18485 RVA: 0x000E560A File Offset: 0x000E3A0A
		public static void AddCostMoneyID(FlatBufferBuilder builder, int CostMoneyID)
		{
			builder.AddInt(7, CostMoneyID, 0);
		}

		// Token: 0x06004836 RID: 18486 RVA: 0x000E5615 File Offset: 0x000E3A15
		public static void AddGetMoneyID(FlatBufferBuilder builder, int GetMoneyID)
		{
			builder.AddInt(8, GetMoneyID, 0);
		}

		// Token: 0x06004837 RID: 18487 RVA: 0x000E5620 File Offset: 0x000E3A20
		public static void AddSubType(FlatBufferBuilder builder, RedPacketTable.eSubType SubType)
		{
			builder.AddInt(9, (int)SubType, 0);
		}

		// Token: 0x06004838 RID: 18488 RVA: 0x000E562C File Offset: 0x000E3A2C
		public static void AddThirdType(FlatBufferBuilder builder, RedPacketTable.eThirdType ThirdType)
		{
			builder.AddInt(10, (int)ThirdType, 0);
		}

		// Token: 0x06004839 RID: 18489 RVA: 0x000E5638 File Offset: 0x000E3A38
		public static Offset<RedPacketTable> EndRedPacketTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RedPacketTable>(value);
		}

		// Token: 0x0600483A RID: 18490 RVA: 0x000E5652 File Offset: 0x000E3A52
		public static void FinishRedPacketTableBuffer(FlatBufferBuilder builder, Offset<RedPacketTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A8E RID: 6798
		private Table __p = new Table();

		// Token: 0x04001A8F RID: 6799
		private FlatBufferArray<int> NumValue;

		// Token: 0x0200057A RID: 1402
		public enum eType
		{
			// Token: 0x04001A91 RID: 6801
			Type_None,
			// Token: 0x04001A92 RID: 6802
			GUILD,
			// Token: 0x04001A93 RID: 6803
			NEW_YEAR
		}

		// Token: 0x0200057B RID: 1403
		public enum eSubType
		{
			// Token: 0x04001A95 RID: 6805
			SubType_None,
			// Token: 0x04001A96 RID: 6806
			Buy,
			// Token: 0x04001A97 RID: 6807
			System
		}

		// Token: 0x0200057C RID: 1404
		public enum eThirdType
		{
			// Token: 0x04001A99 RID: 6809
			INVALID,
			// Token: 0x04001A9A RID: 6810
			GUILD_ALL,
			// Token: 0x04001A9B RID: 6811
			GUILD_BATTLE,
			// Token: 0x04001A9C RID: 6812
			GUILD_CROSS_BATTLE,
			// Token: 0x04001A9D RID: 6813
			GUILD_DUNGEON
		}

		// Token: 0x0200057D RID: 1405
		public enum eCrypt
		{
			// Token: 0x04001A9F RID: 6815
			code = -860454163
		}
	}
}
