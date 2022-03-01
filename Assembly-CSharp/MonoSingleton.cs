using System;
using UnityEngine;

// Token: 0x020001B6 RID: 438
public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
	// Token: 0x170001EC RID: 492
	// (get) Token: 0x06000E1D RID: 3613 RVA: 0x00012048 File Offset: 0x00010448
	public static T instance
	{
		get
		{
			if (MonoSingleton<T>.m_Instance == null)
			{
				MonoSingleton<T>.m_Instance = (Object.FindObjectOfType(typeof(T)) as T);
				if (MonoSingleton<T>.m_Instance == null)
				{
					MonoSingleton<T>.m_Instance = new GameObject("Singleton of " + typeof(T).ToString(), new Type[]
					{
						typeof(T)
					}).GetComponent<T>();
					MonoSingleton<T>.m_Instance.Init();
					MonoSingleton<T>.m_Instance.gameObject.transform.SetSiblingIndex(0);
				}
			}
			return MonoSingleton<T>.m_Instance;
		}
	}

	// Token: 0x06000E1E RID: 3614 RVA: 0x00012108 File Offset: 0x00010508
	private void Awake()
	{
		if (MonoSingleton<T>.m_Instance == null)
		{
			MonoSingleton<T>.m_Instance = (this as T);
		}
	}

	// Token: 0x06000E1F RID: 3615 RVA: 0x0001212F File Offset: 0x0001052F
	public virtual void Init()
	{
	}

	// Token: 0x06000E20 RID: 3616 RVA: 0x00012131 File Offset: 0x00010531
	protected virtual void OnApplicationQuit()
	{
		MonoSingleton<T>.m_Instance = (T)((object)null);
	}

	// Token: 0x06000E21 RID: 3617 RVA: 0x0001213E File Offset: 0x0001053E
	protected virtual void OnDestroy()
	{
		if (MonoSingleton<T>.m_Instance == this)
		{
			MonoSingleton<T>.m_Instance = (T)((object)null);
		}
	}

	// Token: 0x040009CC RID: 2508
	private static T m_Instance;
}
