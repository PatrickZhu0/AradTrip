using System;
using System.Collections;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016A7 RID: 5799
	internal class DecomposeResultFrame : ClientFrame
	{
		// Token: 0x0600E3B4 RID: 58292 RVA: 0x003AAE21 File Offset: 0x003A9221
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Package/DecomposeResult";
		}

		// Token: 0x0600E3B5 RID: 58293 RVA: 0x003AAE28 File Offset: 0x003A9228
		protected override void _OnOpenFrame()
		{
			this.m_resultData = (this.userData as DecomposeResultData);
			if (this.m_resultData != null)
			{
				if (this.m_resultData.bIsDecomposeFashion && this.m_titleTxt != null)
				{
					this.m_titleTxt.text = "时装分解成功";
				}
				this.m_coroutineDecompose = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._ShowDecompose());
			}
			else
			{
				Logger.LogError("分解界面数据错误！");
			}
		}

		// Token: 0x0600E3B6 RID: 58294 RVA: 0x003AAEA7 File Offset: 0x003A92A7
		protected override void _OnCloseFrame()
		{
			if (this.m_coroutineDecompose != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_coroutineDecompose);
				this.m_coroutineDecompose = null;
			}
			this.m_resultData = null;
			this.indexs.Clear();
		}

		// Token: 0x0600E3B7 RID: 58295 RVA: 0x003AAEE0 File Offset: 0x003A92E0
		private IEnumerator _ShowDecompose()
		{
			this.m_objProgressRoot.SetActive(true);
			this.m_objResultRoot.SetActive(false);
			SystemValueTable systemValue = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(454, string.Empty, string.Empty);
			float delayTime = (systemValue != null) ? ((float)systemValue.Value / 1000f) : 2f;
			yield return Yielders.GetWaitForSeconds(delayTime);
			this._ShowResult();
			this.m_coroutineDecompose = null;
			yield break;
		}

		// Token: 0x0600E3B8 RID: 58296 RVA: 0x003AAEFC File Offset: 0x003A92FC
		private void _ShowResult()
		{
			this.m_objProgressRoot.SetActive(false);
			this.m_objResultRoot.SetActive(true);
			this.m_comItemList.Initialize();
			this.m_comItemList.onBindItem = ((GameObject var) => base.CreateComItem(Utility.FindGameObject(var, "Item", true)));
			this.m_comItemList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_resultData != null && this.m_resultData.arrItems != null && var.m_index >= 0 && var.m_index < this.m_resultData.arrItems.Count)
				{
					ItemData itemData = this.m_resultData.arrItems[var.m_index];
					ComItem comItem = var.gameObjectBindScript as ComItem;
					comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					Utility.GetComponetInChild<Text>(var.gameObject, "Desc").text = string.Format("{0}x{1}", itemData.GetColorName(string.Empty, false), itemData.Count);
					GameObject gameObject = Utility.FindChild(var.gameObject, "EffectRoot");
					if (!this.indexs.Contains(var.m_index) && this.m_resultData.bIsDecomposeFashion)
					{
						GameObject gameObject2 = Utility.FindChild(gameObject, "EffUI_common_huode");
						if (gameObject2 != null)
						{
							Object.Destroy(gameObject2);
						}
						GameObject gameObject3 = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.sEffectPath, true, 0U);
						gameObject3.name = "EffUI_common_huode";
						Utility.AttachTo(gameObject3, gameObject, false);
						this.indexs.Add(var.m_index);
					}
				}
			};
			if (this.m_resultData != null && this.m_resultData.arrItems != null)
			{
				this.m_comItemList.SetElementAmount(this.m_resultData.arrItems.Count);
			}
			else
			{
				this.m_comItemList.SetElementAmount(0);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DecomposeFinished, null, null, null, null);
		}

		// Token: 0x0600E3B9 RID: 58297 RVA: 0x003AAFB4 File Offset: 0x003A93B4
		[UIEventHandle("Result/Title/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<DecomposeResultFrame>(this, false);
		}

		// Token: 0x040088A6 RID: 34982
		[UIObject("Progress")]
		private GameObject m_objProgressRoot;

		// Token: 0x040088A7 RID: 34983
		[UIObject("Result")]
		private GameObject m_objResultRoot;

		// Token: 0x040088A8 RID: 34984
		[UIControl("Result/ItemListView", null, 0)]
		private ComUIListScript m_comItemList;

		// Token: 0x040088A9 RID: 34985
		[UIControl("Result/Title/Text", null, 0)]
		private Text m_titleTxt;

		// Token: 0x040088AA RID: 34986
		private string sEffectPath = "Effects/UI/Prefab/EffUI_Common/Prefab/EffUI_common_huode";

		// Token: 0x040088AB RID: 34987
		private List<int> indexs = new List<int>();

		// Token: 0x040088AC RID: 34988
		private DecomposeResultData m_resultData;

		// Token: 0x040088AD RID: 34989
		private Coroutine m_coroutineDecompose;
	}
}
