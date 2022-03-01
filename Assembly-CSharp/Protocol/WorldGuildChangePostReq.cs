using System;

namespace Protocol
{
	// Token: 0x02000836 RID: 2102
	[Protocol]
	public class WorldGuildChangePostReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006358 RID: 25432 RVA: 0x0012A50E File Offset: 0x0012890E
		public uint GetMsgID()
		{
			return 601914U;
		}

		// Token: 0x06006359 RID: 25433 RVA: 0x0012A515 File Offset: 0x00128915
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600635A RID: 25434 RVA: 0x0012A51D File Offset: 0x0012891D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600635B RID: 25435 RVA: 0x0012A526 File Offset: 0x00128926
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.post);
			BaseDLL.encode_uint64(buffer, ref pos_, this.replacerId);
		}

		// Token: 0x0600635C RID: 25436 RVA: 0x0012A552 File Offset: 0x00128952
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.post);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.replacerId);
		}

		// Token: 0x0600635D RID: 25437 RVA: 0x0012A57E File Offset: 0x0012897E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.post);
			BaseDLL.encode_uint64(buffer, ref pos_, this.replacerId);
		}

		// Token: 0x0600635E RID: 25438 RVA: 0x0012A5AA File Offset: 0x001289AA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.post);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.replacerId);
		}

		// Token: 0x0600635F RID: 25439 RVA: 0x0012A5D8 File Offset: 0x001289D8
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			return num + 8;
		}

		// Token: 0x04002C9D RID: 11421
		public const uint MsgID = 601914U;

		// Token: 0x04002C9E RID: 11422
		public uint Sequence;

		// Token: 0x04002C9F RID: 11423
		public ulong id;

		// Token: 0x04002CA0 RID: 11424
		public byte post;

		// Token: 0x04002CA1 RID: 11425
		public ulong replacerId;
	}
}
