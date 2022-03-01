using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200175D RID: 5981
	internal class ComTopButtonExpandController : MonoBehaviour
	{
		// Token: 0x0600EBE5 RID: 60389 RVA: 0x003EDFB8 File Offset: 0x003EC3B8
		private void OnDestroy()
		{
			this.FirstBtnList = null;
			this.SecendBtnList = null;
			this.UnPermanentBtnList = null;
			this.HaveatwolevelermanentBtnList = null;
			this.UnPermanentHaveTwoLevelErmanentBtnList = null;
			this.ParentIcon = null;
			this.RePointImg = null;
			this.RePointGo = null;
			this.LeftImg = null;
			this.RightImg = null;
			this.topRightGo = null;
			this.topRight2Go = null;
			this.bStartAnimation = false;
			this.Btnindex = 0;
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Remove(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Remove(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Remove(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshActivityLimitTimeBtn, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityLimitTimeBtn));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateBossActivityState, new ClientEventSystem.UIEventHandler(this.OnUpdataUnPermenentTwoLevelButton));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateUnlockFunc, new ClientEventSystem.UIEventHandler(this.OnUpdataUnPermenentTwoLevelButton));
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Remove(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600EBE6 RID: 60390 RVA: 0x003EE110 File Offset: 0x003EC510
		private void Start()
		{
			ActiveManager instance = DataManager<ActiveManager>.GetInstance();
			instance.onAddMainActivity = (ActiveManager.OnAddMainActivity)Delegate.Combine(instance.onAddMainActivity, new ActiveManager.OnAddMainActivity(this._OnAddMainActivity));
			ActiveManager instance2 = DataManager<ActiveManager>.GetInstance();
			instance2.onRemoveMainActivity = (ActiveManager.OnRemoveMainActivity)Delegate.Combine(instance2.onRemoveMainActivity, new ActiveManager.OnRemoveMainActivity(this._OnRemoveMainActivity));
			ActiveManager instance3 = DataManager<ActiveManager>.GetInstance();
			instance3.onUpdateMainActivity = (ActiveManager.OnUpdateMainActivity)Delegate.Combine(instance3.onUpdateMainActivity, new ActiveManager.OnUpdateMainActivity(this._OnUpdateMainActivity));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshActivityLimitTimeBtn, new ClientEventSystem.UIEventHandler(this.OnUpdateActivityLimitTimeBtn));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateBossActivityState, new ClientEventSystem.UIEventHandler(this.OnUpdataUnPermenentTwoLevelButton));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateUnlockFunc, new ClientEventSystem.UIEventHandler(this.OnUpdataUnPermenentTwoLevelButton));
			if (!this.CanGoOn())
			{
				return;
			}
			this.bExpanding = false;
			ActiveManager instance4 = DataManager<ActiveManager>.GetInstance();
			instance4.onActivityUpdate = (ActiveManager.OnActivityUpdate)Delegate.Combine(instance4.onActivityUpdate, new ActiveManager.OnActivityUpdate(this._OnActivityUpdate));
		}

		// Token: 0x0600EBE7 RID: 60391 RVA: 0x003EE21C File Offset: 0x003EC61C
		public void StartExpand(bool bExpand)
		{
			if (!this.CanGoOn())
			{
				return;
			}
			this.bExpanding = bExpand;
			this.CloseTopRightTopRight2GameObject();
			this.AnimationBefore();
			base.Invoke("OpenTopRightTopRight2GameObject", this.OpenTopRightGoTime);
			this.StartMainUIIconAnimation(this.FirstBtnList, this.SecendBtnList);
		}

		// Token: 0x0600EBE8 RID: 60392 RVA: 0x003EE26C File Offset: 0x003EC66C
		private void AnimationBefore()
		{
			for (int i = 0; i < this.UnPermanentBtnList.Count; i++)
			{
				if (this.bExpanding)
				{
					this.UnPermanentBtnList[i].gameObject.CustomActive(false);
				}
				else
				{
					this.UpdateTopRightButtons();
				}
			}
			this.RefreshPermenentTwoLevelButton();
			this.MainButtonState();
		}

		// Token: 0x0600EBE9 RID: 60393 RVA: 0x003EE2CE File Offset: 0x003EC6CE
		public void UpdateTopRightState(bool IsExpand)
		{
			this.bExpanding = IsExpand;
			this.AnimationBefore();
		}

		// Token: 0x0600EBEA RID: 60394 RVA: 0x003EE2DD File Offset: 0x003EC6DD
		private void CloseTopRightTopRight2GameObject()
		{
			this.topRightGo.CustomActive(false);
			this.topRight2Go.CustomActive(false);
		}

		// Token: 0x0600EBEB RID: 60395 RVA: 0x003EE2F7 File Offset: 0x003EC6F7
		private void OpenTopRightTopRight2GameObject()
		{
			this.topRightGo.CustomActive(true);
			this.topRight2Go.CustomActive(true);
		}

		// Token: 0x0600EBEC RID: 60396 RVA: 0x003EE314 File Offset: 0x003EC714
		public void MainButtonState()
		{
			if (this.bExpanding)
			{
				this.LeftImg.CustomActive(this.bExpanding);
				this.RightImg.CustomActive(!this.bExpanding);
				this.RePointGo.CustomActive(this.IsRePointShow());
			}
			else
			{
				this.LeftImg.CustomActive(this.bExpanding);
				this.RightImg.CustomActive(!this.bExpanding);
				this.RePointGo.CustomActive(false);
			}
		}

		// Token: 0x0600EBED RID: 60397 RVA: 0x003EE398 File Offset: 0x003EC798
		private bool CanGoOn()
		{
			return this.FirstBtnList != null && !(this.ParentIcon == null) && this.SecendBtnList != null;
		}

		// Token: 0x0600EBEE RID: 60398 RVA: 0x003EE3C4 File Offset: 0x003EC7C4
		private bool IsRePointShow()
		{
			int num = 0;
			if (this.bExpanding)
			{
				for (int i = 0; i < this.RePointImg.Count; i++)
				{
					if (this.RePointImg[i].gameObject.activeSelf && this.IsShowRedPoint(i))
					{
						num++;
					}
				}
			}
			return num > 0;
		}

		// Token: 0x0600EBEF RID: 60399 RVA: 0x003EE42F File Offset: 0x003EC82F
		public bool IsExpand()
		{
			return !this.bExpanding;
		}

		// Token: 0x0600EBF0 RID: 60400 RVA: 0x003EE43A File Offset: 0x003EC83A
		private bool IsShowRedPoint(int Iindex)
		{
			if (Iindex == 0)
			{
				return Utility.IsUnLockFunc(6);
			}
			if (Iindex == 1)
			{
				return Utility.IsUnLockFunc(36);
			}
			return Iindex != 2 || Utility.IsUnLockFunc(57);
		}

		// Token: 0x0600EBF1 RID: 60401 RVA: 0x003EE468 File Offset: 0x003EC868
		public bool IsShowUnPermenentButton(ExpandButtonType btnType)
		{
			if (btnType == ExpandButtonType.ActivityJar)
			{
				return this._isActivityJarBtn();
			}
			if (btnType == ExpandButtonType.Welfare)
			{
				return Utility.IsUnLockFunc(6);
			}
			if (btnType == ExpandButtonType.Jar)
			{
				return this._IsMagicJarBtn();
			}
			if (btnType == ExpandButtonType.FirstRechargeActivity)
			{
				return this._isFirstRechargeActivityBtn();
			}
			return btnType != ExpandButtonType.TreasureLotteryActivity || this._isTreasureLotteryActivityBtn();
		}

		// Token: 0x0600EBF2 RID: 60402 RVA: 0x003EE4BB File Offset: 0x003EC8BB
		public bool IsShowPermenentButton(HaveTwoLevelPermanent HTLP)
		{
			if (HTLP == HaveTwoLevelPermanent.ActivityLimittimeFrame)
			{
				return this._isActivityLimittimeFrameBtn();
			}
			return HTLP != HaveTwoLevelPermanent.ActiveSevenDays || this._isActiveSevenDaysBtn();
		}

		// Token: 0x0600EBF3 RID: 60403 RVA: 0x003EE4D9 File Offset: 0x003EC8D9
		private bool IsShowUnPermenentTwoLevelButton(UnPermanentHaveTwoLevelErmanent type)
		{
			return type != UnPermanentHaveTwoLevelErmanent.FirstRechargeActivity || this._isFirstRechargeActivityBtn();
		}

		// Token: 0x0600EBF4 RID: 60404 RVA: 0x003EE4E9 File Offset: 0x003EC8E9
		private bool _isActivityJarBtn()
		{
			return Utility.IsUnLockFunc(58) && DataManager<JarDataManager>.GetInstance().HasActivityJar();
		}

		// Token: 0x0600EBF5 RID: 60405 RVA: 0x003EE509 File Offset: 0x003EC909
		private bool _IsMagicJarBtn()
		{
			return Utility.IsUnLockFunc(36);
		}

		// Token: 0x0600EBF6 RID: 60406 RVA: 0x003EE512 File Offset: 0x003EC912
		private bool _isActivityLimittimeFrameBtn()
		{
			return DataManager<ActivityManager>.GetInstance().IsHaveAnyActivity();
		}

		// Token: 0x0600EBF7 RID: 60407 RVA: 0x003EE51E File Offset: 0x003EC91E
		private bool _isActiveSevenDaysBtn()
		{
			return Utility.IsUnLockFunc(32) && this.SevenDaysButtonIsShow();
		}

		// Token: 0x0600EBF8 RID: 60408 RVA: 0x003EE53A File Offset: 0x003EC93A
		private bool _isFirstRechargeActivityBtn()
		{
			return Utility.IsUnLockFunc(34) && (Singleton<PayManager>.GetInstance().HasFirstPay() || Singleton<PayManager>.GetInstance().HasConsumePay());
		}

		// Token: 0x0600EBF9 RID: 60409 RVA: 0x003EE56C File Offset: 0x003EC96C
		private bool _isTreasureLotteryActivityBtn()
		{
			ETreasureLotterState state = DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetState();
			return state == ETreasureLotterState.Open || state == ETreasureLotterState.Prepare;
		}

		// Token: 0x0600EBFA RID: 60410 RVA: 0x003EE598 File Offset: 0x003EC998
		public void RefreshPermenentTwoLevelButton()
		{
			for (int i = 0; i < 2; i++)
			{
				this.HaveatwolevelermanentBtnList[i].gameObject.CustomActive(this.IsShowPermenentButton((HaveTwoLevelPermanent)i));
			}
		}

		// Token: 0x0600EBFB RID: 60411 RVA: 0x003EE5D4 File Offset: 0x003EC9D4
		private void RefreshUnPermenentTwoLevelButton()
		{
			for (int i = 0; i < 1; i++)
			{
				this.UnPermanentHaveTwoLevelErmanentBtnList[i].gameObject.CustomActive(this.IsShowUnPermenentTwoLevelButton((UnPermanentHaveTwoLevelErmanent)i));
			}
		}

		// Token: 0x0600EBFC RID: 60412 RVA: 0x003EE610 File Offset: 0x003ECA10
		public void UpdateTopRightButtons()
		{
			for (int i = 0; i < 5; i++)
			{
				this.UnPermanentBtnList[i].gameObject.CustomActive(this.IsShowUnPermenentButton((ExpandButtonType)i));
			}
		}

		// Token: 0x0600EBFD RID: 60413 RVA: 0x003EE64C File Offset: 0x003ECA4C
		private bool SevenDaysButtonIsShow()
		{
			bool result = false;
			List<ActiveMainTable> type2Templates = DataManager<ActiveManager>.GetInstance().GetType2Templates(this.ISevenActiveConfigID);
			int num = 0;
			while (type2Templates != null && num < type2Templates.Count)
			{
				if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.ContainsKey(type2Templates[num].ID))
				{
					ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().ActiveDictionary[type2Templates[num].ID];
					if (activeData != null)
					{
						if (activeData.mainInfo != null && activeData.mainInfo.state != 0)
						{
							result = true;
							break;
						}
					}
				}
				num++;
			}
			return result;
		}

		// Token: 0x0600EBFE RID: 60414 RVA: 0x003EE6F8 File Offset: 0x003ECAF8
		private void ResetMainUIIconTransform(List<RectTransform> btnList, float width)
		{
			if (btnList == null)
			{
				return;
			}
			for (int i = 0; i < btnList.Count; i++)
			{
				RectTransform rectTransform = btnList[i];
				if (rectTransform)
				{
					rectTransform.sizeDelta = new Vector2(width, this.cMainUIIconHeight);
					CanvasGroup component = rectTransform.GetComponent<CanvasGroup>();
					if (component)
					{
						component.alpha = this.AlphaStart;
					}
				}
			}
		}

		// Token: 0x0600EBFF RID: 60415 RVA: 0x003EE768 File Offset: 0x003ECB68
		private void StartMainUIIconAnimation(List<RectTransform> btnFirstList, List<RectTransform> btnSecendList)
		{
			this.currentMainList.Clear();
			this.currentMainList2.Clear();
			for (int i = 0; i < btnFirstList.Count; i++)
			{
				RectTransform rectTransform = btnFirstList[i];
				if (rectTransform && rectTransform.gameObject.activeSelf)
				{
					this.currentMainList.Add(rectTransform);
				}
			}
			for (int j = 0; j < btnSecendList.Count; j++)
			{
				RectTransform rectTransform2 = btnSecendList[j];
				if (rectTransform2 && rectTransform2.gameObject.activeSelf)
				{
					this.currentMainList2.Add(rectTransform2);
				}
			}
			this.ResetMainUIIconTransform(this.currentMainList, this.cMainUIIconStartWidth);
			this.ResetMainUIIconTransform(this.currentMainList2, this.cMainUIIconStartWidth);
			this.bStartAnimation = true;
			this.Btnindex = 0;
			this.timeflow = 0f;
		}

		// Token: 0x0600EC00 RID: 60416 RVA: 0x003EE854 File Offset: 0x003ECC54
		private void Update()
		{
			if (this.bStartAnimation)
			{
				this.timeflow += Time.deltaTime;
				int btnindex = this.Btnindex;
				int num = this.Btnindex - 1;
				float num2 = this.timeflow / this.m_fSpeed;
				if (this.bUseCurve && this.mCurve != null)
				{
					num2 = this.mCurve.Evaluate(num2);
				}
				else
				{
					num2 = Mathf.Sin(num2 * 3.1415927f / 2f);
					num2 = Mathf.Sqrt(num2);
				}
				if (btnindex >= 0 && btnindex < this.currentMainList.Count)
				{
					RectTransform rectTransform = this.currentMainList[btnindex];
					rectTransform.sizeDelta = new Vector2(Mathf.Lerp(this.cMainUIIconStartWidth, this.cMainUIIconEffectWidth, num2), this.cMainUIIconHeight);
					CanvasGroup component = rectTransform.GetComponent<CanvasGroup>();
					if (component)
					{
						component.alpha = Mathf.Lerp(this.AlphaStart, this.AlphaEnd, num2);
					}
				}
				if (num >= 0 && num < this.currentMainList.Count)
				{
					RectTransform rectTransform2 = this.currentMainList[num];
					rectTransform2.sizeDelta = new Vector2(Mathf.Lerp(this.cMainUIIconEffectWidth, this.cMainUIIconTargetWidth, num2), this.cMainUIIconHeight);
				}
				if (btnindex >= 0 && btnindex < this.currentMainList2.Count)
				{
					RectTransform rectTransform3 = this.currentMainList2[btnindex];
					rectTransform3.sizeDelta = new Vector2(Mathf.Lerp(this.cMainUIIconStartWidth, this.cMainUIIconEffectWidth, num2), this.cMainUIIconHeight);
					CanvasGroup component2 = rectTransform3.GetComponent<CanvasGroup>();
					if (component2)
					{
						component2.alpha = Mathf.Lerp(this.AlphaStart, this.AlphaEnd, num2);
					}
				}
				if (num >= 0 && num < this.currentMainList2.Count)
				{
					RectTransform rectTransform4 = this.currentMainList2[num];
					rectTransform4.sizeDelta = new Vector2(Mathf.Lerp(this.cMainUIIconEffectWidth, this.cMainUIIconTargetWidth, num2), this.cMainUIIconHeight);
				}
				if (this.timeflow >= this.m_fSpeed)
				{
					this.Btnindex++;
					this.timeflow = 0f;
					if (this.Btnindex > this.currentMainList.Count && this.Btnindex > this.currentMainList2.Count)
					{
						this.bStartAnimation = false;
					}
				}
			}
		}

		// Token: 0x0600EC01 RID: 60417 RVA: 0x003EEABC File Offset: 0x003ECEBC
		private void _OnAddMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.ISevenActiveConfigID)
			{
				this.RefreshPermenentTwoLevelButton();
			}
		}

		// Token: 0x0600EC02 RID: 60418 RVA: 0x003EEADA File Offset: 0x003ECEDA
		private void _OnRemoveMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.ISevenActiveConfigID)
			{
				this.RefreshPermenentTwoLevelButton();
			}
		}

		// Token: 0x0600EC03 RID: 60419 RVA: 0x003EEAF8 File Offset: 0x003ECEF8
		private void _OnUpdateMainActivity(ActiveManager.ActiveData data)
		{
			if (data.mainItem.ActiveTypeID == this.ISevenActiveConfigID)
			{
				this.RefreshPermenentTwoLevelButton();
			}
		}

		// Token: 0x0600EC04 RID: 60420 RVA: 0x003EEB16 File Offset: 0x003ECF16
		private void OnUpdateActivityLimitTimeBtn(UIEvent iEvent)
		{
			this.RefreshPermenentTwoLevelButton();
		}

		// Token: 0x0600EC05 RID: 60421 RVA: 0x003EEB1E File Offset: 0x003ECF1E
		private void OnUpdataUnPermenentTwoLevelButton(UIEvent iEvent)
		{
			this.RefreshUnPermenentTwoLevelButton();
			this.RefreshPermenentTwoLevelButton();
		}

		// Token: 0x0600EC06 RID: 60422 RVA: 0x003EEB2C File Offset: 0x003ECF2C
		private void _OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType)
		{
			this.RefreshUnPermenentTwoLevelButton();
		}

		// Token: 0x04008F45 RID: 36677
		public bool bExpanding;

		// Token: 0x04008F46 RID: 36678
		public List<RectTransform> FirstBtnList;

		// Token: 0x04008F47 RID: 36679
		public List<RectTransform> SecendBtnList;

		// Token: 0x04008F48 RID: 36680
		public List<RectTransform> UnPermanentBtnList;

		// Token: 0x04008F49 RID: 36681
		public List<RectTransform> HaveatwolevelermanentBtnList;

		// Token: 0x04008F4A RID: 36682
		public List<RectTransform> UnPermanentHaveTwoLevelErmanentBtnList;

		// Token: 0x04008F4B RID: 36683
		public List<Image> RePointImg;

		// Token: 0x04008F4C RID: 36684
		public float OpenTopRightGoTime;

		// Token: 0x04008F4D RID: 36685
		public int ISevenActiveConfigID;

		// Token: 0x04008F4E RID: 36686
		public GameObject ParentIcon;

		// Token: 0x04008F4F RID: 36687
		public GameObject RePointGo;

		// Token: 0x04008F50 RID: 36688
		public GameObject LeftImg;

		// Token: 0x04008F51 RID: 36689
		public GameObject RightImg;

		// Token: 0x04008F52 RID: 36690
		public GameObject topRightGo;

		// Token: 0x04008F53 RID: 36691
		public GameObject topRight2Go;

		// Token: 0x04008F54 RID: 36692
		public float cMainUIIconHeight = 110f;

		// Token: 0x04008F55 RID: 36693
		public float cMainUIIconStartWidth = 60f;

		// Token: 0x04008F56 RID: 36694
		public float cMainUIIconEffectWidth = 180f;

		// Token: 0x04008F57 RID: 36695
		public float cMainUIIconTargetWidth = 110f;

		// Token: 0x04008F58 RID: 36696
		public float m_fSpeed = 0.08f;

		// Token: 0x04008F59 RID: 36697
		private float timeflow;

		// Token: 0x04008F5A RID: 36698
		private int Btnindex;

		// Token: 0x04008F5B RID: 36699
		private bool bStartAnimation;

		// Token: 0x04008F5C RID: 36700
		public float AlphaStart;

		// Token: 0x04008F5D RID: 36701
		public float AlphaEnd;

		// Token: 0x04008F5E RID: 36702
		private List<RectTransform> currentMainList = new List<RectTransform>();

		// Token: 0x04008F5F RID: 36703
		private List<RectTransform> currentMainList2 = new List<RectTransform>();

		// Token: 0x04008F60 RID: 36704
		public AnimationCurve mCurve;

		// Token: 0x04008F61 RID: 36705
		public bool bUseCurve;
	}
}
