using System;

namespace Protocol
{
	// Token: 0x02000752 RID: 1874
	[Protocol]
	public class SceneChampionObserveReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D0D RID: 23821 RVA: 0x00118108 File Offset: 0x00116508
		public uint GetMsgID()
		{
			return 509815U;
		}

		// Token: 0x06005D0E RID: 23822 RVA: 0x0011810F File Offset: 0x0011650F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D0F RID: 23823 RVA: 0x00118117 File Offset: 0x00116517
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D10 RID: 23824 RVA: 0x00118120 File Offset: 0x00116520
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceID);
		}

		// Token: 0x06005D11 RID: 23825 RVA: 0x00118130 File Offset: 0x00116530
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceID);
		}

		// Token: 0x06005D12 RID: 23826 RVA: 0x00118140 File Offset: 0x00116540
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceID);
		}

		// Token: 0x06005D13 RID: 23827 RVA: 0x00118150 File Offset: 0x00116550
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceID);
		}

		// Token: 0x06005D14 RID: 23828 RVA: 0x00118160 File Offset: 0x00116560
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002625 RID: 9765
		public const uint MsgID = 509815U;

		// Token: 0x04002626 RID: 9766
		public uint Sequence;

		// Token: 0x04002627 RID: 9767
		public ulong raceID;
	}
}
