using System;

namespace Protocol
{
	// Token: 0x02000BF1 RID: 3057
	[Protocol]
	public class TeamCopyInviteChoiceReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008014 RID: 32788 RVA: 0x0016ACA9 File Offset: 0x001690A9
		public uint GetMsgID()
		{
			return 1100054U;
		}

		// Token: 0x06008015 RID: 32789 RVA: 0x0016ACB0 File Offset: 0x001690B0
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008016 RID: 32790 RVA: 0x0016ACB8 File Offset: 0x001690B8
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008017 RID: 32791 RVA: 0x0016ACC4 File Offset: 0x001690C4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAgree);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamId.Length);
			for (int i = 0; i < this.teamId.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.teamId[i]);
			}
		}

		// Token: 0x06008018 RID: 32792 RVA: 0x0016AD1C File Offset: 0x0016911C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAgree);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamId = new uint[(int)num];
			for (int i = 0; i < this.teamId.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId[i]);
			}
		}

		// Token: 0x06008019 RID: 32793 RVA: 0x0016AD7C File Offset: 0x0016917C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAgree);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamId.Length);
			for (int i = 0; i < this.teamId.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.teamId[i]);
			}
		}

		// Token: 0x0600801A RID: 32794 RVA: 0x0016ADD4 File Offset: 0x001691D4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAgree);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamId = new uint[(int)num];
			for (int i = 0; i < this.teamId.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId[i]);
			}
		}

		// Token: 0x0600801B RID: 32795 RVA: 0x0016AE34 File Offset: 0x00169234
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + 4 * this.teamId.Length);
		}

		// Token: 0x04003D20 RID: 15648
		public const uint MsgID = 1100054U;

		// Token: 0x04003D21 RID: 15649
		public uint Sequence;

		// Token: 0x04003D22 RID: 15650
		public uint isAgree;

		// Token: 0x04003D23 RID: 15651
		public uint[] teamId = new uint[0];
	}
}
