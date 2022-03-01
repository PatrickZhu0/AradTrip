using System;

namespace Protocol
{
	// Token: 0x02000B29 RID: 2857
	[Protocol]
	public class WorldBindDeviceReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A65 RID: 31333 RVA: 0x0015F798 File Offset: 0x0015DB98
		public uint GetMsgID()
		{
			return 608408U;
		}

		// Token: 0x06007A66 RID: 31334 RVA: 0x0015F79F File Offset: 0x0015DB9F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A67 RID: 31335 RVA: 0x0015F7A7 File Offset: 0x0015DBA7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A68 RID: 31336 RVA: 0x0015F7B0 File Offset: 0x0015DBB0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.bindType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.deviceID);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A69 RID: 31337 RVA: 0x0015F7E8 File Offset: 0x0015DBE8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bindType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.deviceID = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A6A RID: 31338 RVA: 0x0015F844 File Offset: 0x0015DC44
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.bindType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.deviceID);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A6B RID: 31339 RVA: 0x0015F880 File Offset: 0x0015DC80
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bindType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.deviceID = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A6C RID: 31340 RVA: 0x0015F8DC File Offset: 0x0015DCDC
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.deviceID);
			return num + (2 + array.Length);
		}

		// Token: 0x040039C8 RID: 14792
		public const uint MsgID = 608408U;

		// Token: 0x040039C9 RID: 14793
		public uint Sequence;

		// Token: 0x040039CA RID: 14794
		public uint bindType;

		// Token: 0x040039CB RID: 14795
		public string deviceID;
	}
}
