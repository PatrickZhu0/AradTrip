using System;

namespace Protocol
{
	// Token: 0x020008E4 RID: 2276
	[Protocol]
	public class SceneEnlargeStorage : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006874 RID: 26740 RVA: 0x001355E0 File Offset: 0x001339E0
		public uint GetMsgID()
		{
			return 500913U;
		}

		// Token: 0x06006875 RID: 26741 RVA: 0x001355E7 File Offset: 0x001339E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006876 RID: 26742 RVA: 0x001355EF File Offset: 0x001339EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006877 RID: 26743 RVA: 0x001355F8 File Offset: 0x001339F8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006878 RID: 26744 RVA: 0x001355FA File Offset: 0x001339FA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006879 RID: 26745 RVA: 0x001355FC File Offset: 0x001339FC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600687A RID: 26746 RVA: 0x001355FE File Offset: 0x001339FE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600687B RID: 26747 RVA: 0x00135600 File Offset: 0x00133A00
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002F66 RID: 12134
		public const uint MsgID = 500913U;

		// Token: 0x04002F67 RID: 12135
		public uint Sequence;
	}
}
