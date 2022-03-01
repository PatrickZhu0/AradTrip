using System;

namespace Protocol
{
	// Token: 0x020008FF RID: 2303
	[Protocol]
	public class SceneCheckSealEquipRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006967 RID: 26983 RVA: 0x00136ABC File Offset: 0x00134EBC
		public uint GetMsgID()
		{
			return 500940U;
		}

		// Token: 0x06006968 RID: 26984 RVA: 0x00136AC3 File Offset: 0x00134EC3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006969 RID: 26985 RVA: 0x00136ACB File Offset: 0x00134ECB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600696A RID: 26986 RVA: 0x00136AD4 File Offset: 0x00134ED4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.matID);
			BaseDLL.encode_uint16(buffer, ref pos_, this.needNum);
		}

		// Token: 0x0600696B RID: 26987 RVA: 0x00136B00 File Offset: 0x00134F00
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.matID);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.needNum);
		}

		// Token: 0x0600696C RID: 26988 RVA: 0x00136B2C File Offset: 0x00134F2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			BaseDLL.encode_uint32(buffer, ref pos_, this.matID);
			BaseDLL.encode_uint16(buffer, ref pos_, this.needNum);
		}

		// Token: 0x0600696D RID: 26989 RVA: 0x00136B58 File Offset: 0x00134F58
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.matID);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.needNum);
		}

		// Token: 0x0600696E RID: 26990 RVA: 0x00136B84 File Offset: 0x00134F84
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 2;
		}

		// Token: 0x04002FC3 RID: 12227
		public const uint MsgID = 500940U;

		// Token: 0x04002FC4 RID: 12228
		public uint Sequence;

		// Token: 0x04002FC5 RID: 12229
		public uint code;

		// Token: 0x04002FC6 RID: 12230
		public uint matID;

		// Token: 0x04002FC7 RID: 12231
		public ushort needNum;
	}
}
