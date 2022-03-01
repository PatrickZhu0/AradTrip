using System;

namespace Protocol
{
	// Token: 0x02000BEF RID: 3055
	public class TCInviteInfo : IProtocolStream
	{
		// Token: 0x06008005 RID: 32773 RVA: 0x0016A828 File Offset: 0x00168C28
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamGrade);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.awaken);
			BaseDLL.encode_uint32(buffer, ref pos_, this.level);
		}

		// Token: 0x06008006 RID: 32774 RVA: 0x0016A8B4 File Offset: 0x00168CB4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamGrade);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.awaken);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.level);
		}

		// Token: 0x06008007 RID: 32775 RVA: 0x0016A964 File Offset: 0x00168D64
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamModel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamGrade);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint32(buffer, ref pos_, this.awaken);
			BaseDLL.encode_uint32(buffer, ref pos_, this.level);
		}

		// Token: 0x06008008 RID: 32776 RVA: 0x0016A9F4 File Offset: 0x00168DF4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamModel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamGrade);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.awaken);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.level);
		}

		// Token: 0x06008009 RID: 32777 RVA: 0x0016AAA4 File Offset: 0x00168EA4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D15 RID: 15637
		public uint teamId;

		// Token: 0x04003D16 RID: 15638
		public uint teamType;

		// Token: 0x04003D17 RID: 15639
		public uint teamModel;

		// Token: 0x04003D18 RID: 15640
		public uint teamGrade;

		// Token: 0x04003D19 RID: 15641
		public string name;

		// Token: 0x04003D1A RID: 15642
		public uint occu;

		// Token: 0x04003D1B RID: 15643
		public uint awaken;

		// Token: 0x04003D1C RID: 15644
		public uint level;
	}
}
