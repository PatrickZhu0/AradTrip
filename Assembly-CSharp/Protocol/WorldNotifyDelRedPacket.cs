using System;

namespace Protocol
{
	// Token: 0x02000A7F RID: 2687
	[Protocol]
	public class WorldNotifyDelRedPacket : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007585 RID: 30085 RVA: 0x0015427D File Offset: 0x0015267D
		public uint GetMsgID()
		{
			return 607304U;
		}

		// Token: 0x06007586 RID: 30086 RVA: 0x00154284 File Offset: 0x00152684
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007587 RID: 30087 RVA: 0x0015428C File Offset: 0x0015268C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007588 RID: 30088 RVA: 0x00154298 File Offset: 0x00152698
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.redPacketList.Length);
			for (int i = 0; i < this.redPacketList.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.redPacketList[i]);
			}
		}

		// Token: 0x06007589 RID: 30089 RVA: 0x001542E0 File Offset: 0x001526E0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.redPacketList = new ulong[(int)num];
			for (int i = 0; i < this.redPacketList.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.redPacketList[i]);
			}
		}

		// Token: 0x0600758A RID: 30090 RVA: 0x00154334 File Offset: 0x00152734
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.redPacketList.Length);
			for (int i = 0; i < this.redPacketList.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.redPacketList[i]);
			}
		}

		// Token: 0x0600758B RID: 30091 RVA: 0x0015437C File Offset: 0x0015277C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.redPacketList = new ulong[(int)num];
			for (int i = 0; i < this.redPacketList.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.redPacketList[i]);
			}
		}

		// Token: 0x0600758C RID: 30092 RVA: 0x001543D0 File Offset: 0x001527D0
		public int getLen()
		{
			int num = 0;
			return num + (2 + 8 * this.redPacketList.Length);
		}

		// Token: 0x040036BA RID: 14010
		public const uint MsgID = 607304U;

		// Token: 0x040036BB RID: 14011
		public uint Sequence;

		// Token: 0x040036BC RID: 14012
		public ulong[] redPacketList = new ulong[0];
	}
}
