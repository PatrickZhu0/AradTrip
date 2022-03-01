using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x0200062B RID: 1579
	internal static class CustomDecoder
	{
		// Token: 0x0600558E RID: 21902 RVA: 0x00105684 File Offset: 0x00103A84
		public static List<CustomDecoder.RewardItem> DecodeGetRewards(byte[] buffer, ref int pos, int length, ref uint itemSource, ref byte notify)
		{
			BaseDLL.decode_uint32(buffer, ref pos, ref itemSource);
			BaseDLL.decode_int8(buffer, ref pos, ref notify);
			List<CustomDecoder.RewardItem> list = new List<CustomDecoder.RewardItem>();
			if (list == null)
			{
				Logger.LogError("new List<RewardItem>() failed");
				return null;
			}
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos, ref num);
			for (int i = 0; i < (int)num; i++)
			{
				CustomDecoder.RewardItem item = default(CustomDecoder.RewardItem);
				BaseDLL.decode_uint32(buffer, ref pos, ref item.ID);
				BaseDLL.decode_uint32(buffer, ref pos, ref item.Num);
				BaseDLL.decode_int8(buffer, ref pos, ref item.qualityLv);
				BaseDLL.decode_int8(buffer, ref pos, ref item.strength);
				BaseDLL.decode_uint32(buffer, ref pos, ref item.auctionCoolTimeStamp);
				BaseDLL.decode_int8(buffer, ref pos, ref item.equipType);
				BaseDLL.decode_uint32(buffer, ref pos, ref item.auctionTransTimes);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0600558F RID: 21903 RVA: 0x00105754 File Offset: 0x00103B54
		public static bool DecodeStrengthenResult(out CustomDecoder.StrengthenRet ret, byte[] buffer, ref int pos, int length)
		{
			ret = new CustomDecoder.StrengthenRet();
			BaseDLL.decode_uint32(buffer, ref pos, ref ret.code);
			ret.BrokenItems = new List<CustomDecoder.RewardItem>();
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos, ref num);
			for (int i = 0; i < (int)num; i++)
			{
				CustomDecoder.RewardItem item = default(CustomDecoder.RewardItem);
				BaseDLL.decode_uint32(buffer, ref pos, ref item.ID);
				BaseDLL.decode_uint32(buffer, ref pos, ref item.Num);
				BaseDLL.decode_int8(buffer, ref pos, ref item.qualityLv);
				BaseDLL.decode_int8(buffer, ref pos, ref item.strength);
				BaseDLL.decode_uint32(buffer, ref pos, ref item.auctionCoolTimeStamp);
				BaseDLL.decode_int8(buffer, ref pos, ref item.equipType);
				BaseDLL.decode_uint32(buffer, ref pos, ref item.auctionTransTimes);
				ret.BrokenItems.Add(item);
			}
			return true;
		}

		// Token: 0x06005590 RID: 21904 RVA: 0x00105820 File Offset: 0x00103C20
		public static bool DecodeShop(out CustomDecoder.ProtoShop ret, byte[] buffer, ref int pos, int length)
		{
			ret = new CustomDecoder.ProtoShop();
			BaseDLL.decode_uint32(buffer, ref pos, ref ret.shopID);
			BaseDLL.decode_uint16(buffer, ref pos, ref ret.refreshCost);
			ret.shopItemList = new List<CustomDecoder.ProtoShopItem>();
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos, ref num);
			for (int i = 0; i < (int)num; i++)
			{
				CustomDecoder.ProtoShopItem protoShopItem = new CustomDecoder.ProtoShopItem();
				BaseDLL.decode_uint32(buffer, ref pos, ref protoShopItem.shopItemId);
				BaseDLL.decode_int8(buffer, ref pos, ref protoShopItem.grid);
				BaseDLL.decode_int16(buffer, ref pos, ref protoShopItem.restNum);
				BaseDLL.decode_int8(buffer, ref pos, ref protoShopItem.vipLv);
				BaseDLL.decode_int8(buffer, ref pos, ref protoShopItem.vipDiscount);
				BaseDLL.decode_uint32(buffer, ref pos, ref protoShopItem.discount);
				BaseDLL.decode_uint32(buffer, ref pos, ref protoShopItem.leaseEndTimeStamp);
				ret.shopItemList.Add(protoShopItem);
			}
			BaseDLL.decode_uint32(buffer, ref pos, ref ret.restRefreshTime);
			BaseDLL.decode_int8(buffer, ref pos, ref ret.refreshTimes);
			BaseDLL.decode_int8(buffer, ref pos, ref ret.refreshAllTimes);
			BaseDLL.decode_uint32(buffer, ref pos, ref ret.WeekRestRefreshTime);
			BaseDLL.decode_uint32(buffer, ref pos, ref ret.MonthRefreshTime);
			return true;
		}

		// Token: 0x0200062C RID: 1580
		public struct RewardItem
		{
			// Token: 0x04001EC1 RID: 7873
			public uint ID;

			// Token: 0x04001EC2 RID: 7874
			public uint Num;

			// Token: 0x04001EC3 RID: 7875
			public byte qualityLv;

			// Token: 0x04001EC4 RID: 7876
			public byte strength;

			// Token: 0x04001EC5 RID: 7877
			public uint auctionCoolTimeStamp;

			// Token: 0x04001EC6 RID: 7878
			public byte equipType;

			// Token: 0x04001EC7 RID: 7879
			public uint auctionTransTimes;
		}

		// Token: 0x0200062D RID: 1581
		public class StrengthenRet
		{
			// Token: 0x04001EC8 RID: 7880
			public uint code;

			// Token: 0x04001EC9 RID: 7881
			public List<CustomDecoder.RewardItem> BrokenItems;
		}

		// Token: 0x0200062E RID: 1582
		public class ProtoShopItem
		{
			// Token: 0x04001ECA RID: 7882
			public ulong shopId;

			// Token: 0x04001ECB RID: 7883
			public uint shopItemId;

			// Token: 0x04001ECC RID: 7884
			public byte grid;

			// Token: 0x04001ECD RID: 7885
			public short restNum;

			// Token: 0x04001ECE RID: 7886
			public byte vipLv;

			// Token: 0x04001ECF RID: 7887
			public byte vipDiscount;

			// Token: 0x04001ED0 RID: 7888
			public uint discount;

			// Token: 0x04001ED1 RID: 7889
			public uint leaseEndTimeStamp;
		}

		// Token: 0x0200062F RID: 1583
		public class ProtoShop
		{
			// Token: 0x04001ED2 RID: 7890
			public uint shopID;

			// Token: 0x04001ED3 RID: 7891
			public ushort refreshCost;

			// Token: 0x04001ED4 RID: 7892
			public List<CustomDecoder.ProtoShopItem> shopItemList;

			// Token: 0x04001ED5 RID: 7893
			public uint restRefreshTime;

			// Token: 0x04001ED6 RID: 7894
			public byte refreshTimes;

			// Token: 0x04001ED7 RID: 7895
			public byte refreshAllTimes;

			// Token: 0x04001ED8 RID: 7896
			public uint WeekRestRefreshTime;

			// Token: 0x04001ED9 RID: 7897
			public uint MonthRefreshTime;
		}
	}
}
