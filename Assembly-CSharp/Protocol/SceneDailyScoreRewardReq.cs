using System;

namespace Protocol
{
	// Token: 0x02000C64 RID: 3172
	[Protocol]
	public class SceneDailyScoreRewardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600838F RID: 33679 RVA: 0x001719F4 File Offset: 0x0016FDF4
		public uint GetMsgID()
		{
			return 501139U;
		}

		// Token: 0x06008390 RID: 33680 RVA: 0x001719FB File Offset: 0x0016FDFB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008391 RID: 33681 RVA: 0x00171A03 File Offset: 0x0016FE03
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008392 RID: 33682 RVA: 0x00171A0C File Offset: 0x0016FE0C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.boxId);
		}

		// Token: 0x06008393 RID: 33683 RVA: 0x00171A1C File Offset: 0x0016FE1C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.boxId);
		}

		// Token: 0x06008394 RID: 33684 RVA: 0x00171A2C File Offset: 0x0016FE2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.boxId);
		}

		// Token: 0x06008395 RID: 33685 RVA: 0x00171A3C File Offset: 0x0016FE3C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.boxId);
		}

		// Token: 0x06008396 RID: 33686 RVA: 0x00171A4C File Offset: 0x0016FE4C
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003EE5 RID: 16101
		public const uint MsgID = 501139U;

		// Token: 0x04003EE6 RID: 16102
		public uint Sequence;

		// Token: 0x04003EE7 RID: 16103
		public byte boxId;
	}
}
