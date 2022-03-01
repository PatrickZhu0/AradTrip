using System;

namespace Protocol
{
	// Token: 0x020006AB RID: 1707
	[Protocol]
	public class WorldQueryAllExpeditionMapsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005816 RID: 22550 RVA: 0x0010C109 File Offset: 0x0010A509
		public uint GetMsgID()
		{
			return 608622U;
		}

		// Token: 0x06005817 RID: 22551 RVA: 0x0010C110 File Offset: 0x0010A510
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005818 RID: 22552 RVA: 0x0010C118 File Offset: 0x0010A518
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005819 RID: 22553 RVA: 0x0010C124 File Offset: 0x0010A524
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mapBaseInfos.Length);
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				this.mapBaseInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600581A RID: 22554 RVA: 0x0010C178 File Offset: 0x0010A578
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mapBaseInfos = new ExpeditionMapBaseInfo[(int)num];
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				this.mapBaseInfos[i] = new ExpeditionMapBaseInfo();
				this.mapBaseInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600581B RID: 22555 RVA: 0x0010C1E0 File Offset: 0x0010A5E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.resCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mapBaseInfos.Length);
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				this.mapBaseInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600581C RID: 22556 RVA: 0x0010C234 File Offset: 0x0010A634
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.resCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mapBaseInfos = new ExpeditionMapBaseInfo[(int)num];
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				this.mapBaseInfos[i] = new ExpeditionMapBaseInfo();
				this.mapBaseInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600581D RID: 22557 RVA: 0x0010C29C File Offset: 0x0010A69C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				num += this.mapBaseInfos[i].getLen();
			}
			return num;
		}

		// Token: 0x0400230F RID: 8975
		public const uint MsgID = 608622U;

		// Token: 0x04002310 RID: 8976
		public uint Sequence;

		// Token: 0x04002311 RID: 8977
		public uint resCode;

		// Token: 0x04002312 RID: 8978
		public ExpeditionMapBaseInfo[] mapBaseInfos = new ExpeditionMapBaseInfo[0];
	}
}
