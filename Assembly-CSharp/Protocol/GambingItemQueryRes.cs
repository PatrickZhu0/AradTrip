using System;

namespace Protocol
{
	// Token: 0x0200094B RID: 2379
	[Protocol]
	public class GambingItemQueryRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C07 RID: 27655 RVA: 0x0013B1E0 File Offset: 0x001395E0
		public uint GetMsgID()
		{
			return 707904U;
		}

		// Token: 0x06006C08 RID: 27656 RVA: 0x0013B1E7 File Offset: 0x001395E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C09 RID: 27657 RVA: 0x0013B1EF File Offset: 0x001395EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C0A RID: 27658 RVA: 0x0013B1F8 File Offset: 0x001395F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gambingItems.Length);
			for (int i = 0; i < this.gambingItems.Length; i++)
			{
				this.gambingItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C0B RID: 27659 RVA: 0x0013B240 File Offset: 0x00139640
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gambingItems = new GambingItemInfo[(int)num];
			for (int i = 0; i < this.gambingItems.Length; i++)
			{
				this.gambingItems[i] = new GambingItemInfo();
				this.gambingItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C0C RID: 27660 RVA: 0x0013B29C File Offset: 0x0013969C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gambingItems.Length);
			for (int i = 0; i < this.gambingItems.Length; i++)
			{
				this.gambingItems[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C0D RID: 27661 RVA: 0x0013B2E4 File Offset: 0x001396E4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gambingItems = new GambingItemInfo[(int)num];
			for (int i = 0; i < this.gambingItems.Length; i++)
			{
				this.gambingItems[i] = new GambingItemInfo();
				this.gambingItems[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C0E RID: 27662 RVA: 0x0013B340 File Offset: 0x00139740
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.gambingItems.Length; i++)
			{
				num += this.gambingItems[i].getLen();
			}
			return num;
		}

		// Token: 0x040030ED RID: 12525
		public const uint MsgID = 707904U;

		// Token: 0x040030EE RID: 12526
		public uint Sequence;

		// Token: 0x040030EF RID: 12527
		public GambingItemInfo[] gambingItems = new GambingItemInfo[0];
	}
}
