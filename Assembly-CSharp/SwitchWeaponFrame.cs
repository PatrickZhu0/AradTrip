using System;
using System.Collections.Generic;
using DG.Tweening;
using GameClient;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200170E RID: 5902
public class SwitchWeaponFrame : ClientFrame
{
	// Token: 0x0600E7FB RID: 59387 RVA: 0x003D3C6C File Offset: 0x003D206C
	protected override void _bindExUI()
	{
		this.itemRoot = this.mBind.GetGameObject("ItemRoot");
		this.sideWeaponObj[0] = this.mBind.GetGameObject("sideWeapon1");
		this.sideWeaponObj[1] = this.mBind.GetGameObject("sideWeapon2");
		this.sideWeaponObj[2] = this.mBind.GetGameObject("sideWeapon3");
		this.sideWeaponObj[3] = this.mBind.GetGameObject("sideWeapon4");
		this.sideWeaponObj[4] = this.mBind.GetGameObject("sideWeapon5");
		this.mainWeaponContainer = this.mBind.GetGameObject("mainWeapon");
		this.btnClose = this.mBind.GetCom<Button>("BtnClose");
		this.changeBtn = this.mBind.GetCom<Button>("changeBtn");
		this.mainWeaponIcon = this.mBind.GetCom<Image>("mainWeaponIcon");
		this.mainWeaponBack = this.mBind.GetCom<Image>("mainWeaponBack");
		this.mainWeaponLv = this.mBind.GetCom<Text>("mainWeaponLv");
		this.mainWeaponStrenghLv = this.mBind.GetCom<Text>("mainWeaponStrengthLv");
		this.sideWeaponIcon = this.mBind.GetCom<Image>("sideWeaponIcon");
		this.sideWeaponBack = this.mBind.GetCom<Image>("sideWeaponBack");
		this.sideWeaponLv = this.mBind.GetCom<Text>("sideWeaponLv");
		this.sideWeaponStrenghLv = this.mBind.GetCom<Text>("sideWeaponStrengthLv");
		this.mainStrBack = this.mBind.GetGameObject("mainWeaponStrengthBack");
		this.sideStrBack = this.mBind.GetGameObject("sideWeaponStrengthback");
		this.mainLvBack = this.mBind.GetGameObject("mainLvBack");
		this.sideLvBack = this.mBind.GetGameObject("sideLvBack");
		this.arrow1 = this.mBind.GetCom<Image>("arrow1");
		this.arrow2 = this.mBind.GetCom<Image>("arrow2");
		this.switchText = this.mBind.GetGameObject("switchText");
		this.m_comItemList = this.mBind.GetCom<ComUIListScript>("comUIList");
		this.btnClose.onClick.RemoveAllListeners();
		this.btnClose.onClick.AddListener(delegate()
		{
			base.Close(false);
		});
		this.changeBtn.onClick.RemoveAllListeners();
		this.changeBtn.onClick.AddListener(delegate()
		{
			if (this.canSwitchweapon)
			{
				this.ChangeSwitchArrowState(false);
				this.canSwitchweapon = false;
				TweenSettingsExtensions.OnComplete<Tweener>(ShortcutExtensions.DOScale(this.arrow1.transform, 1.1f, 0.1f), delegate()
				{
					ShortcutExtensions.DOScale(this.arrow1.transform, 1f, 0.1f);
				});
				TweenSettingsExtensions.OnComplete<Tweener>(ShortcutExtensions.DOScale(this.arrow2.transform, 1.1f, 0.1f), delegate()
				{
					ShortcutExtensions.DOScale(this.arrow2.transform, 1f, 0.1f);
				});
				DataManager<ItemDataManager>.GetInstance().UseItem(this.sideWeapon, false, 0, 0);
				MonoSingleton<AudioManager>.instance.PlaySound(102);
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(1000, delegate
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SwitchWeaponFrame>(null))
					{
						this.canSwitchweapon = true;
						this.ChangeSwitchArrowState(true);
					}
				}, 0, 0, false);
			}
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ChangeWeapon");
		});
	}

	// Token: 0x0600E7FC RID: 59388 RVA: 0x003D3F01 File Offset: 0x003D2301
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/Package/SwitchWeaponFrame";
	}

	// Token: 0x0600E7FD RID: 59389 RVA: 0x003D3F08 File Offset: 0x003D2308
	protected override void _OnOpenFrame()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this.InitWeaponInfo));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SwitchEquipSuccess, new ClientEventSystem.UIEventHandler(this.InitWeaponInfo));
		this.InitWeaponInfo(null);
		this.canSwitchweapon = true;
		this.ChangeSwitchArrowState(true);
	}

	// Token: 0x0600E7FE RID: 59390 RVA: 0x003D3F60 File Offset: 0x003D2360
	private void InitWeaponInfo(UIEvent uiEvent)
	{
		this.CreateMainWeapon();
		this.CreateSideWeapon();
		this.CreateSideWeaponPack();
		this.MainAndSideBothHaveWeapon();
	}

	// Token: 0x0600E7FF RID: 59391 RVA: 0x003D3F7C File Offset: 0x003D237C
	private void CreateMainWeapon()
	{
		ulong id = DataManager<ItemDataManager>.GetInstance().GetMainWeapon();
		this.mainWeapon = null;
		if (id > 0UL)
		{
			ItemData data = DataManager<ItemDataManager>.GetInstance().GetItem(id);
			if (data == null)
			{
				return;
			}
			this.mainWeapon = data;
			Button component = this.mainWeaponIcon.gameObject.GetComponent<Button>();
			if (component != null)
			{
				component.onClick.RemoveAllListeners();
				component.onClick.AddListener(delegate()
				{
					if (id > 0UL)
					{
						List<TipFuncButon> list = new List<TipFuncButon>();
						list.Add(new TipFuncButon
						{
							text = TR.Value("tip_takeoff"),
							callback = new OnTipFuncClicked(this.UnloadMainWeapon)
						});
						DataManager<ItemTipManager>.GetInstance().ShowTip(data, list, 4, true, false, true);
					}
				});
			}
			this.mainWeaponIcon.color = new Color(1f, 1f, 1f, 1f);
			this.SetMainWeapon(data.LevelLimit, data.StrengthenLevel);
			this.SetBackAndIcon(this.mainWeaponBack, this.mainWeaponIcon, data.Icon, data.GetQualityInfo().Background);
		}
		else
		{
			this.mainWeaponIcon.color = new Color(1f, 1f, 1f, 0f);
			this.SetBackAndIcon(this.mainWeaponBack, this.mainWeaponIcon, string.Empty, this.defaultBack);
			this.SetMainWeapon(0, 0);
		}
	}

	// Token: 0x0600E800 RID: 59392 RVA: 0x003D40EF File Offset: 0x003D24EF
	private void UnloadMainWeapon(ItemData item, object param1)
	{
		DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
		DataManager<ItemTipManager>.GetInstance().CloseAll();
	}

	// Token: 0x0600E801 RID: 59393 RVA: 0x003D410C File Offset: 0x003D250C
	private void CreateSideWeapon()
	{
		this.sideWeapon = null;
		Dictionary<byte, ulong> sideWeaponDic = DataManager<SwitchWeaponDataManager>.GetInstance().GetSideWeaponDic();
		foreach (KeyValuePair<byte, ulong> keyValuePair in sideWeaponDic)
		{
			ItemData data = DataManager<ItemDataManager>.GetInstance().GetItem(keyValuePair.Value);
			this.sideWeapon = data;
			if (data == null)
			{
				this.SetSideWeapon(0, 0);
				this.SetBackAndIcon(this.sideWeaponBack, this.sideWeaponIcon, string.Empty, this.defaultBack);
				this.sideWeaponIcon.color = new Color(1f, 1f, 1f, 0f);
			}
			else
			{
				this.SetSideWeapon(data.LevelLimit, data.StrengthenLevel);
				this.sideWeaponIcon.color = new Color(1f, 1f, 1f, 1f);
				Button component = this.sideWeaponIcon.gameObject.GetComponent<Button>();
				if (component != null)
				{
					component.onClick.RemoveAllListeners();
					component.onClick.AddListener(delegate()
					{
						if (sideWeaponDic.Count > 0)
						{
							this.ShowSideWeaponInfo(data);
						}
					});
				}
				this.SetBackAndIcon(this.sideWeaponBack, this.sideWeaponIcon, data.Icon, data.GetQualityInfo().Background);
			}
			this.sideWeaponIcon.name = keyValuePair.Value.ToString();
		}
	}

	// Token: 0x0600E802 RID: 59394 RVA: 0x003D42EC File Offset: 0x003D26EC
	private void ShowSideWeaponInfo(ItemData data)
	{
		List<TipFuncButon> list = new List<TipFuncButon>();
		list.Add(new TipFuncButon
		{
			text = TR.Value("tip_takeoff"),
			callback = new OnTipFuncClicked(this._OnUnWear)
		});
		DataManager<ItemTipManager>.GetInstance().ShowTip(data, list, 4, true, false, true);
	}

	// Token: 0x0600E803 RID: 59395 RVA: 0x003D433E File Offset: 0x003D273E
	private void _OnUnWear(ItemData item, object data)
	{
		if (item != null)
		{
			DataManager<SwitchWeaponDataManager>.GetInstance().TakeOnSideWeapon(1U, 0UL);
			MonoSingleton<AudioManager>.instance.PlaySound(103);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}
	}

	// Token: 0x0600E804 RID: 59396 RVA: 0x003D436A File Offset: 0x003D276A
	private void CreateSideWeaponPack()
	{
		this._InitItemList();
	}

	// Token: 0x0600E805 RID: 59397 RVA: 0x003D4374 File Offset: 0x003D2774
	private void _InitItemList()
	{
		this.m_comItemList.Initialize();
		this.m_comItemList.onBindItem = ((GameObject obj) => this.CreateComItem(obj));
		List<ulong> idList = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Equip, ItemTable.eSubType.WEAPON);
		idList = DataManager<ItemDataManager>.GetInstance().GetOccupationFitEquip(idList);
		this.m_comItemList.onItemVisiable = delegate(ComUIListElementScript item)
		{
			ComGridBindItem component = item.GetComponent<ComGridBindItem>();
			if (item.m_index >= 0)
			{
				if (item.m_index < idList.Count)
				{
					ComItem comItem = item.gameObjectBindScript as ComItem;
					ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(idList[item.m_index]);
					if (item2 != null)
					{
						comItem.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
						comItem.Setup(item2, new ComItem.OnItemClicked(this._OnItemClicked));
						comItem.SetEnable(true);
						comItem.SetShowBetterState(true);
						comItem.SetShowUnusableState(true);
						if (component != null)
						{
							component.param1 = item.gameObject.name;
							component.param2 = item2.GUID;
						}
					}
				}
				else
				{
					ComItem comItem2 = item.gameObjectBindScript as ComItem;
					comItem2.SetupSlot(ComItem.ESlotType.Opened, string.Empty, null, string.Empty);
					comItem2.Setup(null, null);
					comItem2.SetEnable(true);
					comItem2.SetShowBetterState(false);
					comItem2.SetShowSelectState(false);
					comItem2.SetShowUnusableState(false);
					if (component != null)
					{
						component.param1 = null;
						component.param2 = 0;
					}
				}
			}
		};
		this.m_comItemList.SetElementAmount(this.GetSidePackSize());
	}

	// Token: 0x0600E806 RID: 59398 RVA: 0x003D4400 File Offset: 0x003D2800
	private int GetSidePackSize()
	{
		int num = DataManager<PlayerBaseData>.GetInstance().PackTotalSize[1];
		int count = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip).Count;
		int count2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageSubType(EPackageType.Equip, ItemTable.eSubType.WEAPON).Count;
		return num - count + count2;
	}

	// Token: 0x0600E807 RID: 59399 RVA: 0x003D4448 File Offset: 0x003D2848
	private void MainAndSideBothHaveWeapon()
	{
		bool flag = DataManager<SwitchWeaponDataManager>.GetInstance().MainAndSideBothHaveWeapon();
		this.changeBtn.interactable = flag;
		this.switchText.CustomActive(flag);
		this.ChangeSwitchArrowState(flag);
	}

	// Token: 0x0600E808 RID: 59400 RVA: 0x003D4480 File Offset: 0x003D2880
	private void ChangeSwitchArrowState(bool flag)
	{
		flag = (flag && DataManager<SwitchWeaponDataManager>.GetInstance().MainAndSideBothHaveWeapon() && this.canSwitchweapon);
		ETCImageLoader.LoadSprite(ref this.arrow1, (!flag) ? this.arrowState1 : this.arrowState2, true);
		ETCImageLoader.LoadSprite(ref this.arrow2, (!flag) ? this.arrowState1 : this.arrowState2, true);
	}

	// Token: 0x0600E809 RID: 59401 RVA: 0x003D44F5 File Offset: 0x003D28F5
	private void SetBackAndIcon(Image back, Image icon, string iconPath, string backPath)
	{
		ETCImageLoader.LoadSprite(ref icon, iconPath, true);
		ETCImageLoader.LoadSprite(ref back, backPath, true);
	}

	// Token: 0x0600E80A RID: 59402 RVA: 0x003D450C File Offset: 0x003D290C
	private void SetMainWeapon(int lv, int strengthLv)
	{
		this.mainLvBack.CustomActive(lv != 0);
		this.mainStrBack.CustomActive(strengthLv != 0);
		this.mainWeaponLv.gameObject.CustomActive(lv != 0);
		this.mainWeaponStrenghLv.gameObject.CustomActive(strengthLv != 0);
		this.mainWeaponLv.text = "LV." + lv;
		this.mainWeaponStrenghLv.text = "+" + strengthLv;
	}

	// Token: 0x0600E80B RID: 59403 RVA: 0x003D45A4 File Offset: 0x003D29A4
	private void SetSideWeapon(int lv, int strengthLv)
	{
		this.sideLvBack.CustomActive(lv != 0);
		this.sideStrBack.CustomActive(strengthLv != 0);
		this.sideWeaponLv.gameObject.CustomActive(lv != 0);
		this.sideWeaponStrenghLv.gameObject.CustomActive(strengthLv != 0);
		this.sideWeaponLv.text = "LV." + lv;
		this.sideWeaponStrenghLv.text = "+" + strengthLv;
	}

	// Token: 0x0600E80C RID: 59404 RVA: 0x003D463C File Offset: 0x003D2A3C
	private void _OnItemClicked(GameObject obj, ItemData item)
	{
		if (item != null)
		{
			List<TipFuncButon> list = new List<TipFuncButon>();
			TipFuncButon tipFuncButon = new TipFuncButon();
			tipFuncButon.text = TR.Value("tip_wear_mainweapon");
			if (item.HasTransfered)
			{
				tipFuncButon.callback = new OnTipFuncClicked(this._TryDeTransferClicked);
			}
			else if (item.Packing)
			{
				tipFuncButon.callback = new OnTipFuncClicked(this._OnDeSealClicked);
			}
			else
			{
				tipFuncButon.callback = new OnTipFuncClicked(this._OnUseItem);
			}
			list.Add(tipFuncButon);
			tipFuncButon = new TipFuncButon();
			tipFuncButon.text = TR.Value("tip_wear_sideweapon");
			if (item.HasTransfered)
			{
				tipFuncButon.callback = new OnTipFuncClicked(this._TryDeTransferClicked);
			}
			else if (item.Packing)
			{
				tipFuncButon.callback = new OnTipFuncClicked(this._OnDeSeaSidelClicked);
			}
			else
			{
				tipFuncButon.callback = new OnTipFuncClicked(this.WearSideWeapon);
			}
			list.Add(tipFuncButon);
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, list, 4, true, false, true);
		}
	}

	// Token: 0x0600E80D RID: 59405 RVA: 0x003D474D File Offset: 0x003D2B4D
	private void _TryDeTransferClicked(ItemData item, object data)
	{
		this._RealTryDeTransferClicked(item, data);
	}

	// Token: 0x0600E80E RID: 59406 RVA: 0x003D4758 File Offset: 0x003D2B58
	private void _RealTryDeTransferClicked(ItemData item, object data)
	{
		if (item == null)
		{
			return;
		}
		SystemNotifyManager.SystemNotify(9066, delegate()
		{
			DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
			MonoSingleton<AudioManager>.instance.PlaySound(102);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}, null, new object[]
		{
			item.GetColorName(string.Empty, false)
		});
	}

	// Token: 0x0600E80F RID: 59407 RVA: 0x003D47B0 File Offset: 0x003D2BB0
	private void _OnDeSeaSidelClicked(ItemData item, object param1)
	{
		if (item != null && item.Packing)
		{
			if (item.CanEquip())
			{
				SystemNotifyManager.SystemNotify(2006, delegate()
				{
					this.WearSideWeapon(item, param1);
					MonoSingleton<AudioManager>.instance.PlaySound(102);
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}, null, new object[]
				{
					item.GetColorName(string.Empty, false)
				});
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("equip_deseal_notify_cannot", item.GetColorName(string.Empty, false)), null, string.Empty, false);
			}
		}
		Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("tipWearSideWeapon");
	}

	// Token: 0x0600E810 RID: 59408 RVA: 0x003D4870 File Offset: 0x003D2C70
	private void WearSideWeapon(ItemData item, object param1)
	{
		if (item == null)
		{
			return;
		}
		if ((int)DataManager<PlayerBaseData>.GetInstance().Level < item.LevelLimit)
		{
			SystemNotifyManager.SystemNotify(1000023, string.Empty);
		}
		else
		{
			DataManager<SwitchWeaponDataManager>.GetInstance().TakeOnSideWeapon(1U, item.GUID);
		}
		DataManager<ItemTipManager>.GetInstance().CloseAll();
		MonoSingleton<AudioManager>.instance.PlaySound(102);
		Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("tipWearSideWeapon");
	}

	// Token: 0x0600E811 RID: 59409 RVA: 0x003D48E4 File Offset: 0x003D2CE4
	private void _OnDeSealClicked(ItemData item, object data)
	{
		if (item != null && item.Packing)
		{
			if (item.CanEquip())
			{
				SystemNotifyManager.SystemNotify(2006, delegate()
				{
					DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
					MonoSingleton<AudioManager>.instance.PlaySound(102);
					DataManager<ItemTipManager>.GetInstance().CloseAll();
				}, null, new object[]
				{
					item.GetColorName(string.Empty, false)
				});
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("equip_deseal_notify_cannot", item.GetColorName(string.Empty, false)), null, string.Empty, false);
			}
		}
		Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("tipWearMainWeapon");
	}

	// Token: 0x0600E812 RID: 59410 RVA: 0x003D4998 File Offset: 0x003D2D98
	private void _OnUseItem(ItemData item, object data)
	{
		if (item != null && item.CanEquip())
		{
			DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
			MonoSingleton<AudioManager>.instance.PlaySound(102);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}
		else
		{
			SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("equip_deseal_notify_cannot", item.GetColorName(string.Empty, false)), null, string.Empty, false);
		}
		Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("tipWearMainWeapon");
	}

	// Token: 0x0600E813 RID: 59411 RVA: 0x003D4A11 File Offset: 0x003D2E11
	protected override void _OnCloseFrame()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this.InitWeaponInfo));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SwitchEquipSuccess, new ClientEventSystem.UIEventHandler(this.InitWeaponInfo));
	}

	// Token: 0x04008CA2 RID: 36002
	private GameObject itemRoot;

	// Token: 0x04008CA3 RID: 36003
	private GameObject[] sideWeaponObj = new GameObject[5];

	// Token: 0x04008CA4 RID: 36004
	private ItemData mainWeapon;

	// Token: 0x04008CA5 RID: 36005
	private ItemData sideWeapon;

	// Token: 0x04008CA6 RID: 36006
	private GameObject mainWeaponContainer;

	// Token: 0x04008CA7 RID: 36007
	private Button btnClose;

	// Token: 0x04008CA8 RID: 36008
	private Image mainWeaponIcon;

	// Token: 0x04008CA9 RID: 36009
	private Image mainWeaponBack;

	// Token: 0x04008CAA RID: 36010
	private Text mainWeaponLv;

	// Token: 0x04008CAB RID: 36011
	private Text mainWeaponStrenghLv;

	// Token: 0x04008CAC RID: 36012
	private Image sideWeaponIcon;

	// Token: 0x04008CAD RID: 36013
	private Image sideWeaponBack;

	// Token: 0x04008CAE RID: 36014
	private Text sideWeaponLv;

	// Token: 0x04008CAF RID: 36015
	private Text sideWeaponStrenghLv;

	// Token: 0x04008CB0 RID: 36016
	private string defaultBack = "UI/Image/Packed/p_UI_Common01.png:UI_Tongyong_Tubiao_White";

	// Token: 0x04008CB1 RID: 36017
	private GameObject mainStrBack;

	// Token: 0x04008CB2 RID: 36018
	private GameObject sideStrBack;

	// Token: 0x04008CB3 RID: 36019
	private GameObject mainLvBack;

	// Token: 0x04008CB4 RID: 36020
	private GameObject sideLvBack;

	// Token: 0x04008CB5 RID: 36021
	private Image arrow1;

	// Token: 0x04008CB6 RID: 36022
	private Image arrow2;

	// Token: 0x04008CB7 RID: 36023
	private Button changeBtn;

	// Token: 0x04008CB8 RID: 36024
	private ComUIListScript m_comItemList;

	// Token: 0x04008CB9 RID: 36025
	private GameObject switchText;

	// Token: 0x04008CBA RID: 36026
	private bool canSwitchweapon = true;

	// Token: 0x04008CBB RID: 36027
	private string arrowState1 = "UI/Image/Packed/p_UI_Package.png:UI_Package_Shuangwuqi_Qiehuan_Jiantou01";

	// Token: 0x04008CBC RID: 36028
	private string arrowState2 = "UI/Image/Packed/p_UI_Package.png:UI_Package_Shuangwuqi_Qiehuan_Jiantou";
}
