using System;

namespace Protocol
{
	// Token: 0x0200077F RID: 1919
	[Protocol]
	public class SceneSyncChat : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E75 RID: 24181 RVA: 0x0011B1C0 File Offset: 0x001195C0
		public uint GetMsgID()
		{
			return 500803U;
		}

		// Token: 0x06005E76 RID: 24182 RVA: 0x0011B1C7 File Offset: 0x001195C7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E77 RID: 24183 RVA: 0x0011B1CF File Offset: 0x001195CF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E78 RID: 24184 RVA: 0x0011B1D8 File Offset: 0x001195D8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.channel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.objid);
			BaseDLL.encode_int8(buffer, ref pos_, this.sex);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.viplvl);
			byte[] str = StringHelper.StringToUTF8Bytes(this.objname);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.receiverId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.word);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.bLink);
			BaseDLL.encode_int8(buffer, ref pos_, this.isGm);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.voiceKey);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.voiceDuration);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mask);
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrame);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
		}

		// Token: 0x06005E79 RID: 24185 RVA: 0x0011B2F0 File Offset: 0x001196F0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.channel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.objid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.viplvl);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.objname = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.receiverId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.word = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bLink);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isGm);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.voiceKey = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.voiceDuration);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mask);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrame);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
		}

		// Token: 0x06005E7A RID: 24186 RVA: 0x0011B488 File Offset: 0x00119888
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.channel);
			BaseDLL.encode_uint64(buffer, ref pos_, this.objid);
			BaseDLL.encode_int8(buffer, ref pos_, this.sex);
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.viplvl);
			byte[] str = StringHelper.StringToUTF8Bytes(this.objname);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint64(buffer, ref pos_, this.receiverId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.word);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.bLink);
			BaseDLL.encode_int8(buffer, ref pos_, this.isGm);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.voiceKey);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.voiceDuration);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mask);
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrame);
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
		}

		// Token: 0x06005E7B RID: 24187 RVA: 0x0011B5A8 File Offset: 0x001199A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.channel);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.objid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.viplvl);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.objname = StringHelper.BytesToString(array);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.receiverId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.word = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.bLink);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isGm);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.voiceKey = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.voiceDuration);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mask);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrame);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
		}

		// Token: 0x06005E7C RID: 24188 RVA: 0x0011B740 File Offset: 0x00119B40
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			num++;
			num++;
			num += 2;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.objname);
			num += 2 + array.Length;
			num += 8;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.word);
			num += 2 + array2.Length;
			num++;
			num++;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.voiceKey);
			num += 2 + array3.Length;
			num++;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040026CD RID: 9933
		public const uint MsgID = 500803U;

		// Token: 0x040026CE RID: 9934
		public uint Sequence;

		// Token: 0x040026CF RID: 9935
		public byte channel;

		// Token: 0x040026D0 RID: 9936
		public ulong objid;

		// Token: 0x040026D1 RID: 9937
		public byte sex;

		// Token: 0x040026D2 RID: 9938
		public byte occu;

		// Token: 0x040026D3 RID: 9939
		public ushort level;

		// Token: 0x040026D4 RID: 9940
		public byte viplvl;

		// Token: 0x040026D5 RID: 9941
		public string objname;

		// Token: 0x040026D6 RID: 9942
		public ulong receiverId;

		// Token: 0x040026D7 RID: 9943
		public string word;

		// Token: 0x040026D8 RID: 9944
		public byte bLink;

		// Token: 0x040026D9 RID: 9945
		public byte isGm;

		// Token: 0x040026DA RID: 9946
		public string voiceKey;

		// Token: 0x040026DB RID: 9947
		public byte voiceDuration;

		// Token: 0x040026DC RID: 9948
		public uint mask;

		// Token: 0x040026DD RID: 9949
		public uint headFrame;

		// Token: 0x040026DE RID: 9950
		public uint zoneId;
	}
}
