using System;

namespace Protocol
{
	// Token: 0x0200096E RID: 2414
	public class ArtifactJarLotteryCfg : IProtocolStream
	{
		// Token: 0x06006D3C RID: 27964 RVA: 0x0013D524 File Offset: 0x0013B924
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewardList.Length);
			for (int i = 0; i < this.rewardList.Length; i++)
			{
				this.rewardList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D3D RID: 27965 RVA: 0x0013D578 File Offset: 0x0013B978
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rewardList = new ItemReward[(int)num];
			for (int i = 0; i < this.rewardList.Length; i++)
			{
				this.rewardList[i] = new ItemReward();
				this.rewardList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D3E RID: 27966 RVA: 0x0013D5E0 File Offset: 0x0013B9E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.rewardList.Length);
			for (int i = 0; i < this.rewardList.Length; i++)
			{
				this.rewardList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D3F RID: 27967 RVA: 0x0013D634 File Offset: 0x0013BA34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.rewardList = new ItemReward[(int)num];
			for (int i = 0; i < this.rewardList.Length; i++)
			{
				this.rewardList[i] = new ItemReward();
				this.rewardList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006D40 RID: 27968 RVA: 0x0013D69C File Offset: 0x0013BA9C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.rewardList.Length; i++)
			{
				num += this.rewardList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003173 RID: 12659
		public uint jarId;

		// Token: 0x04003174 RID: 12660
		public ItemReward[] rewardList = new ItemReward[0];
	}
}
