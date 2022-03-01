using System;

namespace Protocol
{
	// Token: 0x02000C22 RID: 3106
	[Protocol]
	public class WorldAventurePassStatusRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060081B2 RID: 33202 RVA: 0x0016DD84 File Offset: 0x0016C184
		public uint GetMsgID()
		{
			return 609502U;
		}

		// Token: 0x060081B3 RID: 33203 RVA: 0x0016DD8B File Offset: 0x0016C18B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060081B4 RID: 33204 RVA: 0x0016DD93 File Offset: 0x0016C193
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060081B5 RID: 33205 RVA: 0x0016DD9C File Offset: 0x0016C19C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.exp);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.activity);
			byte[] str = StringHelper.StringToUTF8Bytes(this.normalReward);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.highReward);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060081B6 RID: 33206 RVA: 0x0016DE44 File Offset: 0x0016C244
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.exp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activity);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.normalReward = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.highReward = StringHelper.BytesToString(array2);
		}

		// Token: 0x060081B7 RID: 33207 RVA: 0x0016DF3C File Offset: 0x0016C33C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.lv);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.exp);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.activity);
			byte[] str = StringHelper.StringToUTF8Bytes(this.normalReward);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.highReward);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060081B8 RID: 33208 RVA: 0x0016DFEC File Offset: 0x0016C3EC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lv);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.exp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.activity);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.normalReward = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.highReward = StringHelper.BytesToString(array2);
		}

		// Token: 0x060081B9 RID: 33209 RVA: 0x0016E0E4 File Offset: 0x0016C4E4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.normalReward);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.highReward);
			return num + (2 + array2.Length);
		}

		// Token: 0x04003DE2 RID: 15842
		public const uint MsgID = 609502U;

		// Token: 0x04003DE3 RID: 15843
		public uint Sequence;

		// Token: 0x04003DE4 RID: 15844
		public uint lv;

		// Token: 0x04003DE5 RID: 15845
		public uint startTime;

		// Token: 0x04003DE6 RID: 15846
		public uint endTime;

		// Token: 0x04003DE7 RID: 15847
		public uint seasonID;

		// Token: 0x04003DE8 RID: 15848
		public uint exp;

		// Token: 0x04003DE9 RID: 15849
		public byte type;

		// Token: 0x04003DEA RID: 15850
		public uint activity;

		// Token: 0x04003DEB RID: 15851
		public string normalReward;

		// Token: 0x04003DEC RID: 15852
		public string highReward;
	}
}
