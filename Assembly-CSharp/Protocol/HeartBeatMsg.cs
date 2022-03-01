using System;

namespace Protocol
{
	// Token: 0x020006E7 RID: 1767
	[Protocol]
	public class HeartBeatMsg : IProtocolStream, IGetMsgID
	{
		// Token: 0x060059AD RID: 22957 RVA: 0x00110889 File Offset: 0x0010EC89
		public uint GetMsgID()
		{
			return 0U;
		}

		// Token: 0x060059AE RID: 22958 RVA: 0x0011088C File Offset: 0x0010EC8C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060059AF RID: 22959 RVA: 0x00110894 File Offset: 0x0010EC94
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060059B0 RID: 22960 RVA: 0x0011089D File Offset: 0x0010EC9D
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060059B1 RID: 22961 RVA: 0x0011089F File Offset: 0x0010EC9F
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060059B2 RID: 22962 RVA: 0x001108A1 File Offset: 0x0010ECA1
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060059B3 RID: 22963 RVA: 0x001108A3 File Offset: 0x0010ECA3
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060059B4 RID: 22964 RVA: 0x001108A8 File Offset: 0x0010ECA8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400243A RID: 9274
		public const uint MsgID = 0U;

		// Token: 0x0400243B RID: 9275
		public uint Sequence;
	}
}
