using System;

namespace ManualMD5
{
	// Token: 0x02000151 RID: 337
	public sealed class Digest
	{
		// Token: 0x060009C2 RID: 2498 RVA: 0x0003346A File Offset: 0x0003186A
		public Digest()
		{
			this.A = 1732584193U;
			this.B = 4023233417U;
			this.C = 2562383102U;
			this.D = 271733878U;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x000334A0 File Offset: 0x000318A0
		public override string ToString()
		{
			return MD5Helper.ReverseByte(this.A).ToString("X8") + MD5Helper.ReverseByte(this.B).ToString("X8") + MD5Helper.ReverseByte(this.C).ToString("X8") + MD5Helper.ReverseByte(this.D).ToString("X8");
		}

		// Token: 0x0400074D RID: 1869
		public uint A;

		// Token: 0x0400074E RID: 1870
		public uint B;

		// Token: 0x0400074F RID: 1871
		public uint C;

		// Token: 0x04000750 RID: 1872
		public uint D;
	}
}
