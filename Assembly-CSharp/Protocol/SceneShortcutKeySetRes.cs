using System;

namespace Protocol
{
	// Token: 0x02000B4D RID: 2893
	[Protocol]
	public class SceneShortcutKeySetRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B79 RID: 31609 RVA: 0x00161161 File Offset: 0x0015F561
		public uint GetMsgID()
		{
			return 501230U;
		}

		// Token: 0x06007B7A RID: 31610 RVA: 0x00161168 File Offset: 0x0015F568
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B7B RID: 31611 RVA: 0x00161170 File Offset: 0x0015F570
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B7C RID: 31612 RVA: 0x00161179 File Offset: 0x0015F579
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007B7D RID: 31613 RVA: 0x00161196 File Offset: 0x0015F596
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007B7E RID: 31614 RVA: 0x001611B3 File Offset: 0x0015F5B3
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007B7F RID: 31615 RVA: 0x001611D0 File Offset: 0x0015F5D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007B80 RID: 31616 RVA: 0x001611F0 File Offset: 0x0015F5F0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.info.getLen();
		}

		// Token: 0x04003A72 RID: 14962
		public const uint MsgID = 501230U;

		// Token: 0x04003A73 RID: 14963
		public uint Sequence;

		// Token: 0x04003A74 RID: 14964
		public uint retCode;

		// Token: 0x04003A75 RID: 14965
		public ShortcutKeyInfo info = new ShortcutKeyInfo();
	}
}
