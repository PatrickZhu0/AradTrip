using System;

namespace Protocol
{
	// Token: 0x02000A42 RID: 2626
	[Protocol]
	public class SceneWeekSignBoxNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x060073B4 RID: 29620 RVA: 0x0014FC05 File Offset: 0x0014E005
		public uint GetMsgID()
		{
			return 507407U;
		}

		// Token: 0x060073B5 RID: 29621 RVA: 0x0014FC0C File Offset: 0x0014E00C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060073B6 RID: 29622 RVA: 0x0014FC14 File Offset: 0x0014E014
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060073B7 RID: 29623 RVA: 0x0014FC20 File Offset: 0x0014E020
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.boxData.Length);
			for (int i = 0; i < this.boxData.Length; i++)
			{
				this.boxData[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060073B8 RID: 29624 RVA: 0x0014FC74 File Offset: 0x0014E074
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.boxData = new WeekSignBox[(int)num];
			for (int i = 0; i < this.boxData.Length; i++)
			{
				this.boxData[i] = new WeekSignBox();
				this.boxData[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060073B9 RID: 29625 RVA: 0x0014FCDC File Offset: 0x0014E0DC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.boxData.Length);
			for (int i = 0; i < this.boxData.Length; i++)
			{
				this.boxData[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060073BA RID: 29626 RVA: 0x0014FD30 File Offset: 0x0014E130
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.boxData = new WeekSignBox[(int)num];
			for (int i = 0; i < this.boxData.Length; i++)
			{
				this.boxData[i] = new WeekSignBox();
				this.boxData[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060073BB RID: 29627 RVA: 0x0014FD98 File Offset: 0x0014E198
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.boxData.Length; i++)
			{
				num += this.boxData[i].getLen();
			}
			return num;
		}

		// Token: 0x040035B2 RID: 13746
		public const uint MsgID = 507407U;

		// Token: 0x040035B3 RID: 13747
		public uint Sequence;

		// Token: 0x040035B4 RID: 13748
		public uint opActType;

		// Token: 0x040035B5 RID: 13749
		public WeekSignBox[] boxData = new WeekSignBox[0];
	}
}
