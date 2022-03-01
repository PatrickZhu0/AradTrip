using System;

namespace Protocol
{
	// Token: 0x0200084C RID: 2124
	[Protocol]
	public class WorldGuildOrzReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600641E RID: 25630 RVA: 0x0012B582 File Offset: 0x00129982
		public uint GetMsgID()
		{
			return 601936U;
		}

		// Token: 0x0600641F RID: 25631 RVA: 0x0012B589 File Offset: 0x00129989
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006420 RID: 25632 RVA: 0x0012B591 File Offset: 0x00129991
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006421 RID: 25633 RVA: 0x0012B59A File Offset: 0x0012999A
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x06006422 RID: 25634 RVA: 0x0012B5AA File Offset: 0x001299AA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06006423 RID: 25635 RVA: 0x0012B5BA File Offset: 0x001299BA
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
		}

		// Token: 0x06006424 RID: 25636 RVA: 0x0012B5CA File Offset: 0x001299CA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
		}

		// Token: 0x06006425 RID: 25637 RVA: 0x0012B5DC File Offset: 0x001299DC
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002CE2 RID: 11490
		public const uint MsgID = 601936U;

		// Token: 0x04002CE3 RID: 11491
		public uint Sequence;

		// Token: 0x04002CE4 RID: 11492
		public byte type;
	}
}
