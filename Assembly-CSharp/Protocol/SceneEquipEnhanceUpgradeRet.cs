using System;

namespace Protocol
{
	// Token: 0x0200098B RID: 2443
	[Protocol]
	public class SceneEquipEnhanceUpgradeRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E35 RID: 28213 RVA: 0x0013F678 File Offset: 0x0013DA78
		public uint GetMsgID()
		{
			return 501061U;
		}

		// Token: 0x06006E36 RID: 28214 RVA: 0x0013F67F File Offset: 0x0013DA7F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E37 RID: 28215 RVA: 0x0013F687 File Offset: 0x0013DA87
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E38 RID: 28216 RVA: 0x0013F690 File Offset: 0x0013DA90
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.matNums.Length);
			for (int i = 0; i < this.matNums.Length; i++)
			{
				this.matNums[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006E39 RID: 28217 RVA: 0x0013F6E4 File Offset: 0x0013DAE4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.matNums = new ItemReward[(int)num];
			for (int i = 0; i < this.matNums.Length; i++)
			{
				this.matNums[i] = new ItemReward();
				this.matNums[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006E3A RID: 28218 RVA: 0x0013F74C File Offset: 0x0013DB4C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.matNums.Length);
			for (int i = 0; i < this.matNums.Length; i++)
			{
				this.matNums[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006E3B RID: 28219 RVA: 0x0013F7A0 File Offset: 0x0013DBA0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.matNums = new ItemReward[(int)num];
			for (int i = 0; i < this.matNums.Length; i++)
			{
				this.matNums[i] = new ItemReward();
				this.matNums[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006E3C RID: 28220 RVA: 0x0013F808 File Offset: 0x0013DC08
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.matNums.Length; i++)
			{
				num += this.matNums[i].getLen();
			}
			return num;
		}

		// Token: 0x040031EF RID: 12783
		public const uint MsgID = 501061U;

		// Token: 0x040031F0 RID: 12784
		public uint Sequence;

		// Token: 0x040031F1 RID: 12785
		public uint code;

		// Token: 0x040031F2 RID: 12786
		public ItemReward[] matNums = new ItemReward[0];
	}
}
