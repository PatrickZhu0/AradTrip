using System;

namespace Protocol
{
	// Token: 0x02000680 RID: 1664
	[Protocol]
	public class SceneSyncPhaseGift : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056AB RID: 22187 RVA: 0x00109560 File Offset: 0x00107960
		public uint GetMsgID()
		{
			return 501141U;
		}

		// Token: 0x060056AC RID: 22188 RVA: 0x00109567 File Offset: 0x00107967
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056AD RID: 22189 RVA: 0x0010956F File Offset: 0x0010796F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056AE RID: 22190 RVA: 0x00109578 File Offset: 0x00107978
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.giftId);
			BaseDLL.encode_int8(buffer, ref pos_, this.canTake);
		}

		// Token: 0x060056AF RID: 22191 RVA: 0x00109596 File Offset: 0x00107996
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.canTake);
		}

		// Token: 0x060056B0 RID: 22192 RVA: 0x001095B4 File Offset: 0x001079B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.giftId);
			BaseDLL.encode_int8(buffer, ref pos_, this.canTake);
		}

		// Token: 0x060056B1 RID: 22193 RVA: 0x001095D2 File Offset: 0x001079D2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.canTake);
		}

		// Token: 0x060056B2 RID: 22194 RVA: 0x001095F0 File Offset: 0x001079F0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400226E RID: 8814
		public const uint MsgID = 501141U;

		// Token: 0x0400226F RID: 8815
		public uint Sequence;

		// Token: 0x04002270 RID: 8816
		public uint giftId;

		// Token: 0x04002271 RID: 8817
		public byte canTake;
	}
}
