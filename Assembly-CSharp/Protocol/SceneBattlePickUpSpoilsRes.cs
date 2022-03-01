using System;

namespace Protocol
{
	// Token: 0x02000706 RID: 1798
	[Protocol]
	public class SceneBattlePickUpSpoilsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AAF RID: 23215 RVA: 0x00113AF0 File Offset: 0x00111EF0
		public uint GetMsgID()
		{
			return 508912U;
		}

		// Token: 0x06005AB0 RID: 23216 RVA: 0x00113AF7 File Offset: 0x00111EF7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005AB1 RID: 23217 RVA: 0x00113AFF File Offset: 0x00111EFF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005AB2 RID: 23218 RVA: 0x00113B08 File Offset: 0x00111F08
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
		}

		// Token: 0x06005AB3 RID: 23219 RVA: 0x00113B26 File Offset: 0x00111F26
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
		}

		// Token: 0x06005AB4 RID: 23220 RVA: 0x00113B44 File Offset: 0x00111F44
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
		}

		// Token: 0x06005AB5 RID: 23221 RVA: 0x00113B62 File Offset: 0x00111F62
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
		}

		// Token: 0x06005AB6 RID: 23222 RVA: 0x00113B80 File Offset: 0x00111F80
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x040024E5 RID: 9445
		public const uint MsgID = 508912U;

		// Token: 0x040024E6 RID: 9446
		public uint Sequence;

		// Token: 0x040024E7 RID: 9447
		public uint retCode;

		// Token: 0x040024E8 RID: 9448
		public ulong itemGuid;
	}
}
