using System;

namespace Protocol
{
	// Token: 0x020006FD RID: 1789
	[Protocol]
	public class SceneBattleBalanceEnd : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A61 RID: 23137 RVA: 0x00112E78 File Offset: 0x00111278
		public uint GetMsgID()
		{
			return 508905U;
		}

		// Token: 0x06005A62 RID: 23138 RVA: 0x00112E7F File Offset: 0x0011127F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A63 RID: 23139 RVA: 0x00112E87 File Offset: 0x00111287
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A64 RID: 23140 RVA: 0x00112E90 File Offset: 0x00111290
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rank);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.kills);
			BaseDLL.encode_uint32(buffer, ref pos_, this.survivalTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x06005A65 RID: 23141 RVA: 0x00112F10 File Offset: 0x00111310
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rank);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.kills);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.survivalTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x06005A66 RID: 23142 RVA: 0x00112F90 File Offset: 0x00111390
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.rank);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.kills);
			BaseDLL.encode_uint32(buffer, ref pos_, this.survivalTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getHonor);
		}

		// Token: 0x06005A67 RID: 23143 RVA: 0x00113010 File Offset: 0x00111410
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.rank);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.kills);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.survivalTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getHonor);
		}

		// Token: 0x06005A68 RID: 23144 RVA: 0x00113090 File Offset: 0x00111490
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040024B2 RID: 9394
		public const uint MsgID = 508905U;

		// Token: 0x040024B3 RID: 9395
		public uint Sequence;

		// Token: 0x040024B4 RID: 9396
		public ulong roleId;

		// Token: 0x040024B5 RID: 9397
		public uint rank;

		// Token: 0x040024B6 RID: 9398
		public uint playerNum;

		// Token: 0x040024B7 RID: 9399
		public uint kills;

		// Token: 0x040024B8 RID: 9400
		public uint survivalTime;

		// Token: 0x040024B9 RID: 9401
		public uint score;

		// Token: 0x040024BA RID: 9402
		public uint battleID;

		// Token: 0x040024BB RID: 9403
		public uint getHonor;
	}
}
