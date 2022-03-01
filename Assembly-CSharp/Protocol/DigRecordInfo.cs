using System;

namespace Protocol
{
	// Token: 0x02000793 RID: 1939
	public class DigRecordInfo : IProtocolStream
	{
		// Token: 0x06005F02 RID: 24322 RVA: 0x0011CEA8 File Offset: 0x0011B2A8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.digIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x06005F03 RID: 24323 RVA: 0x0011CF28 File Offset: 0x0011B328
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.digIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x06005F04 RID: 24324 RVA: 0x0011CFCC File Offset: 0x0011B3CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.digIndex);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
		}

		// Token: 0x06005F05 RID: 24325 RVA: 0x0011D04C File Offset: 0x0011B44C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mapId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.digIndex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
		}

		// Token: 0x06005F06 RID: 24326 RVA: 0x0011D0F0 File Offset: 0x0011B4F0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num++;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array.Length;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002730 RID: 10032
		public uint mapId;

		// Token: 0x04002731 RID: 10033
		public uint digIndex;

		// Token: 0x04002732 RID: 10034
		public byte type;

		// Token: 0x04002733 RID: 10035
		public ulong playerId;

		// Token: 0x04002734 RID: 10036
		public string playerName;

		// Token: 0x04002735 RID: 10037
		public uint itemId;

		// Token: 0x04002736 RID: 10038
		public uint itemNum;
	}
}
