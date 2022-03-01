using System;

namespace Protocol
{
	// Token: 0x020007DA RID: 2010
	[Protocol]
	public class SceneTowerWipeoutQuickFinishRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006115 RID: 24853 RVA: 0x00123764 File Offset: 0x00121B64
		public uint GetMsgID()
		{
			return 507206U;
		}

		// Token: 0x06006116 RID: 24854 RVA: 0x0012376B File Offset: 0x00121B6B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006117 RID: 24855 RVA: 0x00123773 File Offset: 0x00121B73
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006118 RID: 24856 RVA: 0x0012377C File Offset: 0x00121B7C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006119 RID: 24857 RVA: 0x0012378C File Offset: 0x00121B8C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600611A RID: 24858 RVA: 0x0012379C File Offset: 0x00121B9C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600611B RID: 24859 RVA: 0x001237AC File Offset: 0x00121BAC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600611C RID: 24860 RVA: 0x001237BC File Offset: 0x00121BBC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400287A RID: 10362
		public const uint MsgID = 507206U;

		// Token: 0x0400287B RID: 10363
		public uint Sequence;

		// Token: 0x0400287C RID: 10364
		public uint result;
	}
}
