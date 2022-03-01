using System;

namespace Protocol
{
	// Token: 0x02000AC1 RID: 2753
	[Protocol]
	public class WorldExtensibleRoleFieldUnlockRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007765 RID: 30565 RVA: 0x00158F7C File Offset: 0x0015737C
		public uint GetMsgID()
		{
			return 608702U;
		}

		// Token: 0x06007766 RID: 30566 RVA: 0x00158F83 File Offset: 0x00157383
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007767 RID: 30567 RVA: 0x00158F8B File Offset: 0x0015738B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007768 RID: 30568 RVA: 0x00158F94 File Offset: 0x00157394
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
		}

		// Token: 0x06007769 RID: 30569 RVA: 0x00158FA4 File Offset: 0x001573A4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
		}

		// Token: 0x0600776A RID: 30570 RVA: 0x00158FB4 File Offset: 0x001573B4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
		}

		// Token: 0x0600776B RID: 30571 RVA: 0x00158FC4 File Offset: 0x001573C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
		}

		// Token: 0x0600776C RID: 30572 RVA: 0x00158FD4 File Offset: 0x001573D4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040037F4 RID: 14324
		public const uint MsgID = 608702U;

		// Token: 0x040037F5 RID: 14325
		public uint Sequence;

		// Token: 0x040037F6 RID: 14326
		public uint resCode;
	}
}
