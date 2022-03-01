using System;

namespace Protocol
{
	// Token: 0x020007CC RID: 1996
	[Protocol]
	public class SceneDungeonKillMonsterReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600609A RID: 24730 RVA: 0x001226F4 File Offset: 0x00120AF4
		public uint GetMsgID()
		{
			return 506819U;
		}

		// Token: 0x0600609B RID: 24731 RVA: 0x001226FB File Offset: 0x00120AFB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600609C RID: 24732 RVA: 0x00122703 File Offset: 0x00120B03
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600609D RID: 24733 RVA: 0x0012270C File Offset: 0x00120B0C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsterIds.Length);
			for (int i = 0; i < this.monsterIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.monsterIds[i]);
			}
		}

		// Token: 0x0600609E RID: 24734 RVA: 0x00122754 File Offset: 0x00120B54
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

		// Token: 0x0600609F RID: 24735 RVA: 0x001227A8 File Offset: 0x00120BA8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsterIds.Length);
			for (int i = 0; i < this.monsterIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.monsterIds[i]);
			}
		}

		// Token: 0x060060A0 RID: 24736 RVA: 0x001227F0 File Offset: 0x00120BF0
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

		// Token: 0x060060A1 RID: 24737 RVA: 0x00122844 File Offset: 0x00120C44
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.monsterIds.Length);
		}

		// Token: 0x0400284B RID: 10315
		public const uint MsgID = 506819U;

		// Token: 0x0400284C RID: 10316
		public uint Sequence;

		// Token: 0x0400284D RID: 10317
		public uint[] monsterIds = new uint[0];
	}
}
