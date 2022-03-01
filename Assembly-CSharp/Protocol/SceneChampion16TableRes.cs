using System;

namespace Protocol
{
	// Token: 0x0200074F RID: 1871
	[Protocol]
	public class SceneChampion16TableRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CF2 RID: 23794 RVA: 0x00117CA4 File Offset: 0x001160A4
		public uint GetMsgID()
		{
			return 509809U;
		}

		// Token: 0x06005CF3 RID: 23795 RVA: 0x00117CAB File Offset: 0x001160AB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CF4 RID: 23796 RVA: 0x00117CB3 File Offset: 0x001160B3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CF5 RID: 23797 RVA: 0x00117CBC File Offset: 0x001160BC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerVec.Length);
			for (int i = 0; i < this.playerVec.Length; i++)
			{
				this.playerVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005CF6 RID: 23798 RVA: 0x00117D04 File Offset: 0x00116104
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerVec = new ChampionTop16Player[(int)num];
			for (int i = 0; i < this.playerVec.Length; i++)
			{
				this.playerVec[i] = new ChampionTop16Player();
				this.playerVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005CF7 RID: 23799 RVA: 0x00117D60 File Offset: 0x00116160
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.playerVec.Length);
			for (int i = 0; i < this.playerVec.Length; i++)
			{
				this.playerVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005CF8 RID: 23800 RVA: 0x00117DA8 File Offset: 0x001161A8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.playerVec = new ChampionTop16Player[(int)num];
			for (int i = 0; i < this.playerVec.Length; i++)
			{
				this.playerVec[i] = new ChampionTop16Player();
				this.playerVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005CF9 RID: 23801 RVA: 0x00117E04 File Offset: 0x00116204
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.playerVec.Length; i++)
			{
				num += this.playerVec[i].getLen();
			}
			return num;
		}

		// Token: 0x04002615 RID: 9749
		public const uint MsgID = 509809U;

		// Token: 0x04002616 RID: 9750
		public uint Sequence;

		// Token: 0x04002617 RID: 9751
		public ChampionTop16Player[] playerVec = new ChampionTop16Player[0];
	}
}
