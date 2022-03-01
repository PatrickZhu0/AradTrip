using System;

namespace Protocol
{
	// Token: 0x02000C63 RID: 3171
	[Protocol]
	public class SceneRefreshCycleTask : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008386 RID: 33670 RVA: 0x001719BC File Offset: 0x0016FDBC
		public uint GetMsgID()
		{
			return 501135U;
		}

		// Token: 0x06008387 RID: 33671 RVA: 0x001719C3 File Offset: 0x0016FDC3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008388 RID: 33672 RVA: 0x001719CB File Offset: 0x0016FDCB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008389 RID: 33673 RVA: 0x001719D4 File Offset: 0x0016FDD4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600838A RID: 33674 RVA: 0x001719D6 File Offset: 0x0016FDD6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600838B RID: 33675 RVA: 0x001719D8 File Offset: 0x0016FDD8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600838C RID: 33676 RVA: 0x001719DA File Offset: 0x0016FDDA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600838D RID: 33677 RVA: 0x001719DC File Offset: 0x0016FDDC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003EE3 RID: 16099
		public const uint MsgID = 501135U;

		// Token: 0x04003EE4 RID: 16100
		public uint Sequence;
	}
}
