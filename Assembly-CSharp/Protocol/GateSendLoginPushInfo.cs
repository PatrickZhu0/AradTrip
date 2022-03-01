using System;

namespace Protocol
{
	// Token: 0x020009D1 RID: 2513
	[Protocol]
	public class GateSendLoginPushInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007081 RID: 28801 RVA: 0x001455B4 File Offset: 0x001439B4
		public uint GetMsgID()
		{
			return 300321U;
		}

		// Token: 0x06007082 RID: 28802 RVA: 0x001455BB File Offset: 0x001439BB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007083 RID: 28803 RVA: 0x001455C3 File Offset: 0x001439C3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007084 RID: 28804 RVA: 0x001455CC File Offset: 0x001439CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007085 RID: 28805 RVA: 0x00145614 File Offset: 0x00143A14
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new LoginPushInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new LoginPushInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007086 RID: 28806 RVA: 0x00145670 File Offset: 0x00143A70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infos.Length);
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007087 RID: 28807 RVA: 0x001456B8 File Offset: 0x00143AB8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infos = new LoginPushInfo[(int)num];
			for (int i = 0; i < this.infos.Length; i++)
			{
				this.infos[i] = new LoginPushInfo();
				this.infos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007088 RID: 28808 RVA: 0x00145714 File Offset: 0x00143B14
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.infos.Length; i++)
			{
				num += this.infos[i].getLen();
			}
			return num;
		}

		// Token: 0x04003340 RID: 13120
		public const uint MsgID = 300321U;

		// Token: 0x04003341 RID: 13121
		public uint Sequence;

		// Token: 0x04003342 RID: 13122
		public LoginPushInfo[] infos = new LoginPushInfo[0];
	}
}
