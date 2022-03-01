using System;

namespace Protocol
{
	// Token: 0x02000C69 RID: 3177
	[Protocol]
	public class SceneAchievementScoreRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083BC RID: 33724 RVA: 0x00171D8A File Offset: 0x0017018A
		public uint GetMsgID()
		{
			return 501156U;
		}

		// Token: 0x060083BD RID: 33725 RVA: 0x00171D91 File Offset: 0x00170191
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083BE RID: 33726 RVA: 0x00171D99 File Offset: 0x00170199
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083BF RID: 33727 RVA: 0x00171DA2 File Offset: 0x001701A2
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.rewardId);
		}

		// Token: 0x060083C0 RID: 33728 RVA: 0x00171DB2 File Offset: 0x001701B2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewardId);
		}

		// Token: 0x060083C1 RID: 33729 RVA: 0x00171DC2 File Offset: 0x001701C2
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.rewardId);
		}

		// Token: 0x060083C2 RID: 33730 RVA: 0x00171DD2 File Offset: 0x001701D2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewardId);
		}

		// Token: 0x060083C3 RID: 33731 RVA: 0x00171DE4 File Offset: 0x001701E4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003EF4 RID: 16116
		public const uint MsgID = 501156U;

		// Token: 0x04003EF5 RID: 16117
		public uint Sequence;

		// Token: 0x04003EF6 RID: 16118
		public uint rewardId;
	}
}
