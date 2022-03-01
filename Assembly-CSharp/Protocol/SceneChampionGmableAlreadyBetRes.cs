using System;

namespace Protocol
{
	// Token: 0x02000778 RID: 1912
	[Protocol]
	public class SceneChampionGmableAlreadyBetRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E48 RID: 24136 RVA: 0x0011AA34 File Offset: 0x00118E34
		public uint GetMsgID()
		{
			return 509840U;
		}

		// Token: 0x06005E49 RID: 24137 RVA: 0x0011AA3B File Offset: 0x00118E3B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E4A RID: 24138 RVA: 0x0011AA43 File Offset: 0x00118E43
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E4B RID: 24139 RVA: 0x0011AA4C File Offset: 0x00118E4C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint64(buffer, ref pos_, this.num);
		}

		// Token: 0x06005E4C RID: 24140 RVA: 0x0011AA78 File Offset: 0x00118E78
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005E4D RID: 24141 RVA: 0x0011AAA4 File Offset: 0x00118EA4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint64(buffer, ref pos_, this.num);
		}

		// Token: 0x06005E4E RID: 24142 RVA: 0x0011AAD0 File Offset: 0x00118ED0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005E4F RID: 24143 RVA: 0x0011AAFC File Offset: 0x00118EFC
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 8;
			return num + 8;
		}

		// Token: 0x040026A9 RID: 9897
		public const uint MsgID = 509840U;

		// Token: 0x040026AA RID: 9898
		public uint Sequence;

		// Token: 0x040026AB RID: 9899
		public uint id;

		// Token: 0x040026AC RID: 9900
		public ulong option;

		// Token: 0x040026AD RID: 9901
		public ulong num;
	}
}
