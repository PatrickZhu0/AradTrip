using System;

namespace Protocol
{
	// Token: 0x02000CB4 RID: 3252
	[Protocol]
	public class WorldSyncRelationQuestionnaire : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600860B RID: 34315 RVA: 0x001770FC File Offset: 0x001754FC
		public uint GetMsgID()
		{
			return 601748U;
		}

		// Token: 0x0600860C RID: 34316 RVA: 0x00177103 File Offset: 0x00175503
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600860D RID: 34317 RVA: 0x0017710B File Offset: 0x0017550B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600860E RID: 34318 RVA: 0x00177114 File Offset: 0x00175514
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600860F RID: 34319 RVA: 0x00177168 File Offset: 0x00175568
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

		// Token: 0x06008610 RID: 34320 RVA: 0x001771E0 File Offset: 0x001755E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008611 RID: 34321 RVA: 0x00177238 File Offset: 0x00175638
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

		// Token: 0x06008612 RID: 34322 RVA: 0x001772B0 File Offset: 0x001756B0
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.declaration);
			return num + (2 + array.Length);
		}

		// Token: 0x0400402B RID: 16427
		public const uint MsgID = 601748U;

		// Token: 0x0400402C RID: 16428
		public uint Sequence;

		// Token: 0x0400402D RID: 16429
		public byte activeTimeType;

		// Token: 0x0400402E RID: 16430
		public byte masterType;

		// Token: 0x0400402F RID: 16431
		public byte regionId;

		// Token: 0x04004030 RID: 16432
		public string declaration;
	}
}
