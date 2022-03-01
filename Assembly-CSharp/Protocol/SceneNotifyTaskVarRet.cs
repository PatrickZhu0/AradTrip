using System;

namespace Protocol
{
	// Token: 0x02000C5B RID: 3163
	[Protocol]
	public class SceneNotifyTaskVarRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600833E RID: 33598 RVA: 0x001710AC File Offset: 0x0016F4AC
		public uint GetMsgID()
		{
			return 501110U;
		}

		// Token: 0x0600833F RID: 33599 RVA: 0x001710B3 File Offset: 0x0016F4B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008340 RID: 33600 RVA: 0x001710BB File Offset: 0x0016F4BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008341 RID: 33601 RVA: 0x001710C4 File Offset: 0x0016F4C4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.value);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008342 RID: 33602 RVA: 0x00171118 File Offset: 0x0016F518
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.key = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.value = StringHelper.BytesToString(array2);
		}

		// Token: 0x06008343 RID: 33603 RVA: 0x001711BC File Offset: 0x0016F5BC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskID);
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.value);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008344 RID: 33604 RVA: 0x00171218 File Offset: 0x0016F618
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.key = StringHelper.BytesToString(array);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.value = StringHelper.BytesToString(array2);
		}

		// Token: 0x06008345 RID: 33605 RVA: 0x001712BC File Offset: 0x0016F6BC
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.key);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.value);
			return num + (2 + array2.Length);
		}

		// Token: 0x04003EC9 RID: 16073
		public const uint MsgID = 501110U;

		// Token: 0x04003ECA RID: 16074
		public uint Sequence;

		// Token: 0x04003ECB RID: 16075
		public uint taskID;

		// Token: 0x04003ECC RID: 16076
		public string key;

		// Token: 0x04003ECD RID: 16077
		public string value;
	}
}
