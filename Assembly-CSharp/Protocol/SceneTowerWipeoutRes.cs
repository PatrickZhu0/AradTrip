using System;

namespace Protocol
{
	// Token: 0x020007D4 RID: 2004
	[Protocol]
	public class SceneTowerWipeoutRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060DF RID: 24799 RVA: 0x00123200 File Offset: 0x00121600
		public uint GetMsgID()
		{
			return 507202U;
		}

		// Token: 0x060060E0 RID: 24800 RVA: 0x00123207 File Offset: 0x00121607
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060E1 RID: 24801 RVA: 0x0012320F File Offset: 0x0012160F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060E2 RID: 24802 RVA: 0x00123218 File Offset: 0x00121618
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060060E3 RID: 24803 RVA: 0x00123228 File Offset: 0x00121628
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060060E4 RID: 24804 RVA: 0x00123238 File Offset: 0x00121638
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060060E5 RID: 24805 RVA: 0x00123248 File Offset: 0x00121648
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060060E6 RID: 24806 RVA: 0x00123258 File Offset: 0x00121658
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002867 RID: 10343
		public const uint MsgID = 507202U;

		// Token: 0x04002868 RID: 10344
		public uint Sequence;

		// Token: 0x04002869 RID: 10345
		public uint result;
	}
}
