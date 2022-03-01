using System;

namespace Protocol
{
	// Token: 0x0200071B RID: 1819
	[Protocol]
	public class SceneBattleOpenBoxRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005B66 RID: 23398 RVA: 0x00115110 File Offset: 0x00113510
		public uint GetMsgID()
		{
			return 508936U;
		}

		// Token: 0x06005B67 RID: 23399 RVA: 0x00115117 File Offset: 0x00113517
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005B68 RID: 23400 RVA: 0x0011511F File Offset: 0x0011351F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005B69 RID: 23401 RVA: 0x00115128 File Offset: 0x00113528
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.openTime);
		}

		// Token: 0x06005B6A RID: 23402 RVA: 0x00115162 File Offset: 0x00113562
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.openTime);
		}

		// Token: 0x06005B6B RID: 23403 RVA: 0x0011519C File Offset: 0x0011359C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.itemGuid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param);
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint32(buffer, ref pos_, this.openTime);
		}

		// Token: 0x06005B6C RID: 23404 RVA: 0x001151D6 File Offset: 0x001135D6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.itemGuid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.openTime);
		}

		// Token: 0x06005B6D RID: 23405 RVA: 0x00115210 File Offset: 0x00113610
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002542 RID: 9538
		public const uint MsgID = 508936U;

		// Token: 0x04002543 RID: 9539
		public uint Sequence;

		// Token: 0x04002544 RID: 9540
		public ulong itemGuid;

		// Token: 0x04002545 RID: 9541
		public uint param;

		// Token: 0x04002546 RID: 9542
		public uint retCode;

		// Token: 0x04002547 RID: 9543
		public uint openTime;
	}
}
