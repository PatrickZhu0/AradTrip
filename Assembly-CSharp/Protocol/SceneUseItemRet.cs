using System;

namespace Protocol
{
	// Token: 0x020008DB RID: 2267
	[Protocol]
	public class SceneUseItemRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006823 RID: 26659 RVA: 0x00135118 File Offset: 0x00133518
		public uint GetMsgID()
		{
			return 500902U;
		}

		// Token: 0x06006824 RID: 26660 RVA: 0x0013511F File Offset: 0x0013351F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006825 RID: 26661 RVA: 0x00135127 File Offset: 0x00133527
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006826 RID: 26662 RVA: 0x00135130 File Offset: 0x00133530
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006827 RID: 26663 RVA: 0x00135140 File Offset: 0x00133540
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006828 RID: 26664 RVA: 0x00135150 File Offset: 0x00133550
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006829 RID: 26665 RVA: 0x00135160 File Offset: 0x00133560
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600682A RID: 26666 RVA: 0x00135170 File Offset: 0x00133570
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002F48 RID: 12104
		public const uint MsgID = 500902U;

		// Token: 0x04002F49 RID: 12105
		public uint Sequence;

		// Token: 0x04002F4A RID: 12106
		public uint code;
	}
}
