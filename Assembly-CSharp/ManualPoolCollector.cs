using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001B2 RID: 434
public class ManualPoolCollector : MonoSingleton<ManualPoolCollector>
{
	// Token: 0x06000DFE RID: 3582 RVA: 0x00048494 File Offset: 0x00046894
	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x000484A4 File Offset: 0x000468A4
	public GameObject GetGameObject(string path)
	{
		if (!this.m_pools.ContainsKey(path))
		{
			this.m_pools.Add(path, new List<GameObject>());
		}
		List<GameObject> list = this.m_pools[path];
		GameObject gameObject;
		if (list.Count > 0)
		{
			gameObject = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
			if (gameObject.IsNull())
			{
				return gameObject;
			}
			if (this.m_IdToGoMap.ContainsKey(gameObject.GetInstanceID()))
			{
				this.m_IdToGoMap[gameObject.GetInstanceID()].go = null;
			}
			else
			{
				this.m_IdToGoMap.Add(gameObject.GetInstanceID(), new ManualPoolCollector.GameObjectDesc
				{
					path = path,
					go = null
				});
			}
		}
		else
		{
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
			if (gameObject.IsNull())
			{
				return gameObject;
			}
			if (this.m_IdToGoMap.ContainsKey(gameObject.GetInstanceID()))
			{
				this.m_IdToGoMap[gameObject.GetInstanceID()].go = null;
			}
			else
			{
				this.m_IdToGoMap.Add(gameObject.GetInstanceID(), new ManualPoolCollector.GameObjectDesc
				{
					path = path,
					go = null
				});
			}
		}
		gameObject.transform.SetParent(null, false);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.parent = null;
		gameObject.SetActive(true);
		return gameObject;
	}

	// Token: 0x06000E00 RID: 3584 RVA: 0x0004862C File Offset: 0x00046A2C
	public void Recycle(GameObject go)
	{
		if (go.IsNull())
		{
			return;
		}
		if (!this.m_IdToGoMap.ContainsKey(go.GetInstanceID()))
		{
			Logger.LogErrorFormat("has not instanceId record {0}", new object[]
			{
				go.GetInstanceID()
			});
			Object.Destroy(go);
			return;
		}
		string path = this.m_IdToGoMap[go.GetInstanceID()].path;
		this.m_IdToGoMap[go.GetInstanceID()].go = go;
		if (!this.m_pools.ContainsKey(path))
		{
			this.m_pools.Add(path, new List<GameObject>());
		}
		this.m_pools[path].Add(go);
		go.SetActive(false);
		go.transform.SetParent(base.gameObject.transform, false);
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x00048700 File Offset: 0x00046B00
	public void Clear()
	{
		foreach (KeyValuePair<int, ManualPoolCollector.GameObjectDesc> keyValuePair in this.m_IdToGoMap)
		{
			ManualPoolCollector.GameObjectDesc value = keyValuePair.Value;
			if (value != null && !value.go.IsNull())
			{
				Object.Destroy(value.go);
			}
		}
		this.m_IdToGoMap.Clear();
		this.m_pools.Clear();
	}

	// Token: 0x040009BF RID: 2495
	private Dictionary<string, List<GameObject>> m_pools = new Dictionary<string, List<GameObject>>();

	// Token: 0x040009C0 RID: 2496
	private Dictionary<int, ManualPoolCollector.GameObjectDesc> m_IdToGoMap = new Dictionary<int, ManualPoolCollector.GameObjectDesc>();

	// Token: 0x020001B3 RID: 435
	private class GameObjectDesc
	{
		// Token: 0x040009C1 RID: 2497
		public string path;

		// Token: 0x040009C2 RID: 2498
		public GameObject go;
	}
}
