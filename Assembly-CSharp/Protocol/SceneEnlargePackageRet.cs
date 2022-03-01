using System;

namespace Protocol
{
	// Token: 0x020008DF RID: 2271
	[Protocol]
	public class SceneEnlargePackageRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006847 RID: 26695 RVA: 0x001352E8 File Offset: 0x001336E8
		public uint GetMsgID()
		{
			return 500917U;
		}

		// Token: 0x06006848 RID: 26696 RVA: 0x001352EF File Offset: 0x001336EF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006849 RID: 26697 RVA: 0x001352F7 File Offset: 0x001336F7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600684A RID: 26698 RVA: 0x00135300 File Offset: 0x00133700
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600684B RID: 26699 RVA: 0x00135310 File Offset: 0x00133710
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600684C RID: 26700 RVA: 0x00135320 File Offset: 0x00133720
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600684D RID: 26701 RVA: 0x00135330 File Offset: 0x00133730
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600684E RID: 26702 RVA: 0x00135340 File Offset: 0x00133740
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002F54 RID: 12116
		public const uint MsgID = 500917U;

		// Token: 0x04002F55 RID: 12117
		public uint Sequence;

		// Token: 0x04002F56 RID: 12118
		public uint code;
	}
}
