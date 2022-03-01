using System;

namespace Protocol
{
	// Token: 0x020008E9 RID: 2281
	[Protocol]
	public class SceneEquipDecomposeRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060068A1 RID: 26785 RVA: 0x00135ABB File Offset: 0x00133EBB
		public uint GetMsgID()
		{
			return 500919U;
		}

		// Token: 0x060068A2 RID: 26786 RVA: 0x00135AC2 File Offset: 0x00133EC2
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060068A3 RID: 26787 RVA: 0x00135ACA File Offset: 0x00133ECA
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060068A4 RID: 26788 RVA: 0x00135AD4 File Offset: 0x00133ED4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.getItems.Length);
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060068A5 RID: 26789 RVA: 0x00135B28 File Offset: 0x00133F28
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.getItems = new ItemReward[(int)num];
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i] = new ItemReward();
				this.getItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060068A6 RID: 26790 RVA: 0x00135B90 File Offset: 0x00133F90
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.getItems.Length);
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060068A7 RID: 26791 RVA: 0x00135BE4 File Offset: 0x00133FE4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.getItems = new ItemReward[(int)num];
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i] = new ItemReward();
				this.getItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060068A8 RID: 26792 RVA: 0x00135C4C File Offset: 0x0013404C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.getItems.Length; i++)
			{
				num += this.getItems[i].getLen();
			}
			return num;
		}

		// Token: 0x04002F76 RID: 12150
		public const uint MsgID = 500919U;

		// Token: 0x04002F77 RID: 12151
		public uint Sequence;

		// Token: 0x04002F78 RID: 12152
		public uint code;

		// Token: 0x04002F79 RID: 12153
		public ItemReward[] getItems = new ItemReward[0];
	}
}
