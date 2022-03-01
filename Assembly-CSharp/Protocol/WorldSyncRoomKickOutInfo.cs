using System;

namespace Protocol
{
	// Token: 0x02000AD4 RID: 2772
	[Protocol]
	public class WorldSyncRoomKickOutInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077BF RID: 30655 RVA: 0x0015A720 File Offset: 0x00158B20
		public uint GetMsgID()
		{
			return 607805U;
		}

		// Token: 0x060077C0 RID: 30656 RVA: 0x0015A727 File Offset: 0x00158B27
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077C1 RID: 30657 RVA: 0x0015A72F File Offset: 0x00158B2F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077C2 RID: 30658 RVA: 0x0015A738 File Offset: 0x00158B38
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint64(buffer, ref pos_, this.kickPlayerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.kickPlayerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
		}

		// Token: 0x060077C3 RID: 30659 RVA: 0x0015A78C File Offset: 0x00158B8C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.kickPlayerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.kickPlayerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
		}

		// Token: 0x060077C4 RID: 30660 RVA: 0x0015A804 File Offset: 0x00158C04
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint64(buffer, ref pos_, this.kickPlayerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.kickPlayerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
		}

		// Token: 0x060077C5 RID: 30661 RVA: 0x0015A85C File Offset: 0x00158C5C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.kickPlayerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.kickPlayerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
		}

		// Token: 0x060077C6 RID: 30662 RVA: 0x0015A8D4 File Offset: 0x00158CD4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.kickPlayerName);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x04003869 RID: 14441
		public const uint MsgID = 607805U;

		// Token: 0x0400386A RID: 14442
		public uint Sequence;

		// Token: 0x0400386B RID: 14443
		public uint reason;

		// Token: 0x0400386C RID: 14444
		public ulong kickPlayerId;

		// Token: 0x0400386D RID: 14445
		public string kickPlayerName;

		// Token: 0x0400386E RID: 14446
		public uint roomId;
	}
}
