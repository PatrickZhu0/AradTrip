using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000600 RID: 1536
	public class TeamRewardTable : IFlatbufferObject
	{
		// Token: 0x1700166C RID: 5740
		// (get) Token: 0x06005137 RID: 20791 RVA: 0x000FA508 File Offset: 0x000F8908
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005138 RID: 20792 RVA: 0x000FA515 File Offset: 0x000F8915
		public static TeamRewardTable GetRootAsTeamRewardTable(ByteBuffer _bb)
		{
			return TeamRewardTable.GetRootAsTeamRewardTable(_bb, new TeamRewardTable());
		}

		// Token: 0x06005139 RID: 20793 RVA: 0x000FA522 File Offset: 0x000F8922
		public static TeamRewardTable GetRootAsTeamRewardTable(ByteBuffer _bb, TeamRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600513A RID: 20794 RVA: 0x000FA53E File Offset: 0x000F893E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600513B RID: 20795 RVA: 0x000FA558 File Offset: 0x000F8958
		public TeamRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700166D RID: 5741
		// (get) Token: 0x0600513C RID: 20796 RVA: 0x000FA564 File Offset: 0x000F8964
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1435926900 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700166E RID: 5742
		// (get) Token: 0x0600513D RID: 20797 RVA: 0x000FA5B0 File Offset: 0x000F89B0
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1435926900 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700166F RID: 5743
		// (get) Token: 0x0600513E RID: 20798 RVA: 0x000FA5FC File Offset: 0x000F89FC
		public int Reward
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1435926900 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001670 RID: 5744
		// (get) Token: 0x0600513F RID: 20799 RVA: 0x000FA648 File Offset: 0x000F8A48
		public int Num
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1435926900 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001671 RID: 5745
		// (get) Token: 0x06005140 RID: 20800 RVA: 0x000FA694 File Offset: 0x000F8A94
		public int Prob
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1435926900 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001672 RID: 5746
		// (get) Token: 0x06005141 RID: 20801 RVA: 0x000FA6E0 File Offset: 0x000F8AE0
		public int DailyLimit
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1435926900 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005142 RID: 20802 RVA: 0x000FA72A File Offset: 0x000F8B2A
		public static Offset<TeamRewardTable> CreateTeamRewardTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int Reward = 0, int Num = 0, int Prob = 0, int DailyLimit = 0)
		{
			builder.StartObject(6);
			TeamRewardTable.AddDailyLimit(builder, DailyLimit);
			TeamRewardTable.AddProb(builder, Prob);
			TeamRewardTable.AddNum(builder, Num);
			TeamRewardTable.AddReward(builder, Reward);
			TeamRewardTable.AddType(builder, Type);
			TeamRewardTable.AddID(builder, ID);
			return TeamRewardTable.EndTeamRewardTable(builder);
		}

		// Token: 0x06005143 RID: 20803 RVA: 0x000FA766 File Offset: 0x000F8B66
		public static void StartTeamRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06005144 RID: 20804 RVA: 0x000FA76F File Offset: 0x000F8B6F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005145 RID: 20805 RVA: 0x000FA77A File Offset: 0x000F8B7A
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x06005146 RID: 20806 RVA: 0x000FA785 File Offset: 0x000F8B85
		public static void AddReward(FlatBufferBuilder builder, int Reward)
		{
			builder.AddInt(2, Reward, 0);
		}

		// Token: 0x06005147 RID: 20807 RVA: 0x000FA790 File Offset: 0x000F8B90
		public static void AddNum(FlatBufferBuilder builder, int Num)
		{
			builder.AddInt(3, Num, 0);
		}

		// Token: 0x06005148 RID: 20808 RVA: 0x000FA79B File Offset: 0x000F8B9B
		public static void AddProb(FlatBufferBuilder builder, int Prob)
		{
			builder.AddInt(4, Prob, 0);
		}

		// Token: 0x06005149 RID: 20809 RVA: 0x000FA7A6 File Offset: 0x000F8BA6
		public static void AddDailyLimit(FlatBufferBuilder builder, int DailyLimit)
		{
			builder.AddInt(5, DailyLimit, 0);
		}

		// Token: 0x0600514A RID: 20810 RVA: 0x000FA7B4 File Offset: 0x000F8BB4
		public static Offset<TeamRewardTable> EndTeamRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamRewardTable>(value);
		}

		// Token: 0x0600514B RID: 20811 RVA: 0x000FA7CE File Offset: 0x000F8BCE
		public static void FinishTeamRewardTableBuffer(FlatBufferBuilder builder, Offset<TeamRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E09 RID: 7689
		private Table __p = new Table();

		// Token: 0x02000601 RID: 1537
		public enum eCrypt
		{
			// Token: 0x04001E0B RID: 7691
			code = 1435926900
		}
	}
}
