using System;

namespace Protocol
{
	// Token: 0x02000C53 RID: 3155
	[Protocol]
	public class SceneSubmitTaskReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082FC RID: 33532 RVA: 0x001706E8 File Offset: 0x0016EAE8
		public uint GetMsgID()
		{
			return 501104U;
		}

		// Token: 0x060082FD RID: 33533 RVA: 0x001706EF File Offset: 0x0016EAEF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082FE RID: 33534 RVA: 0x001706F7 File Offset: 0x0016EAF7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082FF RID: 33535 RVA: 0x00170700 File Offset: 0x0016EB00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.submitType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
		}

		// Token: 0x06008300 RID: 33536 RVA: 0x0017072C File Offset: 0x0016EB2C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.submitType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
		}

		// Token: 0x06008301 RID: 33537 RVA: 0x00170758 File Offset: 0x0016EB58
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.submitType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.npcID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
		}

		// Token: 0x06008302 RID: 33538 RVA: 0x00170784 File Offset: 0x0016EB84
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.submitType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.npcID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
		}

		// Token: 0x06008303 RID: 33539 RVA: 0x001707B0 File Offset: 0x0016EBB0
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003EAB RID: 16043
		public const uint MsgID = 501104U;

		// Token: 0x04003EAC RID: 16044
		public uint Sequence;

		// Token: 0x04003EAD RID: 16045
		public byte submitType;

		// Token: 0x04003EAE RID: 16046
		public uint npcID;

		// Token: 0x04003EAF RID: 16047
		public uint taskID;
	}
}
