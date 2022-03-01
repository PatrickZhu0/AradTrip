using System;

namespace Protocol
{
	// Token: 0x02000C45 RID: 3141
	[Protocol]
	public class WorldQueryHireCoinReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082C6 RID: 33478 RVA: 0x00170278 File Offset: 0x0016E678
		public uint GetMsgID()
		{
			return 601795U;
		}

		// Token: 0x060082C7 RID: 33479 RVA: 0x0017027F File Offset: 0x0016E67F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082C8 RID: 33480 RVA: 0x00170287 File Offset: 0x0016E687
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082C9 RID: 33481 RVA: 0x00170290 File Offset: 0x0016E690
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060082CA RID: 33482 RVA: 0x00170292 File Offset: 0x0016E692
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060082CB RID: 33483 RVA: 0x00170294 File Offset: 0x0016E694
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060082CC RID: 33484 RVA: 0x00170296 File Offset: 0x0016E696
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060082CD RID: 33485 RVA: 0x00170298 File Offset: 0x0016E698
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003E6D RID: 15981
		public const uint MsgID = 601795U;

		// Token: 0x04003E6E RID: 15982
		public uint Sequence;
	}
}
