using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D61 RID: 3425
	public sealed class DAnimatParamData : Table
	{
		// Token: 0x06008B01 RID: 35585 RVA: 0x00198EF4 File Offset: 0x001972F4
		public static DAnimatParamData GetRootAsDAnimatParamData(ByteBuffer _bb)
		{
			return DAnimatParamData.GetRootAsDAnimatParamData(_bb, new DAnimatParamData());
		}

		// Token: 0x06008B02 RID: 35586 RVA: 0x00198F01 File Offset: 0x00197301
		public static DAnimatParamData GetRootAsDAnimatParamData(ByteBuffer _bb, DAnimatParamData obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06008B03 RID: 35587 RVA: 0x00198F1D File Offset: 0x0019731D
		public DAnimatParamData __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700187F RID: 6271
		// (get) Token: 0x06008B04 RID: 35588 RVA: 0x00198F30 File Offset: 0x00197330
		public float _float
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17001880 RID: 6272
		// (get) Token: 0x06008B05 RID: 35589 RVA: 0x00198F68 File Offset: 0x00197368
		public Color _color
		{
			get
			{
				return this.Get_color(new Color());
			}
		}

		// Token: 0x06008B06 RID: 35590 RVA: 0x00198F78 File Offset: 0x00197378
		public Color Get_color(Color obj)
		{
			int num = base.__offset(6);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17001881 RID: 6273
		// (get) Token: 0x06008B07 RID: 35591 RVA: 0x00198FAD File Offset: 0x001973AD
		public Vector4 _vec4
		{
			get
			{
				return this.Get_vec4(new Vector4());
			}
		}

		// Token: 0x06008B08 RID: 35592 RVA: 0x00198FBC File Offset: 0x001973BC
		public Vector4 Get_vec4(Vector4 obj)
		{
			int num = base.__offset(8);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x06008B09 RID: 35593 RVA: 0x00198FF1 File Offset: 0x001973F1
		public static void StartDAnimatParamData(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06008B0A RID: 35594 RVA: 0x00198FFA File Offset: 0x001973FA
		public static void Add_float(FlatBufferBuilder builder, float Float)
		{
			builder.AddFloat(0, Float, 0.0);
		}

		// Token: 0x06008B0B RID: 35595 RVA: 0x0019900D File Offset: 0x0019740D
		public static void Add_color(FlatBufferBuilder builder, Offset<Color> ColorOffset)
		{
			builder.AddStruct(1, ColorOffset.Value, 0);
		}

		// Token: 0x06008B0C RID: 35596 RVA: 0x0019901E File Offset: 0x0019741E
		public static void Add_vec4(FlatBufferBuilder builder, Offset<Vector4> Vec4Offset)
		{
			builder.AddStruct(2, Vec4Offset.Value, 0);
		}

		// Token: 0x06008B0D RID: 35597 RVA: 0x00199030 File Offset: 0x00197430
		public static Offset<DAnimatParamData> EndDAnimatParamData(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DAnimatParamData>(value);
		}
	}
}
