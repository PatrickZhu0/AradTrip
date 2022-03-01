using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000EF4 RID: 3828
	internal class ComItemManager
	{
		// Token: 0x060095C4 RID: 38340 RVA: 0x001C4660 File Offset: 0x001C2A60
		public static ComItem Create(GameObject parent)
		{
			if (parent == null)
			{
				Logger.LogError("ComItemManager Create function param parent is null!");
				return null;
			}
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/Package/Item", enResourceType.UIPrefab, 2U);
			if (gameObject != null)
			{
				ComItem component = gameObject.GetComponent<ComItem>();
				if (component != null)
				{
					component.Reset();
					component.gameObject.transform.SetParent(parent.transform, false);
					component.needRecycle = true;
					return component;
				}
			}
			return null;
		}

		// Token: 0x060095C5 RID: 38341 RVA: 0x001C46E0 File Offset: 0x001C2AE0
		public static void Destroy(ComItem a_comItem)
		{
			if (a_comItem != null && a_comItem.gameObject != null)
			{
				a_comItem.Reset();
				if (a_comItem.needRecycle)
				{
					Singleton<CGameObjectPool>.instance.RecycleGameObject(a_comItem.gameObject);
					a_comItem.needRecycle = false;
				}
			}
		}

		// Token: 0x060095C6 RID: 38342 RVA: 0x001C4734 File Offset: 0x001C2B34
		public static void Destroy(List<ComItem> a_arrComItems)
		{
			if (a_arrComItems != null)
			{
				for (int i = 0; i < a_arrComItems.Count; i++)
				{
					ComItem comItem = a_arrComItems[i];
					if (comItem != null && comItem.gameObject != null)
					{
						comItem.Reset();
						if (comItem.needRecycle)
						{
							Singleton<CGameObjectPool>.instance.RecycleGameObject(comItem.gameObject);
							comItem.needRecycle = false;
						}
					}
				}
			}
		}

		// Token: 0x060095C7 RID: 38343 RVA: 0x001C47AC File Offset: 0x001C2BAC
		public static void Destroy(ComItem[] a_arrComItems)
		{
			if (a_arrComItems != null)
			{
				foreach (ComItem comItem in a_arrComItems)
				{
					if (comItem != null && comItem.gameObject != null)
					{
						comItem.Reset();
						if (comItem.needRecycle)
						{
							Singleton<CGameObjectPool>.instance.RecycleGameObject(comItem.gameObject);
							comItem.needRecycle = false;
						}
					}
				}
			}
		}
	}
}
