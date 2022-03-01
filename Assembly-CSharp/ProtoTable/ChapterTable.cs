using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200030B RID: 779
	public class ChapterTable : IFlatbufferObject
	{
		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06001EB7 RID: 7863 RVA: 0x0008290C File Offset: 0x00080D0C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001EB8 RID: 7864 RVA: 0x00082919 File Offset: 0x00080D19
		public static ChapterTable GetRootAsChapterTable(ByteBuffer _bb)
		{
			return ChapterTable.GetRootAsChapterTable(_bb, new ChapterTable());
		}

		// Token: 0x06001EB9 RID: 7865 RVA: 0x00082926 File Offset: 0x00080D26
		public static ChapterTable GetRootAsChapterTable(ByteBuffer _bb, ChapterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001EBA RID: 7866 RVA: 0x00082942 File Offset: 0x00080D42
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001EBB RID: 7867 RVA: 0x0008295C File Offset: 0x00080D5C
		public ChapterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x06001EBC RID: 7868 RVA: 0x00082968 File Offset: 0x00080D68
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1366078111 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x06001EBD RID: 7869 RVA: 0x000829B4 File Offset: 0x00080DB4
		public string ChapterName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001EBE RID: 7870 RVA: 0x000829F6 File Offset: 0x00080DF6
		public ArraySegment<byte>? GetChapterNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x06001EBF RID: 7871 RVA: 0x00082A04 File Offset: 0x00080E04
		public int RewardIsOpen
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1366078111 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x06001EC0 RID: 7872 RVA: 0x00082A50 File Offset: 0x00080E50
		public string ChapterIconPath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001EC1 RID: 7873 RVA: 0x00082A93 File Offset: 0x00080E93
		public ArraySegment<byte>? GetChapterIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06001EC2 RID: 7874 RVA: 0x00082AA2 File Offset: 0x00080EA2
		public static Offset<ChapterTable> CreateChapterTable(FlatBufferBuilder builder, int ID = 0, StringOffset ChapterNameOffset = default(StringOffset), int RewardIsOpen = 0, StringOffset ChapterIconPathOffset = default(StringOffset))
		{
			builder.StartObject(4);
			ChapterTable.AddChapterIconPath(builder, ChapterIconPathOffset);
			ChapterTable.AddRewardIsOpen(builder, RewardIsOpen);
			ChapterTable.AddChapterName(builder, ChapterNameOffset);
			ChapterTable.AddID(builder, ID);
			return ChapterTable.EndChapterTable(builder);
		}

		// Token: 0x06001EC3 RID: 7875 RVA: 0x00082ACE File Offset: 0x00080ECE
		public static void StartChapterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x00082AD7 File Offset: 0x00080ED7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x00082AE2 File Offset: 0x00080EE2
		public static void AddChapterName(FlatBufferBuilder builder, StringOffset ChapterNameOffset)
		{
			builder.AddOffset(1, ChapterNameOffset.Value, 0);
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x00082AF3 File Offset: 0x00080EF3
		public static void AddRewardIsOpen(FlatBufferBuilder builder, int RewardIsOpen)
		{
			builder.AddInt(2, RewardIsOpen, 0);
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x00082AFE File Offset: 0x00080EFE
		public static void AddChapterIconPath(FlatBufferBuilder builder, StringOffset ChapterIconPathOffset)
		{
			builder.AddOffset(3, ChapterIconPathOffset.Value, 0);
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x00082B10 File Offset: 0x00080F10
		public static Offset<ChapterTable> EndChapterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChapterTable>(value);
		}

		// Token: 0x06001EC9 RID: 7881 RVA: 0x00082B2A File Offset: 0x00080F2A
		public static void FinishChapterTableBuffer(FlatBufferBuilder builder, Offset<ChapterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F45 RID: 3909
		private Table __p = new Table();

		// Token: 0x0200030C RID: 780
		public enum eCrypt
		{
			// Token: 0x04000F47 RID: 3911
			code = 1366078111
		}
	}
}
