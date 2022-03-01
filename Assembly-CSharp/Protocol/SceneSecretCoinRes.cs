using System;

namespace Protocol
{
	// Token: 0x0200068F RID: 1679
	[Protocol]
	public class SceneSecretCoinRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600572F RID: 22319 RVA: 0x0010A1F0 File Offset: 0x001085F0
		public uint GetMsgID()
		{
			return 501168U;
		}

		// Token: 0x06005730 RID: 22320 RVA: 0x0010A1F7 File Offset: 0x001085F7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005731 RID: 22321 RVA: 0x0010A1FF File Offset: 0x001085FF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005732 RID: 22322 RVA: 0x0010A208 File Offset: 0x00108608
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.coin);
		}

		// Token: 0x06005733 RID: 22323 RVA: 0x0010A218 File Offset: 0x00108618
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.coin);
		}

		// Token: 0x06005734 RID: 22324 RVA: 0x0010A228 File Offset: 0x00108628
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.coin);
		}

		// Token: 0x06005735 RID: 22325 RVA: 0x0010A238 File Offset: 0x00108638
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.coin);
		}

		// Token: 0x06005736 RID: 22326 RVA: 0x0010A248 File Offset: 0x00108648
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400229D RID: 8861
		public const uint MsgID = 501168U;

		// Token: 0x0400229E RID: 8862
		public uint Sequence;

		// Token: 0x0400229F RID: 8863
		public uint coin;
	}
}
