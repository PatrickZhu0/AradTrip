using System;

namespace Protocol
{
	// Token: 0x02000A6D RID: 2669
	[Protocol]
	public class WorldPremiumLeagueBattleGamerUpdate : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007504 RID: 29956 RVA: 0x00152B55 File Offset: 0x00150F55
		public uint GetMsgID()
		{
			return 607707U;
		}

		// Token: 0x06007505 RID: 29957 RVA: 0x00152B5C File Offset: 0x00150F5C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007506 RID: 29958 RVA: 0x00152B64 File Offset: 0x00150F64
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007507 RID: 29959 RVA: 0x00152B6D File Offset: 0x00150F6D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLose);
		}

		// Token: 0x06007508 RID: 29960 RVA: 0x00152B99 File Offset: 0x00150F99
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLose);
		}

		// Token: 0x06007509 RID: 29961 RVA: 0x00152BC5 File Offset: 0x00150FC5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.isLose);
		}

		// Token: 0x0600750A RID: 29962 RVA: 0x00152BF1 File Offset: 0x00150FF1
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isLose);
		}

		// Token: 0x0600750B RID: 29963 RVA: 0x00152C20 File Offset: 0x00151020
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400366B RID: 13931
		public const uint MsgID = 607707U;

		// Token: 0x0400366C RID: 13932
		public uint Sequence;

		// Token: 0x0400366D RID: 13933
		public ulong roleId;

		// Token: 0x0400366E RID: 13934
		public uint winNum;

		// Token: 0x0400366F RID: 13935
		public byte isLose;
	}
}
