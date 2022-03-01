using System;

namespace Protocol
{
	// Token: 0x0200082E RID: 2094
	[Protocol]
	public class WorldJoinGuildRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006310 RID: 25360 RVA: 0x00129E28 File Offset: 0x00128228
		public uint GetMsgID()
		{
			return 601906U;
		}

		// Token: 0x06006311 RID: 25361 RVA: 0x00129E2F File Offset: 0x0012822F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006312 RID: 25362 RVA: 0x00129E37 File Offset: 0x00128237
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006313 RID: 25363 RVA: 0x00129E40 File Offset: 0x00128240
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006314 RID: 25364 RVA: 0x00129E50 File Offset: 0x00128250
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006315 RID: 25365 RVA: 0x00129E60 File Offset: 0x00128260
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006316 RID: 25366 RVA: 0x00129E70 File Offset: 0x00128270
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006317 RID: 25367 RVA: 0x00129E80 File Offset: 0x00128280
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002C82 RID: 11394
		public const uint MsgID = 601906U;

		// Token: 0x04002C83 RID: 11395
		public uint Sequence;

		// Token: 0x04002C84 RID: 11396
		public uint result;
	}
}
