using System;

namespace Protocol
{
	// Token: 0x02000BA3 RID: 2979
	[Protocol]
	public class WorldTeamInviteSyncAttr : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E16 RID: 32278 RVA: 0x00165E9C File Offset: 0x0016429C
		public uint GetMsgID()
		{
			return 601657U;
		}

		// Token: 0x06007E17 RID: 32279 RVA: 0x00165EA3 File Offset: 0x001642A3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E18 RID: 32280 RVA: 0x00165EAB File Offset: 0x001642AB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E19 RID: 32281 RVA: 0x00165EB4 File Offset: 0x001642B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_int32(buffer, ref pos_, this.target);
		}

		// Token: 0x06007E1A RID: 32282 RVA: 0x00165ED2 File Offset: 0x001642D2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.target);
		}

		// Token: 0x06007E1B RID: 32283 RVA: 0x00165EF0 File Offset: 0x001642F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_int32(buffer, ref pos_, this.target);
		}

		// Token: 0x06007E1C RID: 32284 RVA: 0x00165F0E File Offset: 0x0016430E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.target);
		}

		// Token: 0x06007E1D RID: 32285 RVA: 0x00165F2C File Offset: 0x0016432C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003BBB RID: 15291
		public const uint MsgID = 601657U;

		// Token: 0x04003BBC RID: 15292
		public uint Sequence;

		// Token: 0x04003BBD RID: 15293
		public int teamId;

		// Token: 0x04003BBE RID: 15294
		public int target;
	}
}
