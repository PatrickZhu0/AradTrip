using System;

namespace Protocol
{
	// Token: 0x02000BD7 RID: 3031
	[Protocol]
	public class TeamCopyStartChallengeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F30 RID: 32560 RVA: 0x00169273 File Offset: 0x00167673
		public uint GetMsgID()
		{
			return 1100027U;
		}

		// Token: 0x06007F31 RID: 32561 RVA: 0x0016927A File Offset: 0x0016767A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F32 RID: 32562 RVA: 0x00169282 File Offset: 0x00167682
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F33 RID: 32563 RVA: 0x0016928B File Offset: 0x0016768B
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldId);
		}

		// Token: 0x06007F34 RID: 32564 RVA: 0x0016929B File Offset: 0x0016769B
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldId);
		}

		// Token: 0x06007F35 RID: 32565 RVA: 0x001692AB File Offset: 0x001676AB
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldId);
		}

		// Token: 0x06007F36 RID: 32566 RVA: 0x001692BB File Offset: 0x001676BB
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldId);
		}

		// Token: 0x06007F37 RID: 32567 RVA: 0x001692CC File Offset: 0x001676CC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003CBE RID: 15550
		public const uint MsgID = 1100027U;

		// Token: 0x04003CBF RID: 15551
		public uint Sequence;

		// Token: 0x04003CC0 RID: 15552
		public uint fieldId;
	}
}
