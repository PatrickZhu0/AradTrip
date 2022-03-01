using System;

namespace Protocol
{
	// Token: 0x020006EE RID: 1774
	[Protocol]
	public class SceneSyncRequest : IProtocolStream, IGetMsgID
	{
		// Token: 0x060059E0 RID: 23008 RVA: 0x00111597 File Offset: 0x0010F997
		public uint GetMsgID()
		{
			return 500805U;
		}

		// Token: 0x060059E1 RID: 23009 RVA: 0x0011159E File Offset: 0x0010F99E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060059E2 RID: 23010 RVA: 0x001115A6 File Offset: 0x0010F9A6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060059E3 RID: 23011 RVA: 0x001115B0 File Offset: 0x0010F9B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.requester);
			byte[] str = StringHelper.StringToUTF8Bytes(this.requesterName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.requesterOccu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.requesterLevel);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.param1);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.requesterVipLv);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060059E4 RID: 23012 RVA: 0x00111690 File Offset: 0x0010FA90
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.requester);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.requesterName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.requesterOccu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.requesterLevel);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.param1 = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.requesterVipLv);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activeTimeType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.masterType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.regionId);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.declaration = StringHelper.BytesToString(array3);
		}

		// Token: 0x060059E5 RID: 23013 RVA: 0x001117F0 File Offset: 0x0010FBF0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.requester);
			byte[] str = StringHelper.StringToUTF8Bytes(this.requesterName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.requesterOccu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.requesterLevel);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.param1);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.requesterVipLv);
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060059E6 RID: 23014 RVA: 0x001118D8 File Offset: 0x0010FCD8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.requester);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.requesterName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.requesterOccu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.requesterLevel);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.param1 = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.requesterVipLv);
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activeTimeType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.masterType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.regionId);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.declaration = StringHelper.BytesToString(array3);
		}

		// Token: 0x060059E7 RID: 23015 RVA: 0x00111A38 File Offset: 0x0010FE38
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.requesterName);
			num += 2 + array.Length;
			num++;
			num += 2;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.param1);
			num += 2 + array2.Length;
			num++;
			num += this.avatar.getLen();
			num++;
			num++;
			num++;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.declaration);
			return num + (2 + array3.Length);
		}

		// Token: 0x04002460 RID: 9312
		public const uint MsgID = 500805U;

		// Token: 0x04002461 RID: 9313
		public uint Sequence;

		// Token: 0x04002462 RID: 9314
		public byte type;

		// Token: 0x04002463 RID: 9315
		public ulong requester;

		// Token: 0x04002464 RID: 9316
		public string requesterName;

		// Token: 0x04002465 RID: 9317
		public byte requesterOccu;

		// Token: 0x04002466 RID: 9318
		public ushort requesterLevel;

		// Token: 0x04002467 RID: 9319
		public string param1;

		// Token: 0x04002468 RID: 9320
		public byte requesterVipLv;

		// Token: 0x04002469 RID: 9321
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x0400246A RID: 9322
		public byte activeTimeType;

		// Token: 0x0400246B RID: 9323
		public byte masterType;

		// Token: 0x0400246C RID: 9324
		public byte regionId;

		// Token: 0x0400246D RID: 9325
		public string declaration;
	}
}
