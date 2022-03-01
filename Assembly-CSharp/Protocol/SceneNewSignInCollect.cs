using System;

namespace Protocol
{
	// Token: 0x0200067C RID: 1660
	[Protocol]
	public class SceneNewSignInCollect : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005687 RID: 22151 RVA: 0x00109354 File Offset: 0x00107754
		public uint GetMsgID()
		{
			return 501165U;
		}

		// Token: 0x06005688 RID: 22152 RVA: 0x0010935B File Offset: 0x0010775B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005689 RID: 22153 RVA: 0x00109363 File Offset: 0x00107763
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600568A RID: 22154 RVA: 0x0010936C File Offset: 0x0010776C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.day);
		}

		// Token: 0x0600568B RID: 22155 RVA: 0x0010937C File Offset: 0x0010777C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.day);
		}

		// Token: 0x0600568C RID: 22156 RVA: 0x0010938C File Offset: 0x0010778C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.day);
		}

		// Token: 0x0600568D RID: 22157 RVA: 0x0010939C File Offset: 0x0010779C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.day);
		}

		// Token: 0x0600568E RID: 22158 RVA: 0x001093AC File Offset: 0x001077AC
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002261 RID: 8801
		public const uint MsgID = 501165U;

		// Token: 0x04002262 RID: 8802
		public uint Sequence;

		// Token: 0x04002263 RID: 8803
		public byte day;
	}
}
