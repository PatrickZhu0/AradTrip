using System;

namespace Protocol
{
	// Token: 0x02000C13 RID: 3091
	[Protocol]
	public class TeamCopyGridMonsterDead : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600813D RID: 33085 RVA: 0x0016D510 File Offset: 0x0016B910
		public uint GetMsgID()
		{
			return 1100085U;
		}

		// Token: 0x0600813E RID: 33086 RVA: 0x0016D517 File Offset: 0x0016B917
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600813F RID: 33087 RVA: 0x0016D51F File Offset: 0x0016B91F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008140 RID: 33088 RVA: 0x0016D528 File Offset: 0x0016B928
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.monsterObjId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isKill);
		}

		// Token: 0x06008141 RID: 33089 RVA: 0x0016D546 File Offset: 0x0016B946
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.monsterObjId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isKill);
		}

		// Token: 0x06008142 RID: 33090 RVA: 0x0016D564 File Offset: 0x0016B964
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.monsterObjId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isKill);
		}

		// Token: 0x06008143 RID: 33091 RVA: 0x0016D582 File Offset: 0x0016B982
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.monsterObjId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isKill);
		}

		// Token: 0x06008144 RID: 33092 RVA: 0x0016D5A0 File Offset: 0x0016B9A0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003DB4 RID: 15796
		public const uint MsgID = 1100085U;

		// Token: 0x04003DB5 RID: 15797
		public uint Sequence;

		// Token: 0x04003DB6 RID: 15798
		public uint monsterObjId;

		// Token: 0x04003DB7 RID: 15799
		public uint isKill;
	}
}
