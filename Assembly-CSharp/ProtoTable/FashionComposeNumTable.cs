using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200042A RID: 1066
	public class FashionComposeNumTable : IFlatbufferObject
	{
		// Token: 0x17000C65 RID: 3173
		// (get) Token: 0x060032CA RID: 13002 RVA: 0x000B31E4 File Offset: 0x000B15E4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060032CB RID: 13003 RVA: 0x000B31F1 File Offset: 0x000B15F1
		public static FashionComposeNumTable GetRootAsFashionComposeNumTable(ByteBuffer _bb)
		{
			return FashionComposeNumTable.GetRootAsFashionComposeNumTable(_bb, new FashionComposeNumTable());
		}

		// Token: 0x060032CC RID: 13004 RVA: 0x000B31FE File Offset: 0x000B15FE
		public static FashionComposeNumTable GetRootAsFashionComposeNumTable(ByteBuffer _bb, FashionComposeNumTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060032CD RID: 13005 RVA: 0x000B321A File Offset: 0x000B161A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060032CE RID: 13006 RVA: 0x000B3234 File Offset: 0x000B1634
		public FashionComposeNumTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C66 RID: 3174
		// (get) Token: 0x060032CF RID: 13007 RVA: 0x000B3240 File Offset: 0x000B1640
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1437690228 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C67 RID: 3175
		// (get) Token: 0x060032D0 RID: 13008 RVA: 0x000B328C File Offset: 0x000B168C
		public int Part
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1437690228 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C68 RID: 3176
		// (get) Token: 0x060032D1 RID: 13009 RVA: 0x000B32D8 File Offset: 0x000B16D8
		public int Quality
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1437690228 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C69 RID: 3177
		// (get) Token: 0x060032D2 RID: 13010 RVA: 0x000B3324 File Offset: 0x000B1724
		public int Rate
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1437690228 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060032D3 RID: 13011 RVA: 0x000B336E File Offset: 0x000B176E
		public static Offset<FashionComposeNumTable> CreateFashionComposeNumTable(FlatBufferBuilder builder, int ID = 0, int Part = 0, int Quality = 0, int Rate = 0)
		{
			builder.StartObject(4);
			FashionComposeNumTable.AddRate(builder, Rate);
			FashionComposeNumTable.AddQuality(builder, Quality);
			FashionComposeNumTable.AddPart(builder, Part);
			FashionComposeNumTable.AddID(builder, ID);
			return FashionComposeNumTable.EndFashionComposeNumTable(builder);
		}

		// Token: 0x060032D4 RID: 13012 RVA: 0x000B339A File Offset: 0x000B179A
		public static void StartFashionComposeNumTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x060032D5 RID: 13013 RVA: 0x000B33A3 File Offset: 0x000B17A3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060032D6 RID: 13014 RVA: 0x000B33AE File Offset: 0x000B17AE
		public static void AddPart(FlatBufferBuilder builder, int Part)
		{
			builder.AddInt(1, Part, 0);
		}

		// Token: 0x060032D7 RID: 13015 RVA: 0x000B33B9 File Offset: 0x000B17B9
		public static void AddQuality(FlatBufferBuilder builder, int Quality)
		{
			builder.AddInt(2, Quality, 0);
		}

		// Token: 0x060032D8 RID: 13016 RVA: 0x000B33C4 File Offset: 0x000B17C4
		public static void AddRate(FlatBufferBuilder builder, int Rate)
		{
			builder.AddInt(3, Rate, 0);
		}

		// Token: 0x060032D9 RID: 13017 RVA: 0x000B33D0 File Offset: 0x000B17D0
		public static Offset<FashionComposeNumTable> EndFashionComposeNumTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FashionComposeNumTable>(value);
		}

		// Token: 0x060032DA RID: 13018 RVA: 0x000B33EA File Offset: 0x000B17EA
		public static void FinishFashionComposeNumTableBuffer(FlatBufferBuilder builder, Offset<FashionComposeNumTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014D6 RID: 5334
		private Table __p = new Table();

		// Token: 0x0200042B RID: 1067
		public enum eCrypt
		{
			// Token: 0x040014D8 RID: 5336
			code = -1437690228
		}
	}
}
