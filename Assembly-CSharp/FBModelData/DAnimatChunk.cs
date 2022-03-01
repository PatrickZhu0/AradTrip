using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D64 RID: 3428
	public sealed class DAnimatChunk : Table
	{
		// Token: 0x06008B29 RID: 35625 RVA: 0x001992D2 File Offset: 0x001976D2
		public static DAnimatChunk GetRootAsDAnimatChunk(ByteBuffer _bb)
		{
			return DAnimatChunk.GetRootAsDAnimatChunk(_bb, new DAnimatChunk());
		}

		// Token: 0x06008B2A RID: 35626 RVA: 0x001992DF File Offset: 0x001976DF
		public static DAnimatChunk GetRootAsDAnimatChunk(ByteBuffer _bb, DAnimatChunk obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06008B2B RID: 35627 RVA: 0x001992FB File Offset: 0x001976FB
		public DAnimatChunk __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17001887 RID: 6279
		// (get) Token: 0x06008B2C RID: 35628 RVA: 0x0019930C File Offset: 0x0019770C
		public string Name
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17001888 RID: 6280
		// (get) Token: 0x06008B2D RID: 35629 RVA: 0x0019933C File Offset: 0x0019773C
		public string ShaderName
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x06008B2E RID: 35630 RVA: 0x0019936B File Offset: 0x0019776B
		public DAnimatParamDesc GetParamDesc(int j)
		{
			return this.GetParamDesc(new DAnimatParamDesc(), j);
		}

		// Token: 0x06008B2F RID: 35631 RVA: 0x0019937C File Offset: 0x0019777C
		public DAnimatParamDesc GetParamDesc(DAnimatParamDesc obj, int j)
		{
			int num = base.__offset(8);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17001889 RID: 6281
		// (get) Token: 0x06008B30 RID: 35632 RVA: 0x001993BC File Offset: 0x001977BC
		public int ParamDescLength
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x06008B31 RID: 35633 RVA: 0x001993E4 File Offset: 0x001977E4
		public static Offset<DAnimatChunk> CreateDAnimatChunk(FlatBufferBuilder builder, StringOffset name = default(StringOffset), StringOffset shaderName = default(StringOffset), VectorOffset paramDesc = default(VectorOffset))
		{
			builder.StartObject(3);
			DAnimatChunk.AddParamDesc(builder, paramDesc);
			DAnimatChunk.AddShaderName(builder, shaderName);
			DAnimatChunk.AddName(builder, name);
			return DAnimatChunk.EndDAnimatChunk(builder);
		}

		// Token: 0x06008B32 RID: 35634 RVA: 0x00199408 File Offset: 0x00197808
		public static void StartDAnimatChunk(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06008B33 RID: 35635 RVA: 0x00199411 File Offset: 0x00197811
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(0, nameOffset.Value, 0);
		}

		// Token: 0x06008B34 RID: 35636 RVA: 0x00199422 File Offset: 0x00197822
		public static void AddShaderName(FlatBufferBuilder builder, StringOffset shaderNameOffset)
		{
			builder.AddOffset(1, shaderNameOffset.Value, 0);
		}

		// Token: 0x06008B35 RID: 35637 RVA: 0x00199433 File Offset: 0x00197833
		public static void AddParamDesc(FlatBufferBuilder builder, VectorOffset paramDescOffset)
		{
			builder.AddOffset(2, paramDescOffset.Value, 0);
		}

		// Token: 0x06008B36 RID: 35638 RVA: 0x00199444 File Offset: 0x00197844
		public static VectorOffset CreateParamDescVector(FlatBufferBuilder builder, Offset<DAnimatParamDesc>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06008B37 RID: 35639 RVA: 0x0019948A File Offset: 0x0019788A
		public static void StartParamDescVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06008B38 RID: 35640 RVA: 0x00199498 File Offset: 0x00197898
		public static Offset<DAnimatChunk> EndDAnimatChunk(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DAnimatChunk>(value);
		}
	}
}
