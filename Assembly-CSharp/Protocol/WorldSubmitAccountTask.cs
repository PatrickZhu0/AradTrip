using System;

namespace Protocol
{
	// Token: 0x02000C79 RID: 3193
	[Protocol]
	public class WorldSubmitAccountTask : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008449 RID: 33865 RVA: 0x00172F30 File Offset: 0x00171330
		public uint GetMsgID()
		{
			return 601103U;
		}

		// Token: 0x0600844A RID: 33866 RVA: 0x00172F37 File Offset: 0x00171337
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600844B RID: 33867 RVA: 0x00172F3F File Offset: 0x0017133F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600844C RID: 33868 RVA: 0x00172F48 File Offset: 0x00171348
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x0600844D RID: 33869 RVA: 0x00172F58 File Offset: 0x00171358
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x0600844E RID: 33870 RVA: 0x00172F68 File Offset: 0x00171368
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x0600844F RID: 33871 RVA: 0x00172F78 File Offset: 0x00171378
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x06008450 RID: 33872 RVA: 0x00172F88 File Offset: 0x00171388
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003F34 RID: 16180
		public const uint MsgID = 601103U;

		// Token: 0x04003F35 RID: 16181
		public uint Sequence;

		// Token: 0x04003F36 RID: 16182
		public uint taskId;
	}
}
