using System;

namespace Protocol
{
	// Token: 0x020008A3 RID: 2211
	[Protocol]
	public class WorldGuildAcceptOrRefuseOrCancleMergerRequestReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006718 RID: 26392 RVA: 0x00130A6D File Offset: 0x0012EE6D
		public uint GetMsgID()
		{
			return 601985U;
		}

		// Token: 0x06006719 RID: 26393 RVA: 0x00130A74 File Offset: 0x0012EE74
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600671A RID: 26394 RVA: 0x00130A7C File Offset: 0x0012EE7C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600671B RID: 26395 RVA: 0x00130A85 File Offset: 0x0012EE85
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x0600671C RID: 26396 RVA: 0x00130AA3 File Offset: 0x0012EEA3
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x0600671D RID: 26397 RVA: 0x00130AC1 File Offset: 0x0012EEC1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x0600671E RID: 26398 RVA: 0x00130ADF File Offset: 0x0012EEDF
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x0600671F RID: 26399 RVA: 0x00130B00 File Offset: 0x0012EF00
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04002E15 RID: 11797
		public const uint MsgID = 601985U;

		// Token: 0x04002E16 RID: 11798
		public uint Sequence;

		// Token: 0x04002E17 RID: 11799
		public ulong guildId;

		// Token: 0x04002E18 RID: 11800
		public byte opType;
	}
}
