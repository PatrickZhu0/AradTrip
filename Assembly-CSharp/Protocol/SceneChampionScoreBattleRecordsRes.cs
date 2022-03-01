using System;

namespace Protocol
{
	// Token: 0x02000768 RID: 1896
	[Protocol]
	public class SceneChampionScoreBattleRecordsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005DC7 RID: 24007 RVA: 0x001195DC File Offset: 0x001179DC
		public uint GetMsgID()
		{
			return 509830U;
		}

		// Token: 0x06005DC8 RID: 24008 RVA: 0x001195E3 File Offset: 0x001179E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005DC9 RID: 24009 RVA: 0x001195EB File Offset: 0x001179EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005DCA RID: 24010 RVA: 0x001195F4 File Offset: 0x001179F4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.recods.Length);
			for (int i = 0; i < this.recods.Length; i++)
			{
				this.recods[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DCB RID: 24011 RVA: 0x0011963C File Offset: 0x00117A3C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.recods = new ScoreBattleRecord[(int)num];
			for (int i = 0; i < this.recods.Length; i++)
			{
				this.recods[i] = new ScoreBattleRecord();
				this.recods[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DCC RID: 24012 RVA: 0x00119698 File Offset: 0x00117A98
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.recods.Length);
			for (int i = 0; i < this.recods.Length; i++)
			{
				this.recods[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DCD RID: 24013 RVA: 0x001196E0 File Offset: 0x00117AE0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.recods = new ScoreBattleRecord[(int)num];
			for (int i = 0; i < this.recods.Length; i++)
			{
				this.recods[i] = new ScoreBattleRecord();
				this.recods[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DCE RID: 24014 RVA: 0x0011973C File Offset: 0x00117B3C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.recods.Length; i++)
			{
				num += this.recods[i].getLen();
			}
			return num;
		}

		// Token: 0x04002671 RID: 9841
		public const uint MsgID = 509830U;

		// Token: 0x04002672 RID: 9842
		public uint Sequence;

		// Token: 0x04002673 RID: 9843
		public ScoreBattleRecord[] recods = new ScoreBattleRecord[0];
	}
}
