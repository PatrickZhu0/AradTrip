using System;

namespace Protocol
{
	// Token: 0x02000910 RID: 2320
	[Protocol]
	public class WorldMallQueryItemRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A00 RID: 27136 RVA: 0x00137BC8 File Offset: 0x00135FC8
		public uint GetMsgID()
		{
			return 602804U;
		}

		// Token: 0x06006A01 RID: 27137 RVA: 0x00137BCF File Offset: 0x00135FCF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A02 RID: 27138 RVA: 0x00137BD7 File Offset: 0x00135FD7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A03 RID: 27139 RVA: 0x00137BE0 File Offset: 0x00135FE0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A04 RID: 27140 RVA: 0x00137C34 File Offset: 0x00136034
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new MallItemInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new MallItemInfo();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A05 RID: 27141 RVA: 0x00137C9C File Offset: 0x0013609C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A06 RID: 27142 RVA: 0x00137CF0 File Offset: 0x001360F0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new MallItemInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new MallItemInfo();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006A07 RID: 27143 RVA: 0x00137D58 File Offset: 0x00136158
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x04003012 RID: 12306
		public const uint MsgID = 602804U;

		// Token: 0x04003013 RID: 12307
		public uint Sequence;

		// Token: 0x04003014 RID: 12308
		public byte type;

		// Token: 0x04003015 RID: 12309
		public MallItemInfo[] items = new MallItemInfo[0];
	}
}
