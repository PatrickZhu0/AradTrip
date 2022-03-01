using System;

namespace Protocol
{
	// Token: 0x02000AD6 RID: 2774
	[Protocol]
	public class WorldSyncRoomSwapSlotInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077D1 RID: 30673 RVA: 0x0015A9BC File Offset: 0x00158DBC
		public uint GetMsgID()
		{
			return 607807U;
		}

		// Token: 0x060077D2 RID: 30674 RVA: 0x0015A9C3 File Offset: 0x00158DC3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077D3 RID: 30675 RVA: 0x0015A9CB File Offset: 0x00158DCB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077D4 RID: 30676 RVA: 0x0015A9D4 File Offset: 0x00158DD4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.playerLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerAwaken);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotIndex);
		}

		// Token: 0x060077D5 RID: 30677 RVA: 0x0015AA54 File Offset: 0x00158E54
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.playerLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerAwaken);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotIndex);
		}

		// Token: 0x060077D6 RID: 30678 RVA: 0x0015AAF8 File Offset: 0x00158EF8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint16(buffer, ref pos_, this.playerLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.playerAwaken);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotIndex);
		}

		// Token: 0x060077D7 RID: 30679 RVA: 0x0015AB78 File Offset: 0x00158F78
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.playerLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.playerAwaken);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotIndex);
		}

		// Token: 0x060077D8 RID: 30680 RVA: 0x0015AC1C File Offset: 0x0015901C
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			num += 2 + array.Length;
			num += 2;
			num++;
			num++;
			num++;
			return num + 1;
		}

		// Token: 0x04003873 RID: 14451
		public const uint MsgID = 607807U;

		// Token: 0x04003874 RID: 14452
		public uint Sequence;

		// Token: 0x04003875 RID: 14453
		public ulong playerId;

		// Token: 0x04003876 RID: 14454
		public string playerName;

		// Token: 0x04003877 RID: 14455
		public ushort playerLevel;

		// Token: 0x04003878 RID: 14456
		public byte playerOccu;

		// Token: 0x04003879 RID: 14457
		public byte playerAwaken;

		// Token: 0x0400387A RID: 14458
		public byte slotGroup;

		// Token: 0x0400387B RID: 14459
		public byte slotIndex;
	}
}
