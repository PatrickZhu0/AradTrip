using System;

namespace Protocol
{
	// Token: 0x0200098D RID: 2445
	[Protocol]
	public class SceneEquipEnhanceClearRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006E47 RID: 28231 RVA: 0x0013F904 File Offset: 0x0013DD04
		public uint GetMsgID()
		{
			return 501063U;
		}

		// Token: 0x06006E48 RID: 28232 RVA: 0x0013F90B File Offset: 0x0013DD0B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006E49 RID: 28233 RVA: 0x0013F913 File Offset: 0x0013DD13
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006E4A RID: 28234 RVA: 0x0013F91C File Offset: 0x0013DD1C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E4B RID: 28235 RVA: 0x0013F92C File Offset: 0x0013DD2C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E4C RID: 28236 RVA: 0x0013F93C File Offset: 0x0013DD3C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006E4D RID: 28237 RVA: 0x0013F94C File Offset: 0x0013DD4C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006E4E RID: 28238 RVA: 0x0013F95C File Offset: 0x0013DD5C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040031F7 RID: 12791
		public const uint MsgID = 501063U;

		// Token: 0x040031F8 RID: 12792
		public uint Sequence;

		// Token: 0x040031F9 RID: 12793
		public uint code;
	}
}
