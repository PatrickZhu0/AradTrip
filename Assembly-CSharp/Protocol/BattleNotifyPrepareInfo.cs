using System;

namespace Protocol
{
	// Token: 0x02000700 RID: 1792
	[Protocol]
	public class BattleNotifyPrepareInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A79 RID: 23161 RVA: 0x001134F9 File Offset: 0x001118F9
		public uint GetMsgID()
		{
			return 2200009U;
		}

		// Token: 0x06005A7A RID: 23162 RVA: 0x00113500 File Offset: 0x00111900
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A7B RID: 23163 RVA: 0x00113508 File Offset: 0x00111908
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A7C RID: 23164 RVA: 0x00113511 File Offset: 0x00111911
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
		}

		// Token: 0x06005A7D RID: 23165 RVA: 0x0011352F File Offset: 0x0011192F
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
		}

		// Token: 0x06005A7E RID: 23166 RVA: 0x0011354D File Offset: 0x0011194D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
		}

		// Token: 0x06005A7F RID: 23167 RVA: 0x0011356B File Offset: 0x0011196B
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
		}

		// Token: 0x06005A80 RID: 23168 RVA: 0x0011358C File Offset: 0x0011198C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040024C6 RID: 9414
		public const uint MsgID = 2200009U;

		// Token: 0x040024C7 RID: 9415
		public uint Sequence;

		// Token: 0x040024C8 RID: 9416
		public uint playerNum;

		// Token: 0x040024C9 RID: 9417
		public uint totalNum;
	}
}
