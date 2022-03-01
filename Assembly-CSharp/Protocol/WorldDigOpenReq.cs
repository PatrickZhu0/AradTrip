using System;

namespace Protocol
{
	// Token: 0x0200079E RID: 1950
	[Protocol]
	public class WorldDigOpenReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F62 RID: 24418 RVA: 0x0011DA8A File Offset: 0x0011BE8A
		public uint GetMsgID()
		{
			return 608211U;
		}

		// Token: 0x06005F63 RID: 24419 RVA: 0x0011DA91 File Offset: 0x0011BE91
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F64 RID: 24420 RVA: 0x0011DA99 File Offset: 0x0011BE99
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F65 RID: 24421 RVA: 0x0011DAA2 File Offset: 0x0011BEA2
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
		}

		// Token: 0x06005F66 RID: 24422 RVA: 0x0011DAC0 File Offset: 0x0011BEC0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
		}

		// Token: 0x06005F67 RID: 24423 RVA: 0x0011DADE File Offset: 0x0011BEDE
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
		}

		// Token: 0x06005F68 RID: 24424 RVA: 0x0011DAFC File Offset: 0x0011BEFC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
		}

		// Token: 0x06005F69 RID: 24425 RVA: 0x0011DB1C File Offset: 0x0011BF1C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400275E RID: 10078
		public const uint MsgID = 608211U;

		// Token: 0x0400275F RID: 10079
		public uint Sequence;

		// Token: 0x04002760 RID: 10080
		public uint mapId;

		// Token: 0x04002761 RID: 10081
		public uint index;
	}
}
