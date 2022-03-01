using System;

namespace Protocol
{
	// Token: 0x02000677 RID: 1655
	[Protocol]
	public class SceneActiveTaskSubmitRp : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600565A RID: 22106 RVA: 0x00108EA8 File Offset: 0x001072A8
		public uint GetMsgID()
		{
			return 501131U;
		}

		// Token: 0x0600565B RID: 22107 RVA: 0x00108EAF File Offset: 0x001072AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600565C RID: 22108 RVA: 0x00108EB7 File Offset: 0x001072B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600565D RID: 22109 RVA: 0x00108EC0 File Offset: 0x001072C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.taskId.Length);
			for (int i = 0; i < this.taskId.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.taskId[i]);
			}
		}

		// Token: 0x0600565E RID: 22110 RVA: 0x00108F08 File Offset: 0x00107308
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.taskId = new uint[(int)num];
			for (int i = 0; i < this.taskId.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId[i]);
			}
		}

		// Token: 0x0600565F RID: 22111 RVA: 0x00108F5C File Offset: 0x0010735C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.taskId.Length);
			for (int i = 0; i < this.taskId.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.taskId[i]);
			}
		}

		// Token: 0x06005660 RID: 22112 RVA: 0x00108FA4 File Offset: 0x001073A4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.taskId = new uint[(int)num];
			for (int i = 0; i < this.taskId.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId[i]);
			}
		}

		// Token: 0x06005661 RID: 22113 RVA: 0x00108FF8 File Offset: 0x001073F8
		public int getLen()
		{
			int num = 0;
			return num + (2 + 4 * this.taskId.Length);
		}

		// Token: 0x0400224D RID: 8781
		public const uint MsgID = 501131U;

		// Token: 0x0400224E RID: 8782
		public uint Sequence;

		// Token: 0x0400224F RID: 8783
		public uint[] taskId = new uint[0];
	}
}
