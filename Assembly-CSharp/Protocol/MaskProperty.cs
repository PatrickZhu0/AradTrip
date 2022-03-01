using System;

namespace Protocol
{
	// Token: 0x02000647 RID: 1607
	public class MaskProperty
	{
		// Token: 0x060055B1 RID: 21937 RVA: 0x00105FD3 File Offset: 0x001043D3
		public MaskProperty(uint size)
		{
			this.maskSize = size;
			this.byteSize = (size - 1U) / 8U + 1U;
			this.flags = new byte[this.byteSize];
		}

		// Token: 0x060055B2 RID: 21938 RVA: 0x00106004 File Offset: 0x00104404
		public bool CheckMask(uint offset)
		{
			if (offset >= this.maskSize)
			{
				return false;
			}
			int num = (int)(offset / 8U);
			int num2 = (int)(offset % 8U);
			return ((int)this.flags[num] & 1 << num2) != 0;
		}

		// Token: 0x040020C4 RID: 8388
		public uint maskSize;

		// Token: 0x040020C5 RID: 8389
		public uint byteSize;

		// Token: 0x040020C6 RID: 8390
		public byte[] flags;
	}
}
