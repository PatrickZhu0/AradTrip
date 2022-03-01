using System;

namespace Protocol
{
	// Token: 0x020007EF RID: 2031
	[Protocol]
	public class WorldDungeonRollItemResult : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061D2 RID: 25042 RVA: 0x001245D8 File Offset: 0x001229D8
		public uint GetMsgID()
		{
			return 606819U;
		}

		// Token: 0x060061D3 RID: 25043 RVA: 0x001245DF File Offset: 0x001229DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061D4 RID: 25044 RVA: 0x001245E7 File Offset: 0x001229E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061D5 RID: 25045 RVA: 0x001245F0 File Offset: 0x001229F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060061D6 RID: 25046 RVA: 0x00124638 File Offset: 0x00122A38
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new RollDropResultItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new RollDropResultItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060061D7 RID: 25047 RVA: 0x00124694 File Offset: 0x00122A94
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060061D8 RID: 25048 RVA: 0x001246DC File Offset: 0x00122ADC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new RollDropResultItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new RollDropResultItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060061D9 RID: 25049 RVA: 0x00124738 File Offset: 0x00122B38
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x040028BF RID: 10431
		public const uint MsgID = 606819U;

		// Token: 0x040028C0 RID: 10432
		public uint Sequence;

		// Token: 0x040028C1 RID: 10433
		public RollDropResultItem[] items = new RollDropResultItem[0];
	}
}
