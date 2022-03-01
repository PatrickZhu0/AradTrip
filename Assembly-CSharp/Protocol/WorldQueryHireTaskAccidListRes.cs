using System;

namespace Protocol
{
	// Token: 0x02000C3F RID: 3135
	[Protocol]
	public class WorldQueryHireTaskAccidListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008293 RID: 33427 RVA: 0x0016FB30 File Offset: 0x0016DF30
		public uint GetMsgID()
		{
			return 601789U;
		}

		// Token: 0x06008294 RID: 33428 RVA: 0x0016FB37 File Offset: 0x0016DF37
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008295 RID: 33429 RVA: 0x0016FB3F File Offset: 0x0016DF3F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008296 RID: 33430 RVA: 0x0016FB48 File Offset: 0x0016DF48
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.nameList.Length);
			for (int i = 0; i < this.nameList.Length; i++)
			{
				byte[] str = StringHelper.StringToUTF8Bytes(this.nameList[i]);
				BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			}
		}

		// Token: 0x06008297 RID: 33431 RVA: 0x0016FBA0 File Offset: 0x0016DFA0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.nameList = new string[(int)num];
			for (int i = 0; i < this.nameList.Length; i++)
			{
				ushort num2 = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
				byte[] array = new byte[(int)num2];
				for (int j = 0; j < (int)num2; j++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref array[j]);
				}
				this.nameList[i] = StringHelper.BytesToString(array);
			}
		}

		// Token: 0x06008298 RID: 33432 RVA: 0x0016FC28 File Offset: 0x0016E028
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.nameList.Length);
			for (int i = 0; i < this.nameList.Length; i++)
			{
				byte[] str = StringHelper.StringToUTF8Bytes(this.nameList[i]);
				BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			}
		}

		// Token: 0x06008299 RID: 33433 RVA: 0x0016FC80 File Offset: 0x0016E080
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.nameList = new string[(int)num];
			for (int i = 0; i < this.nameList.Length; i++)
			{
				ushort num2 = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
				byte[] array = new byte[(int)num2];
				for (int j = 0; j < (int)num2; j++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref array[j]);
				}
				this.nameList[i] = StringHelper.BytesToString(array);
			}
		}

		// Token: 0x0600829A RID: 33434 RVA: 0x0016FD08 File Offset: 0x0016E108
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.nameList.Length; i++)
			{
				byte[] array = StringHelper.StringToUTF8Bytes(this.nameList[i]);
				num += 2 + array.Length;
			}
			return num;
		}

		// Token: 0x04003E59 RID: 15961
		public const uint MsgID = 601789U;

		// Token: 0x04003E5A RID: 15962
		public uint Sequence;

		// Token: 0x04003E5B RID: 15963
		public string[] nameList = new string[0];
	}
}
