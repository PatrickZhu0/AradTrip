using System;

namespace Protocol
{
	// Token: 0x0200070E RID: 1806
	[Protocol]
	public class SceneBattleNotifySomeoneDead : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005AF4 RID: 23284 RVA: 0x001143C8 File Offset: 0x001127C8
		public uint GetMsgID()
		{
			return 508919U;
		}

		// Token: 0x06005AF5 RID: 23285 RVA: 0x001143CF File Offset: 0x001127CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005AF6 RID: 23286 RVA: 0x001143D7 File Offset: 0x001127D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005AF7 RID: 23287 RVA: 0x001143E0 File Offset: 0x001127E0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.killerID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint32(buffer, ref pos_, this.kills);
			BaseDLL.encode_uint32(buffer, ref pos_, this.suvivalNum);
		}

		// Token: 0x06005AF8 RID: 23288 RVA: 0x00114444 File Offset: 0x00112844
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.killerID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.kills);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.suvivalNum);
		}

		// Token: 0x06005AF9 RID: 23289 RVA: 0x001144A8 File Offset: 0x001128A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerID);
			BaseDLL.encode_uint64(buffer, ref pos_, this.killerID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint32(buffer, ref pos_, this.kills);
			BaseDLL.encode_uint32(buffer, ref pos_, this.suvivalNum);
		}

		// Token: 0x06005AFA RID: 23290 RVA: 0x0011450C File Offset: 0x0011290C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerID);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.killerID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.kills);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.suvivalNum);
		}

		// Token: 0x06005AFB RID: 23291 RVA: 0x00114570 File Offset: 0x00112970
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 8;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002509 RID: 9481
		public const uint MsgID = 508919U;

		// Token: 0x0400250A RID: 9482
		public uint Sequence;

		// Token: 0x0400250B RID: 9483
		public uint battleID;

		// Token: 0x0400250C RID: 9484
		public ulong playerID;

		// Token: 0x0400250D RID: 9485
		public ulong killerID;

		// Token: 0x0400250E RID: 9486
		public uint reason;

		// Token: 0x0400250F RID: 9487
		public uint kills;

		// Token: 0x04002510 RID: 9488
		public uint suvivalNum;
	}
}
