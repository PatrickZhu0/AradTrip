using System;

namespace Protocol
{
	// Token: 0x02000A69 RID: 2665
	[Protocol]
	public class WorldPremiumLeagueRewardPoolRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060074E0 RID: 29920 RVA: 0x00152758 File Offset: 0x00150B58
		public uint GetMsgID()
		{
			return 607703U;
		}

		// Token: 0x060074E1 RID: 29921 RVA: 0x0015275F File Offset: 0x00150B5F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060074E2 RID: 29922 RVA: 0x00152767 File Offset: 0x00150B67
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060074E3 RID: 29923 RVA: 0x00152770 File Offset: 0x00150B70
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.enrollPlayerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.money);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.rewards[i]);
			}
		}

		// Token: 0x060074E4 RID: 29924 RVA: 0x001527C4 File Offset: 0x00150BC4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enrollPlayerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.money);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewards[i]);
			}
		}

		// Token: 0x060074E5 RID: 29925 RVA: 0x0015281C File Offset: 0x00150C1C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.enrollPlayerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.money);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.rewards[i]);
			}
		}

		// Token: 0x060074E6 RID: 29926 RVA: 0x00152870 File Offset: 0x00150C70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enrollPlayerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.money);
			for (int i = 0; i < this.rewards.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.rewards[i]);
			}
		}

		// Token: 0x060074E7 RID: 29927 RVA: 0x001528C8 File Offset: 0x00150CC8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4 * this.rewards.Length;
		}

		// Token: 0x0400365E RID: 13918
		public const uint MsgID = 607703U;

		// Token: 0x0400365F RID: 13919
		public uint Sequence;

		// Token: 0x04003660 RID: 13920
		public uint enrollPlayerNum;

		// Token: 0x04003661 RID: 13921
		public uint money;

		// Token: 0x04003662 RID: 13922
		public uint[] rewards = new uint[5];
	}
}
