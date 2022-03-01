using System;

namespace Protocol
{
	// Token: 0x02000AAD RID: 2733
	[Protocol]
	public class SceneReplayView : IProtocolStream, IGetMsgID
	{
		// Token: 0x060076D5 RID: 30421 RVA: 0x00157829 File Offset: 0x00155C29
		public uint GetMsgID()
		{
			return 507503U;
		}

		// Token: 0x060076D6 RID: 30422 RVA: 0x00157830 File Offset: 0x00155C30
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060076D7 RID: 30423 RVA: 0x00157838 File Offset: 0x00155C38
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060076D8 RID: 30424 RVA: 0x00157841 File Offset: 0x00155C41
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceid);
		}

		// Token: 0x060076D9 RID: 30425 RVA: 0x00157851 File Offset: 0x00155C51
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceid);
		}

		// Token: 0x060076DA RID: 30426 RVA: 0x00157861 File Offset: 0x00155C61
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceid);
		}

		// Token: 0x060076DB RID: 30427 RVA: 0x00157871 File Offset: 0x00155C71
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceid);
		}

		// Token: 0x060076DC RID: 30428 RVA: 0x00157884 File Offset: 0x00155C84
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x0400379E RID: 14238
		public const uint MsgID = 507503U;

		// Token: 0x0400379F RID: 14239
		public uint Sequence;

		// Token: 0x040037A0 RID: 14240
		public ulong raceid;
	}
}
