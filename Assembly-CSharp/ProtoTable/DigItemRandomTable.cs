using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000380 RID: 896
	public class DigItemRandomTable : IFlatbufferObject
	{
		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x06002649 RID: 9801 RVA: 0x00095178 File Offset: 0x00093578
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600264A RID: 9802 RVA: 0x00095185 File Offset: 0x00093585
		public static DigItemRandomTable GetRootAsDigItemRandomTable(ByteBuffer _bb)
		{
			return DigItemRandomTable.GetRootAsDigItemRandomTable(_bb, new DigItemRandomTable());
		}

		// Token: 0x0600264B RID: 9803 RVA: 0x00095192 File Offset: 0x00093592
		public static DigItemRandomTable GetRootAsDigItemRandomTable(ByteBuffer _bb, DigItemRandomTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600264C RID: 9804 RVA: 0x000951AE File Offset: 0x000935AE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600264D RID: 9805 RVA: 0x000951C8 File Offset: 0x000935C8
		public DigItemRandomTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x0600264E RID: 9806 RVA: 0x000951D4 File Offset: 0x000935D4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-986767962 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x0600264F RID: 9807 RVA: 0x00095220 File Offset: 0x00093620
		public int Group
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-986767962 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000862 RID: 2146
		// (get) Token: 0x06002650 RID: 9808 RVA: 0x0009526C File Offset: 0x0009366C
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-986767962 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000863 RID: 2147
		// (get) Token: 0x06002651 RID: 9809 RVA: 0x000952B8 File Offset: 0x000936B8
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-986767962 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000864 RID: 2148
		// (get) Token: 0x06002652 RID: 9810 RVA: 0x00095304 File Offset: 0x00093704
		public int RewardNum
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-986767962 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000865 RID: 2149
		// (get) Token: 0x06002653 RID: 9811 RVA: 0x00095350 File Offset: 0x00093750
		public int IsAnnounce
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-986767962 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002654 RID: 9812 RVA: 0x0009539A File Offset: 0x0009379A
		public static Offset<DigItemRandomTable> CreateDigItemRandomTable(FlatBufferBuilder builder, int ID = 0, int Group = 0, int ItemID = 0, int Weight = 0, int RewardNum = 0, int IsAnnounce = 0)
		{
			builder.StartObject(6);
			DigItemRandomTable.AddIsAnnounce(builder, IsAnnounce);
			DigItemRandomTable.AddRewardNum(builder, RewardNum);
			DigItemRandomTable.AddWeight(builder, Weight);
			DigItemRandomTable.AddItemID(builder, ItemID);
			DigItemRandomTable.AddGroup(builder, Group);
			DigItemRandomTable.AddID(builder, ID);
			return DigItemRandomTable.EndDigItemRandomTable(builder);
		}

		// Token: 0x06002655 RID: 9813 RVA: 0x000953D6 File Offset: 0x000937D6
		public static void StartDigItemRandomTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06002656 RID: 9814 RVA: 0x000953DF File Offset: 0x000937DF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002657 RID: 9815 RVA: 0x000953EA File Offset: 0x000937EA
		public static void AddGroup(FlatBufferBuilder builder, int Group)
		{
			builder.AddInt(1, Group, 0);
		}

		// Token: 0x06002658 RID: 9816 RVA: 0x000953F5 File Offset: 0x000937F5
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(2, ItemID, 0);
		}

		// Token: 0x06002659 RID: 9817 RVA: 0x00095400 File Offset: 0x00093800
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(3, Weight, 0);
		}

		// Token: 0x0600265A RID: 9818 RVA: 0x0009540B File Offset: 0x0009380B
		public static void AddRewardNum(FlatBufferBuilder builder, int RewardNum)
		{
			builder.AddInt(4, RewardNum, 0);
		}

		// Token: 0x0600265B RID: 9819 RVA: 0x00095416 File Offset: 0x00093816
		public static void AddIsAnnounce(FlatBufferBuilder builder, int IsAnnounce)
		{
			builder.AddInt(5, IsAnnounce, 0);
		}

		// Token: 0x0600265C RID: 9820 RVA: 0x00095424 File Offset: 0x00093824
		public static Offset<DigItemRandomTable> EndDigItemRandomTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DigItemRandomTable>(value);
		}

		// Token: 0x0600265D RID: 9821 RVA: 0x0009543E File Offset: 0x0009383E
		public static void FinishDigItemRandomTableBuffer(FlatBufferBuilder builder, Offset<DigItemRandomTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011A2 RID: 4514
		private Table __p = new Table();

		// Token: 0x02000381 RID: 897
		public enum eCrypt
		{
			// Token: 0x040011A4 RID: 4516
			code = -986767962
		}
	}
}
