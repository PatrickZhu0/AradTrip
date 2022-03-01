using System;

namespace Protocol
{
	// Token: 0x02000ADE RID: 2782
	[Protocol]
	public class WorldJoinRoomReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007819 RID: 30745 RVA: 0x0015BD36 File Offset: 0x0015A136
		public uint GetMsgID()
		{
			return 607815U;
		}

		// Token: 0x0600781A RID: 30746 RVA: 0x0015BD3D File Offset: 0x0015A13D
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600781B RID: 30747 RVA: 0x0015BD45 File Offset: 0x0015A145
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600781C RID: 30748 RVA: 0x0015BD50 File Offset: 0x0015A150
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.password);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.createTime);
		}

		// Token: 0x0600781D RID: 30749 RVA: 0x0015BDA4 File Offset: 0x0015A1A4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.password = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.createTime);
		}

		// Token: 0x0600781E RID: 30750 RVA: 0x0015BE1C File Offset: 0x0015A21C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.roomId);
			BaseDLL.encode_int8(buffer, ref pos_, this.roomType);
			byte[] str = StringHelper.StringToUTF8Bytes(this.password);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.createTime);
		}

		// Token: 0x0600781F RID: 30751 RVA: 0x0015BE74 File Offset: 0x0015A274
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roomId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roomType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.password = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.createTime);
		}

		// Token: 0x06007820 RID: 30752 RVA: 0x0015BEEC File Offset: 0x0015A2EC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			byte[] array = StringHelper.StringToUTF8Bytes(this.password);
			num += 2 + array.Length;
			return num + 4;
		}

		// Token: 0x040038B8 RID: 14520
		public const uint MsgID = 607815U;

		// Token: 0x040038B9 RID: 14521
		public uint Sequence;

		// Token: 0x040038BA RID: 14522
		public uint roomId;

		// Token: 0x040038BB RID: 14523
		public byte roomType;

		// Token: 0x040038BC RID: 14524
		public string password;

		// Token: 0x040038BD RID: 14525
		public uint createTime;
	}
}
