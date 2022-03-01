using System;

namespace Protocol
{
	// Token: 0x0200094C RID: 2380
	[Protocol]
	public class GambingMineQueryReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C10 RID: 27664 RVA: 0x0013B385 File Offset: 0x00139785
		public uint GetMsgID()
		{
			return 707905U;
		}

		// Token: 0x06006C11 RID: 27665 RVA: 0x0013B38C File Offset: 0x0013978C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C12 RID: 27666 RVA: 0x0013B394 File Offset: 0x00139794
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C13 RID: 27667 RVA: 0x0013B39D File Offset: 0x0013979D
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006C14 RID: 27668 RVA: 0x0013B39F File Offset: 0x0013979F
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006C15 RID: 27669 RVA: 0x0013B3A1 File Offset: 0x001397A1
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006C16 RID: 27670 RVA: 0x0013B3A3 File Offset: 0x001397A3
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006C17 RID: 27671 RVA: 0x0013B3A8 File Offset: 0x001397A8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040030F0 RID: 12528
		public const uint MsgID = 707905U;

		// Token: 0x040030F1 RID: 12529
		public uint Sequence;
	}
}
