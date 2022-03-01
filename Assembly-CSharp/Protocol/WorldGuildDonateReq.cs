using System;

namespace Protocol
{
	// Token: 0x02000844 RID: 2116
	[Protocol]
	public class WorldGuildDonateReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063D6 RID: 25558 RVA: 0x0012B144 File Offset: 0x00129544
		public uint GetMsgID()
		{
			return 601928U;
		}

		// Token: 0x060063D7 RID: 25559 RVA: 0x0012B14B File Offset: 0x0012954B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063D8 RID: 25560 RVA: 0x0012B153 File Offset: 0x00129553
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063D9 RID: 25561 RVA: 0x0012B15C File Offset: 0x0012955C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x060063DA RID: 25562 RVA: 0x0012B17A File Offset: 0x0012957A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060063DB RID: 25563 RVA: 0x0012B198 File Offset: 0x00129598
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x060063DC RID: 25564 RVA: 0x0012B1B6 File Offset: 0x001295B6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060063DD RID: 25565 RVA: 0x0012B1D4 File Offset: 0x001295D4
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x04002CCD RID: 11469
		public const uint MsgID = 601928U;

		// Token: 0x04002CCE RID: 11470
		public uint Sequence;

		// Token: 0x04002CCF RID: 11471
		public byte type;

		// Token: 0x04002CD0 RID: 11472
		public byte num;
	}
}
