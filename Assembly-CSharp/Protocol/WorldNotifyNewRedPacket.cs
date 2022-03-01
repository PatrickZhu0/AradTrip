using System;

namespace Protocol
{
	// Token: 0x02000A7E RID: 2686
	[Protocol]
	public class WorldNotifyNewRedPacket : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600757C RID: 30076 RVA: 0x001540CA File Offset: 0x001524CA
		public uint GetMsgID()
		{
			return 607303U;
		}

		// Token: 0x0600757D RID: 30077 RVA: 0x001540D1 File Offset: 0x001524D1
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600757E RID: 30078 RVA: 0x001540D9 File Offset: 0x001524D9
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600757F RID: 30079 RVA: 0x001540E4 File Offset: 0x001524E4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.entry.Length);
			for (int i = 0; i < this.entry.Length; i++)
			{
				this.entry[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007580 RID: 30080 RVA: 0x0015412C File Offset: 0x0015252C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.entry = new RedPacketBaseEntry[(int)num];
			for (int i = 0; i < this.entry.Length; i++)
			{
				this.entry[i] = new RedPacketBaseEntry();
				this.entry[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007581 RID: 30081 RVA: 0x00154188 File Offset: 0x00152588
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.entry.Length);
			for (int i = 0; i < this.entry.Length; i++)
			{
				this.entry[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007582 RID: 30082 RVA: 0x001541D0 File Offset: 0x001525D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.entry = new RedPacketBaseEntry[(int)num];
			for (int i = 0; i < this.entry.Length; i++)
			{
				this.entry[i] = new RedPacketBaseEntry();
				this.entry[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007583 RID: 30083 RVA: 0x0015422C File Offset: 0x0015262C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.entry.Length; i++)
			{
				num += this.entry[i].getLen();
			}
			return num;
		}

		// Token: 0x040036B7 RID: 14007
		public const uint MsgID = 607303U;

		// Token: 0x040036B8 RID: 14008
		public uint Sequence;

		// Token: 0x040036B9 RID: 14009
		public RedPacketBaseEntry[] entry = new RedPacketBaseEntry[0];
	}
}
