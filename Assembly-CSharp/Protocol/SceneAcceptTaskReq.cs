using System;

namespace Protocol
{
	// Token: 0x02000C52 RID: 3154
	[Protocol]
	public class SceneAcceptTaskReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082F3 RID: 33523 RVA: 0x001705FC File Offset: 0x0016E9FC
		public uint GetMsgID()
		{
			return 501103U;
		}

		// Token: 0x060082F4 RID: 33524 RVA: 0x00170603 File Offset: 0x0016EA03
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082F5 RID: 33525 RVA: 0x0017060B File Offset: 0x0016EA0B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082F6 RID: 33526 RVA: 0x00170614 File Offset: 0x0016EA14
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.acceptType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
		}

		// Token: 0x060082F7 RID: 33527 RVA: 0x00170640 File Offset: 0x0016EA40
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.acceptType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
		}

		// Token: 0x060082F8 RID: 33528 RVA: 0x0017066C File Offset: 0x0016EA6C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.acceptType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
		}

		// Token: 0x060082F9 RID: 33529 RVA: 0x00170698 File Offset: 0x0016EA98
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.acceptType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
		}

		// Token: 0x060082FA RID: 33530 RVA: 0x001706C4 File Offset: 0x0016EAC4
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003EA6 RID: 16038
		public const uint MsgID = 501103U;

		// Token: 0x04003EA7 RID: 16039
		public uint Sequence;

		// Token: 0x04003EA8 RID: 16040
		public byte acceptType;

		// Token: 0x04003EA9 RID: 16041
		public uint npcID;

		// Token: 0x04003EAA RID: 16042
		public uint taskID;
	}
}
