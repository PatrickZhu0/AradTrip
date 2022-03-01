using System;

namespace Protocol
{
	// Token: 0x02000791 RID: 1937
	public class DigDetailInfo : IProtocolStream
	{
		// Token: 0x06005EF6 RID: 24310 RVA: 0x0011CC08 File Offset: 0x0011B008
		public void encode(byte[] buffer, ref int pos_)
		{
			this.simpleInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.digItems.Length);
			for (int i = 0; i < this.digItems.Length; i++)
			{
				this.digItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005EF7 RID: 24311 RVA: 0x0011CC5C File Offset: 0x0011B05C
		public void decode(byte[] buffer, ref int pos_)
		{
			this.simpleInfo.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.digItems = new DigItemInfo[(int)num];
			for (int i = 0; i < this.digItems.Length; i++)
			{
				this.digItems[i] = new DigItemInfo();
				this.digItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005EF8 RID: 24312 RVA: 0x0011CCC4 File Offset: 0x0011B0C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.simpleInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.digItems.Length);
			for (int i = 0; i < this.digItems.Length; i++)
			{
				this.digItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005EF9 RID: 24313 RVA: 0x0011CD18 File Offset: 0x0011B118
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.simpleInfo.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.digItems = new DigItemInfo[(int)num];
			for (int i = 0; i < this.digItems.Length; i++)
			{
				this.digItems[i] = new DigItemInfo();
				this.digItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005EFA RID: 24314 RVA: 0x0011CD80 File Offset: 0x0011B180
		public int getLen()
		{
			int num = 0;
			num += this.simpleInfo.getLen();
			num += 2;
			for (int i = 0; i < this.digItems.Length; i++)
			{
				num += this.digItems[i].getLen();
			}
			return num;
		}

		// Token: 0x0400272B RID: 10027
		public DigInfo simpleInfo = new DigInfo();

		// Token: 0x0400272C RID: 10028
		public DigItemInfo[] digItems = new DigItemInfo[0];
	}
}
