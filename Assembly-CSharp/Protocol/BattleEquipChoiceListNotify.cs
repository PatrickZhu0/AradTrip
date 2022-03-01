using System;

namespace Protocol
{
	// Token: 0x02000729 RID: 1833
	[Protocol]
	public class BattleEquipChoiceListNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005BE1 RID: 23521 RVA: 0x00115B60 File Offset: 0x00113F60
		public uint GetMsgID()
		{
			return 508949U;
		}

		// Token: 0x06005BE2 RID: 23522 RVA: 0x00115B67 File Offset: 0x00113F67
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005BE3 RID: 23523 RVA: 0x00115B6F File Offset: 0x00113F6F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005BE4 RID: 23524 RVA: 0x00115B78 File Offset: 0x00113F78
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equipList.Length);
			for (int i = 0; i < this.equipList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.equipList[i]);
			}
		}

		// Token: 0x06005BE5 RID: 23525 RVA: 0x00115BC0 File Offset: 0x00113FC0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.equipList = new uint[(int)num];
			for (int i = 0; i < this.equipList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipList[i]);
			}
		}

		// Token: 0x06005BE6 RID: 23526 RVA: 0x00115C14 File Offset: 0x00114014
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equipList.Length);
			for (int i = 0; i < this.equipList.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.equipList[i]);
			}
		}

		// Token: 0x06005BE7 RID: 23527 RVA: 0x00115C5C File Offset: 0x0011405C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.equipList = new uint[(int)num];
			for (int i = 0; i < this.equipList.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipList[i]);
			}
		}

		// Token: 0x06005BE8 RID: 23528 RVA: 0x00115CB0 File Offset: 0x001140B0
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.equipList.Length);
		}

		// Token: 0x0400256E RID: 9582
		public const uint MsgID = 508949U;

		// Token: 0x0400256F RID: 9583
		public uint Sequence;

		// Token: 0x04002570 RID: 9584
		public uint[] equipList = new uint[0];
	}
}
