using System;

namespace Protocol
{
	// Token: 0x02000B38 RID: 2872
	[Protocol]
	public class SceneCheckChangeNameReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007ABF RID: 31423 RVA: 0x001602C4 File Offset: 0x0015E6C4
		public uint GetMsgID()
		{
			return 501216U;
		}

		// Token: 0x06007AC0 RID: 31424 RVA: 0x001602CB File Offset: 0x0015E6CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007AC1 RID: 31425 RVA: 0x001602D3 File Offset: 0x0015E6D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007AC2 RID: 31426 RVA: 0x001602DC File Offset: 0x0015E6DC
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.newName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007AC3 RID: 31427 RVA: 0x00160308 File Offset: 0x0015E708
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.newName = StringHelper.BytesToString(array);
		}

		// Token: 0x06007AC4 RID: 31428 RVA: 0x00160358 File Offset: 0x0015E758
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.newName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06007AC5 RID: 31429 RVA: 0x00160384 File Offset: 0x0015E784
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.newName = StringHelper.BytesToString(array);
		}

		// Token: 0x06007AC6 RID: 31430 RVA: 0x001603D4 File Offset: 0x0015E7D4
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.newName);
			return num + (2 + array.Length);
		}

		// Token: 0x04003A31 RID: 14897
		public const uint MsgID = 501216U;

		// Token: 0x04003A32 RID: 14898
		public uint Sequence;

		// Token: 0x04003A33 RID: 14899
		public string newName;
	}
}
