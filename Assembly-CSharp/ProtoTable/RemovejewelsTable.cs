using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200057E RID: 1406
	public class RemovejewelsTable : IFlatbufferObject
	{
		// Token: 0x17001381 RID: 4993
		// (get) Token: 0x0600483C RID: 18492 RVA: 0x000E5674 File Offset: 0x000E3A74
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600483D RID: 18493 RVA: 0x000E5681 File Offset: 0x000E3A81
		public static RemovejewelsTable GetRootAsRemovejewelsTable(ByteBuffer _bb)
		{
			return RemovejewelsTable.GetRootAsRemovejewelsTable(_bb, new RemovejewelsTable());
		}

		// Token: 0x0600483E RID: 18494 RVA: 0x000E568E File Offset: 0x000E3A8E
		public static RemovejewelsTable GetRootAsRemovejewelsTable(ByteBuffer _bb, RemovejewelsTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600483F RID: 18495 RVA: 0x000E56AA File Offset: 0x000E3AAA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004840 RID: 18496 RVA: 0x000E56C4 File Offset: 0x000E3AC4
		public RemovejewelsTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001382 RID: 4994
		// (get) Token: 0x06004841 RID: 18497 RVA: 0x000E56D0 File Offset: 0x000E3AD0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-719475222 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001383 RID: 4995
		// (get) Token: 0x06004842 RID: 18498 RVA: 0x000E571C File Offset: 0x000E3B1C
		public int Colour
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-719475222 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001384 RID: 4996
		// (get) Token: 0x06004843 RID: 18499 RVA: 0x000E5768 File Offset: 0x000E3B68
		public int Grades
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-719475222 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001385 RID: 4997
		// (get) Token: 0x06004844 RID: 18500 RVA: 0x000E57B4 File Offset: 0x000E3BB4
		public int Material1
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-719475222 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001386 RID: 4998
		// (get) Token: 0x06004845 RID: 18501 RVA: 0x000E5800 File Offset: 0x000E3C00
		public int Num1
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-719475222 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001387 RID: 4999
		// (get) Token: 0x06004846 RID: 18502 RVA: 0x000E584C File Offset: 0x000E3C4C
		public int Success1
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-719475222 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001388 RID: 5000
		// (get) Token: 0x06004847 RID: 18503 RVA: 0x000E5898 File Offset: 0x000E3C98
		public int BeadType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-719475222 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001389 RID: 5001
		// (get) Token: 0x06004848 RID: 18504 RVA: 0x000E58E4 File Offset: 0x000E3CE4
		public int PickNum
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-719475222 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004849 RID: 18505 RVA: 0x000E5930 File Offset: 0x000E3D30
		public static Offset<RemovejewelsTable> CreateRemovejewelsTable(FlatBufferBuilder builder, int ID = 0, int Colour = 0, int Grades = 0, int Material1 = 0, int Num1 = 0, int Success1 = 0, int BeadType = 0, int PickNum = 0)
		{
			builder.StartObject(8);
			RemovejewelsTable.AddPickNum(builder, PickNum);
			RemovejewelsTable.AddBeadType(builder, BeadType);
			RemovejewelsTable.AddSuccess1(builder, Success1);
			RemovejewelsTable.AddNum1(builder, Num1);
			RemovejewelsTable.AddMaterial1(builder, Material1);
			RemovejewelsTable.AddGrades(builder, Grades);
			RemovejewelsTable.AddColour(builder, Colour);
			RemovejewelsTable.AddID(builder, ID);
			return RemovejewelsTable.EndRemovejewelsTable(builder);
		}

		// Token: 0x0600484A RID: 18506 RVA: 0x000E5987 File Offset: 0x000E3D87
		public static void StartRemovejewelsTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x0600484B RID: 18507 RVA: 0x000E5990 File Offset: 0x000E3D90
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600484C RID: 18508 RVA: 0x000E599B File Offset: 0x000E3D9B
		public static void AddColour(FlatBufferBuilder builder, int Colour)
		{
			builder.AddInt(1, Colour, 0);
		}

		// Token: 0x0600484D RID: 18509 RVA: 0x000E59A6 File Offset: 0x000E3DA6
		public static void AddGrades(FlatBufferBuilder builder, int Grades)
		{
			builder.AddInt(2, Grades, 0);
		}

		// Token: 0x0600484E RID: 18510 RVA: 0x000E59B1 File Offset: 0x000E3DB1
		public static void AddMaterial1(FlatBufferBuilder builder, int Material1)
		{
			builder.AddInt(3, Material1, 0);
		}

		// Token: 0x0600484F RID: 18511 RVA: 0x000E59BC File Offset: 0x000E3DBC
		public static void AddNum1(FlatBufferBuilder builder, int Num1)
		{
			builder.AddInt(4, Num1, 0);
		}

		// Token: 0x06004850 RID: 18512 RVA: 0x000E59C7 File Offset: 0x000E3DC7
		public static void AddSuccess1(FlatBufferBuilder builder, int Success1)
		{
			builder.AddInt(5, Success1, 0);
		}

		// Token: 0x06004851 RID: 18513 RVA: 0x000E59D2 File Offset: 0x000E3DD2
		public static void AddBeadType(FlatBufferBuilder builder, int BeadType)
		{
			builder.AddInt(6, BeadType, 0);
		}

		// Token: 0x06004852 RID: 18514 RVA: 0x000E59DD File Offset: 0x000E3DDD
		public static void AddPickNum(FlatBufferBuilder builder, int PickNum)
		{
			builder.AddInt(7, PickNum, 0);
		}

		// Token: 0x06004853 RID: 18515 RVA: 0x000E59E8 File Offset: 0x000E3DE8
		public static Offset<RemovejewelsTable> EndRemovejewelsTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RemovejewelsTable>(value);
		}

		// Token: 0x06004854 RID: 18516 RVA: 0x000E5A02 File Offset: 0x000E3E02
		public static void FinishRemovejewelsTableBuffer(FlatBufferBuilder builder, Offset<RemovejewelsTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AA0 RID: 6816
		private Table __p = new Table();

		// Token: 0x0200057F RID: 1407
		public enum eCrypt
		{
			// Token: 0x04001AA2 RID: 6818
			code = -719475222
		}
	}
}
