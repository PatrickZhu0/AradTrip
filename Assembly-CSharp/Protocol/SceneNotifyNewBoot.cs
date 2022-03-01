using System;

namespace Protocol
{
	// Token: 0x02000B6E RID: 2926
	[Protocol]
	public class SceneNotifyNewBoot : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007C81 RID: 31873 RVA: 0x001634DC File Offset: 0x001618DC
		public uint GetMsgID()
		{
			return 505402U;
		}

		// Token: 0x06007C82 RID: 31874 RVA: 0x001634E3 File Offset: 0x001618E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007C83 RID: 31875 RVA: 0x001634EB File Offset: 0x001618EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007C84 RID: 31876 RVA: 0x001634F4 File Offset: 0x001618F4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06007C85 RID: 31877 RVA: 0x00163504 File Offset: 0x00161904
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007C86 RID: 31878 RVA: 0x00163514 File Offset: 0x00161914
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
		}

		// Token: 0x06007C87 RID: 31879 RVA: 0x00163524 File Offset: 0x00161924
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007C88 RID: 31880 RVA: 0x00163534 File Offset: 0x00161934
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003AF4 RID: 15092
		public const uint MsgID = 505402U;

		// Token: 0x04003AF5 RID: 15093
		public uint Sequence;

		// Token: 0x04003AF6 RID: 15094
		public uint id;
	}
}
