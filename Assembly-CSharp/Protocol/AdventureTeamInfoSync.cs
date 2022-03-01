using System;

namespace Protocol
{
	// Token: 0x02000695 RID: 1685
	[Protocol]
	public class AdventureTeamInfoSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005750 RID: 22352 RVA: 0x0010AA6F File Offset: 0x00108E6F
		public uint GetMsgID()
		{
			return 308601U;
		}

		// Token: 0x06005751 RID: 22353 RVA: 0x0010AA76 File Offset: 0x00108E76
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005752 RID: 22354 RVA: 0x0010AA7E File Offset: 0x00108E7E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005753 RID: 22355 RVA: 0x0010AA87 File Offset: 0x00108E87
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005754 RID: 22356 RVA: 0x0010AA96 File Offset: 0x00108E96
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005755 RID: 22357 RVA: 0x0010AAA5 File Offset: 0x00108EA5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005756 RID: 22358 RVA: 0x0010AAB4 File Offset: 0x00108EB4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005757 RID: 22359 RVA: 0x0010AAC4 File Offset: 0x00108EC4
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x040022B7 RID: 8887
		public const uint MsgID = 308601U;

		// Token: 0x040022B8 RID: 8888
		public uint Sequence;

		// Token: 0x040022B9 RID: 8889
		public AdventureTeamExtraInfo info = new AdventureTeamExtraInfo();
	}
}
