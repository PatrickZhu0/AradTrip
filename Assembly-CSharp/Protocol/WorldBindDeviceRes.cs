using System;

namespace Protocol
{
	// Token: 0x02000B2A RID: 2858
	[Protocol]
	public class WorldBindDeviceRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007A6E RID: 31342 RVA: 0x0015F90C File Offset: 0x0015DD0C
		public uint GetMsgID()
		{
			return 608409U;
		}

		// Token: 0x06007A6F RID: 31343 RVA: 0x0015F913 File Offset: 0x0015DD13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007A70 RID: 31344 RVA: 0x0015F91B File Offset: 0x0015DD1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007A71 RID: 31345 RVA: 0x0015F924 File Offset: 0x0015DD24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bindState);
			byte[] str = StringHelper.StringToUTF8Bytes(this.deviceID);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A72 RID: 31346 RVA: 0x0015F96C File Offset: 0x0015DD6C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bindState);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.deviceID = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A73 RID: 31347 RVA: 0x0015F9D8 File Offset: 0x0015DDD8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.ret);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bindState);
			byte[] str = StringHelper.StringToUTF8Bytes(this.deviceID);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007A74 RID: 31348 RVA: 0x0015FA20 File Offset: 0x0015DE20
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ret);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bindState);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.deviceID = StringHelper.BytesToString(array);
		}

		// Token: 0x06007A75 RID: 31349 RVA: 0x0015FA8C File Offset: 0x0015DE8C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.deviceID);
			return num + (2 + array.Length);
		}

		// Token: 0x040039CC RID: 14796
		public const uint MsgID = 608409U;

		// Token: 0x040039CD RID: 14797
		public uint Sequence;

		// Token: 0x040039CE RID: 14798
		public uint ret;

		// Token: 0x040039CF RID: 14799
		public uint bindState;

		// Token: 0x040039D0 RID: 14800
		public string deviceID;
	}
}
