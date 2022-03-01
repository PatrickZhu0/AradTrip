using System;

namespace Protocol
{
	// Token: 0x02000B9F RID: 2975
	[Protocol]
	public class SceneTeamMatchStartRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DF2 RID: 32242 RVA: 0x00165C04 File Offset: 0x00164004
		public uint GetMsgID()
		{
			return 501605U;
		}

		// Token: 0x06007DF3 RID: 32243 RVA: 0x00165C0B File Offset: 0x0016400B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DF4 RID: 32244 RVA: 0x00165C13 File Offset: 0x00164013
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DF5 RID: 32245 RVA: 0x00165C1C File Offset: 0x0016401C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007DF6 RID: 32246 RVA: 0x00165C2C File Offset: 0x0016402C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007DF7 RID: 32247 RVA: 0x00165C3C File Offset: 0x0016403C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007DF8 RID: 32248 RVA: 0x00165C4C File Offset: 0x0016404C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007DF9 RID: 32249 RVA: 0x00165C5C File Offset: 0x0016405C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003BAC RID: 15276
		public const uint MsgID = 501605U;

		// Token: 0x04003BAD RID: 15277
		public uint Sequence;

		// Token: 0x04003BAE RID: 15278
		public uint result;
	}
}
