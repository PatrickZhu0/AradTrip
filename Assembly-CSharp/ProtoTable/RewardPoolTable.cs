using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000587 RID: 1415
	public class RewardPoolTable : IFlatbufferObject
	{
		// Token: 0x170013E2 RID: 5090
		// (get) Token: 0x06004967 RID: 18791 RVA: 0x000E8058 File Offset: 0x000E6458
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004968 RID: 18792 RVA: 0x000E8065 File Offset: 0x000E6465
		public static RewardPoolTable GetRootAsRewardPoolTable(ByteBuffer _bb)
		{
			return RewardPoolTable.GetRootAsRewardPoolTable(_bb, new RewardPoolTable());
		}

		// Token: 0x06004969 RID: 18793 RVA: 0x000E8072 File Offset: 0x000E6472
		public static RewardPoolTable GetRootAsRewardPoolTable(ByteBuffer _bb, RewardPoolTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600496A RID: 18794 RVA: 0x000E808E File Offset: 0x000E648E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600496B RID: 18795 RVA: 0x000E80A8 File Offset: 0x000E64A8
		public RewardPoolTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170013E3 RID: 5091
		// (get) Token: 0x0600496C RID: 18796 RVA: 0x000E80B4 File Offset: 0x000E64B4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013E4 RID: 5092
		// (get) Token: 0x0600496D RID: 18797 RVA: 0x000E8100 File Offset: 0x000E6500
		public int DrawPrizeTableID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013E5 RID: 5093
		// (get) Token: 0x0600496E RID: 18798 RVA: 0x000E814C File Offset: 0x000E654C
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013E6 RID: 5094
		// (get) Token: 0x0600496F RID: 18799 RVA: 0x000E8198 File Offset: 0x000E6598
		public int ItemNum
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013E7 RID: 5095
		// (get) Token: 0x06004970 RID: 18800 RVA: 0x000E81E4 File Offset: 0x000E65E4
		public int StrengthenLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013E8 RID: 5096
		// (get) Token: 0x06004971 RID: 18801 RVA: 0x000E8230 File Offset: 0x000E6630
		public int ItemWeight
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013E9 RID: 5097
		// (get) Token: 0x06004972 RID: 18802 RVA: 0x000E827C File Offset: 0x000E667C
		public int DrawPrizeCountLimit
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013EA RID: 5098
		// (get) Token: 0x06004973 RID: 18803 RVA: 0x000E82C8 File Offset: 0x000E66C8
		public int ChargeCond
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013EB RID: 5099
		// (get) Token: 0x06004974 RID: 18804 RVA: 0x000E8314 File Offset: 0x000E6714
		public int IsImportant
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013EC RID: 5100
		// (get) Token: 0x06004975 RID: 18805 RVA: 0x000E8360 File Offset: 0x000E6760
		public int AnnounceNum
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013ED RID: 5101
		// (get) Token: 0x06004976 RID: 18806 RVA: 0x000E83AC File Offset: 0x000E67AC
		public int ServerTotalNum
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-2044683795 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004977 RID: 18807 RVA: 0x000E83F8 File Offset: 0x000E67F8
		public static Offset<RewardPoolTable> CreateRewardPoolTable(FlatBufferBuilder builder, int ID = 0, int DrawPrizeTableID = 0, int ItemID = 0, int ItemNum = 0, int StrengthenLevel = 0, int ItemWeight = 0, int DrawPrizeCountLimit = 0, int ChargeCond = 0, int IsImportant = 0, int AnnounceNum = 0, int ServerTotalNum = 0)
		{
			builder.StartObject(11);
			RewardPoolTable.AddServerTotalNum(builder, ServerTotalNum);
			RewardPoolTable.AddAnnounceNum(builder, AnnounceNum);
			RewardPoolTable.AddIsImportant(builder, IsImportant);
			RewardPoolTable.AddChargeCond(builder, ChargeCond);
			RewardPoolTable.AddDrawPrizeCountLimit(builder, DrawPrizeCountLimit);
			RewardPoolTable.AddItemWeight(builder, ItemWeight);
			RewardPoolTable.AddStrengthenLevel(builder, StrengthenLevel);
			RewardPoolTable.AddItemNum(builder, ItemNum);
			RewardPoolTable.AddItemID(builder, ItemID);
			RewardPoolTable.AddDrawPrizeTableID(builder, DrawPrizeTableID);
			RewardPoolTable.AddID(builder, ID);
			return RewardPoolTable.EndRewardPoolTable(builder);
		}

		// Token: 0x06004978 RID: 18808 RVA: 0x000E8468 File Offset: 0x000E6868
		public static void StartRewardPoolTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x06004979 RID: 18809 RVA: 0x000E8472 File Offset: 0x000E6872
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600497A RID: 18810 RVA: 0x000E847D File Offset: 0x000E687D
		public static void AddDrawPrizeTableID(FlatBufferBuilder builder, int DrawPrizeTableID)
		{
			builder.AddInt(1, DrawPrizeTableID, 0);
		}

		// Token: 0x0600497B RID: 18811 RVA: 0x000E8488 File Offset: 0x000E6888
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(2, ItemID, 0);
		}

		// Token: 0x0600497C RID: 18812 RVA: 0x000E8493 File Offset: 0x000E6893
		public static void AddItemNum(FlatBufferBuilder builder, int ItemNum)
		{
			builder.AddInt(3, ItemNum, 0);
		}

		// Token: 0x0600497D RID: 18813 RVA: 0x000E849E File Offset: 0x000E689E
		public static void AddStrengthenLevel(FlatBufferBuilder builder, int StrengthenLevel)
		{
			builder.AddInt(4, StrengthenLevel, 0);
		}

		// Token: 0x0600497E RID: 18814 RVA: 0x000E84A9 File Offset: 0x000E68A9
		public static void AddItemWeight(FlatBufferBuilder builder, int ItemWeight)
		{
			builder.AddInt(5, ItemWeight, 0);
		}

		// Token: 0x0600497F RID: 18815 RVA: 0x000E84B4 File Offset: 0x000E68B4
		public static void AddDrawPrizeCountLimit(FlatBufferBuilder builder, int DrawPrizeCountLimit)
		{
			builder.AddInt(6, DrawPrizeCountLimit, 0);
		}

		// Token: 0x06004980 RID: 18816 RVA: 0x000E84BF File Offset: 0x000E68BF
		public static void AddChargeCond(FlatBufferBuilder builder, int ChargeCond)
		{
			builder.AddInt(7, ChargeCond, 0);
		}

		// Token: 0x06004981 RID: 18817 RVA: 0x000E84CA File Offset: 0x000E68CA
		public static void AddIsImportant(FlatBufferBuilder builder, int IsImportant)
		{
			builder.AddInt(8, IsImportant, 0);
		}

		// Token: 0x06004982 RID: 18818 RVA: 0x000E84D5 File Offset: 0x000E68D5
		public static void AddAnnounceNum(FlatBufferBuilder builder, int AnnounceNum)
		{
			builder.AddInt(9, AnnounceNum, 0);
		}

		// Token: 0x06004983 RID: 18819 RVA: 0x000E84E1 File Offset: 0x000E68E1
		public static void AddServerTotalNum(FlatBufferBuilder builder, int ServerTotalNum)
		{
			builder.AddInt(10, ServerTotalNum, 0);
		}

		// Token: 0x06004984 RID: 18820 RVA: 0x000E84F0 File Offset: 0x000E68F0
		public static Offset<RewardPoolTable> EndRewardPoolTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RewardPoolTable>(value);
		}

		// Token: 0x06004985 RID: 18821 RVA: 0x000E850A File Offset: 0x000E690A
		public static void FinishRewardPoolTableBuffer(FlatBufferBuilder builder, Offset<RewardPoolTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AB4 RID: 6836
		private Table __p = new Table();

		// Token: 0x02000588 RID: 1416
		public enum eCrypt
		{
			// Token: 0x04001AB6 RID: 6838
			code = -2044683795
		}
	}
}
