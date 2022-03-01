using System;

namespace Protocol
{
	// Token: 0x02000716 RID: 1814
	[Protocol]
	public class SceneBattleNpcTradeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B39 RID: 23353 RVA: 0x00114C7F File Offset: 0x0011307F
		public uint GetMsgID()
		{
			return 508931U;
		}

		// Token: 0x06005B3A RID: 23354 RVA: 0x00114C86 File Offset: 0x00113086
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B3B RID: 23355 RVA: 0x00114C8E File Offset: 0x0011308E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B3C RID: 23356 RVA: 0x00114C97 File Offset: 0x00113097
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcId);
		}

		// Token: 0x06005B3D RID: 23357 RVA: 0x00114CB5 File Offset: 0x001130B5
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcId);
		}

		// Token: 0x06005B3E RID: 23358 RVA: 0x00114CD3 File Offset: 0x001130D3
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcId);
		}

		// Token: 0x06005B3F RID: 23359 RVA: 0x00114CF1 File Offset: 0x001130F1
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcId);
		}

		// Token: 0x06005B40 RID: 23360 RVA: 0x00114D10 File Offset: 0x00113110
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400252A RID: 9514
		public const uint MsgID = 508931U;

		// Token: 0x0400252B RID: 9515
		public uint Sequence;

		// Token: 0x0400252C RID: 9516
		public uint retCode;

		// Token: 0x0400252D RID: 9517
		public uint npcId;
	}
}
