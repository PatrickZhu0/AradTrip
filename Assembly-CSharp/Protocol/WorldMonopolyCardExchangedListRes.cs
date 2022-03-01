using System;

namespace Protocol
{
	// Token: 0x02000A19 RID: 2585
	[Protocol]
	public class WorldMonopolyCardExchangedListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060072A3 RID: 29347 RVA: 0x0014BB08 File Offset: 0x00149F08
		public uint GetMsgID()
		{
			return 610215U;
		}

		// Token: 0x060072A4 RID: 29348 RVA: 0x0014BB0F File Offset: 0x00149F0F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060072A5 RID: 29349 RVA: 0x0014BB17 File Offset: 0x00149F17
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060072A6 RID: 29350 RVA: 0x0014BB20 File Offset: 0x00149F20
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.cardList.Length);
			for (int i = 0; i < this.cardList.Length; i++)
			{
				this.cardList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060072A7 RID: 29351 RVA: 0x0014BB68 File Offset: 0x00149F68
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

		// Token: 0x060072A8 RID: 29352 RVA: 0x0014BBC4 File Offset: 0x00149FC4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.cardList.Length);
			for (int i = 0; i < this.cardList.Length; i++)
			{
				this.cardList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060072A9 RID: 29353 RVA: 0x0014BC0C File Offset: 0x0014A00C
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

		// Token: 0x060072AA RID: 29354 RVA: 0x0014BC68 File Offset: 0x0014A068
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

		// Token: 0x040034A7 RID: 13479
		public const uint MsgID = 610215U;

		// Token: 0x040034A8 RID: 13480
		public uint Sequence;

		// Token: 0x040034A9 RID: 13481
		public MonpolyCard[] cardList = new MonpolyCard[0];
	}
}
