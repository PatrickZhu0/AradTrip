using System;

namespace Protocol
{
	// Token: 0x02000A2D RID: 2605
	[Protocol]
	public class SceneCdkReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007309 RID: 29449 RVA: 0x0014CA70 File Offset: 0x0014AE70
		public uint GetMsgID()
		{
			return 607401U;
		}

		// Token: 0x0600730A RID: 29450 RVA: 0x0014CA77 File Offset: 0x0014AE77
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600730B RID: 29451 RVA: 0x0014CA7F File Offset: 0x0014AE7F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600730C RID: 29452 RVA: 0x0014CA88 File Offset: 0x0014AE88
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.cdk);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600730D RID: 29453 RVA: 0x0014CAB4 File Offset: 0x0014AEB4
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.cdk = StringHelper.BytesToString(array);
		}

		// Token: 0x0600730E RID: 29454 RVA: 0x0014CB04 File Offset: 0x0014AF04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.cdk);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x0600730F RID: 29455 RVA: 0x0014CB30 File Offset: 0x0014AF30
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.cdk = StringHelper.BytesToString(array);
		}

		// Token: 0x06007310 RID: 29456 RVA: 0x0014CB80 File Offset: 0x0014AF80
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.cdk);
			return num + (2 + array.Length);
		}

		// Token: 0x04003546 RID: 13638
		public const uint MsgID = 607401U;

		// Token: 0x04003547 RID: 13639
		public uint Sequence;

		// Token: 0x04003548 RID: 13640
		public string cdk;
	}
}
