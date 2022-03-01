using System;

namespace Protocol
{
	// Token: 0x020009B6 RID: 2486
	[Protocol]
	public class WorldGetSysRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006FAF RID: 28591 RVA: 0x001421D4 File Offset: 0x001405D4
		public uint GetMsgID()
		{
			return 600908U;
		}

		// Token: 0x06006FB0 RID: 28592 RVA: 0x001421DB File Offset: 0x001405DB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006FB1 RID: 28593 RVA: 0x001421E3 File Offset: 0x001405E3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FB2 RID: 28594 RVA: 0x001421EC File Offset: 0x001405EC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.behavoir);
			BaseDLL.encode_uint32(buffer, ref pos_, this.role);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06006FB3 RID: 28595 RVA: 0x00142226 File Offset: 0x00140626
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.behavoir);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.role);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x06006FB4 RID: 28596 RVA: 0x00142260 File Offset: 0x00140660
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.behavoir);
			BaseDLL.encode_uint32(buffer, ref pos_, this.role);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06006FB5 RID: 28597 RVA: 0x0014229A File Offset: 0x0014069A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.behavoir);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.role);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x06006FB6 RID: 28598 RVA: 0x001422D4 File Offset: 0x001406D4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040032AA RID: 12970
		public const uint MsgID = 600908U;

		// Token: 0x040032AB RID: 12971
		public uint Sequence;

		// Token: 0x040032AC RID: 12972
		public uint behavoir;

		// Token: 0x040032AD RID: 12973
		public uint role;

		// Token: 0x040032AE RID: 12974
		public uint param;

		// Token: 0x040032AF RID: 12975
		public uint value;
	}
}
