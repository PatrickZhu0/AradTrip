using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D62 RID: 3426
	public sealed class DAnimatParamObj : Table
	{
		// Token: 0x06008B0F RID: 35599 RVA: 0x00199052 File Offset: 0x00197452
		public static DAnimatParamObj GetRootAsDAnimatParamObj(ByteBuffer _bb)
		{
			return DAnimatParamObj.GetRootAsDAnimatParamObj(_bb, new DAnimatParamObj());
		}

		// Token: 0x06008B10 RID: 35600 RVA: 0x0019905F File Offset: 0x0019745F
		public static DAnimatParamObj GetRootAsDAnimatParamObj(ByteBuffer _bb, DAnimatParamObj obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06008B11 RID: 35601 RVA: 0x0019907B File Offset: 0x0019747B
		public DAnimatParamObj __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17001882 RID: 6274
		// (get) Token: 0x06008B12 RID: 35602 RVA: 0x0019908C File Offset: 0x0019748C
		public string _texAsset
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x06008B13 RID: 35603 RVA: 0x001990BB File Offset: 0x001974BB
		public static Offset<DAnimatParamObj> CreateDAnimatParamObj(FlatBufferBuilder builder, StringOffset _texAsset = default(StringOffset))
		{
			builder.StartObject(1);
			DAnimatParamObj.Add_texAsset(builder, _texAsset);
			return DAnimatParamObj.EndDAnimatParamObj(builder);
		}

		// Token: 0x06008B14 RID: 35604 RVA: 0x001990D1 File Offset: 0x001974D1
		public static void StartDAnimatParamObj(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x06008B15 RID: 35605 RVA: 0x001990DA File Offset: 0x001974DA
		public static void Add_texAsset(FlatBufferBuilder builder, StringOffset TexAssetOffset)
		{
			builder.AddOffset(0, TexAssetOffset.Value, 0);
		}

		// Token: 0x06008B16 RID: 35606 RVA: 0x001990EC File Offset: 0x001974EC
		public static Offset<DAnimatParamObj> EndDAnimatParamObj(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DAnimatParamObj>(value);
		}
	}
}
