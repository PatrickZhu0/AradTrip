using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000589 RID: 1417
	public class RobotConfigTable : IFlatbufferObject
	{
		// Token: 0x170013EE RID: 5102
		// (get) Token: 0x06004987 RID: 18823 RVA: 0x000E852C File Offset: 0x000E692C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004988 RID: 18824 RVA: 0x000E8539 File Offset: 0x000E6939
		public static RobotConfigTable GetRootAsRobotConfigTable(ByteBuffer _bb)
		{
			return RobotConfigTable.GetRootAsRobotConfigTable(_bb, new RobotConfigTable());
		}

		// Token: 0x06004989 RID: 18825 RVA: 0x000E8546 File Offset: 0x000E6946
		public static RobotConfigTable GetRootAsRobotConfigTable(ByteBuffer _bb, RobotConfigTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600498A RID: 18826 RVA: 0x000E8562 File Offset: 0x000E6962
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600498B RID: 18827 RVA: 0x000E857C File Offset: 0x000E697C
		public RobotConfigTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170013EF RID: 5103
		// (get) Token: 0x0600498C RID: 18828 RVA: 0x000E8588 File Offset: 0x000E6988
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1538225668 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013F0 RID: 5104
		// (get) Token: 0x0600498D RID: 18829 RVA: 0x000E85D4 File Offset: 0x000E69D4
		public int Level
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1538225668 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170013F1 RID: 5105
		// (get) Token: 0x0600498E RID: 18830 RVA: 0x000E8620 File Offset: 0x000E6A20
		public int Occu
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1538225668 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600498F RID: 18831 RVA: 0x000E866C File Offset: 0x000E6A6C
		public int SkillsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1538225668 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170013F2 RID: 5106
		// (get) Token: 0x06004990 RID: 18832 RVA: 0x000E86BC File Offset: 0x000E6ABC
		public int SkillsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004991 RID: 18833 RVA: 0x000E86EF File Offset: 0x000E6AEF
		public ArraySegment<byte>? GetSkillsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170013F3 RID: 5107
		// (get) Token: 0x06004992 RID: 18834 RVA: 0x000E86FE File Offset: 0x000E6AFE
		public FlatBufferArray<int> Skills
		{
			get
			{
				if (this.SkillsValue == null)
				{
					this.SkillsValue = new FlatBufferArray<int>(new Func<int, int>(this.SkillsArray), this.SkillsLength);
				}
				return this.SkillsValue;
			}
		}

		// Token: 0x06004993 RID: 18835 RVA: 0x000E8730 File Offset: 0x000E6B30
		public int FashionsArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-1538225668 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170013F4 RID: 5108
		// (get) Token: 0x06004994 RID: 18836 RVA: 0x000E8780 File Offset: 0x000E6B80
		public int FashionsLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004995 RID: 18837 RVA: 0x000E87B3 File Offset: 0x000E6BB3
		public ArraySegment<byte>? GetFashionsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170013F5 RID: 5109
		// (get) Token: 0x06004996 RID: 18838 RVA: 0x000E87C2 File Offset: 0x000E6BC2
		public FlatBufferArray<int> Fashions
		{
			get
			{
				if (this.FashionsValue == null)
				{
					this.FashionsValue = new FlatBufferArray<int>(new Func<int, int>(this.FashionsArray), this.FashionsLength);
				}
				return this.FashionsValue;
			}
		}

		// Token: 0x06004997 RID: 18839 RVA: 0x000E87F2 File Offset: 0x000E6BF2
		public static Offset<RobotConfigTable> CreateRobotConfigTable(FlatBufferBuilder builder, int ID = 0, int Level = 0, int Occu = 0, VectorOffset SkillsOffset = default(VectorOffset), VectorOffset FashionsOffset = default(VectorOffset))
		{
			builder.StartObject(5);
			RobotConfigTable.AddFashions(builder, FashionsOffset);
			RobotConfigTable.AddSkills(builder, SkillsOffset);
			RobotConfigTable.AddOccu(builder, Occu);
			RobotConfigTable.AddLevel(builder, Level);
			RobotConfigTable.AddID(builder, ID);
			return RobotConfigTable.EndRobotConfigTable(builder);
		}

		// Token: 0x06004998 RID: 18840 RVA: 0x000E8826 File Offset: 0x000E6C26
		public static void StartRobotConfigTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06004999 RID: 18841 RVA: 0x000E882F File Offset: 0x000E6C2F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600499A RID: 18842 RVA: 0x000E883A File Offset: 0x000E6C3A
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(1, Level, 0);
		}

		// Token: 0x0600499B RID: 18843 RVA: 0x000E8845 File Offset: 0x000E6C45
		public static void AddOccu(FlatBufferBuilder builder, int Occu)
		{
			builder.AddInt(2, Occu, 0);
		}

		// Token: 0x0600499C RID: 18844 RVA: 0x000E8850 File Offset: 0x000E6C50
		public static void AddSkills(FlatBufferBuilder builder, VectorOffset SkillsOffset)
		{
			builder.AddOffset(3, SkillsOffset.Value, 0);
		}

		// Token: 0x0600499D RID: 18845 RVA: 0x000E8864 File Offset: 0x000E6C64
		public static VectorOffset CreateSkillsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600499E RID: 18846 RVA: 0x000E88A1 File Offset: 0x000E6CA1
		public static void StartSkillsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600499F RID: 18847 RVA: 0x000E88AC File Offset: 0x000E6CAC
		public static void AddFashions(FlatBufferBuilder builder, VectorOffset FashionsOffset)
		{
			builder.AddOffset(4, FashionsOffset.Value, 0);
		}

		// Token: 0x060049A0 RID: 18848 RVA: 0x000E88C0 File Offset: 0x000E6CC0
		public static VectorOffset CreateFashionsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060049A1 RID: 18849 RVA: 0x000E88FD File Offset: 0x000E6CFD
		public static void StartFashionsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060049A2 RID: 18850 RVA: 0x000E8908 File Offset: 0x000E6D08
		public static Offset<RobotConfigTable> EndRobotConfigTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RobotConfigTable>(value);
		}

		// Token: 0x060049A3 RID: 18851 RVA: 0x000E8922 File Offset: 0x000E6D22
		public static void FinishRobotConfigTableBuffer(FlatBufferBuilder builder, Offset<RobotConfigTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AB7 RID: 6839
		private Table __p = new Table();

		// Token: 0x04001AB8 RID: 6840
		private FlatBufferArray<int> SkillsValue;

		// Token: 0x04001AB9 RID: 6841
		private FlatBufferArray<int> FashionsValue;

		// Token: 0x0200058A RID: 1418
		public enum eCrypt
		{
			// Token: 0x04001ABB RID: 6843
			code = -1538225668
		}
	}
}
