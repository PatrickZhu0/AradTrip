using System;

namespace Protocol
{
	// Token: 0x020006D5 RID: 1749
	[Protocol]
	public class SceneAbnormalTransactionRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600592C RID: 22828 RVA: 0x0010EF88 File Offset: 0x0010D388
		public uint GetMsgID()
		{
			return 503907U;
		}

		// Token: 0x0600592D RID: 22829 RVA: 0x0010EF8F File Offset: 0x0010D38F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600592E RID: 22830 RVA: 0x0010EF97 File Offset: 0x0010D397
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600592F RID: 22831 RVA: 0x0010EFA0 File Offset: 0x0010D3A0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.frozenMoneyType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.frozenAmount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.abnormalTransactionTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.backDeadline);
			BaseDLL.encode_uint32(buffer, ref pos_, this.backAmount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.backDays);
		}

		// Token: 0x06005930 RID: 22832 RVA: 0x0010F004 File Offset: 0x0010D404
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.frozenMoneyType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.frozenAmount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.abnormalTransactionTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.backDeadline);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.backAmount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.backDays);
		}

		// Token: 0x06005931 RID: 22833 RVA: 0x0010F068 File Offset: 0x0010D468
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.frozenMoneyType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.frozenAmount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.abnormalTransactionTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.backDeadline);
			BaseDLL.encode_uint32(buffer, ref pos_, this.backAmount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.backDays);
		}

		// Token: 0x06005932 RID: 22834 RVA: 0x0010F0CC File Offset: 0x0010D4CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.frozenMoneyType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.frozenAmount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.abnormalTransactionTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.backDeadline);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.backAmount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.backDays);
		}

		// Token: 0x06005933 RID: 22835 RVA: 0x0010F130 File Offset: 0x0010D530
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040023D2 RID: 9170
		public const uint MsgID = 503907U;

		// Token: 0x040023D3 RID: 9171
		public uint Sequence;

		// Token: 0x040023D4 RID: 9172
		public uint frozenMoneyType;

		// Token: 0x040023D5 RID: 9173
		public uint frozenAmount;

		// Token: 0x040023D6 RID: 9174
		public uint abnormalTransactionTime;

		// Token: 0x040023D7 RID: 9175
		public uint backDeadline;

		// Token: 0x040023D8 RID: 9176
		public uint backAmount;

		// Token: 0x040023D9 RID: 9177
		public uint backDays;
	}
}
