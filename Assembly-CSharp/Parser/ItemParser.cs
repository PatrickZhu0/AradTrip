using System;
using GameClient;
using Network;
using Protocol;
using ProtoTable;

namespace Parser
{
	// Token: 0x020045F2 RID: 17906
	public class ItemParser : IParser
	{
		// Token: 0x060192CB RID: 103115 RVA: 0x007F5E3C File Offset: 0x007F423C
		public ParserReturn OnParse(string value)
		{
			ParserReturn result;
			result.color = "#FFFFFF";
			result.iId = 0U;
			result.content = string.Empty;
			string text = value.TrimStart(new char[]
			{
				'['
			});
			text = text.TrimEnd(new char[]
			{
				']'
			});
			int num = int.Parse(text);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return result;
			}
			result.color = tableItem.Color.ToString().ToLower();
			result.content = tableItem.Name;
			result.iId = (uint)num;
			return result;
		}

		// Token: 0x060192CC RID: 103116 RVA: 0x007F5EEC File Offset: 0x007F42EC
		public static void OnItemLink(ulong guid, int iItemID, uint queryPlayerType = 0U, uint zoneId = 0U)
		{
			if (guid != 0UL)
			{
				WorldChatLinkDataReq worldChatLinkDataReq = new WorldChatLinkDataReq();
				worldChatLinkDataReq.type = 73;
				worldChatLinkDataReq.uid = guid;
				worldChatLinkDataReq.queryType = queryPlayerType;
				worldChatLinkDataReq.zoneId = zoneId;
				NetManager.Instance().SendCommand<WorldChatLinkDataReq>(ServerType.GATE_SERVER, worldChatLinkDataReq);
			}
			else
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(iItemID);
				if (commonItemTableDataByID != null)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(commonItemTableDataByID, null, 4, true, false, true);
				}
				else
				{
					Logger.LogErrorFormat("itemData create failed with id = {0}", new object[]
					{
						iItemID
					});
				}
			}
		}

		// Token: 0x060192CD RID: 103117 RVA: 0x007F5F78 File Offset: 0x007F4378
		public static string GetItemColor(ItemTable item)
		{
			string result = "white";
			if (item != null)
			{
				switch (item.Color)
				{
				case ItemTable.eColor.WHITE:
					result = "white";
					break;
				case ItemTable.eColor.BLUE:
					result = "#00C0FF";
					break;
				case ItemTable.eColor.PURPLE:
					result = "#C000FF";
					break;
				case ItemTable.eColor.GREEN:
					result = "#00FF00";
					break;
				case ItemTable.eColor.PINK:
					if (item.Color2 == 3)
					{
						result = "#FF0058";
					}
					else
					{
						result = "#FF00C0";
					}
					break;
				case ItemTable.eColor.YELLOW:
					result = "#FFC000";
					break;
				default:
					result = "white";
					break;
				}
			}
			return result;
		}

		// Token: 0x060192CE RID: 103118 RVA: 0x007F6024 File Offset: 0x007F4424
		public static SpriteAssetColor GetAssetColor(ItemTable item)
		{
			SpriteAssetColor result = SpriteAssetColor.SAC_WHITE;
			if (item != null)
			{
				switch (item.Color)
				{
				case ItemTable.eColor.WHITE:
					result = SpriteAssetColor.SAC_WHITE;
					break;
				case ItemTable.eColor.BLUE:
					result = SpriteAssetColor.SAC_BLUE;
					break;
				case ItemTable.eColor.PURPLE:
					result = SpriteAssetColor.SAC_PURPLE;
					break;
				case ItemTable.eColor.GREEN:
					result = SpriteAssetColor.SAC_GREEN;
					break;
				case ItemTable.eColor.PINK:
					result = SpriteAssetColor.SAC_PINK;
					if (item.Color2 == 3)
					{
						result = SpriteAssetColor.SAC_PINK_RED;
					}
					break;
				case ItemTable.eColor.YELLOW:
					result = SpriteAssetColor.SAC_ORANGE;
					break;
				default:
					result = SpriteAssetColor.SAC_COUNT;
					break;
				}
			}
			return result;
		}
	}
}
