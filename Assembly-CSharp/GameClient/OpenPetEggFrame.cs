using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001977 RID: 6519
	internal class OpenPetEggFrame : ClientFrame
	{
		// Token: 0x0600FD51 RID: 64849 RVA: 0x0045BF57 File Offset: 0x0045A357
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pet/OpenPetEggFrame";
		}

		// Token: 0x0600FD52 RID: 64850 RVA: 0x0045BF5E File Offset: 0x0045A35E
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				return;
			}
			this.PetEggData = (ItemData)this.userData;
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x0600FD53 RID: 64851 RVA: 0x0045BF89 File Offset: 0x0045A389
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.ClearData();
		}

		// Token: 0x0600FD54 RID: 64852 RVA: 0x0045BF98 File Offset: 0x0045A398
		private void ClearData()
		{
			this.OpenEffectObj = null;
			this.AnimControl = null;
			this.mAvatarRenderer.ClearAvatar();
			this.bInitActor = false;
			this.fTimeIntval = 0f;
			this.bIsFirstClick = true;
			this.SpecialActionTimeLen = 0f;
			this.bStartIdleAction = false;
			this.SpecialActionTimeIntrval = 0f;
		}

		// Token: 0x0600FD55 RID: 64853 RVA: 0x0045BFF4 File Offset: 0x0045A3F4
		protected void BindUIEvent()
		{
		}

		// Token: 0x0600FD56 RID: 64854 RVA: 0x0045BFF6 File Offset: 0x0045A3F6
		protected void UnBindUIEvent()
		{
		}

		// Token: 0x0600FD57 RID: 64855 RVA: 0x0045BFF8 File Offset: 0x0045A3F8
		private void InitInterface()
		{
			string text = "Actor/Pet_eggs/Prefabs/EffUI_chongwudan0{0}";
			if (this.PetEggData.Quality <= ItemTable.eColor.BLUE)
			{
				text = string.Format(text, 1);
			}
			else if (this.PetEggData.Quality == ItemTable.eColor.PURPLE)
			{
				text = string.Format(text, 2);
			}
			else
			{
				text = string.Format(text, 3);
			}
			this.OpenEffectObj = Singleton<AssetLoader>.instance.LoadResAsGameObject(text, true, 0U);
			if (this.OpenEffectObj != null)
			{
				Utility.AttachTo(this.OpenEffectObj, this.mEffectPos, false);
			}
		}

		// Token: 0x0600FD58 RID: 64856 RVA: 0x0045C094 File Offset: 0x0045A494
		private void UpdateActor(int iPetID)
		{
			PetTable tableItem = Singleton<TableManager>.instance.GetTableItem<PetTable>(iPetID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("can not find PetTable with id:{0}", new object[]
				{
					iPetID
				});
			}
			else
			{
				ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.ModeID, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
					{
						tableItem.ModeID
					});
				}
				else
				{
					if (this.OpenEffectObj == null)
					{
						return;
					}
					GameObject gameObject = Utility.FindGameObject(this.OpenEffectObj, this.AttachPointPath, true);
					if (gameObject == null)
					{
						return;
					}
					GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(tableItem2.ModelPath, true, 0U);
					if (gameObject2 == null)
					{
						return;
					}
					Utility.AttachTo(gameObject2, gameObject, false);
					Transform[] componentsInChildren = gameObject2.GetComponentsInChildren<Transform>(true);
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						componentsInChildren[i].gameObject.layer = 5;
					}
					Vector3 localPosition = gameObject2.GetComponent<Transform>().localPosition;
					Quaternion localRotation = gameObject2.GetComponent<Transform>().localRotation;
					gameObject2.GetComponent<Transform>().localPosition = new Vector3(localPosition.x, (float)tableItem.OpenEggHeight, localPosition.z);
					gameObject2.GetComponent<Transform>().localRotation = Quaternion.Euler(localRotation.x, (float)tableItem.OpenEggRotation / 1000f, localRotation.z);
					gameObject2.GetComponent<Transform>().localScale = new Vector3((float)tableItem.OpenEggModelScale[0], (float)tableItem.OpenEggModelScale[1], (float)tableItem.OpenEggModelScale[2]);
					this.AnimControl = gameObject2.GetComponent<GeAnimDescProxy>();
					if (this.AnimControl != null)
					{
						this.AnimControl.ChangeAction(tableItem.OpenEggAction, false, 1f, 0f);
						GeAnimDesc geAnimDesc = this.AnimControl.FindAnimDescByName(tableItem.OpenEggAction);
						if (geAnimDesc != null)
						{
							this.SpecialActionTimeLen = geAnimDesc.timeLen;
							this.bStartIdleAction = true;
						}
					}
					Vector3 avatarPos = this.mAvatarRenderer.avatarPos;
					this.mAvatarRenderer.CreateEffect("Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", 999999f, avatarPos, 1f, 1f, false, false);
				}
			}
		}

		// Token: 0x0600FD59 RID: 64857 RVA: 0x0045C2E8 File Offset: 0x0045A6E8
		private void UpdateActorInfo()
		{
			PetInfo newOpenPet = DataManager<PetDataManager>.GetInstance().GetNewOpenPet();
			if (newOpenPet.dataId == 0U)
			{
				return;
			}
			PetTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>((int)newOpenPet.dataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.mAvatarRenderer.gameObject.CustomActive(true);
			MonoSingleton<AudioManager>.instance.PlaySound(3321);
			this.UpdateActor((int)newOpenPet.dataId);
			this.mTitle.gameObject.CustomActive(true);
			this.mName.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, tableItem.Quality);
			this.mName.gameObject.CustomActive(true);
			this.mGoTo.gameObject.CustomActive(true);
			this.mQuitTip.gameObject.CustomActive(true);
		}

		// Token: 0x0600FD5A RID: 64858 RVA: 0x0045C3C0 File Offset: 0x0045A7C0
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FD5B RID: 64859 RVA: 0x0045C3C4 File Offset: 0x0045A7C4
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeIntval += timeElapsed;
			if (this.fTimeIntval > this.fTimeValue && !this.bInitActor && this.bIsFirstClick)
			{
				this.bInitActor = true;
				this.UpdateActorInfo();
			}
			if (this.bStartIdleAction)
			{
				this.SpecialActionTimeIntrval += timeElapsed;
				if (this.SpecialActionTimeIntrval >= this.SpecialActionTimeLen && this.AnimControl != null)
				{
					this.AnimControl.ChangeAction("Anim_Idle01", true, 1f, 0f);
					this.bStartIdleAction = false;
				}
			}
			if (null != this.mAvatarRenderer)
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
				this.mAvatarRenderer.m_LightRot = Global.Settings.avatarLightDir;
			}
		}

		// Token: 0x0600FD5C RID: 64860 RVA: 0x0045C5F0 File Offset: 0x0045A9F0
		protected override void _bindExUI()
		{
			this.mEffectPos = this.mBind.GetGameObject("EffectPos");
			this.mAvatarRenderer = this.mBind.GetCom<GeAvatarRendererEx>("AvatarRenderer");
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mBack = this.mBind.GetCom<Button>("Back");
			this.mBack.onClick.AddListener(new UnityAction(this._onBackButtonClick));
			this.mGoTo = this.mBind.GetCom<Button>("GoTo");
			this.mGoTo.onClick.AddListener(new UnityAction(this._onGoToButtonClick));
			this.mTitle = this.mBind.GetGameObject("Title");
			this.mQuitTip = this.mBind.GetCom<Text>("QuitTip");
		}

		// Token: 0x0600FD5D RID: 64861 RVA: 0x0045C6D0 File Offset: 0x0045AAD0
		protected override void _unbindExUI()
		{
			this.mEffectPos = null;
			this.mAvatarRenderer = null;
			this.mName = null;
			this.mBack.onClick.RemoveListener(new UnityAction(this._onBackButtonClick));
			this.mBack = null;
			this.mGoTo.onClick.RemoveListener(new UnityAction(this._onGoToButtonClick));
			this.mGoTo = null;
			this.mTitle = null;
			this.mQuitTip = null;
		}

		// Token: 0x0600FD5E RID: 64862 RVA: 0x0045C746 File Offset: 0x0045AB46
		private void _onBackButtonClick()
		{
			if (this.bIsFirstClick && this.fTimeIntval < this.fTimeValue)
			{
				this.bIsFirstClick = false;
				this.UpdateActorInfo();
				return;
			}
			this.frameMgr.CloseFrame<OpenPetEggFrame>(this, false);
		}

		// Token: 0x0600FD5F RID: 64863 RVA: 0x0045C780 File Offset: 0x0045AB80
		private void _onGoToButtonClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PackageNewFrame>(null))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PackageSwitch2OneGroup, EPackageOpenMode.Pet, null, null, null);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, EPackageOpenMode.Pet, string.Empty);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PetPacketFrame>(null))
			{
				PetPacketFrame petPacketFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PetPacketFrame)) as PetPacketFrame;
				if (petPacketFrame != null)
				{
					petPacketFrame.SetPetToggle();
				}
			}
			this.frameMgr.CloseFrame<OpenPetEggFrame>(this, false);
		}

		// Token: 0x04009F2B RID: 40747
		private string AttachPointPath = "EffUI_chongwudanfuhua/Dummy";

		// Token: 0x04009F2C RID: 40748
		private ItemData PetEggData;

		// Token: 0x04009F2D RID: 40749
		private GameObject OpenEffectObj;

		// Token: 0x04009F2E RID: 40750
		private GeAnimDescProxy AnimControl;

		// Token: 0x04009F2F RID: 40751
		private bool bInitActor;

		// Token: 0x04009F30 RID: 40752
		private float fTimeIntval;

		// Token: 0x04009F31 RID: 40753
		private float fTimeValue = 0.8f;

		// Token: 0x04009F32 RID: 40754
		private bool bIsFirstClick = true;

		// Token: 0x04009F33 RID: 40755
		private float SpecialActionTimeLen;

		// Token: 0x04009F34 RID: 40756
		private bool bStartIdleAction;

		// Token: 0x04009F35 RID: 40757
		private float SpecialActionTimeIntrval;

		// Token: 0x04009F36 RID: 40758
		private GameObject mEffectPos;

		// Token: 0x04009F37 RID: 40759
		private GeAvatarRendererEx mAvatarRenderer;

		// Token: 0x04009F38 RID: 40760
		private Text mName;

		// Token: 0x04009F39 RID: 40761
		private Button mBack;

		// Token: 0x04009F3A RID: 40762
		private Button mGoTo;

		// Token: 0x04009F3B RID: 40763
		private GameObject mTitle;

		// Token: 0x04009F3C RID: 40764
		private Text mQuitTip;
	}
}
