using System;

namespace Protocol
{
	// Token: 0x0200097F RID: 2431
	[Protocol]
	public class WorldBuyRechargePushItemsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DCC RID: 28108 RVA: 0x0013E840 File Offset: 0x0013CC40
		public uint GetMsgID()
		{
			return 602830U;
		}

		// Token: 0x06006DCD RID: 28109 RVA: 0x0013E847 File Offset: 0x0013CC47
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006DCE RID: 28110 RVA: 0x0013E84F File Offset: 0x0013CC4F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006DCF RID: 28111 RVA: 0x0013E858 File Offset: 0x0013CC58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pushId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemVec.Length);
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DD0 RID: 28112 RVA: 0x0013E8BC File Offset: 0x0013CCBC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pushId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemVec = new RechargePushItem[(int)num];
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i] = new RechargePushItem();
				this.itemVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DD1 RID: 28113 RVA: 0x0013E934 File Offset: 0x0013CD34
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pushId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemVec.Length);
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DD2 RID: 28114 RVA: 0x0013E998 File Offset: 0x0013CD98
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pushId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemVec = new RechargePushItem[(int)num];
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i] = new RechargePushItem();
				this.itemVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DD3 RID: 28115 RVA: 0x0013EA10 File Offset: 0x0013CE10
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				num += this.itemVec[i].getLen();
			}
			return num;
		}

		// Token: 0x040031B8 RID: 12728
		public const uint MsgID = 602830U;

		// Token: 0x040031B9 RID: 12729
		public uint Sequence;

		// Token: 0x040031BA RID: 12730
		public uint retCode;

		// Token: 0x040031BB RID: 12731
		public uint pushId;

		// Token: 0x040031BC RID: 12732
		public RechargePushItem[] itemVec = new RechargePushItem[0];
	}
}
