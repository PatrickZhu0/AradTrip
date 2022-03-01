using System;

namespace ManualMD5
{
	// Token: 0x02000152 RID: 338
	public sealed class MD5Helper
	{
		// Token: 0x060009C4 RID: 2500 RVA: 0x00033515 File Offset: 0x00031915
		private MD5Helper()
		{
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0003351D File Offset: 0x0003191D
		public static uint RotateLeft(uint uiNumber, ushort shift)
		{
			return uiNumber >> (int)(32 - shift) | uiNumber << (int)shift;
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0003352F File Offset: 0x0003192F
		public static uint ReverseByte(uint uiNumber)
		{
			return (uiNumber & 255U) << 24 | uiNumber >> 24 | (uiNumber & 16711680U) >> 8 | (uiNumber & 65280U) << 8;
		}
	}
}
