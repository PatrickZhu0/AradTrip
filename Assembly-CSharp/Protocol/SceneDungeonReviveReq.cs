using System;

namespace Protocol
{
	// Token: 0x020007CA RID: 1994
	[Protocol]
	public class SceneDungeonReviveReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006088 RID: 24712 RVA: 0x00122586 File Offset: 0x00120986
		public uint GetMsgID()
		{
			return 506817U;
		}

		// Token: 0x06006089 RID: 24713 RVA: 0x0012258D File Offset: 0x0012098D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600608A RID: 24714 RVA: 0x00122595 File Offset: 0x00120995
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600608B RID: 24715 RVA: 0x0012259E File Offset: 0x0012099E
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.reviveId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.reviveCoinNum);
		}

		// Token: 0x0600608C RID: 24716 RVA: 0x001225CA File Offset: 0x001209CA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.reviveId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.reviveCoinNum);
		}

		// Token: 0x0600608D RID: 24717 RVA: 0x001225F6 File Offset: 0x001209F6
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.reviveId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.reviveCoinNum);
		}

		// Token: 0x0600608E RID: 24718 RVA: 0x00122622 File Offset: 0x00120A22
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.reviveId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.reviveCoinNum);
		}

		// Token: 0x0600608F RID: 24719 RVA: 0x00122650 File Offset: 0x00120A50
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002843 RID: 10307
		public const uint MsgID = 506817U;

		// Token: 0x04002844 RID: 10308
		public uint Sequence;

		// Token: 0x04002845 RID: 10309
		public ulong targetId;

		// Token: 0x04002846 RID: 10310
		public uint reviveId;

		// Token: 0x04002847 RID: 10311
		public uint reviveCoinNum;
	}
}
