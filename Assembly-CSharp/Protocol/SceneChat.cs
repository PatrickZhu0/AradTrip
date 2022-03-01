using System;

namespace Protocol
{
	// Token: 0x0200077B RID: 1915
	[Protocol]
	public class SceneChat : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E51 RID: 24145 RVA: 0x0011AB20 File Offset: 0x00118F20
		public uint GetMsgID()
		{
			return 500801U;
		}

		// Token: 0x06005E52 RID: 24146 RVA: 0x0011AB27 File Offset: 0x00118F27
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E53 RID: 24147 RVA: 0x0011AB2F File Offset: 0x00118F2F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E54 RID: 24148 RVA: 0x0011AB38 File Offset: 0x00118F38
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.channel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.word);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.bLink);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.voiceKey);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.voiceDuration);
			BaseDLL.encode_int8(buffer, ref pos_, this.isShare);
		}

		// Token: 0x06005E55 RID: 24149 RVA: 0x0011ABC4 File Offset: 0x00118FC4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.channel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.word = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bLink);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.voiceKey = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.voiceDuration);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isShare);
		}

		// Token: 0x06005E56 RID: 24150 RVA: 0x0011ACA0 File Offset: 0x001190A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.channel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.targetId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.word);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.bLink);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.voiceKey);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.voiceDuration);
			BaseDLL.encode_int8(buffer, ref pos_, this.isShare);
		}

		// Token: 0x06005E57 RID: 24151 RVA: 0x0011AD34 File Offset: 0x00119134
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.channel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.targetId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.word = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bLink);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.voiceKey = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.voiceDuration);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isShare);
		}

		// Token: 0x06005E58 RID: 24152 RVA: 0x0011AE10 File Offset: 0x00119210
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.word);
			num += 2 + array.Length;
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.voiceKey);
			num += 2 + array2.Length;
			num++;
			return num + 1;
		}

		// Token: 0x040026B9 RID: 9913
		public const uint MsgID = 500801U;

		// Token: 0x040026BA RID: 9914
		public uint Sequence;

		// Token: 0x040026BB RID: 9915
		public byte channel;

		// Token: 0x040026BC RID: 9916
		public ulong targetId;

		// Token: 0x040026BD RID: 9917
		public string word;

		// Token: 0x040026BE RID: 9918
		public byte bLink;

		// Token: 0x040026BF RID: 9919
		public string voiceKey;

		// Token: 0x040026C0 RID: 9920
		public byte voiceDuration;

		// Token: 0x040026C1 RID: 9921
		public byte isShare;
	}
}
