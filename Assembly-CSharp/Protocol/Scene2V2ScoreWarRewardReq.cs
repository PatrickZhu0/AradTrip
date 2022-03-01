using System;

namespace Protocol
{
	// Token: 0x02000667 RID: 1639
	[Protocol]
	public class Scene2V2ScoreWarRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060055EB RID: 21995 RVA: 0x00107707 File Offset: 0x00105B07
		public uint GetMsgID()
		{
			return 509603U;
		}

		// Token: 0x060055EC RID: 21996 RVA: 0x0010770E File Offset: 0x00105B0E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060055ED RID: 21997 RVA: 0x00107716 File Offset: 0x00105B16
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060055EE RID: 21998 RVA: 0x0010771F File Offset: 0x00105B1F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rewardId);
		}

		// Token: 0x060055EF RID: 21999 RVA: 0x0010772F File Offset: 0x00105B2F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rewardId);
		}

		// Token: 0x060055F0 RID: 22000 RVA: 0x0010773F File Offset: 0x00105B3F
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.rewardId);
		}

		// Token: 0x060055F1 RID: 22001 RVA: 0x0010774F File Offset: 0x00105B4F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.rewardId);
		}

		// Token: 0x060055F2 RID: 22002 RVA: 0x00107760 File Offset: 0x00105B60
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x040021FB RID: 8699
		public const uint MsgID = 509603U;

		// Token: 0x040021FC RID: 8700
		public uint Sequence;

		// Token: 0x040021FD RID: 8701
		public byte rewardId;
	}
}
