using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BCF RID: 7119
	internal class PupilItem
	{
		// Token: 0x060116CD RID: 71373 RVA: 0x0050DD13 File Offset: 0x0050C113
		public PupilItem(RelationData relationData, GameObject toggleGroup)
		{
			this.thisPupilData = relationData;
			this.pupilItemToggleGroup = toggleGroup;
			this.CreateGo();
		}

		// Token: 0x17001DB1 RID: 7601
		// (get) Token: 0x060116CE RID: 71374 RVA: 0x0050DD2F File Offset: 0x0050C12F
		// (set) Token: 0x060116CF RID: 71375 RVA: 0x0050DD37 File Offset: 0x0050C137
		public GameObject ThisGameObject
		{
			get
			{
				return this.thisGameObject;
			}
			set
			{
				this.thisGameObject = value;
			}
		}

		// Token: 0x060116D0 RID: 71376 RVA: 0x0050DD40 File Offset: 0x0050C140
		private void CreateGo()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/TAP/PupilItem", true, 0U);
			if (gameObject == null)
			{
				return;
			}
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			this.mName = component.GetCom<Text>("Name");
			this.mIcon = component.GetCom<Image>("Icon");
			this.mPupilToggle = component.GetCom<Toggle>("PupilToggle");
			this.mSelect = component.GetGameObject("Select");
			this.mOnline = component.GetCom<Text>("Online");
			this.mBtnTalk = component.GetCom<Button>("BtnTalk");
			this.mDonateEquip = component.GetCom<Button>("DonateEquip");
			this.mLevel = component.GetCom<Text>("Level");
			this.mRedPoint = component.GetGameObject("RedPoint");
			this.mDonateMoney = component.GetCom<Button>("DonateMoney");
			this.mGray = component.GetCom<UIGray>("Gray");
			this.mGrayBtn = component.GetCom<UIGray>("GrayBtn");
			this.mReplaceHeadPortraitFrame = component.GetCom<ReplaceHeadPortraitFrame>("ReplaceHeadPortraitFrame");
			this.mKechushi = component.GetCom<Image>("Kechushi");
			this.ThisGameObject = gameObject;
			ToggleGroup component2 = this.pupilItemToggleGroup.GetComponent<ToggleGroup>();
			if (component2 != null)
			{
				this.mPupilToggle.group = component2;
			}
			this.UpdateUI(this.thisPupilData);
		}

		// Token: 0x060116D1 RID: 71377 RVA: 0x0050DEA8 File Offset: 0x0050C2A8
		public void UpdateUI(RelationData relationData)
		{
			this.thisPupilData = relationData;
			this.mName.text = this.thisPupilData.name;
			this.mOnline.CustomActive(true);
			bool flag = relationData.dayGiftNum > 0;
			if (this.thisPupilData.isOnline == 1)
			{
				if (this.thisPupilData.status == 0)
				{
					this.mOnline.text = "<color=#11EE11FF>在线</color>";
					if (flag)
					{
						this.mDonateMoney.enabled = true;
						this.mGrayBtn.enabled = false;
					}
					else
					{
						this.mDonateMoney.enabled = false;
						this.mGrayBtn.enabled = true;
					}
				}
				else if (this.thisPupilData.status == 1)
				{
					this.mOnline.text = "<color=#E95137FF>战斗中</color>";
					if (flag)
					{
						this.mDonateMoney.enabled = true;
						this.mGrayBtn.enabled = false;
					}
					else
					{
						this.mDonateMoney.enabled = false;
						this.mGrayBtn.enabled = true;
					}
				}
				else
				{
					this.mOnline.text = "<color=#11EE11FF>在线</color>";
					if (flag)
					{
						this.mDonateMoney.enabled = true;
						this.mGrayBtn.enabled = false;
					}
					else
					{
						this.mDonateMoney.enabled = false;
						this.mGrayBtn.enabled = true;
					}
				}
			}
			else
			{
				this.mOnline.text = "<color=#99AABBFF>离线</color>";
				if (flag)
				{
					this.mDonateMoney.enabled = true;
					this.mGrayBtn.enabled = false;
				}
				else
				{
					this.mDonateMoney.enabled = false;
					this.mGrayBtn.enabled = true;
				}
			}
			this.mPupilToggle.onValueChanged.RemoveAllListeners();
			this.mPupilToggle.onValueChanged.AddListener(delegate(bool value)
			{
				this.mSelect.CustomActive(value);
				if (value)
				{
					DataManager<TAPNewDataManager>.GetInstance().GetPupilMissionList(this.thisPupilData.uid);
					this.thisPupilData.tapType = TAPType.Pupil;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPupilDataUpdate, this.thisPupilData, null, null, null);
				}
			});
			this.mBtnTalk.onClick.RemoveAllListeners();
			this.mBtnTalk.onClick.AddListener(delegate()
			{
				RelationMenuData relationMenuData = new RelationMenuData();
				relationMenuData.m_data = this.thisPupilData;
				relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_PUPIL_REAL;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShowPupilRealMenu, relationMenuData, null, null, null);
			});
			this.mDonateEquip.onClick.RemoveAllListeners();
			this.mDonateEquip.onClick.AddListener(delegate()
			{
				TAPDonateFrame.Open(this.thisPupilData);
			});
			this.mLevel.text = this.thisPupilData.level.ToString();
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)this.thisPupilData.occu, string.Empty, string.Empty);
			if (null != this.mIcon)
			{
				string path = string.Empty;
				if (tableItem != null)
				{
					ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						path = tableItem2.IconPath;
					}
				}
				ETCImageLoader.LoadSprite(ref this.mIcon, path, true);
			}
			if (this.mGray != null)
			{
				this.mGray.enabled = false;
				bool enabled = this.thisPupilData.isOnline == 0;
				this.mGray.enabled = enabled;
			}
			this.mRedPoint.CustomActive(DataManager<TAPNewDataManager>.GetInstance().HaveTAPDailyRedPointForID(relationData.uid));
			this.mDonateMoney.SafeRemoveAllListener();
			this.mDonateMoney.SafeAddOnClickListener(new UnityAction(this.OnSendGift));
			if (this.mReplaceHeadPortraitFrame != null)
			{
				if (relationData.headFrame != 0U)
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame((int)relationData.headFrame);
				}
				else
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
			if (this.thisPupilData.level >= 50)
			{
				this.mKechushi.CustomActive(true);
			}
			else
			{
				this.mKechushi.CustomActive(false);
			}
		}

		// Token: 0x060116D2 RID: 71378 RVA: 0x0050E255 File Offset: 0x0050C655
		public void DestoryGo()
		{
			Object.Destroy(this.ThisGameObject);
		}

		// Token: 0x060116D3 RID: 71379 RVA: 0x0050E262 File Offset: 0x0050C662
		public bool toggleIsOn()
		{
			return this.mPupilToggle.isOn;
		}

		// Token: 0x060116D4 RID: 71380 RVA: 0x0050E26F File Offset: 0x0050C66F
		public void SetToggleSelect()
		{
			this.mPupilToggle.isOn = true;
		}

		// Token: 0x060116D5 RID: 71381 RVA: 0x0050E27D File Offset: 0x0050C67D
		public ulong GetUid()
		{
			return this.thisPupilData.uid;
		}

		// Token: 0x060116D6 RID: 71382 RVA: 0x0050E28A File Offset: 0x0050C68A
		public void UpdateSelect()
		{
			DataManager<TAPNewDataManager>.GetInstance().GetPupilMissionList(this.thisPupilData.uid);
			this.thisPupilData.tapType = TAPType.Pupil;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPupilDataUpdate, this.thisPupilData, null, null, null);
		}

		// Token: 0x060116D7 RID: 71383 RVA: 0x0050E2C8 File Offset: 0x0050C6C8
		private void OnSendGift()
		{
			if (this.thisPupilData != null)
			{
				if (this.thisPupilData.dayGiftNum <= 0)
				{
					return;
				}
				WorldRelationPresentGiveReq worldRelationPresentGiveReq = new WorldRelationPresentGiveReq();
				worldRelationPresentGiveReq.friendUID = this.thisPupilData.uid;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldRelationPresentGiveReq>(ServerType.GATE_SERVER, worldRelationPresentGiveReq);
				DataManager<WaitNetMessageManager>.GetInstance().Wait(601775U, delegate(MsgDATA data)
				{
					if (data == null)
					{
						return;
					}
					WorldRelationPresentGiveRes worldRelationPresentGiveRes = new WorldRelationPresentGiveRes();
					worldRelationPresentGiveRes.decode(data.bytes);
					if (worldRelationPresentGiveRes.code != 0U)
					{
						CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)worldRelationPresentGiveRes.code, string.Empty, string.Empty);
						if (tableItem != null)
						{
							SystemNotifyManager.SysNotifyTextAnimation(tableItem.Descs, CommonTipsDesc.eShowMode.SI_UNIQUE);
						}
					}
					else if (this.mDonateMoney != null)
					{
						this.mDonateMoney.enabled = false;
						UIGray component = this.mDonateMoney.GetComponent<UIGray>();
						if (component != null)
						{
							component.enabled = true;
						}
					}
				}, false, 15f, null);
			}
		}

		// Token: 0x0400B4DE RID: 46302
		private const string pupilItemPath = "UIFlatten/Prefabs/TAP/PupilItem";

		// Token: 0x0400B4DF RID: 46303
		private Image mIcon;

		// Token: 0x0400B4E0 RID: 46304
		private Text mName;

		// Token: 0x0400B4E1 RID: 46305
		private Toggle mPupilToggle;

		// Token: 0x0400B4E2 RID: 46306
		private GameObject mSelect;

		// Token: 0x0400B4E3 RID: 46307
		private Text mOnline;

		// Token: 0x0400B4E4 RID: 46308
		private Button mBtnTalk;

		// Token: 0x0400B4E5 RID: 46309
		private Button mDonateEquip;

		// Token: 0x0400B4E6 RID: 46310
		private Text mLevel;

		// Token: 0x0400B4E7 RID: 46311
		private GameObject mRedPoint;

		// Token: 0x0400B4E8 RID: 46312
		private Button mDonateMoney;

		// Token: 0x0400B4E9 RID: 46313
		private UIGray mGray;

		// Token: 0x0400B4EA RID: 46314
		private UIGray mGrayBtn;

		// Token: 0x0400B4EB RID: 46315
		private ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x0400B4EC RID: 46316
		private Image mKechushi;

		// Token: 0x0400B4ED RID: 46317
		private GameObject thisGameObject;

		// Token: 0x0400B4EE RID: 46318
		private RelationData thisPupilData;

		// Token: 0x0400B4EF RID: 46319
		private GameObject pupilItemToggleGroup;
	}
}
