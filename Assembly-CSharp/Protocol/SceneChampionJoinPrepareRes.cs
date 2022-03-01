using System;

namespace Protocol
{
	// Token: 0x0200074A RID: 1866
	[Protocol]
	public class SceneChampionJoinPrepareRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CC8 RID: 23752 RVA: 0x00117800 File Offset: 0x00115C00
		public uint GetMsgID()
		{
			return 509805U;
		}

		// Token: 0x06005CC9 RID: 23753 RVA: 0x00117807 File Offset: 0x00115C07
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CCA RID: 23754 RVA: 0x0011780F File Offset: 0x00115C0F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CCB RID: 23755 RVA: 0x00117818 File Offset: 0x00115C18
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005CCC RID: 23756 RVA: 0x00117828 File Offset: 0x00115C28
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005CCD RID: 23757 RVA: 0x00117838 File Offset: 0x00115C38
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x06005CCE RID: 23758 RVA: 0x00117848 File Offset: 0x00115C48
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06005CCF RID: 23759 RVA: 0x00117858 File Offset: 0x00115C58
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002604 RID: 9732
		public const uint MsgID = 509805U;

		// Token: 0x04002605 RID: 9733
		public uint Sequence;

		// Token: 0x04002606 RID: 9734
		public uint errorCode;
	}
}
