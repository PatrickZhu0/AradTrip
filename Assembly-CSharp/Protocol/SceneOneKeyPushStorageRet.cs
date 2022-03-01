using System;

namespace Protocol
{
	// Token: 0x020008F8 RID: 2296
	[Protocol]
	public class SceneOneKeyPushStorageRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006928 RID: 26920 RVA: 0x00136608 File Offset: 0x00134A08
		public uint GetMsgID()
		{
			return 500929U;
		}

		// Token: 0x06006929 RID: 26921 RVA: 0x0013660F File Offset: 0x00134A0F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600692A RID: 26922 RVA: 0x00136617 File Offset: 0x00134A17
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600692B RID: 26923 RVA: 0x00136620 File Offset: 0x00134A20
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600692C RID: 26924 RVA: 0x00136630 File Offset: 0x00134A30
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600692D RID: 26925 RVA: 0x00136640 File Offset: 0x00134A40
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x0600692E RID: 26926 RVA: 0x00136650 File Offset: 0x00134A50
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x0600692F RID: 26927 RVA: 0x00136660 File Offset: 0x00134A60
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002FAC RID: 12204
		public const uint MsgID = 500929U;

		// Token: 0x04002FAD RID: 12205
		public uint Sequence;

		// Token: 0x04002FAE RID: 12206
		public uint code;
	}
}
