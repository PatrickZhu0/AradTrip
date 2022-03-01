using System;

namespace Protocol
{
	// Token: 0x02000A56 RID: 2646
	[Protocol]
	public class SceneSellPetReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600745C RID: 29788 RVA: 0x00151488 File Offset: 0x0014F888
		public uint GetMsgID()
		{
			return 502209U;
		}

		// Token: 0x0600745D RID: 29789 RVA: 0x0015148F File Offset: 0x0014F88F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600745E RID: 29790 RVA: 0x00151497 File Offset: 0x0014F897
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600745F RID: 29791 RVA: 0x001514A0 File Offset: 0x0014F8A0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007460 RID: 29792 RVA: 0x001514B0 File Offset: 0x0014F8B0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007461 RID: 29793 RVA: 0x001514C0 File Offset: 0x0014F8C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x06007462 RID: 29794 RVA: 0x001514D0 File Offset: 0x0014F8D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007463 RID: 29795 RVA: 0x001514E0 File Offset: 0x0014F8E0
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x0400360A RID: 13834
		public const uint MsgID = 502209U;

		// Token: 0x0400360B RID: 13835
		public uint Sequence;

		// Token: 0x0400360C RID: 13836
		public ulong id;
	}
}
