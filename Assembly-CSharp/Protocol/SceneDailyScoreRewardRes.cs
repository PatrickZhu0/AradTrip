using System;

namespace Protocol
{
	// Token: 0x02000C65 RID: 3173
	[Protocol]
	public class SceneDailyScoreRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008398 RID: 33688 RVA: 0x00171A68 File Offset: 0x0016FE68
		public uint GetMsgID()
		{
			return 501140U;
		}

		// Token: 0x06008399 RID: 33689 RVA: 0x00171A6F File Offset: 0x0016FE6F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600839A RID: 33690 RVA: 0x00171A77 File Offset: 0x0016FE77
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600839B RID: 33691 RVA: 0x00171A80 File Offset: 0x0016FE80
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600839C RID: 33692 RVA: 0x00171A90 File Offset: 0x0016FE90
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600839D RID: 33693 RVA: 0x00171AA0 File Offset: 0x0016FEA0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600839E RID: 33694 RVA: 0x00171AB0 File Offset: 0x0016FEB0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600839F RID: 33695 RVA: 0x00171AC0 File Offset: 0x0016FEC0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003EE8 RID: 16104
		public const uint MsgID = 501140U;

		// Token: 0x04003EE9 RID: 16105
		public uint Sequence;

		// Token: 0x04003EEA RID: 16106
		public uint result;
	}
}
