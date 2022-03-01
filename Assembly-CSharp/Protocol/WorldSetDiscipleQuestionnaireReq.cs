using System;

namespace Protocol
{
	// Token: 0x02000CAB RID: 3243
	[Protocol]
	public class WorldSetDiscipleQuestionnaireReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085BA RID: 34234 RVA: 0x00176AAC File Offset: 0x00174EAC
		public uint GetMsgID()
		{
			return 601739U;
		}

		// Token: 0x060085BB RID: 34235 RVA: 0x00176AB3 File Offset: 0x00174EB3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085BC RID: 34236 RVA: 0x00176ABB File Offset: 0x00174EBB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085BD RID: 34237 RVA: 0x00176AC4 File Offset: 0x00174EC4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060085BE RID: 34238 RVA: 0x00176B18 File Offset: 0x00174F18
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activeTimeType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.masterType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.regionId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.declaration = StringHelper.BytesToString(array);
		}

		// Token: 0x060085BF RID: 34239 RVA: 0x00176B90 File Offset: 0x00174F90
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060085C0 RID: 34240 RVA: 0x00176BE8 File Offset: 0x00174FE8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activeTimeType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.masterType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.regionId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.declaration = StringHelper.BytesToString(array);
		}

		// Token: 0x060085C1 RID: 34241 RVA: 0x00176C60 File Offset: 0x00175060
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.declaration);
			return num + (2 + array.Length);
		}

		// Token: 0x0400400D RID: 16397
		public const uint MsgID = 601739U;

		// Token: 0x0400400E RID: 16398
		public uint Sequence;

		// Token: 0x0400400F RID: 16399
		public byte activeTimeType;

		// Token: 0x04004010 RID: 16400
		public byte masterType;

		// Token: 0x04004011 RID: 16401
		public byte regionId;

		// Token: 0x04004012 RID: 16402
		public string declaration;
	}
}
