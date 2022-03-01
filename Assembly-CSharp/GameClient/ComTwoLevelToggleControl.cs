using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F9B RID: 3995
	public class ComTwoLevelToggleControl : MonoBehaviour
	{
		// Token: 0x06009A69 RID: 39529 RVA: 0x001DD71C File Offset: 0x001DBB1C
		public void InitTwoLevelToggleControl(List<ComTwoLevelToggleData> twoLevelToggleDataList, OnComToggleClick _onFirstLevelToggleClick = null, OnComToggleClick _onSecondLevelToggleClick = null)
		{
			if (this.twoLevelToggleRoot == null || this.twoLevelToggleItemPrefab == null)
			{
				Logger.LogErrorFormat("ComTwoLevelToggleControl root or prefab is null", new object[0]);
				return;
			}
			if (twoLevelToggleDataList == null || twoLevelToggleDataList.Count <= 0)
			{
				Logger.LogErrorFormat("ComTwoLevelToggleControl twoLevelToggleDataList is null", new object[0]);
				return;
			}
			for (int i = 0; i < twoLevelToggleDataList.Count; i++)
			{
				ComTwoLevelToggleData comTwoLevelToggleData = twoLevelToggleDataList[i];
				if (comTwoLevelToggleData != null && comTwoLevelToggleData.FirstLevelToggleData != null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.twoLevelToggleItemPrefab);
					if (gameObject != null)
					{
						gameObject.CustomActive(true);
						Utility.AttachTo(gameObject, this.twoLevelToggleRoot, false);
						gameObject.transform.name = gameObject.transform.name + "_" + (i + 1);
						ComTwoLevelToggleItem component = gameObject.GetComponent<ComTwoLevelToggleItem>();
						if (component != null)
						{
							component.InitItem(comTwoLevelToggleData, _onFirstLevelToggleClick, _onSecondLevelToggleClick);
						}
					}
				}
			}
		}

		// Token: 0x04004FF3 RID: 20467
		[Space(5f)]
		[Header("TwoLevelControl")]
		[Space(5f)]
		[SerializeField]
		private GameObject twoLevelToggleRoot;

		// Token: 0x04004FF4 RID: 20468
		[SerializeField]
		private GameObject twoLevelToggleItemPrefab;
	}
}
