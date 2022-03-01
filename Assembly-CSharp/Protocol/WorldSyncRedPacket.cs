using System;

namespace Protocol
{
	// Token: 0x02000A7C RID: 2684
	[Protocol]
	public class WorldSyncRedPacket : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600756A RID: 30058 RVA: 0x00153E94 File Offset: 0x00152294
		public uint GetMsgID()
		{
			return 607301U;
		}

		// Token: 0x0600756B RID: 30059 RVA: 0x00153E9B File Offset: 0x0015229B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600756C RID: 30060 RVA: 0x00153EA3 File Offset: 0x001522A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600756D RID: 30061 RVA: 0x00153EAC File Offset: 0x001522AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.entrys.Length);
			for (int i = 0; i < this.entrys.Length; i++)
			{
				this.entrys[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600756E RID: 30062 RVA: 0x00153EF4 File Offset: 0x001522F4
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.entrys = new RedPacketBaseEntry[(int)num];
			for (int i = 0; i < this.entrys.Length; i++)
			{
				this.entrys[i] = new RedPacketBaseEntry();
				this.entrys[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600756F RID: 30063 RVA: 0x00153F50 File Offset: 0x00152350
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.entrys.Length);
			for (int i = 0; i < this.entrys.Length; i++)
			{
				this.entrys[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007570 RID: 30064 RVA: 0x00153F98 File Offset: 0x00152398
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.entrys = new RedPacketBaseEntry[(int)num];
			for (int i = 0; i < this.entrys.Length; i++)
			{
				this.entrys[i] = new RedPacketBaseEntry();
				this.entrys[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007571 RID: 30065 RVA: 0x00153FF4 File Offset: 0x001523F4
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.entrys.Length; i++)
			{
				num += this.entrys[i].getLen();
			}
			return num;
		}

		// Token: 0x040036B1 RID: 14001
		public const uint MsgID = 607301U;

		// Token: 0x040036B2 RID: 14002
		public uint Sequence;

		// Token: 0x040036B3 RID: 14003
		public RedPacketBaseEntry[] entrys = new RedPacketBaseEntry[0];
	}
}
