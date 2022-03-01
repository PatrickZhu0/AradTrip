using System;

namespace Protocol
{
	// Token: 0x0200099C RID: 2460
	[Protocol]
	public class SceneEquipInscriptionSynthesisRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006ECE RID: 28366 RVA: 0x0014058F File Offset: 0x0013E98F
		public uint GetMsgID()
		{
			return 501082U;
		}

		// Token: 0x06006ECF RID: 28367 RVA: 0x00140596 File Offset: 0x0013E996
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006ED0 RID: 28368 RVA: 0x0014059E File Offset: 0x0013E99E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006ED1 RID: 28369 RVA: 0x001405A8 File Offset: 0x0013E9A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006ED2 RID: 28370 RVA: 0x001405FC File Offset: 0x0013E9FC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new ItemReward[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new ItemReward();
				this.items[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006ED3 RID: 28371 RVA: 0x00140664 File Offset: 0x0013EA64
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006ED4 RID: 28372 RVA: 0x001406B8 File Offset: 0x0013EAB8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new ItemReward[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new ItemReward();
				this.items[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006ED5 RID: 28373 RVA: 0x00140720 File Offset: 0x0013EB20
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

		// Token: 0x04003237 RID: 12855
		public const uint MsgID = 501082U;

		// Token: 0x04003238 RID: 12856
		public uint Sequence;

		// Token: 0x04003239 RID: 12857
		public ItemReward[] items = new ItemReward[0];

		// Token: 0x0400323A RID: 12858
		public uint retCode;
	}
}
