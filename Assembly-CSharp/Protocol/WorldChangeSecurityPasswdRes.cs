using System;

namespace Protocol
{
	// Token: 0x02000B28 RID: 2856
	[Protocol]
	public class WorldChangeSecurityPasswdRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A5C RID: 31324 RVA: 0x0015F6E8 File Offset: 0x0015DAE8
		public uint GetMsgID()
		{
			return 608407U;
		}

		// Token: 0x06007A5D RID: 31325 RVA: 0x0015F6EF File Offset: 0x0015DAEF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A5E RID: 31326 RVA: 0x0015F6F7 File Offset: 0x0015DAF7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A5F RID: 31327 RVA: 0x0015F700 File Offset: 0x0015DB00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errNum);
		}

		// Token: 0x06007A60 RID: 31328 RVA: 0x0015F71E File Offset: 0x0015DB1E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errNum);
		}

		// Token: 0x06007A61 RID: 31329 RVA: 0x0015F73C File Offset: 0x0015DB3C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_uint32(buffer, ref pos_, this.errNum);
		}

		// Token: 0x06007A62 RID: 31330 RVA: 0x0015F75A File Offset: 0x0015DB5A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.errNum);
		}

		// Token: 0x06007A63 RID: 31331 RVA: 0x0015F778 File Offset: 0x0015DB78
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040039C4 RID: 14788
		public const uint MsgID = 608407U;

		// Token: 0x040039C5 RID: 14789
		public uint Sequence;

		// Token: 0x040039C6 RID: 14790
		public uint ret;

		// Token: 0x040039C7 RID: 14791
		public uint errNum;
	}
}
