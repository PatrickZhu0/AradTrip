using System;

namespace Protocol
{
	// Token: 0x02000669 RID: 1641
	[Protocol]
	public class Scene2V2SyncScoreWarInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060055FD RID: 22013 RVA: 0x001077F0 File Offset: 0x00105BF0
		public uint GetMsgID()
		{
			return 509601U;
		}

		// Token: 0x060055FE RID: 22014 RVA: 0x001077F7 File Offset: 0x00105BF7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060055FF RID: 22015 RVA: 0x001077FF File Offset: 0x00105BFF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005600 RID: 22016 RVA: 0x00107808 File Offset: 0x00105C08
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.statusEndTime);
		}

		// Token: 0x06005601 RID: 22017 RVA: 0x00107826 File Offset: 0x00105C26
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.statusEndTime);
		}

		// Token: 0x06005602 RID: 22018 RVA: 0x00107844 File Offset: 0x00105C44
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.statusEndTime);
		}

		// Token: 0x06005603 RID: 22019 RVA: 0x00107862 File Offset: 0x00105C62
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.statusEndTime);
		}

		// Token: 0x06005604 RID: 22020 RVA: 0x00107880 File Offset: 0x00105C80
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x04002201 RID: 8705
		public const uint MsgID = 509601U;

		// Token: 0x04002202 RID: 8706
		public uint Sequence;

		// Token: 0x04002203 RID: 8707
		public byte status;

		// Token: 0x04002204 RID: 8708
		public uint statusEndTime;
	}
}
