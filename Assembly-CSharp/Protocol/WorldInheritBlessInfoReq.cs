using System;

namespace Protocol
{
	// Token: 0x0200069A RID: 1690
	[Protocol]
	public class WorldInheritBlessInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600577D RID: 22397 RVA: 0x0010AF38 File Offset: 0x00109338
		public uint GetMsgID()
		{
			return 608605U;
		}

		// Token: 0x0600577E RID: 22398 RVA: 0x0010AF3F File Offset: 0x0010933F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600577F RID: 22399 RVA: 0x0010AF47 File Offset: 0x00109347
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005780 RID: 22400 RVA: 0x0010AF50 File Offset: 0x00109350
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005781 RID: 22401 RVA: 0x0010AF52 File Offset: 0x00109352
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005782 RID: 22402 RVA: 0x0010AF54 File Offset: 0x00109354
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005783 RID: 22403 RVA: 0x0010AF56 File Offset: 0x00109356
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005784 RID: 22404 RVA: 0x0010AF58 File Offset: 0x00109358
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040022CA RID: 8906
		public const uint MsgID = 608605U;

		// Token: 0x040022CB RID: 8907
		public uint Sequence;
	}
}
