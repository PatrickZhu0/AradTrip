using System;

namespace Protocol
{
	// Token: 0x02000780 RID: 1920
	[Protocol]
	public class WorldChatLinkDataReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E7E RID: 24190 RVA: 0x0011B7C8 File Offset: 0x00119BC8
		public uint GetMsgID()
		{
			return 600802U;
		}

		// Token: 0x06005E7F RID: 24191 RVA: 0x0011B7CF File Offset: 0x00119BCF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E80 RID: 24192 RVA: 0x0011B7D7 File Offset: 0x00119BD7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E81 RID: 24193 RVA: 0x0011B7E0 File Offset: 0x00119BE0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.queryType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
		}

		// Token: 0x06005E82 RID: 24194 RVA: 0x0011B81A File Offset: 0x00119C1A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.queryType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
		}

		// Token: 0x06005E83 RID: 24195 RVA: 0x0011B854 File Offset: 0x00119C54
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.queryType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
		}

		// Token: 0x06005E84 RID: 24196 RVA: 0x0011B88E File Offset: 0x00119C8E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.queryType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
		}

		// Token: 0x06005E85 RID: 24197 RVA: 0x0011B8C8 File Offset: 0x00119CC8
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x040026DF RID: 9951
		public const uint MsgID = 600802U;

		// Token: 0x040026E0 RID: 9952
		public uint Sequence;

		// Token: 0x040026E1 RID: 9953
		public byte type;

		// Token: 0x040026E2 RID: 9954
		public ulong uid;

		// Token: 0x040026E3 RID: 9955
		public uint queryType;

		// Token: 0x040026E4 RID: 9956
		public uint zoneId;
	}
}
