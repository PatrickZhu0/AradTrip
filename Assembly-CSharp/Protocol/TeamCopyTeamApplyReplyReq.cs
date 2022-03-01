using System;

namespace Protocol
{
	// Token: 0x02000BD5 RID: 3029
	[Protocol]
	public class TeamCopyTeamApplyReplyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F1E RID: 32542 RVA: 0x00168EC1 File Offset: 0x001672C1
		public uint GetMsgID()
		{
			return 1100025U;
		}

		// Token: 0x06007F1F RID: 32543 RVA: 0x00168EC8 File Offset: 0x001672C8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F20 RID: 32544 RVA: 0x00168ED0 File Offset: 0x001672D0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F21 RID: 32545 RVA: 0x00168EDC File Offset: 0x001672DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAgree);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerIds.Length);
			for (int i = 0; i < this.playerIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.playerIds[i]);
			}
		}

		// Token: 0x06007F22 RID: 32546 RVA: 0x00168F34 File Offset: 0x00167334
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAgree);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerIds = new ulong[(int)num];
			for (int i = 0; i < this.playerIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerIds[i]);
			}
		}

		// Token: 0x06007F23 RID: 32547 RVA: 0x00168F94 File Offset: 0x00167394
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.isAgree);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerIds.Length);
			for (int i = 0; i < this.playerIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.playerIds[i]);
			}
		}

		// Token: 0x06007F24 RID: 32548 RVA: 0x00168FEC File Offset: 0x001673EC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isAgree);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerIds = new ulong[(int)num];
			for (int i = 0; i < this.playerIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.playerIds[i]);
			}
		}

		// Token: 0x06007F25 RID: 32549 RVA: 0x0016904C File Offset: 0x0016744C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + 8 * this.playerIds.Length);
		}

		// Token: 0x04003CB5 RID: 15541
		public const uint MsgID = 1100025U;

		// Token: 0x04003CB6 RID: 15542
		public uint Sequence;

		// Token: 0x04003CB7 RID: 15543
		public uint isAgree;

		// Token: 0x04003CB8 RID: 15544
		public ulong[] playerIds = new ulong[0];
	}
}
