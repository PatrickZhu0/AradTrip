using System;

namespace Protocol
{
	// Token: 0x02000CAF RID: 3247
	[Protocol]
	public class WorldNotifyNewMasterSectRelation : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085DE RID: 34270 RVA: 0x00176F6C File Offset: 0x0017536C
		public uint GetMsgID()
		{
			return 601743U;
		}

		// Token: 0x060085DF RID: 34271 RVA: 0x00176F73 File Offset: 0x00175373
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085E0 RID: 34272 RVA: 0x00176F7B File Offset: 0x0017537B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085E1 RID: 34273 RVA: 0x00176F84 File Offset: 0x00175384
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085E2 RID: 34274 RVA: 0x00176F86 File Offset: 0x00175386
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060085E3 RID: 34275 RVA: 0x00176F88 File Offset: 0x00175388
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085E4 RID: 34276 RVA: 0x00176F8A File Offset: 0x0017538A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060085E5 RID: 34277 RVA: 0x00176F8C File Offset: 0x0017538C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400401F RID: 16415
		public const uint MsgID = 601743U;

		// Token: 0x04004020 RID: 16416
		public uint Sequence;
	}
}
