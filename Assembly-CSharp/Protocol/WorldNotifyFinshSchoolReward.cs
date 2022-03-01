using System;

namespace Protocol
{
	// Token: 0x02000C78 RID: 3192
	[Protocol]
	public class WorldNotifyFinshSchoolReward : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008440 RID: 33856 RVA: 0x00172C24 File Offset: 0x00171024
		public uint GetMsgID()
		{
			return 601771U;
		}

		// Token: 0x06008441 RID: 33857 RVA: 0x00172C2B File Offset: 0x0017102B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008442 RID: 33858 RVA: 0x00172C33 File Offset: 0x00171033
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008443 RID: 33859 RVA: 0x00172C3C File Offset: 0x0017103C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.giftId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.masterId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.masterName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.discipleName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.discipleGrowth);
		}

		// Token: 0x06008444 RID: 33860 RVA: 0x00172CBC File Offset: 0x001710BC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.masterId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.masterName = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.discipleName = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discipleGrowth);
		}

		// Token: 0x06008445 RID: 33861 RVA: 0x00172D8C File Offset: 0x0017118C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.giftId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.masterId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.discipleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.masterName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.discipleName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.discipleGrowth);
		}

		// Token: 0x06008446 RID: 33862 RVA: 0x00172E10 File Offset: 0x00171210
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.giftId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.masterId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.discipleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.masterName = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.discipleName = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.discipleGrowth);
		}

		// Token: 0x06008447 RID: 33863 RVA: 0x00172EE0 File Offset: 0x001712E0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.masterName);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.discipleName);
			num += 2 + array2.Length;
			return num + 4;
		}

		// Token: 0x04003F2C RID: 16172
		public const uint MsgID = 601771U;

		// Token: 0x04003F2D RID: 16173
		public uint Sequence;

		// Token: 0x04003F2E RID: 16174
		public uint giftId;

		// Token: 0x04003F2F RID: 16175
		public ulong masterId;

		// Token: 0x04003F30 RID: 16176
		public ulong discipleId;

		// Token: 0x04003F31 RID: 16177
		public string masterName;

		// Token: 0x04003F32 RID: 16178
		public string discipleName;

		// Token: 0x04003F33 RID: 16179
		public uint discipleGrowth;
	}
}
