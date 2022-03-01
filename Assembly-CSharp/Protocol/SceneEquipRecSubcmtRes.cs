using System;

namespace Protocol
{
	// Token: 0x0200093C RID: 2364
	[Protocol]
	public class SceneEquipRecSubcmtRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B80 RID: 27520 RVA: 0x0013A5F4 File Offset: 0x001389F4
		public uint GetMsgID()
		{
			return 501009U;
		}

		// Token: 0x06006B81 RID: 27521 RVA: 0x0013A5FB File Offset: 0x001389FB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B82 RID: 27522 RVA: 0x0013A603 File Offset: 0x00138A03
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B83 RID: 27523 RVA: 0x0013A60C File Offset: 0x00138A0C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x06006B84 RID: 27524 RVA: 0x0013A670 File Offset: 0x00138A70
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new EqRecScoreItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new EqRecScoreItem();
				this.items[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x06006B85 RID: 27525 RVA: 0x0013A6E8 File Offset: 0x00138AE8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x06006B86 RID: 27526 RVA: 0x0013A74C File Offset: 0x00138B4C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new EqRecScoreItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new EqRecScoreItem();
				this.items[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x06006B87 RID: 27527 RVA: 0x0013A7C4 File Offset: 0x00138BC4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num + 4;
		}

		// Token: 0x040030B6 RID: 12470
		public const uint MsgID = 501009U;

		// Token: 0x040030B7 RID: 12471
		public uint Sequence;

		// Token: 0x040030B8 RID: 12472
		public uint code;

		// Token: 0x040030B9 RID: 12473
		public EqRecScoreItem[] items = new EqRecScoreItem[0];

		// Token: 0x040030BA RID: 12474
		public uint score;
	}
}
