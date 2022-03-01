using System;

namespace Protocol
{
	// Token: 0x02000BF0 RID: 3056
	[Protocol]
	public class TeamCopyInviteListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600800B RID: 32779 RVA: 0x0016AAF8 File Offset: 0x00168EF8
		public uint GetMsgID()
		{
			return 1100053U;
		}

		// Token: 0x0600800C RID: 32780 RVA: 0x0016AAFF File Offset: 0x00168EFF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600800D RID: 32781 RVA: 0x0016AB07 File Offset: 0x00168F07
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600800E RID: 32782 RVA: 0x0016AB10 File Offset: 0x00168F10
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inviteList.Length);
			for (int i = 0; i < this.inviteList.Length; i++)
			{
				this.inviteList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600800F RID: 32783 RVA: 0x0016AB58 File Offset: 0x00168F58
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.inviteList = new TCInviteInfo[(int)num];
			for (int i = 0; i < this.inviteList.Length; i++)
			{
				this.inviteList[i] = new TCInviteInfo();
				this.inviteList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06008010 RID: 32784 RVA: 0x0016ABB4 File Offset: 0x00168FB4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.inviteList.Length);
			for (int i = 0; i < this.inviteList.Length; i++)
			{
				this.inviteList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008011 RID: 32785 RVA: 0x0016ABFC File Offset: 0x00168FFC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.inviteList = new TCInviteInfo[(int)num];
			for (int i = 0; i < this.inviteList.Length; i++)
			{
				this.inviteList[i] = new TCInviteInfo();
				this.inviteList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06008012 RID: 32786 RVA: 0x0016AC58 File Offset: 0x00169058
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.inviteList.Length; i++)
			{
				num += this.inviteList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003D1D RID: 15645
		public const uint MsgID = 1100053U;

		// Token: 0x04003D1E RID: 15646
		public uint Sequence;

		// Token: 0x04003D1F RID: 15647
		public TCInviteInfo[] inviteList = new TCInviteInfo[0];
	}
}
