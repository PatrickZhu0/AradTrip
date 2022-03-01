using System;

namespace Protocol
{
	// Token: 0x02000672 RID: 1650
	[Protocol]
	public class SceneSyncClientActivities : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600562D RID: 22061 RVA: 0x0010878C File Offset: 0x00106B8C
		public uint GetMsgID()
		{
			return 501136U;
		}

		// Token: 0x0600562E RID: 22062 RVA: 0x00108793 File Offset: 0x00106B93
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600562F RID: 22063 RVA: 0x0010879B File Offset: 0x00106B9B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005630 RID: 22064 RVA: 0x001087A4 File Offset: 0x00106BA4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.activities.Length);
			for (int i = 0; i < this.activities.Length; i++)
			{
				this.activities[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005631 RID: 22065 RVA: 0x001087EC File Offset: 0x00106BEC
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.activities = new ActivityInfo[(int)num];
			for (int i = 0; i < this.activities.Length; i++)
			{
				this.activities[i] = new ActivityInfo();
				this.activities[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005632 RID: 22066 RVA: 0x00108848 File Offset: 0x00106C48
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.activities.Length);
			for (int i = 0; i < this.activities.Length; i++)
			{
				this.activities[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005633 RID: 22067 RVA: 0x00108890 File Offset: 0x00106C90
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.activities = new ActivityInfo[(int)num];
			for (int i = 0; i < this.activities.Length; i++)
			{
				this.activities[i] = new ActivityInfo();
				this.activities[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005634 RID: 22068 RVA: 0x001088EC File Offset: 0x00106CEC
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.activities.Length; i++)
			{
				num += this.activities[i].getLen();
			}
			return num;
		}

		// Token: 0x0400223A RID: 8762
		public const uint MsgID = 501136U;

		// Token: 0x0400223B RID: 8763
		public uint Sequence;

		// Token: 0x0400223C RID: 8764
		public ActivityInfo[] activities = new ActivityInfo[0];
	}
}
