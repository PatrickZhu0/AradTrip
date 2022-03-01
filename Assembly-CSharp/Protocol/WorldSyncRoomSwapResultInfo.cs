using System;

namespace Protocol
{
	// Token: 0x02000AD7 RID: 2775
	[Protocol]
	public class WorldSyncRoomSwapResultInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060077DA RID: 30682 RVA: 0x0015AC60 File Offset: 0x00159060
		public uint GetMsgID()
		{
			return 607808U;
		}

		// Token: 0x060077DB RID: 30683 RVA: 0x0015AC67 File Offset: 0x00159067
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060077DC RID: 30684 RVA: 0x0015AC6F File Offset: 0x0015906F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060077DD RID: 30685 RVA: 0x0015AC78 File Offset: 0x00159078
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060077DE RID: 30686 RVA: 0x0015ACC0 File Offset: 0x001590C0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
		}

		// Token: 0x060077DF RID: 30687 RVA: 0x0015AD2C File Offset: 0x0015912C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.result);
			BaseDLL.encode_uint64(buffer, ref pos_, this.playerId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.playerName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
		}

		// Token: 0x060077E0 RID: 30688 RVA: 0x0015AD74 File Offset: 0x00159174
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.playerName = StringHelper.BytesToString(array);
		}

		// Token: 0x060077E1 RID: 30689 RVA: 0x0015ADE0 File Offset: 0x001591E0
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.playerName);
			return num + (2 + array.Length);
		}

		// Token: 0x0400387C RID: 14460
		public const uint MsgID = 607808U;

		// Token: 0x0400387D RID: 14461
		public uint Sequence;

		// Token: 0x0400387E RID: 14462
		public byte result;

		// Token: 0x0400387F RID: 14463
		public ulong playerId;

		// Token: 0x04003880 RID: 14464
		public string playerName;
	}
}
