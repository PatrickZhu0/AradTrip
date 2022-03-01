using System;

namespace Protocol
{
	// Token: 0x02000721 RID: 1825
	[Protocol]
	public class SceneBattleNoWarOption : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B99 RID: 23449 RVA: 0x00115658 File Offset: 0x00113A58
		public uint GetMsgID()
		{
			return 508942U;
		}

		// Token: 0x06005B9A RID: 23450 RVA: 0x0011565F File Offset: 0x00113A5F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B9B RID: 23451 RVA: 0x00115667 File Offset: 0x00113A67
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B9C RID: 23452 RVA: 0x00115670 File Offset: 0x00113A70
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.enemyRoleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.enemyName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005B9D RID: 23453 RVA: 0x001156A8 File Offset: 0x00113AA8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.enemyRoleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.enemyName = StringHelper.BytesToString(array);
		}

		// Token: 0x06005B9E RID: 23454 RVA: 0x00115704 File Offset: 0x00113B04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.enemyRoleId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.enemyName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x06005B9F RID: 23455 RVA: 0x00115740 File Offset: 0x00113B40
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.enemyRoleId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.enemyName = StringHelper.BytesToString(array);
		}

		// Token: 0x06005BA0 RID: 23456 RVA: 0x0011579C File Offset: 0x00113B9C
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.enemyName);
			return num + (2 + array.Length);
		}

		// Token: 0x04002558 RID: 9560
		public const uint MsgID = 508942U;

		// Token: 0x04002559 RID: 9561
		public uint Sequence;

		// Token: 0x0400255A RID: 9562
		public ulong enemyRoleId;

		// Token: 0x0400255B RID: 9563
		public string enemyName;
	}
}
