using System;

namespace Protocol
{
	// Token: 0x02000777 RID: 1911
	[Protocol]
	public class SceneChampionGmableAlreadyBetReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005E3F RID: 24127 RVA: 0x0011A984 File Offset: 0x00118D84
		public uint GetMsgID()
		{
			return 509839U;
		}

		// Token: 0x06005E40 RID: 24128 RVA: 0x0011A98B File Offset: 0x00118D8B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005E41 RID: 24129 RVA: 0x0011A993 File Offset: 0x00118D93
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005E42 RID: 24130 RVA: 0x0011A99C File Offset: 0x00118D9C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
		}

		// Token: 0x06005E43 RID: 24131 RVA: 0x0011A9BA File Offset: 0x00118DBA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
		}

		// Token: 0x06005E44 RID: 24132 RVA: 0x0011A9D8 File Offset: 0x00118DD8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
		}

		// Token: 0x06005E45 RID: 24133 RVA: 0x0011A9F6 File Offset: 0x00118DF6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
		}

		// Token: 0x06005E46 RID: 24134 RVA: 0x0011AA14 File Offset: 0x00118E14
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 8;
		}

		// Token: 0x040026A5 RID: 9893
		public const uint MsgID = 509839U;

		// Token: 0x040026A6 RID: 9894
		public uint Sequence;

		// Token: 0x040026A7 RID: 9895
		public uint id;

		// Token: 0x040026A8 RID: 9896
		public ulong option;
	}
}
