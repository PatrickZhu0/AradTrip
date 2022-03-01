using System;

namespace Protocol
{
	// Token: 0x02000CAD RID: 3245
	[Protocol]
	public class WorldSetMasterQuestionnaireReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060085CC RID: 34252 RVA: 0x00176D0C File Offset: 0x0017510C
		public uint GetMsgID()
		{
			return 601741U;
		}

		// Token: 0x060085CD RID: 34253 RVA: 0x00176D13 File Offset: 0x00175113
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060085CE RID: 34254 RVA: 0x00176D1B File Offset: 0x0017511B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060085CF RID: 34255 RVA: 0x00176D24 File Offset: 0x00175124
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060085D0 RID: 34256 RVA: 0x00176D78 File Offset: 0x00175178
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

		// Token: 0x060085D1 RID: 34257 RVA: 0x00176DF0 File Offset: 0x001751F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060085D2 RID: 34258 RVA: 0x00176E48 File Offset: 0x00175248
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

		// Token: 0x060085D3 RID: 34259 RVA: 0x00176EC0 File Offset: 0x001752C0
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.declaration);
			return num + (2 + array.Length);
		}

		// Token: 0x04004016 RID: 16406
		public const uint MsgID = 601741U;

		// Token: 0x04004017 RID: 16407
		public uint Sequence;

		// Token: 0x04004018 RID: 16408
		public byte activeTimeType;

		// Token: 0x04004019 RID: 16409
		public byte masterType;

		// Token: 0x0400401A RID: 16410
		public byte regionId;

		// Token: 0x0400401B RID: 16411
		public string declaration;
	}
}
