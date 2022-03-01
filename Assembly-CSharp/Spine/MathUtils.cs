using System;

namespace Spine
{
	// Token: 0x020049CA RID: 18890
	public static class MathUtils
	{
		// Token: 0x0601B327 RID: 111399 RVA: 0x0085B220 File Offset: 0x00859620
		static MathUtils()
		{
			for (int i = 0; i < 16384; i++)
			{
				MathUtils.sin[i] = (float)Math.Sin((double)(((float)i + 0.5f) / 16384f * 6.2831855f));
			}
			for (int j = 0; j < 360; j += 90)
			{
				MathUtils.sin[(int)((float)j * 45.511112f) & 16383] = (float)Math.Sin((double)((float)j * 0.017453292f));
			}
		}

		// Token: 0x0601B328 RID: 111400 RVA: 0x0085B2AF File Offset: 0x008596AF
		public static float Sin(float radians)
		{
			return MathUtils.sin[(int)(radians * 2607.5945f) & 16383];
		}

		// Token: 0x0601B329 RID: 111401 RVA: 0x0085B2C5 File Offset: 0x008596C5
		public static float Cos(float radians)
		{
			return MathUtils.sin[(int)((radians + 1.5707964f) * 2607.5945f) & 16383];
		}

		// Token: 0x0601B32A RID: 111402 RVA: 0x0085B2E1 File Offset: 0x008596E1
		public static float SinDeg(float degrees)
		{
			return MathUtils.sin[(int)(degrees * 45.511112f) & 16383];
		}

		// Token: 0x0601B32B RID: 111403 RVA: 0x0085B2F7 File Offset: 0x008596F7
		public static float CosDeg(float degrees)
		{
			return MathUtils.sin[(int)((degrees + 90f) * 45.511112f) & 16383];
		}

		// Token: 0x0601B32C RID: 111404 RVA: 0x0085B314 File Offset: 0x00859714
		public static float Atan2(float y, float x)
		{
			if (x == 0f)
			{
				if (y > 0f)
				{
					return 1.5707964f;
				}
				if (y == 0f)
				{
					return 0f;
				}
				return -1.5707964f;
			}
			else
			{
				float num = y / x;
				float num2;
				if (Math.Abs(num) >= 1f)
				{
					num2 = 1.5707964f - num / (num * num + 0.28f);
					return (y >= 0f) ? num2 : (num2 - 3.1415927f);
				}
				num2 = num / (1f + 0.28f * num * num);
				if (x < 0f)
				{
					return num2 + ((y >= 0f) ? 3.1415927f : -3.1415927f);
				}
				return num2;
			}
		}

		// Token: 0x0601B32D RID: 111405 RVA: 0x0085B3CE File Offset: 0x008597CE
		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x04012F4E RID: 77646
		public const float PI = 3.1415927f;

		// Token: 0x04012F4F RID: 77647
		public const float PI2 = 6.2831855f;

		// Token: 0x04012F50 RID: 77648
		public const float RadDeg = 57.295776f;

		// Token: 0x04012F51 RID: 77649
		public const float DegRad = 0.017453292f;

		// Token: 0x04012F52 RID: 77650
		private const int SIN_BITS = 14;

		// Token: 0x04012F53 RID: 77651
		private const int SIN_MASK = 16383;

		// Token: 0x04012F54 RID: 77652
		private const int SIN_COUNT = 16384;

		// Token: 0x04012F55 RID: 77653
		private const float RadFull = 6.2831855f;

		// Token: 0x04012F56 RID: 77654
		private const float DegFull = 360f;

		// Token: 0x04012F57 RID: 77655
		private const float RadToIndex = 2607.5945f;

		// Token: 0x04012F58 RID: 77656
		private const float DegToIndex = 45.511112f;

		// Token: 0x04012F59 RID: 77657
		private static float[] sin = new float[16384];
	}
}
