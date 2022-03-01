using System;

namespace Protocol
{
	// Token: 0x02000A74 RID: 2676
	[Protocol]
	public class WorldPremiumLeagueBattleInfoUpdate : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007543 RID: 30019 RVA: 0x001533B8 File Offset: 0x001517B8
		public uint GetMsgID()
		{
			return 607714U;
		}

		// Token: 0x06007544 RID: 30020 RVA: 0x001533BF File Offset: 0x001517BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007545 RID: 30021 RVA: 0x001533C7 File Offset: 0x001517C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007546 RID: 30022 RVA: 0x001533D0 File Offset: 0x001517D0
		public void encode(byte[] buffer, ref int pos_)
		{
			this.battle.encode(buffer, ref pos_);
		}

		// Token: 0x06007547 RID: 30023 RVA: 0x001533DF File Offset: 0x001517DF
		public void decode(byte[] buffer, ref int pos_)
		{
			this.battle.decode(buffer, ref pos_);
		}

		// Token: 0x06007548 RID: 30024 RVA: 0x001533EE File Offset: 0x001517EE
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.battle.encode(buffer, ref pos_);
		}

		// Token: 0x06007549 RID: 30025 RVA: 0x001533FD File Offset: 0x001517FD
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.battle.decode(buffer, ref pos_);
		}

		// Token: 0x0600754A RID: 30026 RVA: 0x0015340C File Offset: 0x0015180C
		public int getLen()
		{
			int num = 0;
			return num + this.battle.getLen();
		}

		// Token: 0x0400368A RID: 13962
		public const uint MsgID = 607714U;

		// Token: 0x0400368B RID: 13963
		public uint Sequence;

		// Token: 0x0400368C RID: 13964
		public CLPremiumLeagueBattle battle = new CLPremiumLeagueBattle();
	}
}
