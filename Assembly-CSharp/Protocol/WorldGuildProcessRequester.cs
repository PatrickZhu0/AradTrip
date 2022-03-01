using System;

namespace Protocol
{
	// Token: 0x02000834 RID: 2100
	[Protocol]
	public class WorldGuildProcessRequester : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006346 RID: 25414 RVA: 0x0012A39C File Offset: 0x0012879C
		public uint GetMsgID()
		{
			return 601912U;
		}

		// Token: 0x06006347 RID: 25415 RVA: 0x0012A3A3 File Offset: 0x001287A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006348 RID: 25416 RVA: 0x0012A3AB File Offset: 0x001287AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006349 RID: 25417 RVA: 0x0012A3B4 File Offset: 0x001287B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x0600634A RID: 25418 RVA: 0x0012A3D2 File Offset: 0x001287D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x0600634B RID: 25419 RVA: 0x0012A3F0 File Offset: 0x001287F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x0600634C RID: 25420 RVA: 0x0012A40E File Offset: 0x0012880E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x0600634D RID: 25421 RVA: 0x0012A42C File Offset: 0x0012882C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 1;
		}

		// Token: 0x04002C95 RID: 11413
		public const uint MsgID = 601912U;

		// Token: 0x04002C96 RID: 11414
		public uint Sequence;

		// Token: 0x04002C97 RID: 11415
		public ulong id;

		// Token: 0x04002C98 RID: 11416
		public byte agree;
	}
}
