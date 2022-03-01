using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001880 RID: 6272
	public class ChangeFashionSpecialExchangeView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F5A4 RID: 62884 RVA: 0x004243FC File Offset: 0x004227FC
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				return;
			}
			this.mNote.Init(model, true, null);
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			this._InitItems(model);
		}

		// Token: 0x0600F5A5 RID: 62885 RVA: 0x00424450 File Offset: 0x00422850
		protected sealed override void _InitItems(ILimitTimeActivityModel data)
		{
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败，路径:" + data.ItemPath);
				return;
			}
			if (gameObject.GetComponent<IActivityCommonItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到ICommonActivityItem的脚本，预制体路径是:" + data.ItemPath);
				return;
			}
			this.mThisItem = gameObject;
			this.mItems.Clear();
			GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
			gameObject2.transform.SetParent(this.mItemRoot, false);
			gameObject2.GetComponent<IActivityCommonItem>().InitFromMode(data, this.mOnItemClick);
			this.mItems.Add(data.TaskDatas[0].DataId, gameObject2.GetComponent<IActivityCommonItem>());
			Object.Destroy(gameObject);
		}

		// Token: 0x0600F5A6 RID: 62886 RVA: 0x0042451E File Offset: 0x0042291E
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F5A7 RID: 62887 RVA: 0x00424541 File Offset: 0x00422941
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.mModel == null)
			{
				return;
			}
		}

		// Token: 0x0600F5A8 RID: 62888 RVA: 0x00424550 File Offset: 0x00422950
		public override void UpdateData(ILimitTimeActivityModel data)
		{
			this.mModel = data;
			for (int i = 0; i < data.TaskDatas.Count; i++)
			{
				IActivityCommonItem componentInChildren = this.mItemRoot.GetComponentInChildren<IActivityCommonItem>();
				componentInChildren.UpdateData(data.TaskDatas[i]);
			}
		}

		// Token: 0x040096AF RID: 38575
		private new ILimitTimeActivityModel mModel;

		// Token: 0x040096B0 RID: 38576
		private GameObject mThisItem;
	}
}
