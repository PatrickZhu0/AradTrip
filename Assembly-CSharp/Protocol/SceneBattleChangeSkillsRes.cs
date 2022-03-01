using System;

namespace Protocol
{
	// Token: 0x020006F6 RID: 1782
	[Protocol]
	public class SceneBattleChangeSkillsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A22 RID: 23074 RVA: 0x00112739 File Offset: 0x00110B39
		public uint GetMsgID()
		{
			return 508904U;
		}

		// Token: 0x06005A23 RID: 23075 RVA: 0x00112740 File Offset: 0x00110B40
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A24 RID: 23076 RVA: 0x00112748 File Offset: 0x00110B48
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A25 RID: 23077 RVA: 0x00112751 File Offset: 0x00110B51
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06005A26 RID: 23078 RVA: 0x00112761 File Offset: 0x00110B61
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005A27 RID: 23079 RVA: 0x00112771 File Offset: 0x00110B71
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06005A28 RID: 23080 RVA: 0x00112781 File Offset: 0x00110B81
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005A29 RID: 23081 RVA: 0x00112794 File Offset: 0x00110B94
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400248F RID: 9359
		public const uint MsgID = 508904U;

		// Token: 0x04002490 RID: 9360
		public uint Sequence;

		// Token: 0x04002491 RID: 9361
		public uint result;
	}
}
