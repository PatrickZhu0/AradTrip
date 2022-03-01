using System;

namespace Protocol
{
	// Token: 0x0200089D RID: 2205
	[Protocol]
	public class WorldGuildMergerRequestOperatorReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066E2 RID: 26338 RVA: 0x00130675 File Offset: 0x0012EA75
		public uint GetMsgID()
		{
			return 601979U;
		}

		// Token: 0x060066E3 RID: 26339 RVA: 0x0013067C File Offset: 0x0012EA7C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066E4 RID: 26340 RVA: 0x00130684 File Offset: 0x0012EA84
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066E5 RID: 26341 RVA: 0x0013068D File Offset: 0x0012EA8D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x060066E6 RID: 26342 RVA: 0x001306AB File Offset: 0x0012EAAB
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x060066E7 RID: 26343 RVA: 0x001306C9 File Offset: 0x0012EAC9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guildId);
			BaseDLL.encode_int8(buffer, ref pos_, this.opType);
		}

		// Token: 0x060066E8 RID: 26344 RVA: 0x001306E7 File Offset: 0x0012EAE7
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guildId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.opType);
		}

		// Token: 0x060066E9 RID: 26345 RVA: 0x00130708 File Offset: 0x0012EB08
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04002E03 RID: 11779
		public const uint MsgID = 601979U;

		// Token: 0x04002E04 RID: 11780
		public uint Sequence;

		// Token: 0x04002E05 RID: 11781
		public ulong guildId;

		// Token: 0x04002E06 RID: 11782
		public byte opType;
	}
}
