using System;

namespace Protocol
{
	// Token: 0x020008F7 RID: 2295
	[Protocol]
	public class SceneOneKeyPushStorage : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600691F RID: 26911 RVA: 0x001365D0 File Offset: 0x001349D0
		public uint GetMsgID()
		{
			return 500928U;
		}

		// Token: 0x06006920 RID: 26912 RVA: 0x001365D7 File Offset: 0x001349D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006921 RID: 26913 RVA: 0x001365DF File Offset: 0x001349DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006922 RID: 26914 RVA: 0x001365E8 File Offset: 0x001349E8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006923 RID: 26915 RVA: 0x001365EA File Offset: 0x001349EA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006924 RID: 26916 RVA: 0x001365EC File Offset: 0x001349EC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006925 RID: 26917 RVA: 0x001365EE File Offset: 0x001349EE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006926 RID: 26918 RVA: 0x001365F0 File Offset: 0x001349F0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002FAA RID: 12202
		public const uint MsgID = 500928U;

		// Token: 0x04002FAB RID: 12203
		public uint Sequence;
	}
}
