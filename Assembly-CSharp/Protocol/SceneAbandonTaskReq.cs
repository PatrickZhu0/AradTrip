using System;

namespace Protocol
{
	// Token: 0x02000C54 RID: 3156
	[Protocol]
	public class SceneAbandonTaskReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008305 RID: 33541 RVA: 0x001707D4 File Offset: 0x0016EBD4
		public uint GetMsgID()
		{
			return 501105U;
		}

		// Token: 0x06008306 RID: 33542 RVA: 0x001707DB File Offset: 0x0016EBDB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008307 RID: 33543 RVA: 0x001707E3 File Offset: 0x0016EBE3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008308 RID: 33544 RVA: 0x001707EC File Offset: 0x0016EBEC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
		}

		// Token: 0x06008309 RID: 33545 RVA: 0x001707FC File Offset: 0x0016EBFC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
		}

		// Token: 0x0600830A RID: 33546 RVA: 0x0017080C File Offset: 0x0016EC0C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
		}

		// Token: 0x0600830B RID: 33547 RVA: 0x0017081C File Offset: 0x0016EC1C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
		}

		// Token: 0x0600830C RID: 33548 RVA: 0x0017082C File Offset: 0x0016EC2C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003EB0 RID: 16048
		public const uint MsgID = 501105U;

		// Token: 0x04003EB1 RID: 16049
		public uint Sequence;

		// Token: 0x04003EB2 RID: 16050
		public uint taskID;
	}
}
