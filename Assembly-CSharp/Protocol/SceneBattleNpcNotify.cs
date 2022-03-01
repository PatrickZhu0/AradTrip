using System;

namespace Protocol
{
	// Token: 0x02000714 RID: 1812
	[Protocol]
	public class SceneBattleNpcNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B27 RID: 23335 RVA: 0x001148DA File Offset: 0x00112CDA
		public uint GetMsgID()
		{
			return 508929U;
		}

		// Token: 0x06005B28 RID: 23336 RVA: 0x001148E1 File Offset: 0x00112CE1
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B29 RID: 23337 RVA: 0x001148E9 File Offset: 0x00112CE9
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B2A RID: 23338 RVA: 0x001148F4 File Offset: 0x00112CF4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battleNpcList.Length);
			for (int i = 0; i < this.battleNpcList.Length; i++)
			{
				this.battleNpcList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005B2B RID: 23339 RVA: 0x0011493C File Offset: 0x00112D3C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battleNpcList = new BattleNpc[(int)num];
			for (int i = 0; i < this.battleNpcList.Length; i++)
			{
				this.battleNpcList[i] = new BattleNpc();
				this.battleNpcList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005B2C RID: 23340 RVA: 0x00114998 File Offset: 0x00112D98
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battleNpcList.Length);
			for (int i = 0; i < this.battleNpcList.Length; i++)
			{
				this.battleNpcList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005B2D RID: 23341 RVA: 0x001149E0 File Offset: 0x00112DE0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battleNpcList = new BattleNpc[(int)num];
			for (int i = 0; i < this.battleNpcList.Length; i++)
			{
				this.battleNpcList[i] = new BattleNpc();
				this.battleNpcList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005B2E RID: 23342 RVA: 0x00114A3C File Offset: 0x00112E3C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.battleNpcList.Length; i++)
			{
				num += this.battleNpcList[i].getLen();
			}
			return num;
		}

		// Token: 0x04002522 RID: 9506
		public const uint MsgID = 508929U;

		// Token: 0x04002523 RID: 9507
		public uint Sequence;

		// Token: 0x04002524 RID: 9508
		public BattleNpc[] battleNpcList = new BattleNpc[0];
	}
}
