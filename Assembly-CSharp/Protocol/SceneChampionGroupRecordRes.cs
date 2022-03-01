using System;

namespace Protocol
{
	// Token: 0x02000760 RID: 1888
	[Protocol]
	public class SceneChampionGroupRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D82 RID: 23938 RVA: 0x00118CF8 File Offset: 0x001170F8
		public uint GetMsgID()
		{
			return 509826U;
		}

		// Token: 0x06005D83 RID: 23939 RVA: 0x00118CFF File Offset: 0x001170FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D84 RID: 23940 RVA: 0x00118D07 File Offset: 0x00117107
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D85 RID: 23941 RVA: 0x00118D10 File Offset: 0x00117110
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.groupID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005D86 RID: 23942 RVA: 0x00118D64 File Offset: 0x00117164
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.groupID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new ChampionBattleRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new ChampionBattleRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005D87 RID: 23943 RVA: 0x00118DCC File Offset: 0x001171CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.groupID);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005D88 RID: 23944 RVA: 0x00118E20 File Offset: 0x00117220
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.groupID);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new ChampionBattleRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new ChampionBattleRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005D89 RID: 23945 RVA: 0x00118E88 File Offset: 0x00117288
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

		// Token: 0x04002655 RID: 9813
		public const uint MsgID = 509826U;

		// Token: 0x04002656 RID: 9814
		public uint Sequence;

		// Token: 0x04002657 RID: 9815
		public uint groupID;

		// Token: 0x04002658 RID: 9816
		public ChampionBattleRecord[] records = new ChampionBattleRecord[0];
	}
}
