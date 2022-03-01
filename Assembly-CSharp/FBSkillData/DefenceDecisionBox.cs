using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B1D RID: 19229
	public sealed class DefenceDecisionBox : Table
	{
		// Token: 0x0601C0C7 RID: 114887 RVA: 0x008909BA File Offset: 0x0088EDBA
		public static DefenceDecisionBox GetRootAsDefenceDecisionBox(ByteBuffer _bb)
		{
			return DefenceDecisionBox.GetRootAsDefenceDecisionBox(_bb, new DefenceDecisionBox());
		}

		// Token: 0x0601C0C8 RID: 114888 RVA: 0x008909C7 File Offset: 0x0088EDC7
		public static DefenceDecisionBox GetRootAsDefenceDecisionBox(ByteBuffer _bb, DefenceDecisionBox obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C0C9 RID: 114889 RVA: 0x008909E3 File Offset: 0x0088EDE3
		public DefenceDecisionBox __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x0601C0CA RID: 114890 RVA: 0x008909F4 File Offset: 0x0088EDF4
		public ShapeBox GetBoxs(int j)
		{
			return this.GetBoxs(new ShapeBox(), j);
		}

		// Token: 0x0601C0CB RID: 114891 RVA: 0x00890A04 File Offset: 0x0088EE04
		public ShapeBox GetBoxs(ShapeBox obj, int j)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x1700267F RID: 9855
		// (get) Token: 0x0601C0CC RID: 114892 RVA: 0x00890A44 File Offset: 0x0088EE44
		public int BoxsLength
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x17002680 RID: 9856
		// (get) Token: 0x0601C0CD RID: 114893 RVA: 0x00890A6C File Offset: 0x0088EE6C
		public bool HasHit
		{
			get
			{
				int num = base.__offset(6);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002681 RID: 9857
		// (get) Token: 0x0601C0CE RID: 114894 RVA: 0x00890AA8 File Offset: 0x0088EEA8
		public bool BlockToggle
		{
			get
			{
				int num = base.__offset(8);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x17002682 RID: 9858
		// (get) Token: 0x0601C0CF RID: 114895 RVA: 0x00890AE4 File Offset: 0x0088EEE4
		public int Type
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C0D0 RID: 114896 RVA: 0x00890B19 File Offset: 0x0088EF19
		public static Offset<DefenceDecisionBox> CreateDefenceDecisionBox(FlatBufferBuilder builder, VectorOffset boxs = default(VectorOffset), bool hasHit = false, bool blockToggle = false, int type = 0)
		{
			builder.StartObject(4);
			DefenceDecisionBox.AddType(builder, type);
			DefenceDecisionBox.AddBoxs(builder, boxs);
			DefenceDecisionBox.AddBlockToggle(builder, blockToggle);
			DefenceDecisionBox.AddHasHit(builder, hasHit);
			return DefenceDecisionBox.EndDefenceDecisionBox(builder);
		}

		// Token: 0x0601C0D1 RID: 114897 RVA: 0x00890B45 File Offset: 0x0088EF45
		public static void StartDefenceDecisionBox(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0601C0D2 RID: 114898 RVA: 0x00890B4E File Offset: 0x0088EF4E
		public static void AddBoxs(FlatBufferBuilder builder, VectorOffset boxsOffset)
		{
			builder.AddOffset(0, boxsOffset.Value, 0);
		}

		// Token: 0x0601C0D3 RID: 114899 RVA: 0x00890B60 File Offset: 0x0088EF60
		public static VectorOffset CreateBoxsVector(FlatBufferBuilder builder, Offset<ShapeBox>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C0D4 RID: 114900 RVA: 0x00890BA6 File Offset: 0x0088EFA6
		public static void StartBoxsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C0D5 RID: 114901 RVA: 0x00890BB1 File Offset: 0x0088EFB1
		public static void AddHasHit(FlatBufferBuilder builder, bool hasHit)
		{
			builder.AddBool(1, hasHit, false);
		}

		// Token: 0x0601C0D6 RID: 114902 RVA: 0x00890BBC File Offset: 0x0088EFBC
		public static void AddBlockToggle(FlatBufferBuilder builder, bool blockToggle)
		{
			builder.AddBool(2, blockToggle, false);
		}

		// Token: 0x0601C0D7 RID: 114903 RVA: 0x00890BC7 File Offset: 0x0088EFC7
		public static void AddType(FlatBufferBuilder builder, int type)
		{
			builder.AddInt(3, type, 0);
		}

		// Token: 0x0601C0D8 RID: 114904 RVA: 0x00890BD4 File Offset: 0x0088EFD4
		public static Offset<DefenceDecisionBox> EndDefenceDecisionBox(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DefenceDecisionBox>(value);
		}
	}
}
