using System;

namespace Protocol
{
	// Token: 0x02000C3A RID: 3130
	[Protocol]
	public class WorldUseHireCodeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008269 RID: 33385 RVA: 0x0016F77C File Offset: 0x0016DB7C
		public uint GetMsgID()
		{
			return 601785U;
		}

		// Token: 0x0600826A RID: 33386 RVA: 0x0016F783 File Offset: 0x0016DB83
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600826B RID: 33387 RVA: 0x0016F78B File Offset: 0x0016DB8B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600826C RID: 33388 RVA: 0x0016F794 File Offset: 0x0016DB94
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x0600826D RID: 33389 RVA: 0x0016F7A4 File Offset: 0x0016DBA4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x0600826E RID: 33390 RVA: 0x0016F7B4 File Offset: 0x0016DBB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x0600826F RID: 33391 RVA: 0x0016F7C4 File Offset: 0x0016DBC4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x06008270 RID: 33392 RVA: 0x0016F7D4 File Offset: 0x0016DBD4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003E4B RID: 15947
		public const uint MsgID = 601785U;

		// Token: 0x04003E4C RID: 15948
		public uint Sequence;

		// Token: 0x04003E4D RID: 15949
		public uint errorCode;
	}
}
