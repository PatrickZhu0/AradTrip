using System;

namespace Protocol
{
	// Token: 0x02000783 RID: 1923
	[Protocol]
	public class SceneChatHornRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E99 RID: 24217 RVA: 0x0011BA9C File Offset: 0x00119E9C
		public uint GetMsgID()
		{
			return 500809U;
		}

		// Token: 0x06005E9A RID: 24218 RVA: 0x0011BAA3 File Offset: 0x00119EA3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E9B RID: 24219 RVA: 0x0011BAAB File Offset: 0x00119EAB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E9C RID: 24220 RVA: 0x0011BAB4 File Offset: 0x00119EB4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06005E9D RID: 24221 RVA: 0x0011BAC4 File Offset: 0x00119EC4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005E9E RID: 24222 RVA: 0x0011BAD4 File Offset: 0x00119ED4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06005E9F RID: 24223 RVA: 0x0011BAE4 File Offset: 0x00119EE4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005EA0 RID: 24224 RVA: 0x0011BAF4 File Offset: 0x00119EF4
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x040026EB RID: 9963
		public const uint MsgID = 500809U;

		// Token: 0x040026EC RID: 9964
		public uint Sequence;

		// Token: 0x040026ED RID: 9965
		public uint result;
	}
}
