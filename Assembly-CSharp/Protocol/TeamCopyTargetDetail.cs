using System;

namespace Protocol
{
	// Token: 0x02000BCB RID: 3019
	public class TeamCopyTargetDetail : IProtocolStream
	{
		// Token: 0x06007ED0 RID: 32464 RVA: 0x00167E97 File Offset: 0x00166297
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
		}

		// Token: 0x06007ED1 RID: 32465 RVA: 0x00167EC3 File Offset: 0x001662C3
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
		}

		// Token: 0x06007ED2 RID: 32466 RVA: 0x00167EEF File Offset: 0x001662EF
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
		}

		// Token: 0x06007ED3 RID: 32467 RVA: 0x00167F1B File Offset: 0x0016631B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
		}

		// Token: 0x06007ED4 RID: 32468 RVA: 0x00167F48 File Offset: 0x00166348
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003C8A RID: 15498
		public uint fieldId;

		// Token: 0x04003C8B RID: 15499
		public uint curNum;

		// Token: 0x04003C8C RID: 15500
		public uint totalNum;
	}
}
