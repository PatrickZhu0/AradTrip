using System;

namespace Protocol
{
	// Token: 0x0200079D RID: 1949
	[Protocol]
	public class WorldDigWatchRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F59 RID: 24409 RVA: 0x0011D95B File Offset: 0x0011BD5B
		public uint GetMsgID()
		{
			return 608210U;
		}

		// Token: 0x06005F5A RID: 24410 RVA: 0x0011D962 File Offset: 0x0011BD62
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F5B RID: 24411 RVA: 0x0011D96A File Offset: 0x0011BD6A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F5C RID: 24412 RVA: 0x0011D973 File Offset: 0x0011BD73
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005F5D RID: 24413 RVA: 0x0011D9AC File Offset: 0x0011BDAC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005F5E RID: 24414 RVA: 0x0011D9E5 File Offset: 0x0011BDE5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06005F5F RID: 24415 RVA: 0x0011DA1E File Offset: 0x0011BE1E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06005F60 RID: 24416 RVA: 0x0011DA58 File Offset: 0x0011BE58
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + this.info.getLen();
		}

		// Token: 0x04002758 RID: 10072
		public const uint MsgID = 608210U;

		// Token: 0x04002759 RID: 10073
		public uint Sequence;

		// Token: 0x0400275A RID: 10074
		public uint result;

		// Token: 0x0400275B RID: 10075
		public uint mapId;

		// Token: 0x0400275C RID: 10076
		public uint index;

		// Token: 0x0400275D RID: 10077
		public DigDetailInfo info = new DigDetailInfo();
	}
}
