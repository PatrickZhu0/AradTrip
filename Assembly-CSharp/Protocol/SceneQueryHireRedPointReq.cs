using System;

namespace Protocol
{
	// Token: 0x02000C47 RID: 3143
	[Protocol]
	public class SceneQueryHireRedPointReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082D8 RID: 33496 RVA: 0x00170324 File Offset: 0x0016E724
		public uint GetMsgID()
		{
			return 501729U;
		}

		// Token: 0x060082D9 RID: 33497 RVA: 0x0017032B File Offset: 0x0016E72B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082DA RID: 33498 RVA: 0x00170333 File Offset: 0x0016E733
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082DB RID: 33499 RVA: 0x0017033C File Offset: 0x0016E73C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060082DC RID: 33500 RVA: 0x0017033E File Offset: 0x0016E73E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060082DD RID: 33501 RVA: 0x00170340 File Offset: 0x0016E740
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060082DE RID: 33502 RVA: 0x00170342 File Offset: 0x0016E742
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060082DF RID: 33503 RVA: 0x00170344 File Offset: 0x0016E744
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003E72 RID: 15986
		public const uint MsgID = 501729U;

		// Token: 0x04003E73 RID: 15987
		public uint Sequence;
	}
}
