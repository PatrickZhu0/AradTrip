using System;

namespace Protocol
{
	// Token: 0x02000A0D RID: 2573
	[Protocol]
	public class WorldMonopolyStatusRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600723A RID: 29242 RVA: 0x0014B374 File Offset: 0x00149774
		public uint GetMsgID()
		{
			return 610204U;
		}

		// Token: 0x0600723B RID: 29243 RVA: 0x0014B37B File Offset: 0x0014977B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600723C RID: 29244 RVA: 0x0014B383 File Offset: 0x00149783
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600723D RID: 29245 RVA: 0x0014B38C File Offset: 0x0014978C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.turn);
			BaseDLL.encode_uint32(buffer, ref pos_, this.currentGrid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rollTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buff);
		}

		// Token: 0x0600723E RID: 29246 RVA: 0x0014B3C6 File Offset: 0x001497C6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.turn);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.currentGrid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rollTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buff);
		}

		// Token: 0x0600723F RID: 29247 RVA: 0x0014B400 File Offset: 0x00149800
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.turn);
			BaseDLL.encode_uint32(buffer, ref pos_, this.currentGrid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rollTimes);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buff);
		}

		// Token: 0x06007240 RID: 29248 RVA: 0x0014B43A File Offset: 0x0014983A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.turn);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.currentGrid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rollTimes);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buff);
		}

		// Token: 0x06007241 RID: 29249 RVA: 0x0014B474 File Offset: 0x00149874
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003481 RID: 13441
		public const uint MsgID = 610204U;

		// Token: 0x04003482 RID: 13442
		public uint Sequence;

		// Token: 0x04003483 RID: 13443
		public uint turn;

		// Token: 0x04003484 RID: 13444
		public uint currentGrid;

		// Token: 0x04003485 RID: 13445
		public uint rollTimes;

		// Token: 0x04003486 RID: 13446
		public uint buff;
	}
}
