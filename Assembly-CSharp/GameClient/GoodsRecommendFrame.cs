using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200176E RID: 5998
	internal class GoodsRecommendFrame : ClientFrame
	{
		// Token: 0x0600ECBD RID: 60605 RVA: 0x003F38CA File Offset: 0x003F1CCA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mall/GoodsRecommend";
		}

		// Token: 0x0600ECBE RID: 60606 RVA: 0x003F38D4 File Offset: 0x003F1CD4
		protected override void _OnOpenFrame()
		{
			if (DataManager<MallDataManager>.GetInstance().GoodsRecommend == null)
			{
				Logger.LogErrorFormat("GoodsRecommend is null", new object[0]);
				return;
			}
			MallNewFrame mallNewFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(MallNewFrame)) as MallNewFrame;
			this.BindUIEvent();
			this.mTips.CustomActive(true);
			this.mRemainTimeGO.CustomActive(false);
			DataManager<MallDataManager>.GetInstance().SendGoodsRecommendReq();
		}

		// Token: 0x0600ECBF RID: 60607 RVA: 0x003F3944 File Offset: 0x003F1D44
		protected override void _OnCloseFrame()
		{
			this._ClearData();
			this.UnBindUIEvent();
			MallNewFrame mallNewFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(MallNewFrame)) as MallNewFrame;
		}

		// Token: 0x0600ECC0 RID: 60608 RVA: 0x003F3977 File Offset: 0x003F1D77
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GoodsRecommend, new ClientEventSystem.UIEventHandler(this.SetActiceGoodsRecommend));
		}

		// Token: 0x0600ECC1 RID: 60609 RVA: 0x003F3994 File Offset: 0x003F1D94
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GoodsRecommend, new ClientEventSystem.UIEventHandler(this.SetActiceGoodsRecommend));
		}

		// Token: 0x0600ECC2 RID: 60610 RVA: 0x003F39B1 File Offset: 0x003F1DB1
		private void SetActiceGoodsRecommend(UIEvent uiEvent)
		{
			this._initData();
			this._getGoodsList();
			this._sortGoodsList();
			this.mTips.CustomActive(false);
			this.mRemainTimeGO.CustomActive(true);
			this._InitBt();
			this.UpdateGoodsData(this.NowIndex);
		}

		// Token: 0x0600ECC3 RID: 60611 RVA: 0x003F39EF File Offset: 0x003F1DEF
		private void _initData()
		{
			this.NowIndex = 0;
			this.MyGoods.Clear();
			this.NowEndTime = 0;
			Array.Clear(this.ChildElement, 0, this.ChildElement.Length);
		}

		// Token: 0x0600ECC4 RID: 60612 RVA: 0x003F3A1E File Offset: 0x003F1E1E
		protected void _ClearData()
		{
			base.StopCoroutine(this.UpdateTime());
			this.NowIndex = -1;
			this.MyGoods.Clear();
			Array.Clear(this.ChildElement, 0, this.ChildElement.Length);
		}

		// Token: 0x0600ECC5 RID: 60613 RVA: 0x003F3A54 File Offset: 0x003F1E54
		private void _getGoodsList()
		{
			for (int i = 0; i < DataManager<MallDataManager>.GetInstance().GoodsRecommend.Count; i++)
			{
				MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)DataManager<MallDataManager>.GetInstance().GoodsRecommend[i].id, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("mallitemdata is null", new object[0]);
					return;
				}
				int personalTailID = tableItem.PersonalTailID;
				if (personalTailID != 0)
				{
					PersonalTailorTriggerTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PersonalTailorTriggerTable>(personalTailID, string.Empty, string.Empty);
					if (tableItem2 == null)
					{
						Logger.LogErrorFormat("PersonalTailorTriggerTable is null", new object[0]);
						return;
					}
					if (tableItem2.TypeID == 5)
					{
						string[] array = tableItem.giftpackitems.Split(new char[]
						{
							'|'
						});
						for (int j = 0; j < array.Length; j++)
						{
							string[] array2 = array[i].Split(new char[]
							{
								':'
							});
							int id = 0;
							int.TryParse(array2[0], out id);
							ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
							if (tableItem3 == null)
							{
								Logger.LogErrorFormat("itemtabledata is null", new object[0]);
								return;
							}
							if (tableItem3.TimeLeft == 604800)
							{
								this.BuyFashion[0] = DataManager<MallDataManager>.GetInstance().GoodsRecommend[i];
								break;
							}
							if (tableItem3.TimeLeft == 2592000)
							{
								this.BuyFashion[1] = DataManager<MallDataManager>.GetInstance().GoodsRecommend[i];
								break;
							}
							if (tableItem3.TimeLeft == 0)
							{
								this.MyGoods.Add(DataManager<MallDataManager>.GetInstance().GoodsRecommend[i]);
								this.BuyFashion[2] = DataManager<MallDataManager>.GetInstance().GoodsRecommend[i];
								break;
							}
						}
					}
					else
					{
						this.MyGoods.Add(DataManager<MallDataManager>.GetInstance().GoodsRecommend[i]);
					}
				}
				else
				{
					Logger.LogErrorFormat("PersonTaler is error:{0}", new object[]
					{
						(int)DataManager<MallDataManager>.GetInstance().GoodsRecommend[i].id
					});
				}
			}
		}

		// Token: 0x0600ECC6 RID: 60614 RVA: 0x003F3C80 File Offset: 0x003F2080
		private void _sortGoodsList()
		{
			this.MyGoods.Sort(delegate(MallItemInfo x, MallItemInfo y)
			{
				int result;
				if (x.starttime.CompareTo(y.starttime) > 0)
				{
					result = -1;
				}
				else
				{
					result = 1;
				}
				return result;
			});
		}

		// Token: 0x0600ECC7 RID: 60615 RVA: 0x003F3CAA File Offset: 0x003F20AA
		private void _InitBt()
		{
			if (this.MyGoods.Count > 1)
			{
				this.mGoRight.gameObject.CustomActive(true);
			}
			this.mBuy.gameObject.CustomActive(true);
		}

		// Token: 0x0600ECC8 RID: 60616 RVA: 0x003F3CE0 File Offset: 0x003F20E0
		private void UpdateGoodsData(int index)
		{
			this.mGoldTime.CustomActive(false);
			Array.Clear(this.ChildElement, 0, this.ChildElement.Length);
			this.NowEndTime = (int)this.MyGoods[index].endtime;
			this._OnUpdate(this.MyGoods[index].endtime);
			MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)this.MyGoods[index].id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int personalTailID = tableItem.PersonalTailID;
				PersonalTailorTriggerTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PersonalTailorTriggerTable>(personalTailID, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogErrorFormat("tabledata is null私人物品配置表", new object[0]);
				}
				else if (tableItem2.BgPath != string.Empty)
				{
					ETCImageLoader.LoadSprite(ref this.mBG, tableItem2.BgPath, true);
				}
				else
				{
					JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
					if (tableItem3 == null)
					{
						Logger.LogErrorFormat("JobTableData is null From xzl", new object[0]);
					}
					string goodsRecommendBG = tableItem3.GoodsRecommendBG;
					ETCImageLoader.LoadSprite(ref this.mBG, goodsRecommendBG, true);
				}
				this.mGoodsFashion.CustomActive(false);
				this.mGoodsStone.CustomActive(false);
				this.mGoodsTitle.CustomActive(false);
				this.mGoodsBuySomeThing.CustomActive(false);
				if (tableItem2.TypeID == 1)
				{
					this.mBuy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(373f, -220f);
					this.mGoodsStone.CustomActive(true);
					this._UpdateLimitTime(index);
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.MyGoods[index].itemid, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("ItemDetailData is null From XZL", new object[0]);
						return;
					}
					ComItem comItem = this.mStoreElement.GetComponentInChildren<ComItem>();
					if (comItem == null)
					{
						comItem = base.CreateComItem(this.mStoreElement.gameObject);
					}
					comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
					{
						this.OnShowTipsFromJob((int)this.MyGoods[index].itemid);
					});
					ItemTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.MyGoods[index].itemid, string.Empty, string.Empty);
					if (tableItem4 == null)
					{
						Logger.LogErrorFormat("From xzl ItemTableData is null", new object[0]);
						return;
					}
					this.mStoreName.text = tableItem4.Name;
				}
				if (tableItem2.TypeID == 2)
				{
					this.mBuy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(467f, -251f);
					this.mGoodsTitle.CustomActive(true);
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable((int)this.MyGoods[index].itemid, 100, 0);
					if (itemData2 == null)
					{
						Logger.LogErrorFormat("ItemDetailData is null From XZL", new object[0]);
						return;
					}
					ComItem comItem2 = this.mTitleElement.GetComponentInChildren<ComItem>();
					if (comItem2 == null)
					{
						comItem2 = base.CreateComItem(this.mTitleElement.gameObject);
					}
					comItem2.Setup(itemData2, delegate(GameObject Obj, ItemData sitem)
					{
						this.OnShowTipsFromJob((int)this.MyGoods[index].itemid);
					});
				}
				if (tableItem2.TypeID == 3)
				{
					this.mBuy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(375f, -296f);
					this.mGoodsBuySomeThing.CustomActive(true);
					ItemData itemData3 = ItemDataManager.CreateItemDataFromTable((int)this.MyGoods[index].itemid, 100, 0);
					if (itemData3 == null)
					{
						Logger.LogErrorFormat("ItemDetailData is null From XZL", new object[0]);
						return;
					}
					ComItem comItem3 = this.mSomeThingElement.GetComponentInChildren<ComItem>();
					if (comItem3 == null)
					{
						comItem3 = base.CreateComItem(this.mSomeThingElement.gameObject);
					}
					comItem3.Setup(itemData3, delegate(GameObject Obj, ItemData sitem)
					{
						this.OnShowTipsFromJob((int)this.MyGoods[index].itemid);
					});
					ItemTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.MyGoods[index].itemid, string.Empty, string.Empty);
					if (tableItem5 == null)
					{
						Logger.LogErrorFormat("ItemTableData is null From XZL", new object[0]);
						return;
					}
					this.mSomeThingName.text = tableItem5.Name;
				}
				if (tableItem2.TypeID == 4)
				{
					this.mGoldTime.CustomActive(true);
					this.mBuy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(587f, -299f);
				}
				if (tableItem2.TypeID == 5)
				{
					RectTransform[] array = new RectTransform[5];
					array = null;
					MallItemTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)this.MyGoods[index].id, string.Empty, string.Empty);
					if (tableItem6 == null)
					{
						Logger.LogErrorFormat("mallitemdata is null from xzl", new object[0]);
						return;
					}
					JobTable tableItem7 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
					if (tableItem7 == null)
					{
						Logger.LogErrorFormat("Jobtabledata is null From xzl", new object[0]);
						return;
					}
					if (tableItem7.prejob == tableItem6.jobtype || DataManager<PlayerBaseData>.GetInstance().JobTableID == tableItem6.jobtype)
					{
						this.mGoodsFashion.CustomActive(true);
						int jobtype = tableItem6.jobtype;
						if (jobtype != 10)
						{
							if (jobtype != 20)
							{
								if (jobtype != 30)
								{
									if (jobtype != 40)
									{
										if (jobtype == 50)
										{
											array = this.NvQiangFashionElement;
											this.mBuy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(261f, -352f);
											this.mGuiJian.CustomActive(false);
											this.mNanQiang.CustomActive(false);
											this.mLuoLi.CustomActive(false);
											this.mGeDou.CustomActive(false);
											this.mNvQiang.CustomActive(true);
										}
									}
									else
									{
										array = this.GeDouFashionElement;
										this.mBuy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(345f, -304f);
										this.mGuiJian.CustomActive(false);
										this.mNanQiang.CustomActive(false);
										this.mLuoLi.CustomActive(false);
										this.mGeDou.CustomActive(true);
										this.mNvQiang.CustomActive(false);
									}
								}
								else
								{
									array = this.LuoLiFashionElement;
									this.mBuy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(316f, -338f);
									this.mGuiJian.CustomActive(false);
									this.mNanQiang.CustomActive(false);
									this.mLuoLi.CustomActive(true);
									this.mGeDou.CustomActive(false);
									this.mNvQiang.CustomActive(false);
								}
							}
							else
							{
								array = this.NanQiangFashionElement;
								this.mBuy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(318f, -370f);
								this.mGuiJian.CustomActive(false);
								this.mNanQiang.CustomActive(true);
								this.mLuoLi.CustomActive(false);
								this.mGeDou.CustomActive(false);
								this.mNvQiang.CustomActive(false);
							}
						}
						else
						{
							array = this.GuiJianFashionElement;
							this.mBuy.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(344f, -303f);
							this.mGuiJian.CustomActive(true);
							this.mNanQiang.CustomActive(false);
							this.mLuoLi.CustomActive(false);
							this.mGeDou.CustomActive(false);
							this.mNvQiang.CustomActive(false);
						}
						string[] array2 = tableItem6.giftpackitems.Split(new char[]
						{
							'|'
						});
						for (int i = 0; i < array2.Length; i++)
						{
							string[] array3 = array2[i].Split(new char[]
							{
								':'
							});
							int result_ID = 0;
							int.TryParse(array3[0], out result_ID);
							if (ItemDataManager.CreateItemDataFromTable(result_ID, 100, 0) == null)
							{
								Logger.LogErrorFormat("ItemDetailData is null from XZL", new object[0]);
								return;
							}
							if (array[i] == null)
							{
								Logger.LogErrorFormat("Fashionelement[{0}] is null", new object[]
								{
									i
								});
								return;
							}
							ItemTable tableItem8 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(result_ID, string.Empty, string.Empty);
							if (tableItem8 == null)
							{
								Logger.LogErrorFormat("ItemTableData is null From XZL", new object[0]);
								return;
							}
							Button component = array[i].GetComponent<Button>();
							if (component == null)
							{
								Logger.LogErrorFormat("can not find button in Item", new object[0]);
								return;
							}
							Image component2 = array[i].GetComponent<Image>();
							if (component2 == null)
							{
								Logger.LogErrorFormat("can not find Image in Item", new object[0]);
								return;
							}
							string icon = tableItem8.Icon;
							if (icon == null)
							{
								Logger.LogErrorFormat("ImagePath is null From XZL", new object[0]);
								return;
							}
							ETCImageLoader.LoadSprite(ref component2, icon, true);
							component.onClick.RemoveAllListeners();
							component.onClick.AddListener(delegate()
							{
								this.OnShowTipsFromJob(result_ID);
							});
						}
					}
				}
				return;
			}
			Logger.LogErrorFormat("MallItemdata is null", new object[0]);
		}

		// Token: 0x0600ECC9 RID: 60617 RVA: 0x003F4664 File Offset: 0x003F2A64
		private void _UpdateLimitTime(int index)
		{
			bool flag = false;
			int leftLimitNum = Utility.GetLeftLimitNum(this.MyGoods[index], ref flag);
			int limitnum = (int)this.MyGoods[index].limitnum;
			if (flag)
			{
				this.mLimitTime.text = string.Format("每日限购:{0}/{1}", leftLimitNum, limitnum);
			}
			else
			{
				this.mLimitTime.text = string.Format("限购:{0}/5", leftLimitNum);
			}
		}

		// Token: 0x0600ECCA RID: 60618 RVA: 0x003F46E0 File Offset: 0x003F2AE0
		private void OnShowTipsFromJob(int result)
		{
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600ECCB RID: 60619 RVA: 0x003F4707 File Offset: 0x003F2B07
		private void _RegistenUIEvent()
		{
		}

		// Token: 0x0600ECCC RID: 60620 RVA: 0x003F4709 File Offset: 0x003F2B09
		private void _UnRegistenUIEvent()
		{
		}

		// Token: 0x0600ECCD RID: 60621 RVA: 0x003F470B File Offset: 0x003F2B0B
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600ECCE RID: 60622 RVA: 0x003F4710 File Offset: 0x003F2B10
		protected override void _OnUpdate(float LastTime)
		{
			float num = 0f;
			int num2 = this.NowEndTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			int num3 = num2 / 60 / 60;
			int num4 = num2 / 60 % 60;
			int num5 = num2 % 60;
			string arg = string.Empty;
			string arg2 = string.Empty;
			string arg3 = string.Empty;
			if (num3 != 0)
			{
				arg = string.Format("{0}小时", num3);
			}
			if (num4 != 0 || num3 != 0)
			{
				arg2 = string.Format("{0}分", num4);
			}
			if (num5 != 0 || num4 != 0 || num3 != 0)
			{
				arg3 = string.Format("{0}秒", num5);
			}
			this.mRemainTime.text = string.Format("剩余时间：{0}{1}{2}", arg, arg2, arg3);
			float time = Time.time;
			if (time - num >= 1f)
			{
				this.mTitleTime.text = this.mRemainTime.text;
				this.mStoneTime.text = this.mRemainTime.text;
				this.mBuySomethingTime.text = this.mRemainTime.text;
				this.mGuiJianTime.text = this.mRemainTime.text;
				this.mNanQiangTime.text = this.mRemainTime.text;
				this.mLuoLiTime.text = this.mRemainTime.text;
				this.mGeDouTime.text = this.mRemainTime.text;
				this.mNvQiangTime.text = this.mRemainTime.text;
			}
		}

		// Token: 0x0600ECCF RID: 60623 RVA: 0x003F48A8 File Offset: 0x003F2CA8
		protected override void _bindExUI()
		{
			this.mGoRight = this.mBind.GetCom<Button>("GoRight");
			this.mGoRight.onClick.AddListener(new UnityAction(this._onGoRightButtonClick));
			this.mGoLeft = this.mBind.GetCom<Button>("GoLeft");
			this.mGoLeft.onClick.AddListener(new UnityAction(this._onGoLeftButtonClick));
			this.mRemainTime = this.mBind.GetCom<Text>("RemainTime");
			this.mBuy = this.mBind.GetCom<Button>("Buy");
			this.mBuy.onClick.AddListener(new UnityAction(this._onBuyButtonClick));
			this.mStoreElement = this.mBind.GetGameObject("StoreElement");
			this.mStoreName = this.mBind.GetCom<Text>("StoreName");
			this.mLimitTime = this.mBind.GetCom<Text>("LimitTime");
			this.mTitleElement = this.mBind.GetGameObject("TitleElement");
			this.mSomeThingElement = this.mBind.GetGameObject("SomeThingElement");
			this.mSomeThingName = this.mBind.GetCom<Text>("SomeThingName");
			this.mBG = this.mBind.GetCom<Image>("BG");
			this.mGoodsFashion = this.mBind.GetGameObject("GoodsFashion");
			this.mGoodsStone = this.mBind.GetGameObject("GoodsStone");
			this.mGoodsTitle = this.mBind.GetGameObject("GoodsTitle");
			this.mGoodsBuySomeThing = this.mBind.GetGameObject("GoodsBuySomeThing");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mTips = this.mBind.GetGameObject("Tips");
			this.mRemainTimeGO = this.mBind.GetGameObject("RemainTimeGO");
			this.mTitleTime = this.mBind.GetCom<Text>("TitleTime");
			this.mStoneTime = this.mBind.GetCom<Text>("StoneTime");
			this.mBuySomethingTime = this.mBind.GetCom<Text>("BuySomethingTime");
			this.mGuiJianTime = this.mBind.GetCom<Text>("GuiJianTime");
			this.mNanQiangTime = this.mBind.GetCom<Text>("NanQiangTime");
			this.mNvQiangTime = this.mBind.GetCom<Text>("NvQiangTime");
			this.mLuoLiTime = this.mBind.GetCom<Text>("LuoLiTime");
			this.mGeDouTime = this.mBind.GetCom<Text>("GeDouTime");
			this.mGuiJian = this.mBind.GetGameObject("GuiJian");
			this.mNanQiang = this.mBind.GetGameObject("NanQiang");
			this.mNvQiang = this.mBind.GetGameObject("NvQiang");
			this.mLuoLi = this.mBind.GetGameObject("LuoLi");
			this.mGeDou = this.mBind.GetGameObject("GeDou");
			this.mGoldTime = this.mBind.GetGameObject("GoldTime");
		}

		// Token: 0x0600ECD0 RID: 60624 RVA: 0x003F4BE8 File Offset: 0x003F2FE8
		protected override void _unbindExUI()
		{
			this.mGoRight.onClick.RemoveListener(new UnityAction(this._onGoRightButtonClick));
			this.mGoRight = null;
			this.mGoLeft.onClick.RemoveListener(new UnityAction(this._onGoLeftButtonClick));
			this.mGoLeft = null;
			this.mRemainTime = null;
			this.mBuy.onClick.RemoveListener(new UnityAction(this._onBuyButtonClick));
			this.mBuy = null;
			this.mStoreElement = null;
			this.mStoreName = null;
			this.mLimitTime = null;
			this.mTitleElement = null;
			this.mSomeThingElement = null;
			this.mSomeThingName = null;
			this.mBG = null;
			this.mGoodsFashion = null;
			this.mGoodsStone = null;
			this.mGoodsTitle = null;
			this.mGoodsBuySomeThing = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mTips = null;
			this.mRemainTime = null;
			this.mTitleTime = null;
			this.mStoneTime = null;
			this.mBuySomethingTime = null;
			this.mGuiJianTime = null;
			this.mNanQiangTime = null;
			this.mNvQiangTime = null;
			this.mLuoLiTime = null;
			this.mGeDouTime = null;
			this.mGuiJian = null;
			this.mNanQiang = null;
			this.mNvQiang = null;
			this.mLuoLi = null;
			this.mGeDou = null;
			this.mGoldTime = null;
		}

		// Token: 0x0600ECD1 RID: 60625 RVA: 0x003F4D48 File Offset: 0x003F3148
		private void _onGoRightButtonClick()
		{
			if (this.NowIndex < this.MyGoods.Count - 1)
			{
				this.UpdateGoodsData(++this.NowIndex);
				this.mGoLeft.gameObject.CustomActive(true);
				if (this.NowIndex == this.MyGoods.Count - 1)
				{
					this.mGoRight.gameObject.CustomActive(false);
				}
				return;
			}
		}

		// Token: 0x0600ECD2 RID: 60626 RVA: 0x003F4DC4 File Offset: 0x003F31C4
		private void _onGoLeftButtonClick()
		{
			if (this.NowIndex > 0)
			{
				this.UpdateGoodsData(--this.NowIndex);
				this.mGoRight.gameObject.CustomActive(true);
				if (this.NowIndex == 0)
				{
					this.mGoLeft.gameObject.CustomActive(false);
				}
				return;
			}
		}

		// Token: 0x0600ECD3 RID: 60627 RVA: 0x003F4E28 File Offset: 0x003F3228
		private void _onBuyButtonClick()
		{
			int id = 0;
			MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)this.MyGoods[this.NowIndex].id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				id = tableItem.PersonalTailID;
			}
			else
			{
				Logger.LogErrorFormat("MallItemdata is null", new object[0]);
			}
			PersonalTailorTriggerTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PersonalTailorTriggerTable>(id, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("From xzl tabledata is null", new object[0]);
				return;
			}
			MallItemInfo userData = this.MyGoods[this.NowIndex];
			if (tableItem2.TypeID != 5)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, userData, string.Empty);
				if (tableItem2.TypeID == 1)
				{
					base.StopCoroutine(this.UpdateTime());
					base.StartCoroutine(this.UpdateTime());
				}
			}
			else if (tableItem2.TypeID == 5)
			{
				List<MallItemInfo> list = new List<MallItemInfo>();
				for (int i = 0; i < 3; i++)
				{
					list.Add(this.BuyFashion[i]);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionBuyFrame>(FrameLayer.Middle, list, string.Empty);
			}
		}

		// Token: 0x0600ECD4 RID: 60628 RVA: 0x003F4F58 File Offset: 0x003F3358
		private IEnumerator UpdateTime()
		{
			yield return Yielders.GetWaitForSeconds(2f);
			this._UpdateLimitTime(this.NowIndex);
			yield break;
		}

		// Token: 0x0600ECD5 RID: 60629 RVA: 0x003F4F73 File Offset: 0x003F3373
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<GoodsRecommendFrame>(this, false);
		}

		// Token: 0x04009006 RID: 36870
		private const int GoodsSum = 7;

		// Token: 0x04009007 RID: 36871
		private int NowEndTime;

		// Token: 0x04009008 RID: 36872
		private int NowIndex = -1;

		// Token: 0x04009009 RID: 36873
		private List<MallItemInfo> MyGoods = new List<MallItemInfo>();

		// Token: 0x0400900A RID: 36874
		private MallItemInfo[] BuyFashion = new MallItemInfo[3];

		// Token: 0x0400900B RID: 36875
		private RectTransform[] ChildElement = new RectTransform[20];

		// Token: 0x0400900C RID: 36876
		[UIControl("Middle/GoodsFashion/MiddleGuiJian/element{0}", typeof(RectTransform), 1)]
		private RectTransform[] GuiJianFashionElement = new RectTransform[5];

		// Token: 0x0400900D RID: 36877
		[UIControl("Middle/GoodsFashion/MiddleNanQiang/element{0}", typeof(RectTransform), 1)]
		private RectTransform[] NanQiangFashionElement = new RectTransform[5];

		// Token: 0x0400900E RID: 36878
		[UIControl("Middle/GoodsFashion/MiddleNvQiang/element{0}", typeof(RectTransform), 1)]
		private RectTransform[] NvQiangFashionElement = new RectTransform[5];

		// Token: 0x0400900F RID: 36879
		[UIControl("Middle/GoodsFashion/MiddleLuoLi/element{0}", typeof(RectTransform), 1)]
		private RectTransform[] LuoLiFashionElement = new RectTransform[5];

		// Token: 0x04009010 RID: 36880
		[UIControl("Middle/GoodsFashion/MiddleGeDou/element{0}", typeof(RectTransform), 1)]
		private RectTransform[] GeDouFashionElement = new RectTransform[5];

		// Token: 0x04009011 RID: 36881
		private Button mGoRight;

		// Token: 0x04009012 RID: 36882
		private Button mGoLeft;

		// Token: 0x04009013 RID: 36883
		private Text mRemainTime;

		// Token: 0x04009014 RID: 36884
		private Button mBuy;

		// Token: 0x04009015 RID: 36885
		private GameObject mStoreElement;

		// Token: 0x04009016 RID: 36886
		private Text mStoreName;

		// Token: 0x04009017 RID: 36887
		private Text mLimitTime;

		// Token: 0x04009018 RID: 36888
		private GameObject mTitleElement;

		// Token: 0x04009019 RID: 36889
		private GameObject mSomeThingElement;

		// Token: 0x0400901A RID: 36890
		private Text mSomeThingName;

		// Token: 0x0400901B RID: 36891
		private Image mBG;

		// Token: 0x0400901C RID: 36892
		private GameObject mGoodsFashion;

		// Token: 0x0400901D RID: 36893
		private GameObject mGoodsStone;

		// Token: 0x0400901E RID: 36894
		private GameObject mGoodsTitle;

		// Token: 0x0400901F RID: 36895
		private GameObject mGoodsBuySomeThing;

		// Token: 0x04009020 RID: 36896
		private Button mClose;

		// Token: 0x04009021 RID: 36897
		private GameObject mTips;

		// Token: 0x04009022 RID: 36898
		private GameObject mRemainTimeGO;

		// Token: 0x04009023 RID: 36899
		private Text mTitleTime;

		// Token: 0x04009024 RID: 36900
		private Text mStoneTime;

		// Token: 0x04009025 RID: 36901
		private Text mBuySomethingTime;

		// Token: 0x04009026 RID: 36902
		private Text mGuiJianTime;

		// Token: 0x04009027 RID: 36903
		private Text mNanQiangTime;

		// Token: 0x04009028 RID: 36904
		private Text mNvQiangTime;

		// Token: 0x04009029 RID: 36905
		private Text mLuoLiTime;

		// Token: 0x0400902A RID: 36906
		private Text mGeDouTime;

		// Token: 0x0400902B RID: 36907
		private GameObject mGuiJian;

		// Token: 0x0400902C RID: 36908
		private GameObject mNanQiang;

		// Token: 0x0400902D RID: 36909
		private GameObject mNvQiang;

		// Token: 0x0400902E RID: 36910
		private GameObject mLuoLi;

		// Token: 0x0400902F RID: 36911
		private GameObject mGeDou;

		// Token: 0x04009030 RID: 36912
		private GameObject mGoldTime;
	}
}
