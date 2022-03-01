using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200047B RID: 1147
	public class GuildProsperityTable : IFlatbufferObject
	{
		// Token: 0x17000DF0 RID: 3568
		// (get) Token: 0x0600378C RID: 14220 RVA: 0x000BE034 File Offset: 0x000BC434
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600378D RID: 14221 RVA: 0x000BE041 File Offset: 0x000BC441
		public static GuildProsperityTable GetRootAsGuildProsperityTable(ByteBuffer _bb)
		{
			return GuildProsperityTable.GetRootAsGuildProsperityTable(_bb, new GuildProsperityTable());
		}

		// Token: 0x0600378E RID: 14222 RVA: 0x000BE04E File Offset: 0x000BC44E
		public static GuildProsperityTable GetRootAsGuildProsperityTable(ByteBuffer _bb, GuildProsperityTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600378F RID: 14223 RVA: 0x000BE06A File Offset: 0x000BC46A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003790 RID: 14224 RVA: 0x000BE084 File Offset: 0x000BC484
		public GuildProsperityTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000DF1 RID: 3569
		// (get) Token: 0x06003791 RID: 14225 RVA: 0x000BE090 File Offset: 0x000BC490
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1869684804 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DF2 RID: 3570
		// (get) Token: 0x06003792 RID: 14226 RVA: 0x000BE0DC File Offset: 0x000BC4DC
		public int DismissLevel
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1869684804 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DF3 RID: 3571
		// (get) Token: 0x06003793 RID: 14227 RVA: 0x000BE128 File Offset: 0x000BC528
		public int MidLevel
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1869684804 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DF4 RID: 3572
		// (get) Token: 0x06003794 RID: 14228 RVA: 0x000BE174 File Offset: 0x000BC574
		public int HighLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1869684804 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003795 RID: 14229 RVA: 0x000BE1BE File Offset: 0x000BC5BE
		public static Offset<GuildProsperityTable> CreateGuildProsperityTable(FlatBufferBuilder builder, int ID = 0, int DismissLevel = 0, int MidLevel = 0, int HighLevel = 0)
		{
			builder.StartObject(4);
			GuildProsperityTable.AddHighLevel(builder, HighLevel);
			GuildProsperityTable.AddMidLevel(builder, MidLevel);
			GuildProsperityTable.AddDismissLevel(builder, DismissLevel);
			GuildProsperityTable.AddID(builder, ID);
			return GuildProsperityTable.EndGuildProsperityTable(builder);
		}

		// Token: 0x06003796 RID: 14230 RVA: 0x000BE1EA File Offset: 0x000BC5EA
		public static void StartGuildProsperityTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06003797 RID: 14231 RVA: 0x000BE1F3 File Offset: 0x000BC5F3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003798 RID: 14232 RVA: 0x000BE1FE File Offset: 0x000BC5FE
		public static void AddDismissLevel(FlatBufferBuilder builder, int DismissLevel)
		{
			builder.AddInt(1, DismissLevel, 0);
		}

		// Token: 0x06003799 RID: 14233 RVA: 0x000BE209 File Offset: 0x000BC609
		public static void AddMidLevel(FlatBufferBuilder builder, int MidLevel)
		{
			builder.AddInt(2, MidLevel, 0);
		}

		// Token: 0x0600379A RID: 14234 RVA: 0x000BE214 File Offset: 0x000BC614
		public static void AddHighLevel(FlatBufferBuilder builder, int HighLevel)
		{
			builder.AddInt(3, HighLevel, 0);
		}

		// Token: 0x0600379B RID: 14235 RVA: 0x000BE220 File Offset: 0x000BC620
		public static Offset<GuildProsperityTable> EndGuildProsperityTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildProsperityTable>(value);
		}

		// Token: 0x0600379C RID: 14236 RVA: 0x000BE23A File Offset: 0x000BC63A
		public static void FinishGuildProsperityTableBuffer(FlatBufferBuilder builder, Offset<GuildProsperityTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015DD RID: 5597
		private Table __p = new Table();

		// Token: 0x0200047C RID: 1148
		public enum eCrypt
		{
			// Token: 0x040015DF RID: 5599
			code = -1869684804
		}
	}
}
