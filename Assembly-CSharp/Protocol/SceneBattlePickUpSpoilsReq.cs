using System;

namespace Protocol
{
	// Token: 0x02000705 RID: 1797
	[Protocol]
	public class SceneBattlePickUpSpoilsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AA6 RID: 23206 RVA: 0x00113A04 File Offset: 0x00111E04
		public uint GetMsgID()
		{
			return 508911U;
		}

		// Token: 0x06005AA7 RID: 23207 RVA: 0x00113A0B File Offset: 0x00111E0B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005AA8 RID: 23208 RVA: 0x00113A13 File Offset: 0x00111E13
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005AA9 RID: 23209 RVA: 0x00113A1C File Offset: 0x00111E1C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
		}

		// Token: 0x06005AAA RID: 23210 RVA: 0x00113A48 File Offset: 0x00111E48
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
		}

		// Token: 0x06005AAB RID: 23211 RVA: 0x00113A74 File Offset: 0x00111E74
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
		}

		// Token: 0x06005AAC RID: 23212 RVA: 0x00113AA0 File Offset: 0x00111EA0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
		}

		// Token: 0x06005AAD RID: 23213 RVA: 0x00113ACC File Offset: 0x00111ECC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			return num + 8;
		}

		// Token: 0x040024E0 RID: 9440
		public const uint MsgID = 508911U;

		// Token: 0x040024E1 RID: 9441
		public uint Sequence;

		// Token: 0x040024E2 RID: 9442
		public uint battleID;

		// Token: 0x040024E3 RID: 9443
		public ulong playerID;

		// Token: 0x040024E4 RID: 9444
		public ulong itemGuid;
	}
}
