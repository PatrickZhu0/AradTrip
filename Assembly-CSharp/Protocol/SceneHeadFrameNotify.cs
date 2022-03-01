using System;

namespace Protocol
{
	// Token: 0x020008AB RID: 2219
	[Protocol]
	public class SceneHeadFrameNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600675D RID: 26461 RVA: 0x00130FF7 File Offset: 0x0012F3F7
		public uint GetMsgID()
		{
			return 509105U;
		}

		// Token: 0x0600675E RID: 26462 RVA: 0x00130FFE File Offset: 0x0012F3FE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600675F RID: 26463 RVA: 0x00131006 File Offset: 0x0012F406
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006760 RID: 26464 RVA: 0x0013100F File Offset: 0x0012F40F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isGet);
			this.headFrame.encode(buffer, ref pos_);
		}

		// Token: 0x06006761 RID: 26465 RVA: 0x0013102C File Offset: 0x0012F42C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isGet);
			this.headFrame.decode(buffer, ref pos_);
		}

		// Token: 0x06006762 RID: 26466 RVA: 0x00131049 File Offset: 0x0012F449
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isGet);
			this.headFrame.encode(buffer, ref pos_);
		}

		// Token: 0x06006763 RID: 26467 RVA: 0x00131066 File Offset: 0x0012F466
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isGet);
			this.headFrame.decode(buffer, ref pos_);
		}

		// Token: 0x06006764 RID: 26468 RVA: 0x00131084 File Offset: 0x0012F484
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.headFrame.getLen();
		}

		// Token: 0x04002E2E RID: 11822
		public const uint MsgID = 509105U;

		// Token: 0x04002E2F RID: 11823
		public uint Sequence;

		// Token: 0x04002E30 RID: 11824
		public uint isGet;

		// Token: 0x04002E31 RID: 11825
		public HeadFrame headFrame = new HeadFrame();
	}
}
