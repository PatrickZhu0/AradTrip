using System;

namespace Protocol
{
	// Token: 0x02000B43 RID: 2883
	[Protocol]
	public class SceneSetPvpSkillConfigRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B22 RID: 31522 RVA: 0x00160B10 File Offset: 0x0015EF10
		public uint GetMsgID()
		{
			return 501222U;
		}

		// Token: 0x06007B23 RID: 31523 RVA: 0x00160B17 File Offset: 0x0015EF17
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B24 RID: 31524 RVA: 0x00160B1F File Offset: 0x0015EF1F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B25 RID: 31525 RVA: 0x00160B28 File Offset: 0x0015EF28
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007B26 RID: 31526 RVA: 0x00160B38 File Offset: 0x0015EF38
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007B27 RID: 31527 RVA: 0x00160B48 File Offset: 0x0015EF48
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007B28 RID: 31528 RVA: 0x00160B58 File Offset: 0x0015EF58
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007B29 RID: 31529 RVA: 0x00160B68 File Offset: 0x0015EF68
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003A55 RID: 14933
		public const uint MsgID = 501222U;

		// Token: 0x04003A56 RID: 14934
		public uint Sequence;

		// Token: 0x04003A57 RID: 14935
		public uint result;
	}
}
