using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000E62 RID: 3682
public class CBossHpFadeWhite : MonoBehaviour
{
	// Token: 0x0600925E RID: 37470 RVA: 0x001B2A5C File Offset: 0x001B0E5C
	public void SetValue(float minValue, float maxValue, float timeout, UnityAction fn)
	{
		GameObject go = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/BattleUI/DungeonBar/HPBar_White", enResourceType.UIPrefab, 0U);
		Utility.AttachTo(go, base.gameObject, false);
		CBossHpWhiteBar bar = go.GetComponent<CBossHpWhiteBar>();
		bar.SetValue(minValue, maxValue);
		bar.StartFadeOut(timeout, delegate
		{
			if (fn != null)
			{
				fn.Invoke();
			}
			Singleton<CGameObjectPool>.instance.RecycleGameObject(go);
			if (null != bar)
			{
				this.mBars.Remove(bar);
			}
		});
		for (int i = 0; i < this.mBars.Count; i++)
		{
			if (null != this.mBars[i])
			{
				this.mBars[i].SetMinValue(minValue);
			}
		}
		this.mBars.Add(bar);
	}

	// Token: 0x0600925F RID: 37471 RVA: 0x001B2B33 File Offset: 0x001B0F33
	public void OnDestroy()
	{
		this.mBars.Clear();
	}

	// Token: 0x0400496A RID: 18794
	private const string kPrefabUnit = "UIFlatten/Prefabs/BattleUI/DungeonBar/HPBar_White";

	// Token: 0x0400496B RID: 18795
	private List<CBossHpWhiteBar> mBars = new List<CBossHpWhiteBar>();
}
