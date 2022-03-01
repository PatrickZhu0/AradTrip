using System;

namespace Protocol
{
	// Token: 0x02000CBD RID: 3261
	[Protocol]
	public class WorldRelationAnnounceReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600865C RID: 34396 RVA: 0x00177800 File Offset: 0x00175C00
		public uint GetMsgID()
		{
			return 601776U;
		}

		// Token: 0x0600865D RID: 34397 RVA: 0x00177807 File Offset: 0x00175C07
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600865E RID: 34398 RVA: 0x0017780F File Offset: 0x00175C0F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600865F RID: 34399 RVA: 0x00177818 File Offset: 0x00175C18
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
		}

		// Token: 0x06008660 RID: 34400 RVA: 0x00177828 File Offset: 0x00175C28
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06008661 RID: 34401 RVA: 0x00177838 File Offset: 0x00175C38
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
		}

		// Token: 0x06008662 RID: 34402 RVA: 0x00177848 File Offset: 0x00175C48
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06008663 RID: 34403 RVA: 0x00177858 File Offset: 0x00175C58
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400404C RID: 16460
		public const uint MsgID = 601776U;

		// Token: 0x0400404D RID: 16461
		public uint Sequence;

		// Token: 0x0400404E RID: 16462
		public uint type;
	}
}
