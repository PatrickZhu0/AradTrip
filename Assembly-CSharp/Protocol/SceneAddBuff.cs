using System;

namespace Protocol
{
	// Token: 0x02000B5E RID: 2910
	[Protocol]
	public class SceneAddBuff : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007BF1 RID: 31729 RVA: 0x00162BF8 File Offset: 0x00160FF8
		public uint GetMsgID()
		{
			return 500711U;
		}

		// Token: 0x06007BF2 RID: 31730 RVA: 0x00162BFF File Offset: 0x00160FFF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007BF3 RID: 31731 RVA: 0x00162C07 File Offset: 0x00161007
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007BF4 RID: 31732 RVA: 0x00162C10 File Offset: 0x00161010
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
		}

		// Token: 0x06007BF5 RID: 31733 RVA: 0x00162C20 File Offset: 0x00161020
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
		}

		// Token: 0x06007BF6 RID: 31734 RVA: 0x00162C30 File Offset: 0x00161030
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
		}

		// Token: 0x06007BF7 RID: 31735 RVA: 0x00162C40 File Offset: 0x00161040
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
		}

		// Token: 0x06007BF8 RID: 31736 RVA: 0x00162C50 File Offset: 0x00161050
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003ABD RID: 15037
		public const uint MsgID = 500711U;

		// Token: 0x04003ABE RID: 15038
		public uint Sequence;

		// Token: 0x04003ABF RID: 15039
		public uint buffId;
	}
}
