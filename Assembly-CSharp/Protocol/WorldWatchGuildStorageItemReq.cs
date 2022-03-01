using System;

namespace Protocol
{
	// Token: 0x02000875 RID: 2165
	[Protocol]
	public class WorldWatchGuildStorageItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600658F RID: 25999 RVA: 0x0012DFC0 File Offset: 0x0012C3C0
		public uint GetMsgID()
		{
			return 601976U;
		}

		// Token: 0x06006590 RID: 26000 RVA: 0x0012DFC7 File Offset: 0x0012C3C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006591 RID: 26001 RVA: 0x0012DFCF File Offset: 0x0012C3CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006592 RID: 26002 RVA: 0x0012DFD8 File Offset: 0x0012C3D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06006593 RID: 26003 RVA: 0x0012DFE8 File Offset: 0x0012C3E8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06006594 RID: 26004 RVA: 0x0012DFF8 File Offset: 0x0012C3F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06006595 RID: 26005 RVA: 0x0012E008 File Offset: 0x0012C408
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06006596 RID: 26006 RVA: 0x0012E018 File Offset: 0x0012C418
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002D7E RID: 11646
		public const uint MsgID = 601976U;

		// Token: 0x04002D7F RID: 11647
		public uint Sequence;

		// Token: 0x04002D80 RID: 11648
		public ulong uid;
	}
}
