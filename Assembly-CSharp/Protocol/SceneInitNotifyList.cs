using System;

namespace Protocol
{
	// Token: 0x02000683 RID: 1667
	[Protocol]
	public class SceneInitNotifyList : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056C3 RID: 22211 RVA: 0x00109728 File Offset: 0x00107B28
		public uint GetMsgID()
		{
			return 501153U;
		}

		// Token: 0x060056C4 RID: 22212 RVA: 0x0010972F File Offset: 0x00107B2F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056C5 RID: 22213 RVA: 0x00109737 File Offset: 0x00107B37
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056C6 RID: 22214 RVA: 0x00109740 File Offset: 0x00107B40
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.notifys.Length);
			for (int i = 0; i < this.notifys.Length; i++)
			{
				this.notifys[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060056C7 RID: 22215 RVA: 0x00109788 File Offset: 0x00107B88
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.notifys = new NotifyInfo[(int)num];
			for (int i = 0; i < this.notifys.Length; i++)
			{
				this.notifys[i] = new NotifyInfo();
				this.notifys[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060056C8 RID: 22216 RVA: 0x001097E4 File Offset: 0x00107BE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.notifys.Length);
			for (int i = 0; i < this.notifys.Length; i++)
			{
				this.notifys[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060056C9 RID: 22217 RVA: 0x0010982C File Offset: 0x00107C2C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.notifys = new NotifyInfo[(int)num];
			for (int i = 0; i < this.notifys.Length; i++)
			{
				this.notifys[i] = new NotifyInfo();
				this.notifys[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060056CA RID: 22218 RVA: 0x00109888 File Offset: 0x00107C88
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.notifys.Length; i++)
			{
				num += this.notifys[i].getLen();
			}
			return num;
		}

		// Token: 0x04002277 RID: 8823
		public const uint MsgID = 501153U;

		// Token: 0x04002278 RID: 8824
		public uint Sequence;

		// Token: 0x04002279 RID: 8825
		public NotifyInfo[] notifys = new NotifyInfo[0];
	}
}
