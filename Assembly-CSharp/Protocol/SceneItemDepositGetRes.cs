using System;

namespace Protocol
{
	// Token: 0x02000984 RID: 2436
	[Protocol]
	public class SceneItemDepositGetRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DF6 RID: 28150 RVA: 0x0013EDDC File Offset: 0x0013D1DC
		public uint GetMsgID()
		{
			return 501053U;
		}

		// Token: 0x06006DF7 RID: 28151 RVA: 0x0013EDE3 File Offset: 0x0013D1E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006DF8 RID: 28152 RVA: 0x0013EDEB File Offset: 0x0013D1EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006DF9 RID: 28153 RVA: 0x0013EDF4 File Offset: 0x0013D1F4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006DFA RID: 28154 RVA: 0x0013EE04 File Offset: 0x0013D204
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006DFB RID: 28155 RVA: 0x0013EE14 File Offset: 0x0013D214
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006DFC RID: 28156 RVA: 0x0013EE24 File Offset: 0x0013D224
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006DFD RID: 28157 RVA: 0x0013EE34 File Offset: 0x0013D234
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040031C9 RID: 12745
		public const uint MsgID = 501053U;

		// Token: 0x040031CA RID: 12746
		public uint Sequence;

		// Token: 0x040031CB RID: 12747
		public uint retCode;
	}
}
