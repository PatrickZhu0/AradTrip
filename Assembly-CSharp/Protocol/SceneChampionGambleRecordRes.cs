using System;

namespace Protocol
{
	// Token: 0x02000775 RID: 1909
	[Protocol]
	public class SceneChampionGambleRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E2D RID: 24109 RVA: 0x0011A7A4 File Offset: 0x00118BA4
		public uint GetMsgID()
		{
			return 509837U;
		}

		// Token: 0x06005E2E RID: 24110 RVA: 0x0011A7AB File Offset: 0x00118BAB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E2F RID: 24111 RVA: 0x0011A7B3 File Offset: 0x00118BB3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E30 RID: 24112 RVA: 0x0011A7BC File Offset: 0x00118BBC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005E31 RID: 24113 RVA: 0x0011A804 File Offset: 0x00118C04
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new GambleRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new GambleRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005E32 RID: 24114 RVA: 0x0011A860 File Offset: 0x00118C60
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005E33 RID: 24115 RVA: 0x0011A8A8 File Offset: 0x00118CA8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new GambleRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new GambleRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005E34 RID: 24116 RVA: 0x0011A904 File Offset: 0x00118D04
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.records.Length; i++)
			{
				num += this.records[i].getLen();
			}
			return num;
		}

		// Token: 0x040026A0 RID: 9888
		public const uint MsgID = 509837U;

		// Token: 0x040026A1 RID: 9889
		public uint Sequence;

		// Token: 0x040026A2 RID: 9890
		public GambleRecord[] records = new GambleRecord[0];
	}
}
