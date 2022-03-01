using System;

namespace Protocol
{
	// Token: 0x020006E1 RID: 1761
	[Protocol]
	public class WorldAuctionQueryMagicOnsalesRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005992 RID: 22930 RVA: 0x001102B0 File Offset: 0x0010E6B0
		public uint GetMsgID()
		{
			return 603934U;
		}

		// Token: 0x06005993 RID: 22931 RVA: 0x001102B7 File Offset: 0x0010E6B7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005994 RID: 22932 RVA: 0x001102BF File Offset: 0x0010E6BF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005995 RID: 22933 RVA: 0x001102C8 File Offset: 0x0010E6C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.magicOnsales.Length);
			for (int i = 0; i < this.magicOnsales.Length; i++)
			{
				this.magicOnsales[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005996 RID: 22934 RVA: 0x0011031C File Offset: 0x0010E71C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.magicOnsales = new AuctionMagicOnsale[(int)num];
			for (int i = 0; i < this.magicOnsales.Length; i++)
			{
				this.magicOnsales[i] = new AuctionMagicOnsale();
				this.magicOnsales[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005997 RID: 22935 RVA: 0x00110384 File Offset: 0x0010E784
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.magicOnsales.Length);
			for (int i = 0; i < this.magicOnsales.Length; i++)
			{
				this.magicOnsales[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005998 RID: 22936 RVA: 0x001103D8 File Offset: 0x0010E7D8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.magicOnsales = new AuctionMagicOnsale[(int)num];
			for (int i = 0; i < this.magicOnsales.Length; i++)
			{
				this.magicOnsales[i] = new AuctionMagicOnsale();
				this.magicOnsales[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005999 RID: 22937 RVA: 0x00110440 File Offset: 0x0010E840
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.magicOnsales.Length; i++)
			{
				num += this.magicOnsales[i].getLen();
			}
			return num;
		}

		// Token: 0x04002413 RID: 9235
		public const uint MsgID = 603934U;

		// Token: 0x04002414 RID: 9236
		public uint Sequence;

		// Token: 0x04002415 RID: 9237
		public uint code;

		// Token: 0x04002416 RID: 9238
		public AuctionMagicOnsale[] magicOnsales = new AuctionMagicOnsale[0];
	}
}
