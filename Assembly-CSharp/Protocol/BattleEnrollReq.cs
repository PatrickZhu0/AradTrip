using System;

namespace Protocol
{
	// Token: 0x020006F7 RID: 1783
	[Protocol]
	public class BattleEnrollReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005A2B RID: 23083 RVA: 0x001127B0 File Offset: 0x00110BB0
		public uint GetMsgID()
		{
			return 2200005U;
		}

		// Token: 0x06005A2C RID: 23084 RVA: 0x001127B7 File Offset: 0x00110BB7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005A2D RID: 23085 RVA: 0x001127BF File Offset: 0x00110BBF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005A2E RID: 23086 RVA: 0x001127C8 File Offset: 0x00110BC8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isMatch);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.playerOccu);
		}

		// Token: 0x06005A2F RID: 23087 RVA: 0x0011282C File Offset: 0x00110C2C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isMatch);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerOccu);
		}

		// Token: 0x06005A30 RID: 23088 RVA: 0x001128B4 File Offset: 0x00110CB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isMatch);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accId);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.playerOccu);
		}

		// Token: 0x06005A31 RID: 23089 RVA: 0x00112918 File Offset: 0x00110D18
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isMatch);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accId);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerOccu);
		}

		// Token: 0x06005A32 RID: 23090 RVA: 0x001129A0 File Offset: 0x00110DA0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array.Length;
			return num + 1;
		}

		// Token: 0x04002492 RID: 9362
		public const uint MsgID = 2200005U;

		// Token: 0x04002493 RID: 9363
		public uint Sequence;

		// Token: 0x04002494 RID: 9364
		public uint isMatch;

		// Token: 0x04002495 RID: 9365
		public uint accId;

		// Token: 0x04002496 RID: 9366
		public ulong roleId;

		// Token: 0x04002497 RID: 9367
		public string playerName;

		// Token: 0x04002498 RID: 9368
		public byte playerOccu;
	}
}
