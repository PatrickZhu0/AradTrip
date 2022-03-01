using System;

namespace Protocol
{
	// Token: 0x020008F9 RID: 2297
	[Protocol]
	public class SceneEnlargeStorageRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006931 RID: 26929 RVA: 0x0013667C File Offset: 0x00134A7C
		public uint GetMsgID()
		{
			return 500930U;
		}

		// Token: 0x06006932 RID: 26930 RVA: 0x00136683 File Offset: 0x00134A83
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006933 RID: 26931 RVA: 0x0013668B File Offset: 0x00134A8B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006934 RID: 26932 RVA: 0x00136694 File Offset: 0x00134A94
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006935 RID: 26933 RVA: 0x001366A4 File Offset: 0x00134AA4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006936 RID: 26934 RVA: 0x001366B4 File Offset: 0x00134AB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006937 RID: 26935 RVA: 0x001366C4 File Offset: 0x00134AC4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006938 RID: 26936 RVA: 0x001366D4 File Offset: 0x00134AD4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002FAF RID: 12207
		public const uint MsgID = 500930U;

		// Token: 0x04002FB0 RID: 12208
		public uint Sequence;

		// Token: 0x04002FB1 RID: 12209
		public uint code;
	}
}
