using System;

namespace Protocol
{
	// Token: 0x02000750 RID: 1872
	[Protocol]
	public class SceneChampionGambleReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CFB RID: 23803 RVA: 0x00117E49 File Offset: 0x00116249
		public uint GetMsgID()
		{
			return 509811U;
		}

		// Token: 0x06005CFC RID: 23804 RVA: 0x00117E50 File Offset: 0x00116250
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CFD RID: 23805 RVA: 0x00117E58 File Offset: 0x00116258
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CFE RID: 23806 RVA: 0x00117E64 File Offset: 0x00116264
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint32(buffer, ref pos_, this.coin);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
		}

		// Token: 0x06005CFF RID: 23807 RVA: 0x00117EB8 File Offset: 0x001162B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.coin);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
		}

		// Token: 0x06005D00 RID: 23808 RVA: 0x00117F0C File Offset: 0x0011630C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleID);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint32(buffer, ref pos_, this.coin);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
		}

		// Token: 0x06005D01 RID: 23809 RVA: 0x00117F60 File Offset: 0x00116360
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleID);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.coin);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
		}

		// Token: 0x06005D02 RID: 23810 RVA: 0x00117FB4 File Offset: 0x001163B4
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 8;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002618 RID: 9752
		public const uint MsgID = 509811U;

		// Token: 0x04002619 RID: 9753
		public uint Sequence;

		// Token: 0x0400261A RID: 9754
		public ulong roleID;

		// Token: 0x0400261B RID: 9755
		public uint id;

		// Token: 0x0400261C RID: 9756
		public ulong option;

		// Token: 0x0400261D RID: 9757
		public uint coin;

		// Token: 0x0400261E RID: 9758
		public uint accid;
	}
}
