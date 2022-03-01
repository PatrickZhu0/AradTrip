using System;

namespace Protocol
{
	// Token: 0x02000C17 RID: 3095
	[Protocol]
	public class SceneVipBuyItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008155 RID: 33109 RVA: 0x0016D6CC File Offset: 0x0016BACC
		public uint GetMsgID()
		{
			return 503301U;
		}

		// Token: 0x06008156 RID: 33110 RVA: 0x0016D6D3 File Offset: 0x0016BAD3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008157 RID: 33111 RVA: 0x0016D6DB File Offset: 0x0016BADB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008158 RID: 33112 RVA: 0x0016D6E4 File Offset: 0x0016BAE4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
		}

		// Token: 0x06008159 RID: 33113 RVA: 0x0016D6F4 File Offset: 0x0016BAF4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
		}

		// Token: 0x0600815A RID: 33114 RVA: 0x0016D704 File Offset: 0x0016BB04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
		}

		// Token: 0x0600815B RID: 33115 RVA: 0x0016D714 File Offset: 0x0016BB14
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
		}

		// Token: 0x0600815C RID: 33116 RVA: 0x0016D724 File Offset: 0x0016BB24
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003DC2 RID: 15810
		public const uint MsgID = 503301U;

		// Token: 0x04003DC3 RID: 15811
		public uint Sequence;

		// Token: 0x04003DC4 RID: 15812
		public byte vipLevel;
	}
}
