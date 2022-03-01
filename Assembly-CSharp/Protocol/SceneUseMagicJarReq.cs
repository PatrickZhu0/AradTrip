using System;

namespace Protocol
{
	// Token: 0x02000920 RID: 2336
	[Protocol]
	public class SceneUseMagicJarReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A8D RID: 27277 RVA: 0x00138BF8 File Offset: 0x00136FF8
		public uint GetMsgID()
		{
			return 500948U;
		}

		// Token: 0x06006A8E RID: 27278 RVA: 0x00138BFF File Offset: 0x00136FFF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A8F RID: 27279 RVA: 0x00138C07 File Offset: 0x00137007
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A90 RID: 27280 RVA: 0x00138C10 File Offset: 0x00137010
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.combo);
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06006A91 RID: 27281 RVA: 0x00138C4A File Offset: 0x0013704A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.combo);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06006A92 RID: 27282 RVA: 0x00138C84 File Offset: 0x00137084
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.combo);
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
		}

		// Token: 0x06006A93 RID: 27283 RVA: 0x00138CBE File Offset: 0x001370BE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.combo);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
		}

		// Token: 0x06006A94 RID: 27284 RVA: 0x00138CF8 File Offset: 0x001370F8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400304C RID: 12364
		public const uint MsgID = 500948U;

		// Token: 0x0400304D RID: 12365
		public uint Sequence;

		// Token: 0x0400304E RID: 12366
		public uint type;

		// Token: 0x0400304F RID: 12367
		public byte combo;

		// Token: 0x04003050 RID: 12368
		public uint opActId;

		// Token: 0x04003051 RID: 12369
		public uint param;
	}
}
