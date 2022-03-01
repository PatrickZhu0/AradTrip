using System;

namespace Protocol
{
	// Token: 0x02000C68 RID: 3176
	[Protocol]
	public class SceneResetTaskSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083B3 RID: 33715 RVA: 0x00171D0F File Offset: 0x0017010F
		public uint GetMsgID()
		{
			return 501116U;
		}

		// Token: 0x060083B4 RID: 33716 RVA: 0x00171D16 File Offset: 0x00170116
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083B5 RID: 33717 RVA: 0x00171D1E File Offset: 0x0017011E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083B6 RID: 33718 RVA: 0x00171D27 File Offset: 0x00170127
		public void encode(byte[] buffer, ref int pos_)
		{
			this.taskInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060083B7 RID: 33719 RVA: 0x00171D36 File Offset: 0x00170136
		public void decode(byte[] buffer, ref int pos_)
		{
			this.taskInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060083B8 RID: 33720 RVA: 0x00171D45 File Offset: 0x00170145
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.taskInfo.encode(buffer, ref pos_);
		}

		// Token: 0x060083B9 RID: 33721 RVA: 0x00171D54 File Offset: 0x00170154
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.taskInfo.decode(buffer, ref pos_);
		}

		// Token: 0x060083BA RID: 33722 RVA: 0x00171D64 File Offset: 0x00170164
		public int getLen()
		{
			int num = 0;
			return num + this.taskInfo.getLen();
		}

		// Token: 0x04003EF1 RID: 16113
		public const uint MsgID = 501116U;

		// Token: 0x04003EF2 RID: 16114
		public uint Sequence;

		// Token: 0x04003EF3 RID: 16115
		public MissionInfo taskInfo = new MissionInfo();
	}
}
