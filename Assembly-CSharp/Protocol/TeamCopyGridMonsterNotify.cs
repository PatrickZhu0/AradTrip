using System;

namespace Protocol
{
	// Token: 0x02000C0D RID: 3085
	[Protocol]
	public class TeamCopyGridMonsterNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008107 RID: 33031 RVA: 0x0016C957 File Offset: 0x0016AD57
		public uint GetMsgID()
		{
			return 1100079U;
		}

		// Token: 0x06008108 RID: 33032 RVA: 0x0016C95E File Offset: 0x0016AD5E
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008109 RID: 33033 RVA: 0x0016C966 File Offset: 0x0016AD66
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600810A RID: 33034 RVA: 0x0016C970 File Offset: 0x0016AD70
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsterVec.Length);
			for (int i = 0; i < this.monsterVec.Length; i++)
			{
				this.monsterVec[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsterPathList.Length);
			for (int j = 0; j < this.monsterPathList.Length; j++)
			{
				this.monsterPathList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600810B RID: 33035 RVA: 0x0016C9F0 File Offset: 0x0016ADF0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsterVec = new TCGridObjData[(int)num];
			for (int i = 0; i < this.monsterVec.Length; i++)
			{
				this.monsterVec[i] = new TCGridObjData();
				this.monsterVec[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.monsterPathList = new TCMonsterPath[(int)num2];
			for (int j = 0; j < this.monsterPathList.Length; j++)
			{
				this.monsterPathList[j] = new TCMonsterPath();
				this.monsterPathList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600810C RID: 33036 RVA: 0x0016CA98 File Offset: 0x0016AE98
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsterVec.Length);
			for (int i = 0; i < this.monsterVec.Length; i++)
			{
				this.monsterVec[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.monsterPathList.Length);
			for (int j = 0; j < this.monsterPathList.Length; j++)
			{
				this.monsterPathList[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600810D RID: 33037 RVA: 0x0016CB18 File Offset: 0x0016AF18
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.monsterVec = new TCGridObjData[(int)num];
			for (int i = 0; i < this.monsterVec.Length; i++)
			{
				this.monsterVec[i] = new TCGridObjData();
				this.monsterVec[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.monsterPathList = new TCMonsterPath[(int)num2];
			for (int j = 0; j < this.monsterPathList.Length; j++)
			{
				this.monsterPathList[j] = new TCMonsterPath();
				this.monsterPathList[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600810E RID: 33038 RVA: 0x0016CBC0 File Offset: 0x0016AFC0
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.monsterVec.Length; i++)
			{
				num += this.monsterVec[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.monsterPathList.Length; j++)
			{
				num += this.monsterPathList[j].getLen();
			}
			return num;
		}

		// Token: 0x04003D8F RID: 15759
		public const uint MsgID = 1100079U;

		// Token: 0x04003D90 RID: 15760
		public uint Sequence;

		// Token: 0x04003D91 RID: 15761
		public TCGridObjData[] monsterVec = new TCGridObjData[0];

		// Token: 0x04003D92 RID: 15762
		public TCMonsterPath[] monsterPathList = new TCMonsterPath[0];
	}
}
