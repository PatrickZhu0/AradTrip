using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000455 RID: 1109
	public class GuidanceLevelTable : IFlatbufferObject
	{
		// Token: 0x17000D4C RID: 3404
		// (get) Token: 0x0600355C RID: 13660 RVA: 0x000B941C File Offset: 0x000B781C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600355D RID: 13661 RVA: 0x000B9429 File Offset: 0x000B7829
		public static GuidanceLevelTable GetRootAsGuidanceLevelTable(ByteBuffer _bb)
		{
			return GuidanceLevelTable.GetRootAsGuidanceLevelTable(_bb, new GuidanceLevelTable());
		}

		// Token: 0x0600355E RID: 13662 RVA: 0x000B9436 File Offset: 0x000B7836
		public static GuidanceLevelTable GetRootAsGuidanceLevelTable(ByteBuffer _bb, GuidanceLevelTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600355F RID: 13663 RVA: 0x000B9452 File Offset: 0x000B7852
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003560 RID: 13664 RVA: 0x000B946C File Offset: 0x000B786C
		public GuidanceLevelTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D4D RID: 3405
		// (get) Token: 0x06003561 RID: 13665 RVA: 0x000B9478 File Offset: 0x000B7878
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1028261162 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003562 RID: 13666 RVA: 0x000B94C4 File Offset: 0x000B78C4
		public int RelationIdsArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (1028261162 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D4E RID: 3406
		// (get) Token: 0x06003563 RID: 13667 RVA: 0x000B9510 File Offset: 0x000B7910
		public int RelationIdsLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003564 RID: 13668 RVA: 0x000B9542 File Offset: 0x000B7942
		public ArraySegment<byte>? GetRelationIdsBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000D4F RID: 3407
		// (get) Token: 0x06003565 RID: 13669 RVA: 0x000B9550 File Offset: 0x000B7950
		public FlatBufferArray<int> RelationIds
		{
			get
			{
				if (this.RelationIdsValue == null)
				{
					this.RelationIdsValue = new FlatBufferArray<int>(new Func<int, int>(this.RelationIdsArray), this.RelationIdsLength);
				}
				return this.RelationIdsValue;
			}
		}

		// Token: 0x06003566 RID: 13670 RVA: 0x000B9580 File Offset: 0x000B7980
		public static Offset<GuidanceLevelTable> CreateGuidanceLevelTable(FlatBufferBuilder builder, int ID = 0, VectorOffset RelationIdsOffset = default(VectorOffset))
		{
			builder.StartObject(2);
			GuidanceLevelTable.AddRelationIds(builder, RelationIdsOffset);
			GuidanceLevelTable.AddID(builder, ID);
			return GuidanceLevelTable.EndGuidanceLevelTable(builder);
		}

		// Token: 0x06003567 RID: 13671 RVA: 0x000B959D File Offset: 0x000B799D
		public static void StartGuidanceLevelTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06003568 RID: 13672 RVA: 0x000B95A6 File Offset: 0x000B79A6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003569 RID: 13673 RVA: 0x000B95B1 File Offset: 0x000B79B1
		public static void AddRelationIds(FlatBufferBuilder builder, VectorOffset RelationIdsOffset)
		{
			builder.AddOffset(1, RelationIdsOffset.Value, 0);
		}

		// Token: 0x0600356A RID: 13674 RVA: 0x000B95C4 File Offset: 0x000B79C4
		public static VectorOffset CreateRelationIdsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600356B RID: 13675 RVA: 0x000B9601 File Offset: 0x000B7A01
		public static void StartRelationIdsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600356C RID: 13676 RVA: 0x000B960C File Offset: 0x000B7A0C
		public static Offset<GuidanceLevelTable> EndGuidanceLevelTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuidanceLevelTable>(value);
		}

		// Token: 0x0600356D RID: 13677 RVA: 0x000B9626 File Offset: 0x000B7A26
		public static void FinishGuidanceLevelTableBuffer(FlatBufferBuilder builder, Offset<GuidanceLevelTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001589 RID: 5513
		private Table __p = new Table();

		// Token: 0x0400158A RID: 5514
		private FlatBufferArray<int> RelationIdsValue;

		// Token: 0x02000456 RID: 1110
		public enum eCrypt
		{
			// Token: 0x0400158C RID: 5516
			code = 1028261162
		}
	}
}
