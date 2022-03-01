using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001CAA RID: 7338
	internal class ComCache : MonoBehaviour
	{
		// Token: 0x06012038 RID: 73784 RVA: 0x00543FE4 File Offset: 0x005423E4
		public void SetItems(List<object> datas)
		{
			this.datas = datas;
			if (this.datas == null)
			{
				datas = (this.datas = new List<object>());
			}
			if (datas.Count < this.scripts.Count)
			{
				for (int i = datas.Count; i < this.scripts.Count; i++)
				{
					if (this.onItemRecycled != null)
					{
						this.onItemRecycled(this.scripts[i]);
					}
					this.recycleScripts.Add(this.scripts[i]);
				}
				this.scripts.RemoveRange(datas.Count, this.scripts.Count - datas.Count);
			}
			else
			{
				int count = this.scripts.Count;
				int num = datas.Count - this.scripts.Count;
				if (this.recycleScripts.Count == num)
				{
					this.scripts.InsertRange(this.scripts.Count, this.recycleScripts);
					this.recycleScripts.Clear();
				}
				else if (this.recycleScripts.Count > num)
				{
					this.scripts.InsertRange(this.scripts.Count, this.recycleScripts.GetRange(0, num));
					this.recycleScripts.RemoveRange(0, num);
				}
				else
				{
					for (int j = this.recycleScripts.Count; j < num; j++)
					{
						GameObject go = Object.Instantiate<GameObject>(this.goPrefab);
						if (this.onItemCreate != null)
						{
							this.scripts.Add(this.onItemCreate(go));
						}
						Utility.AttachTo(go, this.goPrefab.transform.parent.gameObject, false);
					}
					this.scripts.InsertRange(this.scripts.Count, this.recycleScripts);
					this.recycleScripts.Clear();
				}
			}
			if (this.onItemVisible != null)
			{
				int num2 = 0;
				while (num2 < datas.Count && num2 < this.scripts.Count)
				{
					this.onItemVisible(this.scripts[num2], datas[num2]);
					num2++;
				}
			}
		}

		// Token: 0x0400BBC1 RID: 48065
		public GameObject goPrefab;

		// Token: 0x0400BBC2 RID: 48066
		private List<object> scripts = new List<object>();

		// Token: 0x0400BBC3 RID: 48067
		private List<object> datas = new List<object>();

		// Token: 0x0400BBC4 RID: 48068
		private List<object> recycleScripts = new List<object>();

		// Token: 0x0400BBC5 RID: 48069
		public ComCache.OnItemCreate onItemCreate;

		// Token: 0x0400BBC6 RID: 48070
		public ComCache.OnItemVisible onItemVisible;

		// Token: 0x0400BBC7 RID: 48071
		public ComCache.OnItemRecycled onItemRecycled;

		// Token: 0x02001CAB RID: 7339
		// (Invoke) Token: 0x0601203A RID: 73786
		public delegate object OnItemCreate(GameObject go);

		// Token: 0x02001CAC RID: 7340
		// (Invoke) Token: 0x0601203E RID: 73790
		public delegate void OnItemVisible(object script, object data);

		// Token: 0x02001CAD RID: 7341
		// (Invoke) Token: 0x06012042 RID: 73794
		public delegate void OnItemRecycled(object script);
	}
}
