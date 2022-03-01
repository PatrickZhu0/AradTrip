using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200055A RID: 1370
	public class PkLevelTable : IFlatbufferObject
	{
		// Token: 0x17001307 RID: 4871
		// (get) Token: 0x060046AF RID: 18095 RVA: 0x000E20BC File Offset: 0x000E04BC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060046B0 RID: 18096 RVA: 0x000E20C9 File Offset: 0x000E04C9
		public static PkLevelTable GetRootAsPkLevelTable(ByteBuffer _bb)
		{
			return PkLevelTable.GetRootAsPkLevelTable(_bb, new PkLevelTable());
		}

		// Token: 0x060046B1 RID: 18097 RVA: 0x000E20D6 File Offset: 0x000E04D6
		public static PkLevelTable GetRootAsPkLevelTable(ByteBuffer _bb, PkLevelTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060046B2 RID: 18098 RVA: 0x000E20F2 File Offset: 0x000E04F2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060046B3 RID: 18099 RVA: 0x000E210C File Offset: 0x000E050C
		public PkLevelTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001308 RID: 4872
		// (get) Token: 0x060046B4 RID: 18100 RVA: 0x000E2118 File Offset: 0x000E0518
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1616207787 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001309 RID: 4873
		// (get) Token: 0x060046B5 RID: 18101 RVA: 0x000E2164 File Offset: 0x000E0564
		public int PkLevelType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1616207787 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700130A RID: 4874
		// (get) Token: 0x060046B6 RID: 18102 RVA: 0x000E21B0 File Offset: 0x000E05B0
		public int Level
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1616207787 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700130B RID: 4875
		// (get) Token: 0x060046B7 RID: 18103 RVA: 0x000E21FC File Offset: 0x000E05FC
		public int MinPkValue
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1616207787 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700130C RID: 4876
		// (get) Token: 0x060046B8 RID: 18104 RVA: 0x000E2248 File Offset: 0x000E0648
		public string Path
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046B9 RID: 18105 RVA: 0x000E228B File Offset: 0x000E068B
		public ArraySegment<byte>? GetPathBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700130D RID: 4877
		// (get) Token: 0x060046BA RID: 18106 RVA: 0x000E229C File Offset: 0x000E069C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060046BB RID: 18107 RVA: 0x000E22DF File Offset: 0x000E06DF
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x060046BC RID: 18108 RVA: 0x000E22EE File Offset: 0x000E06EE
		public static Offset<PkLevelTable> CreatePkLevelTable(FlatBufferBuilder builder, int ID = 0, int PkLevelType = 0, int Level = 0, int MinPkValue = 0, StringOffset PathOffset = default(StringOffset), StringOffset NameOffset = default(StringOffset))
		{
			builder.StartObject(6);
			PkLevelTable.AddName(builder, NameOffset);
			PkLevelTable.AddPath(builder, PathOffset);
			PkLevelTable.AddMinPkValue(builder, MinPkValue);
			PkLevelTable.AddLevel(builder, Level);
			PkLevelTable.AddPkLevelType(builder, PkLevelType);
			PkLevelTable.AddID(builder, ID);
			return PkLevelTable.EndPkLevelTable(builder);
		}

		// Token: 0x060046BD RID: 18109 RVA: 0x000E232A File Offset: 0x000E072A
		public static void StartPkLevelTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x060046BE RID: 18110 RVA: 0x000E2333 File Offset: 0x000E0733
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060046BF RID: 18111 RVA: 0x000E233E File Offset: 0x000E073E
		public static void AddPkLevelType(FlatBufferBuilder builder, int PkLevelType)
		{
			builder.AddInt(1, PkLevelType, 0);
		}

		// Token: 0x060046C0 RID: 18112 RVA: 0x000E2349 File Offset: 0x000E0749
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(2, Level, 0);
		}

		// Token: 0x060046C1 RID: 18113 RVA: 0x000E2354 File Offset: 0x000E0754
		public static void AddMinPkValue(FlatBufferBuilder builder, int MinPkValue)
		{
			builder.AddInt(3, MinPkValue, 0);
		}

		// Token: 0x060046C2 RID: 18114 RVA: 0x000E235F File Offset: 0x000E075F
		public static void AddPath(FlatBufferBuilder builder, StringOffset PathOffset)
		{
			builder.AddOffset(4, PathOffset.Value, 0);
		}

		// Token: 0x060046C3 RID: 18115 RVA: 0x000E2370 File Offset: 0x000E0770
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(5, NameOffset.Value, 0);
		}

		// Token: 0x060046C4 RID: 18116 RVA: 0x000E2384 File Offset: 0x000E0784
		public static Offset<PkLevelTable> EndPkLevelTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<PkLevelTable>(value);
		}

		// Token: 0x060046C5 RID: 18117 RVA: 0x000E239E File Offset: 0x000E079E
		public static void FinishPkLevelTableBuffer(FlatBufferBuilder builder, Offset<PkLevelTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A21 RID: 6689
		private Table __p = new Table();

		// Token: 0x0200055B RID: 1371
		public enum eCrypt
		{
			// Token: 0x04001A23 RID: 6691
			code = 1616207787
		}
	}
}
