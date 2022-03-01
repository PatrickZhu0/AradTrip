using System;
using GameClient;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02001595 RID: 5525
public class PlayerTryOnFrame : ClientFrame
{
	// Token: 0x0600D831 RID: 55345 RVA: 0x003608D6 File Offset: 0x0035ECD6
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/Common/PlayerTryOnFrame";
	}

	// Token: 0x0600D832 RID: 55346 RVA: 0x003608E0 File Offset: 0x0035ECE0
	protected sealed override void _OnOpenFrame()
	{
		int num = (int)this.userData;
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		if (tableItem.SubType == ItemTable.eSubType.GiftPackage)
		{
			GiftPackTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(tableItem.PackageID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			FlatBufferArray<int> items = tableItem2.Items;
			bool flag = false;
			for (int i = 0; i < items.Length; i++)
			{
				GiftTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(items[i], string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					if (tableItem3.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
					{
						if (!flag)
						{
							flag = true;
							this._InitAvatar(tableItem3.ItemID);
						}
						else
						{
							ItemTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem3.ItemID, string.Empty, string.Empty);
							if (tableItem4 != null)
							{
								EFashionWearSlotType equipSlotType = this.GetEquipSlotType(tableItem4);
								DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.mAvartarRenderer, equipSlotType, tableItem4.ID, null, 0, false);
							}
						}
					}
				}
			}
			this.mAvartarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
		}
		else
		{
			this._InitAvatar(num);
		}
	}

	// Token: 0x0600D833 RID: 55347 RVA: 0x00360A41 File Offset: 0x0035EE41
	public void Reset(int itemId)
	{
		this._InitAvatar(itemId);
	}

	// Token: 0x0600D834 RID: 55348 RVA: 0x00360A4A File Offset: 0x0035EE4A
	public override bool IsNeedUpdate()
	{
		return true;
	}

	// Token: 0x0600D835 RID: 55349 RVA: 0x00360A50 File Offset: 0x0035EE50
	protected override void _OnUpdate(float timeElapsed)
	{
		base._OnUpdate(timeElapsed);
		if (null != this.mAvartarRenderer)
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
			this.mAvartarRenderer.m_LightRot = Global.Settings.avatarLightDir;
		}
	}

	// Token: 0x0600D836 RID: 55350 RVA: 0x00360BE0 File Offset: 0x0035EFE0
	private void _InitAvatar(int itemId)
	{
		int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
		JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(jobTableID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogErrorFormat("can not find JobTable with id:{0}", new object[]
			{
				jobTableID
			});
		}
		else
		{
			ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
				{
					tableItem.Mode
				});
			}
			else
			{
				this.mAvartarRenderer.ClearAvatar();
				this.SetCameraPosYZ(itemId);
				this.mAvartarRenderer.LoadAvatar(tableItem2.ModelPath, -1);
				if (jobTableID == DataManager<PlayerBaseData>.GetInstance().JobTableID)
				{
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.mAvartarRenderer, null, false);
				}
				this.mAvartarRenderer.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
				this.mAvartarRenderer.SuitAvatar(true, false);
				if (itemId > 0)
				{
					ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						if (tableItem3.SubType == ItemTable.eSubType.FASHION_HAIR)
						{
							DataManager<PlayerBaseData>.GetInstance().AvatarEquipWing(this.mAvartarRenderer, tableItem3.ID, null, false);
						}
						else if (tableItem3.SubType == ItemTable.eSubType.FASHION_AURAS)
						{
							DataManager<PlayerBaseData>.GetInstance().AvatarEquipHalo(this.mAvartarRenderer, tableItem3.ID, null, false, false);
						}
						else if (tableItem3.SubType == ItemTable.eSubType.WEAPON)
						{
							DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.mAvartarRenderer, jobTableID, tableItem3.ID, null, false);
						}
						else if (tableItem3.SubType == ItemTable.eSubType.FASHION_WEAPON)
						{
							DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.mAvartarRenderer, jobTableID, tableItem3.ID, null, false);
						}
						else
						{
							EFashionWearSlotType equipSlotType = this.GetEquipSlotType(tableItem3);
							DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.mAvartarRenderer, equipSlotType, tableItem3.ID, null, 0, false);
						}
					}
				}
				this.mAvartarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
			}
		}
	}

	// Token: 0x0600D837 RID: 55351 RVA: 0x00360DF4 File Offset: 0x0035F1F4
	private EFashionWearSlotType GetEquipSlotType(ItemTable ItemTableData)
	{
		if (ItemTableData.SubType == ItemTable.eSubType.FASHION_HEAD)
		{
			return EFashionWearSlotType.Head;
		}
		if (ItemTableData.SubType == ItemTable.eSubType.FASHION_CHEST)
		{
			return EFashionWearSlotType.UpperBody;
		}
		if (ItemTableData.SubType == ItemTable.eSubType.FASHION_EPAULET)
		{
			return EFashionWearSlotType.Chest;
		}
		if (ItemTableData.SubType == ItemTable.eSubType.FASHION_LEG)
		{
			return EFashionWearSlotType.LowerBody;
		}
		if (ItemTableData.SubType == ItemTable.eSubType.FASHION_SASH)
		{
			return EFashionWearSlotType.Waist;
		}
		return EFashionWearSlotType.Invalid;
	}

	// Token: 0x0600D838 RID: 55352 RVA: 0x00360E50 File Offset: 0x0035F250
	protected override void _bindExUI()
	{
		this.mButtonClosePanel = this.mBind.GetCom<Button>("ButtonClosePanel");
		if (null != this.mButtonClosePanel)
		{
			this.mButtonClosePanel.onClick.AddListener(new UnityAction(this._onButtonClosePanelButtonClick));
		}
		this.mAvartarRenderer = this.mBind.GetCom<GeAvatarRendererEx>("Actorpos");
	}

	// Token: 0x0600D839 RID: 55353 RVA: 0x00360EB6 File Offset: 0x0035F2B6
	protected override void _unbindExUI()
	{
		if (null != this.mButtonClosePanel)
		{
			this.mButtonClosePanel.onClick.RemoveListener(new UnityAction(this._onButtonClosePanelButtonClick));
		}
		this.mButtonClosePanel = null;
		this.mAvartarRenderer = null;
	}

	// Token: 0x0600D83A RID: 55354 RVA: 0x00360EF3 File Offset: 0x0035F2F3
	private void _onButtonClosePanelButtonClick()
	{
		base.Close(false);
	}

	// Token: 0x0600D83B RID: 55355 RVA: 0x00360EFC File Offset: 0x0035F2FC
	private void SetCameraPosYZ(int itemId)
	{
		if (this.mAvartarRenderer != null && this.mAnniversaryItemId == itemId)
		{
			this.mAvartarRenderer.m_CameraPos.y = 1.74f;
			this.mAvartarRenderer.m_CameraPos.z = -4.5f;
		}
	}

	// Token: 0x04007EEE RID: 32494
	private int mAnniversaryItemId = 535002503;

	// Token: 0x04007EEF RID: 32495
	private Button mButtonClosePanel;

	// Token: 0x04007EF0 RID: 32496
	private GeAvatarRendererEx mAvartarRenderer;
}
