using System;

namespace Protocol
{
	// Token: 0x020006F9 RID: 1785
	[Protocol]
	public class BattlePkSomeOneReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A3D RID: 23101 RVA: 0x00112A8C File Offset: 0x00110E8C
		public uint GetMsgID()
		{
			return 2200007U;
		}

		// Token: 0x06005A3E RID: 23102 RVA: 0x00112A93 File Offset: 0x00110E93
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A3F RID: 23103 RVA: 0x00112A9B File Offset: 0x00110E9B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A40 RID: 23104 RVA: 0x00112AA4 File Offset: 0x00110EA4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.dstId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonID);
		}

		// Token: 0x06005A41 RID: 23105 RVA: 0x00112ADE File Offset: 0x00110EDE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.dstId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonID);
		}

		// Token: 0x06005A42 RID: 23106 RVA: 0x00112B18 File Offset: 0x00110F18
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.dstId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonID);
		}

		// Token: 0x06005A43 RID: 23107 RVA: 0x00112B52 File Offset: 0x00110F52
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.dstId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonID);
		}

		// Token: 0x06005A44 RID: 23108 RVA: 0x00112B8C File Offset: 0x00110F8C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400249D RID: 9373
		public const uint MsgID = 2200007U;

		// Token: 0x0400249E RID: 9374
		public uint Sequence;

		// Token: 0x0400249F RID: 9375
		public ulong roleId;

		// Token: 0x040024A0 RID: 9376
		public ulong dstId;

		// Token: 0x040024A1 RID: 9377
		public uint battleID;

		// Token: 0x040024A2 RID: 9378
		public uint dungeonID;
	}
}
