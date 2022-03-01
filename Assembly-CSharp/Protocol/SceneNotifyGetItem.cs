using System;

namespace Protocol
{
	// Token: 0x020008E7 RID: 2279
	[Protocol]
	public class SceneNotifyGetItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600688F RID: 26767 RVA: 0x0013570C File Offset: 0x00133B0C
		public uint GetMsgID()
		{
			return 500916U;
		}

		// Token: 0x06006890 RID: 26768 RVA: 0x00135713 File Offset: 0x00133B13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006891 RID: 26769 RVA: 0x0013571B File Offset: 0x00133B1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006892 RID: 26770 RVA: 0x00135724 File Offset: 0x00133B24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sourceType);
			BaseDLL.encode_int8(buffer, ref pos_, this.notify);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006893 RID: 26771 RVA: 0x00135788 File Offset: 0x00133B88
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sourceType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.notify);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new ItemReward[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new ItemReward();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006894 RID: 26772 RVA: 0x00135800 File Offset: 0x00133C00
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.sourceType);
			BaseDLL.encode_int8(buffer, ref pos_, this.notify);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006895 RID: 26773 RVA: 0x00135864 File Offset: 0x00133C64
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.sourceType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.notify);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new ItemReward[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new ItemReward();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006896 RID: 26774 RVA: 0x001358DC File Offset: 0x00133CDC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x04002F6E RID: 12142
		public const uint MsgID = 500916U;

		// Token: 0x04002F6F RID: 12143
		public uint Sequence;

		// Token: 0x04002F70 RID: 12144
		public uint sourceType;

		// Token: 0x04002F71 RID: 12145
		public byte notify;

		// Token: 0x04002F72 RID: 12146
		public ItemReward[] items = new ItemReward[0];
	}
}
