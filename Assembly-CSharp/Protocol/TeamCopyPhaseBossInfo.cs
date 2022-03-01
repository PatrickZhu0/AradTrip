using System;

namespace Protocol
{
	// Token: 0x02000BFF RID: 3071
	[Protocol]
	public class TeamCopyPhaseBossInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008092 RID: 32914 RVA: 0x0016BD18 File Offset: 0x0016A118
		public uint GetMsgID()
		{
			return 1100068U;
		}

		// Token: 0x06008093 RID: 32915 RVA: 0x0016BD1F File Offset: 0x0016A11F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008094 RID: 32916 RVA: 0x0016BD27 File Offset: 0x0016A127
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008095 RID: 32917 RVA: 0x0016BD30 File Offset: 0x0016A130
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curFrame);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phase);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bossBloodRate);
		}

		// Token: 0x06008096 RID: 32918 RVA: 0x0016BD84 File Offset: 0x0016A184
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curFrame);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phase);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bossBloodRate);
		}

		// Token: 0x06008097 RID: 32919 RVA: 0x0016BDD8 File Offset: 0x0016A1D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.raceId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.curFrame);
			BaseDLL.encode_uint32(buffer, ref pos_, this.phase);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bossBloodRate);
		}

		// Token: 0x06008098 RID: 32920 RVA: 0x0016BE2C File Offset: 0x0016A22C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.raceId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.curFrame);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.phase);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bossBloodRate);
		}

		// Token: 0x06008099 RID: 32921 RVA: 0x0016BE80 File Offset: 0x0016A280
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D61 RID: 15713
		public const uint MsgID = 1100068U;

		// Token: 0x04003D62 RID: 15714
		public uint Sequence;

		// Token: 0x04003D63 RID: 15715
		public ulong raceId;

		// Token: 0x04003D64 RID: 15716
		public ulong roleId;

		// Token: 0x04003D65 RID: 15717
		public uint curFrame;

		// Token: 0x04003D66 RID: 15718
		public uint phase;

		// Token: 0x04003D67 RID: 15719
		public uint bossBloodRate;
	}
}
