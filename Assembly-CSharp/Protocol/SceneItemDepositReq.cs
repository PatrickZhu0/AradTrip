using System;

namespace Protocol
{
	// Token: 0x02000980 RID: 2432
	[Protocol]
	public class SceneItemDepositReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DD5 RID: 28117 RVA: 0x0013EA5D File Offset: 0x0013CE5D
		public uint GetMsgID()
		{
			return 501050U;
		}

		// Token: 0x06006DD6 RID: 28118 RVA: 0x0013EA64 File Offset: 0x0013CE64
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006DD7 RID: 28119 RVA: 0x0013EA6C File Offset: 0x0013CE6C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006DD8 RID: 28120 RVA: 0x0013EA75 File Offset: 0x0013CE75
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006DD9 RID: 28121 RVA: 0x0013EA77 File Offset: 0x0013CE77
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006DDA RID: 28122 RVA: 0x0013EA79 File Offset: 0x0013CE79
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006DDB RID: 28123 RVA: 0x0013EA7B File Offset: 0x0013CE7B
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006DDC RID: 28124 RVA: 0x0013EA80 File Offset: 0x0013CE80
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040031BD RID: 12733
		public const uint MsgID = 501050U;

		// Token: 0x040031BE RID: 12734
		public uint Sequence;
	}
}
