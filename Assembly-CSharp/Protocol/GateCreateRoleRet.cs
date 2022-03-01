using System;

namespace Protocol
{
	// Token: 0x020009C2 RID: 2498
	[Protocol]
	public class GateCreateRoleRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006FFA RID: 28666 RVA: 0x00144820 File Offset: 0x00142C20
		public uint GetMsgID()
		{
			return 300303U;
		}

		// Token: 0x06006FFB RID: 28667 RVA: 0x00144827 File Offset: 0x00142C27
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006FFC RID: 28668 RVA: 0x0014482F File Offset: 0x00142C2F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FFD RID: 28669 RVA: 0x00144838 File Offset: 0x00142C38
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006FFE RID: 28670 RVA: 0x00144848 File Offset: 0x00142C48
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006FFF RID: 28671 RVA: 0x00144858 File Offset: 0x00142C58
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007000 RID: 28672 RVA: 0x00144868 File Offset: 0x00142C68
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007001 RID: 28673 RVA: 0x00144878 File Offset: 0x00142C78
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003308 RID: 13064
		public const uint MsgID = 300303U;

		// Token: 0x04003309 RID: 13065
		public uint Sequence;

		// Token: 0x0400330A RID: 13066
		public uint result;
	}
}
