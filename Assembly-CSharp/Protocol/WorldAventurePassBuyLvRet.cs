using System;

namespace Protocol
{
	// Token: 0x02000C26 RID: 3110
	[Protocol]
	public class WorldAventurePassBuyLvRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081D6 RID: 33238 RVA: 0x0016E29C File Offset: 0x0016C69C
		public uint GetMsgID()
		{
			return 609506U;
		}

		// Token: 0x060081D7 RID: 33239 RVA: 0x0016E2A3 File Offset: 0x0016C6A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081D8 RID: 33240 RVA: 0x0016E2AB File Offset: 0x0016C6AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081D9 RID: 33241 RVA: 0x0016E2B4 File Offset: 0x0016C6B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
		}

		// Token: 0x060081DA RID: 33242 RVA: 0x0016E2C4 File Offset: 0x0016C6C4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
		}

		// Token: 0x060081DB RID: 33243 RVA: 0x0016E2D4 File Offset: 0x0016C6D4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
		}

		// Token: 0x060081DC RID: 33244 RVA: 0x0016E2E4 File Offset: 0x0016C6E4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
		}

		// Token: 0x060081DD RID: 33245 RVA: 0x0016E2F4 File Offset: 0x0016C6F4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003DF6 RID: 15862
		public const uint MsgID = 609506U;

		// Token: 0x04003DF7 RID: 15863
		public uint Sequence;

		// Token: 0x04003DF8 RID: 15864
		public uint lv;
	}
}
