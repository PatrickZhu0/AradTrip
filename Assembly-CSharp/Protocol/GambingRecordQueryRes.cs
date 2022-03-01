using System;

namespace Protocol
{
	// Token: 0x0200094F RID: 2383
	[Protocol]
	public class GambingRecordQueryRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C2B RID: 27691 RVA: 0x0013B5B8 File Offset: 0x001399B8
		public uint GetMsgID()
		{
			return 707908U;
		}

		// Token: 0x06006C2C RID: 27692 RVA: 0x0013B5BF File Offset: 0x001399BF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C2D RID: 27693 RVA: 0x0013B5C7 File Offset: 0x001399C7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C2E RID: 27694 RVA: 0x0013B5D0 File Offset: 0x001399D0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gambingRecordDatas.Length);
			for (int i = 0; i < this.gambingRecordDatas.Length; i++)
			{
				this.gambingRecordDatas[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C2F RID: 27695 RVA: 0x0013B618 File Offset: 0x00139A18
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gambingRecordDatas = new GambingItemRecordData[(int)num];
			for (int i = 0; i < this.gambingRecordDatas.Length; i++)
			{
				this.gambingRecordDatas[i] = new GambingItemRecordData();
				this.gambingRecordDatas[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C30 RID: 27696 RVA: 0x0013B674 File Offset: 0x00139A74
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.gambingRecordDatas.Length);
			for (int i = 0; i < this.gambingRecordDatas.Length; i++)
			{
				this.gambingRecordDatas[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C31 RID: 27697 RVA: 0x0013B6BC File Offset: 0x00139ABC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.gambingRecordDatas = new GambingItemRecordData[(int)num];
			for (int i = 0; i < this.gambingRecordDatas.Length; i++)
			{
				this.gambingRecordDatas[i] = new GambingItemRecordData();
				this.gambingRecordDatas[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006C32 RID: 27698 RVA: 0x0013B718 File Offset: 0x00139B18
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.gambingRecordDatas.Length; i++)
			{
				num += this.gambingRecordDatas[i].getLen();
			}
			return num;
		}

		// Token: 0x040030F7 RID: 12535
		public const uint MsgID = 707908U;

		// Token: 0x040030F8 RID: 12536
		public uint Sequence;

		// Token: 0x040030F9 RID: 12537
		public GambingItemRecordData[] gambingRecordDatas = new GambingItemRecordData[0];
	}
}
