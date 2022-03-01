using System;

namespace Protocol
{
	// Token: 0x02000674 RID: 1652
	[Protocol]
	public class SceneNotifyActiveTaskVar : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600563F RID: 22079 RVA: 0x001089E4 File Offset: 0x00106DE4
		public uint GetMsgID()
		{
			return 501128U;
		}

		// Token: 0x06005640 RID: 22080 RVA: 0x001089EB File Offset: 0x00106DEB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005641 RID: 22081 RVA: 0x001089F3 File Offset: 0x00106DF3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005642 RID: 22082 RVA: 0x001089FC File Offset: 0x00106DFC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.val);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005643 RID: 22083 RVA: 0x00108A50 File Offset: 0x00106E50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
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
			this.val = StringHelper.BytesToString(array2);
		}

		// Token: 0x06005644 RID: 22084 RVA: 0x00108AF4 File Offset: 0x00106EF4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.val);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005645 RID: 22085 RVA: 0x00108B50 File Offset: 0x00106F50
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
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
			this.val = StringHelper.BytesToString(array2);
		}

		// Token: 0x06005646 RID: 22086 RVA: 0x00108BF4 File Offset: 0x00106FF4
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.key);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.val);
			return num + (2 + array2.Length);
		}

		// Token: 0x04002241 RID: 8769
		public const uint MsgID = 501128U;

		// Token: 0x04002242 RID: 8770
		public uint Sequence;

		// Token: 0x04002243 RID: 8771
		public uint taskId;

		// Token: 0x04002244 RID: 8772
		public string key;

		// Token: 0x04002245 RID: 8773
		public string val;
	}
}
