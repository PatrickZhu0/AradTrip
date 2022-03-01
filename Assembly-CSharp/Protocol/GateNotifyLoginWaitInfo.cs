using System;

namespace Protocol
{
	// Token: 0x020009CC RID: 2508
	[Protocol]
	public class GateNotifyLoginWaitInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007054 RID: 28756 RVA: 0x00145364 File Offset: 0x00143764
		public uint GetMsgID()
		{
			return 300316U;
		}

		// Token: 0x06007055 RID: 28757 RVA: 0x0014536B File Offset: 0x0014376B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007056 RID: 28758 RVA: 0x00145373 File Offset: 0x00143773
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007057 RID: 28759 RVA: 0x0014537C File Offset: 0x0014377C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.waitPlayerNum);
		}

		// Token: 0x06007058 RID: 28760 RVA: 0x0014538C File Offset: 0x0014378C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.waitPlayerNum);
		}

		// Token: 0x06007059 RID: 28761 RVA: 0x0014539C File Offset: 0x0014379C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.waitPlayerNum);
		}

		// Token: 0x0600705A RID: 28762 RVA: 0x001453AC File Offset: 0x001437AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.waitPlayerNum);
		}

		// Token: 0x0600705B RID: 28763 RVA: 0x001453BC File Offset: 0x001437BC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003331 RID: 13105
		public const uint MsgID = 300316U;

		// Token: 0x04003332 RID: 13106
		public uint Sequence;

		// Token: 0x04003333 RID: 13107
		public uint waitPlayerNum;
	}
}
