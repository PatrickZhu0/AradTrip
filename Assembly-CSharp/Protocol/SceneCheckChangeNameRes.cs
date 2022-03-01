using System;

namespace Protocol
{
	// Token: 0x02000B39 RID: 2873
	[Protocol]
	public class SceneCheckChangeNameRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007AC8 RID: 31432 RVA: 0x00160400 File Offset: 0x0015E800
		public uint GetMsgID()
		{
			return 501217U;
		}

		// Token: 0x06007AC9 RID: 31433 RVA: 0x00160407 File Offset: 0x0015E807
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007ACA RID: 31434 RVA: 0x0016040F File Offset: 0x0015E80F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007ACB RID: 31435 RVA: 0x00160418 File Offset: 0x0015E818
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06007ACC RID: 31436 RVA: 0x00160428 File Offset: 0x0015E828
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06007ACD RID: 31437 RVA: 0x00160438 File Offset: 0x0015E838
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06007ACE RID: 31438 RVA: 0x00160448 File Offset: 0x0015E848
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06007ACF RID: 31439 RVA: 0x00160458 File Offset: 0x0015E858
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003A34 RID: 14900
		public const uint MsgID = 501217U;

		// Token: 0x04003A35 RID: 14901
		public uint Sequence;

		// Token: 0x04003A36 RID: 14902
		public uint code;
	}
}
