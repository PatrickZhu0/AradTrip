using System;

namespace Protocol
{
	// Token: 0x02000C96 RID: 3222
	[Protocol]
	public class WorldUpdatePlayerOnlineReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060084FD RID: 34045 RVA: 0x00175314 File Offset: 0x00173714
		public uint GetMsgID()
		{
			return 601714U;
		}

		// Token: 0x060084FE RID: 34046 RVA: 0x0017531B File Offset: 0x0017371B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060084FF RID: 34047 RVA: 0x00175323 File Offset: 0x00173723
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008500 RID: 34048 RVA: 0x0017532C File Offset: 0x0017372C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.uids.Length);
			for (int i = 0; i < this.uids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.uids[i]);
			}
		}

		// Token: 0x06008501 RID: 34049 RVA: 0x00175374 File Offset: 0x00173774
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.uids = new ulong[(int)num];
			for (int i = 0; i < this.uids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.uids[i]);
			}
		}

		// Token: 0x06008502 RID: 34050 RVA: 0x001753C8 File Offset: 0x001737C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.uids.Length);
			for (int i = 0; i < this.uids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.uids[i]);
			}
		}

		// Token: 0x06008503 RID: 34051 RVA: 0x00175410 File Offset: 0x00173810
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.uids = new ulong[(int)num];
			for (int i = 0; i < this.uids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.uids[i]);
			}
		}

		// Token: 0x06008504 RID: 34052 RVA: 0x00175464 File Offset: 0x00173864
		public int getLen()
		{
			int num = 0;
			return num + (2 + 8 * this.uids.Length);
		}

		// Token: 0x04003FBF RID: 16319
		public const uint MsgID = 601714U;

		// Token: 0x04003FC0 RID: 16320
		public uint Sequence;

		// Token: 0x04003FC1 RID: 16321
		public ulong[] uids = new ulong[0];
	}
}
