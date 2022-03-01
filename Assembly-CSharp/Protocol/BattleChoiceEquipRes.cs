using System;

namespace Protocol
{
	// Token: 0x0200072B RID: 1835
	[Protocol]
	public class BattleChoiceEquipRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BF3 RID: 23539 RVA: 0x00115D4C File Offset: 0x0011414C
		public uint GetMsgID()
		{
			return 508951U;
		}

		// Token: 0x06005BF4 RID: 23540 RVA: 0x00115D53 File Offset: 0x00114153
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BF5 RID: 23541 RVA: 0x00115D5B File Offset: 0x0011415B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BF6 RID: 23542 RVA: 0x00115D64 File Offset: 0x00114164
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipId);
		}

		// Token: 0x06005BF7 RID: 23543 RVA: 0x00115D82 File Offset: 0x00114182
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipId);
		}

		// Token: 0x06005BF8 RID: 23544 RVA: 0x00115DA0 File Offset: 0x001141A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipId);
		}

		// Token: 0x06005BF9 RID: 23545 RVA: 0x00115DBE File Offset: 0x001141BE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipId);
		}

		// Token: 0x06005BFA RID: 23546 RVA: 0x00115DDC File Offset: 0x001141DC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002574 RID: 9588
		public const uint MsgID = 508951U;

		// Token: 0x04002575 RID: 9589
		public uint Sequence;

		// Token: 0x04002576 RID: 9590
		public uint retCode;

		// Token: 0x04002577 RID: 9591
		public uint equipId;
	}
}
