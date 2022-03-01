using System;

namespace Protocol
{
	// Token: 0x02000AD8 RID: 2776
	[Protocol]
	public class WorldSyncRoomPasswordInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077E3 RID: 30691 RVA: 0x0015AE14 File Offset: 0x00159214
		public uint GetMsgID()
		{
			return 607809U;
		}

		// Token: 0x060077E4 RID: 30692 RVA: 0x0015AE1B File Offset: 0x0015921B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077E5 RID: 30693 RVA: 0x0015AE23 File Offset: 0x00159223
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077E6 RID: 30694 RVA: 0x0015AE2C File Offset: 0x0015922C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.password);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060077E7 RID: 30695 RVA: 0x0015AE64 File Offset: 0x00159264
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.password = StringHelper.BytesToString(array);
		}

		// Token: 0x060077E8 RID: 30696 RVA: 0x0015AEC0 File Offset: 0x001592C0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.password);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060077E9 RID: 30697 RVA: 0x0015AEFC File Offset: 0x001592FC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.password = StringHelper.BytesToString(array);
		}

		// Token: 0x060077EA RID: 30698 RVA: 0x0015AF58 File Offset: 0x00159358
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.password);
			return num + (2 + array.Length);
		}

		// Token: 0x04003881 RID: 14465
		public const uint MsgID = 607809U;

		// Token: 0x04003882 RID: 14466
		public uint Sequence;

		// Token: 0x04003883 RID: 14467
		public uint roomId;

		// Token: 0x04003884 RID: 14468
		public string password;
	}
}
