using System;

namespace Protocol
{
	// Token: 0x02000753 RID: 1875
	[Protocol]
	public class SceneChampionObserveRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D16 RID: 23830 RVA: 0x00118187 File Offset: 0x00116587
		public uint GetMsgID()
		{
			return 509816U;
		}

		// Token: 0x06005D17 RID: 23831 RVA: 0x0011818E File Offset: 0x0011658E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D18 RID: 23832 RVA: 0x00118196 File Offset: 0x00116596
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D19 RID: 23833 RVA: 0x0011819F File Offset: 0x0011659F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceID);
			this.addr.encode(buffer, ref pos_);
		}

		// Token: 0x06005D1A RID: 23834 RVA: 0x001181CA File Offset: 0x001165CA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceID);
			this.addr.decode(buffer, ref pos_);
		}

		// Token: 0x06005D1B RID: 23835 RVA: 0x001181F5 File Offset: 0x001165F5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceID);
			this.addr.encode(buffer, ref pos_);
		}

		// Token: 0x06005D1C RID: 23836 RVA: 0x00118220 File Offset: 0x00116620
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceID);
			this.addr.decode(buffer, ref pos_);
		}

		// Token: 0x06005D1D RID: 23837 RVA: 0x0011824C File Offset: 0x0011664C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			return num + this.addr.getLen();
		}

		// Token: 0x04002628 RID: 9768
		public const uint MsgID = 509816U;

		// Token: 0x04002629 RID: 9769
		public uint Sequence;

		// Token: 0x0400262A RID: 9770
		public ulong roleID;

		// Token: 0x0400262B RID: 9771
		public ulong raceID;

		// Token: 0x0400262C RID: 9772
		public SockAddr addr = new SockAddr();
	}
}
