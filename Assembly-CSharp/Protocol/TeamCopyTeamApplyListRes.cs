using System;

namespace Protocol
{
	// Token: 0x02000BD4 RID: 3028
	[Protocol]
	public class TeamCopyTeamApplyListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F15 RID: 32533 RVA: 0x00168D10 File Offset: 0x00167110
		public uint GetMsgID()
		{
			return 1100024U;
		}

		// Token: 0x06007F16 RID: 32534 RVA: 0x00168D17 File Offset: 0x00167117
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F17 RID: 32535 RVA: 0x00168D1F File Offset: 0x0016711F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F18 RID: 32536 RVA: 0x00168D28 File Offset: 0x00167128
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.applyList.Length);
			for (int i = 0; i < this.applyList.Length; i++)
			{
				this.applyList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F19 RID: 32537 RVA: 0x00168D70 File Offset: 0x00167170
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.applyList = new TeamCopyApplyProperty[(int)num];
			for (int i = 0; i < this.applyList.Length; i++)
			{
				this.applyList[i] = new TeamCopyApplyProperty();
				this.applyList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F1A RID: 32538 RVA: 0x00168DCC File Offset: 0x001671CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.applyList.Length);
			for (int i = 0; i < this.applyList.Length; i++)
			{
				this.applyList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F1B RID: 32539 RVA: 0x00168E14 File Offset: 0x00167214
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.applyList = new TeamCopyApplyProperty[(int)num];
			for (int i = 0; i < this.applyList.Length; i++)
			{
				this.applyList[i] = new TeamCopyApplyProperty();
				this.applyList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007F1C RID: 32540 RVA: 0x00168E70 File Offset: 0x00167270
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.applyList.Length; i++)
			{
				num += this.applyList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003CB2 RID: 15538
		public const uint MsgID = 1100024U;

		// Token: 0x04003CB3 RID: 15539
		public uint Sequence;

		// Token: 0x04003CB4 RID: 15540
		public TeamCopyApplyProperty[] applyList = new TeamCopyApplyProperty[0];
	}
}
