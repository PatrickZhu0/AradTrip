using System;

namespace Protocol
{
	// Token: 0x02000671 RID: 1649
	[Protocol]
	public class WorldNotifyClientActivity : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005624 RID: 22052 RVA: 0x001084DB File Offset: 0x001068DB
		public uint GetMsgID()
		{
			return 602901U;
		}

		// Token: 0x06005625 RID: 22053 RVA: 0x001084E2 File Offset: 0x001068E2
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005626 RID: 22054 RVA: 0x001084EA File Offset: 0x001068EA
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005627 RID: 22055 RVA: 0x001084F4 File Offset: 0x001068F4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dueTime);
		}

		// Token: 0x06005628 RID: 22056 RVA: 0x00108574 File Offset: 0x00106974
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dueTime);
		}

		// Token: 0x06005629 RID: 22057 RVA: 0x00108618 File Offset: 0x00106A18
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dueTime);
		}

		// Token: 0x0600562A RID: 22058 RVA: 0x00108698 File Offset: 0x00106A98
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dueTime);
		}

		// Token: 0x0600562B RID: 22059 RVA: 0x0010873C File Offset: 0x00106B3C
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num += 2;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002231 RID: 8753
		public const uint MsgID = 602901U;

		// Token: 0x04002232 RID: 8754
		public uint Sequence;

		// Token: 0x04002233 RID: 8755
		public byte type;

		// Token: 0x04002234 RID: 8756
		public uint id;

		// Token: 0x04002235 RID: 8757
		public string name;

		// Token: 0x04002236 RID: 8758
		public ushort level;

		// Token: 0x04002237 RID: 8759
		public uint preTime;

		// Token: 0x04002238 RID: 8760
		public uint startTime;

		// Token: 0x04002239 RID: 8761
		public uint dueTime;
	}
}
