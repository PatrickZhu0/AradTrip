using System;

namespace Protocol
{
	// Token: 0x020006EB RID: 1771
	public class PlayerLabelInfo : IProtocolStream
	{
		// Token: 0x060059CB RID: 22987 RVA: 0x00110C74 File Offset: 0x0010F074
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.awakenStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.returnStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.noviceGuideChooseFlag);
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrame);
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.returnAnniversaryTitle);
		}

		// Token: 0x060059CC RID: 22988 RVA: 0x00110CD8 File Offset: 0x0010F0D8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.awakenStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.returnStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.noviceGuideChooseFlag);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrame);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.returnAnniversaryTitle);
		}

		// Token: 0x060059CD RID: 22989 RVA: 0x00110D3C File Offset: 0x0010F13C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.awakenStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.returnStatus);
			BaseDLL.encode_int8(buffer, ref pos_, this.noviceGuideChooseFlag);
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrame);
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.returnAnniversaryTitle);
		}

		// Token: 0x060059CE RID: 22990 RVA: 0x00110DA0 File Offset: 0x0010F1A0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.awakenStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.returnStatus);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.noviceGuideChooseFlag);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrame);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.returnAnniversaryTitle);
		}

		// Token: 0x060059CF RID: 22991 RVA: 0x00110E04 File Offset: 0x0010F204
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num++;
			num += 4;
			num += 8;
			return num + 4;
		}

		// Token: 0x04002444 RID: 9284
		public byte awakenStatus;

		// Token: 0x04002445 RID: 9285
		public byte returnStatus;

		// Token: 0x04002446 RID: 9286
		public byte noviceGuideChooseFlag;

		// Token: 0x04002447 RID: 9287
		public uint headFrame;

		// Token: 0x04002448 RID: 9288
		public ulong guildId;

		// Token: 0x04002449 RID: 9289
		public uint returnAnniversaryTitle;
	}
}
