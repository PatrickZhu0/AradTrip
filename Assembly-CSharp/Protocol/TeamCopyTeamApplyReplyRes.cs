using System;

namespace Protocol
{
	// Token: 0x02000BD6 RID: 3030
	[Protocol]
	public class TeamCopyTeamApplyReplyRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F27 RID: 32551 RVA: 0x00169083 File Offset: 0x00167483
		public uint GetMsgID()
		{
			return 1100026U;
		}

		// Token: 0x06007F28 RID: 32552 RVA: 0x0016908A File Offset: 0x0016748A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F29 RID: 32553 RVA: 0x00169092 File Offset: 0x00167492
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F2A RID: 32554 RVA: 0x0016909C File Offset: 0x0016749C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAgree);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerIds.Length);
			for (int i = 0; i < this.playerIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.playerIds[i]);
			}
		}

		// Token: 0x06007F2B RID: 32555 RVA: 0x00169100 File Offset: 0x00167500
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAgree);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerIds = new ulong[(int)num];
			for (int i = 0; i < this.playerIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerIds[i]);
			}
		}

		// Token: 0x06007F2C RID: 32556 RVA: 0x00169170 File Offset: 0x00167570
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAgree);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerIds.Length);
			for (int i = 0; i < this.playerIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.playerIds[i]);
			}
		}

		// Token: 0x06007F2D RID: 32557 RVA: 0x001691D4 File Offset: 0x001675D4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAgree);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerIds = new ulong[(int)num];
			for (int i = 0; i < this.playerIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerIds[i]);
			}
		}

		// Token: 0x06007F2E RID: 32558 RVA: 0x00169244 File Offset: 0x00167644
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + (2 + 8 * this.playerIds.Length);
		}

		// Token: 0x04003CB9 RID: 15545
		public const uint MsgID = 1100026U;

		// Token: 0x04003CBA RID: 15546
		public uint Sequence;

		// Token: 0x04003CBB RID: 15547
		public uint retCode;

		// Token: 0x04003CBC RID: 15548
		public uint isAgree;

		// Token: 0x04003CBD RID: 15549
		public ulong[] playerIds = new ulong[0];
	}
}
