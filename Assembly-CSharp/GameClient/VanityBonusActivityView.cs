using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001928 RID: 6440
	public class VanityBonusActivityView : MonoBehaviour, IDungeonBuffView
	{
		// Token: 0x0600FA94 RID: 64148 RVA: 0x00449F14 File Offset: 0x00448314
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

		// Token: 0x0600FA95 RID: 64149 RVA: 0x00449F6C File Offset: 0x0044836C
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
			if (gameObject.GetComponent<VanityBonusItem>() == null)
			{
				Object.Destroy(gameObject);
				Logger.LogError("预制体上找不到VanityBonusItem的脚本，预制体路径是:" + model.ItemPath);
				return;
			}
			GameObject gameObject2 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mVanityBonusItemRightPath, true, 0U);
			if (gameObject2 == null)
			{
				Logger.LogError("加载预制体失败，路径:" + model.ItemPath);
				return;
			}
			if (gameObject2.GetComponent<VanityBonusItem>() == null)
			{
				Object.Destroy(gameObject2);
				Logger.LogError("预制体上找不到VanityBonusItem的脚本，预制体路径是:" + model.ItemPath);
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

		// Token: 0x0600FA96 RID: 64150 RVA: 0x0044A0A8 File Offset: 0x004484A8
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
			VanityBonusItem component = gameObject.GetComponent<VanityBonusItem>();
			if (component != null)
			{
				component.Init(id);
			}
		}

		// Token: 0x0600FA97 RID: 64151 RVA: 0x0044A106 File Offset: 0x00448506
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600FA98 RID: 64152 RVA: 0x0044A119 File Offset: 0x00448519
		public void Dispose()
		{
			if (this.mNote != null)
			{
				this.mNote.Dispose();
			}
			this.goBtn.SafeRemoveOnClickListener(this.goOnClick);
			this.goOnClick = null;
		}

		// Token: 0x04009C87 RID: 40071
		[SerializeField]
		private RectTransform[] mItemRoots;

		// Token: 0x04009C88 RID: 40072
		[SerializeField]
		private ActivityNote mNote;

		// Token: 0x04009C89 RID: 40073
		[SerializeField]
		private Button goBtn;

		// Token: 0x04009C8A RID: 40074
		[SerializeField]
		private string mVanityBonusItemRightPath = "UIFlatten/Prefabs/OperateActivity/YiJie/Items/VanityBonusItemRight";

		// Token: 0x04009C8B RID: 40075
		private UnityAction goOnClick;
	}
}
