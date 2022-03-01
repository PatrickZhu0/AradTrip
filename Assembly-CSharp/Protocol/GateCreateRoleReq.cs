using System;

namespace Protocol
{
	// Token: 0x020009C1 RID: 2497
	[Protocol]
	public class GateCreateRoleReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006FF1 RID: 28657 RVA: 0x00144632 File Offset: 0x00142A32
		public uint GetMsgID()
		{
			return 300302U;
		}

		// Token: 0x06006FF2 RID: 28658 RVA: 0x00144639 File Offset: 0x00142A39
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006FF3 RID: 28659 RVA: 0x00144641 File Offset: 0x00142A41
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006FF4 RID: 28660 RVA: 0x0014464C File Offset: 0x00142A4C
		public void encode(byte[] buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.sex);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupation);
			BaseDLL.encode_int8(buffer, ref pos_, this.isnewer);
		}

		// Token: 0x06006FF5 RID: 28661 RVA: 0x001446A0 File Offset: 0x00142AA0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupation);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isnewer);
		}

		// Token: 0x06006FF6 RID: 28662 RVA: 0x00144718 File Offset: 0x00142B18
		public void encode(MapViewStream buffer, ref int pos_)
		{
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.sex);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupation);
			BaseDLL.encode_int8(buffer, ref pos_, this.isnewer);
		}

		// Token: 0x06006FF7 RID: 28663 RVA: 0x00144770 File Offset: 0x00142B70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sex);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupation);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isnewer);
		}

		// Token: 0x06006FF8 RID: 28664 RVA: 0x001447E8 File Offset: 0x00142BE8
		public int getLen()
		{
			int num = 0;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num++;
			return num + 1;
		}

		// Token: 0x04003302 RID: 13058
		public const uint MsgID = 300302U;

		// Token: 0x04003303 RID: 13059
		public uint Sequence;

		// Token: 0x04003304 RID: 13060
		public string name;

		// Token: 0x04003305 RID: 13061
		public byte sex;

		// Token: 0x04003306 RID: 13062
		public byte occupation;

		// Token: 0x04003307 RID: 13063
		public byte isnewer;
	}
}
