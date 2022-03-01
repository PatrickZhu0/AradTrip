using System;

namespace Protocol
{
	// Token: 0x02000A51 RID: 2641
	[Protocol]
	public class SceneDeletePet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600742F RID: 29743 RVA: 0x00150F90 File Offset: 0x0014F390
		public uint GetMsgID()
		{
			return 502203U;
		}

		// Token: 0x06007430 RID: 29744 RVA: 0x00150F97 File Offset: 0x0014F397
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007431 RID: 29745 RVA: 0x00150F9F File Offset: 0x0014F39F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007432 RID: 29746 RVA: 0x00150FA8 File Offset: 0x0014F3A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007433 RID: 29747 RVA: 0x00150FB8 File Offset: 0x0014F3B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007434 RID: 29748 RVA: 0x00150FC8 File Offset: 0x0014F3C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007435 RID: 29749 RVA: 0x00150FD8 File Offset: 0x0014F3D8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007436 RID: 29750 RVA: 0x00150FE8 File Offset: 0x0014F3E8
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x040035F4 RID: 13812
		public const uint MsgID = 502203U;

		// Token: 0x040035F5 RID: 13813
		public uint Sequence;

		// Token: 0x040035F6 RID: 13814
		public ulong id;
	}
}
