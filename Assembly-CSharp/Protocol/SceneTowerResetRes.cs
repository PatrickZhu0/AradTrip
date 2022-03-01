using System;

namespace Protocol
{
	// Token: 0x020007DC RID: 2012
	[Protocol]
	public class SceneTowerResetRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006127 RID: 24871 RVA: 0x00123810 File Offset: 0x00121C10
		public uint GetMsgID()
		{
			return 507208U;
		}

		// Token: 0x06006128 RID: 24872 RVA: 0x00123817 File Offset: 0x00121C17
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006129 RID: 24873 RVA: 0x0012381F File Offset: 0x00121C1F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600612A RID: 24874 RVA: 0x00123828 File Offset: 0x00121C28
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600612B RID: 24875 RVA: 0x00123838 File Offset: 0x00121C38
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600612C RID: 24876 RVA: 0x00123848 File Offset: 0x00121C48
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600612D RID: 24877 RVA: 0x00123858 File Offset: 0x00121C58
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600612E RID: 24878 RVA: 0x00123868 File Offset: 0x00121C68
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400287F RID: 10367
		public const uint MsgID = 507208U;

		// Token: 0x04002880 RID: 10368
		public uint Sequence;

		// Token: 0x04002881 RID: 10369
		public uint result;
	}
}
