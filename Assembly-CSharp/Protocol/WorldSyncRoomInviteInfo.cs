using System;

namespace Protocol
{
	// Token: 0x02000AD3 RID: 2771
	[Protocol]
	public class WorldSyncRoomInviteInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077B6 RID: 30646 RVA: 0x0015A2EA File Offset: 0x001586EA
		public uint GetMsgID()
		{
			return 607804U;
		}

		// Token: 0x060077B7 RID: 30647 RVA: 0x0015A2F1 File Offset: 0x001586F1
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077B8 RID: 30648 RVA: 0x0015A2F9 File Offset: 0x001586F9
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077B9 RID: 30649 RVA: 0x0015A304 File Offset: 0x00158704
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.roomName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.inviterId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.inviterName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.inviterOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.inviterAwaken);
			BaseDLL.encode_uint16(buffer, ref pos_, this.inviterLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerSize);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerMaxSize);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
		}

		// Token: 0x060077BA RID: 30650 RVA: 0x0015A3C8 File Offset: 0x001587C8
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
			this.roomName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.inviterId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.inviterName = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inviterOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inviterAwaken);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.inviterLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerSize);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerMaxSize);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
		}

		// Token: 0x060077BB RID: 30651 RVA: 0x0015A4DC File Offset: 0x001588DC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.roomName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			BaseDLL.encode_uint64(buffer, ref pos_, this.inviterId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.inviterName);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.inviterOccu);
			BaseDLL.encode_int8(buffer, ref pos_, this.inviterAwaken);
			BaseDLL.encode_uint16(buffer, ref pos_, this.inviterLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerSize);
			BaseDLL.encode_uint32(buffer, ref pos_, this.playerMaxSize);
			BaseDLL.encode_int8(buffer, ref pos_, this.slotGroup);
		}

		// Token: 0x060077BC RID: 30652 RVA: 0x0015A5A8 File Offset: 0x001589A8
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
			this.roomName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.inviterId);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.inviterName = StringHelper.BytesToString(array2);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inviterOccu);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inviterAwaken);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.inviterLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerSize);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.playerMaxSize);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slotGroup);
		}

		// Token: 0x060077BD RID: 30653 RVA: 0x0015A6BC File Offset: 0x00158ABC
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.roomName);
			num += 2 + array.Length;
			num++;
			num += 8;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.inviterName);
			num += 2 + array2.Length;
			num++;
			num++;
			num += 2;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x0400385C RID: 14428
		public const uint MsgID = 607804U;

		// Token: 0x0400385D RID: 14429
		public uint Sequence;

		// Token: 0x0400385E RID: 14430
		public uint roomId;

		// Token: 0x0400385F RID: 14431
		public string roomName;

		// Token: 0x04003860 RID: 14432
		public byte roomType;

		// Token: 0x04003861 RID: 14433
		public ulong inviterId;

		// Token: 0x04003862 RID: 14434
		public string inviterName;

		// Token: 0x04003863 RID: 14435
		public byte inviterOccu;

		// Token: 0x04003864 RID: 14436
		public byte inviterAwaken;

		// Token: 0x04003865 RID: 14437
		public ushort inviterLevel;

		// Token: 0x04003866 RID: 14438
		public uint playerSize;

		// Token: 0x04003867 RID: 14439
		public uint playerMaxSize;

		// Token: 0x04003868 RID: 14440
		public byte slotGroup;
	}
}
