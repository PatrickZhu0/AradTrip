using System;

namespace LibZip
{
	// Token: 0x020001A4 RID: 420
	public struct zip_stat
	{
		// Token: 0x0400098E RID: 2446
		public long valid;

		// Token: 0x0400098F RID: 2447
		public IntPtr name;

		// Token: 0x04000990 RID: 2448
		public long index;

		// Token: 0x04000991 RID: 2449
		public long size;

		// Token: 0x04000992 RID: 2450
		public long comp_size;

		// Token: 0x04000993 RID: 2451
		public int mtime;

		// Token: 0x04000994 RID: 2452
		public int crc;

		// Token: 0x04000995 RID: 2453
		public short comp_method;

		// Token: 0x04000996 RID: 2454
		public short encryption_method;

		// Token: 0x04000997 RID: 2455
		public int flags;
	}
}
