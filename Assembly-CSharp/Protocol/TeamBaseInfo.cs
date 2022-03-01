using System;

namespace Protocol
{
	// Token: 0x02000B7C RID: 2940
	public class TeamBaseInfo : IProtocolStream
	{
		// Token: 0x06007CBD RID: 31933 RVA: 0x00163A18 File Offset: 0x00161E18
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.target);
			this.masterInfo.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.memberNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxMemberNum);
		}

		// Token: 0x06007CBE RID: 31934 RVA: 0x00163A6C File Offset: 0x00161E6C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.target);
			this.masterInfo.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.memberNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxMemberNum);
		}

		// Token: 0x06007CBF RID: 31935 RVA: 0x00163AC0 File Offset: 0x00161EC0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.target);
			this.masterInfo.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.memberNum);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxMemberNum);
		}

		// Token: 0x06007CC0 RID: 31936 RVA: 0x00163B14 File Offset: 0x00161F14
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.target);
			this.masterInfo.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.memberNum);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxMemberNum);
		}

		// Token: 0x06007CC1 RID: 31937 RVA: 0x00163B68 File Offset: 0x00161F68
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += this.masterInfo.getLen();
			num++;
			return num + 1;
		}

		// Token: 0x04003B1F RID: 15135
		public uint teamId;

		// Token: 0x04003B20 RID: 15136
		public uint target;

		// Token: 0x04003B21 RID: 15137
		public TeammemberBaseInfo masterInfo = new TeammemberBaseInfo();

		// Token: 0x04003B22 RID: 15138
		public byte memberNum;

		// Token: 0x04003B23 RID: 15139
		public byte maxMemberNum;
	}
}
