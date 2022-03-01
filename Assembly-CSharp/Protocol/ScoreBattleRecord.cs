using System;

namespace Protocol
{
	// Token: 0x02000767 RID: 1895
	public class ScoreBattleRecord : IProtocolStream
	{
		// Token: 0x06005DC1 RID: 24001 RVA: 0x0011931C File Offset: 0x0011771C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleIDA);
			byte[] str = StringHelper.StringToUTF8Bytes(this.nameA);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleIDB);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.nameB);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
		}

		// Token: 0x06005DC2 RID: 24002 RVA: 0x0011938C File Offset: 0x0011778C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleIDA);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.nameA = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleIDB);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.nameB = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005DC3 RID: 24003 RVA: 0x0011944C File Offset: 0x0011784C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleIDA);
			byte[] str = StringHelper.StringToUTF8Bytes(this.nameA);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleIDB);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.nameB);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
		}

		// Token: 0x06005DC4 RID: 24004 RVA: 0x001194C4 File Offset: 0x001178C4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleIDA);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.nameA = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleIDB);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.nameB = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005DC5 RID: 24005 RVA: 0x00119584 File Offset: 0x00117984
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.nameA);
			num += 2 + array.Length;
			num += 8;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.nameB);
			num += 2 + array2.Length;
			return num + 1;
		}

		// Token: 0x0400266C RID: 9836
		public ulong roleIDA;

		// Token: 0x0400266D RID: 9837
		public string nameA;

		// Token: 0x0400266E RID: 9838
		public ulong roleIDB;

		// Token: 0x0400266F RID: 9839
		public string nameB;

		// Token: 0x04002670 RID: 9840
		public byte result;
	}
}
