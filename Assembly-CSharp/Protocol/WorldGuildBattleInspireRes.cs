using System;

namespace Protocol
{
	// Token: 0x02000856 RID: 2134
	[Protocol]
	public class WorldGuildBattleInspireRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006478 RID: 25720 RVA: 0x0012BB60 File Offset: 0x00129F60
		public uint GetMsgID()
		{
			return 601945U;
		}

		// Token: 0x06006479 RID: 25721 RVA: 0x0012BB67 File Offset: 0x00129F67
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600647A RID: 25722 RVA: 0x0012BB6F File Offset: 0x00129F6F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600647B RID: 25723 RVA: 0x0012BB78 File Offset: 0x00129F78
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.inspire);
		}

		// Token: 0x0600647C RID: 25724 RVA: 0x0012BB96 File Offset: 0x00129F96
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inspire);
		}

		// Token: 0x0600647D RID: 25725 RVA: 0x0012BBB4 File Offset: 0x00129FB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_int8(buffer, ref pos_, this.inspire);
		}

		// Token: 0x0600647E RID: 25726 RVA: 0x0012BBD2 File Offset: 0x00129FD2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inspire);
		}

		// Token: 0x0600647F RID: 25727 RVA: 0x0012BBF0 File Offset: 0x00129FF0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002D02 RID: 11522
		public const uint MsgID = 601945U;

		// Token: 0x04002D03 RID: 11523
		public uint Sequence;

		// Token: 0x04002D04 RID: 11524
		public uint result;

		// Token: 0x04002D05 RID: 11525
		public byte inspire;
	}
}
