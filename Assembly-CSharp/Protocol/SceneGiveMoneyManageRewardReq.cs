using System;

namespace Protocol
{
	// Token: 0x02000C19 RID: 3097
	[Protocol]
	public class SceneGiveMoneyManageRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008167 RID: 33127 RVA: 0x0016D7B4 File Offset: 0x0016BBB4
		public uint GetMsgID()
		{
			return 503303U;
		}

		// Token: 0x06008168 RID: 33128 RVA: 0x0016D7BB File Offset: 0x0016BBBB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008169 RID: 33129 RVA: 0x0016D7C3 File Offset: 0x0016BBC3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600816A RID: 33130 RVA: 0x0016D7CC File Offset: 0x0016BBCC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rewardId);
		}

		// Token: 0x0600816B RID: 33131 RVA: 0x0016D7DC File Offset: 0x0016BBDC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rewardId);
		}

		// Token: 0x0600816C RID: 33132 RVA: 0x0016D7EC File Offset: 0x0016BBEC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rewardId);
		}

		// Token: 0x0600816D RID: 33133 RVA: 0x0016D7FC File Offset: 0x0016BBFC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rewardId);
		}

		// Token: 0x0600816E RID: 33134 RVA: 0x0016D80C File Offset: 0x0016BC0C
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003DC8 RID: 15816
		public const uint MsgID = 503303U;

		// Token: 0x04003DC9 RID: 15817
		public uint Sequence;

		// Token: 0x04003DCA RID: 15818
		public byte rewardId;
	}
}
