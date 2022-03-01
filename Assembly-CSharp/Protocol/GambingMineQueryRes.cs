using System;

namespace Protocol
{
	// Token: 0x0200094D RID: 2381
	[Protocol]
	public class GambingMineQueryRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C19 RID: 27673 RVA: 0x0013B3CC File Offset: 0x001397CC
		public uint GetMsgID()
		{
			return 707906U;
		}

		// Token: 0x06006C1A RID: 27674 RVA: 0x0013B3D3 File Offset: 0x001397D3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C1B RID: 27675 RVA: 0x0013B3DB File Offset: 0x001397DB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C1C RID: 27676 RVA: 0x0013B3E4 File Offset: 0x001397E4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mineGambingInfo.Length);
			for (int i = 0; i < this.mineGambingInfo.Length; i++)
			{
				this.mineGambingInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C1D RID: 27677 RVA: 0x0013B42C File Offset: 0x0013982C
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mineGambingInfo = new GambingMineInfo[(int)num];
			for (int i = 0; i < this.mineGambingInfo.Length; i++)
			{
				this.mineGambingInfo[i] = new GambingMineInfo();
				this.mineGambingInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C1E RID: 27678 RVA: 0x0013B488 File Offset: 0x00139888
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mineGambingInfo.Length);
			for (int i = 0; i < this.mineGambingInfo.Length; i++)
			{
				this.mineGambingInfo[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C1F RID: 27679 RVA: 0x0013B4D0 File Offset: 0x001398D0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mineGambingInfo = new GambingMineInfo[(int)num];
			for (int i = 0; i < this.mineGambingInfo.Length; i++)
			{
				this.mineGambingInfo[i] = new GambingMineInfo();
				this.mineGambingInfo[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C20 RID: 27680 RVA: 0x0013B52C File Offset: 0x0013992C
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.mineGambingInfo.Length; i++)
			{
				num += this.mineGambingInfo[i].getLen();
			}
			return num;
		}

		// Token: 0x040030F2 RID: 12530
		public const uint MsgID = 707906U;

		// Token: 0x040030F3 RID: 12531
		public uint Sequence;

		// Token: 0x040030F4 RID: 12532
		public GambingMineInfo[] mineGambingInfo = new GambingMineInfo[0];
	}
}
