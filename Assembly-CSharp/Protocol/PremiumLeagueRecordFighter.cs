using System;

namespace Protocol
{
	// Token: 0x02000A63 RID: 2659
	public class PremiumLeagueRecordFighter : IProtocolStream
	{
		// Token: 0x060074B6 RID: 29878 RVA: 0x00151F80 File Offset: 0x00150380
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.winStreak);
			BaseDLL.encode_uint16(buffer, ref pos_, this.gotScore);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalScore);
		}

		// Token: 0x060074B7 RID: 29879 RVA: 0x00151FE4 File Offset: 0x001503E4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.winStreak);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.gotScore);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalScore);
		}

		// Token: 0x060074B8 RID: 29880 RVA: 0x0015206C File Offset: 0x0015046C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.winStreak);
			BaseDLL.encode_uint16(buffer, ref pos_, this.gotScore);
			BaseDLL.encode_uint16(buffer, ref pos_, this.totalScore);
		}

		// Token: 0x060074B9 RID: 29881 RVA: 0x001520D0 File Offset: 0x001504D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.winStreak);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.gotScore);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.totalScore);
		}

		// Token: 0x060074BA RID: 29882 RVA: 0x00152158 File Offset: 0x00150558
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 2;
			return num + 2;
		}

		// Token: 0x04003646 RID: 13894
		public ulong id;

		// Token: 0x04003647 RID: 13895
		public string name;

		// Token: 0x04003648 RID: 13896
		public byte winStreak;

		// Token: 0x04003649 RID: 13897
		public ushort gotScore;

		// Token: 0x0400364A RID: 13898
		public ushort totalScore;
	}
}
