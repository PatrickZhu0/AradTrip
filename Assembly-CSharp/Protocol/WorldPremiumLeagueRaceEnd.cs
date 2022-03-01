using System;

namespace Protocol
{
	// Token: 0x02000A72 RID: 2674
	[Protocol]
	public class WorldPremiumLeagueRaceEnd : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007531 RID: 30001 RVA: 0x00153022 File Offset: 0x00151422
		public uint GetMsgID()
		{
			return 607712U;
		}

		// Token: 0x06007532 RID: 30002 RVA: 0x00153029 File Offset: 0x00151429
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007533 RID: 30003 RVA: 0x00153031 File Offset: 0x00151431
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007534 RID: 30004 RVA: 0x0015303C File Offset: 0x0015143C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isPreliminay);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preliminayRewardNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x06007535 RID: 30005 RVA: 0x001530A0 File Offset: 0x001514A0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPreliminay);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preliminayRewardNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x06007536 RID: 30006 RVA: 0x00153104 File Offset: 0x00151504
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isPreliminay);
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.newScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preliminayRewardNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x06007537 RID: 30007 RVA: 0x00153168 File Offset: 0x00151568
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isPreliminay);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.newScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preliminayRewardNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x06007538 RID: 30008 RVA: 0x001531CC File Offset: 0x001515CC
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400367F RID: 13951
		public const uint MsgID = 607712U;

		// Token: 0x04003680 RID: 13952
		public uint Sequence;

		// Token: 0x04003681 RID: 13953
		public byte isPreliminay;

		// Token: 0x04003682 RID: 13954
		public byte result;

		// Token: 0x04003683 RID: 13955
		public uint oldScore;

		// Token: 0x04003684 RID: 13956
		public uint newScore;

		// Token: 0x04003685 RID: 13957
		public uint preliminayRewardNum;

		// Token: 0x04003686 RID: 13958
		public uint getHonor;
	}
}
