using System;

namespace Protocol
{
	// Token: 0x02000C18 RID: 3096
	[Protocol]
	public class SceneVipBuyItemRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600815E RID: 33118 RVA: 0x0016D740 File Offset: 0x0016BB40
		public uint GetMsgID()
		{
			return 503302U;
		}

		// Token: 0x0600815F RID: 33119 RVA: 0x0016D747 File Offset: 0x0016BB47
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008160 RID: 33120 RVA: 0x0016D74F File Offset: 0x0016BB4F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008161 RID: 33121 RVA: 0x0016D758 File Offset: 0x0016BB58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008162 RID: 33122 RVA: 0x0016D768 File Offset: 0x0016BB68
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008163 RID: 33123 RVA: 0x0016D778 File Offset: 0x0016BB78
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06008164 RID: 33124 RVA: 0x0016D788 File Offset: 0x0016BB88
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06008165 RID: 33125 RVA: 0x0016D798 File Offset: 0x0016BB98
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003DC5 RID: 15813
		public const uint MsgID = 503302U;

		// Token: 0x04003DC6 RID: 15814
		public uint Sequence;

		// Token: 0x04003DC7 RID: 15815
		public uint result;
	}
}
