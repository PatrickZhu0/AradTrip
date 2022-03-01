using System;

namespace Protocol
{
	// Token: 0x02000762 RID: 1890
	[Protocol]
	public class SceneChampionTotalStatusRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D94 RID: 23956 RVA: 0x00118F53 File Offset: 0x00117353
		public uint GetMsgID()
		{
			return 509828U;
		}

		// Token: 0x06005D95 RID: 23957 RVA: 0x00118F5A File Offset: 0x0011735A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D96 RID: 23958 RVA: 0x00118F62 File Offset: 0x00117362
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D97 RID: 23959 RVA: 0x00118F6B File Offset: 0x0011736B
		public void encode(byte[] buffer, ref int pos_)
		{
			this.status.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.slefStatus);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
		}

		// Token: 0x06005D98 RID: 23960 RVA: 0x00118F96 File Offset: 0x00117396
		public void decode(byte[] buffer, ref int pos_)
		{
			this.status.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.slefStatus);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
		}

		// Token: 0x06005D99 RID: 23961 RVA: 0x00118FC1 File Offset: 0x001173C1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.status.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.slefStatus);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
		}

		// Token: 0x06005D9A RID: 23962 RVA: 0x00118FEC File Offset: 0x001173EC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.status.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.slefStatus);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
		}

		// Token: 0x06005D9B RID: 23963 RVA: 0x00119018 File Offset: 0x00117418
		public int getLen()
		{
			int num = 0;
			num += this.status.getLen();
			num += 4;
			return num + 8;
		}

		// Token: 0x0400265C RID: 9820
		public const uint MsgID = 509828U;

		// Token: 0x0400265D RID: 9821
		public uint Sequence;

		// Token: 0x0400265E RID: 9822
		public ChampionStatusInfo status = new ChampionStatusInfo();

		// Token: 0x0400265F RID: 9823
		public uint slefStatus;

		// Token: 0x04002660 RID: 9824
		public ulong roleID;
	}
}
