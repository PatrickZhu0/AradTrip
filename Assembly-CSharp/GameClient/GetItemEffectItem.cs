using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016BB RID: 5819
	public class GetItemEffectItem : MonoBehaviour
	{
		// Token: 0x0600E435 RID: 58421 RVA: 0x003B07B8 File Offset: 0x003AEBB8
		private void Start()
		{
		}

		// Token: 0x0600E436 RID: 58422 RVA: 0x003B07BA File Offset: 0x003AEBBA
		private void Update()
		{
		}

		// Token: 0x0600E437 RID: 58423 RVA: 0x003B07BC File Offset: 0x003AEBBC
		public void SetUp(ItemData itemData, float fDelay, GetItemEffectFrame frame, bool bHighValue = false)
		{
			if (frame != null && this.goItemParent != null)
			{
				ComItem comItem = frame.CreateComItem(this.goItemParent);
				if (comItem != null)
				{
					comItem.Setup(itemData, delegate(GameObject obj, ItemData item)
					{
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
					});
				}
				if (this.txtItemName != null && itemData != null)
				{
					this.txtItemName.text = itemData.GetColorName(string.Empty, false);
				}
				if (bHighValue)
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.SetUpHighValueEffect());
				}
			}
		}

		// Token: 0x0600E438 RID: 58424 RVA: 0x003B0864 File Offset: 0x003AEC64
		private IEnumerator SetUpHighValueEffect()
		{
			yield return Yielders.GetWaitForSeconds(0.3f);
			if (this.goHighValue != null)
			{
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadRes("Effects/UI/Prefab/EffUI_pinji/Prefab/EffUI_pinjiguang_zise", true, 0U).obj as GameObject;
				gameObject.transform.SetParent(this.goHighValue.transform, false);
				gameObject.SetActive(true);
			}
			yield return 0;
			yield break;
		}

		// Token: 0x0400891C RID: 35100
		[SerializeField]
		private GameObject goItemParent;

		// Token: 0x0400891D RID: 35101
		[SerializeField]
		private Text txtItemName;

		// Token: 0x0400891E RID: 35102
		[SerializeField]
		private GameObject goHighValue;
	}
}
