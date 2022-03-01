using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000E70 RID: 3696
	internal class ComBuffIconManager
	{
		// Token: 0x0600929E RID: 37534 RVA: 0x001B3D94 File Offset: 0x001B2194
		public static ComBuffIcon Create(GameObject parent)
		{
			if (parent == null)
			{
				Logger.LogError("ComBuffIconManager Create function param parent is null!");
				return null;
			}
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/BattleUI/DungeonBeBuffUnit", enResourceType.UIPrefab, 2U);
			if (gameObject != null)
			{
				ComBuffIcon component = gameObject.GetComponent<ComBuffIcon>();
				if (component != null)
				{
					component.Reset();
					Utility.AttachTo(component.gameObject, parent, false);
					component.needRecycle = true;
					return component;
				}
			}
			return null;
		}

		// Token: 0x0600929F RID: 37535 RVA: 0x001B3E08 File Offset: 0x001B2208
		public static void Destroy(ComBuffIcon comBuffIcon)
		{
			if (comBuffIcon != null && comBuffIcon.gameObject != null)
			{
				comBuffIcon.Reset();
				if (comBuffIcon.needRecycle)
				{
					Singleton<CGameObjectPool>.instance.RecycleGameObject(comBuffIcon.gameObject);
					comBuffIcon.needRecycle = false;
				}
			}
		}
	}
}
