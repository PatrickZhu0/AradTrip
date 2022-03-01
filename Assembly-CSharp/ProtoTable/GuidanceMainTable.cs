using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000459 RID: 1113
	public class GuidanceMainTable : IFlatbufferObject
	{
		// Token: 0x17000D58 RID: 3416
		// (get) Token: 0x0600358A RID: 13706 RVA: 0x000B99BC File Offset: 0x000B7DBC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600358B RID: 13707 RVA: 0x000B99C9 File Offset: 0x000B7DC9
		public static GuidanceMainTable GetRootAsGuidanceMainTable(ByteBuffer _bb)
		{
			return GuidanceMainTable.GetRootAsGuidanceMainTable(_bb, new GuidanceMainTable());
		}

		// Token: 0x0600358C RID: 13708 RVA: 0x000B99D6 File Offset: 0x000B7DD6
		public static GuidanceMainTable GetRootAsGuidanceMainTable(ByteBuffer _bb, GuidanceMainTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600358D RID: 13709 RVA: 0x000B99F2 File Offset: 0x000B7DF2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600358E RID: 13710 RVA: 0x000B9A0C File Offset: 0x000B7E0C
		public GuidanceMainTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D59 RID: 3417
		// (get) Token: 0x0600358F RID: 13711 RVA: 0x000B9A18 File Offset: 0x000B7E18
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1525016923 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D5A RID: 3418
		// (get) Token: 0x06003590 RID: 13712 RVA: 0x000B9A64 File Offset: 0x000B7E64
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003591 RID: 13713 RVA: 0x000B9AA6 File Offset: 0x000B7EA6
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06003592 RID: 13714 RVA: 0x000B9AB4 File Offset: 0x000B7EB4
		public int LinkItemsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (1525016923 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D5B RID: 3419
		// (get) Token: 0x06003593 RID: 13715 RVA: 0x000B9B00 File Offset: 0x000B7F00
		public int LinkItemsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003594 RID: 13716 RVA: 0x000B9B32 File Offset: 0x000B7F32
		public ArraySegment<byte>? GetLinkItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000D5C RID: 3420
		// (get) Token: 0x06003595 RID: 13717 RVA: 0x000B9B40 File Offset: 0x000B7F40
		public FlatBufferArray<int> LinkItems
		{
			get
			{
				if (this.LinkItemsValue == null)
				{
					this.LinkItemsValue = new FlatBufferArray<int>(new Func<int, int>(this.LinkItemsArray), this.LinkItemsLength);
				}
				return this.LinkItemsValue;
			}
		}

		// Token: 0x17000D5D RID: 3421
		// (get) Token: 0x06003596 RID: 13718 RVA: 0x000B9B70 File Offset: 0x000B7F70
		public int UnLockLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1525016923 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003597 RID: 13719 RVA: 0x000B9BBA File Offset: 0x000B7FBA
		public static Offset<GuidanceMainTable> CreateGuidanceMainTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescOffset = default(StringOffset), VectorOffset LinkItemsOffset = default(VectorOffset), int UnLockLevel = 0)
		{
			builder.StartObject(4);
			GuidanceMainTable.AddUnLockLevel(builder, UnLockLevel);
			GuidanceMainTable.AddLinkItems(builder, LinkItemsOffset);
			GuidanceMainTable.AddDesc(builder, DescOffset);
			GuidanceMainTable.AddID(builder, ID);
			return GuidanceMainTable.EndGuidanceMainTable(builder);
		}

		// Token: 0x06003598 RID: 13720 RVA: 0x000B9BE6 File Offset: 0x000B7FE6
		public static void StartGuidanceMainTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06003599 RID: 13721 RVA: 0x000B9BEF File Offset: 0x000B7FEF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600359A RID: 13722 RVA: 0x000B9BFA File Offset: 0x000B7FFA
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(1, DescOffset.Value, 0);
		}

		// Token: 0x0600359B RID: 13723 RVA: 0x000B9C0B File Offset: 0x000B800B
		public static void AddLinkItems(FlatBufferBuilder builder, VectorOffset LinkItemsOffset)
		{
			builder.AddOffset(2, LinkItemsOffset.Value, 0);
		}

		// Token: 0x0600359C RID: 13724 RVA: 0x000B9C1C File Offset: 0x000B801C
		public static VectorOffset CreateLinkItemsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600359D RID: 13725 RVA: 0x000B9C59 File Offset: 0x000B8059
		public static void StartLinkItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600359E RID: 13726 RVA: 0x000B9C64 File Offset: 0x000B8064
		public static void AddUnLockLevel(FlatBufferBuilder builder, int UnLockLevel)
		{
			builder.AddInt(3, UnLockLevel, 0);
		}

		// Token: 0x0600359F RID: 13727 RVA: 0x000B9C70 File Offset: 0x000B8070
		public static Offset<GuidanceMainTable> EndGuidanceMainTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuidanceMainTable>(value);
		}

		// Token: 0x060035A0 RID: 13728 RVA: 0x000B9C8A File Offset: 0x000B808A
		public static void FinishGuidanceMainTableBuffer(FlatBufferBuilder builder, Offset<GuidanceMainTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001590 RID: 5520
		private Table __p = new Table();

		// Token: 0x04001591 RID: 5521
		private FlatBufferArray<int> LinkItemsValue;

		// Token: 0x0200045A RID: 1114
		public enum eCrypt
		{
			// Token: 0x04001593 RID: 5523
			code = 1525016923
		}
	}
}
