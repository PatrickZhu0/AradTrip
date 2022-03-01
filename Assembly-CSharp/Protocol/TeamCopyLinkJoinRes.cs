using System;

namespace Protocol
{
	// Token: 0x02000BFA RID: 3066
	[Protocol]
	public class TeamCopyLinkJoinRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008065 RID: 32869 RVA: 0x0016B8E0 File Offset: 0x00169CE0
		public uint GetMsgID()
		{
			return 1100063U;
		}

		// Token: 0x06008066 RID: 32870 RVA: 0x0016B8E7 File Offset: 0x00169CE7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008067 RID: 32871 RVA: 0x0016B8EF File Offset: 0x00169CEF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008068 RID: 32872 RVA: 0x0016B8F8 File Offset: 0x00169CF8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06008069 RID: 32873 RVA: 0x0016B908 File Offset: 0x00169D08
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x0600806A RID: 32874 RVA: 0x0016B918 File Offset: 0x00169D18
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x0600806B RID: 32875 RVA: 0x0016B928 File Offset: 0x00169D28
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x0600806C RID: 32876 RVA: 0x0016B938 File Offset: 0x00169D38
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D4D RID: 15693
		public const uint MsgID = 1100063U;

		// Token: 0x04003D4E RID: 15694
		public uint Sequence;

		// Token: 0x04003D4F RID: 15695
		public uint retCode;
	}
}
