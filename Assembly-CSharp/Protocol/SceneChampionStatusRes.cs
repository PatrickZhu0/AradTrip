using System;

namespace Protocol
{
	// Token: 0x02000756 RID: 1878
	[Protocol]
	public class SceneChampionStatusRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D2E RID: 23854 RVA: 0x001184B3 File Offset: 0x001168B3
		public uint GetMsgID()
		{
			return 509818U;
		}

		// Token: 0x06005D2F RID: 23855 RVA: 0x001184BA File Offset: 0x001168BA
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D30 RID: 23856 RVA: 0x001184C2 File Offset: 0x001168C2
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D31 RID: 23857 RVA: 0x001184CB File Offset: 0x001168CB
		public void encode(byte[] buffer, ref int pos_)
		{
			this.status.encode(buffer, ref pos_);
		}

		// Token: 0x06005D32 RID: 23858 RVA: 0x001184DA File Offset: 0x001168DA
		public void decode(byte[] buffer, ref int pos_)
		{
			this.status.decode(buffer, ref pos_);
		}

		// Token: 0x06005D33 RID: 23859 RVA: 0x001184E9 File Offset: 0x001168E9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.status.encode(buffer, ref pos_);
		}

		// Token: 0x06005D34 RID: 23860 RVA: 0x001184F8 File Offset: 0x001168F8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.status.decode(buffer, ref pos_);
		}

		// Token: 0x06005D35 RID: 23861 RVA: 0x00118508 File Offset: 0x00116908
		public int getLen()
		{
			int num = 0;
			return num + this.status.getLen();
		}

		// Token: 0x04002636 RID: 9782
		public const uint MsgID = 509818U;

		// Token: 0x04002637 RID: 9783
		public uint Sequence;

		// Token: 0x04002638 RID: 9784
		public ChampionStatusInfo status = new ChampionStatusInfo();
	}
}
