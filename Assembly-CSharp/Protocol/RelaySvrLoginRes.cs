using System;

namespace Protocol
{
	// Token: 0x02000A8D RID: 2701
	[Protocol]
	public class RelaySvrLoginRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060075F1 RID: 30193 RVA: 0x001550D0 File Offset: 0x001534D0
		public uint GetMsgID()
		{
			return 1300002U;
		}

		// Token: 0x060075F2 RID: 30194 RVA: 0x001550D7 File Offset: 0x001534D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060075F3 RID: 30195 RVA: 0x001550DF File Offset: 0x001534DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060075F4 RID: 30196 RVA: 0x001550E8 File Offset: 0x001534E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.currentTime);
		}

		// Token: 0x060075F5 RID: 30197 RVA: 0x00155106 File Offset: 0x00153506
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.currentTime);
		}

		// Token: 0x060075F6 RID: 30198 RVA: 0x00155124 File Offset: 0x00153524
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.currentTime);
		}

		// Token: 0x060075F7 RID: 30199 RVA: 0x00155142 File Offset: 0x00153542
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.currentTime);
		}

		// Token: 0x060075F8 RID: 30200 RVA: 0x00155160 File Offset: 0x00153560
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x04003711 RID: 14097
		public const uint MsgID = 1300002U;

		// Token: 0x04003712 RID: 14098
		public uint Sequence;

		// Token: 0x04003713 RID: 14099
		public uint result;

		// Token: 0x04003714 RID: 14100
		public ulong currentTime;
	}
}
