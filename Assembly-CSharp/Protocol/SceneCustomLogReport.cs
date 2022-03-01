using System;

namespace Protocol
{
	// Token: 0x02000788 RID: 1928
	[Protocol]
	public class SceneCustomLogReport : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005EC3 RID: 24259 RVA: 0x0011C264 File Offset: 0x0011A664
		public uint GetMsgID()
		{
			return 503402U;
		}

		// Token: 0x06005EC4 RID: 24260 RVA: 0x0011C26B File Offset: 0x0011A66B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005EC5 RID: 24261 RVA: 0x0011C273 File Offset: 0x0011A673
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005EC6 RID: 24262 RVA: 0x0011C27C File Offset: 0x0011A67C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			byte[] str = StringHelper.StringToUTF8Bytes(this.param);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005EC7 RID: 24263 RVA: 0x0011C2B4 File Offset: 0x0011A6B4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.param = StringHelper.BytesToString(array);
		}

		// Token: 0x06005EC8 RID: 24264 RVA: 0x0011C310 File Offset: 0x0011A710
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			byte[] str = StringHelper.StringToUTF8Bytes(this.param);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005EC9 RID: 24265 RVA: 0x0011C34C File Offset: 0x0011A74C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.param = StringHelper.BytesToString(array);
		}

		// Token: 0x06005ECA RID: 24266 RVA: 0x0011C3A8 File Offset: 0x0011A7A8
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.param);
			return num + (2 + array.Length);
		}

		// Token: 0x04002703 RID: 9987
		public const uint MsgID = 503402U;

		// Token: 0x04002704 RID: 9988
		public uint Sequence;

		// Token: 0x04002705 RID: 9989
		public byte type;

		// Token: 0x04002706 RID: 9990
		public string param;
	}
}
