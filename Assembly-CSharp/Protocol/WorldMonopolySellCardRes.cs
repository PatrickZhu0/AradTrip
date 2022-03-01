using System;

namespace Protocol
{
	// Token: 0x02000A16 RID: 2582
	[Protocol]
	public class WorldMonopolySellCardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007288 RID: 29320 RVA: 0x0014B9A0 File Offset: 0x00149DA0
		public uint GetMsgID()
		{
			return 610212U;
		}

		// Token: 0x06007289 RID: 29321 RVA: 0x0014B9A7 File Offset: 0x00149DA7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600728A RID: 29322 RVA: 0x0014B9AF File Offset: 0x00149DAF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600728B RID: 29323 RVA: 0x0014B9B8 File Offset: 0x00149DB8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x0600728C RID: 29324 RVA: 0x0014B9C8 File Offset: 0x00149DC8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x0600728D RID: 29325 RVA: 0x0014B9D8 File Offset: 0x00149DD8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.errorCode);
		}

		// Token: 0x0600728E RID: 29326 RVA: 0x0014B9E8 File Offset: 0x00149DE8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errorCode);
		}

		// Token: 0x0600728F RID: 29327 RVA: 0x0014B9F8 File Offset: 0x00149DF8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400349E RID: 13470
		public const uint MsgID = 610212U;

		// Token: 0x0400349F RID: 13471
		public uint Sequence;

		// Token: 0x040034A0 RID: 13472
		public uint errorCode;
	}
}
