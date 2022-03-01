using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016F8 RID: 5880
	internal class PocketJarFrame : ClientFrame
	{
		// Token: 0x0600E6C2 RID: 59074 RVA: 0x003C8BB0 File Offset: 0x003C6FB0
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				if (strParam == null || strParam.Length <= 0)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PocketJarFrame>(FrameLayer.Middle, null, string.Empty);
				}
				else
				{
					string[] array = strParam.Split(new char[]
					{
						'|'
					});
					if (array.Length > 0)
					{
						int num = int.Parse(array[0]);
						EPocketJarType epocketJarType = (EPocketJarType)num;
						if (epocketJarType > EPocketJarType.Invalid && epocketJarType < EPocketJarType.Count)
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<PocketJarFrame>(FrameLayer.Middle, epocketJarType, string.Empty);
						}
						else
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<PocketJarFrame>(FrameLayer.Middle, null, string.Empty);
						}
					}
					else
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<PocketJarFrame>(FrameLayer.Middle, null, string.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("PocketJarFrame.OpenLinkFrame : ==>" + ex.ToString());
			}
		}

		// Token: 0x0600E6C3 RID: 59075 RVA: 0x003C8C90 File Offset: 0x003C7090
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Jar/PocketJar";
		}

		// Token: 0x0600E6C4 RID: 59076 RVA: 0x003C8C97 File Offset: 0x003C7097
		protected sealed override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			this.BindUIEvent();
			this._InitUI();
		}

		// Token: 0x0600E6C5 RID: 59077 RVA: 0x003C8CAB File Offset: 0x003C70AB
		protected sealed override void _OnCloseFrame()
		{
			this.mCurPocketJarType = EPocketJarType.Invalid;
			this._ClearUI();
			this.UnBindUIEvent();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600E6C6 RID: 59078 RVA: 0x003C8CC8 File Offset: 0x003C70C8
		protected override void _bindExUI()
		{
			this.preViewModel = this.mBind.GetCom<Button>("preViewModel");
			this.preViewModel.SafeSetOnClickListener(delegate
			{
				List<PreViewItemData> list = new List<PreViewItemData>();
				if (list == null)
				{
					return;
				}
				if (this.m_magicJarData == null)
				{
					return;
				}
				if (this.m_magicJarData.arrBonusItems == null)
				{
					return;
				}
				List<ItemSimpleData> arrBonusItems = this.m_magicJarData.arrBonusItems;
				for (int i = 0; i < arrBonusItems.Count; i++)
				{
					this.CalcPreviewModelItemIDList(arrBonusItems[i].ItemID, ref list);
				}
				SortedDictionary<int, List<PreViewItemData>> sortedDictionary = new SortedDictionary<int, List<PreViewItemData>>();
				List<PreViewItemData> list2 = new List<PreViewItemData>();
				if (sortedDictionary != null && list2 != null)
				{
					for (int j = 0; j < list.Count; j++)
					{
						PreViewItemData preViewItemData = list[j];
						if (preViewItemData != null)
						{
							int rank = this.GetRank(preViewItemData.itemId);
							if (!sortedDictionary.ContainsKey(rank))
							{
								sortedDictionary[rank] = new List<PreViewItemData>();
							}
							sortedDictionary[rank].Add(preViewItemData);
						}
					}
					foreach (KeyValuePair<int, List<PreViewItemData>> keyValuePair in sortedDictionary)
					{
						List<PreViewItemData> value = keyValuePair.Value;
						if (value != null)
						{
							list2.AddRange(value);
						}
					}
					list = list2;
				}
				int num = 0;
				Dictionary<long, List<PreViewItemData>> dictionary = new Dictionary<long, List<PreViewItemData>>();
				if (dictionary != null)
				{
					for (int k = 0; k < list.Count; k++)
					{
						PreViewItemData preViewItemData2 = list[k];
						if (preViewItemData2 != null)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(preViewItemData2.itemId, 100, 0);
							if (itemData != null)
							{
								if (itemData.TableData != null)
								{
									long num2 = PocketJarFrame.HashToLong(itemData.TableData.ResID, itemData.TableData.EquipPropID);
									if (num2 == 0L)
									{
										num2 = (long)num++;
									}
									if (!dictionary.ContainsKey(num2))
									{
										dictionary[num2] = new List<PreViewItemData>();
									}
									dictionary[num2].Add(preViewItemData2);
								}
							}
						}
					}
					list.Clear();
					foreach (KeyValuePair<long, List<PreViewItemData>> keyValuePair2 in dictionary)
					{
						List<PreViewItemData> value2 = keyValuePair2.Value;
						if (value2 != null)
						{
							int num3 = -1;
							int num4 = 0;
							for (int l = 0; l < value2.Count; l++)
							{
								PreViewItemData preViewItemData3 = value2[l];
								if (preViewItemData3 != null)
								{
									ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(preViewItemData3.itemId, 100, 0);
									if (itemData2 != null)
									{
										if (itemData2.TableData != null)
										{
											if (itemData2.TableData.TimeLeft == 0)
											{
												num3 = l;
												break;
											}
											if (itemData2.TableData.TimeLeft > num4)
											{
												num3 = l;
											}
										}
									}
								}
							}
							if (num3 >= 0 && num3 < value2.Count)
							{
								PreViewItemData item = value2[num3];
								list.Add(item);
							}
						}
					}
				}
				PreViewDataModel preViewDataModel = new PreViewDataModel();
				if (preViewDataModel == null)
				{
					return;
				}
				preViewDataModel.isCreatItem = true;
				preViewDataModel.preViewItemList = list;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PreviewModelFrame>(FrameLayer.Middle, preViewDataModel, string.Empty);
			});
			this.shopRedPoint = this.mBind.GetGameObject("ShopRedPoint");
		}

		// Token: 0x0600E6C7 RID: 59079 RVA: 0x003C8D18 File Offset: 0x003C7118
		protected override void _unbindExUI()
		{
			this.preViewModel = null;
			this.shopRedPoint = null;
		}

		// Token: 0x0600E6C8 RID: 59080 RVA: 0x003C8D28 File Offset: 0x003C7128
		private static long HashToLong(int n1, int n2)
		{
			long num = (long)n1;
			num <<= 32;
			return num + (long)n2;
		}

		// Token: 0x0600E6C9 RID: 59081 RVA: 0x003C8D44 File Offset: 0x003C7144
		private int GetRank(int itemID)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemID, 100, 0);
			if (itemData == null)
			{
				return -1;
			}
			if (itemData.SubType == 92)
			{
				return 0;
			}
			if (itemData.SubType == 11)
			{
				return 1;
			}
			if (itemData.Type == ItemTable.eType.FUCKTITTLE)
			{
				return 2;
			}
			if (itemData.SubType == 44)
			{
				return 3;
			}
			return -1;
		}

		// Token: 0x0600E6CA RID: 59082 RVA: 0x003C8DA0 File Offset: 0x003C71A0
		private void CalcPreviewModelItemIDList(int itemID, ref List<PreViewItemData> preViewIDList)
		{
			if (preViewIDList == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemID, 100, 0);
			if (itemData == null)
			{
				return;
			}
			List<GiftTable> gifts = itemData.GetGifts();
			if (gifts != null)
			{
				for (int i = 0; i < gifts.Count; i++)
				{
					this.CalcPreviewModelItemIDList(gifts[i].ItemID, ref preViewIDList);
				}
			}
			else if (this.CanPreviewModel(itemID))
			{
				preViewIDList.Add(new PreViewItemData
				{
					itemId = itemID
				});
			}
		}

		// Token: 0x0600E6CB RID: 59083 RVA: 0x003C8E24 File Offset: 0x003C7224
		private bool CanPreviewModel(int itemID)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemID, 100, 0);
			return itemData != null && (itemData.SubType == 92 || itemData.SubType == 11 || itemData.Type == ItemTable.eType.FUCKTITTLE || itemData.SubType == 44);
		}

		// Token: 0x0600E6CC RID: 59084 RVA: 0x003C8E7C File Offset: 0x003C727C
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateJar));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnUpdateJar));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JarOpenRecordUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateOpenRecord));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarScoreChanged, new ClientEventSystem.UIEventHandler(this._OnMagicJarScoreChanged));
		}

		// Token: 0x0600E6CD RID: 59085 RVA: 0x003C8EF0 File Offset: 0x003C72F0
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateJar));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnUpdateJar));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JarOpenRecordUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateOpenRecord));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarScoreChanged, new ClientEventSystem.UIEventHandler(this._OnMagicJarScoreChanged));
		}

		// Token: 0x0600E6CE RID: 59086 RVA: 0x003C8F64 File Offset: 0x003C7364
		private void BindUIEvent()
		{
			if (this.m_togGoldJar != null)
			{
				this.m_togGoldJar.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleGoldClick));
			}
			if (this.m_togMagicJar != null)
			{
				this.m_togMagicJar.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleMagicClick));
			}
			if (this.m_togMagic_Jar_Lv55 != null)
			{
				this.m_togMagic_Jar_Lv55.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleMagicJarLev55Click));
			}
		}

		// Token: 0x0600E6CF RID: 59087 RVA: 0x003C8FF8 File Offset: 0x003C73F8
		private void UnBindUIEvent()
		{
			if (this.m_togGoldJar != null)
			{
				this.m_togGoldJar.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleGoldClick));
			}
			if (this.m_togMagicJar != null)
			{
				this.m_togMagicJar.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleMagicClick));
			}
			if (this.m_togMagic_Jar_Lv55 != null)
			{
				this.m_togMagic_Jar_Lv55.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleMagicJarLev55Click));
			}
		}

		// Token: 0x0600E6D0 RID: 59088 RVA: 0x003C908C File Offset: 0x003C748C
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600E6D1 RID: 59089 RVA: 0x003C908F File Offset: 0x003C748F
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			this._UpdateFreeCD(this.m_magicJarData, timeElapsed);
		}

		// Token: 0x0600E6D2 RID: 59090 RVA: 0x003C909E File Offset: 0x003C749E
		private void OnToggleGoldClick(bool value)
		{
			this.mCurPocketJarType = EPocketJarType.Gold;
			if (value)
			{
				if (this.m_currGoldJarData != null)
				{
					DataManager<JarDataManager>.GetInstance().RequestJarBuyRecord(this.m_currGoldJarData.nID);
				}
				this.m_comMagicTicket.CustomActive(false);
			}
		}

		// Token: 0x0600E6D3 RID: 59091 RVA: 0x003C90DC File Offset: 0x003C74DC
		private void OnToggleMagicClick(bool value)
		{
			this.mCurPocketJarType = EPocketJarType.Magic;
			this._InitMagicJarUI();
			if (value)
			{
				if (this.m_magicJarData != null)
				{
					DataManager<JarDataManager>.GetInstance().RequestJarBuyRecord(this.m_magicJarData.nID);
				}
				if (this.m_comMagicTicket != null)
				{
					this.m_comMagicTicket.CustomActive(true);
				}
			}
		}

		// Token: 0x0600E6D4 RID: 59092 RVA: 0x003C9139 File Offset: 0x003C7539
		private void OnToggleMagicJarLev55Click(bool value)
		{
			this.mCurPocketJarType = EPocketJarType.Magic_Lv55;
			this._InitMagicJarUI();
			if (value)
			{
				DataManager<JarDataManager>.GetInstance().RequestJarBuyRecord(this.m_magicJarData.nID);
				this.m_comMagicTicket.CustomActive(false);
			}
		}

		// Token: 0x0600E6D5 RID: 59093 RVA: 0x003C9170 File Offset: 0x003C7570
		private void _InitUI()
		{
			this.m_togMagic_Jar_Lv55.gameObject.CustomActive(Utility.IsUnLockFunc(68));
			this._InitGoldJarUI();
			this._InitRecordList();
			this._UpdateRedPoint();
			if (this.userData != null)
			{
				this.mCurPocketJarType = (EPocketJarType)this.userData;
				if (this.mCurPocketJarType == EPocketJarType.Gold)
				{
					this.m_togGoldJar.isOn = true;
				}
				else if (this.mCurPocketJarType == EPocketJarType.Magic)
				{
					this.m_togMagicJar.isOn = true;
				}
				else if (this.mCurPocketJarType == EPocketJarType.Magic_Lv55)
				{
					this.m_togMagic_Jar_Lv55.isOn = true;
				}
			}
			else if (Utility.IsUnLockFunc(68))
			{
				this.m_togMagic_Jar_Lv55.isOn = true;
			}
			else
			{
				this.m_togMagicJar.isOn = true;
			}
			this.shopRedPoint.CustomActive(DataManager<JarDataManager>.GetInstance().IsRedPointShow());
		}

		// Token: 0x0600E6D6 RID: 59094 RVA: 0x003C9256 File Offset: 0x003C7656
		private void _ClearUI()
		{
			this._ClearGoldJarUI();
			this._ClearMagicJarUI();
			this._ClearRecord();
		}

		// Token: 0x0600E6D7 RID: 59095 RVA: 0x003C926A File Offset: 0x003C766A
		private void _InitRecordList()
		{
			if (this.m_comRecordList != null)
			{
				this.m_comRecordList.Initialize();
				this.m_comRecordList.onItemVisiable = delegate(ComUIListElementScript var)
				{
					if (this.m_recordData != null && var.m_index >= 0 && var.m_index < this.m_recordData.records.Length)
					{
						int num = this.m_recordData.records.Length - var.m_index - 1;
						OpenJarRecord openJarRecord = this.m_recordData.records[num];
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID((int)openJarRecord.itemId);
						if (commonItemTableDataByID != null)
						{
							string arg = string.Format(" {{I 0 {0} 0}}", openJarRecord.itemId);
							var.GetComponent<LinkParse>().SetText(TR.Value("jar_record", openJarRecord.name, arg, openJarRecord.num), true);
							return;
						}
					}
				};
			}
		}

		// Token: 0x0600E6D8 RID: 59096 RVA: 0x003C92A0 File Offset: 0x003C76A0
		private void _UpdateRedPoint()
		{
			GameObject gameObject = Utility.FindGameObject(this.m_togMagicJar.gameObject, "RedPoint", true);
			if (gameObject != null)
			{
				gameObject.CustomActive(DataManager<JarDataManager>.GetInstance().CheckRedPoint(JarBonus.eType.MagicJar));
			}
			GameObject gameObject2 = Utility.FindGameObject(this.m_togGoldJar.gameObject, "RedPoint", true);
			if (gameObject2 != null)
			{
				gameObject2.CustomActive(DataManager<JarDataManager>.GetInstance().CheckRedPoint(JarBonus.eType.GoldJar));
			}
			GameObject gameObject3 = Utility.FindGameObject(this.m_togMagic_Jar_Lv55.gameObject, "RedPoint", true);
			if (gameObject3 != null)
			{
				gameObject3.CustomActive(DataManager<JarDataManager>.GetInstance().CheckRedPoint(JarBonus.eType.MagicJar_Lv55));
			}
		}

		// Token: 0x0600E6D9 RID: 59097 RVA: 0x003C934C File Offset: 0x003C774C
		private void _UpdateRecord()
		{
			if (this.m_recordData != null && (((this.m_togMagicJar.isOn || this.m_togMagic_Jar_Lv55.isOn) && (ulong)this.m_recordData.jarId == (ulong)((long)this.m_magicJarData.nID)) || (this.m_togGoldJar.isOn && (ulong)this.m_recordData.jarId == (ulong)((long)this.m_currGoldJarData.nID))))
			{
				this.m_comRecordList.SetElementAmount(this.m_recordData.records.Length);
				this.m_comRecordList.EnsureElementVisable(0);
				return;
			}
			this.m_comRecordList.SetElementAmount(0);
		}

		// Token: 0x0600E6DA RID: 59098 RVA: 0x003C93FF File Offset: 0x003C77FF
		private void _ClearRecord()
		{
			if (this.m_comRecordList != null)
			{
				this.m_comRecordList.SetElementAmount(0);
			}
			this.m_recordData = null;
		}

		// Token: 0x0600E6DB RID: 59099 RVA: 0x003C9425 File Offset: 0x003C7825
		private void _OnUpdateJar(UIEvent a_event)
		{
			this._UpdateGoldGoods(this.m_currGoldJarData);
			this._UpdateMagicJarGoods(this.m_magicJarData);
			this._UpdateRedPoint();
		}

		// Token: 0x0600E6DC RID: 59100 RVA: 0x003C9445 File Offset: 0x003C7845
		private void _OnUpdateOpenRecord(UIEvent a_event)
		{
			this._ClearRecord();
			this.m_recordData = (a_event.Param1 as WorldOpenJarRecordRes);
			this._UpdateRecord();
		}

		// Token: 0x0600E6DD RID: 59101 RVA: 0x003C9464 File Offset: 0x003C7864
		private void _OnMagicJarScoreChanged(UIEvent a_event)
		{
			this.m_labMagicScore.text = DataManager<PlayerBaseData>.GetInstance().MagicJarScore.ToString();
		}

		// Token: 0x0600E6DE RID: 59102 RVA: 0x003C9494 File Offset: 0x003C7894
		[UIEventHandle("BG/Title/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<PocketJarFrame>(this, false);
		}

		// Token: 0x0600E6DF RID: 59103 RVA: 0x003C94A4 File Offset: 0x003C78A4
		protected void _InitGoldJarUI()
		{
			DataManager<JarDataManager>.GetInstance().RequestQuaryJarShopSocre();
			this.m_objGoldLevelTabTemplate.SetActive(false);
			this.m_objGoldLevelTabTemplate.transform.SetParent(this.frame.transform, false);
			this.m_comGoldItemList.Initialize();
			this.m_comGoldItemList.onBindItem = ((GameObject var) => base.CreateComItem(Utility.FindGameObject(var, "Item", true)));
			this.m_comGoldItemList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_currGoldJarData != null)
				{
					List<ItemSimpleData> arrBonusItems = this.m_currGoldJarData.arrBonusItems;
					if (var.m_index >= 0 && var.m_index < arrBonusItems.Count)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(arrBonusItems[var.m_index].ItemID, 100, 0);
						if (itemData != null)
						{
							itemData.Count = arrBonusItems[var.m_index].Count;
							ComItem comItem = var.gameObjectBindScript as ComItem;
							comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
								Utility.DoStartFrameOperation("PocketJarFrame", string.Format("GoldenPot_ItemId_{0}", var2.TableID));
							});
							Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = itemData.GetColorName(string.Empty, false);
						}
					}
				}
			};
			this._ClearGoldLevelTypes();
			this._ClearGoldGoods();
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._InitGoldLevelTypes(tableItem.SuitArmorType);
			}
			else
			{
				Logger.LogErrorFormat("袖珍罐：不存在职业id{0}", new object[]
				{
					DataManager<PlayerBaseData>.GetInstance().JobTableID
				});
			}
		}

		// Token: 0x0600E6E0 RID: 59104 RVA: 0x003C9580 File Offset: 0x003C7980
		protected void _ClearGoldJarUI()
		{
			this.m_currGoldJarData = null;
			this.m_arrLevelTypeObjs.Clear();
			this.m_arrLevelRedPoints.Clear();
		}

		// Token: 0x0600E6E1 RID: 59105 RVA: 0x003C95A0 File Offset: 0x003C79A0
		private void _InitGoldLevelTypes(int a_nSubType)
		{
			if (this.m_arrLevelRedPoints != null)
			{
				this.m_arrLevelRedPoints.Clear();
			}
			List<Toggle> list = new List<Toggle>();
			bool isToggleInited = false;
			List<JarTreeNode> goldJarLevels = DataManager<JarDataManager>.GetInstance().GetGoldJarLevels(a_nSubType);
			if (goldJarLevels != null)
			{
				for (int i = 0; i < goldJarLevels.Count; i++)
				{
					int nLevelType = goldJarLevels[i].nKey;
					GameObject objLevelType = null;
					if (this.m_arrLevelTypeObjs == null)
					{
						this.m_arrLevelTypeObjs = new List<GameObject>();
					}
					if (i < this.m_arrLevelTypeObjs.Count)
					{
						objLevelType = this.m_arrLevelTypeObjs[i];
					}
					else if (this.m_objGoldLevelTabTemplate != null && this.m_objGoldLevelTabRoot != null)
					{
						objLevelType = Object.Instantiate<GameObject>(this.m_objGoldLevelTabTemplate);
						objLevelType.transform.SetParent(this.m_objGoldLevelTabRoot.transform, false);
						this.m_arrLevelTypeObjs.Add(objLevelType);
					}
					if (objLevelType != null)
					{
						objLevelType.SetActive(true);
						Toggle component = objLevelType.GetComponent<Toggle>();
						if (component != null)
						{
							component.onValueChanged.RemoveAllListeners();
							component.onValueChanged.AddListener(delegate(bool var)
							{
								if (isToggleInited && var)
								{
									this.m_currGoldJarData = DataManager<JarDataManager>.GetInstance().GetGoldJarData(a_nSubType, nLevelType);
									this._ClearGoldGoods();
									this._InitGoldGoods(this.m_currGoldJarData);
									if (this.m_togGoldJar != null && this.m_togGoldJar.isOn && this.m_currGoldJarData != null)
									{
										DataManager<JarDataManager>.GetInstance().RequestJarBuyRecord(this.m_currGoldJarData.nID);
									}
									Utility.DoStartFrameOperation("PocketJarFrame", string.Format("GoldenPot_Level_{0}", TR.Value("goldjar_level_type", nLevelType)));
								}
							});
							list.Add(component);
						}
					}
					string text = TR.Value("goldjar_level_type", nLevelType);
					Text componetInChild = Utility.GetComponetInChild<Text>(objLevelType, "Checkmark/Label");
					if (componetInChild != null)
					{
						componetInChild.text = text;
					}
					Text componetInChild2 = Utility.GetComponetInChild<Text>(objLevelType, "Background/Label");
					if (componetInChild2 != null)
					{
						componetInChild2.text = text;
					}
					if (this.m_arrLevelRedPoints != null)
					{
						this.m_arrLevelRedPoints.Add(delegate
						{
							GameObject gameObject = Utility.FindGameObject(objLevelType, "RedPoint", true);
							if (gameObject != null)
							{
								gameObject.SetActive(DataManager<JarDataManager>.GetInstance().CheckGoldJarLevelRedPoint(a_nSubType, nLevelType));
							}
						});
					}
				}
			}
			if (this.m_arrLevelRedPoints != null)
			{
				for (int j = 0; j < this.m_arrLevelRedPoints.Count; j++)
				{
					if (this.m_arrLevelRedPoints[j] != null)
					{
						this.m_arrLevelRedPoints[j]();
					}
				}
			}
			isToggleInited = true;
			int num = this._GetLevelMatchedJarIndex(goldJarLevels);
			if (goldJarLevels != null && num >= 0 && num < goldJarLevels.Count && num < list.Count)
			{
				list[num].isOn = true;
			}
			else if (list.Count > 0)
			{
				list[0].isOn = true;
			}
		}

		// Token: 0x0600E6E2 RID: 59106 RVA: 0x003C9888 File Offset: 0x003C7C88
		private int _GetLevelMatchedJarIndex(List<JarTreeNode> a_arrLevelTypes)
		{
			if (a_arrLevelTypes == null)
			{
				return -1;
			}
			int num = 0;
			int result = -1;
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			for (int i = 0; i < a_arrLevelTypes.Count; i++)
			{
				int nKey = a_arrLevelTypes[i].nKey;
				JarData jarData = a_arrLevelTypes[i].value as JarData;
				if (nKey <= level && nKey > num)
				{
					num = nKey;
					result = i;
				}
			}
			return result;
		}

		// Token: 0x0600E6E3 RID: 59107 RVA: 0x003C98FC File Offset: 0x003C7CFC
		private void _ClearGoldLevelTypes()
		{
			for (int i = 0; i < this.m_arrLevelTypeObjs.Count; i++)
			{
				this.m_arrLevelTypeObjs[i].SetActive(false);
			}
		}

		// Token: 0x0600E6E4 RID: 59108 RVA: 0x003C9938 File Offset: 0x003C7D38
		private void _InitGoldGoods(JarData a_data)
		{
			if (a_data == null)
			{
				return;
			}
			this.m_comGoldItemList.SetElementAmount(a_data.arrBonusItems.Count);
			ETCImageLoader.LoadSprite(ref this.m_imgGoldJarIcon, a_data.strJarImagePath, true);
			this.m_labGoldJarName.text = a_data.strName;
			ComItem comItem = base.CreateComItem(this.m_objGoldBuyItemRoot);
			ItemData itemData = a_data.arrBuyItems[0];
			comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
			this.m_labGoldBuyItemTitle.text = TR.Value("goldjar_buy_item_title", itemData.GetColorName(string.Empty, false));
			this.m_labGoldBuyItemDesc.text = TR.Value("goldjar_buy_desc");
			for (int i = 0; i < a_data.arrBuyInfos.Count; i++)
			{
				GameObject gameObject = this.m_objGoldBuyFuncRoot.transform.GetChild(i).gameObject;
				gameObject.SetActive(true);
				JarBuyInfo buyInfo = a_data.arrBuyInfos[i];
				GameObject gameObject2 = Utility.FindGameObject(gameObject, "RedPoint", true);
				gameObject2.SetActive(false);
				Button component = gameObject.GetComponent<Button>();
				component.onClick.RemoveAllListeners();
				component.onClick.AddListener(delegate()
				{
					ShowItemsFrame.bSkipExplode = false;
					CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
					for (int k = 0; k < buyInfo.arrCosts.Count; k++)
					{
						JarBuyCost jarBuyCost2 = buyInfo.arrCosts[k];
						int realCostCount2 = jarBuyCost2.GetRealCostCount(buyInfo.nBuyCount);
						if (realCostCount2 <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost2.item.TableID, true))
						{
							costInfo.nMoneyID = jarBuyCost2.item.TableID;
							costInfo.nCount = realCostCount2;
							break;
						}
						if (k == buyInfo.arrCosts.Count - 1)
						{
							costInfo.nMoneyID = jarBuyCost2.item.TableID;
							costInfo.nCount = realCostCount2;
						}
					}
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
					{
						DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_data, buyInfo, 0U, 0U);
					}, "common_money_cost", null);
					Utility.DoStartFrameOperation("PocketJarFrame", string.Format("GoldenPot_Buy{0}", buyInfo.nBuyCount));
				});
				Utility.GetComponetInChild<Text>(gameObject, "Time").text = TR.Value("magicjar_buy_times", buyInfo.nBuyCount);
				Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
				Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
				for (int j = 0; j < buyInfo.arrCosts.Count; j++)
				{
					JarBuyCost jarBuyCost = buyInfo.arrCosts[j];
					int realCostCount = jarBuyCost.GetRealCostCount(buyInfo.nBuyCount);
					if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
					{
						componetInChild.text = realCostCount.ToString();
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						break;
					}
					if (j == buyInfo.arrCosts.Count - 1)
					{
						componetInChild.text = TR.Value("color_red", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
					}
				}
			}
		}

		// Token: 0x0600E6E5 RID: 59109 RVA: 0x003C9BF8 File Offset: 0x003C7FF8
		private void _ClearGoldGoods()
		{
			this.m_comGoldItemList.SetElementAmount(0);
		}

		// Token: 0x0600E6E6 RID: 59110 RVA: 0x003C9C08 File Offset: 0x003C8008
		private void _UpdateGoldGoods(JarData a_data)
		{
			for (int i = 0; i < a_data.arrBuyInfos.Count; i++)
			{
				GameObject gameObject = this.m_objGoldBuyFuncRoot.transform.GetChild(i).gameObject;
				gameObject.SetActive(true);
				JarBuyInfo jarBuyInfo = a_data.arrBuyInfos[i];
				GameObject gameObject2 = Utility.FindGameObject(gameObject, "RedPoint", true);
				gameObject2.SetActive(DataManager<JarDataManager>.GetInstance().CheckRedPoint(a_data, jarBuyInfo));
				Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
				Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
				for (int j = 0; j < jarBuyInfo.arrCosts.Count; j++)
				{
					JarBuyCost jarBuyCost = jarBuyInfo.arrCosts[j];
					int realCostCount = jarBuyCost.GetRealCostCount(jarBuyInfo.nBuyCount);
					if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
					{
						componetInChild.text = realCostCount.ToString();
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						break;
					}
					if (j == jarBuyInfo.arrCosts.Count - 1)
					{
						componetInChild.text = TR.Value("color_red", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
					}
				}
			}
			for (int k = 0; k < this.m_arrLevelRedPoints.Count; k++)
			{
				this.m_arrLevelRedPoints[k]();
			}
		}

		// Token: 0x17001CB8 RID: 7352
		// (get) Token: 0x0600E6E7 RID: 59111 RVA: 0x003C9D92 File Offset: 0x003C8192
		private JarData m_magicJarData
		{
			get
			{
				if (this.mCurPocketJarType == EPocketJarType.Magic_Lv55)
				{
					return DataManager<JarDataManager>.GetInstance().GetMagicJarData_Lv55();
				}
				return DataManager<JarDataManager>.GetInstance().GetMagicJarData();
			}
		}

		// Token: 0x0600E6E8 RID: 59112 RVA: 0x003C9DB8 File Offset: 0x003C81B8
		private void _InitMagicJarUI()
		{
			this.m_comMagicItemList.Initialize();
			this.m_comMagicItemList.onBindItem = ((GameObject var) => base.CreateComItem(Utility.FindGameObject(var, "Item", true)));
			this.m_comMagicItemList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_magicJarData != null)
				{
					List<ItemSimpleData> arrBonusItems = this.m_magicJarData.arrBonusItems;
					if (var.m_index >= 0 && var.m_index < arrBonusItems.Count)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(arrBonusItems[var.m_index].ItemID, 100, 0);
						if (itemData != null)
						{
							itemData.Count = arrBonusItems[var.m_index].Count;
							ComItem comItem = var.gameObjectBindScript as ComItem;
							comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
								Utility.DoStartFrameOperation("PocketJarFrame", string.Format("MagicPot_ItemId_{0}", var2.TableID));
							});
							Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = itemData.GetColorName(string.Empty, false);
						}
					}
				}
			};
			this.m_labMagicScore.text = DataManager<PlayerBaseData>.GetInstance().MagicJarScore.ToString();
			if (this.mCurPocketJarType == EPocketJarType.Magic_Lv55)
			{
				this.m_labMagicScoreDesc.text = TR.Value("MagicScoreDesc_Lv55");
			}
			else
			{
				this.m_labMagicScoreDesc.text = TR.Value("MagicScoreDesc");
			}
			this._InitMagicJarGoods(this.m_magicJarData);
		}

		// Token: 0x0600E6E9 RID: 59113 RVA: 0x003C9E68 File Offset: 0x003C8268
		private void _ClearMagicJarUI()
		{
		}

		// Token: 0x0600E6EA RID: 59114 RVA: 0x003C9E6C File Offset: 0x003C826C
		private void _InitMagicJarGoods(JarData a_data)
		{
			if (a_data == null)
			{
				return;
			}
			this.m_comMagicItemList.SetElementAmount(a_data.arrBonusItems.Count);
			ETCImageLoader.LoadSprite(ref this.m_imgMagicJarIcon, a_data.strJarImagePath, true);
			this.m_labMagicJarName.text = a_data.strName;
			ComItem comItem = base.CreateComItem(this.m_objMagicBuyItemRoot);
			ItemData itemData = a_data.arrBuyItems[0];
			comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
			this.m_labMagicBuyItemTitle.text = TR.Value("magicjar_buy_item_title", itemData.GetColorName(string.Empty, false));
			if (this.mCurPocketJarType == EPocketJarType.Magic_Lv55)
			{
				this.m_labMagicBuyItemDesc.text = TR.Value("magicjar_Lv55_buy_desc");
			}
			else
			{
				this.m_labMagicBuyItemDesc.text = TR.Value("magicjar_buy_desc");
			}
			for (int i = 0; i < this.m_objMagicBuyRoot.transform.childCount; i++)
			{
				this.m_objMagicBuyRoot.transform.GetChild(i).gameObject.SetActive(false);
			}
			for (int j = 0; j < a_data.arrBuyInfos.Count; j++)
			{
				GameObject gameObject = this.m_objMagicBuyRoot.transform.GetChild(j).gameObject;
				gameObject.SetActive(true);
				JarBuyInfo buyInfo = a_data.arrBuyInfos[j];
				Button component = gameObject.GetComponent<Button>();
				component.onClick.RemoveAllListeners();
				component.onClick.AddListener(delegate()
				{
					ShowItemsFrame.bSkipExplode = false;
					if (buyInfo.nFreeCount > 0)
					{
						DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_data, buyInfo, 0U, 0U);
						return;
					}
					int discountItemCount = 0;
					int certificateItemCount = 0;
					if (buyInfo.nBuyCount == 10 && this.mCurPocketJarType == EPocketJarType.Magic)
					{
						discountItemCount = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountCount();
						certificateItemCount = DataManager<JarDataManager>.GetInstance().GetMagicPotCredentialsCount(buyInfo);
					}
					CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
					for (int l = 0; l < buyInfo.arrCosts.Count; l++)
					{
						JarBuyCost jarBuyCost2 = buyInfo.arrCosts[l];
						int realCostCount2 = jarBuyCost2.GetRealCostCount(buyInfo.nBuyCount);
						if (buyInfo.nBuyCount == 10 && this.mCurPocketJarType == EPocketJarType.Magic && jarBuyCost2.item.Type == ItemTable.eType.INCOME && discountItemCount > 0 && certificateItemCount < 10)
						{
							ItemTable magicPotDiscountTableData3 = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData();
							int nCount = realCostCount2 * magicPotDiscountTableData3.DiscountCouponProp / 100;
							costInfo.nMoneyID = jarBuyCost2.item.TableID;
							costInfo.nCount = nCount;
							break;
						}
						if (realCostCount2 <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost2.item.TableID, true))
						{
							costInfo.nMoneyID = jarBuyCost2.item.TableID;
							costInfo.nCount = realCostCount2;
							break;
						}
						if (l == buyInfo.arrCosts.Count - 1)
						{
							costInfo.nMoneyID = jarBuyCost2.item.TableID;
							costInfo.nCount = realCostCount2;
						}
					}
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
					{
						if (buyInfo.nBuyCount == 10 && this.mCurPocketJarType == EPocketJarType.Magic && discountItemCount > 0 && certificateItemCount < 10)
						{
							int id = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData().ID;
							DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_data, buyInfo, 0U, (uint)id);
							return;
						}
						DataManager<JarDataManager>.GetInstance().RequestBuyJar(a_data, buyInfo, 0U, 0U);
					}, "common_money_cost", null);
					Utility.DoStartFrameOperation("PocketJarFrame", string.Format("MagicPot_Buy{0}", buyInfo.nBuyCount));
				});
				Utility.GetComponetInChild<Text>(gameObject, "Time").text = TR.Value("magicjar_buy_times", buyInfo.nBuyCount);
				Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
				Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
				Image image = null;
				GameObject gameObject2 = null;
				Text text = null;
				int num = 0;
				int num2 = 0;
				if (buyInfo.nBuyCount == 10 && this.mCurPocketJarType == EPocketJarType.Magic)
				{
					GameObject gameObject3 = Utility.FindGameObject(gameObject, "DiscountRoot", true);
					image = Utility.GetComponetInChild<Image>(gameObject, "DiscountRoot/Icon");
					Text componetInChild3 = Utility.GetComponetInChild<Text>(gameObject, "DiscountRoot/Count");
					gameObject2 = Utility.FindGameObject(gameObject, "Price/Line", true);
					text = Utility.GetComponetInChild<Text>(gameObject, "Price/DiscountPrice");
					if (gameObject2 != null)
					{
						gameObject2.CustomActive(false);
					}
					if (gameObject3 != null)
					{
						gameObject3.CustomActive(false);
					}
					if (text != null)
					{
						text.CustomActive(false);
					}
					num = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountCount();
					num2 = DataManager<JarDataManager>.GetInstance().GetMagicPotCredentialsCount(buyInfo);
					if (num > 0 && num2 < 10)
					{
						if (gameObject3 != null)
						{
							gameObject3.CustomActive(true);
						}
						ItemTable magicPotDiscountTableData = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData();
						if (image != null)
						{
							ETCImageLoader.LoadSprite(ref image, magicPotDiscountTableData.Icon, true);
						}
						if (componetInChild3 != null)
						{
							componetInChild3.text = string.Format("1/{0}", num);
						}
					}
				}
				for (int k = 0; k < buyInfo.arrCosts.Count; k++)
				{
					JarBuyCost jarBuyCost = buyInfo.arrCosts[k];
					int realCostCount = jarBuyCost.GetRealCostCount(buyInfo.nBuyCount);
					if (buyInfo.nBuyCount == 10 && this.mCurPocketJarType == EPocketJarType.Magic && jarBuyCost.item.Type == ItemTable.eType.INCOME && num > 0 && num2 < 10)
					{
						ItemTable magicPotDiscountTableData2 = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData();
						int num3 = realCostCount * magicPotDiscountTableData2.DiscountCouponProp / 100;
						if (gameObject2 != null)
						{
							gameObject2.CustomActive(true);
						}
						if (text != null)
						{
							text.CustomActive(true);
						}
						if (num3 <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
						{
							componetInChild.text = TR.Value("color_yellow", realCostCount);
							if (text != null)
							{
								text.text = TR.Value("color_white", num3);
							}
							ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						}
						else
						{
							componetInChild.text = TR.Value("color_yellow", realCostCount);
							ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
							if (text != null)
							{
								text.text = TR.Value("color_red", num3);
							}
						}
						break;
					}
					if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
					{
						componetInChild.text = TR.Value("color_white", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						break;
					}
					if (k == buyInfo.arrCosts.Count - 1)
					{
						componetInChild.text = TR.Value("color_red", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
					}
				}
				this._SetupFreeCD(gameObject, buyInfo);
				if (buyInfo.arrCosts.Count > 0)
				{
					this.m_comMagicTicket.SetData(ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue, buyInfo.arrCosts[0].item.TableID);
				}
			}
		}

		// Token: 0x0600E6EB RID: 59115 RVA: 0x003CA478 File Offset: 0x003C8878
		private void _UpdateMagicJarGoods(JarData a_data)
		{
			for (int i = 0; i < a_data.arrBuyInfos.Count; i++)
			{
				GameObject gameObject = this.m_objMagicBuyRoot.transform.GetChild(i).gameObject;
				gameObject.SetActive(true);
				JarBuyInfo jarBuyInfo = a_data.arrBuyInfos[i];
				Utility.GetComponetInChild<Text>(gameObject, "Time").text = TR.Value("magicjar_buy_times", jarBuyInfo.nBuyCount);
				Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
				Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
				Image image = null;
				GameObject gameObject2 = null;
				Text text = null;
				int num = 0;
				int num2 = 0;
				if (jarBuyInfo.nBuyCount == 10 && this.mCurPocketJarType == EPocketJarType.Magic)
				{
					GameObject gameObject3 = Utility.FindGameObject(gameObject, "DiscountRoot", true);
					image = Utility.GetComponetInChild<Image>(gameObject, "DiscountRoot/Icon");
					Text componetInChild3 = Utility.GetComponetInChild<Text>(gameObject, "DiscountRoot/Count");
					gameObject2 = Utility.FindGameObject(gameObject, "Price/Line", true);
					text = Utility.GetComponetInChild<Text>(gameObject, "Price/DiscountPrice");
					if (gameObject2 != null)
					{
						gameObject2.CustomActive(false);
					}
					if (gameObject3 != null)
					{
						gameObject3.CustomActive(false);
					}
					if (text != null)
					{
						text.CustomActive(false);
					}
					num = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountCount();
					num2 = DataManager<JarDataManager>.GetInstance().GetMagicPotCredentialsCount(jarBuyInfo);
					if (num > 0 && num2 < 10)
					{
						if (gameObject3 != null)
						{
							gameObject3.CustomActive(true);
						}
						ItemTable magicPotDiscountTableData = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData();
						if (image != null)
						{
							ETCImageLoader.LoadSprite(ref image, magicPotDiscountTableData.Icon, true);
						}
						if (componetInChild3 != null)
						{
							componetInChild3.text = string.Format("1/{0}", num);
						}
					}
				}
				for (int j = 0; j < jarBuyInfo.arrCosts.Count; j++)
				{
					JarBuyCost jarBuyCost = jarBuyInfo.arrCosts[j];
					int realCostCount = jarBuyCost.GetRealCostCount(jarBuyInfo.nBuyCount);
					if (jarBuyInfo.nBuyCount == 10 && this.mCurPocketJarType == EPocketJarType.Magic && jarBuyCost.item.Type == ItemTable.eType.INCOME && num > 0 && num2 < 10)
					{
						ItemTable magicPotDiscountTableData2 = DataManager<JarDataManager>.GetInstance().GetMagicPotDiscountTableData();
						int num3 = realCostCount * magicPotDiscountTableData2.DiscountCouponProp / 100;
						if (gameObject2 != null)
						{
							gameObject2.CustomActive(true);
						}
						if (text != null)
						{
							text.CustomActive(true);
						}
						if (num3 <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
						{
							componetInChild.text = TR.Value("color_yellow", realCostCount);
							if (text != null)
							{
								text.text = TR.Value("color_white", num3);
							}
							ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						}
						else
						{
							componetInChild.text = TR.Value("color_yellow", realCostCount);
							ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
							if (text != null)
							{
								text.text = TR.Value("color_red", num3);
							}
						}
						break;
					}
					if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
					{
						componetInChild.text = TR.Value("color_white", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						break;
					}
					if (j == jarBuyInfo.arrCosts.Count - 1)
					{
						componetInChild.text = TR.Value("color_red", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
					}
				}
				this._SetupFreeCD(gameObject, jarBuyInfo);
				if (jarBuyInfo.arrCosts.Count > 0)
				{
					this.m_comMagicTicket.SetData(ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue, jarBuyInfo.arrCosts[0].item.TableID);
				}
			}
		}

		// Token: 0x0600E6EC RID: 59116 RVA: 0x003CA89C File Offset: 0x003C8C9C
		private void _UpdateFreeCD(JarData a_data, float timeElapsed)
		{
			if (this.m_fUpdateTime <= 0f)
			{
				return;
			}
			this.m_fUpdateTime -= timeElapsed;
			if (this.m_fUpdateTime <= 0f)
			{
				for (int i = 0; i < a_data.arrBuyInfos.Count; i++)
				{
					JarBuyInfo jarBuyInfo = a_data.arrBuyInfos[i];
					if (jarBuyInfo != null && jarBuyInfo.nMaxFreeCount > 0)
					{
						this._SetupFreeCD(this.m_objMagicBuyRoot.transform.GetChild(i).gameObject, jarBuyInfo);
					}
				}
			}
		}

		// Token: 0x0600E6ED RID: 59117 RVA: 0x003CA930 File Offset: 0x003C8D30
		private void _SetupFreeCD(GameObject a_objBuy, JarBuyInfo a_buyInfo)
		{
			GameObject gameObject = Utility.FindGameObject(a_objBuy, "Price", true);
			GameObject gameObject2 = Utility.FindGameObject(a_objBuy, "Free", false);
			GameObject gameObject3 = Utility.FindGameObject(a_objBuy, "FreeCD", false);
			if (a_buyInfo.nMaxFreeCount > 0)
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(a_buyInfo.nFreeCount > 0);
					Text component = gameObject2.GetComponent<Text>();
					component.text = TR.Value("jar_free", a_buyInfo.nFreeCount, a_buyInfo.nMaxFreeCount);
				}
				gameObject.gameObject.SetActive(a_buyInfo.nFreeCount <= 0);
				if (gameObject3 != null)
				{
					if (a_buyInfo.nFreeCount < a_buyInfo.nMaxFreeCount)
					{
						gameObject3.SetActive(true);
						gameObject3.GetComponent<Text>().text = this._GetFreeTimeCDDesc(a_buyInfo.nFreeTimestamp);
						this.m_fUpdateTime = 1f;
					}
					else
					{
						gameObject3.SetActive(false);
					}
				}
			}
			else
			{
				if (gameObject2 != null)
				{
					gameObject2.SetActive(false);
				}
				if (gameObject3 != null)
				{
					gameObject3.SetActive(false);
				}
				gameObject.gameObject.SetActive(true);
			}
		}

		// Token: 0x0600E6EE RID: 59118 RVA: 0x003CAA58 File Offset: 0x003C8E58
		private string _GetFreeTimeCDDesc(int a_timeStamp)
		{
			int num = a_timeStamp - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num < 0)
			{
				num = 0;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = num % 60;
			int num5 = num / 60;
			if (num5 > 0)
			{
				num2 = num5 % 60;
				num3 = num5 / 60;
			}
			return TR.Value("jar_free_cd", num3, num2, num4);
		}

		// Token: 0x0600E6EF RID: 59119 RVA: 0x003CAABC File Offset: 0x003C8EBC
		[UIEventHandle("Content/Groups/MagicGroup/Page/Right/Title/Shop")]
		private void _OnShopClicked()
		{
			DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(7, 0, 0, -1);
			if (this.shopRedPoint.gameObject.activeSelf)
			{
				DataManager<JarDataManager>.GetInstance().SaveCurrTimeStamp();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.Jar, null, null, null);
				this.shopRedPoint.CustomActive(false);
			}
		}

		// Token: 0x04008BDD RID: 35805
		[UIControl("Content/Tabs/Viewport/Content/GoldTab", null, 0)]
		private Toggle m_togGoldJar;

		// Token: 0x04008BDE RID: 35806
		[UIControl("Content/Tabs/Viewport/Content/MagicTab", null, 0)]
		private Toggle m_togMagicJar;

		// Token: 0x04008BDF RID: 35807
		[UIControl("Content/Tabs/Viewport/Content/MagicTab_Lv55", null, 0)]
		private Toggle m_togMagic_Jar_Lv55;

		// Token: 0x04008BE0 RID: 35808
		[UIControl("BG/Title/Moneys/MagicTicket", typeof(ComCommonConsume), 0)]
		private ComCommonConsume m_comMagicTicket;

		// Token: 0x04008BE1 RID: 35809
		[UIControl("Content/BuyRecord/Content", null, 0)]
		private ComUIListScript m_comRecordList;

		// Token: 0x04008BE2 RID: 35810
		private WorldOpenJarRecordRes m_recordData;

		// Token: 0x04008BE3 RID: 35811
		private EPocketJarType mCurPocketJarType = EPocketJarType.Invalid;

		// Token: 0x04008BE4 RID: 35812
		private Button preViewModel;

		// Token: 0x04008BE5 RID: 35813
		private GameObject shopRedPoint;

		// Token: 0x04008BE6 RID: 35814
		[UIObject("Content/Groups/GoldGroup/Tabs")]
		private GameObject m_objGoldLevelTabRoot;

		// Token: 0x04008BE7 RID: 35815
		[UIObject("Content/Groups/GoldGroup/Tabs/Tab")]
		private GameObject m_objGoldLevelTabTemplate;

		// Token: 0x04008BE8 RID: 35816
		[UIControl("Content/Groups/GoldGroup/Page/Right/Items", null, 0)]
		private ComUIListScript m_comGoldItemList;

		// Token: 0x04008BE9 RID: 35817
		[UIControl("Content/Groups/GoldGroup/Page/Left/Jar", null, 0)]
		private Image m_imgGoldJarIcon;

		// Token: 0x04008BEA RID: 35818
		[UIControl("Content/Groups/GoldGroup/Page/Left/Jar/Name", null, 0)]
		private Text m_labGoldJarName;

		// Token: 0x04008BEB RID: 35819
		[UIControl("Content/Groups/GoldGroup/Page/Left/BuyDesc/Title", null, 0)]
		private Text m_labGoldBuyItemTitle;

		// Token: 0x04008BEC RID: 35820
		[UIObject("Content/Groups/GoldGroup/Page/Left/BuyDesc/ItemRoot")]
		private GameObject m_objGoldBuyItemRoot;

		// Token: 0x04008BED RID: 35821
		[UIControl("Content/Groups/GoldGroup/Page/Left/BuyDesc/Desc", null, 0)]
		private Text m_labGoldBuyItemDesc;

		// Token: 0x04008BEE RID: 35822
		[UIObject("Content/Groups/GoldGroup/Page/Right/Buy")]
		private GameObject m_objGoldBuyFuncRoot;

		// Token: 0x04008BEF RID: 35823
		private bool m_bGoldJarInited;

		// Token: 0x04008BF0 RID: 35824
		private JarData m_currGoldJarData;

		// Token: 0x04008BF1 RID: 35825
		private List<GameObject> m_arrLevelTypeObjs = new List<GameObject>();

		// Token: 0x04008BF2 RID: 35826
		private List<PocketJarFrame.OnRedPointChanged> m_arrLevelRedPoints = new List<PocketJarFrame.OnRedPointChanged>();

		// Token: 0x04008BF3 RID: 35827
		[UIControl("Content/Groups/MagicGroup/Page/Right/Items", null, 0)]
		private ComUIListScript m_comMagicItemList;

		// Token: 0x04008BF4 RID: 35828
		[UIControl("Content/Groups/MagicGroup/Page/Left/Jar", null, 0)]
		private Image m_imgMagicJarIcon;

		// Token: 0x04008BF5 RID: 35829
		[UIControl("Content/Groups/MagicGroup/Page/Left/Jar/Name", null, 0)]
		private Text m_labMagicJarName;

		// Token: 0x04008BF6 RID: 35830
		[UIControl("Content/Groups/MagicGroup/Page/Left/BuyDesc/Title", null, 0)]
		private Text m_labMagicBuyItemTitle;

		// Token: 0x04008BF7 RID: 35831
		[UIObject("Content/Groups/MagicGroup/Page/Left/BuyDesc/ItemRoot")]
		private GameObject m_objMagicBuyItemRoot;

		// Token: 0x04008BF8 RID: 35832
		[UIControl("Content/Groups/MagicGroup/Page/Left/BuyDesc/Desc", null, 0)]
		private Text m_labMagicBuyItemDesc;

		// Token: 0x04008BF9 RID: 35833
		[UIObject("Content/Groups/MagicGroup/Page/Right/Buy")]
		private GameObject m_objMagicBuyRoot;

		// Token: 0x04008BFA RID: 35834
		[UIControl("Content/Groups/MagicGroup/Page/Right/Title/MagicScore", null, 0)]
		private Text m_labMagicScore;

		// Token: 0x04008BFB RID: 35835
		[UIControl("Content/Groups/MagicGroup/Page/Right/Title/Text", null, 0)]
		private Text m_labMagicScoreDesc;

		// Token: 0x04008BFC RID: 35836
		private float m_fUpdateTime;

		// Token: 0x020016F9 RID: 5881
		// (Invoke) Token: 0x0600E6FB RID: 59131
		private delegate void OnRedPointChanged();
	}
}
