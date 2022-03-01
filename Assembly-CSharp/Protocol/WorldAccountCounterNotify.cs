using System;

namespace Protocol
{
	// Token: 0x02000AC3 RID: 2755
	[Protocol]
	public class WorldAccountCounterNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007774 RID: 30580 RVA: 0x00159094 File Offset: 0x00157494
		public uint GetMsgID()
		{
			return 600606U;
		}

		// Token: 0x06007775 RID: 30581 RVA: 0x0015909B File Offset: 0x0015749B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007776 RID: 30582 RVA: 0x001590A3 File Offset: 0x001574A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007777 RID: 30583 RVA: 0x001590AC File Offset: 0x001574AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.accCounterList.Length);
			for (int i = 0; i < this.accCounterList.Length; i++)
			{
				this.accCounterList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007778 RID: 30584 RVA: 0x001590F4 File Offset: 0x001574F4
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.accCounterList = new AccountCounter[(int)num];
			for (int i = 0; i < this.accCounterList.Length; i++)
			{
				this.accCounterList[i] = new AccountCounter();
				this.accCounterList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007779 RID: 30585 RVA: 0x00159150 File Offset: 0x00157550
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.accCounterList.Length);
			for (int i = 0; i < this.accCounterList.Length; i++)
			{
				this.accCounterList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600777A RID: 30586 RVA: 0x00159198 File Offset: 0x00157598
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.accCounterList = new AccountCounter[(int)num];
			for (int i = 0; i < this.accCounterList.Length; i++)
			{
				this.accCounterList[i] = new AccountCounter();
				this.accCounterList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600777B RID: 30587 RVA: 0x001591F4 File Offset: 0x001575F4
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.accCounterList.Length; i++)
			{
				num += this.accCounterList[i].getLen();
			}
			return num;
		}

		// Token: 0x040037F9 RID: 14329
		public const uint MsgID = 600606U;

		// Token: 0x040037FA RID: 14330
		public uint Sequence;

		// Token: 0x040037FB RID: 14331
		public AccountCounter[] accCounterList = new AccountCounter[0];
	}
}
