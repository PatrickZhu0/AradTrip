using System;

namespace Protocol
{
	// Token: 0x0200085A RID: 2138
	[Protocol]
	public class WorldGuildBattleRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600649C RID: 25756 RVA: 0x0012BE2C File Offset: 0x0012A22C
		public uint GetMsgID()
		{
			return 601949U;
		}

		// Token: 0x0600649D RID: 25757 RVA: 0x0012BE33 File Offset: 0x0012A233
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600649E RID: 25758 RVA: 0x0012BE3B File Offset: 0x0012A23B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600649F RID: 25759 RVA: 0x0012BE44 File Offset: 0x0012A244
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060064A0 RID: 25760 RVA: 0x0012BE98 File Offset: 0x0012A298
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new GuildBattleRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new GuildBattleRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060064A1 RID: 25761 RVA: 0x0012BF00 File Offset: 0x0012A300
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060064A2 RID: 25762 RVA: 0x0012BF54 File Offset: 0x0012A354
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new GuildBattleRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new GuildBattleRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060064A3 RID: 25763 RVA: 0x0012BFBC File Offset: 0x0012A3BC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.records.Length; i++)
			{
				num += this.records[i].getLen();
			}
			return num;
		}

		// Token: 0x04002D12 RID: 11538
		public const uint MsgID = 601949U;

		// Token: 0x04002D13 RID: 11539
		public uint Sequence;

		// Token: 0x04002D14 RID: 11540
		public uint result;

		// Token: 0x04002D15 RID: 11541
		public GuildBattleRecord[] records = new GuildBattleRecord[0];
	}
}
