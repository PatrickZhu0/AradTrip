using System;

namespace Protocol
{
	// Token: 0x02000C58 RID: 3160
	[Protocol]
	public class SceneNotifyNewTaskRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008323 RID: 33571 RVA: 0x00170E94 File Offset: 0x0016F294
		public uint GetMsgID()
		{
			return 501107U;
		}

		// Token: 0x06008324 RID: 33572 RVA: 0x00170E9B File Offset: 0x0016F29B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008325 RID: 33573 RVA: 0x00170EA3 File Offset: 0x0016F2A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008326 RID: 33574 RVA: 0x00170EAC File Offset: 0x0016F2AC
		public void encode(byte[] buffer, ref int pos_)
		{
			this.taskInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06008327 RID: 33575 RVA: 0x00170EBB File Offset: 0x0016F2BB
		public void decode(byte[] buffer, ref int pos_)
		{
			this.taskInfo.decode(buffer, ref pos_);
		}

		// Token: 0x06008328 RID: 33576 RVA: 0x00170ECA File Offset: 0x0016F2CA
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.taskInfo.encode(buffer, ref pos_);
		}

		// Token: 0x06008329 RID: 33577 RVA: 0x00170ED9 File Offset: 0x0016F2D9
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.taskInfo.decode(buffer, ref pos_);
		}

		// Token: 0x0600832A RID: 33578 RVA: 0x00170EE8 File Offset: 0x0016F2E8
		public int getLen()
		{
			int num = 0;
			return num + this.taskInfo.getLen();
		}

		// Token: 0x04003EBD RID: 16061
		public const uint MsgID = 501107U;

		// Token: 0x04003EBE RID: 16062
		public uint Sequence;

		// Token: 0x04003EBF RID: 16063
		public MissionInfo taskInfo = new MissionInfo();
	}
}
