using System;

namespace Protocol
{
	// Token: 0x0200093F RID: 2367
	[Protocol]
	public class SceneEquipRecUpscoreReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B9B RID: 27547 RVA: 0x0013A938 File Offset: 0x00138D38
		public uint GetMsgID()
		{
			return 501012U;
		}

		// Token: 0x06006B9C RID: 27548 RVA: 0x0013A93F File Offset: 0x00138D3F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B9D RID: 27549 RVA: 0x0013A947 File Offset: 0x00138D47
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B9E RID: 27550 RVA: 0x0013A950 File Offset: 0x00138D50
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.equid);
		}

		// Token: 0x06006B9F RID: 27551 RVA: 0x0013A960 File Offset: 0x00138D60
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equid);
		}

		// Token: 0x06006BA0 RID: 27552 RVA: 0x0013A970 File Offset: 0x00138D70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.equid);
		}

		// Token: 0x06006BA1 RID: 27553 RVA: 0x0013A980 File Offset: 0x00138D80
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.equid);
		}

		// Token: 0x06006BA2 RID: 27554 RVA: 0x0013A990 File Offset: 0x00138D90
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040030C2 RID: 12482
		public const uint MsgID = 501012U;

		// Token: 0x040030C3 RID: 12483
		public uint Sequence;

		// Token: 0x040030C4 RID: 12484
		public ulong equid;
	}
}
