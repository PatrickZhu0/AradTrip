using System;

namespace Protocol
{
	// Token: 0x02000A79 RID: 2681
	public class RedPacketDetail : IProtocolStream
	{
		// Token: 0x06007558 RID: 30040 RVA: 0x0015395C File Offset: 0x00151D5C
		public void encode(byte[] buffer, ref int pos_)
		{
			this.baseEntry.encode(buffer, ref pos_);
			this.ownerIcon.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.receivers.Length);
			for (int i = 0; i < this.receivers.Length; i++)
			{
				this.receivers[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007559 RID: 30041 RVA: 0x001539BC File Offset: 0x00151DBC
		public void decode(byte[] buffer, ref int pos_)
		{
			this.baseEntry.decode(buffer, ref pos_);
			this.ownerIcon.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.receivers = new RedPacketReceiverEntry[(int)num];
			for (int i = 0; i < this.receivers.Length; i++)
			{
				this.receivers[i] = new RedPacketReceiverEntry();
				this.receivers[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600755A RID: 30042 RVA: 0x00153A30 File Offset: 0x00151E30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.baseEntry.encode(buffer, ref pos_);
			this.ownerIcon.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.receivers.Length);
			for (int i = 0; i < this.receivers.Length; i++)
			{
				this.receivers[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600755B RID: 30043 RVA: 0x00153A90 File Offset: 0x00151E90
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.baseEntry.decode(buffer, ref pos_);
			this.ownerIcon.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.receivers = new RedPacketReceiverEntry[(int)num];
			for (int i = 0; i < this.receivers.Length; i++)
			{
				this.receivers[i] = new RedPacketReceiverEntry();
				this.receivers[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600755C RID: 30044 RVA: 0x00153B04 File Offset: 0x00151F04
		public int getLen()
		{
			int num = 0;
			num += this.baseEntry.getLen();
			num += this.ownerIcon.getLen();
			num += 2;
			for (int i = 0; i < this.receivers.Length; i++)
			{
				num += this.receivers[i].getLen();
			}
			return num;
		}

		// Token: 0x040036A5 RID: 13989
		public RedPacketBaseEntry baseEntry = new RedPacketBaseEntry();

		// Token: 0x040036A6 RID: 13990
		public PlayerIcon ownerIcon = new PlayerIcon();

		// Token: 0x040036A7 RID: 13991
		public RedPacketReceiverEntry[] receivers = new RedPacketReceiverEntry[0];
	}
}
