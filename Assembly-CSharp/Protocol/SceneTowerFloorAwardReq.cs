using System;

namespace Protocol
{
	// Token: 0x020007DD RID: 2013
	[Protocol]
	public class SceneTowerFloorAwardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006130 RID: 24880 RVA: 0x00123884 File Offset: 0x00121C84
		public uint GetMsgID()
		{
			return 507209U;
		}

		// Token: 0x06006131 RID: 24881 RVA: 0x0012388B File Offset: 0x00121C8B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006132 RID: 24882 RVA: 0x00123893 File Offset: 0x00121C93
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006133 RID: 24883 RVA: 0x0012389C File Offset: 0x00121C9C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.floor);
		}

		// Token: 0x06006134 RID: 24884 RVA: 0x001238AC File Offset: 0x00121CAC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.floor);
		}

		// Token: 0x06006135 RID: 24885 RVA: 0x001238BC File Offset: 0x00121CBC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.floor);
		}

		// Token: 0x06006136 RID: 24886 RVA: 0x001238CC File Offset: 0x00121CCC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.floor);
		}

		// Token: 0x06006137 RID: 24887 RVA: 0x001238DC File Offset: 0x00121CDC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002882 RID: 10370
		public const uint MsgID = 507209U;

		// Token: 0x04002883 RID: 10371
		public uint Sequence;

		// Token: 0x04002884 RID: 10372
		public uint floor;
	}
}
