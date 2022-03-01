using System;

namespace Protocol
{
	// Token: 0x02000A86 RID: 2694
	[Protocol]
	public class WorldSendCustomRedPacketRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075C4 RID: 30148 RVA: 0x001548B8 File Offset: 0x00152CB8
		public uint GetMsgID()
		{
			return 607311U;
		}

		// Token: 0x060075C5 RID: 30149 RVA: 0x001548BF File Offset: 0x00152CBF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075C6 RID: 30150 RVA: 0x001548C7 File Offset: 0x00152CC7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075C7 RID: 30151 RVA: 0x001548D0 File Offset: 0x00152CD0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.redPacketId);
		}

		// Token: 0x060075C8 RID: 30152 RVA: 0x001548EE File Offset: 0x00152CEE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.redPacketId);
		}

		// Token: 0x060075C9 RID: 30153 RVA: 0x0015490C File Offset: 0x00152D0C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.redPacketId);
		}

		// Token: 0x060075CA RID: 30154 RVA: 0x0015492A File Offset: 0x00152D2A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.redPacketId);
		}

		// Token: 0x060075CB RID: 30155 RVA: 0x00154948 File Offset: 0x00152D48
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x040036D4 RID: 14036
		public const uint MsgID = 607311U;

		// Token: 0x040036D5 RID: 14037
		public uint Sequence;

		// Token: 0x040036D6 RID: 14038
		public uint result;

		// Token: 0x040036D7 RID: 14039
		public ulong redPacketId;
	}
}
