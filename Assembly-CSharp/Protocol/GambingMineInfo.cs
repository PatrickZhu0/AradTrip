using System;

namespace Protocol
{
	// Token: 0x020008D2 RID: 2258
	public class GambingMineInfo : IProtocolStream
	{
		// Token: 0x060067E1 RID: 26593 RVA: 0x00133C48 File Offset: 0x00132048
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.sortId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.soldCopies);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCopies);
			this.mineGambingInfo.encode(buffer, ref pos_);
			this.gainersGambingInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.participantsGambingInfo.Length);
			for (int i = 0; i < this.participantsGambingInfo.Length; i++)
			{
				this.participantsGambingInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060067E2 RID: 26594 RVA: 0x00133D0C File Offset: 0x0013210C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.sortId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.soldCopies);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCopies);
			this.mineGambingInfo.decode(buffer, ref pos_);
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

		// Token: 0x060067E3 RID: 26595 RVA: 0x00133DE4 File Offset: 0x001321E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.gambingItemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, this.sortId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.groupId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.soldCopies);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCopies);
			this.mineGambingInfo.encode(buffer, ref pos_);
			this.gainersGambingInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.participantsGambingInfo.Length);
			for (int i = 0; i < this.participantsGambingInfo.Length; i++)
			{
				this.participantsGambingInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060067E4 RID: 26596 RVA: 0x00133EA8 File Offset: 0x001322A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.gambingItemNum);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.sortId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.groupId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.soldCopies);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCopies);
			this.mineGambingInfo.decode(buffer, ref pos_);
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

		// Token: 0x060067E5 RID: 26597 RVA: 0x00133F80 File Offset: 0x00132380
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 2;
			num += 4;
			num += 2;
			num += 4;
			num += 4;
			num += this.mineGambingInfo.getLen();
			num += this.gainersGambingInfo.getLen();
			num += 2;
			for (int i = 0; i < this.participantsGambingInfo.Length; i++)
			{
				num += this.participantsGambingInfo[i].getLen();
			}
			return num;
		}

		// Token: 0x04002F14 RID: 12052
		public uint gambingItemId;

		// Token: 0x04002F15 RID: 12053
		public uint gambingItemNum;

		// Token: 0x04002F16 RID: 12054
		public ushort sortId;

		// Token: 0x04002F17 RID: 12055
		public uint itemDataId;

		// Token: 0x04002F18 RID: 12056
		public ushort groupId;

		// Token: 0x04002F19 RID: 12057
		public uint soldCopies;

		// Token: 0x04002F1A RID: 12058
		public uint totalCopies;

		// Token: 0x04002F1B RID: 12059
		public GambingParticipantInfo mineGambingInfo = new GambingParticipantInfo();

		// Token: 0x04002F1C RID: 12060
		public GambingParticipantInfo gainersGambingInfo = new GambingParticipantInfo();

		// Token: 0x04002F1D RID: 12061
		public GambingParticipantInfo[] participantsGambingInfo = new GambingParticipantInfo[0];
	}
}
