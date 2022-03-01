using System;

namespace Protocol
{
	// Token: 0x02000A81 RID: 2689
	[Protocol]
	public class WorldSendRedPacketReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007597 RID: 30103 RVA: 0x001544A8 File Offset: 0x001528A8
		public uint GetMsgID()
		{
			return 607306U;
		}

		// Token: 0x06007598 RID: 30104 RVA: 0x001544AF File Offset: 0x001528AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007599 RID: 30105 RVA: 0x001544B7 File Offset: 0x001528B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600759A RID: 30106 RVA: 0x001544C0 File Offset: 0x001528C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x0600759B RID: 30107 RVA: 0x001544DE File Offset: 0x001528DE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x0600759C RID: 30108 RVA: 0x001544FC File Offset: 0x001528FC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.num);
		}

		// Token: 0x0600759D RID: 30109 RVA: 0x0015451A File Offset: 0x0015291A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.num);
		}

		// Token: 0x0600759E RID: 30110 RVA: 0x00154538 File Offset: 0x00152938
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x040036C1 RID: 14017
		public const uint MsgID = 607306U;

		// Token: 0x040036C2 RID: 14018
		public uint Sequence;

		// Token: 0x040036C3 RID: 14019
		public ulong id;

		// Token: 0x040036C4 RID: 14020
		public byte num;
	}
}
