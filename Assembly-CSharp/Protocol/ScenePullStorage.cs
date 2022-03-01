using System;

namespace Protocol
{
	// Token: 0x020008E2 RID: 2274
	[Protocol]
	public class ScenePullStorage : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006862 RID: 26722 RVA: 0x001354BC File Offset: 0x001338BC
		public uint GetMsgID()
		{
			return 500910U;
		}

		// Token: 0x06006863 RID: 26723 RVA: 0x001354C3 File Offset: 0x001338C3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006864 RID: 26724 RVA: 0x001354CB File Offset: 0x001338CB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006865 RID: 26725 RVA: 0x001354D4 File Offset: 0x001338D4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006866 RID: 26726 RVA: 0x001354F2 File Offset: 0x001338F2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006867 RID: 26727 RVA: 0x00135510 File Offset: 0x00133910
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06006868 RID: 26728 RVA: 0x0013552E File Offset: 0x0013392E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06006869 RID: 26729 RVA: 0x0013554C File Offset: 0x0013394C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 2;
		}

		// Token: 0x04002F5F RID: 12127
		public const uint MsgID = 500910U;

		// Token: 0x04002F60 RID: 12128
		public uint Sequence;

		// Token: 0x04002F61 RID: 12129
		public ulong uid;

		// Token: 0x04002F62 RID: 12130
		public ushort num;
	}
}
