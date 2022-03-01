using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000498 RID: 1176
	public class HonorRewardTable : IFlatbufferObject
	{
		// Token: 0x17000E7E RID: 3710
		// (get) Token: 0x0600394B RID: 14667 RVA: 0x000C20C0 File Offset: 0x000C04C0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600394C RID: 14668 RVA: 0x000C20CD File Offset: 0x000C04CD
		public static HonorRewardTable GetRootAsHonorRewardTable(ByteBuffer _bb)
		{
			return HonorRewardTable.GetRootAsHonorRewardTable(_bb, new HonorRewardTable());
		}

		// Token: 0x0600394D RID: 14669 RVA: 0x000C20DA File Offset: 0x000C04DA
		public static HonorRewardTable GetRootAsHonorRewardTable(ByteBuffer _bb, HonorRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600394E RID: 14670 RVA: 0x000C20F6 File Offset: 0x000C04F6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600394F RID: 14671 RVA: 0x000C2110 File Offset: 0x000C0510
		public HonorRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E7F RID: 3711
		// (get) Token: 0x06003950 RID: 14672 RVA: 0x000C211C File Offset: 0x000C051C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1987418915 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E80 RID: 3712
		// (get) Token: 0x06003951 RID: 14673 RVA: 0x000C2168 File Offset: 0x000C0568
		public int PvpType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1987418915 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E81 RID: 3713
		// (get) Token: 0x06003952 RID: 14674 RVA: 0x000C21B4 File Offset: 0x000C05B4
		public string RewardType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003953 RID: 14675 RVA: 0x000C21F6 File Offset: 0x000C05F6
		public ArraySegment<byte>? GetRewardTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000E82 RID: 3714
		// (get) Token: 0x06003954 RID: 14676 RVA: 0x000C2204 File Offset: 0x000C0604
		public int VictoryReward
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1987418915 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E83 RID: 3715
		// (get) Token: 0x06003955 RID: 14677 RVA: 0x000C2250 File Offset: 0x000C0650
		public int LostReward
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1987418915 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E84 RID: 3716
		// (get) Token: 0x06003956 RID: 14678 RVA: 0x000C229C File Offset: 0x000C069C
		public string RankReward
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003957 RID: 14679 RVA: 0x000C22DF File Offset: 0x000C06DF
		public ArraySegment<byte>? GetRankRewardBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000E85 RID: 3717
		// (get) Token: 0x06003958 RID: 14680 RVA: 0x000C22F0 File Offset: 0x000C06F0
		public int KillReward
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1987418915 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003959 RID: 14681 RVA: 0x000C233C File Offset: 0x000C073C
		public static Offset<HonorRewardTable> CreateHonorRewardTable(FlatBufferBuilder builder, int ID = 0, int PvpType = 0, StringOffset RewardTypeOffset = default(StringOffset), int VictoryReward = 0, int LostReward = 0, StringOffset RankRewardOffset = default(StringOffset), int KillReward = 0)
		{
			builder.StartObject(7);
			HonorRewardTable.AddKillReward(builder, KillReward);
			HonorRewardTable.AddRankReward(builder, RankRewardOffset);
			HonorRewardTable.AddLostReward(builder, LostReward);
			HonorRewardTable.AddVictoryReward(builder, VictoryReward);
			HonorRewardTable.AddRewardType(builder, RewardTypeOffset);
			HonorRewardTable.AddPvpType(builder, PvpType);
			HonorRewardTable.AddID(builder, ID);
			return HonorRewardTable.EndHonorRewardTable(builder);
		}

		// Token: 0x0600395A RID: 14682 RVA: 0x000C238B File Offset: 0x000C078B
		public static void StartHonorRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0600395B RID: 14683 RVA: 0x000C2394 File Offset: 0x000C0794
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600395C RID: 14684 RVA: 0x000C239F File Offset: 0x000C079F
		public static void AddPvpType(FlatBufferBuilder builder, int PvpType)
		{
			builder.AddInt(1, PvpType, 0);
		}

		// Token: 0x0600395D RID: 14685 RVA: 0x000C23AA File Offset: 0x000C07AA
		public static void AddRewardType(FlatBufferBuilder builder, StringOffset RewardTypeOffset)
		{
			builder.AddOffset(2, RewardTypeOffset.Value, 0);
		}

		// Token: 0x0600395E RID: 14686 RVA: 0x000C23BB File Offset: 0x000C07BB
		public static void AddVictoryReward(FlatBufferBuilder builder, int VictoryReward)
		{
			builder.AddInt(3, VictoryReward, 0);
		}

		// Token: 0x0600395F RID: 14687 RVA: 0x000C23C6 File Offset: 0x000C07C6
		public static void AddLostReward(FlatBufferBuilder builder, int LostReward)
		{
			builder.AddInt(4, LostReward, 0);
		}

		// Token: 0x06003960 RID: 14688 RVA: 0x000C23D1 File Offset: 0x000C07D1
		public static void AddRankReward(FlatBufferBuilder builder, StringOffset RankRewardOffset)
		{
			builder.AddOffset(5, RankRewardOffset.Value, 0);
		}

		// Token: 0x06003961 RID: 14689 RVA: 0x000C23E2 File Offset: 0x000C07E2
		public static void AddKillReward(FlatBufferBuilder builder, int KillReward)
		{
			builder.AddInt(6, KillReward, 0);
		}

		// Token: 0x06003962 RID: 14690 RVA: 0x000C23F0 File Offset: 0x000C07F0
		public static Offset<HonorRewardTable> EndHonorRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<HonorRewardTable>(value);
		}

		// Token: 0x06003963 RID: 14691 RVA: 0x000C240A File Offset: 0x000C080A
		public static void FinishHonorRewardTableBuffer(FlatBufferBuilder builder, Offset<HonorRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001622 RID: 5666
		private Table __p = new Table();

		// Token: 0x02000499 RID: 1177
		public enum eCrypt
		{
			// Token: 0x04001624 RID: 5668
			code = -1987418915
		}
	}
}
