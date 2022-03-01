using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200045D RID: 1117
	public class GuildBattleLotteryNumTable : IFlatbufferObject
	{
		// Token: 0x17000D6C RID: 3436
		// (get) Token: 0x060035D2 RID: 13778 RVA: 0x000BA2E0 File Offset: 0x000B86E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060035D3 RID: 13779 RVA: 0x000BA2ED File Offset: 0x000B86ED
		public static GuildBattleLotteryNumTable GetRootAsGuildBattleLotteryNumTable(ByteBuffer _bb)
		{
			return GuildBattleLotteryNumTable.GetRootAsGuildBattleLotteryNumTable(_bb, new GuildBattleLotteryNumTable());
		}

		// Token: 0x060035D4 RID: 13780 RVA: 0x000BA2FA File Offset: 0x000B86FA
		public static GuildBattleLotteryNumTable GetRootAsGuildBattleLotteryNumTable(ByteBuffer _bb, GuildBattleLotteryNumTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060035D5 RID: 13781 RVA: 0x000BA316 File Offset: 0x000B8716
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060035D6 RID: 13782 RVA: 0x000BA330 File Offset: 0x000B8730
		public GuildBattleLotteryNumTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D6D RID: 3437
		// (get) Token: 0x060035D7 RID: 13783 RVA: 0x000BA33C File Offset: 0x000B873C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1295388832 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D6E RID: 3438
		// (get) Token: 0x060035D8 RID: 13784 RVA: 0x000BA388 File Offset: 0x000B8788
		public int Num
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1295388832 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060035D9 RID: 13785 RVA: 0x000BA3D1 File Offset: 0x000B87D1
		public static Offset<GuildBattleLotteryNumTable> CreateGuildBattleLotteryNumTable(FlatBufferBuilder builder, int ID = 0, int Num = 0)
		{
			builder.StartObject(2);
			GuildBattleLotteryNumTable.AddNum(builder, Num);
			GuildBattleLotteryNumTable.AddID(builder, ID);
			return GuildBattleLotteryNumTable.EndGuildBattleLotteryNumTable(builder);
		}

		// Token: 0x060035DA RID: 13786 RVA: 0x000BA3EE File Offset: 0x000B87EE
		public static void StartGuildBattleLotteryNumTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x060035DB RID: 13787 RVA: 0x000BA3F7 File Offset: 0x000B87F7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060035DC RID: 13788 RVA: 0x000BA402 File Offset: 0x000B8802
		public static void AddNum(FlatBufferBuilder builder, int Num)
		{
			builder.AddInt(1, Num, 0);
		}

		// Token: 0x060035DD RID: 13789 RVA: 0x000BA410 File Offset: 0x000B8810
		public static Offset<GuildBattleLotteryNumTable> EndGuildBattleLotteryNumTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildBattleLotteryNumTable>(value);
		}

		// Token: 0x060035DE RID: 13790 RVA: 0x000BA42A File Offset: 0x000B882A
		public static void FinishGuildBattleLotteryNumTableBuffer(FlatBufferBuilder builder, Offset<GuildBattleLotteryNumTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001597 RID: 5527
		private Table __p = new Table();

		// Token: 0x0200045E RID: 1118
		public enum eCrypt
		{
			// Token: 0x04001599 RID: 5529
			code = 1295388832
		}
	}
}
