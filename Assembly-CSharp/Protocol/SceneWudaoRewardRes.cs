using System;

namespace Protocol
{
	// Token: 0x02000A03 RID: 2563
	[Protocol]
	public class SceneWudaoRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060071E3 RID: 29155 RVA: 0x0014AA10 File Offset: 0x00148E10
		public uint GetMsgID()
		{
			return 506709U;
		}

		// Token: 0x060071E4 RID: 29156 RVA: 0x0014AA17 File Offset: 0x00148E17
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071E5 RID: 29157 RVA: 0x0014AA1F File Offset: 0x00148E1F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071E6 RID: 29158 RVA: 0x0014AA28 File Offset: 0x00148E28
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.getItems.Length);
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060071E7 RID: 29159 RVA: 0x0014AA7C File Offset: 0x00148E7C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.getItems = new ItemReward[(int)num];
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i] = new ItemReward();
				this.getItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060071E8 RID: 29160 RVA: 0x0014AAE4 File Offset: 0x00148EE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.getItems.Length);
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060071E9 RID: 29161 RVA: 0x0014AB38 File Offset: 0x00148F38
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.getItems = new ItemReward[(int)num];
			for (int i = 0; i < this.getItems.Length; i++)
			{
				this.getItems[i] = new ItemReward();
				this.getItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060071EA RID: 29162 RVA: 0x0014ABA0 File Offset: 0x00148FA0
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

		// Token: 0x0400345B RID: 13403
		public const uint MsgID = 506709U;

		// Token: 0x0400345C RID: 13404
		public uint Sequence;

		// Token: 0x0400345D RID: 13405
		public uint result;

		// Token: 0x0400345E RID: 13406
		public ItemReward[] getItems = new ItemReward[0];
	}
}
