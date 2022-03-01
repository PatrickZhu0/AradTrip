using System;

namespace Protocol
{
	// Token: 0x020008D9 RID: 2265
	[Protocol]
	public class SceneNotifyDeleteItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006811 RID: 26641 RVA: 0x00134F7C File Offset: 0x0013337C
		public uint GetMsgID()
		{
			return 500907U;
		}

		// Token: 0x06006812 RID: 26642 RVA: 0x00134F83 File Offset: 0x00133383
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006813 RID: 26643 RVA: 0x00134F8B File Offset: 0x0013338B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006814 RID: 26644 RVA: 0x00134F94 File Offset: 0x00133394
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06006815 RID: 26645 RVA: 0x00134FA4 File Offset: 0x001333A4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06006816 RID: 26646 RVA: 0x00134FB4 File Offset: 0x001333B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
		}

		// Token: 0x06006817 RID: 26647 RVA: 0x00134FC4 File Offset: 0x001333C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
		}

		// Token: 0x06006818 RID: 26648 RVA: 0x00134FD4 File Offset: 0x001333D4
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002F3F RID: 12095
		public const uint MsgID = 500907U;

		// Token: 0x04002F40 RID: 12096
		public uint Sequence;

		// Token: 0x04002F41 RID: 12097
		public ulong uid;
	}
}
