using System;

namespace Protocol
{
	// Token: 0x020006A9 RID: 1705
	[Protocol]
	public class WorldGetExpeditionRewardsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005804 RID: 22532 RVA: 0x0010BE90 File Offset: 0x0010A290
		public uint GetMsgID()
		{
			return 608620U;
		}

		// Token: 0x06005805 RID: 22533 RVA: 0x0010BE97 File Offset: 0x0010A297
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005806 RID: 22534 RVA: 0x0010BE9F File Offset: 0x0010A29F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005807 RID: 22535 RVA: 0x0010BEA8 File Offset: 0x0010A2A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionStatus);
		}

		// Token: 0x06005808 RID: 22536 RVA: 0x0010BED4 File Offset: 0x0010A2D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionStatus);
		}

		// Token: 0x06005809 RID: 22537 RVA: 0x0010BF00 File Offset: 0x0010A300
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_int8(buffer, ref pos_, this.expeditionStatus);
		}

		// Token: 0x0600580A RID: 22538 RVA: 0x0010BF2C File Offset: 0x0010A32C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.expeditionStatus);
		}

		// Token: 0x0600580B RID: 22539 RVA: 0x0010BF58 File Offset: 0x0010A358
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 1;
		}

		// Token: 0x04002307 RID: 8967
		public const uint MsgID = 608620U;

		// Token: 0x04002308 RID: 8968
		public uint Sequence;

		// Token: 0x04002309 RID: 8969
		public uint resCode;

		// Token: 0x0400230A RID: 8970
		public byte mapId;

		// Token: 0x0400230B RID: 8971
		public byte expeditionStatus;
	}
}
