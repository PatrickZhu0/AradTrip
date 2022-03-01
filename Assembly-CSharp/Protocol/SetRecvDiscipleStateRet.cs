using System;

namespace Protocol
{
	// Token: 0x02000C9B RID: 3227
	[Protocol]
	public class SetRecvDiscipleStateRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600852A RID: 34090 RVA: 0x00175964 File Offset: 0x00173D64
		public uint GetMsgID()
		{
			return 601719U;
		}

		// Token: 0x0600852B RID: 34091 RVA: 0x0017596B File Offset: 0x00173D6B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600852C RID: 34092 RVA: 0x00175973 File Offset: 0x00173D73
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600852D RID: 34093 RVA: 0x0017597C File Offset: 0x00173D7C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
		}

		// Token: 0x0600852E RID: 34094 RVA: 0x0017599A File Offset: 0x00173D9A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
		}

		// Token: 0x0600852F RID: 34095 RVA: 0x001759B8 File Offset: 0x00173DB8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_int8(buffer, ref pos_, this.state);
		}

		// Token: 0x06008530 RID: 34096 RVA: 0x001759D6 File Offset: 0x00173DD6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.state);
		}

		// Token: 0x06008531 RID: 34097 RVA: 0x001759F4 File Offset: 0x00173DF4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003FCF RID: 16335
		public const uint MsgID = 601719U;

		// Token: 0x04003FD0 RID: 16336
		public uint Sequence;

		// Token: 0x04003FD1 RID: 16337
		public uint code;

		// Token: 0x04003FD2 RID: 16338
		public byte state;
	}
}
