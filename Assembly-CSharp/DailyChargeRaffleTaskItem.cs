using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200137B RID: 4987
public class DailyChargeRaffleTaskItem : MonoBehaviour
{
	// Token: 0x17001BB2 RID: 7090
	// (get) Token: 0x0600C166 RID: 49510 RVA: 0x002E1283 File Offset: 0x002DF683
	// (set) Token: 0x0600C167 RID: 49511 RVA: 0x002E128B File Offset: 0x002DF68B
	public DailyChargeRaffleModel model { get; set; }

	// Token: 0x0600C168 RID: 49512 RVA: 0x002E1294 File Offset: 0x002DF694
	private void Awake()
	{
	}

	// Token: 0x0600C169 RID: 49513 RVA: 0x002E1298 File Offset: 0x002DF698
	private void Start()
	{
		if (this.mToPayBtn)
		{
			this.mToPayBtn.onClick.AddListener(new UnityAction(this.OnToPayBtnClick));
		}
		if (this.mToRaffleBtn)
		{
			this.mToRaffleBtn.onClick.AddListener(new UnityAction(this.OnToRaffleBtnClick));
		}
		this.toRaffleTurnTableDesc = TR.Value("daily_charge_raffle_button_goto_turntable");
		this.tr_charge_acc_limit_desc = TR.Value("daily_charge_raffle_acc_limit");
		this.InitRaffleBtnText();
	}

	// Token: 0x0600C16A RID: 49514 RVA: 0x002E1323 File Offset: 0x002DF723
	private void Update()
	{
	}

	// Token: 0x0600C16B RID: 49515 RVA: 0x002E1328 File Offset: 0x002DF728
	private void OnDestroy()
	{
		if (this.model != null)
		{
			this.model.Clear();
			this.model = null;
		}
		if (this.itemDatas != null)
		{
			this.itemDatas.Clear();
		}
		if (this.comItemList != null)
		{
			for (int i = 0; i < this.comItemList.Count; i++)
			{
				ComItemManager.Destroy(this.comItemList[i]);
			}
			this.comItemList.Clear();
		}
		if (this.mToPayBtn)
		{
			this.mToPayBtn.onClick.RemoveListener(new UnityAction(this.OnToPayBtnClick));
		}
		this.mToPayBtn = null;
		this.mToPayBtnText = null;
		if (this.mToRaffleBtn)
		{
			this.mToRaffleBtn.onClick.RemoveListener(new UnityAction(this.OnToRaffleBtnClick));
		}
		this.mToRaffleBtn = null;
		this.mToRaffleBtnText = null;
		this.mAwardItemRoot = null;
		this.mAddImgGo = null;
		this.mFocusItemEffect = null;
		if (this.mRaffleTicketIds != null)
		{
			this.mRaffleTicketIds.Clear();
		}
		this.toRaffleTurnTableDesc = string.Empty;
		this.bInited = false;
	}

	// Token: 0x0600C16C RID: 49516 RVA: 0x002E145C File Offset: 0x002DF85C
	private void OnToPayBtnClick()
	{
		if (this.model == null)
		{
			Logger.LogError("Try to pay failed, model is null !");
			return;
		}
		if (this.model.accLimitChargeNum >= this.model.accLimitChargeMax)
		{
			SystemNotifyManager.SysNotifyTextAnimation(string.Format(this.tr_charge_acc_limit_desc, this.model.accLimitChargeMax), CommonTipsDesc.eShowMode.SI_UNIQUE);
			return;
		}
		DataManager<DailyChargeRaffleDataManager>.GetInstance().SendBuyDailyChargeReq(this.model);
	}

	// Token: 0x0600C16D RID: 49517 RVA: 0x002E14CC File Offset: 0x002DF8CC
	private void OnToRaffleBtnClick()
	{
		if (this.model == null)
		{
			Logger.LogError("Try to open turntable failed, model is null !");
			return;
		}
		DataManager<DailyChargeRaffleDataManager>.GetInstance().OpenRaffleTurnTableFrame(this.model.RaffleTableId);
	}

	// Token: 0x0600C16E RID: 49518 RVA: 0x002E14F9 File Offset: 0x002DF8F9
	private void SetPayGotShow(bool bShow)
	{
	}

	// Token: 0x0600C16F RID: 49519 RVA: 0x002E14FB File Offset: 0x002DF8FB
	private void SetRaffleBtnShow(bool bShow)
	{
		if (this.mToRaffleBtn)
		{
			this.mToRaffleBtn.gameObject.CustomActive(bShow);
		}
	}

	// Token: 0x0600C170 RID: 49520 RVA: 0x002E151E File Offset: 0x002DF91E
	private void SetToPayBtnShow(bool bShow)
	{
		if (this.mToPayBtn)
		{
			this.mToPayBtn.gameObject.CustomActive(bShow);
		}
	}

	// Token: 0x0600C171 RID: 49521 RVA: 0x002E1541 File Offset: 0x002DF941
	private void InitRaffleBtnText()
	{
		if (this.mToRaffleBtnText)
		{
			this.mToRaffleBtnText.text = this.toRaffleTurnTableDesc;
		}
	}

	// Token: 0x0600C172 RID: 49522 RVA: 0x002E1564 File Offset: 0x002DF964
	public void Initialize()
	{
		if (this.model == null)
		{
			return;
		}
		if (this.bInited)
		{
			return;
		}
		this.itemDatas = this.model.AwardItemDataList;
		if (this.itemDatas != null)
		{
			for (int i = 0; i < this.itemDatas.Count; i++)
			{
				ComItem comItem = ComItemManager.Create(this.mAwardItemRoot);
				comItem.CustomActive(true);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.itemDatas[i].ItemID, 100, 0);
				if (itemData == null)
				{
					Logger.LogErrorFormat("Please check item data id {0}", new object[]
					{
						this.itemDatas[i].ItemID
					});
				}
				else
				{
					itemData.Count = this.itemDatas[i].Count;
					comItem.Setup(itemData, delegate(GameObject go, ItemData itemdata)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemdata, null, 4, true, false, true);
					});
					if (comItem != null && !this.comItemList.Contains(comItem))
					{
						this.comItemList.Add(comItem);
					}
				}
			}
		}
		if (this.mAddImgGo)
		{
			this.mAddImgGo.transform.SetAsLastSibling();
		}
		if (this.comItemList != null && this.mRaffleTicketIds != null)
		{
			for (int j = this.comItemList.Count - 1; j >= 0; j--)
			{
				for (int k = 0; k < this.mRaffleTicketIds.Count; k++)
				{
					if (this.comItemList[j].ItemData.TableID == this.mRaffleTicketIds[k])
					{
						this.comItemList[j].gameObject.transform.SetAsLastSibling();
						ComItem comItem2 = this.comItemList[j];
						ItemData itemData2 = comItem2.ItemData;
						comItem2.Setup(itemData2, delegate(GameObject go, ItemData data)
						{
							DataManager<DailyChargeRaffleDataManager>.GetInstance().OpenRaffleTurnTableFrame(this.model.RaffleTableId);
						});
						if (this.mFocusItemEffect)
						{
							RectTransform component = this.mFocusItemEffect.GetComponent<RectTransform>();
							if (component == null)
							{
								return;
							}
							component.anchoredPosition = new Vector2((float)this.mFocusItemEffectOffset, component.anchoredPosition.y);
						}
						break;
					}
				}
			}
		}
		this.bInited = true;
	}

	// Token: 0x0600C173 RID: 49523 RVA: 0x002E17C3 File Offset: 0x002DFBC3
	public void SetToPayBtnText(string desc)
	{
		if (this.mToPayBtnText)
		{
			this.mToPayBtnText.text = desc;
		}
	}

	// Token: 0x0600C174 RID: 49524 RVA: 0x002E17E1 File Offset: 0x002DFBE1
	public void SetTaskItemStatus(ComDailyChargeRaffle.DailyChargeTaskStatus status)
	{
		status = ComDailyChargeRaffle.DailyChargeTaskStatus.ToCharge;
		if (status != ComDailyChargeRaffle.DailyChargeTaskStatus.ToCharge)
		{
			if (status == ComDailyChargeRaffle.DailyChargeTaskStatus.BeCharged)
			{
				this.SetToPayBtnShow(false);
				this.SetRaffleBtnShow(true);
			}
		}
		else
		{
			this.SetToPayBtnShow(true);
			this.SetRaffleBtnShow(false);
		}
	}

	// Token: 0x04006D74 RID: 28020
	private List<ItemSimpleData> itemDatas = new List<ItemSimpleData>();

	// Token: 0x04006D75 RID: 28021
	[SerializeField]
	[Header("不同档位的抽奖券的ID集合")]
	private List<int> mRaffleTicketIds;

	// Token: 0x04006D76 RID: 28022
	[SerializeField]
	[Header("特效挂载偏移1单位值")]
	private int mFocusItemEffectOffset = 86;

	// Token: 0x04006D77 RID: 28023
	public Button mToPayBtn;

	// Token: 0x04006D78 RID: 28024
	public Text mToPayBtnText;

	// Token: 0x04006D79 RID: 28025
	public Button mToRaffleBtn;

	// Token: 0x04006D7A RID: 28026
	public Text mToRaffleBtnText;

	// Token: 0x04006D7B RID: 28027
	public GameObject mAwardItemRoot;

	// Token: 0x04006D7C RID: 28028
	public GameObject mAddImgGo;

	// Token: 0x04006D7D RID: 28029
	public GameObject mFocusItemEffect;

	// Token: 0x04006D7E RID: 28030
	private List<ComItem> comItemList = new List<ComItem>();

	// Token: 0x04006D7F RID: 28031
	private string toRaffleTurnTableDesc = string.Empty;

	// Token: 0x04006D80 RID: 28032
	private string tr_charge_acc_limit_desc = string.Empty;

	// Token: 0x04006D81 RID: 28033
	private bool bInited;
}
