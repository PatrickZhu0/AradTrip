using System;

namespace Protocol
{
	// Token: 0x020006DB RID: 1755
	[Protocol]
	public class WorldAuctionAttentReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600595F RID: 22879 RVA: 0x0010FC26 File Offset: 0x0010E026
		public uint GetMsgID()
		{
			return 603929U;
		}

		// Token: 0x06005960 RID: 22880 RVA: 0x0010FC2D File Offset: 0x0010E02D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005961 RID: 22881 RVA: 0x0010FC35 File Offset: 0x0010E035
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005962 RID: 22882 RVA: 0x0010FC3E File Offset: 0x0010E03E
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.autionGuid);
		}

		// Token: 0x06005963 RID: 22883 RVA: 0x0010FC4E File Offset: 0x0010E04E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.autionGuid);
		}

		// Token: 0x06005964 RID: 22884 RVA: 0x0010FC5E File Offset: 0x0010E05E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.autionGuid);
		}

		// Token: 0x06005965 RID: 22885 RVA: 0x0010FC6E File Offset: 0x0010E06E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.autionGuid);
		}

		// Token: 0x06005966 RID: 22886 RVA: 0x0010FC80 File Offset: 0x0010E080
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040023F9 RID: 9209
		public const uint MsgID = 603929U;

		// Token: 0x040023FA RID: 9210
		public uint Sequence;

		// Token: 0x040023FB RID: 9211
		public ulong autionGuid;
	}
}
