using System;

namespace Protocol
{
	// Token: 0x02000C85 RID: 3205
	[Protocol]
	public class WorldRelationFindPlayersReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008476 RID: 33910 RVA: 0x001730FC File Offset: 0x001714FC
		public uint GetMsgID()
		{
			return 601709U;
		}

		// Token: 0x06008477 RID: 33911 RVA: 0x00173103 File Offset: 0x00171503
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008478 RID: 33912 RVA: 0x0017310B File Offset: 0x0017150B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008479 RID: 33913 RVA: 0x00173114 File Offset: 0x00171514
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600847A RID: 33914 RVA: 0x0017314C File Offset: 0x0017154C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
		}

		// Token: 0x0600847B RID: 33915 RVA: 0x001731A8 File Offset: 0x001715A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600847C RID: 33916 RVA: 0x001731E4 File Offset: 0x001715E4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
		}

		// Token: 0x0600847D RID: 33917 RVA: 0x00173240 File Offset: 0x00171640
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			return num + (2 + array.Length);
		}

		// Token: 0x04003F5E RID: 16222
		public const uint MsgID = 601709U;

		// Token: 0x04003F5F RID: 16223
		public uint Sequence;

		// Token: 0x04003F60 RID: 16224
		public byte type;

		// Token: 0x04003F61 RID: 16225
		public string name;
	}
}
