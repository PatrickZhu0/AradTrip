using System;

namespace Protocol
{
	// Token: 0x02000719 RID: 1817
	[Protocol]
	public class SceneBattlePlaceTrapsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B54 RID: 23380 RVA: 0x00114FEC File Offset: 0x001133EC
		public uint GetMsgID()
		{
			return 508934U;
		}

		// Token: 0x06005B55 RID: 23381 RVA: 0x00114FF3 File Offset: 0x001133F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B56 RID: 23382 RVA: 0x00114FFB File Offset: 0x001133FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B57 RID: 23383 RVA: 0x00115004 File Offset: 0x00113404
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005B58 RID: 23384 RVA: 0x00115014 File Offset: 0x00113414
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005B59 RID: 23385 RVA: 0x00115024 File Offset: 0x00113424
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06005B5A RID: 23386 RVA: 0x00115034 File Offset: 0x00113434
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06005B5B RID: 23387 RVA: 0x00115044 File Offset: 0x00113444
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400253B RID: 9531
		public const uint MsgID = 508934U;

		// Token: 0x0400253C RID: 9532
		public uint Sequence;

		// Token: 0x0400253D RID: 9533
		public uint retCode;
	}
}
