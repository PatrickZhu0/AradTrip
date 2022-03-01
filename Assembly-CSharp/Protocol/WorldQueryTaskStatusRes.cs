using System;

namespace Protocol
{
	// Token: 0x02000C3D RID: 3133
	[Protocol]
	public class WorldQueryTaskStatusRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008281 RID: 33409 RVA: 0x0016F908 File Offset: 0x0016DD08
		public uint GetMsgID()
		{
			return 601787U;
		}

		// Token: 0x06008282 RID: 33410 RVA: 0x0016F90F File Offset: 0x0016DD0F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008283 RID: 33411 RVA: 0x0016F917 File Offset: 0x0016DD17
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008284 RID: 33412 RVA: 0x0016F920 File Offset: 0x0016DD20
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.hireTaskInfoList.Length);
			for (int i = 0; i < this.hireTaskInfoList.Length; i++)
			{
				this.hireTaskInfoList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008285 RID: 33413 RVA: 0x0016F968 File Offset: 0x0016DD68
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.hireTaskInfoList = new HireInfoData[(int)num];
			for (int i = 0; i < this.hireTaskInfoList.Length; i++)
			{
				this.hireTaskInfoList[i] = new HireInfoData();
				this.hireTaskInfoList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06008286 RID: 33414 RVA: 0x0016F9C4 File Offset: 0x0016DDC4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.hireTaskInfoList.Length);
			for (int i = 0; i < this.hireTaskInfoList.Length; i++)
			{
				this.hireTaskInfoList[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06008287 RID: 33415 RVA: 0x0016FA0C File Offset: 0x0016DE0C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.hireTaskInfoList = new HireInfoData[(int)num];
			for (int i = 0; i < this.hireTaskInfoList.Length; i++)
			{
				this.hireTaskInfoList[i] = new HireInfoData();
				this.hireTaskInfoList[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06008288 RID: 33416 RVA: 0x0016FA68 File Offset: 0x0016DE68
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.hireTaskInfoList.Length; i++)
			{
				num += this.hireTaskInfoList[i].getLen();
			}
			return num;
		}

		// Token: 0x04003E53 RID: 15955
		public const uint MsgID = 601787U;

		// Token: 0x04003E54 RID: 15956
		public uint Sequence;

		// Token: 0x04003E55 RID: 15957
		public HireInfoData[] hireTaskInfoList = new HireInfoData[0];
	}
}
