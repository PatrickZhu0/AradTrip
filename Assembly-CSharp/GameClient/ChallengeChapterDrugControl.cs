using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014B7 RID: 5303
	public class ChallengeChapterDrugControl : MonoBehaviour
	{
		// Token: 0x0600CD93 RID: 52627 RVA: 0x003295B8 File Offset: 0x003279B8
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CD94 RID: 52628 RVA: 0x003295C0 File Offset: 0x003279C0
		private void OnDestroy()
		{
			DataManager<ChapterBuffDrugManager>.GetInstance().SetBuffDrugToggleState(this._isUseDrug);
			this.ClearData();
			this.UnBindEvents();
		}

		// Token: 0x0600CD95 RID: 52629 RVA: 0x003295DE File Offset: 0x003279DE
		private void ClearData()
		{
			this._dungeonTable = null;
			this._dungeonId = 0;
			this._isUseDrug = false;
			this._isInit = false;
		}

		// Token: 0x0600CD96 RID: 52630 RVA: 0x003295FC File Offset: 0x003279FC
		private void BindEvents()
		{
			if (this.drugUseButton != null)
			{
				this.drugUseButton.onClick.RemoveAllListeners();
				this.drugUseButton.onClick.AddListener(new UnityAction(this.OnDrugUseButtonClick));
			}
			if (this.drugSettingButton != null)
			{
				this.drugSettingButton.onClick.RemoveAllListeners();
				this.drugSettingButton.onClick.AddListener(new UnityAction(this.OnDrugSettingButtonClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffDrugSettingSubmit, new ClientEventSystem.UIEventHandler(this.OnDrugSettingSubmit));
		}

		// Token: 0x0600CD97 RID: 52631 RVA: 0x003296A0 File Offset: 0x00327AA0
		private void UnBindEvents()
		{
			if (this.drugUseButton != null)
			{
				this.drugUseButton.onClick.RemoveAllListeners();
			}
			if (this.drugSettingButton != null)
			{
				this.drugSettingButton.onClick.RemoveAllListeners();
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffDrugSettingSubmit, new ClientEventSystem.UIEventHandler(this.OnDrugSettingSubmit));
		}

		// Token: 0x0600CD98 RID: 52632 RVA: 0x0032970C File Offset: 0x00327B0C
		public void UpdateDrugControl(int dungeonId)
		{
			if (this._dungeonId == dungeonId)
			{
				return;
			}
			this._dungeonId = dungeonId;
			this._dungeonTable = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this._dungeonId, string.Empty, string.Empty);
			if (this._dungeonTable == null)
			{
				Logger.LogErrorFormat("ChallengeChapterDrugControl dungeonTable is null and dungeonId is {0}", new object[]
				{
					this._dungeonId
				});
				return;
			}
			this.UpdateDrugInitUsed();
			this.SetDrugValueInfo();
			this.SetDrugCostInfo();
		}

		// Token: 0x0600CD99 RID: 52633 RVA: 0x0032978C File Offset: 0x00327B8C
		private void UpdateDrugInitUsed()
		{
			if (!this._isInit)
			{
				this._isInit = true;
				if (DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugToggleOn())
				{
					this._isUseDrug = true;
					if (this._dungeonTable != null)
					{
						DataManager<ChapterBuffDrugManager>.GetInstance().ResetBuffDrugsFromLocal(this._dungeonTable.BuffDrugConfig);
					}
				}
				else
				{
					this._isUseDrug = false;
				}
			}
			this.UpdateUseDrugButtonFlag();
		}

		// Token: 0x0600CD9A RID: 52634 RVA: 0x003297F4 File Offset: 0x00327BF4
		private void SetDrugValueInfo()
		{
			if (this._dungeonTable == null)
			{
				return;
			}
			FlatBufferArray<int> buffDrugConfig = this._dungeonTable.BuffDrugConfig;
			DisplayAttribute mainPlayerActorAttribute = BeUtility.GetMainPlayerActorAttribute(false, false);
			BeEntityData entityData = BeUtility.GetMainPlayerActor(false, null, SkillSystemSourceType.None).GetEntityData();
			BattleData battleData = entityData.battleData;
			if (buffDrugConfig.Count < 4)
			{
				return;
			}
			this.SetAttackInfo(this.attackValueText, mainPlayerActorAttribute.attack, DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugConfig[0]), buffDrugConfig[0]);
			this.SetAttackInfo(this.magicAttackValueText, mainPlayerActorAttribute.magicAttack, DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugConfig[0]), buffDrugConfig[0]);
			this.SetHpInfo(this.hpValueText, battleData, DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugConfig[1]), buffDrugConfig[1]);
			this.SetPercentInfo(this.critValueText, DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugConfig[2]), buffDrugConfig[2]);
			this.SetPercentInfo(this.dodgeValueText, DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugSetted(buffDrugConfig[3]), buffDrugConfig[3]);
		}

		// Token: 0x0600CD9B RID: 52635 RVA: 0x00329904 File Offset: 0x00327D04
		private void SetAttackInfo(Text infoText, float attack, bool isItemSelected, int drugId)
		{
			if (infoText == null)
			{
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(drugId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int onUseBuffId = tableItem.OnUseBuffId;
			BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(onUseBuffId, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			int fixValue = tableItem2.attack.fixValue;
			int fixValue2 = tableItem2.attackAddRate.fixValue;
			if (isItemSelected)
			{
				infoText.text = "+" + ChallengeUtility.FloatToInt((attack + (float)fixValue) * (1f + (float)fixValue2 / (float)GlobalLogic.VALUE_1000) - attack).ToString();
				infoText.color = Color.green;
			}
			else
			{
				infoText.text = TR.Value("chapter_value_string", 0);
				infoText.color = Color.white;
			}
		}

		// Token: 0x0600CD9C RID: 52636 RVA: 0x003299EC File Offset: 0x00327DEC
		private void SetHpInfo(Text infoText, BattleData bData, bool isItemSelected, int drugId)
		{
			if (infoText == null)
			{
				return;
			}
			if (isItemSelected)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(drugId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				int onUseBuffId = tableItem.OnUseBuffId;
				BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(onUseBuffId, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					return;
				}
				int fixValue = tableItem2.maxHp.fixValue;
				int fixValue2 = tableItem2.maxHpAddRate.fixValue;
				int num = ChallengeUtility.FloatToInt((float)(bData.fMaxHp + fixValue) * (1f + (float)fixValue2 / (float)GlobalLogic.VALUE_1000) - (float)bData.fMaxHp);
				int fMaxHp = bData.fMaxHp;
				bData._maxHp += fixValue;
				bData._maxHp += IntMath.Float2Int((float)bData._maxHp * ((float)fixValue2 / (float)GlobalLogic.VALUE_1000));
				int num2 = bData.fMaxHp - fMaxHp;
				infoText.text = TR.Value("chapter_buffdrug_hpdisplay", num, num2);
			}
			else
			{
				infoText.text = TR.Value("chapter_value_string", 0);
				infoText.color = Color.white;
			}
		}

		// Token: 0x0600CD9D RID: 52637 RVA: 0x00329B34 File Offset: 0x00327F34
		private void SetPercentInfo(Text infoText, bool isItemSelected, int drugId)
		{
			if (infoText == null)
			{
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(drugId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int onUseBuffId = tableItem.OnUseBuffId;
			BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(onUseBuffId, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			int num = (tableItem2.ciriticalAttack.fixValue != 0) ? tableItem2.ciriticalAttack.fixValue : tableItem2.dodge.fixValue;
			if (isItemSelected)
			{
				infoText.text = TR.Value("chapter_percent_string", num / 10);
				infoText.color = Color.green;
			}
			else
			{
				infoText.text = TR.Value("chapter_percent_string", 0);
				infoText.color = Color.white;
			}
		}

		// Token: 0x0600CD9E RID: 52638 RVA: 0x00329C0C File Offset: 0x0032800C
		private void SetDrugCostInfo()
		{
			if (!this._isUseDrug)
			{
				this.SetDrugUseRoot(this._isUseDrug);
				return;
			}
			int num = 0;
			List<CostItemManager.CostInfo> allMarkedBuffDrugsCost = DataManager<ChapterBuffDrugManager>.GetInstance().GetAllMarkedBuffDrugsCost(this._dungeonId);
			if (allMarkedBuffDrugsCost == null || allMarkedBuffDrugsCost.Count <= 0)
			{
				num = 0;
			}
			else
			{
				for (int i = 0; i < allMarkedBuffDrugsCost.Count; i++)
				{
					num += allMarkedBuffDrugsCost[i].nCount;
				}
			}
			if (num <= 0)
			{
				this.SetDrugUseRoot(false);
			}
			else
			{
				this.SetDrugUseRoot(true);
				this.drugUseCostValueText.text = num.ToString();
			}
		}

		// Token: 0x0600CD9F RID: 52639 RVA: 0x00329CB5 File Offset: 0x003280B5
		private void SetDrugUseRoot(bool flag)
		{
			if (this.drugUseWithCostRoot != null)
			{
				this.drugUseWithCostRoot.CustomActive(flag);
			}
			if (this.drugUseWithoutCostRoot != null)
			{
				this.drugUseWithoutCostRoot.CustomActive(!flag);
			}
		}

		// Token: 0x0600CDA0 RID: 52640 RVA: 0x00329CF4 File Offset: 0x003280F4
		private void OnDrugSettingButtonClick()
		{
			int dungeonId = this._dungeonId;
			Singleton<ClientSystemManager>.instance.OpenFrame<ChapterDrugSettingFrame>(FrameLayer.Middle, dungeonId, string.Empty);
		}

		// Token: 0x0600CDA1 RID: 52641 RVA: 0x00329D20 File Offset: 0x00328120
		private void OnDrugUseButtonClick()
		{
			this._isUseDrug = !this._isUseDrug;
			this.UpdateUseDrugButtonFlag();
			if (this._isUseDrug)
			{
				if (this._dungeonTable != null)
				{
					DataManager<ChapterBuffDrugManager>.GetInstance().ResetBuffDrugsFromLocal(this._dungeonTable.BuffDrugConfig);
				}
			}
			else
			{
				DataManager<ChapterBuffDrugManager>.GetInstance().ResetAllMarkedBuffDrugs();
			}
			this.SetDrugCostInfo();
		}

		// Token: 0x0600CDA2 RID: 52642 RVA: 0x00329D82 File Offset: 0x00328182
		private void OnDrugSettingSubmit(UIEvent uiEvent)
		{
			this._isUseDrug = true;
			this.UpdateUseDrugButtonFlag();
			this.SetDrugValueInfo();
			this.SetDrugCostInfo();
		}

		// Token: 0x0600CDA3 RID: 52643 RVA: 0x00329D9D File Offset: 0x0032819D
		private void UpdateUseDrugButtonFlag()
		{
			if (this.drugUseImage != null)
			{
				this.drugUseImage.gameObject.CustomActive(this._isUseDrug);
			}
		}

		// Token: 0x040077EB RID: 30699
		private bool _isInit;

		// Token: 0x040077EC RID: 30700
		private int _dungeonId;

		// Token: 0x040077ED RID: 30701
		private DungeonTable _dungeonTable;

		// Token: 0x040077EE RID: 30702
		private bool _isUseDrug;

		// Token: 0x040077EF RID: 30703
		[Space(10f)]
		[Header("DrugValue")]
		[Space(10f)]
		[SerializeField]
		private Text attackValueText;

		// Token: 0x040077F0 RID: 30704
		[SerializeField]
		private Text magicAttackValueText;

		// Token: 0x040077F1 RID: 30705
		[SerializeField]
		private Text hpValueText;

		// Token: 0x040077F2 RID: 30706
		[SerializeField]
		private Text critValueText;

		// Token: 0x040077F3 RID: 30707
		[SerializeField]
		private Text dodgeValueText;

		// Token: 0x040077F4 RID: 30708
		[Space(10f)]
		[Header("ButtonSetting")]
		[Space(10f)]
		[SerializeField]
		private Button drugSettingButton;

		// Token: 0x040077F5 RID: 30709
		[Space(10f)]
		[Header("ButtonUse")]
		[Space(10f)]
		[SerializeField]
		private Button drugUseButton;

		// Token: 0x040077F6 RID: 30710
		[SerializeField]
		private Image drugUseImage;

		// Token: 0x040077F7 RID: 30711
		[SerializeField]
		private GameObject drugUseWithoutCostRoot;

		// Token: 0x040077F8 RID: 30712
		[SerializeField]
		private GameObject drugUseWithCostRoot;

		// Token: 0x040077F9 RID: 30713
		[SerializeField]
		private Text drugUseCostValueText;
	}
}
