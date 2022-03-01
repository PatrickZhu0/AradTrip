using System;

namespace Protocol
{
	// Token: 0x02000A3B RID: 2619
	[Protocol]
	public class SceneOpActivityVarSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007378 RID: 29560 RVA: 0x0014F31C File Offset: 0x0014D71C
		public uint GetMsgID()
		{
			return 507401U;
		}

		// Token: 0x06007379 RID: 29561 RVA: 0x0014F323 File Offset: 0x0014D723
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600737A RID: 29562 RVA: 0x0014F32B File Offset: 0x0014D72B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600737B RID: 29563 RVA: 0x0014F334 File Offset: 0x0014D734
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.value);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600737C RID: 29564 RVA: 0x0014F388 File Offset: 0x0014D788
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
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

		// Token: 0x0600737D RID: 29565 RVA: 0x0014F42C File Offset: 0x0014D82C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.key);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.value);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600737E RID: 29566 RVA: 0x0014F488 File Offset: 0x0014D888
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
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

		// Token: 0x0600737F RID: 29567 RVA: 0x0014F52C File Offset: 0x0014D92C
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.key);
			num += 2 + array.Length;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.value);
			return num + (2 + array2.Length);
		}

		// Token: 0x04003596 RID: 13718
		public const uint MsgID = 507401U;

		// Token: 0x04003597 RID: 13719
		public uint Sequence;

		// Token: 0x04003598 RID: 13720
		public uint opActId;

		// Token: 0x04003599 RID: 13721
		public string key;

		// Token: 0x0400359A RID: 13722
		public string value;
	}
}
