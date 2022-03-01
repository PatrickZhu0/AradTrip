using System;

namespace Protocol
{
	// Token: 0x02000B3C RID: 2876
	[Protocol]
	public class SceneChangeOccu : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007AE3 RID: 31459 RVA: 0x0016065C File Offset: 0x0015EA5C
		public uint GetMsgID()
		{
			return 501212U;
		}

		// Token: 0x06007AE4 RID: 31460 RVA: 0x00160663 File Offset: 0x0015EA63
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007AE5 RID: 31461 RVA: 0x0016066B File Offset: 0x0015EA6B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007AE6 RID: 31462 RVA: 0x00160674 File Offset: 0x0015EA74
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
		}

		// Token: 0x06007AE7 RID: 31463 RVA: 0x00160684 File Offset: 0x0015EA84
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
		}

		// Token: 0x06007AE8 RID: 31464 RVA: 0x00160694 File Offset: 0x0015EA94
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
		}

		// Token: 0x06007AE9 RID: 31465 RVA: 0x001606A4 File Offset: 0x0015EAA4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
		}

		// Token: 0x06007AEA RID: 31466 RVA: 0x001606B4 File Offset: 0x0015EAB4
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003A3E RID: 14910
		public const uint MsgID = 501212U;

		// Token: 0x04003A3F RID: 14911
		public uint Sequence;

		// Token: 0x04003A40 RID: 14912
		public byte occu;
	}
}
