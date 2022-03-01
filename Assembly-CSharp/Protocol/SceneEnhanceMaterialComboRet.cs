using System;

namespace Protocol
{
	// Token: 0x02000993 RID: 2451
	[Protocol]
	public class SceneEnhanceMaterialComboRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E7D RID: 28285 RVA: 0x0013FCAC File Offset: 0x0013E0AC
		public uint GetMsgID()
		{
			return 501069U;
		}

		// Token: 0x06006E7E RID: 28286 RVA: 0x0013FCB3 File Offset: 0x0013E0B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E7F RID: 28287 RVA: 0x0013FCBB File Offset: 0x0013E0BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E80 RID: 28288 RVA: 0x0013FCC4 File Offset: 0x0013E0C4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E81 RID: 28289 RVA: 0x0013FCD4 File Offset: 0x0013E0D4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E82 RID: 28290 RVA: 0x0013FCE4 File Offset: 0x0013E0E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E83 RID: 28291 RVA: 0x0013FCF4 File Offset: 0x0013E0F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E84 RID: 28292 RVA: 0x0013FD04 File Offset: 0x0013E104
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400320D RID: 12813
		public const uint MsgID = 501069U;

		// Token: 0x0400320E RID: 12814
		public uint Sequence;

		// Token: 0x0400320F RID: 12815
		public uint code;
	}
}
