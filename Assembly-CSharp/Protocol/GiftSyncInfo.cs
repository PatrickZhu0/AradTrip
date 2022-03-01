using System;

namespace Protocol
{
	// Token: 0x020008D5 RID: 2261
	public class GiftSyncInfo : IProtocolStream
	{
		// Token: 0x060067F3 RID: 26611 RVA: 0x00134798 File Offset: 0x00132B98
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.recommendJobs.Length);
			for (int i = 0; i < this.recommendJobs.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.recommendJobs[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.weight);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.validLevels.Length);
			for (int j = 0; j < this.validLevels.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.validLevels[j]);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.isTimeLimit);
		}

		// Token: 0x060067F4 RID: 26612 RVA: 0x0013487C File Offset: 0x00132C7C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.recommendJobs = new byte[(int)num];
			for (int i = 0; i < this.recommendJobs.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.recommendJobs[i]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weight);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.validLevels = new uint[(int)num2];
			for (int j = 0; j < this.validLevels.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.validLevels[j]);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isTimeLimit);
		}

		// Token: 0x060067F5 RID: 26613 RVA: 0x00134978 File Offset: 0x00132D78
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.recommendJobs.Length);
			for (int i = 0; i < this.recommendJobs.Length; i++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.recommendJobs[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.weight);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.validLevels.Length);
			for (int j = 0; j < this.validLevels.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.validLevels[j]);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.strengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.isTimeLimit);
		}

		// Token: 0x060067F6 RID: 26614 RVA: 0x00134A5C File Offset: 0x00132E5C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.recommendJobs = new byte[(int)num];
			for (int i = 0; i < this.recommendJobs.Length; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.recommendJobs[i]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weight);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.validLevels = new uint[(int)num2];
			for (int j = 0; j < this.validLevels.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.validLevels[j]);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.strengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isTimeLimit);
		}

		// Token: 0x060067F7 RID: 26615 RVA: 0x00134B58 File Offset: 0x00132F58
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 2 + this.recommendJobs.Length;
			num += 4;
			num += 2 + 4 * this.validLevels.Length;
			num++;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002F2C RID: 12076
		public uint id;

		// Token: 0x04002F2D RID: 12077
		public uint itemId;

		// Token: 0x04002F2E RID: 12078
		public uint itemNum;

		// Token: 0x04002F2F RID: 12079
		public byte[] recommendJobs = new byte[0];

		// Token: 0x04002F30 RID: 12080
		public uint weight;

		// Token: 0x04002F31 RID: 12081
		public uint[] validLevels = new uint[0];

		// Token: 0x04002F32 RID: 12082
		public byte equipType;

		// Token: 0x04002F33 RID: 12083
		public uint strengthen;

		// Token: 0x04002F34 RID: 12084
		public byte isTimeLimit;
	}
}
