using System;

namespace Protocol
{
	// Token: 0x020006A4 RID: 1700
	[Protocol]
	public class WorldDispatchExpeditionTeamReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057D7 RID: 22487 RVA: 0x0010B7F1 File Offset: 0x00109BF1
		public uint GetMsgID()
		{
			return 608615U;
		}

		// Token: 0x060057D8 RID: 22488 RVA: 0x0010B7F8 File Offset: 0x00109BF8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057D9 RID: 22489 RVA: 0x0010B800 File Offset: 0x00109C00
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057DA RID: 22490 RVA: 0x0010B80C File Offset: 0x00109C0C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.members.Length);
			for (int i = 0; i < this.members.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.members[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.housOfduration);
		}

		// Token: 0x060057DB RID: 22491 RVA: 0x0010B870 File Offset: 0x00109C70
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.members = new ulong[(int)num];
			for (int i = 0; i < this.members.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.members[i]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.housOfduration);
		}

		// Token: 0x060057DC RID: 22492 RVA: 0x0010B8E0 File Offset: 0x00109CE0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.mapId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.members.Length);
			for (int i = 0; i < this.members.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.members[i]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.housOfduration);
		}

		// Token: 0x060057DD RID: 22493 RVA: 0x0010B944 File Offset: 0x00109D44
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.mapId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.members = new ulong[(int)num];
			for (int i = 0; i < this.members.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.members[i]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.housOfduration);
		}

		// Token: 0x060057DE RID: 22494 RVA: 0x0010B9B4 File Offset: 0x00109DB4
		public int getLen()
		{
			int num = 0;
			num++;
			num += 2 + 8 * this.members.Length;
			return num + 4;
		}

		// Token: 0x040022EF RID: 8943
		public const uint MsgID = 608615U;

		// Token: 0x040022F0 RID: 8944
		public uint Sequence;

		// Token: 0x040022F1 RID: 8945
		public byte mapId;

		// Token: 0x040022F2 RID: 8946
		public ulong[] members = new ulong[0];

		// Token: 0x040022F3 RID: 8947
		public uint housOfduration;
	}
}
