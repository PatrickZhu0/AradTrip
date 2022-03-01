using System;

namespace Protocol
{
	// Token: 0x02000952 RID: 2386
	[Protocol]
	public class SceneGiftPackInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C46 RID: 27718 RVA: 0x0013BAE7 File Offset: 0x00139EE7
		public uint GetMsgID()
		{
			return 503212U;
		}

		// Token: 0x06006C47 RID: 27719 RVA: 0x0013BAEE File Offset: 0x00139EEE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C48 RID: 27720 RVA: 0x0013BAF6 File Offset: 0x00139EF6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C49 RID: 27721 RVA: 0x0013BB00 File Offset: 0x00139F00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.giftPacks.Length);
			for (int i = 0; i < this.giftPacks.Length; i++)
			{
				this.giftPacks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C4A RID: 27722 RVA: 0x0013BB48 File Offset: 0x00139F48
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.giftPacks = new GiftPackSyncInfo[(int)num];
			for (int i = 0; i < this.giftPacks.Length; i++)
			{
				this.giftPacks[i] = new GiftPackSyncInfo();
				this.giftPacks[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C4B RID: 27723 RVA: 0x0013BBA4 File Offset: 0x00139FA4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.giftPacks.Length);
			for (int i = 0; i < this.giftPacks.Length; i++)
			{
				this.giftPacks[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C4C RID: 27724 RVA: 0x0013BBEC File Offset: 0x00139FEC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.giftPacks = new GiftPackSyncInfo[(int)num];
			for (int i = 0; i < this.giftPacks.Length; i++)
			{
				this.giftPacks[i] = new GiftPackSyncInfo();
				this.giftPacks[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C4D RID: 27725 RVA: 0x0013BC48 File Offset: 0x0013A048
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.giftPacks.Length; i++)
			{
				num += this.giftPacks[i].getLen();
			}
			return num;
		}

		// Token: 0x04003101 RID: 12545
		public const uint MsgID = 503212U;

		// Token: 0x04003102 RID: 12546
		public uint Sequence;

		// Token: 0x04003103 RID: 12547
		public GiftPackSyncInfo[] giftPacks = new GiftPackSyncInfo[0];
	}
}
