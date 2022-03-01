using System;

namespace Protocol
{
	// Token: 0x02000947 RID: 2375
	[Protocol]
	public class WorldEquipRecoOpenJarsRecordRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006BE3 RID: 27619 RVA: 0x0013ACA8 File Offset: 0x001390A8
		public uint GetMsgID()
		{
			return 600905U;
		}

		// Token: 0x06006BE4 RID: 27620 RVA: 0x0013ACAF File Offset: 0x001390AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006BE5 RID: 27621 RVA: 0x0013ACB7 File Offset: 0x001390B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006BE6 RID: 27622 RVA: 0x0013ACC0 File Offset: 0x001390C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006BE7 RID: 27623 RVA: 0x0013AD08 File Offset: 0x00139108
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new OpenJarRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new OpenJarRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006BE8 RID: 27624 RVA: 0x0013AD64 File Offset: 0x00139164
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.records.Length);
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006BE9 RID: 27625 RVA: 0x0013ADAC File Offset: 0x001391AC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.records = new OpenJarRecord[(int)num];
			for (int i = 0; i < this.records.Length; i++)
			{
				this.records[i] = new OpenJarRecord();
				this.records[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006BEA RID: 27626 RVA: 0x0013AE08 File Offset: 0x00139208
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

		// Token: 0x040030D9 RID: 12505
		public const uint MsgID = 600905U;

		// Token: 0x040030DA RID: 12506
		public uint Sequence;

		// Token: 0x040030DB RID: 12507
		public OpenJarRecord[] records = new OpenJarRecord[0];
	}
}
