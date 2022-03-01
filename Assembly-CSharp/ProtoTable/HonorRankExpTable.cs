using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000496 RID: 1174
	public class HonorRankExpTable : IFlatbufferObject
	{
		// Token: 0x17000E79 RID: 3705
		// (get) Token: 0x06003939 RID: 14649 RVA: 0x000C1E98 File Offset: 0x000C0298
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600393A RID: 14650 RVA: 0x000C1EA5 File Offset: 0x000C02A5
		public static HonorRankExpTable GetRootAsHonorRankExpTable(ByteBuffer _bb)
		{
			return HonorRankExpTable.GetRootAsHonorRankExpTable(_bb, new HonorRankExpTable());
		}

		// Token: 0x0600393B RID: 14651 RVA: 0x000C1EB2 File Offset: 0x000C02B2
		public static HonorRankExpTable GetRootAsHonorRankExpTable(ByteBuffer _bb, HonorRankExpTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600393C RID: 14652 RVA: 0x000C1ECE File Offset: 0x000C02CE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600393D RID: 14653 RVA: 0x000C1EE8 File Offset: 0x000C02E8
		public HonorRankExpTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E7A RID: 3706
		// (get) Token: 0x0600393E RID: 14654 RVA: 0x000C1EF4 File Offset: 0x000C02F4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (368717801 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E7B RID: 3707
		// (get) Token: 0x0600393F RID: 14655 RVA: 0x000C1F40 File Offset: 0x000C0340
		public int Rank
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (368717801 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E7C RID: 3708
		// (get) Token: 0x06003940 RID: 14656 RVA: 0x000C1F8C File Offset: 0x000C038C
		public int RewardExp
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (368717801 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E7D RID: 3709
		// (get) Token: 0x06003941 RID: 14657 RVA: 0x000C1FD8 File Offset: 0x000C03D8
		public int RankLvl
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (368717801 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003942 RID: 14658 RVA: 0x000C2022 File Offset: 0x000C0422
		public static Offset<HonorRankExpTable> CreateHonorRankExpTable(FlatBufferBuilder builder, int ID = 0, int Rank = 0, int RewardExp = 0, int RankLvl = 0)
		{
			builder.StartObject(4);
			HonorRankExpTable.AddRankLvl(builder, RankLvl);
			HonorRankExpTable.AddRewardExp(builder, RewardExp);
			HonorRankExpTable.AddRank(builder, Rank);
			HonorRankExpTable.AddID(builder, ID);
			return HonorRankExpTable.EndHonorRankExpTable(builder);
		}

		// Token: 0x06003943 RID: 14659 RVA: 0x000C204E File Offset: 0x000C044E
		public static void StartHonorRankExpTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06003944 RID: 14660 RVA: 0x000C2057 File Offset: 0x000C0457
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003945 RID: 14661 RVA: 0x000C2062 File Offset: 0x000C0462
		public static void AddRank(FlatBufferBuilder builder, int Rank)
		{
			builder.AddInt(1, Rank, 0);
		}

		// Token: 0x06003946 RID: 14662 RVA: 0x000C206D File Offset: 0x000C046D
		public static void AddRewardExp(FlatBufferBuilder builder, int RewardExp)
		{
			builder.AddInt(2, RewardExp, 0);
		}

		// Token: 0x06003947 RID: 14663 RVA: 0x000C2078 File Offset: 0x000C0478
		public static void AddRankLvl(FlatBufferBuilder builder, int RankLvl)
		{
			builder.AddInt(3, RankLvl, 0);
		}

		// Token: 0x06003948 RID: 14664 RVA: 0x000C2084 File Offset: 0x000C0484
		public static Offset<HonorRankExpTable> EndHonorRankExpTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<HonorRankExpTable>(value);
		}

		// Token: 0x06003949 RID: 14665 RVA: 0x000C209E File Offset: 0x000C049E
		public static void FinishHonorRankExpTableBuffer(FlatBufferBuilder builder, Offset<HonorRankExpTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400161F RID: 5663
		private Table __p = new Table();

		// Token: 0x02000497 RID: 1175
		public enum eCrypt
		{
			// Token: 0x04001621 RID: 5665
			code = 368717801
		}
	}
}
