using System;

namespace Protocol
{
	// Token: 0x0200083E RID: 2110
	[Protocol]
	public class WorldGuildModifyName : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063A0 RID: 25504 RVA: 0x0012AB44 File Offset: 0x00128F44
		public uint GetMsgID()
		{
			return 601922U;
		}

		// Token: 0x060063A1 RID: 25505 RVA: 0x0012AB4B File Offset: 0x00128F4B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063A2 RID: 25506 RVA: 0x0012AB53 File Offset: 0x00128F53
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063A3 RID: 25507 RVA: 0x0012AB5C File Offset: 0x00128F5C
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGUID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTableID);
		}

		// Token: 0x060063A4 RID: 25508 RVA: 0x0012ABA4 File Offset: 0x00128FA4
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGUID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTableID);
		}

		// Token: 0x060063A5 RID: 25509 RVA: 0x0012AC10 File Offset: 0x00129010
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGUID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTableID);
		}

		// Token: 0x060063A6 RID: 25510 RVA: 0x0012AC58 File Offset: 0x00129058
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGUID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTableID);
		}

		// Token: 0x060063A7 RID: 25511 RVA: 0x0012ACC4 File Offset: 0x001290C4
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 8;
			return num + 4;
		}

		// Token: 0x04002CB7 RID: 11447
		public const uint MsgID = 601922U;

		// Token: 0x04002CB8 RID: 11448
		public uint Sequence;

		// Token: 0x04002CB9 RID: 11449
		public string name;

		// Token: 0x04002CBA RID: 11450
		public ulong itemGUID;

		// Token: 0x04002CBB RID: 11451
		public uint itemTableID;
	}
}
