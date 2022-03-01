using System;

namespace Protocol
{
	// Token: 0x020007CD RID: 1997
	[Protocol]
	public class SceneDungeonKillMonsterRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060A3 RID: 24739 RVA: 0x00122877 File Offset: 0x00120C77
		public uint GetMsgID()
		{
			return 506820U;
		}

		// Token: 0x060060A4 RID: 24740 RVA: 0x0012287E File Offset: 0x00120C7E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060A5 RID: 24741 RVA: 0x00122886 File Offset: 0x00120C86
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060A6 RID: 24742 RVA: 0x00122890 File Offset: 0x00120C90
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsterIds.Length);
			for (int i = 0; i < this.monsterIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.monsterIds[i]);
			}
		}

		// Token: 0x060060A7 RID: 24743 RVA: 0x001228D8 File Offset: 0x00120CD8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsterIds = new uint[(int)num];
			for (int i = 0; i < this.monsterIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.monsterIds[i]);
			}
		}

		// Token: 0x060060A8 RID: 24744 RVA: 0x0012292C File Offset: 0x00120D2C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsterIds.Length);
			for (int i = 0; i < this.monsterIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.monsterIds[i]);
			}
		}

		// Token: 0x060060A9 RID: 24745 RVA: 0x00122974 File Offset: 0x00120D74
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsterIds = new uint[(int)num];
			for (int i = 0; i < this.monsterIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.monsterIds[i]);
			}
		}

		// Token: 0x060060AA RID: 24746 RVA: 0x001229C8 File Offset: 0x00120DC8
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.monsterIds.Length);
		}

		// Token: 0x0400284E RID: 10318
		public const uint MsgID = 506820U;

		// Token: 0x0400284F RID: 10319
		public uint Sequence;

		// Token: 0x04002850 RID: 10320
		public uint[] monsterIds = new uint[0];
	}
}
