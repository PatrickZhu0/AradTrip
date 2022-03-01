using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001A2D RID: 6701
public class VipSettingFrame : ClientFrame
{
	// Token: 0x06010762 RID: 67426 RVA: 0x004A20F4 File Offset: 0x004A04F4
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/SettingPanel/vipSettingFrame";
	}

	// Token: 0x06010763 RID: 67427 RVA: 0x004A20FB File Offset: 0x004A04FB
	protected override bool _isLoadFromPool()
	{
		return BattleMain.instance != null;
	}

	// Token: 0x06010764 RID: 67428 RVA: 0x004A2110 File Offset: 0x004A0510
	protected override void _bindExUI()
	{
		this.itemPrefabs[0] = this.mBind.GetCom<ItemDrugSetting>("ItemPrefab1");
		this.itemPrefabs[1] = this.mBind.GetCom<ItemDrugSetting>("ItemPrefab2");
		this.itemPrefabs[2] = this.mBind.GetCom<ItemDrugSetting>("ItemPrefab3");
		this.btn = this.mBind.GetCom<Button>("setBtn");
		this.btn.onClick.AddListener(delegate()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<ChapterBattlePotionSetFrame>(FrameLayer.Middle, null, string.Empty);
		});
	}

	// Token: 0x06010765 RID: 67429 RVA: 0x004A21A8 File Offset: 0x004A05A8
	protected override void _OnOpenFrame()
	{
		this.InitUI();
		this.InitDrugItem(null);
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ClosePotionSetFrame, new ClientEventSystem.UIEventHandler(this.InitDrugItem));
	}

	// Token: 0x06010766 RID: 67430 RVA: 0x004A21D2 File Offset: 0x004A05D2
	protected void InitUI()
	{
		this.vipsetting = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/SettingPanel/VipSetting", true, 0U);
		if (this.vipsetting != null)
		{
			Utility.AttachTo(this.vipsetting, this.frame, false);
		}
	}

	// Token: 0x06010767 RID: 67431 RVA: 0x004A2210 File Offset: 0x004A0610
	private void InitDrugItem(UIEvent uiEvent)
	{
		for (int i = 0; i < this.itemPrefabs.Length; i++)
		{
			this.itemPrefabs[i].SetItemInfo(DataManager<PlayerBaseData>.GetInstance().GetPotionID((PlayerBaseData.PotionSlotType)i), DataManager<PlayerBaseData>.GetInstance().GetPotionPercent((PlayerBaseData.PotionSlotType)i), (PlayerBaseData.PotionSlotType)i);
		}
	}

	// Token: 0x06010768 RID: 67432 RVA: 0x004A225A File Offset: 0x004A065A
	protected override void _OnCloseFrame()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ClosePotionSetFrame, new ClientEventSystem.UIEventHandler(this.InitDrugItem));
		base._OnCloseFrame();
	}

	// Token: 0x0400A75F RID: 42847
	private ItemDrugSetting[] itemPrefabs = new ItemDrugSetting[3];

	// Token: 0x0400A760 RID: 42848
	private Button btn;

	// Token: 0x0400A761 RID: 42849
	private GameObject vipsetting;
}
