using System;

namespace Protocol
{
	// Token: 0x02000B50 RID: 2896
	public class AccountShopItemInfo : IProtocolStream
	{
		// Token: 0x06007B91 RID: 31633 RVA: 0x001614B0 File Offset: 0x0015F8B0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.shopItemId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.shopItemName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.tabType);
			BaseDLL.encode_int8(buffer, ref pos_, this.jobType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.costItems.Length);
			for (int i = 0; i < this.costItems.Length; i++)
			{
				this.costItems[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.accountRefreshType);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.accountRefreshTimePoint);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountLimitBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountRestBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountBuyRecordNextRefreshTimestamp);
			BaseDLL.encode_int8(buffer, ref pos_, this.roleRefreshType);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.roleRefreshTimePoint);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.roleBuyRecordNextRefreshTimestamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.roleLimitBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.roleRestBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.extensibleCondition);
			BaseDLL.encode_int8(buffer, ref pos_, this.needPreviewFunc);
		}

		// Token: 0x06007B92 RID: 31634 RVA: 0x0016161C File Offset: 0x0015FA1C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shopItemId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.shopItemName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tabType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.jobType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.costItems = new ItemReward[(int)num2];
			for (int j = 0; j < this.costItems.Length; j++)
			{
				this.costItems[j] = new ItemReward();
				this.costItems[j].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.accountRefreshType);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array2 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[k]);
			}
			this.accountRefreshTimePoint = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountLimitBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountRestBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountBuyRecordNextRefreshTimestamp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roleRefreshType);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array3 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[l]);
			}
			this.roleRefreshTimePoint = StringHelper.BytesToString(array3);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roleBuyRecordNextRefreshTimestamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roleLimitBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roleRestBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.extensibleCondition);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.needPreviewFunc);
		}

		// Token: 0x06007B93 RID: 31635 RVA: 0x00161824 File Offset: 0x0015FC24
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.shopItemId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.shopItemName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.tabType);
			BaseDLL.encode_int8(buffer, ref pos_, this.jobType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemDataId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemNum);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.costItems.Length);
			for (int i = 0; i < this.costItems.Length; i++)
			{
				this.costItems[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.accountRefreshType);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.accountRefreshTimePoint);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountLimitBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountRestBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accountBuyRecordNextRefreshTimestamp);
			BaseDLL.encode_int8(buffer, ref pos_, this.roleRefreshType);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.roleRefreshTimePoint);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.roleBuyRecordNextRefreshTimestamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.roleLimitBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.roleRestBuyNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.extensibleCondition);
			BaseDLL.encode_int8(buffer, ref pos_, this.needPreviewFunc);
		}

		// Token: 0x06007B94 RID: 31636 RVA: 0x0016199C File Offset: 0x0015FD9C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shopItemId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.shopItemName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.tabType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.jobType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemDataId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemNum);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.costItems = new ItemReward[(int)num2];
			for (int j = 0; j < this.costItems.Length; j++)
			{
				this.costItems[j] = new ItemReward();
				this.costItems[j].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.accountRefreshType);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array2 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[k]);
			}
			this.accountRefreshTimePoint = StringHelper.BytesToString(array2);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountLimitBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountRestBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accountBuyRecordNextRefreshTimestamp);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.roleRefreshType);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array3 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[l]);
			}
			this.roleRefreshTimePoint = StringHelper.BytesToString(array3);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roleBuyRecordNextRefreshTimestamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roleLimitBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.roleRestBuyNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.extensibleCondition);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.needPreviewFunc);
		}

		// Token: 0x06007B95 RID: 31637 RVA: 0x00161BA4 File Offset: 0x0015FFA4
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.shopItemName);
			num += 2 + array.Length;
			num++;
			num++;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.costItems.Length; i++)
			{
				num += this.costItems[i].getLen();
			}
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.accountRefreshTimePoint);
			num += 2 + array2.Length;
			num += 4;
			num += 4;
			num += 4;
			num++;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.roleRefreshTimePoint);
			num += 2 + array3.Length;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 1;
		}

		// Token: 0x04003A7C RID: 14972
		public uint shopItemId;

		// Token: 0x04003A7D RID: 14973
		public string shopItemName;

		// Token: 0x04003A7E RID: 14974
		public byte tabType;

		// Token: 0x04003A7F RID: 14975
		public byte jobType;

		// Token: 0x04003A80 RID: 14976
		public uint itemDataId;

		// Token: 0x04003A81 RID: 14977
		public uint itemNum;

		// Token: 0x04003A82 RID: 14978
		public ItemReward[] costItems = new ItemReward[0];

		// Token: 0x04003A83 RID: 14979
		public byte accountRefreshType;

		// Token: 0x04003A84 RID: 14980
		public string accountRefreshTimePoint;

		// Token: 0x04003A85 RID: 14981
		public uint accountLimitBuyNum;

		// Token: 0x04003A86 RID: 14982
		public uint accountRestBuyNum;

		// Token: 0x04003A87 RID: 14983
		public uint accountBuyRecordNextRefreshTimestamp;

		// Token: 0x04003A88 RID: 14984
		public byte roleRefreshType;

		// Token: 0x04003A89 RID: 14985
		public string roleRefreshTimePoint;

		// Token: 0x04003A8A RID: 14986
		public uint roleBuyRecordNextRefreshTimestamp;

		// Token: 0x04003A8B RID: 14987
		public uint roleLimitBuyNum;

		// Token: 0x04003A8C RID: 14988
		public uint roleRestBuyNum;

		// Token: 0x04003A8D RID: 14989
		public uint extensibleCondition;

		// Token: 0x04003A8E RID: 14990
		public byte needPreviewFunc;
	}
}
