using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001976 RID: 6518
public class TitleView : MonoBehaviour
{
	// Token: 0x0600FD45 RID: 64837 RVA: 0x0045B330 File Offset: 0x00459730
	public void InitUI(int index)
	{
		this.selectTitleData = new PlayerTitleInfo();
		this.titleList.Clear();
		this.titleComUIList.Initialize();
		this.titleComUIList.onItemVisiable = delegate(ComUIListElementScript item)
		{
			if (item.m_index >= 0 && item.m_index < this.titleList.Count)
			{
				this._UpdateItem(item);
			}
		};
		this.titleComUIList.OnItemRecycle = delegate(ComUIListElementScript item)
		{
			if (item.m_index >= 0 && item.m_index < this.titleList.Count)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Toggle com = component.GetCom<Toggle>("selectToggle");
				com.onValueChanged.RemoveAllListeners();
			}
		};
		this._InitModel();
		this.TakeUp.onClick.RemoveAllListeners();
		this.TakeUp.onClick.AddListener(delegate()
		{
			DataManager<TitleDataManager>.GetInstance().SendNewTitleTakeUpReq(this.selectTitleData.guid, this.selectTitleData.titleId);
		});
		this.TakeOff.onClick.RemoveAllListeners();
		this.TakeOff.onClick.AddListener(delegate()
		{
			DataManager<TitleDataManager>.GetInstance().SendNewTitleTakeOffReq(this.selectTitleData.guid, this.selectTitleData.titleId);
		});
		for (int i = 0; i < this.MainTab.Length; i++)
		{
			int tempIndex = i;
			this.MainTab[i].onValueChanged.RemoveAllListeners();
			this.MainTab[i].onValueChanged.AddListener(delegate(bool value)
			{
				if (value)
				{
					this.selectToggleIndex = tempIndex;
					this.UpdateToggleUI(tempIndex);
				}
			});
		}
	}

	// Token: 0x0600FD46 RID: 64838 RVA: 0x0045B448 File Offset: 0x00459848
	public void _InitModel()
	{
		JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogError("职业ID找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
		}
		else
		{
			ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogError("职业ID Mode表 找不到 " + DataManager<PlayerBaseData>.GetInstance().JobTableID.ToString() + "\n");
			}
			else
			{
				this.m_AvatarRenderer.LoadAvatar(tableItem2.ModelPath, -1);
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.m_AvatarRenderer, null, false);
				this.m_AvatarRenderer.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
				this.m_AvatarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
			}
		}
	}

	// Token: 0x0600FD47 RID: 64839 RVA: 0x0045B55C File Offset: 0x0045995C
	private void Update()
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

	// Token: 0x0600FD48 RID: 64840 RVA: 0x0045B6E8 File Offset: 0x00459AE8
	public void UpdateToggleUI(int index = -1)
	{
		if (index == -1)
		{
			this.titleList = DataManager<TitleDataManager>.GetInstance().getTitleListForSubType(this.selectToggleIndex);
		}
		else
		{
			this.titleList = DataManager<TitleDataManager>.GetInstance().getTitleListForSubType(index);
		}
		if (this.titleList != null)
		{
			if (this.titleList.Count > 0)
			{
				if (this.selectTitleData.guid != 0UL)
				{
					this._UpdateSelectItem(this.selectTitleData);
				}
				else
				{
					this._UpdateSelectItem(this.titleList[0]);
				}
			}
			this.titleComUIList.SetElementAmount(this.titleList.Count);
		}
		if (this.titleList == null || this.titleList.Count == 0)
		{
			this.NoTitleTips.CustomActive(true);
			this.SetGameObjectIsShow(false);
		}
		else
		{
			this.NoTitleTips.CustomActive(false);
		}
	}

	// Token: 0x0600FD49 RID: 64841 RVA: 0x0045B7D0 File Offset: 0x00459BD0
	private void SetGameObjectIsShow(bool isFlag)
	{
		this.mDesRoot.CustomActive(isFlag);
		this.mSourceRoot.CustomActive(isFlag);
		this.mTitleImg.CustomActive(isFlag);
		this.TakeUp.CustomActive(isFlag);
		this.TakeOff.CustomActive(isFlag);
		this.mTitleRoot.CustomActive(isFlag);
	}

	// Token: 0x0600FD4A RID: 64842 RVA: 0x0045B828 File Offset: 0x00459C28
	private void _UpdateSelectItem(PlayerTitleInfo titleData)
	{
		NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>((int)titleData.titleId, string.Empty, string.Empty);
		if (tableItem != null)
		{
			this.selectTitleData = titleData;
			if (this.TitleName != null)
			{
				this.TitleName.CustomActive(false);
			}
			if (this.mTitleImg != null)
			{
				this.mTitleImg.CustomActive(false);
			}
			if (this.mTitleRoot != null)
			{
				this.mTitleRoot.CustomActive(false);
			}
			if (this.mHonorImg != null)
			{
				this.mHonorImg.CustomActive(false);
			}
			if (titleData.style == 1)
			{
				if (this.mTitleRoot != null)
				{
					this.mTitleRoot.CustomActive(true);
				}
				if (this.TitleName != null)
				{
					this.TitleName.CustomActive(true);
				}
				if (this.TitleName != null)
				{
					this.TitleName.text = titleData.name;
				}
			}
			else if (titleData.style == 2)
			{
				if (this.mTitleImg != null)
				{
					this.mTitleImg.CustomActive(true);
				}
				if (this.mTitleImg != null)
				{
					ETCImageLoader.LoadSprite(ref this.mTitleImg, tableItem.path, true);
					this.mTitleImg.SetNativeSize();
				}
			}
			else if (titleData.style == 3)
			{
				if (this.mTitleRoot != null)
				{
					this.mTitleRoot.CustomActive(true);
				}
				if (this.TitleName != null)
				{
					this.TitleName.CustomActive(true);
				}
				if (this.mHonorImg != null)
				{
					this.mHonorImg.CustomActive(true);
				}
				if (this.TitleName != null)
				{
					this.TitleName.text = titleData.name;
				}
				if (this.mHonorImg != null)
				{
					ETCImageLoader.LoadSprite(ref this.mHonorImg, tableItem.path, true);
					this.mHonorImg.SetNativeSize();
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(this.mTitleRoot.GetComponent<RectTransform>());
			}
			this.TitleDes.text = tableItem.Describe;
			this.TitleSource.text = tableItem.SourceDescribe;
			if (titleData.guid == DataManager<PlayerBaseData>.GetInstance().TitleGuid)
			{
				this.TakeUp.CustomActive(false);
				this.TakeOff.CustomActive(true);
			}
			else
			{
				this.TakeUp.CustomActive(true);
				this.TakeOff.CustomActive(false);
			}
		}
	}

	// Token: 0x0600FD4B RID: 64843 RVA: 0x0045BACC File Offset: 0x00459ECC
	private void _UpdateItem(ComUIListElementScript item)
	{
		ComCommonBind component = item.GetComponent<ComCommonBind>();
		if (component == null)
		{
			return;
		}
		GameObject gameObject = component.GetGameObject("haveEquip");
		Text com = component.GetCom<Text>("itemName");
		Image com2 = component.GetCom<Image>("Item_Img");
		Toggle com3 = component.GetCom<Toggle>("selectToggle");
		GameObject mHaveSelect = component.GetGameObject("haveSelect");
		GameObject gameObject2 = component.GetGameObject("TitleRoot");
		Image com4 = component.GetCom<Image>("HonorImg");
		if (com != null)
		{
			com.CustomActive(false);
		}
		if (com2 != null)
		{
			com2.CustomActive(false);
		}
		if (com4 != null)
		{
			com4.CustomActive(false);
		}
		if (gameObject2 != null)
		{
			gameObject2.CustomActive(false);
		}
		PlayerTitleInfo playerTitleInfo = this.titleList[item.m_index];
		NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>((int)playerTitleInfo.titleId, string.Empty, string.Empty);
		if (tableItem != null)
		{
			PlayerTitleInfo playerTitleInfo2 = this.titleList[item.m_index];
			if (playerTitleInfo2 == null)
			{
				return;
			}
			if (tableItem.Style == 1)
			{
				if (com != null)
				{
					com.CustomActive(true);
				}
				if (gameObject2 != null)
				{
					gameObject2.CustomActive(true);
				}
				if (com != null)
				{
					com.text = playerTitleInfo2.name;
				}
			}
			else if (tableItem.Style == 2)
			{
				if (com2 != null)
				{
					com2.CustomActive(true);
				}
				if (com2 != null)
				{
					ETCImageLoader.LoadSprite(ref com2, tableItem.path, true);
					com2.SetNativeSize();
				}
			}
			else if (tableItem.Style == 3)
			{
				if (com != null)
				{
					com.CustomActive(true);
				}
				if (com4 != null)
				{
					com4.CustomActive(true);
				}
				if (gameObject2 != null)
				{
					gameObject2.CustomActive(true);
				}
				if (com != null)
				{
					com.text = playerTitleInfo2.name;
				}
				if (com4 != null)
				{
					ETCImageLoader.LoadSprite(ref com4, tableItem.path, true);
					com4.SetNativeSize();
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(gameObject2.GetComponent<RectTransform>());
			}
			com3.onValueChanged.RemoveAllListeners();
			com3.onValueChanged.AddListener(delegate(bool value)
			{
				if (value)
				{
					this._UpdateSelectItem(this.titleList[item.m_index]);
					mHaveSelect.CustomActive(true);
				}
				else
				{
					mHaveSelect.CustomActive(false);
				}
			});
			if (DataManager<PlayerBaseData>.GetInstance().TitleGuid == this.titleList[item.m_index].guid)
			{
				gameObject.CustomActive(true);
			}
			else
			{
				gameObject.CustomActive(false);
			}
			if (this.selectTitleData.guid == this.titleList[item.m_index].guid)
			{
				com3.isOn = true;
			}
		}
	}

	// Token: 0x04009F19 RID: 40729
	[SerializeField]
	private Toggle[] MainTab;

	// Token: 0x04009F1A RID: 40730
	[SerializeField]
	private ComUIListScript titleComUIList;

	// Token: 0x04009F1B RID: 40731
	[SerializeField]
	private Button TakeUp;

	// Token: 0x04009F1C RID: 40732
	[SerializeField]
	private Button TakeOff;

	// Token: 0x04009F1D RID: 40733
	[SerializeField]
	private Text TitleName;

	// Token: 0x04009F1E RID: 40734
	[SerializeField]
	private Image mTitleImg;

	// Token: 0x04009F1F RID: 40735
	[SerializeField]
	private Text TitleDes;

	// Token: 0x04009F20 RID: 40736
	[SerializeField]
	private Text TitleSource;

	// Token: 0x04009F21 RID: 40737
	[SerializeField]
	private GameObject PeopleMode;

	// Token: 0x04009F22 RID: 40738
	[SerializeField]
	private GeAvatarRendererEx m_AvatarRenderer;

	// Token: 0x04009F23 RID: 40739
	[SerializeField]
	private GameObject NoTitleTips;

	// Token: 0x04009F24 RID: 40740
	[SerializeField]
	private GameObject mDesRoot;

	// Token: 0x04009F25 RID: 40741
	[SerializeField]
	private GameObject mSourceRoot;

	// Token: 0x04009F26 RID: 40742
	[SerializeField]
	private GameObject mTitleRoot;

	// Token: 0x04009F27 RID: 40743
	[SerializeField]
	private Image mHonorImg;

	// Token: 0x04009F28 RID: 40744
	private List<PlayerTitleInfo> titleList = new List<PlayerTitleInfo>();

	// Token: 0x04009F29 RID: 40745
	private PlayerTitleInfo selectTitleData = new PlayerTitleInfo();

	// Token: 0x04009F2A RID: 40746
	private int selectToggleIndex;
}
