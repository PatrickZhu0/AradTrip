using System;

namespace Protocol
{
	// Token: 0x02000AA9 RID: 2729
	public class ReplayFighterInfo : IProtocolStream
	{
		// Token: 0x060076B7 RID: 30391 RVA: 0x00156FC8 File Offset: 0x001553C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.seasonStars);
		}

		// Token: 0x060076B8 RID: 30392 RVA: 0x00157048 File Offset: 0x00155448
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seasonStars);
		}

		// Token: 0x060076B9 RID: 30393 RVA: 0x001570EC File Offset: 0x001554EC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.pos);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.seasonStars);
		}

		// Token: 0x060076BA RID: 30394 RVA: 0x0015716C File Offset: 0x0015556C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pos);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seasonStars);
		}

		// Token: 0x060076BB RID: 30395 RVA: 0x00157210 File Offset: 0x00155610
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 2;
			num++;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003787 RID: 14215
		public ulong roleId;

		// Token: 0x04003788 RID: 14216
		public string name;

		// Token: 0x04003789 RID: 14217
		public byte occu;

		// Token: 0x0400378A RID: 14218
		public ushort level;

		// Token: 0x0400378B RID: 14219
		public byte pos;

		// Token: 0x0400378C RID: 14220
		public uint seasonLevel;

		// Token: 0x0400378D RID: 14221
		public byte seasonStars;
	}
}
