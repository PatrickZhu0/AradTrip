using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B1B RID: 19227
	public sealed class ShapeBox : Table
	{
		// Token: 0x0601C0A4 RID: 114852 RVA: 0x008905CE File Offset: 0x0088E9CE
		public static ShapeBox GetRootAsShapeBox(ByteBuffer _bb)
		{
			return ShapeBox.GetRootAsShapeBox(_bb, new ShapeBox());
		}

		// Token: 0x0601C0A5 RID: 114853 RVA: 0x008905DB File Offset: 0x0088E9DB
		public static ShapeBox GetRootAsShapeBox(ByteBuffer _bb, ShapeBox obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C0A6 RID: 114854 RVA: 0x008905F7 File Offset: 0x0088E9F7
		public ShapeBox __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002677 RID: 9847
		// (get) Token: 0x0601C0A7 RID: 114855 RVA: 0x00890608 File Offset: 0x0088EA08
		public Vector2 Size
		{
			get
			{
				return this.GetSize(new Vector2());
			}
		}

		// Token: 0x0601C0A8 RID: 114856 RVA: 0x00890618 File Offset: 0x0088EA18
		public Vector2 GetSize(Vector2 obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002678 RID: 9848
		// (get) Token: 0x0601C0A9 RID: 114857 RVA: 0x0089064D File Offset: 0x0088EA4D
		public Vector2 Center
		{
			get
			{
				return this.GetCenter(new Vector2());
			}
		}

		// Token: 0x0601C0AA RID: 114858 RVA: 0x0089065C File Offset: 0x0088EA5C
		public Vector2 GetCenter(Vector2 obj)
		{
			int num = base.__offset(6);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601C0AB RID: 114859 RVA: 0x00890691 File Offset: 0x0088EA91
		public static void StartShapeBox(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x0601C0AC RID: 114860 RVA: 0x0089069A File Offset: 0x0088EA9A
		public static void AddSize(FlatBufferBuilder builder, Offset<Vector2> sizeOffset)
		{
			builder.AddStruct(0, sizeOffset.Value, 0);
		}

		// Token: 0x0601C0AD RID: 114861 RVA: 0x008906AB File Offset: 0x0088EAAB
		public static void AddCenter(FlatBufferBuilder builder, Offset<Vector2> centerOffset)
		{
			builder.AddStruct(1, centerOffset.Value, 0);
		}

		// Token: 0x0601C0AE RID: 114862 RVA: 0x008906BC File Offset: 0x0088EABC
		public static Offset<ShapeBox> EndShapeBox(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ShapeBox>(value);
		}
	}
}
