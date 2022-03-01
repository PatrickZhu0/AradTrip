using System;

namespace Protocol
{
	// Token: 0x02000CAE RID: 3246
	[Protocol]
	public class WorldSetMasterQuestionnaireRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085D5 RID: 34261 RVA: 0x00176EF8 File Offset: 0x001752F8
		public uint GetMsgID()
		{
			return 601742U;
		}

		// Token: 0x060085D6 RID: 34262 RVA: 0x00176EFF File Offset: 0x001752FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085D7 RID: 34263 RVA: 0x00176F07 File Offset: 0x00175307
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085D8 RID: 34264 RVA: 0x00176F10 File Offset: 0x00175310
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060085D9 RID: 34265 RVA: 0x00176F20 File Offset: 0x00175320
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060085DA RID: 34266 RVA: 0x00176F30 File Offset: 0x00175330
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x060085DB RID: 34267 RVA: 0x00176F40 File Offset: 0x00175340
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x060085DC RID: 34268 RVA: 0x00176F50 File Offset: 0x00175350
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400401C RID: 16412
		public const uint MsgID = 601742U;

		// Token: 0x0400401D RID: 16413
		public uint Sequence;

		// Token: 0x0400401E RID: 16414
		public uint code;
	}
}
