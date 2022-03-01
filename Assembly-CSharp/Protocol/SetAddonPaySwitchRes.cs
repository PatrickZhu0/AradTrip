using System;

namespace Protocol
{
	// Token: 0x02000CA6 RID: 3238
	[Protocol]
	public class SetAddonPaySwitchRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600858D RID: 34189 RVA: 0x00176854 File Offset: 0x00174C54
		public uint GetMsgID()
		{
			return 501714U;
		}

		// Token: 0x0600858E RID: 34190 RVA: 0x0017685B File Offset: 0x00174C5B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600858F RID: 34191 RVA: 0x00176863 File Offset: 0x00174C63
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008590 RID: 34192 RVA: 0x0017686C File Offset: 0x00174C6C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isOn);
		}

		// Token: 0x06008591 RID: 34193 RVA: 0x0017687C File Offset: 0x00174C7C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isOn);
		}

		// Token: 0x06008592 RID: 34194 RVA: 0x0017688C File Offset: 0x00174C8C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isOn);
		}

		// Token: 0x06008593 RID: 34195 RVA: 0x0017689C File Offset: 0x00174C9C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isOn);
		}

		// Token: 0x06008594 RID: 34196 RVA: 0x001768AC File Offset: 0x00174CAC
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04004001 RID: 16385
		public const uint MsgID = 501714U;

		// Token: 0x04004002 RID: 16386
		public uint Sequence;

		// Token: 0x04004003 RID: 16387
		public byte isOn;
	}
}
