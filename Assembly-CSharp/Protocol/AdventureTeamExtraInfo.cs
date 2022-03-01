using System;

namespace Protocol
{
	// Token: 0x02000692 RID: 1682
	public class AdventureTeamExtraInfo : IProtocolStream
	{
		// Token: 0x0600573E RID: 22334 RVA: 0x0010A400 File Offset: 0x00108800
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.adventureTeamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.adventureTeamLevel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.adventureTeamExp);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.adventureTeamGrade);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.adventureTeamRanking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.adventureTeamOwnRoleFileds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.adventureTeamRoleTotalScore);
		}

		// Token: 0x0600573F RID: 22335 RVA: 0x0010A48C File Offset: 0x0010888C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.adventureTeamName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.adventureTeamLevel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.adventureTeamExp);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.adventureTeamGrade = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.adventureTeamRanking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.adventureTeamOwnRoleFileds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.adventureTeamRoleTotalScore);
		}

		// Token: 0x06005740 RID: 22336 RVA: 0x0010A568 File Offset: 0x00108968
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.adventureTeamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.adventureTeamLevel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.adventureTeamExp);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.adventureTeamGrade);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.adventureTeamRanking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.adventureTeamOwnRoleFileds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.adventureTeamRoleTotalScore);
		}

		// Token: 0x06005741 RID: 22337 RVA: 0x0010A5FC File Offset: 0x001089FC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.adventureTeamName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.adventureTeamLevel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.adventureTeamExp);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.adventureTeamGrade = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.adventureTeamRanking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.adventureTeamOwnRoleFileds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.adventureTeamRoleTotalScore);
		}

		// Token: 0x06005742 RID: 22338 RVA: 0x0010A6D8 File Offset: 0x00108AD8
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.adventureTeamName);
			num += 2 + array.Length;
			num += 2;
			num += 8;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.adventureTeamGrade);
			num += 2 + array2.Length;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040022A7 RID: 8871
		public string adventureTeamName;

		// Token: 0x040022A8 RID: 8872
		public ushort adventureTeamLevel;

		// Token: 0x040022A9 RID: 8873
		public ulong adventureTeamExp;

		// Token: 0x040022AA RID: 8874
		public string adventureTeamGrade;

		// Token: 0x040022AB RID: 8875
		public uint adventureTeamRanking;

		// Token: 0x040022AC RID: 8876
		public uint adventureTeamOwnRoleFileds;

		// Token: 0x040022AD RID: 8877
		public uint adventureTeamRoleTotalScore;
	}
}
