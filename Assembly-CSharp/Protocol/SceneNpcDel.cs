using System;

namespace Protocol
{
	// Token: 0x02000B0E RID: 2830
	[Protocol]
	public class SceneNpcDel : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007996 RID: 31126 RVA: 0x0015DD95 File Offset: 0x0015C195
		public uint GetMsgID()
		{
			return 500623U;
		}

		// Token: 0x06007997 RID: 31127 RVA: 0x0015DD9C File Offset: 0x0015C19C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007998 RID: 31128 RVA: 0x0015DDA4 File Offset: 0x0015C1A4
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007999 RID: 31129 RVA: 0x0015DDB0 File Offset: 0x0015C1B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guids.Length);
			for (int i = 0; i < this.guids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.guids[i]);
			}
		}

		// Token: 0x0600799A RID: 31130 RVA: 0x0015DDF8 File Offset: 0x0015C1F8
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guids = new ulong[(int)num];
			for (int i = 0; i < this.guids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.guids[i]);
			}
		}

		// Token: 0x0600799B RID: 31131 RVA: 0x0015DE4C File Offset: 0x0015C24C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.guids.Length);
			for (int i = 0; i < this.guids.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.guids[i]);
			}
		}

		// Token: 0x0600799C RID: 31132 RVA: 0x0015DE94 File Offset: 0x0015C294
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.guids = new ulong[(int)num];
			for (int i = 0; i < this.guids.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.guids[i]);
			}
		}

		// Token: 0x0600799D RID: 31133 RVA: 0x0015DEE8 File Offset: 0x0015C2E8
		public int getLen()
		{
			int num = 0;
			return num + (2 + 8 * this.guids.Length);
		}

		// Token: 0x0400395D RID: 14685
		public const uint MsgID = 500623U;

		// Token: 0x0400395E RID: 14686
		public uint Sequence;

		// Token: 0x0400395F RID: 14687
		public ulong[] guids = new ulong[0];
	}
}
