using System;

namespace Protocol
{
	// Token: 0x02000889 RID: 2185
	[Protocol]
	public class WorldGuildDungeonCopyRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006634 RID: 26164 RVA: 0x0012F2B5 File Offset: 0x0012D6B5
		public uint GetMsgID()
		{
			return 608506U;
		}

		// Token: 0x06006635 RID: 26165 RVA: 0x0012F2BC File Offset: 0x0012D6BC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006636 RID: 26166 RVA: 0x0012F2C4 File Offset: 0x0012D6C4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006637 RID: 26167 RVA: 0x0012F2D0 File Offset: 0x0012D6D0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battleRecord.Length);
			for (int i = 0; i < this.battleRecord.Length; i++)
			{
				this.battleRecord[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006638 RID: 26168 RVA: 0x0012F318 File Offset: 0x0012D718
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battleRecord = new GuildDungeonBattleRecord[(int)num];
			for (int i = 0; i < this.battleRecord.Length; i++)
			{
				this.battleRecord[i] = new GuildDungeonBattleRecord();
				this.battleRecord[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006639 RID: 26169 RVA: 0x0012F374 File Offset: 0x0012D774
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.battleRecord.Length);
			for (int i = 0; i < this.battleRecord.Length; i++)
			{
				this.battleRecord[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600663A RID: 26170 RVA: 0x0012F3BC File Offset: 0x0012D7BC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.battleRecord = new GuildDungeonBattleRecord[(int)num];
			for (int i = 0; i < this.battleRecord.Length; i++)
			{
				this.battleRecord[i] = new GuildDungeonBattleRecord();
				this.battleRecord[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600663B RID: 26171 RVA: 0x0012F418 File Offset: 0x0012D818
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.battleRecord.Length; i++)
			{
				num += this.battleRecord[i].getLen();
			}
			return num;
		}

		// Token: 0x04002DBC RID: 11708
		public const uint MsgID = 608506U;

		// Token: 0x04002DBD RID: 11709
		public uint Sequence;

		// Token: 0x04002DBE RID: 11710
		public GuildDungeonBattleRecord[] battleRecord = new GuildDungeonBattleRecord[0];
	}
}
