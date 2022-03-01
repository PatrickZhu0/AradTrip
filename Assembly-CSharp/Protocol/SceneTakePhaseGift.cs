using System;

namespace Protocol
{
	// Token: 0x02000681 RID: 1665
	[Protocol]
	public class SceneTakePhaseGift : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056B4 RID: 22196 RVA: 0x00109610 File Offset: 0x00107A10
		public uint GetMsgID()
		{
			return 501142U;
		}

		// Token: 0x060056B5 RID: 22197 RVA: 0x00109617 File Offset: 0x00107A17
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056B6 RID: 22198 RVA: 0x0010961F File Offset: 0x00107A1F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056B7 RID: 22199 RVA: 0x00109628 File Offset: 0x00107A28
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.giftId);
		}

		// Token: 0x060056B8 RID: 22200 RVA: 0x00109638 File Offset: 0x00107A38
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftId);
		}

		// Token: 0x060056B9 RID: 22201 RVA: 0x00109648 File Offset: 0x00107A48
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.giftId);
		}

		// Token: 0x060056BA RID: 22202 RVA: 0x00109658 File Offset: 0x00107A58
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftId);
		}

		// Token: 0x060056BB RID: 22203 RVA: 0x00109668 File Offset: 0x00107A68
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002272 RID: 8818
		public const uint MsgID = 501142U;

		// Token: 0x04002273 RID: 8819
		public uint Sequence;

		// Token: 0x04002274 RID: 8820
		public uint giftId;
	}
}
