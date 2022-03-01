using System;

namespace Protocol
{
	// Token: 0x02000B92 RID: 2962
	[Protocol]
	public class WorldTeamRequesterListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D7D RID: 32125 RVA: 0x001652B0 File Offset: 0x001636B0
		public uint GetMsgID()
		{
			return 601639U;
		}

		// Token: 0x06007D7E RID: 32126 RVA: 0x001652B7 File Offset: 0x001636B7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D7F RID: 32127 RVA: 0x001652BF File Offset: 0x001636BF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D80 RID: 32128 RVA: 0x001652C8 File Offset: 0x001636C8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.requesters.Length);
			for (int i = 0; i < this.requesters.Length; i++)
			{
				this.requesters[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007D81 RID: 32129 RVA: 0x00165310 File Offset: 0x00163710
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.requesters = new TeammemberBaseInfo[(int)num];
			for (int i = 0; i < this.requesters.Length; i++)
			{
				this.requesters[i] = new TeammemberBaseInfo();
				this.requesters[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007D82 RID: 32130 RVA: 0x0016536C File Offset: 0x0016376C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.requesters.Length);
			for (int i = 0; i < this.requesters.Length; i++)
			{
				this.requesters[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007D83 RID: 32131 RVA: 0x001653B4 File Offset: 0x001637B4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.requesters = new TeammemberBaseInfo[(int)num];
			for (int i = 0; i < this.requesters.Length; i++)
			{
				this.requesters[i] = new TeammemberBaseInfo();
				this.requesters[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007D84 RID: 32132 RVA: 0x00165410 File Offset: 0x00163810
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.requesters.Length; i++)
			{
				num += this.requesters[i].getLen();
			}
			return num;
		}

		// Token: 0x04003B81 RID: 15233
		public const uint MsgID = 601639U;

		// Token: 0x04003B82 RID: 15234
		public uint Sequence;

		// Token: 0x04003B83 RID: 15235
		public TeammemberBaseInfo[] requesters = new TeammemberBaseInfo[0];
	}
}
