using System;

namespace Protocol
{
	// Token: 0x02000773 RID: 1907
	[Protocol]
	public class SceneChampionGambleRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E1E RID: 24094 RVA: 0x0011A59D File Offset: 0x0011899D
		public uint GetMsgID()
		{
			return 509836U;
		}

		// Token: 0x06005E1F RID: 24095 RVA: 0x0011A5A4 File Offset: 0x001189A4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E20 RID: 24096 RVA: 0x0011A5AC File Offset: 0x001189AC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E21 RID: 24097 RVA: 0x0011A5B5 File Offset: 0x001189B5
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005E22 RID: 24098 RVA: 0x0011A5B7 File Offset: 0x001189B7
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005E23 RID: 24099 RVA: 0x0011A5B9 File Offset: 0x001189B9
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005E24 RID: 24100 RVA: 0x0011A5BB File Offset: 0x001189BB
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005E25 RID: 24101 RVA: 0x0011A5C0 File Offset: 0x001189C0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002698 RID: 9880
		public const uint MsgID = 509836U;

		// Token: 0x04002699 RID: 9881
		public uint Sequence;
	}
}
