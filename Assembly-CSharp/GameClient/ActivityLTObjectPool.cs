using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200173B RID: 5947
	public class ActivityLTObjectPool<T>
	{
		// Token: 0x0600E9BA RID: 59834 RVA: 0x003DE494 File Offset: 0x003DC894
		public ActivityLTObjectPool(int initializeNums, GameObject parent, string prefabPath)
		{
			this.parent = parent;
			this.prefabPath = prefabPath;
			this.actGoList = new List<ActivityLTObject<T>>();
			this.goList = new List<GameObject>();
			this.PreWarmPool(initializeNums);
		}

		// Token: 0x0600E9BB RID: 59835 RVA: 0x003DE4C8 File Offset: 0x003DC8C8
		private void PreWarmPool(int initNum)
		{
			if (initNum <= 0)
			{
				return;
			}
			for (int i = 0; i < initNum; i++)
			{
				ActivityLTObject<T> activityLTObject = new ActivityLTObject<T>();
				GameObject gameObject = activityLTObject.CreatePrefab(this.parent, this.prefabPath);
				gameObject.CustomActive(false);
				this.goList.Add(gameObject);
				this.actGoList.Add(activityLTObject);
			}
		}

		// Token: 0x0600E9BC RID: 59836 RVA: 0x003DE528 File Offset: 0x003DC928
		public GameObject GetGameObject()
		{
			GameObject gameObject;
			if (this.goList.Count > 0)
			{
				gameObject = this.goList[0];
				gameObject.CustomActive(true);
				if (this.goList != null)
				{
					this.goList.RemoveAt(0);
				}
			}
			else
			{
				ActivityLTObject<T> activityLTObject = new ActivityLTObject<T>();
				gameObject = activityLTObject.CreatePrefab(this.parent, this.prefabPath);
				gameObject.CustomActive(true);
				if (this.actGoList != null)
				{
					this.actGoList.Add(activityLTObject);
				}
			}
			return gameObject;
		}

		// Token: 0x0600E9BD RID: 59837 RVA: 0x003DE5B0 File Offset: 0x003DC9B0
		public void ReleaseGameObject(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			go.CustomActive(false);
			Utility.AttachTo(go, this.parent, false);
			if (this.goList != null)
			{
				this.goList.Add(go);
			}
		}

		// Token: 0x0600E9BE RID: 59838 RVA: 0x003DE5EC File Offset: 0x003DC9EC
		public void ReleasePool()
		{
			if (this.actGoList != null)
			{
				for (int i = 0; i < this.actGoList.Count; i++)
				{
					GameObject goSelf = this.actGoList[i].GetGoSelf();
					if (goSelf != null)
					{
						Singleton<CGameObjectPool>.instance.RecycleGameObject(goSelf);
					}
				}
			}
			this.actGoList = null;
			this.goList = null;
		}

		// Token: 0x04008DC4 RID: 36292
		private List<ActivityLTObject<T>> actGoList;

		// Token: 0x04008DC5 RID: 36293
		private List<GameObject> goList;

		// Token: 0x04008DC6 RID: 36294
		private GameObject parent;

		// Token: 0x04008DC7 RID: 36295
		private string prefabPath;
	}
}
