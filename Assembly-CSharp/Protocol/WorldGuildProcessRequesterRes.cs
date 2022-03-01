using System;

namespace Protocol
{
	// Token: 0x02000835 RID: 2101
	[Protocol]
	public class WorldGuildProcessRequesterRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600634F RID: 25423 RVA: 0x0012A457 File Offset: 0x00128857
		public uint GetMsgID()
		{
			return 601913U;
		}

		// Token: 0x06006350 RID: 25424 RVA: 0x0012A45E File Offset: 0x0012885E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006351 RID: 25425 RVA: 0x0012A466 File Offset: 0x00128866
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006352 RID: 25426 RVA: 0x0012A46F File Offset: 0x0012886F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.entry.encode(buffer, ref pos_);
		}

		// Token: 0x06006353 RID: 25427 RVA: 0x0012A48C File Offset: 0x0012888C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.entry.decode(buffer, ref pos_);
		}

		// Token: 0x06006354 RID: 25428 RVA: 0x0012A4A9 File Offset: 0x001288A9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			this.entry.encode(buffer, ref pos_);
		}

		// Token: 0x06006355 RID: 25429 RVA: 0x0012A4C6 File Offset: 0x001288C6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			this.entry.decode(buffer, ref pos_);
		}

		// Token: 0x06006356 RID: 25430 RVA: 0x0012A4E4 File Offset: 0x001288E4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.entry.getLen();
		}

		// Token: 0x04002C99 RID: 11417
		public const uint MsgID = 601913U;

		// Token: 0x04002C9A RID: 11418
		public uint Sequence;

		// Token: 0x04002C9B RID: 11419
		public uint result;

		// Token: 0x04002C9C RID: 11420
		public GuildMemberEntry entry = new GuildMemberEntry();
	}
}
