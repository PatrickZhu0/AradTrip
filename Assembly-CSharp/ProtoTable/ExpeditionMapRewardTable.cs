using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200041F RID: 1055
	public class ExpeditionMapRewardTable : IFlatbufferObject
	{
		// Token: 0x17000C40 RID: 3136
		// (get) Token: 0x06003245 RID: 12869 RVA: 0x000B20B0 File Offset: 0x000B04B0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003246 RID: 12870 RVA: 0x000B20BD File Offset: 0x000B04BD
		public static ExpeditionMapRewardTable GetRootAsExpeditionMapRewardTable(ByteBuffer _bb)
		{
			return ExpeditionMapRewardTable.GetRootAsExpeditionMapRewardTable(_bb, new ExpeditionMapRewardTable());
		}

		// Token: 0x06003247 RID: 12871 RVA: 0x000B20CA File Offset: 0x000B04CA
		public static ExpeditionMapRewardTable GetRootAsExpeditionMapRewardTable(ByteBuffer _bb, ExpeditionMapRewardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003248 RID: 12872 RVA: 0x000B20E6 File Offset: 0x000B04E6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003249 RID: 12873 RVA: 0x000B2100 File Offset: 0x000B0500
		public ExpeditionMapRewardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C41 RID: 3137
		// (get) Token: 0x0600324A RID: 12874 RVA: 0x000B210C File Offset: 0x000B050C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (957108012 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C42 RID: 3138
		// (get) Token: 0x0600324B RID: 12875 RVA: 0x000B2158 File Offset: 0x000B0558
		public int ExpeditionMapId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (957108012 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C43 RID: 3139
		// (get) Token: 0x0600324C RID: 12876 RVA: 0x000B21A4 File Offset: 0x000B05A4
		public string Rewards
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600324D RID: 12877 RVA: 0x000B21E6 File Offset: 0x000B05E6
		public ArraySegment<byte>? GetRewardsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000C44 RID: 3140
		// (get) Token: 0x0600324E RID: 12878 RVA: 0x000B21F4 File Offset: 0x000B05F4
		public int RequireAnyOccu
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (957108012 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C45 RID: 3141
		// (get) Token: 0x0600324F RID: 12879 RVA: 0x000B2240 File Offset: 0x000B0640
		public int RequireAnySameBaseOccu
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (957108012 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C46 RID: 3142
		// (get) Token: 0x06003250 RID: 12880 RVA: 0x000B228C File Offset: 0x000B068C
		public int RequireAnyDiffBaseOccu
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (957108012 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C47 RID: 3143
		// (get) Token: 0x06003251 RID: 12881 RVA: 0x000B22D8 File Offset: 0x000B06D8
		public int RequireAnyDiffChangedOccu
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (957108012 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003252 RID: 12882 RVA: 0x000B2324 File Offset: 0x000B0724
		public static Offset<ExpeditionMapRewardTable> CreateExpeditionMapRewardTable(FlatBufferBuilder builder, int ID = 0, int ExpeditionMapId = 0, StringOffset RewardsOffset = default(StringOffset), int RequireAnyOccu = 0, int RequireAnySameBaseOccu = 0, int RequireAnyDiffBaseOccu = 0, int RequireAnyDiffChangedOccu = 0)
		{
			builder.StartObject(7);
			ExpeditionMapRewardTable.AddRequireAnyDiffChangedOccu(builder, RequireAnyDiffChangedOccu);
			ExpeditionMapRewardTable.AddRequireAnyDiffBaseOccu(builder, RequireAnyDiffBaseOccu);
			ExpeditionMapRewardTable.AddRequireAnySameBaseOccu(builder, RequireAnySameBaseOccu);
			ExpeditionMapRewardTable.AddRequireAnyOccu(builder, RequireAnyOccu);
			ExpeditionMapRewardTable.AddRewards(builder, RewardsOffset);
			ExpeditionMapRewardTable.AddExpeditionMapId(builder, ExpeditionMapId);
			ExpeditionMapRewardTable.AddID(builder, ID);
			return ExpeditionMapRewardTable.EndExpeditionMapRewardTable(builder);
		}

		// Token: 0x06003253 RID: 12883 RVA: 0x000B2373 File Offset: 0x000B0773
		public static void StartExpeditionMapRewardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06003254 RID: 12884 RVA: 0x000B237C File Offset: 0x000B077C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003255 RID: 12885 RVA: 0x000B2387 File Offset: 0x000B0787
		public static void AddExpeditionMapId(FlatBufferBuilder builder, int ExpeditionMapId)
		{
			builder.AddInt(1, ExpeditionMapId, 0);
		}

		// Token: 0x06003256 RID: 12886 RVA: 0x000B2392 File Offset: 0x000B0792
		public static void AddRewards(FlatBufferBuilder builder, StringOffset RewardsOffset)
		{
			builder.AddOffset(2, RewardsOffset.Value, 0);
		}

		// Token: 0x06003257 RID: 12887 RVA: 0x000B23A3 File Offset: 0x000B07A3
		public static void AddRequireAnyOccu(FlatBufferBuilder builder, int RequireAnyOccu)
		{
			builder.AddInt(3, RequireAnyOccu, 0);
		}

		// Token: 0x06003258 RID: 12888 RVA: 0x000B23AE File Offset: 0x000B07AE
		public static void AddRequireAnySameBaseOccu(FlatBufferBuilder builder, int RequireAnySameBaseOccu)
		{
			builder.AddInt(4, RequireAnySameBaseOccu, 0);
		}

		// Token: 0x06003259 RID: 12889 RVA: 0x000B23B9 File Offset: 0x000B07B9
		public static void AddRequireAnyDiffBaseOccu(FlatBufferBuilder builder, int RequireAnyDiffBaseOccu)
		{
			builder.AddInt(5, RequireAnyDiffBaseOccu, 0);
		}

		// Token: 0x0600325A RID: 12890 RVA: 0x000B23C4 File Offset: 0x000B07C4
		public static void AddRequireAnyDiffChangedOccu(FlatBufferBuilder builder, int RequireAnyDiffChangedOccu)
		{
			builder.AddInt(6, RequireAnyDiffChangedOccu, 0);
		}

		// Token: 0x0600325B RID: 12891 RVA: 0x000B23D0 File Offset: 0x000B07D0
		public static Offset<ExpeditionMapRewardTable> EndExpeditionMapRewardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ExpeditionMapRewardTable>(value);
		}

		// Token: 0x0600325C RID: 12892 RVA: 0x000B23EA File Offset: 0x000B07EA
		public static void FinishExpeditionMapRewardTableBuffer(FlatBufferBuilder builder, Offset<ExpeditionMapRewardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014C0 RID: 5312
		private Table __p = new Table();

		// Token: 0x02000420 RID: 1056
		public enum eCrypt
		{
			// Token: 0x040014C2 RID: 5314
			code = 957108012
		}
	}
}
