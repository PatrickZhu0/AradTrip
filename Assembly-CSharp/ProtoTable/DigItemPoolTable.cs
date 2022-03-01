using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200037C RID: 892
	public class DigItemPoolTable : IFlatbufferObject
	{
		// Token: 0x17000854 RID: 2132
		// (get) Token: 0x0600262B RID: 9771 RVA: 0x00094D14 File Offset: 0x00093114
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600262C RID: 9772 RVA: 0x00094D21 File Offset: 0x00093121
		public static DigItemPoolTable GetRootAsDigItemPoolTable(ByteBuffer _bb)
		{
			return DigItemPoolTable.GetRootAsDigItemPoolTable(_bb, new DigItemPoolTable());
		}

		// Token: 0x0600262D RID: 9773 RVA: 0x00094D2E File Offset: 0x0009312E
		public static DigItemPoolTable GetRootAsDigItemPoolTable(ByteBuffer _bb, DigItemPoolTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600262E RID: 9774 RVA: 0x00094D4A File Offset: 0x0009314A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600262F RID: 9775 RVA: 0x00094D64 File Offset: 0x00093164
		public DigItemPoolTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000855 RID: 2133
		// (get) Token: 0x06002630 RID: 9776 RVA: 0x00094D70 File Offset: 0x00093170
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-351814127 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000856 RID: 2134
		// (get) Token: 0x06002631 RID: 9777 RVA: 0x00094DBC File Offset: 0x000931BC
		public DigItemPoolTable.eDigType DigType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (DigItemPoolTable.eDigType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000857 RID: 2135
		// (get) Token: 0x06002632 RID: 9778 RVA: 0x00094E00 File Offset: 0x00093200
		public DigItemPoolTable.eDigItemType DigItemType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (DigItemPoolTable.eDigItemType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000858 RID: 2136
		// (get) Token: 0x06002633 RID: 9779 RVA: 0x00094E44 File Offset: 0x00093244
		public int Group
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-351814127 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000859 RID: 2137
		// (get) Token: 0x06002634 RID: 9780 RVA: 0x00094E90 File Offset: 0x00093290
		public int Priority
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-351814127 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700085A RID: 2138
		// (get) Token: 0x06002635 RID: 9781 RVA: 0x00094EDC File Offset: 0x000932DC
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-351814127 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x06002636 RID: 9782 RVA: 0x00094F28 File Offset: 0x00093328
		public int ItemNum
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-351814127 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06002637 RID: 9783 RVA: 0x00094F74 File Offset: 0x00093374
		public int BoxWeight
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-351814127 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06002638 RID: 9784 RVA: 0x00094FC0 File Offset: 0x000933C0
		public int DigWeight
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-351814127 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06002639 RID: 9785 RVA: 0x0009500C File Offset: 0x0009340C
		public int RewardID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-351814127 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600263A RID: 9786 RVA: 0x00095058 File Offset: 0x00093458
		public static Offset<DigItemPoolTable> CreateDigItemPoolTable(FlatBufferBuilder builder, int ID = 0, DigItemPoolTable.eDigType DigType = DigItemPoolTable.eDigType.DIG_INVALID, DigItemPoolTable.eDigItemType DigItemType = DigItemPoolTable.eDigItemType.DIT_INVALID, int Group = 0, int Priority = 0, int ItemID = 0, int ItemNum = 0, int BoxWeight = 0, int DigWeight = 0, int RewardID = 0)
		{
			builder.StartObject(10);
			DigItemPoolTable.AddRewardID(builder, RewardID);
			DigItemPoolTable.AddDigWeight(builder, DigWeight);
			DigItemPoolTable.AddBoxWeight(builder, BoxWeight);
			DigItemPoolTable.AddItemNum(builder, ItemNum);
			DigItemPoolTable.AddItemID(builder, ItemID);
			DigItemPoolTable.AddPriority(builder, Priority);
			DigItemPoolTable.AddGroup(builder, Group);
			DigItemPoolTable.AddDigItemType(builder, DigItemType);
			DigItemPoolTable.AddDigType(builder, DigType);
			DigItemPoolTable.AddID(builder, ID);
			return DigItemPoolTable.EndDigItemPoolTable(builder);
		}

		// Token: 0x0600263B RID: 9787 RVA: 0x000950C0 File Offset: 0x000934C0
		public static void StartDigItemPoolTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x0600263C RID: 9788 RVA: 0x000950CA File Offset: 0x000934CA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600263D RID: 9789 RVA: 0x000950D5 File Offset: 0x000934D5
		public static void AddDigType(FlatBufferBuilder builder, DigItemPoolTable.eDigType DigType)
		{
			builder.AddInt(1, (int)DigType, 0);
		}

		// Token: 0x0600263E RID: 9790 RVA: 0x000950E0 File Offset: 0x000934E0
		public static void AddDigItemType(FlatBufferBuilder builder, DigItemPoolTable.eDigItemType DigItemType)
		{
			builder.AddInt(2, (int)DigItemType, 0);
		}

		// Token: 0x0600263F RID: 9791 RVA: 0x000950EB File Offset: 0x000934EB
		public static void AddGroup(FlatBufferBuilder builder, int Group)
		{
			builder.AddInt(3, Group, 0);
		}

		// Token: 0x06002640 RID: 9792 RVA: 0x000950F6 File Offset: 0x000934F6
		public static void AddPriority(FlatBufferBuilder builder, int Priority)
		{
			builder.AddInt(4, Priority, 0);
		}

		// Token: 0x06002641 RID: 9793 RVA: 0x00095101 File Offset: 0x00093501
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(5, ItemID, 0);
		}

		// Token: 0x06002642 RID: 9794 RVA: 0x0009510C File Offset: 0x0009350C
		public static void AddItemNum(FlatBufferBuilder builder, int ItemNum)
		{
			builder.AddInt(6, ItemNum, 0);
		}

		// Token: 0x06002643 RID: 9795 RVA: 0x00095117 File Offset: 0x00093517
		public static void AddBoxWeight(FlatBufferBuilder builder, int BoxWeight)
		{
			builder.AddInt(7, BoxWeight, 0);
		}

		// Token: 0x06002644 RID: 9796 RVA: 0x00095122 File Offset: 0x00093522
		public static void AddDigWeight(FlatBufferBuilder builder, int DigWeight)
		{
			builder.AddInt(8, DigWeight, 0);
		}

		// Token: 0x06002645 RID: 9797 RVA: 0x0009512D File Offset: 0x0009352D
		public static void AddRewardID(FlatBufferBuilder builder, int RewardID)
		{
			builder.AddInt(9, RewardID, 0);
		}

		// Token: 0x06002646 RID: 9798 RVA: 0x0009513C File Offset: 0x0009353C
		public static Offset<DigItemPoolTable> EndDigItemPoolTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DigItemPoolTable>(value);
		}

		// Token: 0x06002647 RID: 9799 RVA: 0x00095156 File Offset: 0x00093556
		public static void FinishDigItemPoolTableBuffer(FlatBufferBuilder builder, Offset<DigItemPoolTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001197 RID: 4503
		private Table __p = new Table();

		// Token: 0x0200037D RID: 893
		public enum eDigType
		{
			// Token: 0x04001199 RID: 4505
			DIG_INVALID,
			// Token: 0x0400119A RID: 4506
			DIG_GLOD,
			// Token: 0x0400119B RID: 4507
			DIG_SILVER
		}

		// Token: 0x0200037E RID: 894
		public enum eDigItemType
		{
			// Token: 0x0400119D RID: 4509
			DIT_INVALID,
			// Token: 0x0400119E RID: 4510
			DIT_NORMAL,
			// Token: 0x0400119F RID: 4511
			DIT_HIGHEST_GRADE
		}

		// Token: 0x0200037F RID: 895
		public enum eCrypt
		{
			// Token: 0x040011A1 RID: 4513
			code = -351814127
		}
	}
}
