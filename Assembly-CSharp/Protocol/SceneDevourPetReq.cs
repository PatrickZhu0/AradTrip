using System;

namespace Protocol
{
	// Token: 0x02000A5C RID: 2652
	[Protocol]
	public class SceneDevourPetReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007492 RID: 29842 RVA: 0x0015183C File Offset: 0x0014FC3C
		public uint GetMsgID()
		{
			return 502215U;
		}

		// Token: 0x06007493 RID: 29843 RVA: 0x00151843 File Offset: 0x0014FC43
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007494 RID: 29844 RVA: 0x0015184B File Offset: 0x0014FC4B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007495 RID: 29845 RVA: 0x00151854 File Offset: 0x0014FC54
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.petIds.Length);
			for (int i = 0; i < this.petIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.petIds[i]);
			}
		}

		// Token: 0x06007496 RID: 29846 RVA: 0x001518AC File Offset: 0x0014FCAC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.petIds = new ulong[(int)num];
			for (int i = 0; i < this.petIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.petIds[i]);
			}
		}

		// Token: 0x06007497 RID: 29847 RVA: 0x0015190C File Offset: 0x0014FD0C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.petIds.Length);
			for (int i = 0; i < this.petIds.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.petIds[i]);
			}
		}

		// Token: 0x06007498 RID: 29848 RVA: 0x00151964 File Offset: 0x0014FD64
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.petIds = new ulong[(int)num];
			for (int i = 0; i < this.petIds.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.petIds[i]);
			}
		}

		// Token: 0x06007499 RID: 29849 RVA: 0x001519C4 File Offset: 0x0014FDC4
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + (2 + 8 * this.petIds.Length);
		}

		// Token: 0x04003620 RID: 13856
		public const uint MsgID = 502215U;

		// Token: 0x04003621 RID: 13857
		public uint Sequence;

		// Token: 0x04003622 RID: 13858
		public ulong id;

		// Token: 0x04003623 RID: 13859
		public ulong[] petIds = new ulong[0];
	}
}
