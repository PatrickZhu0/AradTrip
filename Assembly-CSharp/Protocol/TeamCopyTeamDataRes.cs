using System;

namespace Protocol
{
	// Token: 0x02000BBC RID: 3004
	[Protocol]
	public class TeamCopyTeamDataRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E4F RID: 32335 RVA: 0x00166885 File Offset: 0x00164C85
		public uint GetMsgID()
		{
			return 1100006U;
		}

		// Token: 0x06007E50 RID: 32336 RVA: 0x0016688C File Offset: 0x00164C8C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E51 RID: 32337 RVA: 0x00166894 File Offset: 0x00164C94
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E52 RID: 32338 RVA: 0x001668A0 File Offset: 0x00164CA0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
			byte[] str = StringHelper.StringToUTF8Bytes(this.teamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCommission);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bonusCommission);
			BaseDLL.encode_uint32(buffer, ref pos_, this.autoAgreeGold);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamGrade);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.voiceRoomId);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.squadList.Length);
			for (int i = 0; i < this.squadList.Length; i++)
			{
				this.squadList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E53 RID: 32339 RVA: 0x0016699C File Offset: 0x00164D9C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.teamName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCommission);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bonusCommission);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.autoAgreeGold);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamGrade);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.voiceRoomId = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.squadList = new SquadData[(int)num3];
			for (int k = 0; k < this.squadList.Length; k++)
			{
				this.squadList[k] = new SquadData();
				this.squadList[k].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E54 RID: 32340 RVA: 0x00166B04 File Offset: 0x00164F04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
			byte[] str = StringHelper.StringToUTF8Bytes(this.teamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCommission);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bonusCommission);
			BaseDLL.encode_uint32(buffer, ref pos_, this.autoAgreeGold);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamGrade);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.voiceRoomId);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.squadList.Length);
			for (int i = 0; i < this.squadList.Length; i++)
			{
				this.squadList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E55 RID: 32341 RVA: 0x00166C08 File Offset: 0x00165008
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.teamName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCommission);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bonusCommission);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.autoAgreeGold);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamGrade);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.voiceRoomId = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.squadList = new SquadData[(int)num3];
			for (int k = 0; k < this.squadList.Length; k++)
			{
				this.squadList[k] = new SquadData();
				this.squadList[k].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007E56 RID: 32342 RVA: 0x00166D70 File Offset: 0x00165170
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.teamName);
			num += 2 + array.Length;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.voiceRoomId);
			num += 2 + array2.Length;
			num += 2;
			for (int i = 0; i < this.squadList.Length; i++)
			{
				num += this.squadList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003C42 RID: 15426
		public const uint MsgID = 1100006U;

		// Token: 0x04003C43 RID: 15427
		public uint Sequence;

		// Token: 0x04003C44 RID: 15428
		public uint teamId;

		// Token: 0x04003C45 RID: 15429
		public uint equipScore;

		// Token: 0x04003C46 RID: 15430
		public uint status;

		// Token: 0x04003C47 RID: 15431
		public string teamName;

		// Token: 0x04003C48 RID: 15432
		public uint totalCommission;

		// Token: 0x04003C49 RID: 15433
		public uint bonusCommission;

		// Token: 0x04003C4A RID: 15434
		public uint autoAgreeGold;

		// Token: 0x04003C4B RID: 15435
		public uint teamType;

		// Token: 0x04003C4C RID: 15436
		public uint teamModel;

		// Token: 0x04003C4D RID: 15437
		public uint teamGrade;

		// Token: 0x04003C4E RID: 15438
		public string voiceRoomId;

		// Token: 0x04003C4F RID: 15439
		public SquadData[] squadList = new SquadData[0];
	}
}
