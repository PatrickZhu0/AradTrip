using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045FF RID: 17919
	public class ScriptPool
	{
		// Token: 0x060192FC RID: 103164 RVA: 0x007F74DC File Offset: 0x007F58DC
		public static void RecyclePrefab(GameObject go, string path)
		{
			GameObject gameObject = GameObject.Find("TemplateScriptPool");
			if (gameObject == null)
			{
				ScriptPool.ClearAll();
				gameObject = new GameObject("TemplateScriptPool");
				Object.DontDestroyOnLoad(gameObject);
			}
			int hashCode = path.GetHashCode();
			List<GameObject> list = null;
			if (!ScriptPool.poolObjects.TryGetValue(hashCode, out list))
			{
				list = new List<GameObject>();
				ScriptPool.poolObjects.Add(hashCode, list);
			}
			list.Add(go);
			Utility.AttachTo(go, gameObject, false);
			go.SetActive(false);
		}

		// Token: 0x060192FD RID: 103165 RVA: 0x007F755C File Offset: 0x007F595C
		public static void ClearAll()
		{
			foreach (KeyValuePair<int, List<GameObject>> keyValuePair in ScriptPool.poolObjects)
			{
				List<GameObject> value = keyValuePair.Value;
				if (value != null)
				{
					int i = 0;
					int count = value.Count;
					while (i < count)
					{
						if (null != value[i])
						{
							Object.Destroy(value[i]);
						}
						i++;
					}
				}
			}
			ScriptPool.poolObjects.Clear();
		}

		// Token: 0x060192FE RID: 103166 RVA: 0x007F75E4 File Offset: 0x007F59E4
		public static GameObject CreatePrefab(string path, bool bUsedCopyComponent)
		{
			if (path != null && path.Length > 0)
			{
				GameObject gameObject = GameObject.Find("TemplateScriptPool");
				if (gameObject == null)
				{
					ScriptPool.poolObjects.Clear();
				}
				if (gameObject == null)
				{
					gameObject = new GameObject("TemplateScriptPool");
					Object.DontDestroyOnLoad(gameObject);
				}
				int hashCode = path.GetHashCode();
				List<GameObject> list = null;
				GameObject gameObject2;
				if (bUsedCopyComponent)
				{
					if (!ScriptPool.poolObjects.TryGetValue(hashCode, out list))
					{
						list = new List<GameObject>();
						ScriptPool.poolObjects.Add(hashCode, list);
					}
					if (list.Count <= 0)
					{
						gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
						if (gameObject2 != null)
						{
							list.Add(gameObject2);
							Utility.AttachTo(gameObject2, gameObject, false);
							gameObject2.SetActive(false);
						}
					}
					else
					{
						gameObject2 = list[0];
					}
				}
				else if (!ScriptPool.poolObjects.TryGetValue(hashCode, out list) || list.Count <= 0)
				{
					gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
				}
				else
				{
					gameObject2 = list[0];
					list.RemoveAt(0);
				}
				return gameObject2;
			}
			return null;
		}

		// Token: 0x040120B1 RID: 73905
		public static Dictionary<int, List<GameObject>> poolObjects = new Dictionary<int, List<GameObject>>();
	}
}
