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
	// Token: 0x0200169F RID: 5791
	internal class ActivityJarFrame : ClientFrame
	{
		// Token: 0x0600E34F RID: 58191 RVA: 0x003A7AA8 File Offset: 0x003A5EA8
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				if (strParam == null || strParam.Length <= 0)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityJarFrame>(FrameLayer.Middle, null, string.Empty);
				}
				else
				{
					string[] array = strParam.Split(new char[]
					{
						'|'
					});
					if (array.Length > 0)
					{
						int nActivityID = int.Parse(array[0]);
						ActivityJarData activityJarData = new ActivityJarData();
						activityJarData.nActivityID = nActivityID;
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityJarFrame>(FrameLayer.Middle, activityJarData, string.Empty);
					}
					else
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityJarFrame>(FrameLayer.Middle, null, string.Empty);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("ActivityJarFrame.OpenLinkFrame : ==> " + ex.ToString());
			}
		}

		// Token: 0x0600E350 RID: 58192 RVA: 0x003A7B68 File Offset: 0x003A5F68
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Jar/ActivityJar";
		}

		// Token: 0x0600E351 RID: 58193 RVA: 0x003A7B6F File Offset: 0x003A5F6F
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600E352 RID: 58194 RVA: 0x003A7B72 File Offset: 0x003A5F72
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600E353 RID: 58195 RVA: 0x003A7B80 File Offset: 0x003A5F80
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600E354 RID: 58196 RVA: 0x003A7B90 File Offset: 0x003A5F90
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnUpdateJar));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateJar));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JarOpenRecordUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateOpenRecord));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ArtifactJarDataUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateArtifactJarDiscountInfo));
		}

		// Token: 0x0600E355 RID: 58197 RVA: 0x003A7C24 File Offset: 0x003A6024
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataBaseUpdated, new ClientEventSystem.UIEventHandler(this._OnUpdateJar));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MagicJarUseSuccess, new ClientEventSystem.UIEventHandler(this._OnUpdateJar));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JarOpenRecordUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateOpenRecord));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ArtifactJarDataUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateArtifactJarDiscountInfo));
		}

		// Token: 0x0600E356 RID: 58198 RVA: 0x003A7CB8 File Offset: 0x003A60B8
		protected override void _bindExUI()
		{
			this.title = this.mBind.GetCom<Text>("title");
			this.getDiscount = this.mBind.GetGameObject("getDiscount");
			this.btnGetDiscount = this.mBind.GetCom<Button>("btnGetDiscount");
			this.btnGetDiscount.SafeAddOnClickListener(delegate
			{
				DataManager<ArtifactDataManager>.GetInstance().SendGetDiscount();
			});
			this.Rate = this.mBind.GetCom<Text>("Rate");
			this.RemainCount = this.mBind.GetCom<Text>("RemainCount");
			this.mFunc1 = this.mBind.GetGameObject("Func1");
			this.mFunc10Btn = this.mBind.GetCom<Button>("Func10Btn");
			this.mFunc10Gray = this.mBind.GetCom<UIGray>("Func10Gray");
			this.mFunc10Text = this.mBind.GetCom<Text>("Func10Text");
			this.activityCloseTip = this.mBind.GetGameObject("activityCloseTip");
			this.GoldGroup = this.mBind.GetGameObject("GoldGroup");
		}

		// Token: 0x0600E357 RID: 58199 RVA: 0x003A7DE0 File Offset: 0x003A61E0
		protected override void _unbindExUI()
		{
			this.title = null;
			this.getDiscount = null;
			this.btnGetDiscount = null;
			this.Rate = null;
			this.RemainCount = null;
			this.mFunc1 = null;
			this.mFunc10Btn = null;
			this.mFunc10Gray = null;
			this.mFunc10Text = null;
			this.activityCloseTip = null;
			this.GoldGroup = null;
		}

		// Token: 0x0600E358 RID: 58200 RVA: 0x003A7E3A File Offset: 0x003A623A
		protected override void _OnUpdate(float timeElapsed)
		{
			this._UpdateJarTime(timeElapsed);
		}

		// Token: 0x0600E359 RID: 58201 RVA: 0x003A7E44 File Offset: 0x003A6244
		private void _InitUI()
		{
			this._InitBuyJarRecord();
			this._InitDisplayJarInfo();
			this._InitMainTabs();
			this._InitSelectedJarInfo();
			this._InitArtifactJarDiscountInfo();
			this._InitBg();
			this._InitDiscountNum();
			this._InitActivityTimeOpenInfo();
			this._InitSelectJarTabsRect();
			this._InitActivityTipInfo();
			this._UpdateActivityJarUI();
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				this.m_objBuyOneFunc.CustomActive(false);
			}
		}

		// Token: 0x0600E35A RID: 58202 RVA: 0x003A7EAA File Offset: 0x003A62AA
		private void _InitBuyJarRecord()
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

		// Token: 0x0600E35B RID: 58203 RVA: 0x003A7ECE File Offset: 0x003A62CE
		private void _InitDisplayJarInfo()
		{
			this.m_comItemList.Initialize();
			this.m_comItemList.onBindItem = ((GameObject var) => base.CreateComItem(Utility.FindGameObject(var, "Item", true)));
			this.m_comItemList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_currActJar != null)
				{
					List<ItemSimpleData> arrBonusItems = this.m_currActJar.jarData.arrBonusItems;
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
								if (this.m_currActJar.jarData.eType == JarBonus.eType.EquipJar)
								{
									Utility.DoStartFrameOperation("ActivityJarFrame", string.Format("{0}ArtifactTank_ItemId_{1}", this.m_currActJar.activity.level, var2.TableID));
								}
								else if (this.m_currActJar.jarData.eType == JarBonus.eType.FashionJar)
								{
									Utility.DoStartFrameOperation("ActivityJarFrame", string.Format("GlamourFashionJar_ItemId_{0}", var2.TableID));
								}
							});
							Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = itemData.GetColorName(string.Empty, false);
						}
					}
				}
			};
		}

		// Token: 0x0600E35C RID: 58204 RVA: 0x003A7F0C File Offset: 0x003A630C
		private void _InitMainTabs()
		{
			ActivityJarFrame.<_InitMainTabs>c__AnonStorey0 <_InitMainTabs>c__AnonStorey = new ActivityJarFrame.<_InitMainTabs>c__AnonStorey0();
			<_InitMainTabs>c__AnonStorey.$this = this;
			Button componetInChild = Utility.GetComponetInChild<Button>(this.m_objTab0, "DropDownList/MainButton");
			componetInChild.onClick.RemoveAllListeners();
			componetInChild.onClick.AddListener(delegate()
			{
				<_InitMainTabs>c__AnonStorey.$this.m_objOverlay0.SetActive(!<_InitMainTabs>c__AnonStorey.$this.m_objOverlay0.activeSelf);
			});
			this.m_objOverlay0.SetActive(false);
			<_InitMainTabs>c__AnonStorey.comList = this.m_objOverlay0.GetComponent<ComUIListScript>();
			<_InitMainTabs>c__AnonStorey.comList.Initialize();
			<_InitMainTabs>c__AnonStorey.comList.onItemChageDisplay = delegate(ComUIListElementScript var, bool selected)
			{
				ComCommonBind component = var.GetComponent<ComCommonBind>();
				StaticUtility.SafeSetVisible(component, "selected", selected);
			};
			<_InitMainTabs>c__AnonStorey.comList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var.m_index >= 0 && var.m_index < <_InitMainTabs>c__AnonStorey.$this.m_arrEquipActData.Count)
				{
					ActivityJarFrame.ActJarInfo actJarInfo = <_InitMainTabs>c__AnonStorey.$this.m_arrEquipActData[var.m_index];
					Utility.GetComponetInChild<Text>(var.gameObject, "Label").text = actJarInfo.jarData.strName;
					Button component = var.GetComponent<Button>();
					component.onClick.RemoveAllListeners();
					component.onClick.AddListener(delegate()
					{
						<_InitMainTabs>c__AnonStorey.comList.SelectElement(var.m_index, true);
						<_InitMainTabs>c__AnonStorey._UpdateEquipmentJarInfo(<_InitMainTabs>c__AnonStorey.m_arrEquipActData[var.m_index], false);
						Utility.DoStartFrameOperation("ActivityJarFrame", string.Format("{0}ArtifactTank", <_InitMainTabs>c__AnonStorey.m_arrEquipActData[var.m_index].activity.level));
					});
				}
			};
			this.m_togTab0.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					<_InitMainTabs>c__AnonStorey.$this._UpdateEquipmentJarInfo(<_InitMainTabs>c__AnonStorey.$this.m_selectEquipActJar, true);
					if (<_InitMainTabs>c__AnonStorey.$this.m_contentDescText)
					{
						<_InitMainTabs>c__AnonStorey.$this.m_contentDescText.text = TR.Value("jar_content_desc_pink");
					}
				}
				<_InitMainTabs>c__AnonStorey.$this.m_objOverlay0.SetActive(false);
			});
			ActivityJarFrame.<_InitMainTabs>c__AnonStorey2 <_InitMainTabs>c__AnonStorey2 = new ActivityJarFrame.<_InitMainTabs>c__AnonStorey2();
			<_InitMainTabs>c__AnonStorey2.$this = this;
			Button componetInChild2 = Utility.GetComponetInChild<Button>(this.m_objTab1, "DropDownList/MainButton");
			componetInChild2.onClick.RemoveAllListeners();
			componetInChild2.onClick.AddListener(delegate()
			{
				<_InitMainTabs>c__AnonStorey2.$this.m_objOverlay1.SetActive(!<_InitMainTabs>c__AnonStorey2.$this.m_objOverlay1.activeSelf);
			});
			this.m_objOverlay1.SetActive(false);
			<_InitMainTabs>c__AnonStorey2.comList = this.m_objOverlay1.GetComponent<ComUIListScript>();
			<_InitMainTabs>c__AnonStorey2.comList.Initialize();
			<_InitMainTabs>c__AnonStorey2.comList.onItemChageDisplay = delegate(ComUIListElementScript var, bool selected)
			{
				ComCommonBind component = var.GetComponent<ComCommonBind>();
				StaticUtility.SafeSetVisible(component, "selected", selected);
			};
			<_InitMainTabs>c__AnonStorey2.comList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (var.m_index >= 0 && var.m_index < <_InitMainTabs>c__AnonStorey2.$this.m_arrFashionActData.Count)
				{
					ActivityJarFrame.ActJarInfo actJarInfo = <_InitMainTabs>c__AnonStorey2.$this.m_arrFashionActData[var.m_index];
					Utility.GetComponetInChild<Text>(var.gameObject, "Label").text = actJarInfo.jarData.strName;
					Button component = var.GetComponent<Button>();
					component.onClick.RemoveAllListeners();
					component.onClick.AddListener(delegate()
					{
						<_InitMainTabs>c__AnonStorey2.comList.SelectElement(var.m_index, true);
						<_InitMainTabs>c__AnonStorey2._UpdateFashionJarInfo(<_InitMainTabs>c__AnonStorey2.m_arrFashionActData[var.m_index]);
					});
				}
			};
			this.m_togTab1.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					<_InitMainTabs>c__AnonStorey2.$this._UpdateFashionJarInfo(<_InitMainTabs>c__AnonStorey2.$this.m_selectFashionActJar);
					if (<_InitMainTabs>c__AnonStorey2.$this.m_contentDescText)
					{
						<_InitMainTabs>c__AnonStorey2.$this.m_contentDescText.text = TR.Value("jar_content_desc_pupple");
					}
					Utility.DoStartFrameOperation("ActivityJarFrame", "GlamourFashionJar");
				}
				<_InitMainTabs>c__AnonStorey2.$this.m_objOverlay1.SetActive(false);
			});
			this._UpdateTabs(true);
		}

		// Token: 0x0600E35D RID: 58205 RVA: 0x003A80A8 File Offset: 0x003A64A8
		private void _UpdateTabs(bool bIsInit = false)
		{
			this.m_arrEquipActData.Clear();
			this.m_arrFashionActData.Clear();
			Dictionary<int, object>.Enumerator enumerator = Singleton<TableManager>.GetInstance().GetTable<ActivityJarTable>().GetEnumerator();
			while (enumerator.MoveNext())
			{
				ActivityInfo activityInfo = null;
				Dictionary<int, ActivityInfo> allActivities = DataManager<ActiveManager>.GetInstance().allActivities;
				KeyValuePair<int, object> keyValuePair = enumerator.Current;
				allActivities.TryGetValue(keyValuePair.Key, out activityInfo);
				if (activityInfo != null && activityInfo.state != 0)
				{
					KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
					ActivityJarTable activityJarTable = keyValuePair2.Value as ActivityJarTable;
					JarData jarData = DataManager<JarDataManager>.GetInstance().GetJarData(activityJarTable.JarID);
					if (jarData.eType == JarBonus.eType.EquipJar)
					{
						ActivityJarFrame.ActJarInfo actJarInfo = new ActivityJarFrame.ActJarInfo();
						actJarInfo.activity = activityInfo;
						actJarInfo.jarData = jarData;
						bool flag = true;
						if (flag)
						{
							this.m_arrEquipActData.Add(actJarInfo);
						}
					}
					else if (jarData.eType == JarBonus.eType.FashionJar)
					{
						ActivityJarFrame.ActJarInfo actJarInfo2 = new ActivityJarFrame.ActJarInfo();
						actJarInfo2.activity = activityInfo;
						actJarInfo2.jarData = jarData;
						this.m_arrFashionActData.Add(actJarInfo2);
					}
				}
			}
			if (this.m_arrEquipActData.Count > 0)
			{
				this.m_objTab0.SetActive(true);
				if (this.m_selectEquipActJar != null)
				{
					bool flag2 = false;
					for (int i = 0; i < this.m_arrEquipActData.Count; i++)
					{
						if (this.m_arrEquipActData[i].activity.id == this.m_selectEquipActJar.activity.id)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						this.m_selectEquipActJar = this._GetLevelMatchAct(this.m_arrEquipActData);
					}
				}
				else
				{
					this.m_selectEquipActJar = this._GetLevelMatchAct(this.m_arrEquipActData);
				}
				this._UpdateEquipmentJarInfo(this.m_selectEquipActJar, bIsInit);
				this.m_objOverlay0.SetActive(false);
				this.m_objOverlay0.GetComponent<ComUIListScript>().SetElementAmount(this.m_arrEquipActData.Count);
				if (bIsInit)
				{
					ComUIListScript component = this.m_objOverlay0.GetComponent<ComUIListScript>();
					if (component != null && this.m_arrEquipActData != null && this.m_arrEquipActData.Count > 0)
					{
						component.SelectElement(this.m_arrEquipActData.Count - 1, true);
					}
				}
			}
			else
			{
				this.m_objTab0.SetActive(false);
			}
			if (this.m_arrFashionActData.Count > 0)
			{
				this.m_objTab1.SetActive(true);
				if (this.m_selectFashionActJar != null)
				{
					bool flag3 = false;
					for (int j = 0; j < this.m_arrFashionActData.Count; j++)
					{
						if (this.m_arrFashionActData[j].activity.id == this.m_selectFashionActJar.activity.id)
						{
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						this.m_selectFashionActJar = this._GetLevelMatchAct(this.m_arrFashionActData);
					}
				}
				else
				{
					this.m_selectFashionActJar = this._GetLevelMatchAct(this.m_arrFashionActData);
				}
				this._UpdateFashionJarInfo(this.m_selectFashionActJar);
				this.m_objOverlay1.SetActive(false);
				this.m_objOverlay1.GetComponent<ComUIListScript>().SetElementAmount(this.m_arrFashionActData.Count);
				if (bIsInit)
				{
					ComUIListScript component2 = this.m_objOverlay1.GetComponent<ComUIListScript>();
					if (component2 != null && this.m_arrFashionActData != null && this.m_arrFashionActData.Count > 0)
					{
						component2.SelectElement(this.m_arrFashionActData.Count - 1, true);
					}
				}
			}
			else
			{
				this.m_objTab1.SetActive(false);
			}
		}

		// Token: 0x0600E35E RID: 58206 RVA: 0x003A8448 File Offset: 0x003A6848
		private void _InitArtifactJarDiscountInfo()
		{
			if (ActivityJarFrame.frameType != ActivityJarFrameType.Artifact)
			{
				return;
			}
			this.Rate.SafeSetText(TR.Value("jar_activity_rate", ActivityJarFrame.GetArtifactJarDiscountRate()));
			this.RemainCount.SafeSetText(ActivityJarFrame.GetArtifactJarDiscountTimes().ToString());
			StaticUtility.SafeSetText(this.mBind, "leftDiscount", TR.Value("artifact_jar_discount_left_num", ActivityJarFrame.GetArtifactJarDiscountTimes()));
		}

		// Token: 0x0600E35F RID: 58207 RVA: 0x003A84C2 File Offset: 0x003A68C2
		public static int GetArtifactJarDiscountRate()
		{
			if (DataManager<ArtifactDataManager>.GetInstance() == null)
			{
				return 0;
			}
			if (DataManager<ArtifactDataManager>.GetInstance().getArtifactDiscountData() == null)
			{
				return 0;
			}
			return DataManager<ArtifactDataManager>.GetInstance().getArtifactDiscountData().discountRate;
		}

		// Token: 0x0600E360 RID: 58208 RVA: 0x003A84F0 File Offset: 0x003A68F0
		public static int GetArtifactJarDiscountTimes()
		{
			if (DataManager<ArtifactDataManager>.GetInstance() == null)
			{
				return 0;
			}
			if (DataManager<ArtifactDataManager>.GetInstance().getArtifactDiscountData() == null)
			{
				return 0;
			}
			return DataManager<ArtifactDataManager>.GetInstance().getArtifactDiscountData().discountEffectTimes;
		}

		// Token: 0x0600E361 RID: 58209 RVA: 0x003A851E File Offset: 0x003A691E
		public static bool IsHaveGotArtifactJarDiscount()
		{
			return DataManager<ArtifactDataManager>.GetInstance() != null && DataManager<ArtifactDataManager>.GetInstance().getArtifactDiscountData() != null && DataManager<ArtifactDataManager>.GetInstance().getArtifactDiscountData().extractDiscountStatus == ArtifactJarDiscountExtractStatus.AJDES_OVER;
		}

		// Token: 0x0600E362 RID: 58210 RVA: 0x003A854F File Offset: 0x003A694F
		private void _InitGetDiscountInfo()
		{
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Normal)
			{
				this.getDiscount.CustomActive(false);
			}
			else if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				this.getDiscount.CustomActive(!ActivityJarFrame.IsHaveGotArtifactJarDiscount());
			}
		}

		// Token: 0x0600E363 RID: 58211 RVA: 0x003A858A File Offset: 0x003A698A
		private void _InitBg()
		{
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				StaticUtility.SafeSetVisible(this.mBind, "BG", false);
				StaticUtility.SafeSetVisible(this.mBind, "mask", false);
			}
		}

		// Token: 0x0600E364 RID: 58212 RVA: 0x003A85BC File Offset: 0x003A69BC
		private void _InitDiscountNum()
		{
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				StaticUtility.SafeSetImage(this.mBind, "discount", string.Format("UI/Image/Packed/p_UI_Moguanpaidui.png:UI_Moguanpaidui_Number_0{0}", ActivityJarFrame.GetArtifactJarDiscountRate()));
				StaticUtility.SafeSetVisible<Image>(this.mBind, "discount", ActivityJarFrame.GetArtifactJarDiscountRate() > 0);
			}
		}

		// Token: 0x0600E365 RID: 58213 RVA: 0x003A8610 File Offset: 0x003A6A10
		private void _InitActivityTimeOpenInfo()
		{
			OpActivityData artifactJarActData = DataManager<ArtifactDataManager>.GetInstance().getArtifactJarActData();
			if (artifactJarActData != null && ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				StaticUtility.SafeSetText(this.mBind, "activityTime", string.Format("活动时间 {0} - {1}", Function.GetOneData((int)artifactJarActData.startTime), Function.GetDateTime((int)artifactJarActData.endTime, false)));
				StaticUtility.SafeSetVisible<Text>(this.mBind, "activityTime", true);
			}
		}

		// Token: 0x0600E366 RID: 58214 RVA: 0x003A867C File Offset: 0x003A6A7C
		private void _InitActivityTipInfo()
		{
			OpActivityData artifactJarActData = DataManager<ArtifactDataManager>.GetInstance().getArtifactJarActData();
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				StaticUtility.SafeSetVisible(this.mBind, "gongxiang", true);
				StaticUtility.SafeSetVisible(this.mBind, "activityTip", true);
				StaticUtility.SafeSetVisible<Text>(this.mBind, "leftDiscount", true);
				StaticUtility.SafeSetText(this.mBind, "leftDiscount", TR.Value("artifact_jar_discount_left_num", ActivityJarFrame.GetArtifactJarDiscountTimes()));
			}
		}

		// Token: 0x0600E367 RID: 58215 RVA: 0x003A86F6 File Offset: 0x003A6AF6
		private void _UpdateActivityJarUI()
		{
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				this.mFunc1.CustomActive(false);
			}
			else
			{
				this.mFunc1.CustomActive(true);
			}
			this._UpdateFun10Gray();
		}

		// Token: 0x0600E368 RID: 58216 RVA: 0x003A8728 File Offset: 0x003A6B28
		private void _UpdateFun10Gray()
		{
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				if (ActivityJarFrame.GetArtifactJarDiscountTimes() <= 0)
				{
					this.mFunc10Btn.interactable = false;
					this.mFunc10Gray.enabled = true;
					this.mFunc10Text.text = TR.Value("artifact_jar_havebuy_text");
				}
				else
				{
					this.mFunc10Btn.interactable = true;
					this.mFunc10Gray.enabled = false;
					this.mFunc10Text.text = TR.Value("artifact_jar_havenotbuy_text");
				}
			}
		}

		// Token: 0x0600E369 RID: 58217 RVA: 0x003A87AC File Offset: 0x003A6BAC
		private void MoveOffset(ref GameObject obj, int ix, int iy)
		{
			if (obj == null)
			{
				return;
			}
			RectTransform component = obj.GetComponent<RectTransform>();
			Vector3 localPosition = default(Vector3);
			localPosition = component.localPosition;
			localPosition.x += (float)ix;
			localPosition.y += (float)iy;
			obj.transform.localPosition = localPosition;
		}

		// Token: 0x0600E36A RID: 58218 RVA: 0x003A880C File Offset: 0x003A6C0C
		private void _InitSelectJarTabsRect()
		{
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				this.m_objTab1.CustomActive(false);
				int iy = -80;
				this.MoveOffset(ref this.m_objTab0, 0, iy);
				this.MoveOffset(ref this.m_objOverlay0, 0, iy);
			}
		}

		// Token: 0x0600E36B RID: 58219 RVA: 0x003A8850 File Offset: 0x003A6C50
		private void _InitTitle()
		{
			string str = string.Empty;
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Normal)
			{
				str = TR.Value("gemJar");
			}
			else if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				str = TR.Value("artifactJar");
			}
			this.title.SafeSetText(str);
		}

		// Token: 0x0600E36C RID: 58220 RVA: 0x003A88A0 File Offset: 0x003A6CA0
		private void _InitSelectedJarInfo()
		{
			ActivityJarData activityJarData = this.userData as ActivityJarData;
			if (activityJarData != null)
			{
				ActivityJarFrame.ActJarInfo actJarInfo = this._GetActJarInfo(this.m_arrEquipActData, activityJarData.nActivityID);
				if (actJarInfo != null)
				{
					this.m_selectEquipActJar = actJarInfo;
					this.m_currActJar = this.m_selectEquipActJar;
					this.m_togTab0.isOn = false;
					this.m_togTab0.isOn = true;
					return;
				}
				actJarInfo = this._GetActJarInfo(this.m_arrFashionActData, activityJarData.nActivityID);
				if (actJarInfo != null)
				{
					this.m_selectFashionActJar = actJarInfo;
					this.m_currActJar = this.m_selectFashionActJar;
					this.m_togTab1.isOn = false;
					this.m_togTab1.isOn = true;
					return;
				}
			}
			if (this.m_arrEquipActData.Count > 0)
			{
				this.m_selectEquipActJar = this._GetLevelMatchAct(this.m_arrEquipActData);
				this.m_currActJar = this.m_selectEquipActJar;
				this.m_togTab0.isOn = false;
				this.m_togTab0.isOn = true;
			}
			else if (this.m_arrFashionActData.Count > 0)
			{
				this.m_selectFashionActJar = this._GetLevelMatchAct(this.m_arrFashionActData);
				this.m_currActJar = this.m_selectFashionActJar;
				this.m_togTab1.isOn = false;
				this.m_togTab1.isOn = true;
			}
		}

		// Token: 0x0600E36D RID: 58221 RVA: 0x003A89DC File Offset: 0x003A6DDC
		private void _ClearUI()
		{
			this.m_selectEquipActJar = null;
			this.m_arrEquipActData.Clear();
			this.m_selectFashionActJar = null;
			this.m_arrFashionActData.Clear();
			this.m_currActJar = null;
			this.m_fUpdateTime = 0f;
			this._ClearRecord();
		}

		// Token: 0x0600E36E RID: 58222 RVA: 0x003A8A1C File Offset: 0x003A6E1C
		private void _UpdateEquipmentJarInfo(ActivityJarFrame.ActJarInfo a_selectActJar, bool IsInit = false)
		{
			if (DataManager<PlayerBaseData>.GetInstance().Level < a_selectActJar.activity.level)
			{
				if (!IsInit)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("当前角色等级不足,无法查看详细信息,请继续提升等级~", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				return;
			}
			this.m_selectEquipActJar = a_selectActJar;
			if (this.m_selectEquipActJar != null)
			{
				Utility.GetComponetInChild<Text>(this.m_objTab0, "Background/Label").text = this.m_selectEquipActJar.jarData.strName;
				Utility.GetComponetInChild<Text>(this.m_objTab0, "DropDownList/MainButton/Label").text = this.m_selectEquipActJar.jarData.strName;
				if (this.m_objTab0.GetComponent<Toggle>().isOn)
				{
					this._UpdateSelectedJarInfo(this.m_selectEquipActJar);
				}
			}
			this.m_objOverlay0.SetActive(false);
		}

		// Token: 0x0600E36F RID: 58223 RVA: 0x003A8AE0 File Offset: 0x003A6EE0
		private void _UpdateFashionJarInfo(ActivityJarFrame.ActJarInfo a_selectActJar)
		{
			this.m_selectFashionActJar = a_selectActJar;
			if (this.m_selectFashionActJar != null)
			{
				Utility.GetComponetInChild<Text>(this.m_objTab1, "Background/Label").text = this.m_selectFashionActJar.jarData.strName;
				Utility.GetComponetInChild<Text>(this.m_objTab1, "DropDownList/MainButton/Label").text = this.m_selectFashionActJar.jarData.strName;
				if (this.m_objTab1.GetComponent<Toggle>().isOn)
				{
					this._UpdateSelectedJarInfo(this.m_selectFashionActJar);
				}
			}
			this.m_objOverlay1.SetActive(false);
		}

		// Token: 0x0600E370 RID: 58224 RVA: 0x003A8B76 File Offset: 0x003A6F76
		public static uint GetArtifactActivityID()
		{
			if (ActivityJarFrame.frameType != ActivityJarFrameType.Artifact)
			{
				return 0U;
			}
			if (DataManager<ArtifactDataManager>.GetInstance().getArtifactDiscountData() == null)
			{
				return 0U;
			}
			return (uint)DataManager<ArtifactDataManager>.GetInstance().getArtifactDiscountData().opActId;
		}

		// Token: 0x0600E371 RID: 58225 RVA: 0x003A8BA5 File Offset: 0x003A6FA5
		private static bool IsActivityExhibition()
		{
			return ArtifactFrame.IsArtifactJarShowActivityOpen();
		}

		// Token: 0x0600E372 RID: 58226 RVA: 0x003A8BAC File Offset: 0x003A6FAC
		public static void AdjustCostByActivityDiscount(ref int nTotalCost, int nPrice, int nBuyCount)
		{
			int num = Math.Min(ActivityJarFrame.GetArtifactJarDiscountTimes(), nBuyCount);
			int num2 = nBuyCount - num;
			if (num2 < 0)
			{
				num2 = 0;
			}
			float num3 = 1f;
			if (nBuyCount == 1)
			{
				num3 = 1f;
			}
			else if (nBuyCount == 10)
			{
				num3 = 0.9f;
			}
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				nTotalCost = Mathf.FloorToInt(((float)ActivityJarFrame.GetArtifactJarDiscountRate() / 10f * (float)(num * nPrice) + (float)(num2 * nPrice)) * num3);
			}
		}

		// Token: 0x0600E373 RID: 58227 RVA: 0x003A8C24 File Offset: 0x003A7024
		private void _UpdateSelectedJarInfo(ActivityJarFrame.ActJarInfo a_actJar)
		{
			this.m_currActJar = a_actJar;
			DataManager<JarDataManager>.GetInstance().RequestJarBuyRecord(this.m_currActJar.jarData.nID);
			ActivityJarTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActivityJarTable>((int)this.m_currActJar.activity.id, string.Empty, string.Empty);
			ETCImageLoader.LoadSprite(ref this.m_imgActivity, tableItem.ActivityBG, true);
			this.m_labActivityTime.text = this._GetEndTimeDesc((int)this.m_currActJar.activity.dueTime);
			if ((ulong)this.m_currActJar.activity.dueTime > (ulong)((long)DataManager<TimeManager>.GetInstance().GetServerTime()))
			{
				this.m_fUpdateTime = 1f;
			}
			this.m_labActivityRule.text = tableItem.ActivityRule;
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				StaticUtility.SafeSetVisible<Image>(this.mBind, "artifactJarActivity", true);
				StaticUtility.SafeSetImage(this.mBind, "artifactJarActivity", "UI/Image/Background/UI_Shenqiguan_Wodezhekou_Di.png:UI_Shenqiguan_Wodezhekou_Di");
				this.m_imgActivity.CustomActive(false);
				this.m_labActivityRule.text = string.Empty;
				this.m_labActivityTime.text = string.Empty;
			}
			this.m_comItemList.SetElementAmount(this.m_currActJar.jarData.arrBonusItems.Count);
			for (int i = 0; i < this.m_currActJar.jarData.arrBuyInfos.Count; i++)
			{
				GameObject gameObject = this.m_objBuyFuncRoot.transform.GetChild(i).gameObject;
				gameObject.SetActive(true);
				JarBuyInfo buyInfo = this.m_currActJar.jarData.arrBuyInfos[i];
				Button component = gameObject.GetComponent<Button>();
				component.onClick.RemoveAllListeners();
				component.onClick.AddListener(delegate()
				{
					ShowItemsFrame.bSkipExplode = false;
					if (buyInfo.nFreeCount > 0)
					{
						DataManager<JarDataManager>.GetInstance().RequestBuyJar(this.m_currActJar.jarData, buyInfo, ActivityJarFrame.GetArtifactActivityID(), 0U);
						return;
					}
					CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
					for (int k = 0; k < buyInfo.arrCosts.Count; k++)
					{
						JarBuyCost jarBuyCost2 = buyInfo.arrCosts[k];
						int realCostCount2 = jarBuyCost2.GetRealCostCount(buyInfo.nBuyCount);
						ActivityJarFrame.AdjustCostByActivityDiscount(ref realCostCount2, jarBuyCost2.item.Count, buyInfo.nBuyCount);
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
					UnityAction unityAction = delegate()
					{
						DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
						{
							DataManager<JarDataManager>.GetInstance().RequestBuyJar(<_UpdateSelectedJarInfo>c__AnonStorey.m_currActJar.jarData, buyInfo, ActivityJarFrame.GetArtifactActivityID(), 0U);
						}, "common_money_cost", null);
					};
					unityAction.Invoke();
					if (this.m_currActJar.jarData.eType == JarBonus.eType.EquipJar)
					{
						Utility.DoStartFrameOperation("ActivityJarFrame", string.Format("{0}ArtifactTank_Buy{1}", this.m_currActJar.activity.level, buyInfo.nBuyCount));
					}
					else if (this.m_currActJar.jarData.eType == JarBonus.eType.FashionJar)
					{
						Utility.DoStartFrameOperation("ActivityJarFrame", string.Format("GlamourFashionJar_Buy{0}", buyInfo.nBuyCount));
					}
				});
				Utility.GetComponetInChild<Text>(gameObject, "Time").text = TR.Value("magicjar_buy_times", buyInfo.nBuyCount);
				Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "DiscountPrice/Count");
				Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "DiscountPrice/Icon");
				Text componetInChild3 = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
				Image componetInChild4 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
				for (int j = 0; j < buyInfo.arrCosts.Count; j++)
				{
					JarBuyCost jarBuyCost = buyInfo.arrCosts[j];
					ActivityJarBuyCost activityJarBuyCost = jarBuyCost as ActivityJarBuyCost;
					if (activityJarBuyCost != null)
					{
						this.m_labDiscountRate.text = TR.Value("jar_activity_rate", jarBuyCost.fDiscount * 10f);
						this.m_labDiscountRemainCount.text = jarBuyCost.nRemainDiscountTime.ToString();
						this._UpdateActivityJarUI();
						if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
						{
							this._InitArtifactJarDiscountInfo();
						}
						if (activityJarBuyCost.bDisTimeReset)
						{
							this.m_labResetTime.text = TR.Value("jar_activity_discount_reset_time");
						}
						else
						{
							this.m_labResetTime.text = string.Empty;
						}
					}
					int realCostCount = jarBuyCost.GetRealCostCount(buyInfo.nBuyCount);
					ActivityJarFrame.AdjustCostByActivityDiscount(ref realCostCount, jarBuyCost.item.Count, buyInfo.nBuyCount);
					if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
					{
						componetInChild.text = realCostCount.ToString();
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						componetInChild3.text = (jarBuyCost.item.Count * buyInfo.nBuyCount).ToString();
						ETCImageLoader.LoadSprite(ref componetInChild4, jarBuyCost.item.Icon, true);
						break;
					}
					if (j == buyInfo.arrCosts.Count - 1)
					{
						componetInChild.text = TR.Value("color_red", realCostCount);
						ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
						componetInChild3.text = (jarBuyCost.item.Count * buyInfo.nBuyCount).ToString();
						ETCImageLoader.LoadSprite(ref componetInChild4, jarBuyCost.item.Icon, true);
					}
				}
			}
		}

		// Token: 0x0600E374 RID: 58228 RVA: 0x003A9084 File Offset: 0x003A7484
		private void _OnActivityUpdate(UIEvent a_event)
		{
			uint a_nActivityID = (uint)a_event.Param1;
			if (DataManager<JarDataManager>.GetInstance().IsActivityJar((int)a_nActivityID))
			{
				this._UpdateTabs(false);
				this._UpdateSelectActJar();
			}
		}

		// Token: 0x0600E375 RID: 58229 RVA: 0x003A90BC File Offset: 0x003A74BC
		private void _OnUpdateJar(UIEvent a_event)
		{
			if (this.m_currActJar != null)
			{
				for (int i = 0; i < this.m_currActJar.jarData.arrBuyInfos.Count; i++)
				{
					GameObject gameObject = this.m_objBuyFuncRoot.transform.GetChild(i).gameObject;
					gameObject.SetActive(true);
					JarBuyInfo jarBuyInfo = this.m_currActJar.jarData.arrBuyInfos[i];
					Text componetInChild = Utility.GetComponetInChild<Text>(gameObject, "DiscountPrice/Count");
					Image componetInChild2 = Utility.GetComponetInChild<Image>(gameObject, "DiscountPrice/Icon");
					Text componetInChild3 = Utility.GetComponetInChild<Text>(gameObject, "Price/Count");
					Image componetInChild4 = Utility.GetComponetInChild<Image>(gameObject, "Price/Icon");
					for (int j = 0; j < jarBuyInfo.arrCosts.Count; j++)
					{
						JarBuyCost jarBuyCost = jarBuyInfo.arrCosts[j];
						ActivityJarBuyCost activityJarBuyCost = jarBuyCost as ActivityJarBuyCost;
						if (activityJarBuyCost != null)
						{
							this.m_labDiscountRate.text = TR.Value("jar_activity_rate", jarBuyCost.fDiscount * 10f);
							this.m_labDiscountRemainCount.text = jarBuyCost.nRemainDiscountTime.ToString();
							this._UpdateActivityJarUI();
							if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
							{
								this._InitArtifactJarDiscountInfo();
							}
						}
						int realCostCount = jarBuyCost.GetRealCostCount(jarBuyInfo.nBuyCount);
						ActivityJarFrame.AdjustCostByActivityDiscount(ref realCostCount, jarBuyCost.item.Count, jarBuyInfo.nBuyCount);
						if (realCostCount <= DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(jarBuyCost.item.TableID, true))
						{
							componetInChild.text = realCostCount.ToString();
							ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
							componetInChild3.text = (jarBuyCost.item.Count * jarBuyInfo.nBuyCount).ToString();
							ETCImageLoader.LoadSprite(ref componetInChild4, jarBuyCost.item.Icon, true);
							break;
						}
						if (j == jarBuyInfo.arrCosts.Count - 1)
						{
							componetInChild.text = TR.Value("color_red", realCostCount);
							ETCImageLoader.LoadSprite(ref componetInChild2, jarBuyCost.item.Icon, true);
							componetInChild3.text = (jarBuyCost.item.Count * jarBuyInfo.nBuyCount).ToString();
							ETCImageLoader.LoadSprite(ref componetInChild4, jarBuyCost.item.Icon, true);
						}
					}
				}
			}
		}

		// Token: 0x0600E376 RID: 58230 RVA: 0x003A932F File Offset: 0x003A772F
		private void _OnUpdateOpenRecord(UIEvent a_event)
		{
			this._ClearRecord();
			this.m_recordData = (a_event.Param1 as WorldOpenJarRecordRes);
			this._UpdateRecord();
		}

		// Token: 0x0600E377 RID: 58231 RVA: 0x003A934E File Offset: 0x003A774E
		private void _OnUpdateArtifactJarDiscountInfo(UIEvent a_event)
		{
			this._InitArtifactJarDiscountInfo();
		}

		// Token: 0x0600E378 RID: 58232 RVA: 0x003A9358 File Offset: 0x003A7758
		private void _UpdateSelectActJar()
		{
			if (this.m_currActJar != null)
			{
				ActivityJarFrame.ActJarInfo actJarInfo = this._GetActJarInfo(this.m_arrEquipActData, (int)this.m_currActJar.activity.id);
				if (actJarInfo != null)
				{
					this.m_selectEquipActJar = actJarInfo;
					this.m_togTab0.isOn = false;
					this.m_togTab0.isOn = true;
					return;
				}
				actJarInfo = this._GetActJarInfo(this.m_arrFashionActData, (int)this.m_currActJar.activity.id);
				if (actJarInfo != null)
				{
					this.m_selectFashionActJar = actJarInfo;
					this.m_togTab1.isOn = false;
					this.m_togTab1.isOn = true;
					return;
				}
			}
			if (this.m_arrEquipActData.Count > 0)
			{
				this.m_selectEquipActJar = this._GetLevelMatchAct(this.m_arrEquipActData);
				this.m_currActJar = this.m_selectEquipActJar;
				this.m_togTab0.isOn = false;
				this.m_togTab0.isOn = true;
			}
			else if (this.m_arrFashionActData.Count > 0)
			{
				this.m_selectFashionActJar = this._GetLevelMatchAct(this.m_arrFashionActData);
				this.m_currActJar = this.m_selectFashionActJar;
				this.m_togTab1.isOn = false;
				this.m_togTab1.isOn = true;
			}
		}

		// Token: 0x0600E379 RID: 58233 RVA: 0x003A948C File Offset: 0x003A788C
		private void _UpdateRecord()
		{
			if (this.m_recordData != null && this.m_currActJar != null && (ulong)this.m_recordData.jarId == (ulong)((long)this.m_currActJar.jarData.nID))
			{
				this.m_comRecordList.SetElementAmount(this.m_recordData.records.Length);
				this.m_comRecordList.EnsureElementVisable(0);
			}
			else
			{
				this.m_comRecordList.SetElementAmount(0);
			}
		}

		// Token: 0x0600E37A RID: 58234 RVA: 0x003A9506 File Offset: 0x003A7906
		private void _ClearRecord()
		{
			this.m_comRecordList.SetElementAmount(0);
			this.m_recordData = null;
		}

		// Token: 0x0600E37B RID: 58235 RVA: 0x003A951C File Offset: 0x003A791C
		private void _UpdateJarTime(float timeElapsed)
		{
			if (this.m_fUpdateTime <= 0f)
			{
				return;
			}
			this.m_fUpdateTime -= timeElapsed;
			if (this.m_fUpdateTime <= 0f)
			{
				if (this.m_currActJar != null)
				{
					this.m_labActivityTime.text = this._GetEndTimeDesc((int)this.m_currActJar.activity.dueTime);
					if ((ulong)this.m_currActJar.activity.dueTime > (ulong)((long)DataManager<TimeManager>.GetInstance().GetServerTime()))
					{
						this.m_fUpdateTime = 1f;
					}
				}
				else
				{
					this.m_labActivityTime.text = this._GetEndTimeDesc(0);
				}
			}
		}

		// Token: 0x0600E37C RID: 58236 RVA: 0x003A95C8 File Offset: 0x003A79C8
		private string _GetEndTimeDesc(int a_timeStamp)
		{
			int num = a_timeStamp - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			if (num < 0)
			{
				num = 0;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = num % 60;
			int num6 = num / 60;
			if (num6 > 0)
			{
				num2 = num6 % 60;
				num6 /= 60;
				if (num6 > 0)
				{
					num3 = num6 % 24;
					num4 = num6 / 24;
				}
			}
			return TR.Value("jar_activity_remain_time", num4, num3, num2, num5);
		}

		// Token: 0x0600E37D RID: 58237 RVA: 0x003A964C File Offset: 0x003A7A4C
		private ActivityJarFrame.ActJarInfo _GetLevelMatchAct(List<ActivityJarFrame.ActJarInfo> a_arrData)
		{
			a_arrData.Sort((ActivityJarFrame.ActJarInfo var1, ActivityJarFrame.ActJarInfo var2) => var1.jarData.arrFilters[0] - var2.jarData.arrFilters[0]);
			int num = 0;
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			for (int i = 0; i < a_arrData.Count; i++)
			{
				int num2 = a_arrData[i].jarData.arrFilters[0];
				if (num2 <= level)
				{
					num = i;
				}
			}
			if (num >= 0 && num < a_arrData.Count)
			{
				return a_arrData[num];
			}
			return null;
		}

		// Token: 0x0600E37E RID: 58238 RVA: 0x003A96E0 File Offset: 0x003A7AE0
		private ActivityJarFrame.ActJarInfo _GetActJarInfo(List<ActivityJarFrame.ActJarInfo> a_arrData, int a_nActvityID)
		{
			for (int i = 0; i < a_arrData.Count; i++)
			{
				if ((ulong)a_arrData[i].activity.id == (ulong)((long)a_nActvityID))
				{
					return a_arrData[i];
				}
			}
			return null;
		}

		// Token: 0x0600E37F RID: 58239 RVA: 0x003A9726 File Offset: 0x003A7B26
		[UIEventHandle("BG/Close")]
		private void _OnCloseClicked()
		{
			if (ActivityJarFrame.frameType == ActivityJarFrameType.Artifact)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ArtifactFrame>(null, false);
			}
			this.frameMgr.CloseFrame<ActivityJarFrame>(this, false);
		}

		// Token: 0x04008856 RID: 34902
		[UIObject("Content/Tabs/Tab0")]
		private GameObject m_objTab0;

		// Token: 0x04008857 RID: 34903
		[UIControl("Content/Tabs/Tab0", null, 0)]
		private Toggle m_togTab0;

		// Token: 0x04008858 RID: 34904
		[UIObject("Content/Tabs/Overlay0")]
		private GameObject m_objOverlay0;

		// Token: 0x04008859 RID: 34905
		[UIObject("Content/Tabs/Tab1")]
		private GameObject m_objTab1;

		// Token: 0x0400885A RID: 34906
		[UIControl("Content/Tabs/Tab1", null, 0)]
		private Toggle m_togTab1;

		// Token: 0x0400885B RID: 34907
		[UIObject("Content/Tabs/Overlay1")]
		private GameObject m_objOverlay1;

		// Token: 0x0400885C RID: 34908
		[UIControl("Content/Groups/GoldGroup/Activity", null, 0)]
		private Image m_imgActivity;

		// Token: 0x0400885D RID: 34909
		[UIControl("Content/Groups/GoldGroup/Activity/Time", null, 0)]
		private Text m_labActivityTime;

		// Token: 0x0400885E RID: 34910
		[UIControl("Content/Groups/GoldGroup/Activity/Reset", null, 0)]
		private Text m_labResetTime;

		// Token: 0x0400885F RID: 34911
		[UIControl("Content/Groups/GoldGroup/Activity/Rule", null, 0)]
		private Text m_labActivityRule;

		// Token: 0x04008860 RID: 34912
		[UIControl("Content/Groups/GoldGroup/Left/Items", null, 0)]
		private ComUIListScript m_comItemList;

		// Token: 0x04008861 RID: 34913
		[UIControl("Content/Groups/GoldGroup/Right/Discount/Rate", null, 0)]
		private Text m_labDiscountRate;

		// Token: 0x04008862 RID: 34914
		[UIControl("Content/Groups/GoldGroup/Right/Discount/RemainCount", null, 0)]
		private Text m_labDiscountRemainCount;

		// Token: 0x04008863 RID: 34915
		[UIControl("Content/BuyRecord/Content", null, 0)]
		private ComUIListScript m_comRecordList;

		// Token: 0x04008864 RID: 34916
		[UIObject("Content/Groups/GoldGroup/Right/Buy")]
		private GameObject m_objBuyFuncRoot;

		// Token: 0x04008865 RID: 34917
		[UIControl("Content/Groups/GoldGroup/Left/Title/Text", null, 0)]
		private Text m_contentDescText;

		// Token: 0x04008866 RID: 34918
		[UIObject("Content/Groups/GoldGroup/Right/Buy/Func")]
		private GameObject m_objBuyOneFunc;

		// Token: 0x04008867 RID: 34919
		private ActivityJarFrame.ActJarInfo m_selectEquipActJar;

		// Token: 0x04008868 RID: 34920
		private List<ActivityJarFrame.ActJarInfo> m_arrEquipActData = new List<ActivityJarFrame.ActJarInfo>();

		// Token: 0x04008869 RID: 34921
		private ActivityJarFrame.ActJarInfo m_selectFashionActJar;

		// Token: 0x0400886A RID: 34922
		private List<ActivityJarFrame.ActJarInfo> m_arrFashionActData = new List<ActivityJarFrame.ActJarInfo>();

		// Token: 0x0400886B RID: 34923
		private ActivityJarFrame.ActJarInfo m_currActJar;

		// Token: 0x0400886C RID: 34924
		private WorldOpenJarRecordRes m_recordData;

		// Token: 0x0400886D RID: 34925
		private float m_fUpdateTime;

		// Token: 0x0400886E RID: 34926
		public static ActivityJarFrameType frameType;

		// Token: 0x0400886F RID: 34927
		private const string artifactJarActivityBannerPath = "UI/Image/Background/UI_Shenqiguan_Wodezhekou_Di.png:UI_Shenqiguan_Wodezhekou_Di";

		// Token: 0x04008870 RID: 34928
		private Text title;

		// Token: 0x04008871 RID: 34929
		private GameObject getDiscount;

		// Token: 0x04008872 RID: 34930
		private Button btnGetDiscount;

		// Token: 0x04008873 RID: 34931
		private Text Rate;

		// Token: 0x04008874 RID: 34932
		private Text RemainCount;

		// Token: 0x04008875 RID: 34933
		private GameObject mFunc1;

		// Token: 0x04008876 RID: 34934
		private Button mFunc10Btn;

		// Token: 0x04008877 RID: 34935
		private UIGray mFunc10Gray;

		// Token: 0x04008878 RID: 34936
		private Text mFunc10Text;

		// Token: 0x04008879 RID: 34937
		private GameObject activityCloseTip;

		// Token: 0x0400887A RID: 34938
		private GameObject GoldGroup;

		// Token: 0x020016A0 RID: 5792
		private class ActJarInfo
		{
			// Token: 0x0400887F RID: 34943
			public ActivityInfo activity;

			// Token: 0x04008880 RID: 34944
			public JarData jarData;
		}
	}
}
