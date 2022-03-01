using System;

namespace Protocol
{
	// Token: 0x02000853 RID: 2131
	[Protocol]
	public class WorldGuildBattleReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600645D RID: 25693 RVA: 0x0012B9C8 File Offset: 0x00129DC8
		public uint GetMsgID()
		{
			return 601942U;
		}

		// Token: 0x0600645E RID: 25694 RVA: 0x0012B9CF File Offset: 0x00129DCF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600645F RID: 25695 RVA: 0x0012B9D7 File Offset: 0x00129DD7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006460 RID: 25696 RVA: 0x0012B9E0 File Offset: 0x00129DE0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
		}

		// Token: 0x06006461 RID: 25697 RVA: 0x0012B9F0 File Offset: 0x00129DF0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
		}

		// Token: 0x06006462 RID: 25698 RVA: 0x0012BA00 File Offset: 0x00129E00
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.terrId);
		}

		// Token: 0x06006463 RID: 25699 RVA: 0x0012BA10 File Offset: 0x00129E10
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.terrId);
		}

		// Token: 0x06006464 RID: 25700 RVA: 0x0012BA20 File Offset: 0x00129E20
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002CF8 RID: 11512
		public const uint MsgID = 601942U;

		// Token: 0x04002CF9 RID: 11513
		public uint Sequence;

		// Token: 0x04002CFA RID: 11514
		public byte terrId;
	}
}
