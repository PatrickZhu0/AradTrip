using System;

namespace Protocol
{
	// Token: 0x02000C42 RID: 3138
	[Protocol]
	public class WorldQueryHireListRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060082AB RID: 33451 RVA: 0x0016FFAC File Offset: 0x0016E3AC
		public uint GetMsgID()
		{
			return 601791U;
		}

		// Token: 0x060082AC RID: 33452 RVA: 0x0016FFB3 File Offset: 0x0016E3B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060082AD RID: 33453 RVA: 0x0016FFBB File Offset: 0x0016E3BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060082AE RID: 33454 RVA: 0x0016FFC4 File Offset: 0x0016E3C4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.hireList.Length);
			for (int i = 0; i < this.hireList.Length; i++)
			{
				this.hireList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060082AF RID: 33455 RVA: 0x0017000C File Offset: 0x0016E40C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.hireList = new HirePlayerData[(int)num];
			for (int i = 0; i < this.hireList.Length; i++)
			{
				this.hireList[i] = new HirePlayerData();
				this.hireList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060082B0 RID: 33456 RVA: 0x00170068 File Offset: 0x0016E468
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.hireList.Length);
			for (int i = 0; i < this.hireList.Length; i++)
			{
				this.hireList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x060082B1 RID: 33457 RVA: 0x001700B0 File Offset: 0x0016E4B0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.hireList = new HirePlayerData[(int)num];
			for (int i = 0; i < this.hireList.Length; i++)
			{
				this.hireList[i] = new HirePlayerData();
				this.hireList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x060082B2 RID: 33458 RVA: 0x0017010C File Offset: 0x0016E50C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.hireList.Length; i++)
			{
				num += this.hireList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003E63 RID: 15971
		public const uint MsgID = 601791U;

		// Token: 0x04003E64 RID: 15972
		public uint Sequence;

		// Token: 0x04003E65 RID: 15973
		public HirePlayerData[] hireList = new HirePlayerData[0];
	}
}
