using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BE1 RID: 7137
	internal class TeacherItem
	{
		// Token: 0x060117F1 RID: 71665 RVA: 0x00516AA7 File Offset: 0x00514EA7
		public TeacherItem(RelationData relationData, bool haveTrueTeacher, GameObject toggleGroup)
		{
			this.haveTeacher = haveTrueTeacher;
			this.thisTeacherData = relationData;
			this.teacherItemToggleGroup = toggleGroup;
			this.CreateGo(relationData);
		}

		// Token: 0x17001DB4 RID: 7604
		// (get) Token: 0x060117F2 RID: 71666 RVA: 0x00516ACB File Offset: 0x00514ECB
		// (set) Token: 0x060117F3 RID: 71667 RVA: 0x00516AD3 File Offset: 0x00514ED3
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

		// Token: 0x060117F4 RID: 71668 RVA: 0x00516ADC File Offset: 0x00514EDC
		private void CreateGo(RelationData relationData)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/TAP/TeacherItem", true, 0U);
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
			this.mTeacherToggle = component.GetCom<Toggle>("TeacherToggle");
			this.mSelect = component.GetGameObject("Select");
			this.mOnline = component.GetCom<Text>("Online");
			this.mBtnTalk = component.GetCom<Button>("BtnTalk");
			this.mLevel = component.GetCom<Text>("Level");
			this.mTitleImage = component.GetGameObject("titleImage");
			this.mDonateMoney = component.GetCom<Button>("DonateMoney");
			this.mGray = component.GetCom<UIGray>("Gray");
			this.mGrayBtn = component.GetCom<UIGray>("GrayBtn");
			this.mReplaceHeadPortraitFrame = component.GetCom<ReplaceHeadPortraitFrame>("ReplaceHeadPortraitFrame");
			this.mKechushi = component.GetCom<Image>("Kechushi");
			this.mName.text = relationData.name;
			this.mLevel.text = DataManager<PlayerBaseData>.GetInstance().Level.ToString();
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)relationData.occu, string.Empty, string.Empty);
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
			this.ThisGameObject = gameObject;
			this.mTeacherToggle.onValueChanged.RemoveAllListeners();
			this.mBtnTalk.CustomActive(false);
			this.mOnline.CustomActive(false);
			this.mTitleImage.CustomActive(false);
			if (this.haveTeacher)
			{
				this.mTitleImage.CustomActive(true);
				this.mBtnTalk.CustomActive(true);
				this.mTeacherToggle.onValueChanged.AddListener(delegate(bool value)
				{
					this.mSelect.CustomActive(value);
					this.thisTeacherData.tapType = TAPType.Teacher;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTeacherDataUpdate, this.thisTeacherData, null, null, null);
				});
				ToggleGroup component2 = this.teacherItemToggleGroup.GetComponent<ToggleGroup>();
				if (component2 != null)
				{
					this.mTeacherToggle.group = component2;
				}
				this.mBtnTalk.onClick.RemoveAllListeners();
				this.mBtnTalk.onClick.AddListener(delegate()
				{
					RelationMenuData relationMenuData = new RelationMenuData();
					relationMenuData.m_data = this.thisTeacherData;
					relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_TEACHER_REAL;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnShowTeacherRealMenu, relationMenuData, null, null, null);
				});
				this.mOnline.CustomActive(true);
				bool flag = relationData.dayGiftNum > 0;
				if (this.thisTeacherData.isOnline == 1)
				{
					if (this.thisTeacherData.status == 0)
					{
						this.mOnline.text = "<color=#11EE11FF>在线</color>";
						this.mGray.enabled = false;
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
					else if (this.thisTeacherData.status == 1)
					{
						this.mOnline.text = "<color=#E95137FF>战斗中</color>";
						this.mGray.enabled = false;
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
						this.mGray.enabled = false;
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
					this.mGray.enabled = true;
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
				this.mLevel.text = relationData.level.ToString();
				this.mDonateMoney.CustomActive(true);
				this.mDonateMoney.SafeRemoveAllListener();
				this.mDonateMoney.SafeAddOnClickListener(new UnityAction(this.OnSendGift));
			}
			else
			{
				this.mDonateMoney.CustomActive(false);
			}
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
			RelationData teacher = DataManager<RelationDataManager>.GetInstance().GetTeacher();
			if (teacher != null)
			{
				if (DataManager<PlayerBaseData>.GetInstance().Level >= 50)
				{
					this.mKechushi.CustomActive(true);
				}
				else
				{
					this.mKechushi.CustomActive(false);
				}
			}
		}

		// Token: 0x060117F5 RID: 71669 RVA: 0x00517004 File Offset: 0x00515404
		public void DestoryGo()
		{
			Object.Destroy(this.ThisGameObject);
		}

		// Token: 0x060117F6 RID: 71670 RVA: 0x00517011 File Offset: 0x00515411
		public bool toggleIsOn()
		{
			return this.mTeacherToggle.isOn;
		}

		// Token: 0x060117F7 RID: 71671 RVA: 0x0051701E File Offset: 0x0051541E
		public void SetToggleSelect()
		{
			this.mTeacherToggle.isOn = true;
		}

		// Token: 0x060117F8 RID: 71672 RVA: 0x0051702C File Offset: 0x0051542C
		public ulong GetUid()
		{
			return this.thisTeacherData.uid;
		}

		// Token: 0x060117F9 RID: 71673 RVA: 0x00517039 File Offset: 0x00515439
		public void UpdateSelect()
		{
			this.thisTeacherData.tapType = TAPType.Teacher;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTeacherDataUpdate, this.thisTeacherData, null, null, null);
		}

		// Token: 0x060117FA RID: 71674 RVA: 0x00517060 File Offset: 0x00515460
		private void OnSendGift()
		{
			if (this.thisTeacherData != null)
			{
				if (this.thisTeacherData.dayGiftNum <= 0)
				{
					return;
				}
				WorldRelationPresentGiveReq worldRelationPresentGiveReq = new WorldRelationPresentGiveReq();
				worldRelationPresentGiveReq.friendUID = this.thisTeacherData.uid;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldRelationPresentGiveReq>(ServerType.GATE_SERVER, worldRelationPresentGiveReq);
				DataManager<WaitNetMessageManager>.GetInstance().Wait(601775U, delegate(MsgDATA data)
				{
					if (data == null)
					{
						return;
					}
					WorldRelationPresentGiveRes worldRelationPresentGiveRes = new WorldRelationPresentGiveRes();
					if (worldRelationPresentGiveRes != null)
					{
						worldRelationPresentGiveRes.decode(data.bytes);
						if (worldRelationPresentGiveRes.code != 0U)
						{
							CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)worldRelationPresentGiveRes.code, string.Empty, string.Empty);
							if (tableItem != null)
							{
								SystemNotifyManager.SysNotifyTextAnimation(tableItem.Descs, CommonTipsDesc.eShowMode.SI_UNIQUE);
							}
						}
						else
						{
							if (this.mDonateMoney != null)
							{
								this.mDonateMoney.enabled = false;
							}
							UIGray component = this.mDonateMoney.GetComponent<UIGray>();
							if (component != null)
							{
								component.enabled = true;
							}
						}
					}
				}, false, 15f, null);
			}
		}

		// Token: 0x0400B5EB RID: 46571
		private const string TeacherItemPath = "UIFlatten/Prefabs/TAP/TeacherItem";

		// Token: 0x0400B5EC RID: 46572
		private Image mIcon;

		// Token: 0x0400B5ED RID: 46573
		private Text mName;

		// Token: 0x0400B5EE RID: 46574
		private Toggle mTeacherToggle;

		// Token: 0x0400B5EF RID: 46575
		private GameObject mSelect;

		// Token: 0x0400B5F0 RID: 46576
		private Text mOnline;

		// Token: 0x0400B5F1 RID: 46577
		private Button mBtnTalk;

		// Token: 0x0400B5F2 RID: 46578
		private Text mLevel;

		// Token: 0x0400B5F3 RID: 46579
		private GameObject mTitleImage;

		// Token: 0x0400B5F4 RID: 46580
		private Button mDonateMoney;

		// Token: 0x0400B5F5 RID: 46581
		private UIGray mGray;

		// Token: 0x0400B5F6 RID: 46582
		private UIGray mGrayBtn;

		// Token: 0x0400B5F7 RID: 46583
		private ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x0400B5F8 RID: 46584
		private Image mKechushi;

		// Token: 0x0400B5F9 RID: 46585
		private bool haveTeacher;

		// Token: 0x0400B5FA RID: 46586
		private RelationData thisTeacherData;

		// Token: 0x0400B5FB RID: 46587
		private GameObject teacherItemToggleGroup;

		// Token: 0x0400B5FC RID: 46588
		private GameObject thisGameObject;
	}
}
