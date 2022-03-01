using System;

namespace Protocol
{
	// Token: 0x02000A4A RID: 2634
	[Protocol]
	public class SceneOpActivityGetCounterReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060073F9 RID: 29689 RVA: 0x001505B4 File Offset: 0x0014E9B4
		public uint GetMsgID()
		{
			return 507412U;
		}

		// Token: 0x060073FA RID: 29690 RVA: 0x001505BB File Offset: 0x0014E9BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060073FB RID: 29691 RVA: 0x001505C3 File Offset: 0x0014E9C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060073FC RID: 29692 RVA: 0x001505CC File Offset: 0x0014E9CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.counterId);
		}

		// Token: 0x060073FD RID: 29693 RVA: 0x001505EA File Offset: 0x0014E9EA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.counterId);
		}

		// Token: 0x060073FE RID: 29694 RVA: 0x00150608 File Offset: 0x0014EA08
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.counterId);
		}

		// Token: 0x060073FF RID: 29695 RVA: 0x00150626 File Offset: 0x0014EA26
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.counterId);
		}

		// Token: 0x06007400 RID: 29696 RVA: 0x00150644 File Offset: 0x0014EA44
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040035D2 RID: 13778
		public const uint MsgID = 507412U;

		// Token: 0x040035D3 RID: 13779
		public uint Sequence;

		// Token: 0x040035D4 RID: 13780
		public uint opActId;

		// Token: 0x040035D5 RID: 13781
		public uint counterId;
	}
}
