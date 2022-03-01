using System;

namespace Protocol
{
	// Token: 0x02000C59 RID: 3161
	[Protocol]
	public class SceneNotifyDeleteTaskRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600832C RID: 33580 RVA: 0x00170F0E File Offset: 0x0016F30E
		public uint GetMsgID()
		{
			return 501108U;
		}

		// Token: 0x0600832D RID: 33581 RVA: 0x00170F15 File Offset: 0x0016F315
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600832E RID: 33582 RVA: 0x00170F1D File Offset: 0x0016F31D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600832F RID: 33583 RVA: 0x00170F26 File Offset: 0x0016F326
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			BaseDLL.encode_int8(buffer, ref pos_, this.reasion);
		}

		// Token: 0x06008330 RID: 33584 RVA: 0x00170F44 File Offset: 0x0016F344
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reasion);
		}

		// Token: 0x06008331 RID: 33585 RVA: 0x00170F62 File Offset: 0x0016F362
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			BaseDLL.encode_int8(buffer, ref pos_, this.reasion);
		}

		// Token: 0x06008332 RID: 33586 RVA: 0x00170F80 File Offset: 0x0016F380
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reasion);
		}

		// Token: 0x06008333 RID: 33587 RVA: 0x00170FA0 File Offset: 0x0016F3A0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003EC0 RID: 16064
		public const uint MsgID = 501108U;

		// Token: 0x04003EC1 RID: 16065
		public uint Sequence;

		// Token: 0x04003EC2 RID: 16066
		public uint taskID;

		// Token: 0x04003EC3 RID: 16067
		public byte reasion;
	}
}
