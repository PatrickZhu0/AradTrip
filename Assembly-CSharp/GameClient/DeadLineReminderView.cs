using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015AE RID: 5550
	public class DeadLineReminderView : MonoBehaviour
	{
		// Token: 0x0600D912 RID: 55570 RVA: 0x003661A8 File Offset: 0x003645A8
		private void Awake()
		{
			this.BindUIEventSystem();
			this.InitElementUIList();
			if (this.mIngoreLessItemBtn != null)
			{
				this.mIngoreLessItemBtn.onClick.RemoveAllListeners();
				this.mIngoreLessItemBtn.onClick.AddListener(new UnityAction(this.OnIngoreLessItemBtnClick));
			}
		}

		// Token: 0x0600D913 RID: 55571 RVA: 0x003661FE File Offset: 0x003645FE
		private void OnDestroy()
		{
			this.UnBindUIEventSystem();
			this.UnInitElementUIList();
		}

		// Token: 0x0600D914 RID: 55572 RVA: 0x0036620C File Offset: 0x0036460C
		public void InitView()
		{
			DataManager<DeadLineReminderDataManager>.GetInstance().Sort();
			this.UpdateElementAmount();
		}

		// Token: 0x0600D915 RID: 55573 RVA: 0x0036621E File Offset: 0x0036461E
		private void BindUIEventSystem()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DeadLineReminderChanged, new ClientEventSystem.UIEventHandler(this.DeadLineReminderChanged));
		}

		// Token: 0x0600D916 RID: 55574 RVA: 0x0036623B File Offset: 0x0036463B
		private void UnBindUIEventSystem()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DeadLineReminderChanged, new ClientEventSystem.UIEventHandler(this.DeadLineReminderChanged));
		}

		// Token: 0x0600D917 RID: 55575 RVA: 0x00366258 File Offset: 0x00364658
		private void DeadLineReminderChanged(UIEvent uiEvent)
		{
			this.UpdateElementAmount();
		}

		// Token: 0x0600D918 RID: 55576 RVA: 0x00366260 File Offset: 0x00364660
		private void InitElementUIList()
		{
			if (this.mElementUIList != null)
			{
				this.mElementUIList.Initialize();
				ComUIListScript comUIListScript = this.mElementUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mElementUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600D919 RID: 55577 RVA: 0x003662D8 File Offset: 0x003646D8
		private void UnInitElementUIList()
		{
			if (this.mElementUIList != null)
			{
				ComUIListScript comUIListScript = this.mElementUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mElementUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600D91A RID: 55578 RVA: 0x00366344 File Offset: 0x00364744
		private DeadLineReminderElement OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<DeadLineReminderElement>();
		}

		// Token: 0x0600D91B RID: 55579 RVA: 0x0036634C File Offset: 0x0036474C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			DeadLineReminderElement deadLineReminderElement = item.gameObjectBindScript as DeadLineReminderElement;
			if (deadLineReminderElement != null && item.m_index >= 0 && item.m_index < DataManager<DeadLineReminderDataManager>.GetInstance().GetDeadLineReminderModelList().Count)
			{
				DeadLineReminderModel model = DataManager<DeadLineReminderDataManager>.GetInstance().GetDeadLineReminderModelList()[item.m_index];
				deadLineReminderElement.InitElement(model);
			}
		}

		// Token: 0x0600D91C RID: 55580 RVA: 0x003663B4 File Offset: 0x003647B4
		private void UpdateElementAmount()
		{
			if (this.mElementUIList)
			{
				this.mElementUIList.SetElementAmount(DataManager<DeadLineReminderDataManager>.GetInstance().GetDeadLineReminderModelList().Count);
			}
		}

		// Token: 0x0600D91D RID: 55581 RVA: 0x003663E0 File Offset: 0x003647E0
		private void OnIngoreLessItemBtnClick()
		{
			DataManager<DeadLineReminderDataManager>.GetInstance().DeleteFailureItem();
		}

		// Token: 0x04007F90 RID: 32656
		[SerializeField]
		private ComUIListScript mElementUIList;

		// Token: 0x04007F91 RID: 32657
		[SerializeField]
		private Button mIngoreLessItemBtn;
	}
}
