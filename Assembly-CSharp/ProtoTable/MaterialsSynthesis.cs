using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004FC RID: 1276
	public class MaterialsSynthesis : IFlatbufferObject
	{
		// Token: 0x17001132 RID: 4402
		// (get) Token: 0x06004129 RID: 16681 RVA: 0x000D5304 File Offset: 0x000D3704
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600412A RID: 16682 RVA: 0x000D5311 File Offset: 0x000D3711
		public static MaterialsSynthesis GetRootAsMaterialsSynthesis(ByteBuffer _bb)
		{
			return MaterialsSynthesis.GetRootAsMaterialsSynthesis(_bb, new MaterialsSynthesis());
		}

		// Token: 0x0600412B RID: 16683 RVA: 0x000D531E File Offset: 0x000D371E
		public static MaterialsSynthesis GetRootAsMaterialsSynthesis(ByteBuffer _bb, MaterialsSynthesis obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600412C RID: 16684 RVA: 0x000D533A File Offset: 0x000D373A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600412D RID: 16685 RVA: 0x000D5354 File Offset: 0x000D3754
		public MaterialsSynthesis __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001133 RID: 4403
		// (get) Token: 0x0600412E RID: 16686 RVA: 0x000D5360 File Offset: 0x000D3760
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (623797180 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001134 RID: 4404
		// (get) Token: 0x0600412F RID: 16687 RVA: 0x000D53AC File Offset: 0x000D37AC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004130 RID: 16688 RVA: 0x000D53EE File Offset: 0x000D37EE
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001135 RID: 4405
		// (get) Token: 0x06004131 RID: 16689 RVA: 0x000D53FC File Offset: 0x000D37FC
		public string Composites
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004132 RID: 16690 RVA: 0x000D543E File Offset: 0x000D383E
		public ArraySegment<byte>? GetCompositesBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06004133 RID: 16691 RVA: 0x000D544C File Offset: 0x000D384C
		public static Offset<MaterialsSynthesis> CreateMaterialsSynthesis(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset CompositesOffset = default(StringOffset))
		{
			builder.StartObject(3);
			MaterialsSynthesis.AddComposites(builder, CompositesOffset);
			MaterialsSynthesis.AddName(builder, NameOffset);
			MaterialsSynthesis.AddID(builder, ID);
			return MaterialsSynthesis.EndMaterialsSynthesis(builder);
		}

		// Token: 0x06004134 RID: 16692 RVA: 0x000D5470 File Offset: 0x000D3870
		public static void StartMaterialsSynthesis(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004135 RID: 16693 RVA: 0x000D5479 File Offset: 0x000D3879
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004136 RID: 16694 RVA: 0x000D5484 File Offset: 0x000D3884
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004137 RID: 16695 RVA: 0x000D5495 File Offset: 0x000D3895
		public static void AddComposites(FlatBufferBuilder builder, StringOffset CompositesOffset)
		{
			builder.AddOffset(2, CompositesOffset.Value, 0);
		}

		// Token: 0x06004138 RID: 16696 RVA: 0x000D54A8 File Offset: 0x000D38A8
		public static Offset<MaterialsSynthesis> EndMaterialsSynthesis(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MaterialsSynthesis>(value);
		}

		// Token: 0x06004139 RID: 16697 RVA: 0x000D54C2 File Offset: 0x000D38C2
		public static void FinishMaterialsSynthesisBuffer(FlatBufferBuilder builder, Offset<MaterialsSynthesis> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400186D RID: 6253
		private Table __p = new Table();

		// Token: 0x020004FD RID: 1277
		public enum eCrypt
		{
			// Token: 0x0400186F RID: 6255
			code = 623797180
		}
	}
}
