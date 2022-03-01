using System;

namespace Protocol
{
	// Token: 0x02000691 RID: 1681
	public class AdventureTeamInfo : IProtocolStream
	{
		// Token: 0x06005738 RID: 22328 RVA: 0x0010A264 File Offset: 0x00108664
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.adventureTeamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.adventureTeamLevel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.adventureTeamExp);
		}

		// Token: 0x06005739 RID: 22329 RVA: 0x0010A2AC File Offset: 0x001086AC
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
		}

		// Token: 0x0600573A RID: 22330 RVA: 0x0010A318 File Offset: 0x00108718
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.adventureTeamName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.adventureTeamLevel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.adventureTeamExp);
		}

		// Token: 0x0600573B RID: 22331 RVA: 0x0010A360 File Offset: 0x00108760
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
		}

		// Token: 0x0600573C RID: 22332 RVA: 0x0010A3CC File Offset: 0x001087CC
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.adventureTeamName);
			num += 2 + array.Length;
			num += 2;
			return num + 8;
		}

		// Token: 0x040022A4 RID: 8868
		public string adventureTeamName;

		// Token: 0x040022A5 RID: 8869
		public ushort adventureTeamLevel;

		// Token: 0x040022A6 RID: 8870
		public ulong adventureTeamExp;
	}
}
