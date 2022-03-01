using System;

namespace Protocol
{
	// Token: 0x02000BDF RID: 3039
	[Protocol]
	public class TeamCopyStageFlopRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F75 RID: 32629 RVA: 0x00169A10 File Offset: 0x00167E10
		public uint GetMsgID()
		{
			return 1100036U;
		}

		// Token: 0x06007F76 RID: 32630 RVA: 0x00169A17 File Offset: 0x00167E17
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F77 RID: 32631 RVA: 0x00169A1F File Offset: 0x00167E1F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F78 RID: 32632 RVA: 0x00169A28 File Offset: 0x00167E28
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.stageId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.flopList.Length);
			for (int i = 0; i < this.flopList.Length; i++)
			{
				this.flopList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F79 RID: 32633 RVA: 0x00169A7C File Offset: 0x00167E7C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stageId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.flopList = new TeamCopyFlop[(int)num];
			for (int i = 0; i < this.flopList.Length; i++)
			{
				this.flopList[i] = new TeamCopyFlop();
				this.flopList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F7A RID: 32634 RVA: 0x00169AE4 File Offset: 0x00167EE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.stageId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.flopList.Length);
			for (int i = 0; i < this.flopList.Length; i++)
			{
				this.flopList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F7B RID: 32635 RVA: 0x00169B38 File Offset: 0x00167F38
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stageId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.flopList = new TeamCopyFlop[(int)num];
			for (int i = 0; i < this.flopList.Length; i++)
			{
				this.flopList[i] = new TeamCopyFlop();
				this.flopList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F7C RID: 32636 RVA: 0x00169BA0 File Offset: 0x00167FA0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.flopList.Length; i++)
			{
				num += this.flopList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003CD8 RID: 15576
		public const uint MsgID = 1100036U;

		// Token: 0x04003CD9 RID: 15577
		public uint Sequence;

		// Token: 0x04003CDA RID: 15578
		public uint stageId;

		// Token: 0x04003CDB RID: 15579
		public TeamCopyFlop[] flopList = new TeamCopyFlop[0];
	}
}
