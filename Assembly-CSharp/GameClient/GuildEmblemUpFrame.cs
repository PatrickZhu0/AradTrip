using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001621 RID: 5665
	public class GuildEmblemUpFrame : ClientFrame
	{
		// Token: 0x0600DE59 RID: 56921 RVA: 0x003880D4 File Offset: 0x003864D4
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildEmblemUp";
		}

		// Token: 0x0600DE5A RID: 56922 RVA: 0x003880DC File Offset: 0x003864DC
		protected override void _OnOpenFrame()
		{
			this.needCostMaterials = new CachedObjectDicManager<int, CostMaterialItem>();
			this.BindUIEvent();
			this.nGuildLvLimit = DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpGuildLvLimit();
			this.nPlayerLvLimit = DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpPlayerLvLimit();
			this.nHonourLvLimit = DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpHonourLvLimit();
			this.UpdateEmblemInfo();
		}

		// Token: 0x0600DE5B RID: 56923 RVA: 0x00388130 File Offset: 0x00386530
		protected override void _OnCloseFrame()
		{
			this.needCostMaterials.DestroyAllObjects();
			this.UnBindUIEvent();
		}

		// Token: 0x0600DE5C RID: 56924 RVA: 0x00388144 File Offset: 0x00386544
		protected override void _bindExUI()
		{
			this.activeEmblem = this.mBind.GetCom<Button>("activeEmblem");
			this.activeEmblem.SafeSetOnClickListener(delegate
			{
				if (DataManager<GuildDataManager>.GetInstance().myGuild != null && DataManager<GuildDataManager>.GetInstance().myGuild.nLevel < this.nGuildLvLimit)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("emblem_active_need_guild_lv", this.nGuildLvLimit), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level < this.nPlayerLvLimit)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("emblem_active_need_player_lv", this.nPlayerLvLimit), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.HONOUR) < this.nHonourLvLimit)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("emblem_active_need_honour_lv", this.nHonourLvLimit), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				List<int> list = null;
				if (!DataManager<GuildDataManager>.GetInstance().IsCostEnoughToLvUpEmblem(ref list) && list != null && list.Count > 0)
				{
					ItemComeLink.OnLink(list[0], 0, true, null, false, false, false, null, string.Empty);
					return;
				}
				DataManager<GuildDataManager>.GetInstance().SendWorldGuildEmblemUpReq();
			});
			this.levelUpEmblem = this.mBind.GetCom<Button>("levelUpEmblem");
			this.levelUpEmblem.SafeSetOnClickListener(delegate
			{
				int emblemLv = DataManager<GuildDataManager>.GetInstance().GetEmblemLv();
				int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.HONOUR);
				int emblemNeedHonourLv = DataManager<GuildDataManager>.GetInstance().GetEmblemNeedHonourLv(emblemLv + 1);
				if (buildingLevel < emblemNeedHonourLv)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("emblem_lv_up_need_honour_1v_not_ok2", emblemNeedHonourLv), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				List<int> list = null;
				if (!DataManager<GuildDataManager>.GetInstance().IsCostEnoughToLvUpEmblem(ref list) && list != null && list.Count > 0)
				{
					ItemComeLink.OnLink(list[0], 0, true, null, false, false, false, null, string.Empty);
					return;
				}
				DataManager<GuildDataManager>.GetInstance().SendWorldGuildEmblemUpReq();
			});
			this.lv1 = this.mBind.GetGameObject("lv1");
			this.lvMax = this.mBind.GetGameObject("lvMax");
			this.compare = this.mBind.GetGameObject("compare");
			this.lvUpText = this.mBind.GetCom<Text>("lvUpText");
			this.limit = this.mBind.GetCom<Text>("limit");
			this.goMaterialPrefab = this.mBind.GetGameObject("ItemParent");
			this.goMaterialParent = this.mBind.GetGameObject("CostMaterials");
			this.emblemLv1 = this.mBind.GetCom<GuildEmblemAttrItem>("emblemLv1");
			this.emblemLvMax = this.mBind.GetCom<GuildEmblemAttrItem>("emblemLvMax");
			this.emblemLvNow = this.mBind.GetCom<GuildEmblemAttrItem>("emblemLvNow");
			this.emblemLvNext = this.mBind.GetCom<GuildEmblemAttrItem>("emblemLvNext");
			this.Close = this.mBind.GetCom<Button>("Close");
			this.Close.SafeSetOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<GuildEmblemUpFrame>(this, false);
			});
			this.icon = this.mBind.GetCom<Image>("icon");
			this.maxLv = this.mBind.GetCom<Image>("maxLv");
			this.caiLiaoTip = this.mBind.GetCom<Text>("caiLiaoTip");
			this.activeEmblemText = this.mBind.GetCom<Text>("activeEmblemText");
			this.showAttrs = this.mBind.GetCom<Button>("showAttrs");
			this.showAttrs.SafeSetOnClickListener(delegate
			{
				this.frameMgr.OpenFrame<GuildEmblemAttrShowFrame>(FrameLayer.Middle, null, string.Empty);
			});
		}

		// Token: 0x0600DE5D RID: 56925 RVA: 0x00388360 File Offset: 0x00386760
		protected override void _unbindExUI()
		{
			this.activeEmblem = null;
			this.levelUpEmblem = null;
			this.lv1 = null;
			this.lvMax = null;
			this.compare = null;
			this.lvUpText = null;
			this.limit = null;
			this.goMaterialPrefab = null;
			this.goMaterialParent = null;
			this.emblemLv1 = null;
			this.emblemLvMax = null;
			this.emblemLvNow = null;
			this.emblemLvNext = null;
			this.Close = null;
			this.icon = null;
			this.maxLv = null;
			this.caiLiaoTip = null;
			this.activeEmblemText = null;
			this.showAttrs = null;
		}

		// Token: 0x0600DE5E RID: 56926 RVA: 0x003883F4 File Offset: 0x003867F4
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildEmblemLevelUp, new ClientEventSystem.UIEventHandler(this._OnGuildEmblemLevelUp));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateLevelUpMaterials));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x0600DE5F RID: 56927 RVA: 0x003884AC File Offset: 0x003868AC
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildEmblemLevelUp, new ClientEventSystem.UIEventHandler(this._OnGuildEmblemLevelUp));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyGet, new ClientEventSystem.UIEventHandler(this._OnUpdateLevelUpMaterials));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x0600DE60 RID: 56928 RVA: 0x00388564 File Offset: 0x00386964
		private void UpdateEmblemInfo()
		{
			int emblemLv = DataManager<GuildDataManager>.GetInstance().GetEmblemLv();
			if (emblemLv < 0)
			{
				return;
			}
			int maxEmblemLv = DataManager<GuildDataManager>.GetInstance().GetMaxEmblemLv();
			this.activeEmblem.CustomActive(emblemLv == 0);
			this.levelUpEmblem.CustomActive(emblemLv > 0);
			this.lv1.CustomActive(emblemLv == 0);
			this.lvMax.CustomActive(emblemLv == maxEmblemLv);
			this.compare.CustomActive(emblemLv > 0 && emblemLv < maxEmblemLv);
			int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.HONOUR);
			int emblemNeedHonourLv = DataManager<GuildDataManager>.GetInstance().GetEmblemNeedHonourLv(emblemLv + 1);
			if (emblemNeedHonourLv > buildingLevel)
			{
				this.lvUpText.SafeSetText(TR.Value("emblem_lv_up_need_honour_1v", emblemNeedHonourLv));
				this.activeEmblemText.SafeSetText(TR.Value("emblem_lv_up_need_honour_1v", emblemNeedHonourLv));
				this.activeEmblem.SafeSetGray(true, true);
				this.levelUpEmblem.SafeSetGray(true, true);
			}
			else
			{
				this.lvUpText.SafeSetText(TR.Value("emblem_lv_up"));
				this.activeEmblemText.SafeSetText(TR.Value("emblem_active"));
				this.activeEmblem.SafeSetGray(false, true);
				this.levelUpEmblem.SafeSetGray(false, true);
			}
			this.UpdateLevelUpMaterials();
			if (emblemLv == 0)
			{
				if (this.emblemLv1 != null)
				{
					this.emblemLv1.SetUp(1);
				}
			}
			else if (emblemLv == maxEmblemLv)
			{
				if (this.emblemLvMax != null)
				{
					this.emblemLvMax.SetUp(maxEmblemLv);
				}
			}
			else
			{
				if (this.emblemLvNow != null)
				{
					this.emblemLvNow.SetUp(emblemLv);
				}
				if (this.emblemLvNext != null)
				{
					this.emblemLvNext.SetUp(emblemLv + 1);
				}
			}
			int iEmblemLv;
			if (emblemLv == 0)
			{
				iEmblemLv = 1;
			}
			else if (emblemLv == maxEmblemLv)
			{
				iEmblemLv = maxEmblemLv;
			}
			else
			{
				iEmblemLv = emblemLv;
			}
			this.icon.SafeSetImage(DataManager<GuildDataManager>.GetInstance().GetEmblemIconPath(iEmblemLv), false);
			if (emblemLv == maxEmblemLv)
			{
				this.levelUpEmblem.CustomActive(false);
				this.caiLiaoTip.CustomActive(false);
			}
		}

		// Token: 0x0600DE61 RID: 56929 RVA: 0x0038878C File Offset: 0x00386B8C
		private void UpdateLevelUpMaterials()
		{
			this.needCostMaterials.RecycleAllObject();
			int[] array = null;
			int[] array2 = null;
			int emblemLv = DataManager<GuildDataManager>.GetInstance().GetEmblemLv();
			DataManager<GuildDataManager>.GetInstance().GetEmblemLvUpCost(emblemLv + 1, ref array, ref array2);
			if (array != null && array2 != null)
			{
				int num = Math.Min(array.Length, array2.Length);
				for (int i = 0; i < num; i++)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(array[i]);
					if (commonItemTableDataByID != null)
					{
						if (this.needCostMaterials.HasObject(array[i]))
						{
							this.needCostMaterials.RefreshObject(array[i], new object[]
							{
								commonItemTableDataByID,
								false,
								array2[i]
							});
						}
						else
						{
							this.needCostMaterials.Create(array[i], new object[]
							{
								this.goMaterialParent,
								this.goMaterialPrefab,
								commonItemTableDataByID,
								this,
								false,
								array2[i]
							});
						}
					}
				}
				this.needCostMaterials.Filter(null);
			}
		}

		// Token: 0x0600DE62 RID: 56930 RVA: 0x003888A4 File Offset: 0x00386CA4
		private void _OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this.UpdateLevelUpMaterials();
		}

		// Token: 0x0600DE63 RID: 56931 RVA: 0x003888AC File Offset: 0x00386CAC
		private void _OnAddNewItem(List<Item> items)
		{
			this.UpdateLevelUpMaterials();
		}

		// Token: 0x0600DE64 RID: 56932 RVA: 0x003888B4 File Offset: 0x00386CB4
		private void OnUpdateItem(List<Item> items)
		{
			this.UpdateLevelUpMaterials();
		}

		// Token: 0x0600DE65 RID: 56933 RVA: 0x003888BC File Offset: 0x00386CBC
		private void _OnUpdateLevelUpMaterials(UIEvent uiEvent)
		{
			this.UpdateLevelUpMaterials();
		}

		// Token: 0x0600DE66 RID: 56934 RVA: 0x003888C4 File Offset: 0x00386CC4
		private void _OnGuildEmblemLevelUp(UIEvent a_event)
		{
			this.UpdateEmblemInfo();
		}

		// Token: 0x040083B6 RID: 33718
		private CachedObjectDicManager<int, CostMaterialItem> needCostMaterials;

		// Token: 0x040083B7 RID: 33719
		private int nGuildLvLimit = 3;

		// Token: 0x040083B8 RID: 33720
		private int nPlayerLvLimit = 30;

		// Token: 0x040083B9 RID: 33721
		private int nHonourLvLimit = 3;

		// Token: 0x040083BA RID: 33722
		private Button activeEmblem;

		// Token: 0x040083BB RID: 33723
		private Button levelUpEmblem;

		// Token: 0x040083BC RID: 33724
		private GameObject lv1;

		// Token: 0x040083BD RID: 33725
		private GameObject lvMax;

		// Token: 0x040083BE RID: 33726
		private GameObject compare;

		// Token: 0x040083BF RID: 33727
		private Text lvUpText;

		// Token: 0x040083C0 RID: 33728
		private Text limit;

		// Token: 0x040083C1 RID: 33729
		private GameObject goMaterialParent;

		// Token: 0x040083C2 RID: 33730
		private GameObject goMaterialPrefab;

		// Token: 0x040083C3 RID: 33731
		private GuildEmblemAttrItem emblemLv1;

		// Token: 0x040083C4 RID: 33732
		private GuildEmblemAttrItem emblemLvMax;

		// Token: 0x040083C5 RID: 33733
		private GuildEmblemAttrItem emblemLvNow;

		// Token: 0x040083C6 RID: 33734
		private GuildEmblemAttrItem emblemLvNext;

		// Token: 0x040083C7 RID: 33735
		private new Button Close;

		// Token: 0x040083C8 RID: 33736
		private Image icon;

		// Token: 0x040083C9 RID: 33737
		private Image maxLv;

		// Token: 0x040083CA RID: 33738
		private Text caiLiaoTip;

		// Token: 0x040083CB RID: 33739
		private Text activeEmblemText;

		// Token: 0x040083CC RID: 33740
		private Button showAttrs;
	}
}
