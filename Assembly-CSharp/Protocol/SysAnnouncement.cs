using System;

namespace Protocol
{
	// Token: 0x0200077E RID: 1918
	[Protocol]
	public class SysAnnouncement : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E6C RID: 24172 RVA: 0x0011B04C File Offset: 0x0011944C
		public uint GetMsgID()
		{
			return 25U;
		}

		// Token: 0x06005E6D RID: 24173 RVA: 0x0011B050 File Offset: 0x00119450
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E6E RID: 24174 RVA: 0x0011B058 File Offset: 0x00119458
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E6F RID: 24175 RVA: 0x0011B064 File Offset: 0x00119464
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.word);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005E70 RID: 24176 RVA: 0x0011B09C File Offset: 0x0011949C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.word = StringHelper.BytesToString(array);
		}

		// Token: 0x06005E71 RID: 24177 RVA: 0x0011B0F8 File Offset: 0x001194F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.word);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005E72 RID: 24178 RVA: 0x0011B134 File Offset: 0x00119534
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.word = StringHelper.BytesToString(array);
		}

		// Token: 0x06005E73 RID: 24179 RVA: 0x0011B190 File Offset: 0x00119590
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.word);
			return num + (2 + array.Length);
		}

		// Token: 0x040026C9 RID: 9929
		public const uint MsgID = 25U;

		// Token: 0x040026CA RID: 9930
		public uint Sequence;

		// Token: 0x040026CB RID: 9931
		public uint id;

		// Token: 0x040026CC RID: 9932
		public string word;
	}
}
