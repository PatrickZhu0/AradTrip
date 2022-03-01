using System;

namespace Protocol
{
	// Token: 0x02000BCA RID: 3018
	[Protocol]
	public class TeamCopyVoteFinish : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007EC7 RID: 32455 RVA: 0x00167C3C File Offset: 0x0016603C
		public uint GetMsgID()
		{
			return 1100018U;
		}

		// Token: 0x06007EC8 RID: 32456 RVA: 0x00167C43 File Offset: 0x00166043
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007EC9 RID: 32457 RVA: 0x00167C4B File Offset: 0x0016604B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007ECA RID: 32458 RVA: 0x00167C54 File Offset: 0x00166054
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.notVotePlayer.Length);
			for (int i = 0; i < this.notVotePlayer.Length; i++)
			{
				byte[] str = StringHelper.StringToUTF8Bytes(this.notVotePlayer[i]);
				BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			}
		}

		// Token: 0x06007ECB RID: 32459 RVA: 0x00167CB8 File Offset: 0x001660B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.notVotePlayer = new string[(int)num];
			for (int i = 0; i < this.notVotePlayer.Length; i++)
			{
				ushort num2 = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
				byte[] array = new byte[(int)num2];
				for (int j = 0; j < (int)num2; j++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref array[j]);
				}
				this.notVotePlayer[i] = StringHelper.BytesToString(array);
			}
		}

		// Token: 0x06007ECC RID: 32460 RVA: 0x00167D4C File Offset: 0x0016614C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.notVotePlayer.Length);
			for (int i = 0; i < this.notVotePlayer.Length; i++)
			{
				byte[] str = StringHelper.StringToUTF8Bytes(this.notVotePlayer[i]);
				BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			}
		}

		// Token: 0x06007ECD RID: 32461 RVA: 0x00167DB4 File Offset: 0x001661B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.notVotePlayer = new string[(int)num];
			for (int i = 0; i < this.notVotePlayer.Length; i++)
			{
				ushort num2 = 0;
				BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
				byte[] array = new byte[(int)num2];
				for (int j = 0; j < (int)num2; j++)
				{
					BaseDLL.decode_int8(buffer, ref pos_, ref array[j]);
				}
				this.notVotePlayer[i] = StringHelper.BytesToString(array);
			}
		}

		// Token: 0x06007ECE RID: 32462 RVA: 0x00167E48 File Offset: 0x00166248
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.notVotePlayer.Length; i++)
			{
				byte[] array = StringHelper.StringToUTF8Bytes(this.notVotePlayer[i]);
				num += 2 + array.Length;
			}
			return num;
		}

		// Token: 0x04003C86 RID: 15494
		public const uint MsgID = 1100018U;

		// Token: 0x04003C87 RID: 15495
		public uint Sequence;

		// Token: 0x04003C88 RID: 15496
		public uint result;

		// Token: 0x04003C89 RID: 15497
		public string[] notVotePlayer = new string[0];
	}
}
