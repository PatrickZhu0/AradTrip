using System;

namespace Protocol
{
	// Token: 0x02000B9E RID: 2974
	[Protocol]
	public class SceneTeamMatchStartReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DE9 RID: 32233 RVA: 0x00165B90 File Offset: 0x00163F90
		public uint GetMsgID()
		{
			return 501604U;
		}

		// Token: 0x06007DEA RID: 32234 RVA: 0x00165B97 File Offset: 0x00163F97
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DEB RID: 32235 RVA: 0x00165B9F File Offset: 0x00163F9F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DEC RID: 32236 RVA: 0x00165BA8 File Offset: 0x00163FA8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06007DED RID: 32237 RVA: 0x00165BB8 File Offset: 0x00163FB8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06007DEE RID: 32238 RVA: 0x00165BC8 File Offset: 0x00163FC8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
		}

		// Token: 0x06007DEF RID: 32239 RVA: 0x00165BD8 File Offset: 0x00163FD8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
		}

		// Token: 0x06007DF0 RID: 32240 RVA: 0x00165BE8 File Offset: 0x00163FE8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003BA9 RID: 15273
		public const uint MsgID = 501604U;

		// Token: 0x04003BAA RID: 15274
		public uint Sequence;

		// Token: 0x04003BAB RID: 15275
		public uint dungeonId;
	}
}
