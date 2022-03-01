using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000528 RID: 1320
	public class NewTitleTable : IFlatbufferObject
	{
		// Token: 0x17001210 RID: 4624
		// (get) Token: 0x060043D1 RID: 17361 RVA: 0x000DB624 File Offset: 0x000D9A24
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060043D2 RID: 17362 RVA: 0x000DB631 File Offset: 0x000D9A31
		public static NewTitleTable GetRootAsNewTitleTable(ByteBuffer _bb)
		{
			return NewTitleTable.GetRootAsNewTitleTable(_bb, new NewTitleTable());
		}

		// Token: 0x060043D3 RID: 17363 RVA: 0x000DB63E File Offset: 0x000D9A3E
		public static NewTitleTable GetRootAsNewTitleTable(ByteBuffer _bb, NewTitleTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060043D4 RID: 17364 RVA: 0x000DB65A File Offset: 0x000D9A5A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060043D5 RID: 17365 RVA: 0x000DB674 File Offset: 0x000D9A74
		public NewTitleTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001211 RID: 4625
		// (get) Token: 0x060043D6 RID: 17366 RVA: 0x000DB680 File Offset: 0x000D9A80
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (40576386 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001212 RID: 4626
		// (get) Token: 0x060043D7 RID: 17367 RVA: 0x000DB6CC File Offset: 0x000D9ACC
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (40576386 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001213 RID: 4627
		// (get) Token: 0x060043D8 RID: 17368 RVA: 0x000DB718 File Offset: 0x000D9B18
		public int OwnerType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (40576386 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001214 RID: 4628
		// (get) Token: 0x060043D9 RID: 17369 RVA: 0x000DB764 File Offset: 0x000D9B64
		public int Category
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (40576386 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001215 RID: 4629
		// (get) Token: 0x060043DA RID: 17370 RVA: 0x000DB7B0 File Offset: 0x000D9BB0
		public int CategoryParam
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (40576386 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001216 RID: 4630
		// (get) Token: 0x060043DB RID: 17371 RVA: 0x000DB7FC File Offset: 0x000D9BFC
		public string name
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060043DC RID: 17372 RVA: 0x000DB83F File Offset: 0x000D9C3F
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17001217 RID: 4631
		// (get) Token: 0x060043DD RID: 17373 RVA: 0x000DB850 File Offset: 0x000D9C50
		public int Style
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (40576386 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001218 RID: 4632
		// (get) Token: 0x060043DE RID: 17374 RVA: 0x000DB89C File Offset: 0x000D9C9C
		public string path
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060043DF RID: 17375 RVA: 0x000DB8DF File Offset: 0x000D9CDF
		public ArraySegment<byte>? GetPathBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17001219 RID: 4633
		// (get) Token: 0x060043E0 RID: 17376 RVA: 0x000DB8F0 File Offset: 0x000D9CF0
		public string Describe
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060043E1 RID: 17377 RVA: 0x000DB933 File Offset: 0x000D9D33
		public ArraySegment<byte>? GetDescribeBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x1700121A RID: 4634
		// (get) Token: 0x060043E2 RID: 17378 RVA: 0x000DB944 File Offset: 0x000D9D44
		public string SourceDescribe
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060043E3 RID: 17379 RVA: 0x000DB987 File Offset: 0x000D9D87
		public ArraySegment<byte>? GetSourceDescribeBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x1700121B RID: 4635
		// (get) Token: 0x060043E4 RID: 17380 RVA: 0x000DB998 File Offset: 0x000D9D98
		public NewTitleTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(24);
				return (NewTitleTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060043E5 RID: 17381 RVA: 0x000DB9DC File Offset: 0x000D9DDC
		public static Offset<NewTitleTable> CreateNewTitleTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int OwnerType = 0, int Category = 0, int CategoryParam = 0, StringOffset nameOffset = default(StringOffset), int Style = 0, StringOffset pathOffset = default(StringOffset), StringOffset DescribeOffset = default(StringOffset), StringOffset SourceDescribeOffset = default(StringOffset), NewTitleTable.eSubType SubType = NewTitleTable.eSubType.SubType_None)
		{
			builder.StartObject(11);
			NewTitleTable.AddSubType(builder, SubType);
			NewTitleTable.AddSourceDescribe(builder, SourceDescribeOffset);
			NewTitleTable.AddDescribe(builder, DescribeOffset);
			NewTitleTable.AddPath(builder, pathOffset);
			NewTitleTable.AddStyle(builder, Style);
			NewTitleTable.AddName(builder, nameOffset);
			NewTitleTable.AddCategoryParam(builder, CategoryParam);
			NewTitleTable.AddCategory(builder, Category);
			NewTitleTable.AddOwnerType(builder, OwnerType);
			NewTitleTable.AddType(builder, Type);
			NewTitleTable.AddID(builder, ID);
			return NewTitleTable.EndNewTitleTable(builder);
		}

		// Token: 0x060043E6 RID: 17382 RVA: 0x000DBA4C File Offset: 0x000D9E4C
		public static void StartNewTitleTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x060043E7 RID: 17383 RVA: 0x000DBA56 File Offset: 0x000D9E56
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060043E8 RID: 17384 RVA: 0x000DBA61 File Offset: 0x000D9E61
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x060043E9 RID: 17385 RVA: 0x000DBA6C File Offset: 0x000D9E6C
		public static void AddOwnerType(FlatBufferBuilder builder, int OwnerType)
		{
			builder.AddInt(2, OwnerType, 0);
		}

		// Token: 0x060043EA RID: 17386 RVA: 0x000DBA77 File Offset: 0x000D9E77
		public static void AddCategory(FlatBufferBuilder builder, int Category)
		{
			builder.AddInt(3, Category, 0);
		}

		// Token: 0x060043EB RID: 17387 RVA: 0x000DBA82 File Offset: 0x000D9E82
		public static void AddCategoryParam(FlatBufferBuilder builder, int CategoryParam)
		{
			builder.AddInt(4, CategoryParam, 0);
		}

		// Token: 0x060043EC RID: 17388 RVA: 0x000DBA8D File Offset: 0x000D9E8D
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(5, nameOffset.Value, 0);
		}

		// Token: 0x060043ED RID: 17389 RVA: 0x000DBA9E File Offset: 0x000D9E9E
		public static void AddStyle(FlatBufferBuilder builder, int Style)
		{
			builder.AddInt(6, Style, 0);
		}

		// Token: 0x060043EE RID: 17390 RVA: 0x000DBAA9 File Offset: 0x000D9EA9
		public static void AddPath(FlatBufferBuilder builder, StringOffset pathOffset)
		{
			builder.AddOffset(7, pathOffset.Value, 0);
		}

		// Token: 0x060043EF RID: 17391 RVA: 0x000DBABA File Offset: 0x000D9EBA
		public static void AddDescribe(FlatBufferBuilder builder, StringOffset DescribeOffset)
		{
			builder.AddOffset(8, DescribeOffset.Value, 0);
		}

		// Token: 0x060043F0 RID: 17392 RVA: 0x000DBACB File Offset: 0x000D9ECB
		public static void AddSourceDescribe(FlatBufferBuilder builder, StringOffset SourceDescribeOffset)
		{
			builder.AddOffset(9, SourceDescribeOffset.Value, 0);
		}

		// Token: 0x060043F1 RID: 17393 RVA: 0x000DBADD File Offset: 0x000D9EDD
		public static void AddSubType(FlatBufferBuilder builder, NewTitleTable.eSubType SubType)
		{
			builder.AddInt(10, (int)SubType, 0);
		}

		// Token: 0x060043F2 RID: 17394 RVA: 0x000DBAEC File Offset: 0x000D9EEC
		public static Offset<NewTitleTable> EndNewTitleTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<NewTitleTable>(value);
		}

		// Token: 0x060043F3 RID: 17395 RVA: 0x000DBB06 File Offset: 0x000D9F06
		public static void FinishNewTitleTableBuffer(FlatBufferBuilder builder, Offset<NewTitleTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018FD RID: 6397
		private Table __p = new Table();

		// Token: 0x02000529 RID: 1321
		public enum eSubType
		{
			// Token: 0x040018FF RID: 6399
			SubType_None,
			// Token: 0x04001900 RID: 6400
			ACTIVITY,
			// Token: 0x04001901 RID: 6401
			EXPENDABLE
		}

		// Token: 0x0200052A RID: 1322
		public enum eCrypt
		{
			// Token: 0x04001903 RID: 6403
			code = 40576386
		}
	}
}
