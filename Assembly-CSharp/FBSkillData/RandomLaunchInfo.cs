using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B21 RID: 19233
	public sealed class RandomLaunchInfo : Struct
	{
		// Token: 0x0601C115 RID: 114965 RVA: 0x008912C1 File Offset: 0x0088F6C1
		public RandomLaunchInfo __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700269B RID: 9883
		// (get) Token: 0x0601C116 RID: 114966 RVA: 0x008912D2 File Offset: 0x0088F6D2
		public int Num
		{
			get
			{
				return this.bb.GetInt(this.bb_pos);
			}
		}

		// Token: 0x1700269C RID: 9884
		// (get) Token: 0x0601C117 RID: 114967 RVA: 0x008912E5 File Offset: 0x0088F6E5
		public bool IsNumRand
		{
			get
			{
				return 0 != this.bb.Get(this.bb_pos + 4);
			}
		}

		// Token: 0x1700269D RID: 9885
		// (get) Token: 0x0601C118 RID: 114968 RVA: 0x00891300 File Offset: 0x0088F700
		public Vector2 NumRandRange
		{
			get
			{
				return this.GetNumRandRange(new Vector2());
			}
		}

		// Token: 0x0601C119 RID: 114969 RVA: 0x0089130D File Offset: 0x0088F70D
		public Vector2 GetNumRandRange(Vector2 obj)
		{
			return obj.__init(this.bb_pos + 8, this.bb);
		}

		// Token: 0x1700269E RID: 9886
		// (get) Token: 0x0601C11A RID: 114970 RVA: 0x00891323 File Offset: 0x0088F723
		public float Interval
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 16);
			}
		}

		// Token: 0x1700269F RID: 9887
		// (get) Token: 0x0601C11B RID: 114971 RVA: 0x00891339 File Offset: 0x0088F739
		public float RangeRadius
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 20);
			}
		}

		// Token: 0x170026A0 RID: 9888
		// (get) Token: 0x0601C11C RID: 114972 RVA: 0x0089134F File Offset: 0x0088F74F
		public bool IsFullScene
		{
			get
			{
				return 0 != this.bb.Get(this.bb_pos + 24);
			}
		}

		// Token: 0x0601C11D RID: 114973 RVA: 0x0089136C File Offset: 0x0088F76C
		public static Offset<RandomLaunchInfo> CreateRandomLaunchInfo(FlatBufferBuilder builder, int Num, bool IsNumRand, float numRandRange_X, float numRandRange_Y, float Interval, float RangeRadius, bool IsFullScene)
		{
			builder.Prep(4, 28);
			builder.Pad(3);
			builder.PutBool(IsFullScene);
			builder.PutFloat(RangeRadius);
			builder.PutFloat(Interval);
			builder.Prep(4, 8);
			builder.PutFloat(numRandRange_Y);
			builder.PutFloat(numRandRange_X);
			builder.Pad(3);
			builder.PutBool(IsNumRand);
			builder.PutInt(Num);
			return new Offset<RandomLaunchInfo>(builder.Offset);
		}
	}
}
