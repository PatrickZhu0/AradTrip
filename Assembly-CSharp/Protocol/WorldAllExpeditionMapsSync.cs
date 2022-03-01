using System;

namespace Protocol
{
	// Token: 0x020006B0 RID: 1712
	[Protocol]
	public class WorldAllExpeditionMapsSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005843 RID: 22595 RVA: 0x0010C93D File Offset: 0x0010AD3D
		public uint GetMsgID()
		{
			return 608628U;
		}

		// Token: 0x06005844 RID: 22596 RVA: 0x0010C944 File Offset: 0x0010AD44
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005845 RID: 22597 RVA: 0x0010C94C File Offset: 0x0010AD4C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005846 RID: 22598 RVA: 0x0010C958 File Offset: 0x0010AD58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mapBaseInfos.Length);
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				this.mapBaseInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005847 RID: 22599 RVA: 0x0010C9A0 File Offset: 0x0010ADA0
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mapBaseInfos = new ExpeditionMapBaseInfo[(int)num];
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				this.mapBaseInfos[i] = new ExpeditionMapBaseInfo();
				this.mapBaseInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06005848 RID: 22600 RVA: 0x0010C9FC File Offset: 0x0010ADFC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.mapBaseInfos.Length);
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				this.mapBaseInfos[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06005849 RID: 22601 RVA: 0x0010CA44 File Offset: 0x0010AE44
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.mapBaseInfos = new ExpeditionMapBaseInfo[(int)num];
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				this.mapBaseInfos[i] = new ExpeditionMapBaseInfo();
				this.mapBaseInfos[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600584A RID: 22602 RVA: 0x0010CAA0 File Offset: 0x0010AEA0
		public int getLen()
		{
			int num = 0;
			num += 2;
			for (int i = 0; i < this.mapBaseInfos.Length; i++)
			{
				num += this.mapBaseInfos[i].getLen();
			}
			return num;
		}

		// Token: 0x04002320 RID: 8992
		public const uint MsgID = 608628U;

		// Token: 0x04002321 RID: 8993
		public uint Sequence;

		// Token: 0x04002322 RID: 8994
		public ExpeditionMapBaseInfo[] mapBaseInfos = new ExpeditionMapBaseInfo[0];
	}
}
