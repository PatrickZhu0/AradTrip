using System;

namespace Protocol
{
	// Token: 0x02000C90 RID: 3216
	[Protocol]
	public class WorldQueryPlayerDetailsRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060084CA RID: 33994 RVA: 0x00175021 File Offset: 0x00173421
		public uint GetMsgID()
		{
			return 601727U;
		}

		// Token: 0x060084CB RID: 33995 RVA: 0x00175028 File Offset: 0x00173428
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060084CC RID: 33996 RVA: 0x00175030 File Offset: 0x00173430
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060084CD RID: 33997 RVA: 0x00175039 File Offset: 0x00173439
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060084CE RID: 33998 RVA: 0x00175048 File Offset: 0x00173448
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060084CF RID: 33999 RVA: 0x00175057 File Offset: 0x00173457
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x060084D0 RID: 34000 RVA: 0x00175066 File Offset: 0x00173466
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x060084D1 RID: 34001 RVA: 0x00175078 File Offset: 0x00173478
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04003FAE RID: 16302
		public const uint MsgID = 601727U;

		// Token: 0x04003FAF RID: 16303
		public uint Sequence;

		// Token: 0x04003FB0 RID: 16304
		public RacePlayerInfo info = new RacePlayerInfo();
	}
}
