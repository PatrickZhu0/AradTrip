using System;

namespace Protocol
{
	// Token: 0x02000BF2 RID: 3058
	[Protocol]
	public class TeamCopyInviteChoiceRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600801D RID: 32797 RVA: 0x0016AE6B File Offset: 0x0016926B
		public uint GetMsgID()
		{
			return 1100055U;
		}

		// Token: 0x0600801E RID: 32798 RVA: 0x0016AE72 File Offset: 0x00169272
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600801F RID: 32799 RVA: 0x0016AE7A File Offset: 0x0016927A
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008020 RID: 32800 RVA: 0x0016AE84 File Offset: 0x00169284
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamId.Length);
			for (int i = 0; i < this.teamId.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.teamId[i]);
			}
		}

		// Token: 0x06008021 RID: 32801 RVA: 0x0016AEDC File Offset: 0x001692DC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamId = new uint[(int)num];
			for (int i = 0; i < this.teamId.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId[i]);
			}
		}

		// Token: 0x06008022 RID: 32802 RVA: 0x0016AF3C File Offset: 0x0016933C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.teamId.Length);
			for (int i = 0; i < this.teamId.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.teamId[i]);
			}
		}

		// Token: 0x06008023 RID: 32803 RVA: 0x0016AF94 File Offset: 0x00169394
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.teamId = new uint[(int)num];
			for (int i = 0; i < this.teamId.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId[i]);
			}
		}

		// Token: 0x06008024 RID: 32804 RVA: 0x0016AFF4 File Offset: 0x001693F4
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + 4 * this.teamId.Length);
		}

		// Token: 0x04003D24 RID: 15652
		public const uint MsgID = 1100055U;

		// Token: 0x04003D25 RID: 15653
		public uint Sequence;

		// Token: 0x04003D26 RID: 15654
		public uint retCode;

		// Token: 0x04003D27 RID: 15655
		public uint[] teamId = new uint[0];
	}
}
