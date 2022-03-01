using System;

namespace Protocol
{
	// Token: 0x02000930 RID: 2352
	[Protocol]
	public class SceneRenewTimeItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B1A RID: 27418 RVA: 0x00139A6C File Offset: 0x00137E6C
		public uint GetMsgID()
		{
			return 500966U;
		}

		// Token: 0x06006B1B RID: 27419 RVA: 0x00139A73 File Offset: 0x00137E73
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B1C RID: 27420 RVA: 0x00139A7B File Offset: 0x00137E7B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B1D RID: 27421 RVA: 0x00139A84 File Offset: 0x00137E84
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duration);
		}

		// Token: 0x06006B1E RID: 27422 RVA: 0x00139AA2 File Offset: 0x00137EA2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duration);
		}

		// Token: 0x06006B1F RID: 27423 RVA: 0x00139AC0 File Offset: 0x00137EC0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemUid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.duration);
		}

		// Token: 0x06006B20 RID: 27424 RVA: 0x00139ADE File Offset: 0x00137EDE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemUid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.duration);
		}

		// Token: 0x06006B21 RID: 27425 RVA: 0x00139AFC File Offset: 0x00137EFC
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x0400308F RID: 12431
		public const uint MsgID = 500966U;

		// Token: 0x04003090 RID: 12432
		public uint Sequence;

		// Token: 0x04003091 RID: 12433
		public ulong itemUid;

		// Token: 0x04003092 RID: 12434
		public uint duration;
	}
}
