using System;

namespace Protocol
{
	// Token: 0x0200085F RID: 2143
	[Protocol]
	public class WorldGuildBattleEnd : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064C9 RID: 25801 RVA: 0x0012C2BC File Offset: 0x0012A6BC
		public uint GetMsgID()
		{
			return 601954U;
		}

		// Token: 0x060064CA RID: 25802 RVA: 0x0012C2C3 File Offset: 0x0012A6C3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064CB RID: 25803 RVA: 0x0012C2CB File Offset: 0x0012A6CB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064CC RID: 25804 RVA: 0x0012C2D4 File Offset: 0x0012A6D4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.info.Length);
			for (int i = 0; i < this.info.Length; i++)
			{
				this.info[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060064CD RID: 25805 RVA: 0x0012C31C File Offset: 0x0012A71C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.info = new GuildBattleEndInfo[(int)num];
			for (int i = 0; i < this.info.Length; i++)
			{
				this.info[i] = new GuildBattleEndInfo();
				this.info[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060064CE RID: 25806 RVA: 0x0012C378 File Offset: 0x0012A778
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.info.Length);
			for (int i = 0; i < this.info.Length; i++)
			{
				this.info[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060064CF RID: 25807 RVA: 0x0012C3C0 File Offset: 0x0012A7C0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.info = new GuildBattleEndInfo[(int)num];
			for (int i = 0; i < this.info.Length; i++)
			{
				this.info[i] = new GuildBattleEndInfo();
				this.info[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060064D0 RID: 25808 RVA: 0x0012C41C File Offset: 0x0012A81C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.info.Length; i++)
			{
				num += this.info[i].getLen();
			}
			return num;
		}

		// Token: 0x04002D25 RID: 11557
		public const uint MsgID = 601954U;

		// Token: 0x04002D26 RID: 11558
		public uint Sequence;

		// Token: 0x04002D27 RID: 11559
		public GuildBattleEndInfo[] info = new GuildBattleEndInfo[0];
	}
}
