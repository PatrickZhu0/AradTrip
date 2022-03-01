using System;

namespace Protocol
{
	// Token: 0x0200097D RID: 2429
	[Protocol]
	public class WorldGetRechargePushItemsRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006DBA RID: 28090 RVA: 0x0013E5E4 File Offset: 0x0013C9E4
		public uint GetMsgID()
		{
			return 602828U;
		}

		// Token: 0x06006DBB RID: 28091 RVA: 0x0013E5EB File Offset: 0x0013C9EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006DBC RID: 28092 RVA: 0x0013E5F3 File Offset: 0x0013C9F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006DBD RID: 28093 RVA: 0x0013E5FC File Offset: 0x0013C9FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemVec.Length);
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DBE RID: 28094 RVA: 0x0013E650 File Offset: 0x0013CA50
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemVec = new RechargePushItem[(int)num];
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i] = new RechargePushItem();
				this.itemVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DBF RID: 28095 RVA: 0x0013E6B8 File Offset: 0x0013CAB8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemVec.Length);
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DC0 RID: 28096 RVA: 0x0013E70C File Offset: 0x0013CB0C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemVec = new RechargePushItem[(int)num];
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				this.itemVec[i] = new RechargePushItem();
				this.itemVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006DC1 RID: 28097 RVA: 0x0013E774 File Offset: 0x0013CB74
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			for (int i = 0; i < this.itemVec.Length; i++)
			{
				num += this.itemVec[i].getLen();
			}
			return num;
		}

		// Token: 0x040031B1 RID: 12721
		public const uint MsgID = 602828U;

		// Token: 0x040031B2 RID: 12722
		public uint Sequence;

		// Token: 0x040031B3 RID: 12723
		public uint retCode;

		// Token: 0x040031B4 RID: 12724
		public RechargePushItem[] itemVec = new RechargePushItem[0];
	}
}
