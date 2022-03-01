using System;

namespace Protocol
{
	// Token: 0x02000BCF RID: 3023
	[Protocol]
	public class TeamCopyFieldNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007EEB RID: 32491 RVA: 0x0016869D File Offset: 0x00166A9D
		public uint GetMsgID()
		{
			return 1100020U;
		}

		// Token: 0x06007EEC RID: 32492 RVA: 0x001686A4 File Offset: 0x00166AA4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007EED RID: 32493 RVA: 0x001686AC File Offset: 0x00166AAC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007EEE RID: 32494 RVA: 0x001686B8 File Offset: 0x00166AB8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.feildList.Length);
			for (int i = 0; i < this.feildList.Length; i++)
			{
				this.feildList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EEF RID: 32495 RVA: 0x00168700 File Offset: 0x00166B00
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.feildList = new TeamCopyFeild[(int)num];
			for (int i = 0; i < this.feildList.Length; i++)
			{
				this.feildList[i] = new TeamCopyFeild();
				this.feildList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EF0 RID: 32496 RVA: 0x0016875C File Offset: 0x00166B5C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.feildList.Length);
			for (int i = 0; i < this.feildList.Length; i++)
			{
				this.feildList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EF1 RID: 32497 RVA: 0x001687A4 File Offset: 0x00166BA4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.feildList = new TeamCopyFeild[(int)num];
			for (int i = 0; i < this.feildList.Length; i++)
			{
				this.feildList[i] = new TeamCopyFeild();
				this.feildList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007EF2 RID: 32498 RVA: 0x00168800 File Offset: 0x00166C00
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.feildList.Length; i++)
			{
				num += this.feildList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003C9C RID: 15516
		public const uint MsgID = 1100020U;

		// Token: 0x04003C9D RID: 15517
		public uint Sequence;

		// Token: 0x04003C9E RID: 15518
		public TeamCopyFeild[] feildList = new TeamCopyFeild[0];
	}
}
