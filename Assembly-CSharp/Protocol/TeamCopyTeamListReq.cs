using System;

namespace Protocol
{
	// Token: 0x02000BBD RID: 3005
	[Protocol]
	public class TeamCopyTeamListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E58 RID: 32344 RVA: 0x00166E01 File Offset: 0x00165201
		public uint GetMsgID()
		{
			return 1100007U;
		}

		// Token: 0x06007E59 RID: 32345 RVA: 0x00166E08 File Offset: 0x00165208
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E5A RID: 32346 RVA: 0x00166E10 File Offset: 0x00165210
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E5B RID: 32347 RVA: 0x00166E19 File Offset: 0x00165219
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pageNum);
		}

		// Token: 0x06007E5C RID: 32348 RVA: 0x00166E45 File Offset: 0x00165245
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pageNum);
		}

		// Token: 0x06007E5D RID: 32349 RVA: 0x00166E71 File Offset: 0x00165271
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pageNum);
		}

		// Token: 0x06007E5E RID: 32350 RVA: 0x00166E9D File Offset: 0x0016529D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pageNum);
		}

		// Token: 0x06007E5F RID: 32351 RVA: 0x00166ECC File Offset: 0x001652CC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003C50 RID: 15440
		public const uint MsgID = 1100007U;

		// Token: 0x04003C51 RID: 15441
		public uint Sequence;

		// Token: 0x04003C52 RID: 15442
		public uint teamType;

		// Token: 0x04003C53 RID: 15443
		public uint teamModel;

		// Token: 0x04003C54 RID: 15444
		public uint pageNum;
	}
}
