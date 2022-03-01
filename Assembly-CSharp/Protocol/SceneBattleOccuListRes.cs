using System;

namespace Protocol
{
	// Token: 0x02000727 RID: 1831
	[Protocol]
	public class SceneBattleOccuListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BCF RID: 23503 RVA: 0x00115968 File Offset: 0x00113D68
		public uint GetMsgID()
		{
			return 508948U;
		}

		// Token: 0x06005BD0 RID: 23504 RVA: 0x0011596F File Offset: 0x00113D6F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BD1 RID: 23505 RVA: 0x00115977 File Offset: 0x00113D77
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BD2 RID: 23506 RVA: 0x00115980 File Offset: 0x00113D80
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.occuList.Length);
			for (int i = 0; i < this.occuList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.occuList[i]);
			}
		}

		// Token: 0x06005BD3 RID: 23507 RVA: 0x001159C8 File Offset: 0x00113DC8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.occuList = new uint[(int)num];
			for (int i = 0; i < this.occuList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.occuList[i]);
			}
		}

		// Token: 0x06005BD4 RID: 23508 RVA: 0x00115A1C File Offset: 0x00113E1C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.occuList.Length);
			for (int i = 0; i < this.occuList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.occuList[i]);
			}
		}

		// Token: 0x06005BD5 RID: 23509 RVA: 0x00115A64 File Offset: 0x00113E64
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.occuList = new uint[(int)num];
			for (int i = 0; i < this.occuList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.occuList[i]);
			}
		}

		// Token: 0x06005BD6 RID: 23510 RVA: 0x00115AB8 File Offset: 0x00113EB8
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.occuList.Length);
		}

		// Token: 0x04002568 RID: 9576
		public const uint MsgID = 508948U;

		// Token: 0x04002569 RID: 9577
		public uint Sequence;

		// Token: 0x0400256A RID: 9578
		public uint[] occuList = new uint[0];
	}
}
