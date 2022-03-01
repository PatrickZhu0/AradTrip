using System;

namespace Protocol
{
	// Token: 0x02000A07 RID: 2567
	[Protocol]
	public class SceneSyncSeasonLevel : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007204 RID: 29188 RVA: 0x0014AE6D File Offset: 0x0014926D
		public uint GetMsgID()
		{
			return 506711U;
		}

		// Token: 0x06007205 RID: 29189 RVA: 0x0014AE74 File Offset: 0x00149274
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007206 RID: 29190 RVA: 0x0014AE7C File Offset: 0x0014927C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007207 RID: 29191 RVA: 0x0014AE85 File Offset: 0x00149285
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
		}

		// Token: 0x06007208 RID: 29192 RVA: 0x0014AEBF File Offset: 0x001492BF
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
		}

		// Token: 0x06007209 RID: 29193 RVA: 0x0014AEF9 File Offset: 0x001492F9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.oldSeasonStar);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
		}

		// Token: 0x0600720A RID: 29194 RVA: 0x0014AF33 File Offset: 0x00149333
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.oldSeasonStar);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
		}

		// Token: 0x0600720B RID: 29195 RVA: 0x0014AF70 File Offset: 0x00149370
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003466 RID: 13414
		public const uint MsgID = 506711U;

		// Token: 0x04003467 RID: 13415
		public uint Sequence;

		// Token: 0x04003468 RID: 13416
		public uint oldSeasonLevel;

		// Token: 0x04003469 RID: 13417
		public uint oldSeasonStar;

		// Token: 0x0400346A RID: 13418
		public uint seasonLevel;

		// Token: 0x0400346B RID: 13419
		public uint seasonStar;
	}
}
