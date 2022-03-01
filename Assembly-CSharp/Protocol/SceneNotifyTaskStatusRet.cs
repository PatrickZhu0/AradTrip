using System;

namespace Protocol
{
	// Token: 0x02000C5A RID: 3162
	[Protocol]
	public class SceneNotifyTaskStatusRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008335 RID: 33589 RVA: 0x00170FC0 File Offset: 0x0016F3C0
		public uint GetMsgID()
		{
			return 501109U;
		}

		// Token: 0x06008336 RID: 33590 RVA: 0x00170FC7 File Offset: 0x0016F3C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008337 RID: 33591 RVA: 0x00170FCF File Offset: 0x0016F3CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008338 RID: 33592 RVA: 0x00170FD8 File Offset: 0x0016F3D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.finTime);
		}

		// Token: 0x06008339 RID: 33593 RVA: 0x00171004 File Offset: 0x0016F404
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.finTime);
		}

		// Token: 0x0600833A RID: 33594 RVA: 0x00171030 File Offset: 0x0016F430
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.finTime);
		}

		// Token: 0x0600833B RID: 33595 RVA: 0x0017105C File Offset: 0x0016F45C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.finTime);
		}

		// Token: 0x0600833C RID: 33596 RVA: 0x00171088 File Offset: 0x0016F488
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 4;
		}

		// Token: 0x04003EC4 RID: 16068
		public const uint MsgID = 501109U;

		// Token: 0x04003EC5 RID: 16069
		public uint Sequence;

		// Token: 0x04003EC6 RID: 16070
		public uint taskID;

		// Token: 0x04003EC7 RID: 16071
		public byte status;

		// Token: 0x04003EC8 RID: 16072
		public uint finTime;
	}
}
