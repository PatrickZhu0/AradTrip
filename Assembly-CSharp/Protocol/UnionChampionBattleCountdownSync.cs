using System;

namespace Protocol
{
	// Token: 0x02000763 RID: 1891
	[Protocol]
	public class UnionChampionBattleCountdownSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D9D RID: 23965 RVA: 0x00119046 File Offset: 0x00117446
		public uint GetMsgID()
		{
			return 1209810U;
		}

		// Token: 0x06005D9E RID: 23966 RVA: 0x0011904D File Offset: 0x0011744D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D9F RID: 23967 RVA: 0x00119055 File Offset: 0x00117455
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005DA0 RID: 23968 RVA: 0x0011905E File Offset: 0x0011745E
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
		}

		// Token: 0x06005DA1 RID: 23969 RVA: 0x0011906E File Offset: 0x0011746E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
		}

		// Token: 0x06005DA2 RID: 23970 RVA: 0x0011907E File Offset: 0x0011747E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
		}

		// Token: 0x06005DA3 RID: 23971 RVA: 0x0011908E File Offset: 0x0011748E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
		}

		// Token: 0x06005DA4 RID: 23972 RVA: 0x001190A0 File Offset: 0x001174A0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002661 RID: 9825
		public const uint MsgID = 1209810U;

		// Token: 0x04002662 RID: 9826
		public uint Sequence;

		// Token: 0x04002663 RID: 9827
		public uint endTime;
	}
}
