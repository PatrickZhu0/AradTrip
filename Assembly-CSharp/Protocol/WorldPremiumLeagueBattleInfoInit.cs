using System;

namespace Protocol
{
	// Token: 0x02000A73 RID: 2675
	[Protocol]
	public class WorldPremiumLeagueBattleInfoInit : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600753A RID: 30010 RVA: 0x00153208 File Offset: 0x00151608
		public uint GetMsgID()
		{
			return 607713U;
		}

		// Token: 0x0600753B RID: 30011 RVA: 0x0015320F File Offset: 0x0015160F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600753C RID: 30012 RVA: 0x00153217 File Offset: 0x00151617
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600753D RID: 30013 RVA: 0x00153220 File Offset: 0x00151620
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battles.Length);
			for (int i = 0; i < this.battles.Length; i++)
			{
				this.battles[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600753E RID: 30014 RVA: 0x00153268 File Offset: 0x00151668
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battles = new CLPremiumLeagueBattle[(int)num];
			for (int i = 0; i < this.battles.Length; i++)
			{
				this.battles[i] = new CLPremiumLeagueBattle();
				this.battles[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600753F RID: 30015 RVA: 0x001532C4 File Offset: 0x001516C4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battles.Length);
			for (int i = 0; i < this.battles.Length; i++)
			{
				this.battles[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007540 RID: 30016 RVA: 0x0015330C File Offset: 0x0015170C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battles = new CLPremiumLeagueBattle[(int)num];
			for (int i = 0; i < this.battles.Length; i++)
			{
				this.battles[i] = new CLPremiumLeagueBattle();
				this.battles[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007541 RID: 30017 RVA: 0x00153368 File Offset: 0x00151768
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.battles.Length; i++)
			{
				num += this.battles[i].getLen();
			}
			return num;
		}

		// Token: 0x04003687 RID: 13959
		public const uint MsgID = 607713U;

		// Token: 0x04003688 RID: 13960
		public uint Sequence;

		// Token: 0x04003689 RID: 13961
		public CLPremiumLeagueBattle[] battles = new CLPremiumLeagueBattle[0];
	}
}
