using System;

namespace Protocol
{
	// Token: 0x0200090C RID: 2316
	[Protocol]
	public class WorldMallGiftPackActivateRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060069DC RID: 27100 RVA: 0x001376B0 File Offset: 0x00135AB0
		public uint GetMsgID()
		{
			return 602815U;
		}

		// Token: 0x060069DD RID: 27101 RVA: 0x001376B7 File Offset: 0x00135AB7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060069DE RID: 27102 RVA: 0x001376BF File Offset: 0x00135ABF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060069DF RID: 27103 RVA: 0x001376C8 File Offset: 0x00135AC8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060069E0 RID: 27104 RVA: 0x0013771C File Offset: 0x00135B1C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new MallItemInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new MallItemInfo();
				this.items[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060069E1 RID: 27105 RVA: 0x00137784 File Offset: 0x00135B84
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060069E2 RID: 27106 RVA: 0x001377D8 File Offset: 0x00135BD8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new MallItemInfo[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new MallItemInfo();
				this.items[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060069E3 RID: 27107 RVA: 0x00137840 File Offset: 0x00135C40
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num + 4;
		}

		// Token: 0x04002FFE RID: 12286
		public const uint MsgID = 602815U;

		// Token: 0x04002FFF RID: 12287
		public uint Sequence;

		// Token: 0x04003000 RID: 12288
		public MallItemInfo[] items = new MallItemInfo[0];

		// Token: 0x04003001 RID: 12289
		public uint code;
	}
}
