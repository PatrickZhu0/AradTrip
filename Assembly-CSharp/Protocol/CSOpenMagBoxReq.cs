using System;

namespace Protocol
{
	// Token: 0x02000934 RID: 2356
	[Protocol]
	public class CSOpenMagBoxReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B3B RID: 27451 RVA: 0x00139DD9 File Offset: 0x001381D9
		public uint GetMsgID()
		{
			return 500969U;
		}

		// Token: 0x06006B3C RID: 27452 RVA: 0x00139DE0 File Offset: 0x001381E0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B3D RID: 27453 RVA: 0x00139DE8 File Offset: 0x001381E8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B3E RID: 27454 RVA: 0x00139DF1 File Offset: 0x001381F1
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.isBatch);
		}

		// Token: 0x06006B3F RID: 27455 RVA: 0x00139E0F File Offset: 0x0013820F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isBatch);
		}

		// Token: 0x06006B40 RID: 27456 RVA: 0x00139E2D File Offset: 0x0013822D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_int8(buffer, ref pos_, this.isBatch);
		}

		// Token: 0x06006B41 RID: 27457 RVA: 0x00139E4B File Offset: 0x0013824B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isBatch);
		}

		// Token: 0x06006B42 RID: 27458 RVA: 0x00139E6C File Offset: 0x0013826C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x0400309B RID: 12443
		public const uint MsgID = 500969U;

		// Token: 0x0400309C RID: 12444
		public uint Sequence;

		// Token: 0x0400309D RID: 12445
		public ulong itemUid;

		// Token: 0x0400309E RID: 12446
		public byte isBatch;
	}
}
