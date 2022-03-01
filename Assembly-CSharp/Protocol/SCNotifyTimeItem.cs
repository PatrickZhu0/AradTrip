using System;

namespace Protocol
{
	// Token: 0x02000933 RID: 2355
	[Protocol]
	public class SCNotifyTimeItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006B32 RID: 27442 RVA: 0x00139C34 File Offset: 0x00138034
		public uint GetMsgID()
		{
			return 500968U;
		}

		// Token: 0x06006B33 RID: 27443 RVA: 0x00139C3B File Offset: 0x0013803B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006B34 RID: 27444 RVA: 0x00139C43 File Offset: 0x00138043
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006B35 RID: 27445 RVA: 0x00139C4C File Offset: 0x0013804C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B36 RID: 27446 RVA: 0x00139C94 File Offset: 0x00138094
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new TimeItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new TimeItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B37 RID: 27447 RVA: 0x00139CF0 File Offset: 0x001380F0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.items.Length);
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B38 RID: 27448 RVA: 0x00139D38 File Offset: 0x00138138
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.items = new TimeItem[(int)num];
			for (int i = 0; i < this.items.Length; i++)
			{
				this.items[i] = new TimeItem();
				this.items[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006B39 RID: 27449 RVA: 0x00139D94 File Offset: 0x00138194
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.items.Length; i++)
			{
				num += this.items[i].getLen();
			}
			return num;
		}

		// Token: 0x04003098 RID: 12440
		public const uint MsgID = 500968U;

		// Token: 0x04003099 RID: 12441
		public uint Sequence;

		// Token: 0x0400309A RID: 12442
		public TimeItem[] items = new TimeItem[0];
	}
}
