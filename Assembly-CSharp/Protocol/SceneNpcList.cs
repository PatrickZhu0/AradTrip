using System;

namespace Protocol
{
	// Token: 0x02000B0C RID: 2828
	[Protocol]
	public class SceneNpcList : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007984 RID: 31108 RVA: 0x0015DA30 File Offset: 0x0015BE30
		public uint GetMsgID()
		{
			return 500621U;
		}

		// Token: 0x06007985 RID: 31109 RVA: 0x0015DA37 File Offset: 0x0015BE37
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007986 RID: 31110 RVA: 0x0015DA3F File Offset: 0x0015BE3F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007987 RID: 31111 RVA: 0x0015DA48 File Offset: 0x0015BE48
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007988 RID: 31112 RVA: 0x0015DA90 File Offset: 0x0015BE90
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new SceneNpcInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new SceneNpcInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007989 RID: 31113 RVA: 0x0015DAEC File Offset: 0x0015BEEC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600798A RID: 31114 RVA: 0x0015DB34 File Offset: 0x0015BF34
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new SceneNpcInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new SceneNpcInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600798B RID: 31115 RVA: 0x0015DB90 File Offset: 0x0015BF90
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.infoes.Length; i++)
			{
				num += this.infoes[i].getLen();
			}
			return num;
		}

		// Token: 0x04003957 RID: 14679
		public const uint MsgID = 500621U;

		// Token: 0x04003958 RID: 14680
		public uint Sequence;

		// Token: 0x04003959 RID: 14681
		public SceneNpcInfo[] infoes = new SceneNpcInfo[0];
	}
}
