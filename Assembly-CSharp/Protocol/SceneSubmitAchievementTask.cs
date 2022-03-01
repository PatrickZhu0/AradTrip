using System;

namespace Protocol
{
	// Token: 0x02000C5E RID: 3166
	[Protocol]
	public class SceneSubmitAchievementTask : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008359 RID: 33625 RVA: 0x00171525 File Offset: 0x0016F925
		public uint GetMsgID()
		{
			return 501126U;
		}

		// Token: 0x0600835A RID: 33626 RVA: 0x0017152C File Offset: 0x0016F92C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600835B RID: 33627 RVA: 0x00171534 File Offset: 0x0016F934
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600835C RID: 33628 RVA: 0x0017153D File Offset: 0x0016F93D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x0600835D RID: 33629 RVA: 0x0017154D File Offset: 0x0016F94D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x0600835E RID: 33630 RVA: 0x0017155D File Offset: 0x0016F95D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
		}

		// Token: 0x0600835F RID: 33631 RVA: 0x0017156D File Offset: 0x0016F96D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
		}

		// Token: 0x06008360 RID: 33632 RVA: 0x00171580 File Offset: 0x0016F980
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003ED4 RID: 16084
		public const uint MsgID = 501126U;

		// Token: 0x04003ED5 RID: 16085
		public uint Sequence;

		// Token: 0x04003ED6 RID: 16086
		public uint taskId;
	}
}
