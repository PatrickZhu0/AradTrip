using System;

namespace Protocol
{
	// Token: 0x0200076A RID: 1898
	[Protocol]
	public class UnionChampionKnockoutScore : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005DD6 RID: 24022 RVA: 0x00119A44 File Offset: 0x00117E44
		public uint GetMsgID()
		{
			return 1209813U;
		}

		// Token: 0x06005DD7 RID: 24023 RVA: 0x00119A4B File Offset: 0x00117E4B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005DD8 RID: 24024 RVA: 0x00119A53 File Offset: 0x00117E53
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005DD9 RID: 24025 RVA: 0x00119A5C File Offset: 0x00117E5C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.roles.Length);
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DDA RID: 24026 RVA: 0x00119AA4 File Offset: 0x00117EA4
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.roles = new KnockoutPlayer[(int)num];
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i] = new KnockoutPlayer();
				this.roles[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DDB RID: 24027 RVA: 0x00119B00 File Offset: 0x00117F00
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.roles.Length);
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DDC RID: 24028 RVA: 0x00119B48 File Offset: 0x00117F48
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.roles = new KnockoutPlayer[(int)num];
			for (int i = 0; i < this.roles.Length; i++)
			{
				this.roles[i] = new KnockoutPlayer();
				this.roles[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005DDD RID: 24029 RVA: 0x00119BA4 File Offset: 0x00117FA4
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.roles.Length; i++)
			{
				num += this.roles[i].getLen();
			}
			return num;
		}

		// Token: 0x04002679 RID: 9849
		public const uint MsgID = 1209813U;

		// Token: 0x0400267A RID: 9850
		public uint Sequence;

		// Token: 0x0400267B RID: 9851
		public KnockoutPlayer[] roles = new KnockoutPlayer[0];
	}
}
