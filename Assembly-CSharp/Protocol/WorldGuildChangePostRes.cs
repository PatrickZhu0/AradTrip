using System;

namespace Protocol
{
	// Token: 0x02000837 RID: 2103
	[Protocol]
	public class WorldGuildChangePostRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006361 RID: 25441 RVA: 0x0012A5FC File Offset: 0x001289FC
		public uint GetMsgID()
		{
			return 601915U;
		}

		// Token: 0x06006362 RID: 25442 RVA: 0x0012A603 File Offset: 0x00128A03
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006363 RID: 25443 RVA: 0x0012A60B File Offset: 0x00128A0B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006364 RID: 25444 RVA: 0x0012A614 File Offset: 0x00128A14
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006365 RID: 25445 RVA: 0x0012A624 File Offset: 0x00128A24
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006366 RID: 25446 RVA: 0x0012A634 File Offset: 0x00128A34
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006367 RID: 25447 RVA: 0x0012A644 File Offset: 0x00128A44
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006368 RID: 25448 RVA: 0x0012A654 File Offset: 0x00128A54
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002CA2 RID: 11426
		public const uint MsgID = 601915U;

		// Token: 0x04002CA3 RID: 11427
		public uint Sequence;

		// Token: 0x04002CA4 RID: 11428
		public uint result;
	}
}
