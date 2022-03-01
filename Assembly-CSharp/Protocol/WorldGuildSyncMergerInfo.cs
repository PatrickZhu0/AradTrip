using System;

namespace Protocol
{
	// Token: 0x020008A5 RID: 2213
	[Protocol]
	public class WorldGuildSyncMergerInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600672A RID: 26410 RVA: 0x00130BD0 File Offset: 0x0012EFD0
		public uint GetMsgID()
		{
			return 601987U;
		}

		// Token: 0x0600672B RID: 26411 RVA: 0x00130BD7 File Offset: 0x0012EFD7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600672C RID: 26412 RVA: 0x00130BDF File Offset: 0x0012EFDF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600672D RID: 26413 RVA: 0x00130BE8 File Offset: 0x0012EFE8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.prosperityStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.mergerRequsetStatus);
		}

		// Token: 0x0600672E RID: 26414 RVA: 0x00130C06 File Offset: 0x0012F006
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.prosperityStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mergerRequsetStatus);
		}

		// Token: 0x0600672F RID: 26415 RVA: 0x00130C24 File Offset: 0x0012F024
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.prosperityStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.mergerRequsetStatus);
		}

		// Token: 0x06006730 RID: 26416 RVA: 0x00130C42 File Offset: 0x0012F042
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.prosperityStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mergerRequsetStatus);
		}

		// Token: 0x06006731 RID: 26417 RVA: 0x00130C60 File Offset: 0x0012F060
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 1;
		}

		// Token: 0x04002E1D RID: 11805
		public const uint MsgID = 601987U;

		// Token: 0x04002E1E RID: 11806
		public uint Sequence;

		// Token: 0x04002E1F RID: 11807
		public byte prosperityStatus;

		// Token: 0x04002E20 RID: 11808
		public byte mergerRequsetStatus;
	}
}
