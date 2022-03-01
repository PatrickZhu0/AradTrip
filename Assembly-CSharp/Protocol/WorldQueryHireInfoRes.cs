using System;

namespace Protocol
{
	// Token: 0x02000C38 RID: 3128
	[Protocol]
	public class WorldQueryHireInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008257 RID: 33367 RVA: 0x0016F454 File Offset: 0x0016D854
		public uint GetMsgID()
		{
			return 601783U;
		}

		// Token: 0x06008258 RID: 33368 RVA: 0x0016F45B File Offset: 0x0016D85B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008259 RID: 33369 RVA: 0x0016F463 File Offset: 0x0016D863
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600825A RID: 33370 RVA: 0x0016F46C File Offset: 0x0016D86C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.identity);
			byte[] str = StringHelper.StringToUTF8Bytes(this.code);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isBind);
			BaseDLL.encode_int8(buffer, ref pos_, this.isOtherBindMe);
		}

		// Token: 0x0600825B RID: 33371 RVA: 0x0016F4C0 File Offset: 0x0016D8C0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.identity);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.code = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isBind);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isOtherBindMe);
		}

		// Token: 0x0600825C RID: 33372 RVA: 0x0016F538 File Offset: 0x0016D938
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.identity);
			byte[] str = StringHelper.StringToUTF8Bytes(this.code);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.isBind);
			BaseDLL.encode_int8(buffer, ref pos_, this.isOtherBindMe);
		}

		// Token: 0x0600825D RID: 33373 RVA: 0x0016F590 File Offset: 0x0016D990
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.identity);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.code = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isBind);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isOtherBindMe);
		}

		// Token: 0x0600825E RID: 33374 RVA: 0x0016F608 File Offset: 0x0016DA08
		public int getLen()
		{
			int num = 0;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.code);
			num += 2 + array.Length;
			num++;
			return num + 1;
		}

		// Token: 0x04003E42 RID: 15938
		public const uint MsgID = 601783U;

		// Token: 0x04003E43 RID: 15939
		public uint Sequence;

		// Token: 0x04003E44 RID: 15940
		public byte identity;

		// Token: 0x04003E45 RID: 15941
		public string code;

		// Token: 0x04003E46 RID: 15942
		public byte isBind;

		// Token: 0x04003E47 RID: 15943
		public byte isOtherBindMe;
	}
}
