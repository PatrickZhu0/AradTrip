using System;
using System.Collections.Generic;

namespace Protocol
{
	// Token: 0x02000789 RID: 1929
	public class WorldReadMailRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005ECC RID: 24268 RVA: 0x0011C3EF File Offset: 0x0011A7EF
		public uint GetMsgID()
		{
			return 601505U;
		}

		// Token: 0x06005ECD RID: 24269 RVA: 0x0011C3F8 File Offset: 0x0011A7F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.content);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005ECE RID: 24270 RVA: 0x0011C468 File Offset: 0x0011A868
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.content = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.items = new ItemReward[(int)num2];
			for (int j = 0; j < this.items.Length; j++)
			{
				this.items[j] = new ItemReward();
				this.items[j].decode(buffer, ref pos_);
			}
			this.detailItems = ItemDecoder.Decode(buffer, ref pos_, buffer.Length, false);
		}

		// Token: 0x06005ECF RID: 24271 RVA: 0x0011C527 File Offset: 0x0011A927
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005ED0 RID: 24272 RVA: 0x0011C52F File Offset: 0x0011A92F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x04002707 RID: 9991
		public const uint MsgID = 601505U;

		// Token: 0x04002708 RID: 9992
		public uint Sequence;

		// Token: 0x04002709 RID: 9993
		public ulong id;

		// Token: 0x0400270A RID: 9994
		public string content;

		// Token: 0x0400270B RID: 9995
		public ItemReward[] items = new ItemReward[0];

		// Token: 0x0400270C RID: 9996
		public List<Item> detailItems = new List<Item>();
	}
}
