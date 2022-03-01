using System;

namespace Protocol
{
	// Token: 0x020007B3 RID: 1971
	public class SceneDungeonDropItem : IProtocolStream
	{
		// Token: 0x06005FDD RID: 24541 RVA: 0x0011EB44 File Offset: 0x0011CF44
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.typeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.isDouble);
			BaseDLL.encode_int8(buffer, ref pos_, this.strenth);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
		}

		// Token: 0x06005FDE RID: 24542 RVA: 0x0011EBA8 File Offset: 0x0011CFA8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.typeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isDouble);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
		}

		// Token: 0x06005FDF RID: 24543 RVA: 0x0011EC0C File Offset: 0x0011D00C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.typeId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
			BaseDLL.encode_int8(buffer, ref pos_, this.isDouble);
			BaseDLL.encode_int8(buffer, ref pos_, this.strenth);
			BaseDLL.encode_int8(buffer, ref pos_, this.equipType);
		}

		// Token: 0x06005FE0 RID: 24544 RVA: 0x0011EC70 File Offset: 0x0011D070
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.typeId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isDouble);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strenth);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.equipType);
		}

		// Token: 0x06005FE1 RID: 24545 RVA: 0x0011ECD4 File Offset: 0x0011D0D4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num++;
			return num + 1;
		}

		// Token: 0x040027B0 RID: 10160
		public uint id;

		// Token: 0x040027B1 RID: 10161
		public uint typeId;

		// Token: 0x040027B2 RID: 10162
		public uint num;

		// Token: 0x040027B3 RID: 10163
		public byte isDouble;

		// Token: 0x040027B4 RID: 10164
		public byte strenth;

		// Token: 0x040027B5 RID: 10165
		public byte equipType;
	}
}
