using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200045F RID: 1119
	public class GuildBattleScoreRankRewardTable : IFlatbufferObject
	{
		// Token: 0x17000D6F RID: 3439
		// (get) Token: 0x060035E0 RID: 13792 RVA: 0x000BA44C File Offset: 0x000B884C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060035E1 RID: 13793 RVA: 0x000BA459 File Offset: 0x000B8859
		public static GuildBattleScoreRankRewardTable GetRootAsGuildBattleScoreRankRewardTable(ByteBuffer _bb)
		{
			return GuildBattleScoreRankRewardTable.GetRootAsGuildBattleScoreRankRewardTable(_bb, new GuildBattleScoreRankRewardTable());
		}

		// Token: 0x060035E2 RID: 13794 RVA: 0x000BA466 File Offset: 0x000B8866
		public static GuildBattleScoreRankRewardTable GetRootAsGuildBattleScoreRankRewardTable(ByteBuffer _bb, GuildBattleScoreRankRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060035E3 RID: 13795 RVA: 0x000BA482 File Offset: 0x000B8882
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060035E4 RID: 13796 RVA: 0x000BA49C File Offset: 0x000B889C
		public GuildBattleScoreRankRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D70 RID: 3440
		// (get) Token: 0x060035E5 RID: 13797 RVA: 0x000BA4A8 File Offset: 0x000B88A8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1386602394 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D71 RID: 3441
		// (get) Token: 0x060035E6 RID: 13798 RVA: 0x000BA4F4 File Offset: 0x000B88F4
		public int TitleId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1386602394 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D72 RID: 3442
		// (get) Token: 0x060035E7 RID: 13799 RVA: 0x000BA540 File Offset: 0x000B8940
		public int TitleDueTime
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1386602394 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060035E8 RID: 13800 RVA: 0x000BA589 File Offset: 0x000B8989
		public static Offset<GuildBattleScoreRankRewardTable> CreateGuildBattleScoreRankRewardTable(FlatBufferBuilder builder, int ID = 0, int TitleId = 0, int TitleDueTime = 0)
		{
			builder.StartObject(3);
			GuildBattleScoreRankRewardTable.AddTitleDueTime(builder, TitleDueTime);
			GuildBattleScoreRankRewardTable.AddTitleId(builder, TitleId);
			GuildBattleScoreRankRewardTable.AddID(builder, ID);
			return GuildBattleScoreRankRewardTable.EndGuildBattleScoreRankRewardTable(builder);
		}

		// Token: 0x060035E9 RID: 13801 RVA: 0x000BA5AD File Offset: 0x000B89AD
		public static void StartGuildBattleScoreRankRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x060035EA RID: 13802 RVA: 0x000BA5B6 File Offset: 0x000B89B6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060035EB RID: 13803 RVA: 0x000BA5C1 File Offset: 0x000B89C1
		public static void AddTitleId(FlatBufferBuilder builder, int TitleId)
		{
			builder.AddInt(1, TitleId, 0);
		}

		// Token: 0x060035EC RID: 13804 RVA: 0x000BA5CC File Offset: 0x000B89CC
		public static void AddTitleDueTime(FlatBufferBuilder builder, int TitleDueTime)
		{
			builder.AddInt(2, TitleDueTime, 0);
		}

		// Token: 0x060035ED RID: 13805 RVA: 0x000BA5D8 File Offset: 0x000B89D8
		public static Offset<GuildBattleScoreRankRewardTable> EndGuildBattleScoreRankRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildBattleScoreRankRewardTable>(value);
		}

		// Token: 0x060035EE RID: 13806 RVA: 0x000BA5F2 File Offset: 0x000B89F2
		public static void FinishGuildBattleScoreRankRewardTableBuffer(FlatBufferBuilder builder, Offset<GuildBattleScoreRankRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400159A RID: 5530
		private Table __p = new Table();

		// Token: 0x02000460 RID: 1120
		public enum eCrypt
		{
			// Token: 0x0400159C RID: 5532
			code = -1386602394
		}
	}
}
