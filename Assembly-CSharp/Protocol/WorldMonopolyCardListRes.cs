using System;

namespace Protocol
{
	// Token: 0x02000A14 RID: 2580
	[Protocol]
	public class WorldMonopolyCardListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007276 RID: 29302 RVA: 0x0014B748 File Offset: 0x00149B48
		public uint GetMsgID()
		{
			return 610210U;
		}

		// Token: 0x06007277 RID: 29303 RVA: 0x0014B74F File Offset: 0x00149B4F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007278 RID: 29304 RVA: 0x0014B757 File Offset: 0x00149B57
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007279 RID: 29305 RVA: 0x0014B760 File Offset: 0x00149B60
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.cardList.Length);
			for (int i = 0; i < this.cardList.Length; i++)
			{
				this.cardList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600727A RID: 29306 RVA: 0x0014B7A8 File Offset: 0x00149BA8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.cardList = new MonpolyCard[(int)num];
			for (int i = 0; i < this.cardList.Length; i++)
			{
				this.cardList[i] = new MonpolyCard();
				this.cardList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600727B RID: 29307 RVA: 0x0014B804 File Offset: 0x00149C04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.cardList.Length);
			for (int i = 0; i < this.cardList.Length; i++)
			{
				this.cardList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600727C RID: 29308 RVA: 0x0014B84C File Offset: 0x00149C4C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.cardList = new MonpolyCard[(int)num];
			for (int i = 0; i < this.cardList.Length; i++)
			{
				this.cardList[i] = new MonpolyCard();
				this.cardList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600727D RID: 29309 RVA: 0x0014B8A8 File Offset: 0x00149CA8
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.cardList.Length; i++)
			{
				num += this.cardList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003497 RID: 13463
		public const uint MsgID = 610210U;

		// Token: 0x04003498 RID: 13464
		public uint Sequence;

		// Token: 0x04003499 RID: 13465
		public MonpolyCard[] cardList = new MonpolyCard[0];
	}
}
