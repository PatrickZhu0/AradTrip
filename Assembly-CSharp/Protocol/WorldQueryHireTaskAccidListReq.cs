using System;

namespace Protocol
{
	// Token: 0x02000C3E RID: 3134
	[Protocol]
	public class WorldQueryHireTaskAccidListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600828A RID: 33418 RVA: 0x0016FAAD File Offset: 0x0016DEAD
		public uint GetMsgID()
		{
			return 601788U;
		}

		// Token: 0x0600828B RID: 33419 RVA: 0x0016FAB4 File Offset: 0x0016DEB4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600828C RID: 33420 RVA: 0x0016FABC File Offset: 0x0016DEBC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600828D RID: 33421 RVA: 0x0016FAC5 File Offset: 0x0016DEC5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x0600828E RID: 33422 RVA: 0x0016FAD5 File Offset: 0x0016DED5
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x0600828F RID: 33423 RVA: 0x0016FAE5 File Offset: 0x0016DEE5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x06008290 RID: 33424 RVA: 0x0016FAF5 File Offset: 0x0016DEF5
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x06008291 RID: 33425 RVA: 0x0016FB08 File Offset: 0x0016DF08
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003E56 RID: 15958
		public const uint MsgID = 601788U;

		// Token: 0x04003E57 RID: 15959
		public uint Sequence;

		// Token: 0x04003E58 RID: 15960
		public uint taskId;
	}
}
