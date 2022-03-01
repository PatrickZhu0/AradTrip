using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001228 RID: 4648
	public static class CommonUtility
	{
		// Token: 0x0600B297 RID: 45719 RVA: 0x00279CBC File Offset: 0x002780BC
		public static CommonNewItem CreateCommonNewItem(GameObject parent)
		{
			if (parent == null)
			{
				Logger.LogErrorFormat("CommonNewItem Create parent is null", new object[0]);
				return null;
			}
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("UIFlatten/Prefabs/Common/CommonItem/CommonNewItem", true, 0U);
			if (gameObject == null)
			{
				return null;
			}
			CommonNewItem component = gameObject.GetComponent<CommonNewItem>();
			if (component == null)
			{
				return null;
			}
			component.Reset();
			component.gameObject.transform.SetParent(parent.transform, false);
			return component;
		}

		// Token: 0x0600B298 RID: 45720 RVA: 0x00279D3A File Offset: 0x0027813A
		public static void OnCloseCommonKeyBoardFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonKeyBoardFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonKeyBoardFrame>(null, false);
			}
		}

		// Token: 0x0600B299 RID: 45721 RVA: 0x00279D58 File Offset: 0x00278158
		public static void OnOpenCommonKeyBoardFrame(Vector3 vector3, ulong currentValue = 0UL, ulong maxValue = 0UL)
		{
			CommonUtility.OnCloseCommonKeyBoardFrame();
			CommonKeyBoardDataModel userData = new CommonKeyBoardDataModel
			{
				Position = vector3,
				CurrentValue = currentValue,
				MaxValue = maxValue
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CommonKeyBoardFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600B29A RID: 45722 RVA: 0x00279D9C File Offset: 0x0027819C
		public static string GetItemColorName(ItemTable itemTable)
		{
			if (itemTable == null)
			{
				return string.Empty;
			}
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(itemTable.Color, itemTable.Color2 == 1, itemTable.Color2 == 3);
			if (qualityInfo == null)
			{
				return itemTable.Name;
			}
			return string.Format("<color={0}>{1}</color>", qualityInfo.ColStr, itemTable.Name);
		}

		// Token: 0x0600B29B RID: 45723 RVA: 0x00279DF8 File Offset: 0x002781F8
		public static string GetItemColorNameByNameAndColor(string nameStr, ItemTable.eColor itemTableColor)
		{
			if (string.IsNullOrEmpty(nameStr))
			{
				return string.Empty;
			}
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(itemTableColor, false, false);
			if (qualityInfo == null)
			{
				return nameStr;
			}
			return string.Format("<color={0}>{1}</color>", qualityInfo.ColStr, nameStr);
		}

		// Token: 0x0600B29C RID: 45724 RVA: 0x00279E38 File Offset: 0x00278238
		public static string GetPetItemName(PetTable petTable)
		{
			if (petTable == null)
			{
				return string.Empty;
			}
			string name = petTable.Name;
			ItemTable.eColor quality = (ItemTable.eColor)petTable.Quality;
			return CommonUtility.GetItemColorNameByNameAndColor(name, quality);
		}

		// Token: 0x0600B29D RID: 45725 RVA: 0x00279E68 File Offset: 0x00278268
		public static void UpdateButtonState(Button button, UIGray buttonGray, bool flag)
		{
			if (button != null)
			{
				button.interactable = flag;
			}
			if (buttonGray != null)
			{
				buttonGray.enabled = !flag;
				buttonGray.Refresh();
			}
		}

		// Token: 0x0600B29E RID: 45726 RVA: 0x00279E99 File Offset: 0x00278299
		public static void UpdateButtonVisible(Button button, bool flag)
		{
			if (button != null)
			{
				button.gameObject.SetActive(flag);
			}
		}

		// Token: 0x0600B29F RID: 45727 RVA: 0x00279EB3 File Offset: 0x002782B3
		public static void UpdateButtonWithCdVisibleAndReset(ComButtonWithCd buttonWithCd, bool flag)
		{
			if (buttonWithCd == null)
			{
				return;
			}
			buttonWithCd.Reset();
			CommonUtility.UpdateGameObjectVisible(buttonWithCd.gameObject, flag);
		}

		// Token: 0x0600B2A0 RID: 45728 RVA: 0x00279ED4 File Offset: 0x002782D4
		public static void UpdateButtonWithCdVisible(ComButtonWithCd buttonWithCd, bool flag)
		{
			if (buttonWithCd != null)
			{
				CommonUtility.UpdateGameObjectVisible(buttonWithCd.gameObject, flag);
			}
		}

		// Token: 0x0600B2A1 RID: 45729 RVA: 0x00279EEE File Offset: 0x002782EE
		public static void UpdateGameObjectVisible(GameObject go, bool flag)
		{
			if (go != null)
			{
				go.SetActive(flag);
			}
		}

		// Token: 0x0600B2A2 RID: 45730 RVA: 0x00279F03 File Offset: 0x00278303
		public static void UpdateGameObjectUiGray(UIGray uiGray, bool flag)
		{
			if (uiGray != null)
			{
				uiGray.SetEnable(flag);
			}
		}

		// Token: 0x0600B2A3 RID: 45731 RVA: 0x00279F18 File Offset: 0x00278318
		public static void UpdateImageVisible(Image image, bool flag)
		{
			if (image != null)
			{
				image.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600B2A4 RID: 45732 RVA: 0x00279F32 File Offset: 0x00278332
		public static void UpdateTextVisible(Text text, bool flag)
		{
			if (text != null)
			{
				text.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600B2A5 RID: 45733 RVA: 0x00279F4C File Offset: 0x0027834C
		public static void UpdateUIGrayVisible(UIGray uiGray, bool flag)
		{
			if (uiGray != null)
			{
				uiGray.enabled = flag;
				uiGray.Refresh();
			}
		}

		// Token: 0x0600B2A6 RID: 45734 RVA: 0x00279F67 File Offset: 0x00278367
		public static int GetMiddleValue(int value, int min, int max)
		{
			return Math.Min(Math.Max(value, min), max);
		}

		// Token: 0x0600B2A7 RID: 45735 RVA: 0x00279F76 File Offset: 0x00278376
		public static string GetItemNameLinkParseString(int itemId)
		{
			return string.Format(" {{I 0 {0} 0}}", itemId);
		}

		// Token: 0x0600B2A8 RID: 45736 RVA: 0x00279F88 File Offset: 0x00278388
		public static GameObject LoadGameObjectWithPath(GameObject gameObjectRoot, string goPath)
		{
			if (gameObjectRoot == null)
			{
				return null;
			}
			UIPrefabWrapper component = gameObjectRoot.GetComponent<UIPrefabWrapper>();
			if (component == null)
			{
				return null;
			}
			component.m_PrefabName = goPath;
			GameObject gameObject = component.LoadUIPrefab();
			if (gameObject != null)
			{
				gameObject.transform.SetParent(gameObjectRoot.transform, false);
			}
			return gameObject;
		}

		// Token: 0x0600B2A9 RID: 45737 RVA: 0x00279FE8 File Offset: 0x002783E8
		public static GameObject LoadGameObject(GameObject gameObjectRoot)
		{
			if (gameObjectRoot == null)
			{
				return null;
			}
			UIPrefabWrapper component = gameObjectRoot.GetComponent<UIPrefabWrapper>();
			if (component == null)
			{
				return null;
			}
			GameObject gameObject = component.LoadUIPrefab();
			if (gameObject != null)
			{
				gameObject.transform.SetParent(gameObjectRoot.transform, false);
			}
			return gameObject;
		}

		// Token: 0x0600B2AA RID: 45738 RVA: 0x0027A040 File Offset: 0x00278440
		public static T LoadGameObjectWithType<T>(GameObject gameObjectRoot) where T : MonoBehaviour
		{
			GameObject gameObject = CommonUtility.LoadGameObject(gameObjectRoot);
			if (gameObject == null)
			{
				return (T)((object)null);
			}
			return gameObject.GetComponent<T>();
		}

		// Token: 0x0600B2AB RID: 45739 RVA: 0x0027A070 File Offset: 0x00278470
		public static void SetGameObjectLoadPath(GameObject gameObjectRoot, string loadPath)
		{
			if (gameObjectRoot == null)
			{
				return;
			}
			UIPrefabWrapper component = gameObjectRoot.GetComponent<UIPrefabWrapper>();
			if (component == null)
			{
				return;
			}
			component.m_PrefabName = loadPath;
		}

		// Token: 0x0600B2AC RID: 45740 RVA: 0x0027A0A8 File Offset: 0x002784A8
		public static void OnShowCommonMsgBoxWithToggleButton(string tipContent, OnCommonMsgBoxToggleClick onToggleClickAction, Action onLeftAction, Action onRightAction)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = tipContent,
				IsShowNotify = true,
				OnCommonMsgBoxToggleClick = onToggleClickAction,
				LeftButtonText = TR.Value("common_data_cancel"),
				OnLeftButtonClickCallBack = onLeftAction,
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onRightAction
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B2AD RID: 45741 RVA: 0x0027A108 File Offset: 0x00278508
		public static void OnShowCommonMsgBox(string tipContent, Action onRightAction, string rightButtonText)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = tipContent,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = rightButtonText,
				OnRightButtonClickCallBack = onRightAction
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B2AE RID: 45742 RVA: 0x0027A150 File Offset: 0x00278550
		public static void OnShowCommonMsgBoxWithMiddleButton(string tipContent, Action onMiddleAction, string middleButtonText)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = tipContent,
				IsShowNotify = false,
				IsMiddleButton = true,
				MiddleButtonText = middleButtonText,
				OnMiddleButtonClickCallBack = onMiddleAction
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B2AF RID: 45743 RVA: 0x0027A18E File Offset: 0x0027858E
		public static bool IsSelfPlayerByPlayerGuid(ulong playerGuid)
		{
			return playerGuid != 0UL && playerGuid == DataManager<PlayerBaseData>.GetInstance().RoleID;
		}

		// Token: 0x0600B2B0 RID: 45744 RVA: 0x0027A1B0 File Offset: 0x002785B0
		public static void RemoveChildGameObject(GameObject root)
		{
			if (root == null || root.transform == null)
			{
				return;
			}
			Transform transform = root.transform;
			if (transform.childCount <= 0)
			{
				return;
			}
			for (int i = transform.childCount - 1; i >= 0; i--)
			{
				Object.Destroy(transform.GetChild(i).gameObject);
			}
		}

		// Token: 0x0600B2B1 RID: 45745 RVA: 0x0027A21C File Offset: 0x0027861C
		public static string GetFinalStringByUpdateChangeLineFlag(string originalStr)
		{
			if (string.IsNullOrEmpty(originalStr))
			{
				return string.Empty;
			}
			return originalStr.Replace("\\n", "\n");
		}

		// Token: 0x0600B2B2 RID: 45746 RVA: 0x0027A24C File Offset: 0x0027864C
		public static List<CommonSplitDataModel> GetSplitDataModelListByTwoSplitChar(string splitStr, char splitOne, char splitTwo)
		{
			if (string.IsNullOrEmpty(splitStr))
			{
				return null;
			}
			string[] array = splitStr.Split(new char[]
			{
				splitOne
			});
			if (array.Length <= 0)
			{
				return null;
			}
			List<CommonSplitDataModel> list = new List<CommonSplitDataModel>();
			foreach (string text in array)
			{
				if (!string.IsNullOrEmpty(text))
				{
					string[] array2 = text.Split(new char[]
					{
						splitTwo
					});
					if (array2.Length == 2)
					{
						string text2 = array2[0];
						string text3 = array2[1];
						if (!string.IsNullOrEmpty(text2))
						{
							if (!string.IsNullOrEmpty(text3))
							{
								int num = 0;
								if (int.TryParse(text2, out num))
								{
									int num2 = 0;
									if (int.TryParse(text3, out num2))
									{
										if (num > 0 && num2 > 0)
										{
											CommonSplitDataModel item = new CommonSplitDataModel
											{
												FirstNumber = num,
												SecondNumber = num2
											};
											list.Add(item);
										}
									}
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B2B3 RID: 45747 RVA: 0x0027A368 File Offset: 0x00278768
		public static CommonSplitDataModel GetSplitDataModelByOneSplitChar(string splitStr, char splitChar)
		{
			if (string.IsNullOrEmpty(splitStr))
			{
				return null;
			}
			string[] array = splitStr.Split(new char[]
			{
				splitChar
			});
			if (array.Length != 2)
			{
				return null;
			}
			string text = array[0];
			string text2 = array[1];
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			if (string.IsNullOrEmpty(text2))
			{
				return null;
			}
			int num = 0;
			if (!int.TryParse(text, out num))
			{
				return null;
			}
			int num2 = 0;
			if (!int.TryParse(text2, out num2))
			{
				return null;
			}
			if (num <= 0 || num2 <= 0)
			{
				return null;
			}
			return new CommonSplitDataModel
			{
				FirstNumber = num,
				SecondNumber = num2
			};
		}

		// Token: 0x0600B2B4 RID: 45748 RVA: 0x0027A410 File Offset: 0x00278810
		public static List<int> GetNumberListBySplitStringWithLine(string splitStr)
		{
			if (string.IsNullOrEmpty(splitStr))
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (string text in splitStr.Split(new char[]
			{
				'_'
			}))
			{
				if (!string.IsNullOrEmpty(text))
				{
					int item = 0;
					if (int.TryParse(text, out item))
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B2B5 RID: 45749 RVA: 0x0027A484 File Offset: 0x00278884
		public static List<int> GetNumberListBySplitString(string splitStr)
		{
			if (string.IsNullOrEmpty(splitStr))
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (string text in splitStr.Split(new char[]
			{
				'|'
			}))
			{
				if (!string.IsNullOrEmpty(text))
				{
					int item = 0;
					if (int.TryParse(text, out item))
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B2B6 RID: 45750 RVA: 0x0027A4F8 File Offset: 0x002788F8
		public static List<ReceiveItemDataModel> GetReceiveItemDataModelBySplitString(string splitStr)
		{
			if (string.IsNullOrEmpty(splitStr))
			{
				return null;
			}
			List<ReceiveItemDataModel> list = new List<ReceiveItemDataModel>();
			foreach (string text in splitStr.Split(new char[]
			{
				'|'
			}))
			{
				if (!string.IsNullOrEmpty(text))
				{
					string[] array2 = text.Split(new char[]
					{
						','
					});
					if (array2.Length == 3)
					{
						ReceiveItemDataModel receiveItemDataModel = new ReceiveItemDataModel();
						string s = array2[0];
						string s2 = array2[1];
						string s3 = array2[2];
						int itemId = 0;
						if (int.TryParse(s, out itemId))
						{
							receiveItemDataModel.ItemId = itemId;
						}
						int minNumber = 0;
						if (int.TryParse(s2, out minNumber))
						{
							receiveItemDataModel.MinNumber = minNumber;
						}
						int maxNumber = 0;
						if (int.TryParse(s3, out maxNumber))
						{
							receiveItemDataModel.MaxNumber = maxNumber;
						}
						list.Add(receiveItemDataModel);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B2B7 RID: 45751 RVA: 0x0027A5E4 File Offset: 0x002789E4
		public static List<string> GetStrListBySplitString(string splitStr)
		{
			if (string.IsNullOrEmpty(splitStr))
			{
				return null;
			}
			List<string> list = new List<string>();
			foreach (string text in splitStr.Split(new char[]
			{
				'|'
			}))
			{
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
			}
			return list;
		}

		// Token: 0x0600B2B8 RID: 45752 RVA: 0x0027A648 File Offset: 0x00278A48
		public static List<ItemSimpleData> GetItemSimpleDataListByTwoSplitChar(string splitStr, char splitOne, char splitTwo)
		{
			if (string.IsNullOrEmpty(splitStr))
			{
				return null;
			}
			List<ItemSimpleData> list = new List<ItemSimpleData>();
			string[] array = splitStr.Split(new char[]
			{
				splitOne
			});
			if (array != null)
			{
				foreach (string text in array)
				{
					if (!string.IsNullOrEmpty(text))
					{
						string[] array2 = text.Split(new char[]
						{
							splitTwo
						});
						ItemSimpleData itemSimpleData = new ItemSimpleData();
						if (array2.Length >= 3)
						{
							int level = 0;
							if (int.TryParse(array2[0], out level))
							{
								itemSimpleData.level = level;
							}
							int itemID = 0;
							if (int.TryParse(array2[1], out itemID))
							{
								itemSimpleData.ItemID = itemID;
							}
							int count = 0;
							if (int.TryParse(array2[2], out count))
							{
								itemSimpleData.Count = count;
							}
						}
						else if (array2.Length >= 2)
						{
							int itemID2 = 0;
							if (int.TryParse(array2[0], out itemID2))
							{
								itemSimpleData.ItemID = itemID2;
							}
							int count2 = 0;
							if (int.TryParse(array2[1], out count2))
							{
								itemSimpleData.Count = count2;
							}
						}
						list.Add(itemSimpleData);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B2B9 RID: 45753 RVA: 0x0027A770 File Offset: 0x00278B70
		public static ItemSimpleData GetItemSimpleDataByOneSplitChar(string splitStr, char splitChar)
		{
			if (string.IsNullOrEmpty(splitStr))
			{
				return null;
			}
			string[] array = splitStr.Split(new char[]
			{
				splitChar
			});
			if (array.Length != 2)
			{
				return null;
			}
			string text = array[0];
			string text2 = array[1];
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			if (string.IsNullOrEmpty(text2))
			{
				return null;
			}
			int num = 0;
			if (!int.TryParse(text, out num))
			{
				return null;
			}
			int num2 = 0;
			if (!int.TryParse(text2, out num2))
			{
				return null;
			}
			if (num <= 0 || num2 <= 0)
			{
				return null;
			}
			return new ItemSimpleData
			{
				ItemID = num,
				Count = num2
			};
		}

		// Token: 0x0600B2BA RID: 45754 RVA: 0x0027A818 File Offset: 0x00278C18
		public static bool IsProfessionIdIsChangeProfessionId(int professionId)
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(professionId, string.Empty, string.Empty);
			return tableItem != null && tableItem.JobType == 1;
		}

		// Token: 0x0600B2BB RID: 45755 RVA: 0x0027A854 File Offset: 0x00278C54
		public static int GetSelfBaseJobId()
		{
			int num = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return num;
			}
			if (tableItem.JobType == 1)
			{
				num = tableItem.prejob;
			}
			return num;
		}

		// Token: 0x0600B2BC RID: 45756 RVA: 0x0027A8A0 File Offset: 0x00278CA0
		public static string GetPlayerProfessionName()
		{
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return tableItem.Name;
		}

		// Token: 0x0600B2BD RID: 45757 RVA: 0x0027A8E0 File Offset: 0x00278CE0
		public static bool FindInListByBinarySearch(List<ulong> numberList, ulong number)
		{
			if (numberList == null || numberList.Count <= 0)
			{
				return false;
			}
			int i = 0;
			int num = numberList.Count - 1;
			while (i <= num)
			{
				int num2 = (num - i) / 2 + i;
				if (numberList[num2] == number)
				{
					return true;
				}
				if (numberList[num2] > number)
				{
					num = num2 - 1;
				}
				else
				{
					i = num2 + 1;
				}
			}
			return false;
		}

		// Token: 0x0600B2BE RID: 45758 RVA: 0x0027A94C File Offset: 0x00278D4C
		public static bool IsInBattleScene()
		{
			return Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemBattle;
		}

		// Token: 0x0600B2BF RID: 45759 RVA: 0x0027A974 File Offset: 0x00278D74
		public static bool IsInGameBattleScene()
		{
			return Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemGameBattle;
		}

		// Token: 0x0600B2C0 RID: 45760 RVA: 0x0027A99C File Offset: 0x00278D9C
		public static bool IsInTownScene()
		{
			return Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown;
		}

		// Token: 0x0600B2C1 RID: 45761 RVA: 0x0027A9C4 File Offset: 0x00278DC4
		public static void SwitchToBirthCitySceneInClientSystemTown(SceneParams.OnSceneLoadFinish sceneLoadFinish = null)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			SceneParams data = new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = tableItem.BirthCity,
				targetDoorID = 0,
				onSceneLoadFinish = sceneLoadFinish
			};
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(data, false));
		}

		// Token: 0x0600B2C2 RID: 45762 RVA: 0x0027AA54 File Offset: 0x00278E54
		public static void OnEndSceneInClientSystemTown(int targetSceneId)
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(targetSceneId, string.Empty, string.Empty) == null)
			{
				return;
			}
			SceneParams data = new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = targetSceneId,
				targetDoorID = 0
			};
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(data, false));
		}

		// Token: 0x0600B2C3 RID: 45763 RVA: 0x0027AAF0 File Offset: 0x00278EF0
		public static void SetClientSystemTownFrameForbidFadeIn(bool flag)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				if (clientSystemTownFrame != null)
				{
					clientSystemTownFrame.SetForbidFadeIn(flag);
				}
			}
		}

		// Token: 0x0600B2C4 RID: 45764 RVA: 0x0027AB34 File Offset: 0x00278F34
		public static void OnOpenCommonSetContentFrame(CommonSetContentDataModel setContentDataModel)
		{
			CommonUtility.OnCloseCommonSetContentFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CommonSetContentFrame>(FrameLayer.Middle, setContentDataModel, string.Empty);
		}

		// Token: 0x0600B2C5 RID: 45765 RVA: 0x0027AB4D File Offset: 0x00278F4D
		public static void OnCloseCommonSetContentFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonSetContentFrame>(null, false);
		}

		// Token: 0x0600B2C6 RID: 45766 RVA: 0x0027AB5C File Offset: 0x00278F5C
		public static int GetCounterValueByCounterStr(string counterStr)
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(counterStr);
		}

		// Token: 0x0600B2C7 RID: 45767 RVA: 0x0027AB78 File Offset: 0x00278F78
		public static void PlayReplay(ulong raceId, bool normal = true, UnityAction action = null)
		{
			string filename = raceId.ToString();
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				CommonUtility.ShowNotify(ReplayErrorCode.HAS_TEAM);
				return;
			}
			if (Singleton<ReplayServer>.GetInstance().HasReplay(filename))
			{
				ReplayErrorCode replayErrorCode = Singleton<ReplayServer>.GetInstance().StartReplay(filename, ReplayPlayFrom.MONEY_REWARD, false, false, false);
				if (replayErrorCode == ReplayErrorCode.SUCCEED)
				{
					if (action != null)
					{
						action.Invoke();
					}
					DataManager<SeasonDataManager>.GetInstance().NotifyVideoPlayed(raceId);
				}
				else
				{
					Singleton<ReplayServer>.GetInstance().Clear();
				}
				CommonUtility.ShowNotify(replayErrorCode);
			}
			else if (normal)
			{
				CommonUtility.ShowNotify(ReplayErrorCode.FILE_NOT_FOUND);
			}
			else
			{
				CommonUtility.StartDownloadReplayFile(raceId, action);
			}
		}

		// Token: 0x0600B2C8 RID: 45768 RVA: 0x0027AC18 File Offset: 0x00279018
		private static void ShowNotify(ReplayErrorCode code)
		{
			MoneyRewardsDataManager.ShowErrorNotify(code);
		}

		// Token: 0x0600B2C9 RID: 45769 RVA: 0x0027AC20 File Offset: 0x00279020
		private static void StartDownloadReplayFile(ulong a_raceID, UnityAction action = null)
		{
			if (!DataManager<MoneyRewardsDataManager>.GetInstance().isRcdInQueue(a_raceID))
			{
				DataManager<MoneyRewardsDataManager>.GetInstance().downloadRcd(a_raceID, delegate(ulong raceId)
				{
					string filename = raceId.ToString();
					ReplayErrorCode replayErrorCode = Singleton<ReplayServer>.GetInstance().StartReplay(filename, ReplayPlayFrom.MONEY_REWARD, false, false, false);
					if (replayErrorCode == ReplayErrorCode.SUCCEED)
					{
						if (action != null)
						{
							action.Invoke();
						}
						DataManager<SeasonDataManager>.GetInstance().NotifyVideoPlayed(a_raceID);
					}
					else
					{
						Singleton<ReplayServer>.GetInstance().Clear();
					}
					CommonUtility.ShowNotify(replayErrorCode);
				}, true);
			}
		}

		// Token: 0x0600B2CA RID: 45770 RVA: 0x0027AC74 File Offset: 0x00279074
		public static Vector3 GetMiddlePosition(Vector3 startPosition, Vector3 endPosition)
		{
			float num = (startPosition.x + endPosition.x) / 2f;
			float num2 = (startPosition.y + endPosition.y) / 2f;
			float num3 = (startPosition.z + endPosition.z) / 2f;
			Vector3 result;
			result..ctor(num, num2, num3);
			return result;
		}
	}
}
