using System;

namespace Protocol
{
	// Token: 0x020006A8 RID: 1704
	[Protocol]
	public class WorldGetExpeditionRewardsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057FB RID: 22523 RVA: 0x0010BE1C File Offset: 0x0010A21C
		public uint GetMsgID()
		{
			return 608619U;
		}

		// Token: 0x060057FC RID: 22524 RVA: 0x0010BE23 File Offset: 0x0010A223
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057FD RID: 22525 RVA: 0x0010BE2B File Offset: 0x0010A22B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057FE RID: 22526 RVA: 0x0010BE34 File Offset: 0x0010A234
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
		}

		// Token: 0x060057FF RID: 22527 RVA: 0x0010BE44 File Offset: 0x0010A244
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x06005800 RID: 22528 RVA: 0x0010BE54 File Offset: 0x0010A254
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
		}

		// Token: 0x06005801 RID: 22529 RVA: 0x0010BE64 File Offset: 0x0010A264
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
		}

		// Token: 0x06005802 RID: 22530 RVA: 0x0010BE74 File Offset: 0x0010A274
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002304 RID: 8964
		public const uint MsgID = 608619U;

		// Token: 0x04002305 RID: 8965
		public uint Sequence;

		// Token: 0x04002306 RID: 8966
		public byte mapId;
	}
}
