using System;

namespace Protocol
{
	// Token: 0x020008DE RID: 2270
	[Protocol]
	public class SceneEnlargePackage : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600683E RID: 26686 RVA: 0x001352B0 File Offset: 0x001336B0
		public uint GetMsgID()
		{
			return 500908U;
		}

		// Token: 0x0600683F RID: 26687 RVA: 0x001352B7 File Offset: 0x001336B7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006840 RID: 26688 RVA: 0x001352BF File Offset: 0x001336BF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006841 RID: 26689 RVA: 0x001352C8 File Offset: 0x001336C8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006842 RID: 26690 RVA: 0x001352CA File Offset: 0x001336CA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006843 RID: 26691 RVA: 0x001352CC File Offset: 0x001336CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006844 RID: 26692 RVA: 0x001352CE File Offset: 0x001336CE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006845 RID: 26693 RVA: 0x001352D0 File Offset: 0x001336D0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002F52 RID: 12114
		public const uint MsgID = 500908U;

		// Token: 0x04002F53 RID: 12115
		public uint Sequence;
	}
}
