using System;

namespace Protocol
{
	// Token: 0x02000885 RID: 2181
	[Protocol]
	public class WorldGuildDungeonDamageRankRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006616 RID: 26134 RVA: 0x0012EDEC File Offset: 0x0012D1EC
		public uint GetMsgID()
		{
			return 608504U;
		}

		// Token: 0x06006617 RID: 26135 RVA: 0x0012EDF3 File Offset: 0x0012D1F3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006618 RID: 26136 RVA: 0x0012EDFB File Offset: 0x0012D1FB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006619 RID: 26137 RVA: 0x0012EE04 File Offset: 0x0012D204
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.damageVec.Length);
			for (int i = 0; i < this.damageVec.Length; i++)
			{
				this.damageVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600661A RID: 26138 RVA: 0x0012EE4C File Offset: 0x0012D24C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.damageVec = new GuildDungeonDamage[(int)num];
			for (int i = 0; i < this.damageVec.Length; i++)
			{
				this.damageVec[i] = new GuildDungeonDamage();
				this.damageVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600661B RID: 26139 RVA: 0x0012EEA8 File Offset: 0x0012D2A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.damageVec.Length);
			for (int i = 0; i < this.damageVec.Length; i++)
			{
				this.damageVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600661C RID: 26140 RVA: 0x0012EEF0 File Offset: 0x0012D2F0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.damageVec = new GuildDungeonDamage[(int)num];
			for (int i = 0; i < this.damageVec.Length; i++)
			{
				this.damageVec[i] = new GuildDungeonDamage();
				this.damageVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600661D RID: 26141 RVA: 0x0012EF4C File Offset: 0x0012D34C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.damageVec.Length; i++)
			{
				num += this.damageVec[i].getLen();
			}
			return num;
		}

		// Token: 0x04002DB1 RID: 11697
		public const uint MsgID = 608504U;

		// Token: 0x04002DB2 RID: 11698
		public uint Sequence;

		// Token: 0x04002DB3 RID: 11699
		public GuildDungeonDamage[] damageVec = new GuildDungeonDamage[0];
	}
}
