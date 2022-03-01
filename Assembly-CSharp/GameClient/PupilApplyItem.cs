using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BCE RID: 7118
	internal class PupilApplyItem
	{
		// Token: 0x060116C7 RID: 71367 RVA: 0x0050D4F4 File Offset: 0x0050B8F4
		public PupilApplyItem(RelationData relationData, int mlayer)
		{
			int[] array = new int[4];
			array[1] = 1;
			this.m_PlayList = array;
			base..ctor();
			this.CreateGo(relationData, mlayer);
		}

		// Token: 0x17001DB0 RID: 7600
		// (get) Token: 0x060116C9 RID: 71369 RVA: 0x0050D539 File Offset: 0x0050B939
		// (set) Token: 0x060116C8 RID: 71368 RVA: 0x0050D530 File Offset: 0x0050B930
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

		// Token: 0x060116CA RID: 71370 RVA: 0x0050D544 File Offset: 0x0050B944
		private void CreateGo(RelationData relationData, int mLayer)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/TAP/TAPSearchItem", true, 0U);
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
			this.mBtnAccept = component.GetCom<Button>("BtnAccept");
			this.mBtnRefuse = component.GetCom<Button>("BtnRefuse");
			this.mLevel = component.GetCom<Text>("Level");
			this.m_AvatarRenderer = component.GetCom<GeAvatarRendererEx>("ModelRenderTexture");
			this.mBtnView = component.GetCom<Button>("BtnView");
			this.mRegion = component.GetCom<Text>("Region");
			this.mDeclaration = component.GetCom<Text>("Declaration");
			this.mJobName = component.GetCom<Text>("JobName");
			this.mBtText = component.GetCom<Text>("BtText");
			this.mBtGray = component.GetCom<UIGray>("BtnAcceptGray");
			this.mViewInfomationBtn = component.GetCom<Button>("ViewInformationBtn");
			this.mName.text = relationData.name;
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
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Teacher)
			{
				this.mBtText.text = "收徒";
				this.mBtnAccept.interactable = true;
				this.mBtGray.enabled = false;
				this.mBtnAccept.onClick.RemoveAllListeners();
				this.mBtnAccept.onClick.AddListener(delegate()
				{
					if (relationData != null)
					{
						DataManager<TAPNewDataManager>.GetInstance().SendApplyPupil(relationData.uid);
						this.mBtGray.enabled = true;
						this.mBtnAccept.interactable = false;
					}
				});
			}
			else
			{
				this.mBtText.text = "拜师";
				this.mBtnAccept.interactable = true;
				this.mBtGray.enabled = false;
				this.mBtnAccept.onClick.RemoveAllListeners();
				this.mBtnAccept.onClick.AddListener(delegate()
				{
					if (relationData != null)
					{
						this.mBtGray.enabled = true;
						this.mBtnAccept.interactable = false;
						DataManager<TAPNewDataManager>.GetInstance().SendApplyTeacher(relationData.uid);
					}
				});
			}
			this.mBtnRefuse.onClick.RemoveAllListeners();
			this.mBtnRefuse.onClick.AddListener(delegate()
			{
				if (relationData != null)
				{
					DataManager<RelationDataManager>.GetInstance().RefuseApplyPupils(new ulong[]
					{
						relationData.uid
					});
					DataManager<RelationDataManager>.GetInstance().RemoveApplyPupil(relationData.uid);
				}
			});
			if (this.mViewInfomationBtn != null)
			{
				this.mViewInfomationBtn.onClick.RemoveAllListeners();
				this.mViewInfomationBtn.onClick.AddListener(delegate()
				{
					if (relationData != null)
					{
						DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(relationData.uid, 0U, 0U);
					}
				});
			}
			this.mLevel.text = relationData.level.ToString();
			AreaProvinceTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<AreaProvinceTable>((int)relationData.regionId, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				this.mRegion.text = tableItem3.Name;
				this.mRegion.CustomActive(true);
			}
			else
			{
				this.mRegion.CustomActive(false);
			}
			this.mDeclaration.text = relationData.declaration;
			if (DataManager<TAPNewDataManager>.GetInstance().IsTeacher() == TAPType.Pupil)
			{
				this.mDeclaration.text = string.Format("宣言:{0}", TR.Value("tap_teacher_region"));
			}
			else
			{
				this.mDeclaration.text = string.Format("宣言:{0}", TR.Value("tap_pupil_region"));
			}
			JobTable tableItem4 = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)relationData.occu, string.Empty, string.Empty);
			if (tableItem4 == null)
			{
				Logger.LogError("职业ID找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
			}
			else
			{
				this.mJobName.text = tableItem4.Name;
				ResTable tableItem5 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem4.Mode, string.Empty, string.Empty);
				if (tableItem5 == null)
				{
					Logger.LogError("职业ID Mode表 找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
				}
				else
				{
					this.m_AvatarRenderer.LoadAvatar(tableItem5.ModelPath, mLayer);
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(this.m_AvatarRenderer, relationData.avatar.equipItemIds, (int)relationData.occu, (int)relationData.avatar.weaponStrengthen, null, false, relationData.avatar.isShoWeapon, false);
					this.m_AvatarRenderer.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
					this.m_AvatarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
				}
			}
		}

		// Token: 0x060116CB RID: 71371 RVA: 0x0050DA70 File Offset: 0x0050BE70
		public void UpdateMode(float timeElapsed)
		{
			if (null != this.m_AvatarRenderer)
			{
				while (Global.Settings.avatarLightDir.x > 360f)
				{
					GlobalSetting settings = Global.Settings;
					settings.avatarLightDir.x = settings.avatarLightDir.x - 360f;
				}
				while (Global.Settings.avatarLightDir.x < 0f)
				{
					GlobalSetting settings2 = Global.Settings;
					settings2.avatarLightDir.x = settings2.avatarLightDir.x + 360f;
				}
				while (Global.Settings.avatarLightDir.y > 360f)
				{
					GlobalSetting settings3 = Global.Settings;
					settings3.avatarLightDir.y = settings3.avatarLightDir.y - 360f;
				}
				while (Global.Settings.avatarLightDir.y < 0f)
				{
					GlobalSetting settings4 = Global.Settings;
					settings4.avatarLightDir.y = settings4.avatarLightDir.y + 360f;
				}
				while (Global.Settings.avatarLightDir.z > 360f)
				{
					GlobalSetting settings5 = Global.Settings;
					settings5.avatarLightDir.z = settings5.avatarLightDir.z - 360f;
				}
				while (Global.Settings.avatarLightDir.z < 0f)
				{
					GlobalSetting settings6 = Global.Settings;
					settings6.avatarLightDir.z = settings6.avatarLightDir.z + 360f;
				}
				this.m_AvatarRenderer.m_LightRot = Global.Settings.avatarLightDir;
			}
		}

		// Token: 0x060116CC RID: 71372 RVA: 0x0050DBF9 File Offset: 0x0050BFF9
		public void DestoryGo()
		{
			Object.Destroy(this.ThisGameObject);
		}

		// Token: 0x0400B4CD RID: 46285
		private const string pupilApplyItemPath = "UIFlatten/Prefabs/TAP/TAPSearchItem";

		// Token: 0x0400B4CE RID: 46286
		private Image mIcon;

		// Token: 0x0400B4CF RID: 46287
		private Text mName;

		// Token: 0x0400B4D0 RID: 46288
		private Button mBtnAccept;

		// Token: 0x0400B4D1 RID: 46289
		private Button mBtnRefuse;

		// Token: 0x0400B4D2 RID: 46290
		private Text mLevel;

		// Token: 0x0400B4D3 RID: 46291
		private GeAvatarRendererEx m_AvatarRenderer;

		// Token: 0x0400B4D4 RID: 46292
		private Button mBtnView;

		// Token: 0x0400B4D5 RID: 46293
		private Text mRegion;

		// Token: 0x0400B4D6 RID: 46294
		private Text mDeclaration;

		// Token: 0x0400B4D7 RID: 46295
		private Text mJobName;

		// Token: 0x0400B4D8 RID: 46296
		private Text mBtText;

		// Token: 0x0400B4D9 RID: 46297
		private UIGray mBtGray;

		// Token: 0x0400B4DA RID: 46298
		private Button mViewInfomationBtn;

		// Token: 0x0400B4DB RID: 46299
		private readonly string[] m_ActionTable = new string[]
		{
			"Anim_Show_Idle",
			"Anim_Show_Idle_special01"
		};

		// Token: 0x0400B4DC RID: 46300
		private readonly int[] m_PlayList;

		// Token: 0x0400B4DD RID: 46301
		private GameObject thisGameObject;
	}
}
