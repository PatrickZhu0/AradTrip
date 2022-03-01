using System;

namespace Protocol
{
	// Token: 0x0200099A RID: 2458
	[Protocol]
	public class SceneEquipInscriptionExtractRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006EBC RID: 28348 RVA: 0x001402D8 File Offset: 0x0013E6D8
		public uint GetMsgID()
		{
			return 501080U;
		}

		// Token: 0x06006EBD RID: 28349 RVA: 0x001402DF File Offset: 0x0013E6DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006EBE RID: 28350 RVA: 0x001402E7 File Offset: 0x0013E6E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006EBF RID: 28351 RVA: 0x001402F0 File Offset: 0x0013E6F0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006EC0 RID: 28352 RVA: 0x0014032A File Offset: 0x0013E72A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006EC1 RID: 28353 RVA: 0x00140364 File Offset: 0x0013E764
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.inscriptionId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
		}

		// Token: 0x06006EC2 RID: 28354 RVA: 0x0014039E File Offset: 0x0013E79E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.inscriptionId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
		}

		// Token: 0x06006EC3 RID: 28355 RVA: 0x001403D8 File Offset: 0x0013E7D8
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400322E RID: 12846
		public const uint MsgID = 501080U;

		// Token: 0x0400322F RID: 12847
		public uint Sequence;

		// Token: 0x04003230 RID: 12848
		public ulong guid;

		// Token: 0x04003231 RID: 12849
		public uint index;

		// Token: 0x04003232 RID: 12850
		public uint inscriptionId;

		// Token: 0x04003233 RID: 12851
		public uint code;
	}
}
