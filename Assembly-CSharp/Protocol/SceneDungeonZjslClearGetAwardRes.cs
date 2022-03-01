using System;

namespace Protocol
{
	// Token: 0x020007EC RID: 2028
	[Protocol]
	public class SceneDungeonZjslClearGetAwardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061B7 RID: 25015 RVA: 0x00124380 File Offset: 0x00122780
		public uint GetMsgID()
		{
			return 506841U;
		}

		// Token: 0x060061B8 RID: 25016 RVA: 0x00124387 File Offset: 0x00122787
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061B9 RID: 25017 RVA: 0x0012438F File Offset: 0x0012278F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061BA RID: 25018 RVA: 0x00124398 File Offset: 0x00122798
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060061BB RID: 25019 RVA: 0x001243A8 File Offset: 0x001227A8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060061BC RID: 25020 RVA: 0x001243B8 File Offset: 0x001227B8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060061BD RID: 25021 RVA: 0x001243C8 File Offset: 0x001227C8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060061BE RID: 25022 RVA: 0x001243D8 File Offset: 0x001227D8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040028B2 RID: 10418
		public const uint MsgID = 506841U;

		// Token: 0x040028B3 RID: 10419
		public uint Sequence;

		// Token: 0x040028B4 RID: 10420
		public uint result;
	}
}
