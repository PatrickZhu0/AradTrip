using System;

namespace Protocol
{
	// Token: 0x02000B10 RID: 2832
	[Protocol]
	public class SceneNotifyLoadingInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060079A8 RID: 31144 RVA: 0x0015DF96 File Offset: 0x0015C396
		public uint GetMsgID()
		{
			return 500117U;
		}

		// Token: 0x060079A9 RID: 31145 RVA: 0x0015DF9D File Offset: 0x0015C39D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060079AA RID: 31146 RVA: 0x0015DFA5 File Offset: 0x0015C3A5
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060079AB RID: 31147 RVA: 0x0015DFAE File Offset: 0x0015C3AE
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isLoading);
		}

		// Token: 0x060079AC RID: 31148 RVA: 0x0015DFBE File Offset: 0x0015C3BE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLoading);
		}

		// Token: 0x060079AD RID: 31149 RVA: 0x0015DFCE File Offset: 0x0015C3CE
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isLoading);
		}

		// Token: 0x060079AE RID: 31150 RVA: 0x0015DFDE File Offset: 0x0015C3DE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLoading);
		}

		// Token: 0x060079AF RID: 31151 RVA: 0x0015DFF0 File Offset: 0x0015C3F0
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003963 RID: 14691
		public const uint MsgID = 500117U;

		// Token: 0x04003964 RID: 14692
		public uint Sequence;

		// Token: 0x04003965 RID: 14693
		public byte isLoading;
	}
}
