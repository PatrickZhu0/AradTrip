using System;

namespace Protocol
{
	// Token: 0x0200099D RID: 2461
	[Protocol]
	public class SceneEquipInscriptionDestroyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006ED7 RID: 28375 RVA: 0x00140769 File Offset: 0x0013EB69
		public uint GetMsgID()
		{
			return 501083U;
		}

		// Token: 0x06006ED8 RID: 28376 RVA: 0x00140770 File Offset: 0x0013EB70
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006ED9 RID: 28377 RVA: 0x00140778 File Offset: 0x0013EB78
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006EDA RID: 28378 RVA: 0x00140781 File Offset: 0x0013EB81
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
		}

		// Token: 0x06006EDB RID: 28379 RVA: 0x001407AD File Offset: 0x0013EBAD
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
		}

		// Token: 0x06006EDC RID: 28380 RVA: 0x001407D9 File Offset: 0x0013EBD9
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
		}

		// Token: 0x06006EDD RID: 28381 RVA: 0x00140805 File Offset: 0x0013EC05
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
		}

		// Token: 0x06006EDE RID: 28382 RVA: 0x00140834 File Offset: 0x0013EC34
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400323B RID: 12859
		public const uint MsgID = 501083U;

		// Token: 0x0400323C RID: 12860
		public uint Sequence;

		// Token: 0x0400323D RID: 12861
		public ulong guid;

		// Token: 0x0400323E RID: 12862
		public uint index;

		// Token: 0x0400323F RID: 12863
		public uint inscriptionId;
	}
}
