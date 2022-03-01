using System;

namespace Protocol
{
	// Token: 0x02000950 RID: 2384
	[Protocol]
	public class GambingLotterySync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C34 RID: 27700 RVA: 0x0013B774 File Offset: 0x00139B74
		public uint GetMsgID()
		{
			return 707909U;
		}

		// Token: 0x06006C35 RID: 27701 RVA: 0x0013B77B File Offset: 0x00139B7B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C36 RID: 27702 RVA: 0x0013B783 File Offset: 0x00139B83
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C37 RID: 27703 RVA: 0x0013B78C File Offset: 0x00139B8C
		public void encode(byte[] buffer, ref int pos_)
		{
			this.gainersGambingInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.participantsGambingInfo.Length);
			for (int i = 0; i < this.participantsGambingInfo.Length; i++)
			{
				this.participantsGambingInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C38 RID: 27704 RVA: 0x0013B7E0 File Offset: 0x00139BE0
		public void decode(byte[] buffer, ref int pos_)
		{
			this.gainersGambingInfo.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.participantsGambingInfo = new GambingParticipantInfo[(int)num];
			for (int i = 0; i < this.participantsGambingInfo.Length; i++)
			{
				this.participantsGambingInfo[i] = new GambingParticipantInfo();
				this.participantsGambingInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C39 RID: 27705 RVA: 0x0013B848 File Offset: 0x00139C48
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.gainersGambingInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.participantsGambingInfo.Length);
			for (int i = 0; i < this.participantsGambingInfo.Length; i++)
			{
				this.participantsGambingInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C3A RID: 27706 RVA: 0x0013B89C File Offset: 0x00139C9C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.gainersGambingInfo.decode(buffer, ref pos_);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.participantsGambingInfo = new GambingParticipantInfo[(int)num];
			for (int i = 0; i < this.participantsGambingInfo.Length; i++)
			{
				this.participantsGambingInfo[i] = new GambingParticipantInfo();
				this.participantsGambingInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C3B RID: 27707 RVA: 0x0013B904 File Offset: 0x00139D04
		public int getLen()
		{
			int num = 0;
			num += this.gainersGambingInfo.getLen();
			num += 2;
			for (int i = 0; i < this.participantsGambingInfo.Length; i++)
			{
				num += this.participantsGambingInfo[i].getLen();
			}
			return num;
		}

		// Token: 0x040030FA RID: 12538
		public const uint MsgID = 707909U;

		// Token: 0x040030FB RID: 12539
		public uint Sequence;

		// Token: 0x040030FC RID: 12540
		public GambingParticipantInfo gainersGambingInfo = new GambingParticipantInfo();

		// Token: 0x040030FD RID: 12541
		public GambingParticipantInfo[] participantsGambingInfo = new GambingParticipantInfo[0];
	}
}
