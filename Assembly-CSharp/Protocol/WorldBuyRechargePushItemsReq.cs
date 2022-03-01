using System;

namespace Protocol
{
	// Token: 0x0200097E RID: 2430
	[Protocol]
	public class WorldBuyRechargePushItemsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DC3 RID: 28099 RVA: 0x0013E7BD File Offset: 0x0013CBBD
		public uint GetMsgID()
		{
			return 602829U;
		}

		// Token: 0x06006DC4 RID: 28100 RVA: 0x0013E7C4 File Offset: 0x0013CBC4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006DC5 RID: 28101 RVA: 0x0013E7CC File Offset: 0x0013CBCC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006DC6 RID: 28102 RVA: 0x0013E7D5 File Offset: 0x0013CBD5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.pushId);
		}

		// Token: 0x06006DC7 RID: 28103 RVA: 0x0013E7E5 File Offset: 0x0013CBE5
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pushId);
		}

		// Token: 0x06006DC8 RID: 28104 RVA: 0x0013E7F5 File Offset: 0x0013CBF5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.pushId);
		}

		// Token: 0x06006DC9 RID: 28105 RVA: 0x0013E805 File Offset: 0x0013CC05
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pushId);
		}

		// Token: 0x06006DCA RID: 28106 RVA: 0x0013E818 File Offset: 0x0013CC18
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040031B5 RID: 12725
		public const uint MsgID = 602829U;

		// Token: 0x040031B6 RID: 12726
		public uint Sequence;

		// Token: 0x040031B7 RID: 12727
		public uint pushId;
	}
}
