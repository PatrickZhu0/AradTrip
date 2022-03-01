using System;

namespace Protocol
{
	// Token: 0x02000954 RID: 2388
	[Protocol]
	public class SceneItemLockReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C58 RID: 27736 RVA: 0x0013BD04 File Offset: 0x0013A104
		public uint GetMsgID()
		{
			return 501025U;
		}

		// Token: 0x06006C59 RID: 27737 RVA: 0x0013BD0B File Offset: 0x0013A10B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C5A RID: 27738 RVA: 0x0013BD13 File Offset: 0x0013A113
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C5B RID: 27739 RVA: 0x0013BD1C File Offset: 0x0013A11C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x06006C5C RID: 27740 RVA: 0x0013BD3A File Offset: 0x0013A13A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x06006C5D RID: 27741 RVA: 0x0013BD58 File Offset: 0x0013A158
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
		}

		// Token: 0x06006C5E RID: 27742 RVA: 0x0013BD76 File Offset: 0x0013A176
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
		}

		// Token: 0x06006C5F RID: 27743 RVA: 0x0013BD94 File Offset: 0x0013A194
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04003107 RID: 12551
		public const uint MsgID = 501025U;

		// Token: 0x04003108 RID: 12552
		public uint Sequence;

		// Token: 0x04003109 RID: 12553
		public uint opType;

		// Token: 0x0400310A RID: 12554
		public ulong itemUid;
	}
}
