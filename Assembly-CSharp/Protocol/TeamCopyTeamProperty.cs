using System;

namespace Protocol
{
	// Token: 0x02000BBE RID: 3006
	public class TeamCopyTeamProperty : IProtocolStream
	{
		// Token: 0x06007E61 RID: 32353 RVA: 0x00166EF0 File Offset: 0x001652F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.commission);
			byte[] str = StringHelper.StringToUTF8Bytes(this.teamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamGrade);
			BaseDLL.encode_uint32(buffer, ref pos_, this.memberNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
		}

		// Token: 0x06007E62 RID: 32354 RVA: 0x00166F8C File Offset: 0x0016538C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.commission);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.teamName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamGrade);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.memberNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06007E63 RID: 32355 RVA: 0x0016704C File Offset: 0x0016544C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.commission);
			byte[] str = StringHelper.StringToUTF8Bytes(this.teamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamGrade);
			BaseDLL.encode_uint32(buffer, ref pos_, this.memberNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.equipScore);
			BaseDLL.encode_uint32(buffer, ref pos_, this.status);
		}

		// Token: 0x06007E64 RID: 32356 RVA: 0x001670E8 File Offset: 0x001654E8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.commission);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.teamName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamGrade);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.memberNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipScore);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.status);
		}

		// Token: 0x06007E65 RID: 32357 RVA: 0x001671A8 File Offset: 0x001655A8
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
			return num + 4;
		}

		// Token: 0x04003C55 RID: 15445
		public uint teamId;

		// Token: 0x04003C56 RID: 15446
		public uint teamModel;

		// Token: 0x04003C57 RID: 15447
		public uint commission;

		// Token: 0x04003C58 RID: 15448
		public string teamName;

		// Token: 0x04003C59 RID: 15449
		public uint teamType;

		// Token: 0x04003C5A RID: 15450
		public uint teamGrade;

		// Token: 0x04003C5B RID: 15451
		public uint memberNum;

		// Token: 0x04003C5C RID: 15452
		public uint equipScore;

		// Token: 0x04003C5D RID: 15453
		public uint status;
	}
}
