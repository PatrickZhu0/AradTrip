using System;

namespace Protocol
{
	// Token: 0x020007A1 RID: 1953
	[Protocol]
	public class WorldDigMapInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F7D RID: 24445 RVA: 0x0011DCA8 File Offset: 0x0011C0A8
		public uint GetMsgID()
		{
			return 608214U;
		}

		// Token: 0x06005F7E RID: 24446 RVA: 0x0011DCAF File Offset: 0x0011C0AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F7F RID: 24447 RVA: 0x0011DCB7 File Offset: 0x0011C0B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F80 RID: 24448 RVA: 0x0011DCC0 File Offset: 0x0011C0C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.digMapInfos.Length);
			for (int i = 0; i < this.digMapInfos.Length; i++)
			{
				this.digMapInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F81 RID: 24449 RVA: 0x0011DD14 File Offset: 0x0011C114
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.digMapInfos = new DigMapInfo[(int)num];
			for (int i = 0; i < this.digMapInfos.Length; i++)
			{
				this.digMapInfos[i] = new DigMapInfo();
				this.digMapInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F82 RID: 24450 RVA: 0x0011DD7C File Offset: 0x0011C17C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.digMapInfos.Length);
			for (int i = 0; i < this.digMapInfos.Length; i++)
			{
				this.digMapInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F83 RID: 24451 RVA: 0x0011DDD0 File Offset: 0x0011C1D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.digMapInfos = new DigMapInfo[(int)num];
			for (int i = 0; i < this.digMapInfos.Length; i++)
			{
				this.digMapInfos[i] = new DigMapInfo();
				this.digMapInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005F84 RID: 24452 RVA: 0x0011DE38 File Offset: 0x0011C238
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.digMapInfos.Length; i++)
			{
				num += this.digMapInfos[i].getLen();
			}
			return num;
		}

		// Token: 0x0400276A RID: 10090
		public const uint MsgID = 608214U;

		// Token: 0x0400276B RID: 10091
		public uint Sequence;

		// Token: 0x0400276C RID: 10092
		public uint result;

		// Token: 0x0400276D RID: 10093
		public DigMapInfo[] digMapInfos = new DigMapInfo[0];
	}
}
