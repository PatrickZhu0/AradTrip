using System;

namespace Protocol
{
	// Token: 0x02000A9E RID: 2718
	[Protocol]
	public class RelaySvrFrameChecksumRequest : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600766F RID: 30319 RVA: 0x00156868 File Offset: 0x00154C68
		public uint GetMsgID()
		{
			return 1300011U;
		}

		// Token: 0x06007670 RID: 30320 RVA: 0x0015686F File Offset: 0x00154C6F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007671 RID: 30321 RVA: 0x00156877 File Offset: 0x00154C77
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007672 RID: 30322 RVA: 0x00156880 File Offset: 0x00154C80
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.frame);
			BaseDLL.encode_uint32(buffer, ref pos_, this.checksum);
		}

		// Token: 0x06007673 RID: 30323 RVA: 0x0015689E File Offset: 0x00154C9E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.frame);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.checksum);
		}

		// Token: 0x06007674 RID: 30324 RVA: 0x001568BC File Offset: 0x00154CBC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.frame);
			BaseDLL.encode_uint32(buffer, ref pos_, this.checksum);
		}

		// Token: 0x06007675 RID: 30325 RVA: 0x001568DA File Offset: 0x00154CDA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.frame);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.checksum);
		}

		// Token: 0x06007676 RID: 30326 RVA: 0x001568F8 File Offset: 0x00154CF8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003759 RID: 14169
		public const uint MsgID = 1300011U;

		// Token: 0x0400375A RID: 14170
		public uint Sequence;

		// Token: 0x0400375B RID: 14171
		public uint frame;

		// Token: 0x0400375C RID: 14172
		public uint checksum;
	}
}
