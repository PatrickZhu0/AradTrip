using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B1C RID: 19228
	public sealed class HurtDecisionBox : Table
	{
		// Token: 0x0601C0B0 RID: 114864 RVA: 0x008906DE File Offset: 0x0088EADE
		public static HurtDecisionBox GetRootAsHurtDecisionBox(ByteBuffer _bb)
		{
			return HurtDecisionBox.GetRootAsHurtDecisionBox(_bb, new HurtDecisionBox());
		}

		// Token: 0x0601C0B1 RID: 114865 RVA: 0x008906EB File Offset: 0x0088EAEB
		public static HurtDecisionBox GetRootAsHurtDecisionBox(ByteBuffer _bb, HurtDecisionBox obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C0B2 RID: 114866 RVA: 0x00890707 File Offset: 0x0088EB07
		public HurtDecisionBox __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x0601C0B3 RID: 114867 RVA: 0x00890718 File Offset: 0x0088EB18
		public ShapeBox GetBoxs(int j)
		{
			return this.GetBoxs(new ShapeBox(), j);
		}

		// Token: 0x0601C0B4 RID: 114868 RVA: 0x00890728 File Offset: 0x0088EB28
		public ShapeBox GetBoxs(ShapeBox obj, int j)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x17002679 RID: 9849
		// (get) Token: 0x0601C0B5 RID: 114869 RVA: 0x00890768 File Offset: 0x0088EB68
		public int BoxsLength
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x1700267A RID: 9850
		// (get) Token: 0x0601C0B6 RID: 114870 RVA: 0x00890790 File Offset: 0x0088EB90
		public bool HasHit
		{
			get
			{
				int num = base.__offset(6);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700267B RID: 9851
		// (get) Token: 0x0601C0B7 RID: 114871 RVA: 0x008907CC File Offset: 0x0088EBCC
		public bool BlockToggle
		{
			get
			{
				int num = base.__offset(8);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700267C RID: 9852
		// (get) Token: 0x0601C0B8 RID: 114872 RVA: 0x00890808 File Offset: 0x0088EC08
		public float ZDim
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x1700267D RID: 9853
		// (get) Token: 0x0601C0B9 RID: 114873 RVA: 0x00890844 File Offset: 0x0088EC44
		public int Damage
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700267E RID: 9854
		// (get) Token: 0x0601C0BA RID: 114874 RVA: 0x0089087C File Offset: 0x0088EC7C
		public int HurtID
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C0BB RID: 114875 RVA: 0x008908B1 File Offset: 0x0088ECB1
		public static Offset<HurtDecisionBox> CreateHurtDecisionBox(FlatBufferBuilder builder, VectorOffset boxs = default(VectorOffset), bool hasHit = false, bool blockToggle = false, float zDim = 0f, int damage = 0, int hurtID = 0)
		{
			builder.StartObject(6);
			HurtDecisionBox.AddHurtID(builder, hurtID);
			HurtDecisionBox.AddDamage(builder, damage);
			HurtDecisionBox.AddZDim(builder, zDim);
			HurtDecisionBox.AddBoxs(builder, boxs);
			HurtDecisionBox.AddBlockToggle(builder, blockToggle);
			HurtDecisionBox.AddHasHit(builder, hasHit);
			return HurtDecisionBox.EndHurtDecisionBox(builder);
		}

		// Token: 0x0601C0BC RID: 114876 RVA: 0x008908ED File Offset: 0x0088ECED
		public static void StartHurtDecisionBox(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x0601C0BD RID: 114877 RVA: 0x008908F6 File Offset: 0x0088ECF6
		public static void AddBoxs(FlatBufferBuilder builder, VectorOffset boxsOffset)
		{
			builder.AddOffset(0, boxsOffset.Value, 0);
		}

		// Token: 0x0601C0BE RID: 114878 RVA: 0x00890908 File Offset: 0x0088ED08
		public static VectorOffset CreateBoxsVector(FlatBufferBuilder builder, Offset<ShapeBox>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C0BF RID: 114879 RVA: 0x0089094E File Offset: 0x0088ED4E
		public static void StartBoxsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C0C0 RID: 114880 RVA: 0x00890959 File Offset: 0x0088ED59
		public static void AddHasHit(FlatBufferBuilder builder, bool hasHit)
		{
			builder.AddBool(1, hasHit, false);
		}

		// Token: 0x0601C0C1 RID: 114881 RVA: 0x00890964 File Offset: 0x0088ED64
		public static void AddBlockToggle(FlatBufferBuilder builder, bool blockToggle)
		{
			builder.AddBool(2, blockToggle, false);
		}

		// Token: 0x0601C0C2 RID: 114882 RVA: 0x0089096F File Offset: 0x0088ED6F
		public static void AddZDim(FlatBufferBuilder builder, float zDim)
		{
			builder.AddFloat(3, zDim, 0.0);
		}

		// Token: 0x0601C0C3 RID: 114883 RVA: 0x00890982 File Offset: 0x0088ED82
		public static void AddDamage(FlatBufferBuilder builder, int damage)
		{
			builder.AddInt(4, damage, 0);
		}

		// Token: 0x0601C0C4 RID: 114884 RVA: 0x0089098D File Offset: 0x0088ED8D
		public static void AddHurtID(FlatBufferBuilder builder, int hurtID)
		{
			builder.AddInt(5, hurtID, 0);
		}

		// Token: 0x0601C0C5 RID: 114885 RVA: 0x00890998 File Offset: 0x0088ED98
		public static Offset<HurtDecisionBox> EndHurtDecisionBox(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<HurtDecisionBox>(value);
		}
	}
}
