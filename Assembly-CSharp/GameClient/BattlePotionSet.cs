using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016A1 RID: 5793
	public class BattlePotionSet : MonoBehaviour
	{
		// Token: 0x0600E38B RID: 58251 RVA: 0x003AA078 File Offset: 0x003A8478
		private int AdjustSlider(Slider slider, float current, float min, float max)
		{
			float num = current;
			if (current <= min)
			{
				num = min;
				slider.value = min;
			}
			if (current >= max)
			{
				num = max;
				slider.value = max;
			}
			return Mathf.FloorToInt(num * 100f) / 5 * 5;
		}

		// Token: 0x0600E38C RID: 58252 RVA: 0x003AA0BC File Offset: 0x003A84BC
		private void _updateBattlePostionSet()
		{
			List<uint> potionSets = DataManager<PlayerBaseData>.GetInstance().potionSets;
			for (int i = 0; i < this.ConfigItems.Length; i++)
			{
				uint id = 0U;
				if (i < potionSets.Count)
				{
					id = potionSets[i];
				}
				this._updateBattlePostionSetByIdx(i, id);
			}
		}

		// Token: 0x0600E38D RID: 58253 RVA: 0x003AA10C File Offset: 0x003A850C
		private void _updateBattlePostionSetByIdx(int i, uint id)
		{
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>((int)id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				this.ConfigItems[i].color = Color.clear;
				if (this.mDrugRoots != null)
				{
					this.mDrugRoots[i].CustomActive(false);
				}
				if (this.AttributePotions != null)
				{
					this.AttributePotions[i].CustomActive(true);
				}
				if (this.AttributePotionsNotConfigs != null)
				{
					this.AttributePotionsNotConfigs[i].CustomActive(true);
				}
				if (this.AttributePotionsConfigs != null)
				{
					this.AttributePotionsConfigs[i].CustomActive(false);
				}
			}
			else
			{
				this.ConfigItems[i].color = Color.white;
				ETCImageLoader.LoadSprite(ref this.ConfigItems[i], tableItem.Icon, true);
				if (tableItem.SubType == ItemTable.eSubType.AttributeDrug)
				{
					if (this.mDrugRoots != null)
					{
						this.mDrugRoots[i].CustomActive(false);
					}
					if (this.AttributePotions != null)
					{
						this.AttributePotions[i].CustomActive(true);
					}
					if (this.AttributePotionsNotConfigs != null)
					{
						this.AttributePotionsNotConfigs[i].CustomActive(false);
					}
					if (this.AttributePotionsConfigs != null)
					{
						this.AttributePotionsConfigs[i].CustomActive(true);
					}
				}
				else
				{
					if (this.mDrugRoots != null)
					{
						this.mDrugRoots[i].CustomActive(true);
					}
					if (this.AttributePotions != null)
					{
						this.AttributePotions[i].CustomActive(false);
					}
				}
			}
		}

		// Token: 0x0600E38E RID: 58254 RVA: 0x003AA284 File Offset: 0x003A8684
		private void Start()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonPotionSetChanged, new ClientEventSystem.UIEventHandler(this._onUpdateBattlePostionSet));
			if (this.switchButton0 != null)
			{
				this.switchButton0.onValueChanged.RemoveAllListeners();
				this.switchButton0.onValueChanged.AddListener(delegate(bool value)
				{
					DataManager<PlayerBaseData>.GetInstance().SetPotionSlotMainSwitchOn(value, false, "PotionSlotMainSwitch");
				});
			}
			if (this.switchButton1 != null)
			{
				this.switchButton1.onValueChanged.RemoveAllListeners();
				this.switchButton1.onValueChanged.AddListener(delegate(bool value)
				{
					DataManager<PlayerBaseData>.GetInstance().SetPotionSlotMainSwitchOn(value, false, "PotionSlot1Switch");
				});
			}
			if (this.switchButton2 != null)
			{
				this.switchButton2.onValueChanged.RemoveAllListeners();
				this.switchButton2.onValueChanged.AddListener(delegate(bool value)
				{
					DataManager<PlayerBaseData>.GetInstance().SetPotionSlotMainSwitchOn(value, false, "PotionSlot2Switch");
				});
			}
			this.slider0.SafeSetValueChangeListener(delegate(float value)
			{
				int num = this.AdjustSlider(this.slider0, value, 0.05f, 0.9f);
				this.percent0.SafeSetText(string.Format("{0}%", num));
				DataManager<PlayerBaseData>.GetInstance().SetPotionPercent(PlayerBaseData.PotionSlotType.SlotMain, num, false);
			});
			this.slider1.SafeSetValueChangeListener(delegate(float value)
			{
				int num = this.AdjustSlider(this.slider1, value, 0f, 0.9f);
				this.percent1.SafeSetText(string.Format("{0}%", num));
				DataManager<PlayerBaseData>.GetInstance().SetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend1, num, false);
			});
			this.slider2.SafeSetValueChangeListener(delegate(float value)
			{
				int num = this.AdjustSlider(this.slider2, value, 0f, 0.9f);
				this.percent2.SafeSetText(string.Format("{0}%", num));
				DataManager<PlayerBaseData>.GetInstance().SetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend2, num, false);
			});
			this.UpdateUI();
		}

		// Token: 0x0600E38F RID: 58255 RVA: 0x003AA3E1 File Offset: 0x003A87E1
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonPotionSetChanged, new ClientEventSystem.UIEventHandler(this._onUpdateBattlePostionSet));
			DataManager<PlayerBaseData>.GetInstance().SavePotionPercentSetsToFile();
		}

		// Token: 0x0600E390 RID: 58256 RVA: 0x003AA408 File Offset: 0x003A8808
		private void _onUpdateBattlePostionSet(UIEvent ui)
		{
			this._updateBattlePostionSet();
			this.UpdateUI();
		}

		// Token: 0x0600E391 RID: 58257 RVA: 0x003AA416 File Offset: 0x003A8816
		private void Update()
		{
		}

		// Token: 0x0600E392 RID: 58258 RVA: 0x003AA418 File Offset: 0x003A8818
		public void UpdateUI()
		{
			if (this.switchButton0 != null)
			{
				this.switchButton0.SetSwitch(DataManager<PlayerBaseData>.GetInstance().IsPotionSlotMainSwitchOn("PotionSlotMainSwitch"));
				this.switchButton0.interactable = (DataManager<PlayerBaseData>.GetInstance().GetPotionID(PlayerBaseData.PotionSlotType.SlotMain) != 0);
			}
			if (this.switchButton1 != null)
			{
				this.switchButton1.SetSwitch(DataManager<PlayerBaseData>.GetInstance().IsPotionSlotMainSwitchOn("PotionSlot1Switch"));
				this.switchButton1.interactable = (DataManager<PlayerBaseData>.GetInstance().GetPotionID(PlayerBaseData.PotionSlotType.SlotExtend1) != 0);
			}
			if (this.switchButton2 != null)
			{
				this.switchButton2.SetSwitch(DataManager<PlayerBaseData>.GetInstance().IsPotionSlotMainSwitchOn("PotionSlot2Switch"));
				this.switchButton2.interactable = (DataManager<PlayerBaseData>.GetInstance().GetPotionID(PlayerBaseData.PotionSlotType.SlotExtend2) != 0);
			}
			int potionPercent = DataManager<PlayerBaseData>.GetInstance().GetPotionPercent(PlayerBaseData.PotionSlotType.SlotMain);
			this.percent0.SafeSetText(string.Format("{0}%", potionPercent));
			this.slider0.SafeSetValue((float)potionPercent / 100f);
			potionPercent = DataManager<PlayerBaseData>.GetInstance().GetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend1);
			this.percent1.SafeSetText(string.Format("{0}%", potionPercent));
			this.slider1.SafeSetValue((float)potionPercent / 100f);
			potionPercent = DataManager<PlayerBaseData>.GetInstance().GetPotionPercent(PlayerBaseData.PotionSlotType.SlotExtend2);
			this.percent2.SafeSetText(string.Format("{0}%", potionPercent));
			this.slider2.SafeSetValue((float)potionPercent / 100f);
			this._updateBattlePostionSet();
		}

		// Token: 0x04008881 RID: 34945
		[SerializeField]
		private GeUISwitchButton switchButton0;

		// Token: 0x04008882 RID: 34946
		[SerializeField]
		private GeUISwitchButton switchButton1;

		// Token: 0x04008883 RID: 34947
		[SerializeField]
		private GeUISwitchButton switchButton2;

		// Token: 0x04008884 RID: 34948
		[SerializeField]
		private Slider slider0;

		// Token: 0x04008885 RID: 34949
		[SerializeField]
		private Text percent0;

		// Token: 0x04008886 RID: 34950
		[SerializeField]
		private Slider slider1;

		// Token: 0x04008887 RID: 34951
		[SerializeField]
		private Text percent1;

		// Token: 0x04008888 RID: 34952
		[SerializeField]
		private Slider slider2;

		// Token: 0x04008889 RID: 34953
		[SerializeField]
		private Text percent2;

		// Token: 0x0400888A RID: 34954
		[SerializeField]
		private Image[] ConfigItems = new Image[0];

		// Token: 0x0400888B RID: 34955
		[SerializeField]
		private GameObject[] mDrugRoots = new GameObject[0];

		// Token: 0x0400888C RID: 34956
		[SerializeField]
		private GameObject[] AttributePotions = new GameObject[0];

		// Token: 0x0400888D RID: 34957
		[SerializeField]
		private GameObject[] AttributePotionsNotConfigs = new GameObject[0];

		// Token: 0x0400888E RID: 34958
		[SerializeField]
		private GameObject[] AttributePotionsConfigs = new GameObject[0];
	}
}
