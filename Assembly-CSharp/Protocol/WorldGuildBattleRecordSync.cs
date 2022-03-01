using System;

namespace Protocol
{
	// Token: 0x0200085B RID: 2139
	[Protocol]
	public class WorldGuildBattleRecordSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064A5 RID: 25765 RVA: 0x0012C010 File Offset: 0x0012A410
		public uint GetMsgID()
		{
			return 601950U;
		}

		// Token: 0x060064A6 RID: 25766 RVA: 0x0012C017 File Offset: 0x0012A417
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064A7 RID: 25767 RVA: 0x0012C01F File Offset: 0x0012A41F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064A8 RID: 25768 RVA: 0x0012C028 File Offset: 0x0012A428
		public void encode(byte[] buffer, ref int pos_)
		{
			this.record.encode(buffer, ref pos_);
		}

		// Token: 0x060064A9 RID: 25769 RVA: 0x0012C037 File Offset: 0x0012A437
		public void decode(byte[] buffer, ref int pos_)
		{
			this.record.decode(buffer, ref pos_);
		}

		// Token: 0x060064AA RID: 25770 RVA: 0x0012C046 File Offset: 0x0012A446
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.record.encode(buffer, ref pos_);
		}

		// Token: 0x060064AB RID: 25771 RVA: 0x0012C055 File Offset: 0x0012A455
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.record.decode(buffer, ref pos_);
		}

		// Token: 0x060064AC RID: 25772 RVA: 0x0012C064 File Offset: 0x0012A464
		public int getLen()
		{
			int num = 0;
			return num + this.record.getLen();
		}

		// Token: 0x04002D16 RID: 11542
		public const uint MsgID = 601950U;

		// Token: 0x04002D17 RID: 11543
		public uint Sequence;

		// Token: 0x04002D18 RID: 11544
		public GuildBattleRecord record = new GuildBattleRecord();
	}
}
