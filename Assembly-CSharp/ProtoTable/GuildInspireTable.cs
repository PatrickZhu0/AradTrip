using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000479 RID: 1145
	public class GuildInspireTable : IFlatbufferObject
	{
		// Token: 0x17000DE9 RID: 3561
		// (get) Token: 0x06003772 RID: 14194 RVA: 0x000BDC98 File Offset: 0x000BC098
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003773 RID: 14195 RVA: 0x000BDCA5 File Offset: 0x000BC0A5
		public static GuildInspireTable GetRootAsGuildInspireTable(ByteBuffer _bb)
		{
			return GuildInspireTable.GetRootAsGuildInspireTable(_bb, new GuildInspireTable());
		}

		// Token: 0x06003774 RID: 14196 RVA: 0x000BDCB2 File Offset: 0x000BC0B2
		public static GuildInspireTable GetRootAsGuildInspireTable(ByteBuffer _bb, GuildInspireTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003775 RID: 14197 RVA: 0x000BDCCE File Offset: 0x000BC0CE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003776 RID: 14198 RVA: 0x000BDCE8 File Offset: 0x000BC0E8
		public GuildInspireTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000DEA RID: 3562
		// (get) Token: 0x06003777 RID: 14199 RVA: 0x000BDCF4 File Offset: 0x000BC0F4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-598765305 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DEB RID: 3563
		// (get) Token: 0x06003778 RID: 14200 RVA: 0x000BDD40 File Offset: 0x000BC140
		public int NeedGuildLevel
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-598765305 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003779 RID: 14201 RVA: 0x000BDD8C File Offset: 0x000BC18C
		public string ConsumeItemArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000DEC RID: 3564
		// (get) Token: 0x0600377A RID: 14202 RVA: 0x000BDDD4 File Offset: 0x000BC1D4
		public int ConsumeItemLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000DED RID: 3565
		// (get) Token: 0x0600377B RID: 14203 RVA: 0x000BDE06 File Offset: 0x000BC206
		public FlatBufferArray<string> ConsumeItem
		{
			get
			{
				if (this.ConsumeItemValue == null)
				{
					this.ConsumeItemValue = new FlatBufferArray<string>(new Func<int, string>(this.ConsumeItemArray), this.ConsumeItemLength);
				}
				return this.ConsumeItemValue;
			}
		}

		// Token: 0x0600377C RID: 14204 RVA: 0x000BDE38 File Offset: 0x000BC238
		public string CrossConsumeItemArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000DEE RID: 3566
		// (get) Token: 0x0600377D RID: 14205 RVA: 0x000BDE80 File Offset: 0x000BC280
		public int CrossConsumeItemLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000DEF RID: 3567
		// (get) Token: 0x0600377E RID: 14206 RVA: 0x000BDEB3 File Offset: 0x000BC2B3
		public FlatBufferArray<string> CrossConsumeItem
		{
			get
			{
				if (this.CrossConsumeItemValue == null)
				{
					this.CrossConsumeItemValue = new FlatBufferArray<string>(new Func<int, string>(this.CrossConsumeItemArray), this.CrossConsumeItemLength);
				}
				return this.CrossConsumeItemValue;
			}
		}

		// Token: 0x0600377F RID: 14207 RVA: 0x000BDEE3 File Offset: 0x000BC2E3
		public static Offset<GuildInspireTable> CreateGuildInspireTable(FlatBufferBuilder builder, int ID = 0, int NeedGuildLevel = 0, VectorOffset ConsumeItemOffset = default(VectorOffset), VectorOffset CrossConsumeItemOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			GuildInspireTable.AddCrossConsumeItem(builder, CrossConsumeItemOffset);
			GuildInspireTable.AddConsumeItem(builder, ConsumeItemOffset);
			GuildInspireTable.AddNeedGuildLevel(builder, NeedGuildLevel);
			GuildInspireTable.AddID(builder, ID);
			return GuildInspireTable.EndGuildInspireTable(builder);
		}

		// Token: 0x06003780 RID: 14208 RVA: 0x000BDF0F File Offset: 0x000BC30F
		public static void StartGuildInspireTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06003781 RID: 14209 RVA: 0x000BDF18 File Offset: 0x000BC318
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003782 RID: 14210 RVA: 0x000BDF23 File Offset: 0x000BC323
		public static void AddNeedGuildLevel(FlatBufferBuilder builder, int NeedGuildLevel)
		{
			builder.AddInt(1, NeedGuildLevel, 0);
		}

		// Token: 0x06003783 RID: 14211 RVA: 0x000BDF2E File Offset: 0x000BC32E
		public static void AddConsumeItem(FlatBufferBuilder builder, VectorOffset ConsumeItemOffset)
		{
			builder.AddOffset(2, ConsumeItemOffset.Value, 0);
		}

		// Token: 0x06003784 RID: 14212 RVA: 0x000BDF40 File Offset: 0x000BC340
		public static VectorOffset CreateConsumeItemVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003785 RID: 14213 RVA: 0x000BDF86 File Offset: 0x000BC386
		public static void StartConsumeItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003786 RID: 14214 RVA: 0x000BDF91 File Offset: 0x000BC391
		public static void AddCrossConsumeItem(FlatBufferBuilder builder, VectorOffset CrossConsumeItemOffset)
		{
			builder.AddOffset(3, CrossConsumeItemOffset.Value, 0);
		}

		// Token: 0x06003787 RID: 14215 RVA: 0x000BDFA4 File Offset: 0x000BC3A4
		public static VectorOffset CreateCrossConsumeItemVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003788 RID: 14216 RVA: 0x000BDFEA File Offset: 0x000BC3EA
		public static void StartCrossConsumeItemVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003789 RID: 14217 RVA: 0x000BDFF8 File Offset: 0x000BC3F8
		public static Offset<GuildInspireTable> EndGuildInspireTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildInspireTable>(value);
		}

		// Token: 0x0600378A RID: 14218 RVA: 0x000BE012 File Offset: 0x000BC412
		public static void FinishGuildInspireTableBuffer(FlatBufferBuilder builder, Offset<GuildInspireTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015D8 RID: 5592
		private Table __p = new Table();

		// Token: 0x040015D9 RID: 5593
		private FlatBufferArray<string> ConsumeItemValue;

		// Token: 0x040015DA RID: 5594
		private FlatBufferArray<string> CrossConsumeItemValue;

		// Token: 0x0200047A RID: 1146
		public enum eCrypt
		{
			// Token: 0x040015DC RID: 5596
			code = -598765305
		}
	}
}
