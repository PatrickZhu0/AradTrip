using System;

namespace Protocol
{
	// Token: 0x02000CBA RID: 3258
	[Protocol]
	public class WorldSetPlayerRemarkReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008641 RID: 34369 RVA: 0x00177568 File Offset: 0x00175968
		public uint GetMsgID()
		{
			return 601737U;
		}

		// Token: 0x06008642 RID: 34370 RVA: 0x0017756F File Offset: 0x0017596F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008643 RID: 34371 RVA: 0x00177577 File Offset: 0x00175977
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008644 RID: 34372 RVA: 0x00177580 File Offset: 0x00175980
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.remark);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008645 RID: 34373 RVA: 0x001775B8 File Offset: 0x001759B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.remark = StringHelper.BytesToString(array);
		}

		// Token: 0x06008646 RID: 34374 RVA: 0x00177614 File Offset: 0x00175A14
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.remark);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06008647 RID: 34375 RVA: 0x00177650 File Offset: 0x00175A50
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.remark = StringHelper.BytesToString(array);
		}

		// Token: 0x06008648 RID: 34376 RVA: 0x001776AC File Offset: 0x00175AAC
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.remark);
			return num + (2 + array.Length);
		}

		// Token: 0x04004041 RID: 16449
		public const uint MsgID = 601737U;

		// Token: 0x04004042 RID: 16450
		public uint Sequence;

		// Token: 0x04004043 RID: 16451
		public ulong roleId;

		// Token: 0x04004044 RID: 16452
		public string remark;
	}
}
