using System;

namespace behaviac
{
	// Token: 0x0200482D RID: 18477
	internal class RandomGenerator
	{
		// Token: 0x0601A8D2 RID: 108754 RVA: 0x00835BD7 File Offset: 0x00833FD7
		protected RandomGenerator(uint seed)
		{
			this.m_seed = seed;
		}

		// Token: 0x0601A8D3 RID: 108755 RVA: 0x00835BE6 File Offset: 0x00833FE6
		public static RandomGenerator GetInstance()
		{
			if (RandomGenerator.Instance == null)
			{
				RandomGenerator.Instance = new RandomGenerator(0U);
			}
			return RandomGenerator.Instance;
		}

		// Token: 0x0601A8D4 RID: 108756 RVA: 0x00835C04 File Offset: 0x00834004
		public float GetRandom()
		{
			this.m_seed = 214013U * this.m_seed + 2531011U;
			return this.m_seed * 2.3283064E-10f;
		}

		// Token: 0x0601A8D5 RID: 108757 RVA: 0x00835C3C File Offset: 0x0083403C
		public float InRange(float low, float high)
		{
			float random = this.GetRandom();
			return random * (high - low) + low;
		}

		// Token: 0x0601A8D6 RID: 108758 RVA: 0x00835C59 File Offset: 0x00834059
		public void SetSeed(uint seed)
		{
			this.m_seed = seed;
		}

		// Token: 0x04012948 RID: 76104
		private static RandomGenerator Instance;

		// Token: 0x04012949 RID: 76105
		private uint m_seed;
	}
}
