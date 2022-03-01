using System;

namespace Protocol
{
	// Token: 0x02000771 RID: 1905
	[Protocol]
	public class SceneChampionAllGambleInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E0C RID: 24076 RVA: 0x0011A3B1 File Offset: 0x001187B1
		public uint GetMsgID()
		{
			return 509834U;
		}

		// Token: 0x06005E0D RID: 24077 RVA: 0x0011A3B8 File Offset: 0x001187B8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E0E RID: 24078 RVA: 0x0011A3C0 File Offset: 0x001187C0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E0F RID: 24079 RVA: 0x0011A3C9 File Offset: 0x001187C9
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005E10 RID: 24080 RVA: 0x0011A3CB File Offset: 0x001187CB
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005E11 RID: 24081 RVA: 0x0011A3CD File Offset: 0x001187CD
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005E12 RID: 24082 RVA: 0x0011A3CF File Offset: 0x001187CF
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005E13 RID: 24083 RVA: 0x0011A3D4 File Offset: 0x001187D4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002693 RID: 9875
		public const uint MsgID = 509834U;

		// Token: 0x04002694 RID: 9876
		public uint Sequence;
	}
}
