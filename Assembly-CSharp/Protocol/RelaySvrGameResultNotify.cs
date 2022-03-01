using System;

namespace Protocol
{
	// Token: 0x02000A96 RID: 2710
	[Protocol]
	public class RelaySvrGameResultNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007633 RID: 30259 RVA: 0x00155B0C File Offset: 0x00153F0C
		public uint GetMsgID()
		{
			return 1300006U;
		}

		// Token: 0x06007634 RID: 30260 RVA: 0x00155B13 File Offset: 0x00153F13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007635 RID: 30261 RVA: 0x00155B1B File Offset: 0x00153F1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007636 RID: 30262 RVA: 0x00155B24 File Offset: 0x00153F24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.results.Length);
			for (int i = 0; i < this.results.Length; i++)
			{
				this.results[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007637 RID: 30263 RVA: 0x00155B88 File Offset: 0x00153F88
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.results = new FightergResult[(int)num];
			for (int i = 0; i < this.results.Length; i++)
			{
				this.results[i] = new FightergResult();
				this.results[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007638 RID: 30264 RVA: 0x00155C00 File Offset: 0x00154000
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.reason);
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.results.Length);
			for (int i = 0; i < this.results.Length; i++)
			{
				this.results[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007639 RID: 30265 RVA: 0x00155C64 File Offset: 0x00154064
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.reason);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.results = new FightergResult[(int)num];
			for (int i = 0; i < this.results.Length; i++)
			{
				this.results[i] = new FightergResult();
				this.results[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600763A RID: 30266 RVA: 0x00155CDC File Offset: 0x001540DC
		public int getLen()
		{
			int num = 0;
			num++;
			num += 8;
			num += 2;
			for (int i = 0; i < this.results.Length; i++)
			{
				num += this.results[i].getLen();
			}
			return num;
		}

		// Token: 0x04003732 RID: 14130
		public const uint MsgID = 1300006U;

		// Token: 0x04003733 RID: 14131
		public uint Sequence;

		// Token: 0x04003734 RID: 14132
		public byte reason;

		// Token: 0x04003735 RID: 14133
		public ulong session;

		// Token: 0x04003736 RID: 14134
		public FightergResult[] results = new FightergResult[0];
	}
}
