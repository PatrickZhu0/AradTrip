using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AD3 RID: 6867
	public class BeadUpgradeView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x06010DA5 RID: 69029 RVA: 0x004CE4C0 File Offset: 0x004CC8C0
		private void Awake()
		{
			this.RegisterEventHandler();
		}

		// Token: 0x06010DA6 RID: 69030 RVA: 0x004CE4C8 File Offset: 0x004CC8C8
		private void OnDestroy()
		{
			this.UnRegisterEventHandler();
		}

		// Token: 0x06010DA7 RID: 69031 RVA: 0x004CE4D0 File Offset: 0x004CC8D0
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.InitInterface(linkData);
		}

		// Token: 0x06010DA8 RID: 69032 RVA: 0x004CE4D9 File Offset: 0x004CC8D9
		public void OnEnableView()
		{
			this.m_kBeadItemList.RefreshAllBeadItems();
			this.RefreshBeadItems();
		}

		// Token: 0x06010DA9 RID: 69033 RVA: 0x004CE4EC File Offset: 0x004CC8EC
		public void OnDisableView()
		{
		}

		// Token: 0x06010DAA RID: 69034 RVA: 0x004CE4EE File Offset: 0x004CC8EE
		private void RegisterEventHandler()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSelectExpendBeadItem, new ClientEventSystem.UIEventHandler(this.OnSelectExpendBeadItem));
		}

		// Token: 0x06010DAB RID: 69035 RVA: 0x004CE50B File Offset: 0x004CC90B
		private void UnRegisterEventHandler()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSelectExpendBeadItem, new ClientEventSystem.UIEventHandler(this.OnSelectExpendBeadItem));
		}

		// Token: 0x06010DAC RID: 69036 RVA: 0x004CE528 File Offset: 0x004CC928
		private void OnSelectExpendBeadItem(UIEvent uiEvent)
		{
			ExpendBeadItemData expendBeadItemData = uiEvent.Param1 as ExpendBeadItemData;
			if (expendBeadItemData.TatleCount <= 0)
			{
				ItemComeLink.OnLink(119, 0, false, null, false, false, false, null, string.Empty);
				return;
			}
			if (this.mExpendBeadItemComItem == null)
			{
				this.mExpendBeadItemComItem = ComItemManager.Create(this.mExpendBeadItemParent);
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(expendBeadItemData.ItemID);
			if (commonItemTableDataByID == null)
			{
				return;
			}
			commonItemTableDataByID.Count = 0;
			this.mCurrentSelectExpendBeadID = commonItemTableDataByID.TableID;
			this.mExpendBeadItemComItem.Setup(commonItemTableDataByID, delegate(GameObject obj, ItemData item)
			{
				this.OpenExpendBeadItemFrame(this.mCurrentSelectBeadItem);
			});
			int num = this.GetBeadExpendItemNumber(this.mCurrentSelectBeadItem, this.mCurrentSelectExpendBeadID);
			if (num <= 0)
			{
				num = 0;
			}
			if (num >= expendBeadItemData.Count)
			{
				this.mExpendBeadCount.text = TR.Value("Bead_Expend_Green", num, expendBeadItemData.Count);
			}
			else
			{
				this.mExpendBeadCount.text = TR.Value("Bead_Expend_Red", num, expendBeadItemData.Count);
			}
			this.mExpendBeadCount.CustomActive(true);
			this.mSelectExpendBeadBtn.CustomActive(false);
		}

		// Token: 0x06010DAD RID: 69037 RVA: 0x004CE658 File Offset: 0x004CCA58
		private void InitInterface(SmithShopNewLinkData linkData)
		{
			this.mCanUpgradeRoot = this.mBeadUpgradeBind.GetGameObject("CanUpgradeRoot");
			this.mDoNotUpgradeRoot = this.mBeadUpgradeBind.GetGameObject("DoNotUpgradeRoot");
			this.mBeadItemParent = this.mBeadUpgradeBind.GetGameObject("BeadItemParent");
			this.mBeadItemArrt = this.mBeadUpgradeBind.GetCom<Text>("BeadItemArrt");
			this.mExpendBeadItemParent = this.mBeadUpgradeBind.GetGameObject("ExpendBeadItemParent");
			this.mExpendBeadCount = this.mBeadUpgradeBind.GetCom<Text>("ExpendBeadCount");
			this.mExpendBeadCount.CustomActive(false);
			this.mSelectExpendBeadBtn = this.mBeadUpgradeBind.GetCom<Button>("SelectExpendBeadBtn");
			this.mSelectExpendBeadBtn.onClick.RemoveAllListeners();
			this.mSelectExpendBeadBtn.onClick.AddListener(delegate()
			{
				ItemComeLink.OnLink(119, 0, false, null, false, false, false, null, string.Empty);
			});
			this.mNextLevelItemParent = this.mBeadUpgradeBind.GetGameObject("NextLevelItemParent");
			this.mNextLevelBeadArrt = this.mBeadUpgradeBind.GetCom<Text>("NextLevelBeadArrt");
			this.mAppendArrtRoot = this.mBeadUpgradeBind.GetGameObject("AppendArrtRoot");
			this.mAppendArrtBtn = this.mBeadUpgradeBind.GetCom<Button>("AppendAttrBtn");
			this.mAppendArrtBtn.onClick.RemoveAllListeners();
			this.mAppendArrtBtn.onClick.AddListener(delegate()
			{
				this.OpenRandomPropertiesFrame(this.mCurrentSelectBeadItem);
			});
			this.mDoNotUpgradeItemParent = this.mBeadUpgradeBind.GetGameObject("DoNotUpgradeItemParent");
			this.mDoNotUpgradeItemComItem = ComItemManager.Create(this.mDoNotUpgradeItemParent);
			this.mDoNotUpgradeBeadArrt = this.mBeadUpgradeBind.GetCom<Text>("DoNotUpgradeBeadArrt");
			this.mUpgradeBtnGray = this.mBeadUpgradeBind.GetCom<UIGray>("BtnUpgradeGray");
			this.mUpgradeBtnImage = this.mUpgradeBtnGray.GetComponent<Image>();
			this.mUpgradeBtn = this.mBeadUpgradeBind.GetCom<Button>("BtnUpgrade");
			this.mUpgradeBtn.onClick.RemoveAllListeners();
			this.mUpgradeBtn.onClick.AddListener(delegate()
			{
				if (this.mUpgradeBtn != null)
				{
					this.mUpgradeBtn.enabled = false;
					InvokeMethod.Invoke(this, 0.5f, delegate()
					{
						if (this.mUpgradeBtn != null)
						{
							this.mUpgradeBtn.enabled = true;
						}
					});
				}
				this.OnUpgradeBtnClick();
			});
			this.mNoBeadRoot = this.mBeadUpgradeBind.GetGameObject("NoBeadRoot");
			this.mNoBeadRoot.CustomActive(false);
			this.mNextLevelBeadItemScrollViewRect = this.mBeadUpgradeBind.GetCom<RectTransform>("NextLevelBeadItemScrollView");
			this.mBeadItemScrollView = this.mBeadUpgradeBind.GetCom<ScrollRect>("BeadItemScrollView");
			this.mNextLevelBeadScrollView = this.mBeadUpgradeBind.GetCom<ScrollRect>("NextLevelBeadScrollView");
			this.mDoNotUpgradeScrollView = this.mBeadUpgradeBind.GetCom<ScrollRect>("DoNotUpgradeScrollView");
			this.mBeadItemTemplateBackImg = this.mBeadUpgradeBind.GetCom<Image>("BeadItemTemplateBackImg");
			this.mBextBeadItemTemplateBackImg = this.mBeadUpgradeBind.GetCom<Image>("NextLevelBeadItemTemplateBackImg");
			if (!this.m_kBeadItemList.Initilized)
			{
				this.m_kBeadItemList.Initialize(this.mgoBeadItemScrollView, new BeadItemList.OnItemSelect(this.OnBeadItemSelected), linkData);
			}
			this.RefreshBeadItems();
		}

		// Token: 0x06010DAE RID: 69038 RVA: 0x004CE94C File Offset: 0x004CCD4C
		private void OpenRandomPropertiesFrame(BeadItemModel model)
		{
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(model.beadItemData.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int id = 0;
				if (int.TryParse(tableItem.NextLevPrecbeadID, out id))
				{
					BeadTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(id, string.Empty, string.Empty);
					if (tableItem2 != null && tableItem2.BuffGroup > 0)
					{
						List<int> list = new List<int>();
						foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<BeadRandomBuff>())
						{
							BeadRandomBuff beadRandomBuff = keyValuePair.Value as BeadRandomBuff;
							if (beadRandomBuff != null)
							{
								if (beadRandomBuff.BuffGroup == tableItem2.BuffGroup)
								{
									list.Add(beadRandomBuff.BuffinfoID);
								}
							}
						}
						if (list != null)
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<RandomPropertiesFrame>(FrameLayer.Middle, list, string.Empty);
						}
					}
				}
			}
		}

		// Token: 0x06010DAF RID: 69039 RVA: 0x004CEA44 File Offset: 0x004CCE44
		private void OnUpgradeBtnClick()
		{
			if (this.mCurrentSelectExpendBeadID == 0)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("BeadUpgredeFrame_SelectExpand"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			int beadExpendItemNumber = this.GetBeadExpendItemNumber(this.mCurrentSelectBeadItem, this.mCurrentSelectExpendBeadID);
			if (beadExpendItemNumber <= 0)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("BeadUpgredeFrame_ExpandDeficiency"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			DataManager<BeadCardManager>.GetInstance().SendSceneUpgradePreciousbeadReq(this.mCurrentSelectBeadItem, this.mCurrentSelectExpendBeadID);
		}

		// Token: 0x06010DB0 RID: 69040 RVA: 0x004CEAB0 File Offset: 0x004CCEB0
		private int GetBeadExpendItemNumber(BeadItemModel model, int expendItemId)
		{
			int result;
			if (model.mountedType == 1)
			{
				result = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(expendItemId);
			}
			else if (model.beadItemData.TableID == expendItemId)
			{
				result = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(expendItemId) - 1;
			}
			else
			{
				result = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(expendItemId);
			}
			return result;
		}

		// Token: 0x06010DB1 RID: 69041 RVA: 0x004CEB10 File Offset: 0x004CCF10
		private void OnBeadItemSelected(BeadItemModel model)
		{
			if (this.mCurrentSelectBeadItem == model)
			{
				return;
			}
			this.mCurrentSelectBeadItem = model;
			if (this.BeadItemIsCanUpgrade(model))
			{
				this.mUpgradeBtnGray.enabled = false;
				this.mUpgradeBtnImage.raycastTarget = true;
				this.mCanUpgradeRoot.CustomActive(true);
				this.mDoNotUpgradeRoot.CustomActive(false);
				this.InitCanUpgradeBeadItem(model);
				this.InitExpendBeadItem(model);
				this.InitCanUpgradeNextLevelBeadItem(model);
			}
			else
			{
				this.mCanUpgradeRoot.CustomActive(false);
				this.mDoNotUpgradeRoot.CustomActive(true);
				this.InitDoNotUpgradeBeadItem(model);
				this.mUpgradeBtnGray.enabled = true;
				this.mUpgradeBtnImage.raycastTarget = false;
			}
		}

		// Token: 0x06010DB2 RID: 69042 RVA: 0x004CEBC0 File Offset: 0x004CCFC0
		private bool BeadItemIsCanUpgrade(BeadItemModel model)
		{
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(model.beadItemData.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int result = 0;
				if (tableItem.NextLevPrecbeadID != null)
				{
					int.TryParse(tableItem.NextLevPrecbeadID, out result);
				}
				return result != 0;
			}
			return true;
		}

		// Token: 0x06010DB3 RID: 69043 RVA: 0x004CEC1C File Offset: 0x004CD01C
		private void InitCanUpgradeBeadItem(BeadItemModel model)
		{
			ItemData mBeadItemData = model.beadItemData;
			if (mBeadItemData == null)
			{
				return;
			}
			if (this.mBeadItemComItem == null)
			{
				this.mBeadItemComItem = ComItemManager.Create(this.mBeadItemParent);
			}
			this.mBeadItemComItem.Setup(mBeadItemData, delegate(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					mBeadItemData.BeadPickNumber = model.beadPickNumber;
					DataManager<ItemTipManager>.GetInstance().ShowTip(mBeadItemData, null, 4, true, false, true);
				}
			});
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(model.beadItemData.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mBeadItemArrt.text = string.Format("当前属性:\n{0}", DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(tableItem.ID, false));
			}
			this.mBeadItemScrollView.verticalNormalizedPosition = 0f;
			this.mBeadItemScrollView.verticalNormalizedPosition = 1f;
			this.mBeadItemTemplateBackImg.raycastTarget = false;
		}

		// Token: 0x06010DB4 RID: 69044 RVA: 0x004CED10 File Offset: 0x004CD110
		private void InitExpendBeadItem(BeadItemModel model)
		{
			this.mCurrentSelectExpendBeadID = 0;
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(model.beadItemData.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string[] array = tableItem.UpConsume.Split(new char[]
				{
					'|'
				});
				if (array.Length > 1)
				{
					this.mExpendBeadCount.CustomActive(false);
					this.mSelectExpendBeadBtn.CustomActive(true);
					this.mSelectExpendBeadBtn.onClick.RemoveAllListeners();
					this.mSelectExpendBeadBtn.onClick.AddListener(delegate()
					{
						this.OpenExpendBeadItemFrame(this.mCurrentSelectBeadItem);
					});
				}
				else
				{
					this.mSelectExpendBeadBtn.CustomActive(false);
					this.mSelectExpendBeadBtn.onClick.RemoveAllListeners();
					this.mExpendBeadCount.CustomActive(true);
					string[] array2 = array[0].Split(new char[]
					{
						'_'
					});
					if (array2 != null)
					{
						int a_nTableID = 0;
						int num = 0;
						int.TryParse(array2[0], out a_nTableID);
						int.TryParse(array2[1], out num);
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(a_nTableID);
						if (commonItemTableDataByID != null)
						{
							commonItemTableDataByID.Count = 0;
							this.mCurrentSelectExpendBeadID = commonItemTableDataByID.TableID;
							if (this.mExpendBeadItemComItem == null)
							{
								this.mExpendBeadItemComItem = ComItemManager.Create(this.mExpendBeadItemParent);
							}
							ComItem comItem = this.mExpendBeadItemComItem;
							ItemData item = commonItemTableDataByID;
							if (BeadUpgradeView.<>f__mg$cache0 == null)
							{
								BeadUpgradeView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
							}
							comItem.Setup(item, BeadUpgradeView.<>f__mg$cache0);
						}
						int num2 = this.GetBeadExpendItemNumber(this.mCurrentSelectBeadItem, this.mCurrentSelectExpendBeadID);
						if (num2 <= 0)
						{
							num2 = 0;
						}
						if (num2 >= num)
						{
							this.mExpendBeadCount.text = TR.Value("Bead_Expend_Green", num2, num);
						}
						else
						{
							this.mExpendBeadCount.text = TR.Value("Bead_Expend_Red", num2, num);
						}
					}
				}
			}
		}

		// Token: 0x06010DB5 RID: 69045 RVA: 0x004CEEF8 File Offset: 0x004CD2F8
		private void OpenExpendBeadItemFrame(BeadItemModel model)
		{
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(model.beadItemData.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string[] array = tableItem.UpConsume.Split(new char[]
				{
					'|'
				});
				if (array.Length > 1)
				{
					this.mExpendBeadItemDatas.Clear();
					for (int i = 0; i < array.Length; i++)
					{
						string[] array2 = array[i].Split(new char[]
						{
							'_'
						});
						if (array2 != null)
						{
							int num = 0;
							int count = 0;
							int.TryParse(array2[0], out num);
							int.TryParse(array2[1], out count);
							int beadExpendItemNumber = this.GetBeadExpendItemNumber(this.mCurrentSelectBeadItem, num);
							ExpendBeadItemData item = new ExpendBeadItemData(num, beadExpendItemNumber, count);
							this.mExpendBeadItemDatas.Add(item);
						}
					}
					this.mExpendBeadItemDatas.Sort();
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ExpendBeadItemFrame>(FrameLayer.Middle, this.mExpendBeadItemDatas, string.Empty);
				}
			}
		}

		// Token: 0x06010DB6 RID: 69046 RVA: 0x004CEFF0 File Offset: 0x004CD3F0
		private void InitCanUpgradeNextLevelBeadItem(BeadItemModel model)
		{
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(model.beadItemData.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int id = 0;
				if (int.TryParse(tableItem.NextLevPrecbeadID, out id))
				{
					BeadTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(id, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem2.ID);
						if (commonItemTableDataByID != null)
						{
							if (this.mNextLevelItemComItem == null)
							{
								this.mNextLevelItemComItem = ComItemManager.Create(this.mNextLevelItemParent);
							}
							ComItem comItem = this.mNextLevelItemComItem;
							ItemData item = commonItemTableDataByID;
							if (BeadUpgradeView.<>f__mg$cache1 == null)
							{
								BeadUpgradeView.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
							}
							comItem.Setup(item, BeadUpgradeView.<>f__mg$cache1);
							this.mNextLevelBeadArrt.text = string.Format("升级属性:\n{0}", DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(tableItem2.ID, false));
						}
						if (tableItem2.BuffGroup > 0)
						{
							this.mAppendArrtRoot.CustomActive(true);
							this.mNextLevelBeadItemScrollViewRect.sizeDelta = new Vector2(397f, 85f);
						}
						else
						{
							this.mAppendArrtRoot.CustomActive(false);
							this.mNextLevelBeadItemScrollViewRect.sizeDelta = new Vector2(397f, 130f);
						}
					}
				}
			}
			this.mNextLevelBeadScrollView.verticalNormalizedPosition = 0f;
			this.mNextLevelBeadScrollView.verticalNormalizedPosition = 1f;
			this.mBextBeadItemTemplateBackImg.raycastTarget = false;
		}

		// Token: 0x06010DB7 RID: 69047 RVA: 0x004CF164 File Offset: 0x004CD564
		private void InitDoNotUpgradeBeadItem(BeadItemModel model)
		{
			ItemData mBeadItemData = model.beadItemData;
			if (mBeadItemData == null)
			{
				return;
			}
			this.mDoNotUpgradeItemComItem.Setup(mBeadItemData, delegate(GameObject obj, ItemData item)
			{
				if (item != null)
				{
					mBeadItemData.BeadAdditiveAttributeBuffID = model.buffID;
					mBeadItemData.BeadPickNumber = model.beadPickNumber;
					DataManager<ItemTipManager>.GetInstance().ShowTip(mBeadItemData, null, 4, true, false, true);
				}
			});
			BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(model.beadItemData.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (model.buffID > 0)
				{
					this.mDoNotUpgradeBeadArrt.text = string.Format("当前属性:\n{0}", DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(tableItem.ID, false)) + "\n" + string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(model.buffID));
				}
				else
				{
					this.mDoNotUpgradeBeadArrt.text = string.Format("当前属性:\n{0}", DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(tableItem.ID, false));
				}
			}
			this.mDoNotUpgradeScrollView.verticalNormalizedPosition = 0f;
			this.mDoNotUpgradeScrollView.verticalNormalizedPosition = 1f;
		}

		// Token: 0x06010DB8 RID: 69048 RVA: 0x004CF290 File Offset: 0x004CD690
		private void RefreshBeadItems()
		{
			if (this.m_kBeadItemList.GetBeadItemList().Count <= 0)
			{
				this.mNoBeadRoot.CustomActive(true);
				this.mAppendArrtRoot.CustomActive(false);
				this.mUpgradeBtnGray.enabled = true;
				this.mUpgradeBtnImage.raycastTarget = false;
			}
			else
			{
				this.mNoBeadRoot.CustomActive(false);
			}
		}

		// Token: 0x0400ACF0 RID: 44272
		[SerializeField]
		private ComCommonBind mBeadUpgradeBind;

		// Token: 0x0400ACF1 RID: 44273
		[SerializeField]
		private GameObject mgoBeadItemScrollView;

		// Token: 0x0400ACF2 RID: 44274
		private GameObject mCanUpgradeRoot;

		// Token: 0x0400ACF3 RID: 44275
		private GameObject mDoNotUpgradeRoot;

		// Token: 0x0400ACF4 RID: 44276
		private GameObject mBeadItemParent;

		// Token: 0x0400ACF5 RID: 44277
		private ComItem mBeadItemComItem;

		// Token: 0x0400ACF6 RID: 44278
		private Text mBeadItemArrt;

		// Token: 0x0400ACF7 RID: 44279
		private GameObject mExpendBeadItemParent;

		// Token: 0x0400ACF8 RID: 44280
		private ComItem mExpendBeadItemComItem;

		// Token: 0x0400ACF9 RID: 44281
		private Text mExpendBeadCount;

		// Token: 0x0400ACFA RID: 44282
		private Button mSelectExpendBeadBtn;

		// Token: 0x0400ACFB RID: 44283
		private GameObject mNextLevelItemParent;

		// Token: 0x0400ACFC RID: 44284
		private ComItem mNextLevelItemComItem;

		// Token: 0x0400ACFD RID: 44285
		private Text mNextLevelBeadArrt;

		// Token: 0x0400ACFE RID: 44286
		private GameObject mAppendArrtRoot;

		// Token: 0x0400ACFF RID: 44287
		private Button mAppendArrtBtn;

		// Token: 0x0400AD00 RID: 44288
		private GameObject mDoNotUpgradeItemParent;

		// Token: 0x0400AD01 RID: 44289
		private ComItem mDoNotUpgradeItemComItem;

		// Token: 0x0400AD02 RID: 44290
		private Text mDoNotUpgradeBeadArrt;

		// Token: 0x0400AD03 RID: 44291
		private UIGray mUpgradeBtnGray;

		// Token: 0x0400AD04 RID: 44292
		private Image mUpgradeBtnImage;

		// Token: 0x0400AD05 RID: 44293
		private Button mUpgradeBtn;

		// Token: 0x0400AD06 RID: 44294
		private GameObject mNoBeadRoot;

		// Token: 0x0400AD07 RID: 44295
		private RectTransform mNextLevelBeadItemScrollViewRect;

		// Token: 0x0400AD08 RID: 44296
		private ScrollRect mBeadItemScrollView;

		// Token: 0x0400AD09 RID: 44297
		private ScrollRect mNextLevelBeadScrollView;

		// Token: 0x0400AD0A RID: 44298
		private ScrollRect mDoNotUpgradeScrollView;

		// Token: 0x0400AD0B RID: 44299
		private Image mBeadItemTemplateBackImg;

		// Token: 0x0400AD0C RID: 44300
		private Image mBextBeadItemTemplateBackImg;

		// Token: 0x0400AD0D RID: 44301
		private BeadItemModel mCurrentSelectBeadItem;

		// Token: 0x0400AD0E RID: 44302
		private int mCurrentSelectExpendBeadID;

		// Token: 0x0400AD0F RID: 44303
		private List<ExpendBeadItemData> mExpendBeadItemDatas = new List<ExpendBeadItemData>();

		// Token: 0x0400AD10 RID: 44304
		private BeadItemList m_kBeadItemList = new BeadItemList();

		// Token: 0x0400AD12 RID: 44306
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x0400AD13 RID: 44307
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;
	}
}
