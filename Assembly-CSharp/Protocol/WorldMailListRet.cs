using System;

namespace Protocol
{
	// Token: 0x020009E0 RID: 2528
	[Protocol]
	public class WorldMailListRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x060070F9 RID: 28921 RVA: 0x001465F0 File Offset: 0x001449F0
		public uint GetMsgID()
		{
			return 601503U;
		}

		// Token: 0x060070FA RID: 28922 RVA: 0x001465F7 File Offset: 0x001449F7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060070FB RID: 28923 RVA: 0x001465FF File Offset: 0x001449FF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060070FC RID: 28924 RVA: 0x00146608 File Offset: 0x00144A08
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mails.Length);
			for (int i = 0; i < this.mails.Length; i++)
			{
				this.mails[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060070FD RID: 28925 RVA: 0x00146650 File Offset: 0x00144A50
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mails = new MailTitleInfo[(int)num];
			for (int i = 0; i < this.mails.Length; i++)
			{
				this.mails[i] = new MailTitleInfo();
				this.mails[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060070FE RID: 28926 RVA: 0x001466AC File Offset: 0x00144AAC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mails.Length);
			for (int i = 0; i < this.mails.Length; i++)
			{
				this.mails[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060070FF RID: 28927 RVA: 0x001466F4 File Offset: 0x00144AF4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mails = new MailTitleInfo[(int)num];
			for (int i = 0; i < this.mails.Length; i++)
			{
				this.mails[i] = new MailTitleInfo();
				this.mails[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007100 RID: 28928 RVA: 0x00146750 File Offset: 0x00144B50
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.mails.Length; i++)
			{
				num += this.mails[i].getLen();
			}
			return num;
		}

		// Token: 0x0400337C RID: 13180
		public const uint MsgID = 601503U;

		// Token: 0x0400337D RID: 13181
		public uint Sequence;

		// Token: 0x0400337E RID: 13182
		public MailTitleInfo[] mails = new MailTitleInfo[0];
	}
}
