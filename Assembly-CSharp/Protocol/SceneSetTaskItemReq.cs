using System;

namespace Protocol
{
	// Token: 0x02000C61 RID: 3169
	[Protocol]
	public class SceneSetTaskItemReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008374 RID: 33652 RVA: 0x00171794 File Offset: 0x0016FB94
		public uint GetMsgID()
		{
			return 501133U;
		}

		// Token: 0x06008375 RID: 33653 RVA: 0x0017179B File Offset: 0x0016FB9B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008376 RID: 33654 RVA: 0x001717A3 File Offset: 0x0016FBA3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008377 RID: 33655 RVA: 0x001717AC File Offset: 0x0016FBAC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemIds.Length);
			for (int i = 0; i < this.itemIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemIds[i]);
			}
		}

		// Token: 0x06008378 RID: 33656 RVA: 0x00171804 File Offset: 0x0016FC04
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemIds = new ulong[(int)num];
			for (int i = 0; i < this.itemIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemIds[i]);
			}
		}

		// Token: 0x06008379 RID: 33657 RVA: 0x00171864 File Offset: 0x0016FC64
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.taskId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemIds.Length);
			for (int i = 0; i < this.itemIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.itemIds[i]);
			}
		}

		// Token: 0x0600837A RID: 33658 RVA: 0x001718BC File Offset: 0x0016FCBC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.taskId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemIds = new ulong[(int)num];
			for (int i = 0; i < this.itemIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemIds[i]);
			}
		}

		// Token: 0x0600837B RID: 33659 RVA: 0x0017191C File Offset: 0x0016FD1C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + (2 + 8 * this.itemIds.Length);
		}

		// Token: 0x04003EDC RID: 16092
		public const uint MsgID = 501133U;

		// Token: 0x04003EDD RID: 16093
		public uint Sequence;

		// Token: 0x04003EDE RID: 16094
		public uint taskId;

		// Token: 0x04003EDF RID: 16095
		public ulong[] itemIds = new ulong[0];
	}
}
