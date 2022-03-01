using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200181B RID: 6171
	public class ChaosAdditionActivityView : MonoBehaviour, IDungeonBuffView
	{
		// Token: 0x0600F31C RID: 62236 RVA: 0x0041AFDC File Offset: 0x004193DC
		public void Init(ILimitTimeActivityModel model, UnityAction callBack)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.goOnClick = callBack;
			this.InitItems(model);
			this.mNote.Init(model, false, base.GetComponent<ComCommonBind>());
			this.goBtn.SafeAddOnClickListener(this.goOnClick);
		}

		// Token: 0x0600F31D RID: 62237 RVA: 0x0041B034 File Offset: 0x00419434
		private void InitItems(ILimitTimeActivityModel model)
		{
			if (model.ParamArray == null || model.ParamArray.Length <= 0)
			{
				return;
			}
			GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(model.ItemPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败，路径:" + model.ItemPath);
				return;
			}
			if (gameObject.GetComponent<ChaosAddtionItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到ChaosAddtionItem的脚本，预制体路径是:" + model.ItemPath);
				return;
			}
			GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mChaosAddtionItemItemRightPath, true, 0U);
			if (gameObject2 == null)
			{
				Logger.LogError("加载预制体失败，路径:" + model.ItemPath);
				return;
			}
			if (gameObject2.GetComponent<ChaosAddtionItem>() == null)
			{
				Object.Destroy(gameObject2);
				Logger.LogError("预制体上找不到ChaosAddtionItem的脚本，预制体路径是:" + model.ItemPath);
				return;
			}
			for (int i = 0; i < model.ParamArray.Length; i++)
			{
				if (i < 3)
				{
					this.AddItem(gameObject, (int)model.ParamArray[i], i);
				}
				else
				{
					this.AddItem(gameObject2, (int)model.ParamArray[i], i);
				}
			}
			Object.Destroy(gameObject);
			Object.Destroy(gameObject2);
		}

		// Token: 0x0600F31E RID: 62238 RVA: 0x0041B170 File Offset: 0x00419570
		private void AddItem(GameObject go, int id, int index)
		{
			if (index >= this.mItemRoots.Length)
			{
				return;
			}
			if (go == null)
			{
				return;
			}
			GameObject gameObject = Object.Instantiate<GameObject>(go);
			gameObject.transform.SetParent(this.mItemRoots[index], false);
			ChaosAddtionItem component = gameObject.GetComponent<ChaosAddtionItem>();
			if (component != null)
			{
				component.Init(id);
			}
		}

		// Token: 0x0600F31F RID: 62239 RVA: 0x0041B1CE File Offset: 0x004195CE
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F320 RID: 62240 RVA: 0x0041B1E1 File Offset: 0x004195E1
		public void Dispose()
		{
			if (this.mNote != null)
			{
				this.mNote.Dispose();
			}
			this.goBtn.SafeRemoveOnClickListener(this.goOnClick);
			this.goOnClick = null;
		}

		// Token: 0x04009596 RID: 38294
		[SerializeField]
		private RectTransform[] mItemRoots;

		// Token: 0x04009597 RID: 38295
		[SerializeField]
		private ActivityNote mNote;

		// Token: 0x04009598 RID: 38296
		[SerializeField]
		private Button goBtn;

		// Token: 0x04009599 RID: 38297
		[SerializeField]
		private string mChaosAddtionItemItemRightPath = "UIFlatten/Prefabs/OperateActivity/Chaos/Item/ChaosAdditionItemRight";

		// Token: 0x0400959A RID: 38298
		private UnityAction goOnClick;
	}
}
