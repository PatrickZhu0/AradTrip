using System;

namespace Protocol
{
	// Token: 0x02000C6A RID: 3178
	[Protocol]
	public class SceneAchievementScoreRewardRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060083C5 RID: 33733 RVA: 0x00171E00 File Offset: 0x00170200
		public uint GetMsgID()
		{
			return 501157U;
		}

		// Token: 0x060083C6 RID: 33734 RVA: 0x00171E07 File Offset: 0x00170207
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060083C7 RID: 33735 RVA: 0x00171E0F File Offset: 0x0017020F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060083C8 RID: 33736 RVA: 0x00171E18 File Offset: 0x00170218
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060083C9 RID: 33737 RVA: 0x00171E28 File Offset: 0x00170228
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060083CA RID: 33738 RVA: 0x00171E38 File Offset: 0x00170238
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x060083CB RID: 33739 RVA: 0x00171E48 File Offset: 0x00170248
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x060083CC RID: 33740 RVA: 0x00171E58 File Offset: 0x00170258
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003EF7 RID: 16119
		public const uint MsgID = 501157U;

		// Token: 0x04003EF8 RID: 16120
		public uint Sequence;

		// Token: 0x04003EF9 RID: 16121
		public uint result;
	}
}
