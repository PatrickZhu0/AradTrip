using System;

namespace Protocol
{
	// Token: 0x02000BEC RID: 3052
	[Protocol]
	public class TeamCopyAutoAgreeGoldReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FEA RID: 32746 RVA: 0x0016A6CC File Offset: 0x00168ACC
		public uint GetMsgID()
		{
			return 1100050U;
		}

		// Token: 0x06007FEB RID: 32747 RVA: 0x0016A6D3 File Offset: 0x00168AD3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FEC RID: 32748 RVA: 0x0016A6DB File Offset: 0x00168ADB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FED RID: 32749 RVA: 0x0016A6E4 File Offset: 0x00168AE4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAutoAgree);
		}

		// Token: 0x06007FEE RID: 32750 RVA: 0x0016A6F4 File Offset: 0x00168AF4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAutoAgree);
		}

		// Token: 0x06007FEF RID: 32751 RVA: 0x0016A704 File Offset: 0x00168B04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAutoAgree);
		}

		// Token: 0x06007FF0 RID: 32752 RVA: 0x0016A714 File Offset: 0x00168B14
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAutoAgree);
		}

		// Token: 0x06007FF1 RID: 32753 RVA: 0x0016A724 File Offset: 0x00168B24
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D0C RID: 15628
		public const uint MsgID = 1100050U;

		// Token: 0x04003D0D RID: 15629
		public uint Sequence;

		// Token: 0x04003D0E RID: 15630
		public uint isAutoAgree;
	}
}
