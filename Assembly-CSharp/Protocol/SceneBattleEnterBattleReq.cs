using System;

namespace Protocol
{
	// Token: 0x02000711 RID: 1809
	[Protocol]
	public class SceneBattleEnterBattleReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B0F RID: 23311 RVA: 0x00114688 File Offset: 0x00112A88
		public uint GetMsgID()
		{
			return 508925U;
		}

		// Token: 0x06005B10 RID: 23312 RVA: 0x0011468F File Offset: 0x00112A8F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B11 RID: 23313 RVA: 0x00114697 File Offset: 0x00112A97
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B12 RID: 23314 RVA: 0x001146A0 File Offset: 0x00112AA0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
		}

		// Token: 0x06005B13 RID: 23315 RVA: 0x001146B0 File Offset: 0x00112AB0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
		}

		// Token: 0x06005B14 RID: 23316 RVA: 0x001146C0 File Offset: 0x00112AC0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
		}

		// Token: 0x06005B15 RID: 23317 RVA: 0x001146D0 File Offset: 0x00112AD0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
		}

		// Token: 0x06005B16 RID: 23318 RVA: 0x001146E0 File Offset: 0x00112AE0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002517 RID: 9495
		public const uint MsgID = 508925U;

		// Token: 0x04002518 RID: 9496
		public uint Sequence;

		// Token: 0x04002519 RID: 9497
		public uint battleID;
	}
}
