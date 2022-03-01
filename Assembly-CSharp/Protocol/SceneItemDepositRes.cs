using System;

namespace Protocol
{
	// Token: 0x02000982 RID: 2434
	[Protocol]
	public class SceneItemDepositRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DE4 RID: 28132 RVA: 0x0013EB8A File Offset: 0x0013CF8A
		public uint GetMsgID()
		{
			return 501051U;
		}

		// Token: 0x06006DE5 RID: 28133 RVA: 0x0013EB91 File Offset: 0x0013CF91
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006DE6 RID: 28134 RVA: 0x0013EB99 File Offset: 0x0013CF99
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006DE7 RID: 28135 RVA: 0x0013EBA4 File Offset: 0x0013CFA4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.expireTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.depositItemList.Length);
			for (int i = 0; i < this.depositItemList.Length; i++)
			{
				this.depositItemList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DE8 RID: 28136 RVA: 0x0013EBF8 File Offset: 0x0013CFF8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.expireTime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.depositItemList = new depositItem[(int)num];
			for (int i = 0; i < this.depositItemList.Length; i++)
			{
				this.depositItemList[i] = new depositItem();
				this.depositItemList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DE9 RID: 28137 RVA: 0x0013EC60 File Offset: 0x0013D060
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.expireTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.depositItemList.Length);
			for (int i = 0; i < this.depositItemList.Length; i++)
			{
				this.depositItemList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DEA RID: 28138 RVA: 0x0013ECB4 File Offset: 0x0013D0B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.expireTime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.depositItemList = new depositItem[(int)num];
			for (int i = 0; i < this.depositItemList.Length; i++)
			{
				this.depositItemList[i] = new depositItem();
				this.depositItemList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DEB RID: 28139 RVA: 0x0013ED1C File Offset: 0x0013D11C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.depositItemList.Length; i++)
			{
				num += this.depositItemList[i].getLen();
			}
			return num;
		}

		// Token: 0x040031C2 RID: 12738
		public const uint MsgID = 501051U;

		// Token: 0x040031C3 RID: 12739
		public uint Sequence;

		// Token: 0x040031C4 RID: 12740
		public uint expireTime;

		// Token: 0x040031C5 RID: 12741
		public depositItem[] depositItemList = new depositItem[0];
	}
}
