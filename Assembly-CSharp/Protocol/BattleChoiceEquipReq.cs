using System;

namespace Protocol
{
	// Token: 0x0200072A RID: 1834
	[Protocol]
	public class BattleChoiceEquipReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BEA RID: 23530 RVA: 0x00115CD7 File Offset: 0x001140D7
		public uint GetMsgID()
		{
			return 508950U;
		}

		// Token: 0x06005BEB RID: 23531 RVA: 0x00115CDE File Offset: 0x001140DE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BEC RID: 23532 RVA: 0x00115CE6 File Offset: 0x001140E6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BED RID: 23533 RVA: 0x00115CEF File Offset: 0x001140EF
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipId);
		}

		// Token: 0x06005BEE RID: 23534 RVA: 0x00115CFF File Offset: 0x001140FF
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipId);
		}

		// Token: 0x06005BEF RID: 23535 RVA: 0x00115D0F File Offset: 0x0011410F
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipId);
		}

		// Token: 0x06005BF0 RID: 23536 RVA: 0x00115D1F File Offset: 0x0011411F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipId);
		}

		// Token: 0x06005BF1 RID: 23537 RVA: 0x00115D30 File Offset: 0x00114130
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002571 RID: 9585
		public const uint MsgID = 508950U;

		// Token: 0x04002572 RID: 9586
		public uint Sequence;

		// Token: 0x04002573 RID: 9587
		public uint equipId;
	}
}
