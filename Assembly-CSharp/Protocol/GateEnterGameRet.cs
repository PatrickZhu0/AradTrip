using System;

namespace Protocol
{
	// Token: 0x020009C5 RID: 2501
	[Protocol]
	public class GateEnterGameRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007015 RID: 28693 RVA: 0x00144BF4 File Offset: 0x00142FF4
		public uint GetMsgID()
		{
			return 300307U;
		}

		// Token: 0x06007016 RID: 28694 RVA: 0x00144BFB File Offset: 0x00142FFB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007017 RID: 28695 RVA: 0x00144C03 File Offset: 0x00143003
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007018 RID: 28696 RVA: 0x00144C0C File Offset: 0x0014300C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007019 RID: 28697 RVA: 0x00144C1C File Offset: 0x0014301C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600701A RID: 28698 RVA: 0x00144C2C File Offset: 0x0014302C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x0600701B RID: 28699 RVA: 0x00144C3C File Offset: 0x0014303C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x0600701C RID: 28700 RVA: 0x00144C4C File Offset: 0x0014304C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003315 RID: 13077
		public const uint MsgID = 300307U;

		// Token: 0x04003316 RID: 13078
		public uint Sequence;

		// Token: 0x04003317 RID: 13079
		public uint result;
	}
}
