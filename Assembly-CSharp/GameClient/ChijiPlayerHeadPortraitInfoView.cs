using System;
using System.Collections.Generic;
using System.Reflection;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001113 RID: 4371
	public class ChijiPlayerHeadPortraitInfoView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600A5C2 RID: 42434 RVA: 0x00225518 File Offset: 0x00223918
		private void Awake()
		{
			this.InitChijiBuffComUIList();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this.OnJobIDChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiHpChanged, new ClientEventSystem.UIEventHandler(this.OnChijiHPChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiMpChanged, new ClientEventSystem.UIEventHandler(this.OnChijiMPChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HeadPortraitFrameChange, new ClientEventSystem.UIEventHandler(this.OnHeadPortraitFrameChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this.OnBuffListChanged));
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		}

		// Token: 0x0600A5C3 RID: 42435 RVA: 0x00225639 File Offset: 0x00223A39
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x0600A5C4 RID: 42436 RVA: 0x00225644 File Offset: 0x00223A44
		public void InitView(DisplayAttribute attribute)
		{
			if (attribute != null)
			{
				FieldInfo field = attribute.GetType().GetField("maxHp");
				if (field != null)
				{
					float num = (float)field.GetValue(attribute);
					this.iMaxHp = (int)num;
				}
				FieldInfo field2 = attribute.GetType().GetField("maxMp");
				if (field2 != null)
				{
					float num2 = (float)field2.GetValue(attribute);
					this.iMaxMp = (int)num2;
				}
			}
			if (this.mChijiBuffList == null)
			{
				this.mChijiBuffList = new List<BeFightBuff>();
			}
			else
			{
				this.mChijiBuffList.Clear();
			}
			this.ReplaceHeadPortraitFrame();
			this.SetName();
			this.SetLevel();
			this.UpdateHeadIcon();
			this.UpdateHP();
			this.UpdateMP();
			this.UpdateChijiBuffElementAmount();
		}

		// Token: 0x0600A5C5 RID: 42437 RVA: 0x00225700 File Offset: 0x00223B00
		private void UpdateHeadIcon()
		{
			string path = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					path = tableItem2.IconPath;
				}
			}
			if (this.mHeadIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mHeadIcon, path, true);
			}
		}

		// Token: 0x0600A5C6 RID: 42438 RVA: 0x00225780 File Offset: 0x00223B80
		private void UpdateHP()
		{
			if (this.mHpSlider != null)
			{
				this.mHpSlider.value = DataManager<PlayerBaseData>.GetInstance().Chiji_HP_Percent;
			}
			if (this.mHp != null)
			{
				this.mHp.text = string.Format(this.sHPMPDesc, ((int)((float)this.iMaxHp * DataManager<PlayerBaseData>.GetInstance().Chiji_HP_Percent)).ToString(), this.iMaxHp.ToString());
			}
		}

		// Token: 0x0600A5C7 RID: 42439 RVA: 0x0022580C File Offset: 0x00223C0C
		private void UpdateMP()
		{
			if (this.mMpSlider != null)
			{
				this.mMpSlider.value = DataManager<PlayerBaseData>.GetInstance().Chiji_MP_Percent;
			}
			if (this.mMp != null)
			{
				this.mMp.text = string.Format(this.sHPMPDesc, ((int)((float)this.iMaxMp * DataManager<PlayerBaseData>.GetInstance().Chiji_MP_Percent)).ToString(), this.iMaxMp.ToString());
			}
		}

		// Token: 0x0600A5C8 RID: 42440 RVA: 0x00225898 File Offset: 0x00223C98
		private void SetName()
		{
			if (this.mName != null)
			{
				this.mName.text = DataManager<PlayerBaseData>.GetInstance().Name;
			}
		}

		// Token: 0x0600A5C9 RID: 42441 RVA: 0x002258C0 File Offset: 0x00223CC0
		private void SetLevel()
		{
			if (this.mLevel != null)
			{
				this.mLevel.text = DataManager<PlayerBaseData>.GetInstance().Level.ToString();
			}
		}

		// Token: 0x0600A5CA RID: 42442 RVA: 0x00225904 File Offset: 0x00223D04
		private void ReplaceHeadPortraitFrame()
		{
			if (this.mReplaceHeadPortraitFrame != null)
			{
				if (HeadPortraitFrameDataManager.WearHeadPortraitFrameID != 0)
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.WearHeadPortraitFrameID);
				}
				else
				{
					this.mReplaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
		}

		// Token: 0x0600A5CB RID: 42443 RVA: 0x00225951 File Offset: 0x00223D51
		private void OnJobIDChanged(UIEvent uiEvent)
		{
			this.UpdateHeadIcon();
		}

		// Token: 0x0600A5CC RID: 42444 RVA: 0x00225959 File Offset: 0x00223D59
		private void OnChijiHPChanged(UIEvent uiEvent)
		{
			this.UpdateHP();
		}

		// Token: 0x0600A5CD RID: 42445 RVA: 0x00225961 File Offset: 0x00223D61
		private void OnChijiMPChanged(UIEvent uiEvent)
		{
			this.UpdateMP();
		}

		// Token: 0x0600A5CE RID: 42446 RVA: 0x00225969 File Offset: 0x00223D69
		private void OnHeadPortraitFrameChanged(UIEvent uiEvent)
		{
			this.ReplaceHeadPortraitFrame();
		}

		// Token: 0x0600A5CF RID: 42447 RVA: 0x00225971 File Offset: 0x00223D71
		private void OnLevelChanged(UIEvent uiEvent)
		{
			this.SetLevel();
		}

		// Token: 0x0600A5D0 RID: 42448 RVA: 0x00225979 File Offset: 0x00223D79
		private void OnBuffListChanged(UIEvent uiEvent)
		{
			this.UpdateChijiBuffElementAmount();
		}

		// Token: 0x0600A5D1 RID: 42449 RVA: 0x00225984 File Offset: 0x00223D84
		private void OnAddNewItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.Type == ItemTable.eType.EQUIP)
					{
						this.RefreshHpValue();
						break;
					}
				}
			}
		}

		// Token: 0x0600A5D2 RID: 42450 RVA: 0x002259E6 File Offset: 0x00223DE6
		private void OnRemoveItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			if (itemData.Type != ItemTable.eType.EQUIP)
			{
				return;
			}
			this.RefreshHpValue();
		}

		// Token: 0x0600A5D3 RID: 42451 RVA: 0x00225A04 File Offset: 0x00223E04
		private void OnUpdateItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.Type == ItemTable.eType.EQUIP)
					{
						this.RefreshHpValue();
						break;
					}
				}
			}
		}

		// Token: 0x0600A5D4 RID: 42452 RVA: 0x00225A68 File Offset: 0x00223E68
		private void RefreshHpValue()
		{
			DisplayAttribute mainPlayerActorAttribute = BeUtility.GetMainPlayerActorAttribute(true, true);
			if (mainPlayerActorAttribute != null)
			{
				FieldInfo field = mainPlayerActorAttribute.GetType().GetField("maxHp");
				if (field != null)
				{
					float num = (float)field.GetValue(mainPlayerActorAttribute);
					this.iMaxHp = (int)num;
				}
			}
			this.UpdateHP();
		}

		// Token: 0x0600A5D5 RID: 42453 RVA: 0x00225AB8 File Offset: 0x00223EB8
		private void InitChijiBuffComUIList()
		{
			if (this.mChijiBuffComUIList != null)
			{
				this.mChijiBuffComUIList.Initialize();
				ComUIListScript comUIListScript = this.mChijiBuffComUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mChijiBuffComUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mChijiBuffComUIList;
				comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600A5D6 RID: 42454 RVA: 0x00225B56 File Offset: 0x00223F56
		private ChijiBuffItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ChijiBuffItem>();
		}

		// Token: 0x0600A5D7 RID: 42455 RVA: 0x00225B60 File Offset: 0x00223F60
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ChijiBuffItem chijiBuffItem = item.gameObjectBindScript as ChijiBuffItem;
			if (chijiBuffItem != null && item.m_index >= 0 && item.m_index < this.mChijiBuffList.Count)
			{
				chijiBuffItem.OnItemVisiable(this.mChijiBuffList[item.m_index]);
			}
		}

		// Token: 0x0600A5D8 RID: 42456 RVA: 0x00225BC0 File Offset: 0x00223FC0
		private void UpdateChijiBuffElementAmount()
		{
			if (this.mChijiBuffList != null)
			{
				this.mChijiBuffList.Clear();
			}
			if (DataManager<PlayerBaseData>.GetInstance().BuffMgr != null)
			{
				List<BeFightBuff> buffList = DataManager<PlayerBaseData>.GetInstance().BuffMgr.GetBuffList();
				if (buffList != null)
				{
					for (int i = 0; i < buffList.Count; i++)
					{
						if (buffList[i].BuffID != 402000003 && buffList[i].BuffID != 400000001)
						{
							this.mChijiBuffList.Add(buffList[i]);
						}
					}
				}
			}
			if (this.mChijiBuffList.Count <= 0 && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChijiBuffTipsFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiBuffTipsFrame>(null, false);
			}
			if (this.mChijiBuffComUIList != null)
			{
				this.mChijiBuffComUIList.UpdateElementAmount(this.mChijiBuffList.Count);
			}
		}

		// Token: 0x0600A5D9 RID: 42457 RVA: 0x00225CB8 File Offset: 0x002240B8
		private void UnInitChijiBuffComUIList()
		{
			if (this.mChijiBuffComUIList != null)
			{
				ComUIListScript comUIListScript = this.mChijiBuffComUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mChijiBuffComUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mChijiBuffComUIList;
				comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600A5DA RID: 42458 RVA: 0x00225D4C File Offset: 0x0022414C
		public void Dispose()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this.OnJobIDChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiHpChanged, new ClientEventSystem.UIEventHandler(this.OnChijiHPChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiMpChanged, new ClientEventSystem.UIEventHandler(this.OnChijiMPChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HeadPortraitFrameChange, new ClientEventSystem.UIEventHandler(this.OnHeadPortraitFrameChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this.OnBuffListChanged));
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			this.iMaxHp = 0;
			this.iMaxMp = 0;
			this.mChijiBuffList.Clear();
			this.UnInitChijiBuffComUIList();
		}

		// Token: 0x04005CAD RID: 23725
		[SerializeField]
		private Image mHeadIcon;

		// Token: 0x04005CAE RID: 23726
		[SerializeField]
		private ReplaceHeadPortraitFrame mReplaceHeadPortraitFrame;

		// Token: 0x04005CAF RID: 23727
		[SerializeField]
		private Text mLevel;

		// Token: 0x04005CB0 RID: 23728
		[SerializeField]
		private Text mName;

		// Token: 0x04005CB1 RID: 23729
		[SerializeField]
		private Slider mHpSlider;

		// Token: 0x04005CB2 RID: 23730
		[SerializeField]
		private Slider mMpSlider;

		// Token: 0x04005CB3 RID: 23731
		[SerializeField]
		private Text mHp;

		// Token: 0x04005CB4 RID: 23732
		[SerializeField]
		private Text mMp;

		// Token: 0x04005CB5 RID: 23733
		[SerializeField]
		private ComUIListScript mChijiBuffComUIList;

		// Token: 0x04005CB6 RID: 23734
		[SerializeField]
		private string sHPMPDesc = "{0} / {1}";

		// Token: 0x04005CB7 RID: 23735
		private int iMaxHp;

		// Token: 0x04005CB8 RID: 23736
		private int iMaxMp;

		// Token: 0x04005CB9 RID: 23737
		private List<BeFightBuff> mChijiBuffList = new List<BeFightBuff>();
	}
}
