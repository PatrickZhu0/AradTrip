using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001755 RID: 5973
	internal class ComExpandControlRedPointBinder : MonoBehaviour
	{
		// Token: 0x0600EBCF RID: 60367 RVA: 0x003ED7AB File Offset: 0x003EBBAB
		private void OnDestroy()
		{
			this.ParentObj = null;
			this.ParentRedPoint = null;
			this.ParentRedPointText = null;
			this.ChildrenObj = null;
			this.ChildrenRedPoint = null;
		}

		// Token: 0x0600EBD0 RID: 60368 RVA: 0x003ED7D0 File Offset: 0x003EBBD0
		private void Start()
		{
			if (this.ParentObj == null || this.ParentRedPoint == null || this.ParentRedPointText == null || this.ChildrenObj == null || this.ChildrenRedPoint == null)
			{
				return;
			}
		}

		// Token: 0x0600EBD1 RID: 60369 RVA: 0x003ED828 File Offset: 0x003EBC28
		private void Update()
		{
			if (this.ParentObj == null || this.ParentRedPoint == null || this.ParentRedPointText == null)
			{
				return;
			}
			bool bActive = false;
			if (this.ChildrenObj != null)
			{
				for (int i = 0; i < this.ChildrenObj.Count; i++)
				{
					if (this.ChildrenObj[i].activeSelf)
					{
						bActive = true;
						break;
					}
				}
			}
			this.ParentObj.CustomActive(bActive);
			if (this.ChildrenRedPoint != null)
			{
				int num = 0;
				for (int j = 0; j < this.ChildrenRedPoint.Count; j++)
				{
					GameObject gameObject = this.ChildrenRedPoint[j].gameObject;
					if (!(gameObject == null) && !(gameObject.transform.parent == null) && !(gameObject.transform.parent.gameObject == null))
					{
						if (gameObject.transform.parent.gameObject.activeSelf && gameObject.activeSelf)
						{
							num++;
						}
					}
				}
				if (num > 0)
				{
					this._PrepareStringTbl(num + 1);
					this.ParentRedPointText.text = ComExpandControlRedPointBinder.stringTbl[num];
					this.ParentRedPoint.gameObject.CustomActive(true);
				}
				else
				{
					this.ParentRedPoint.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600EBD2 RID: 60370 RVA: 0x003ED9B0 File Offset: 0x003EBDB0
		protected void _PrepareStringTbl(int num)
		{
			if (ComExpandControlRedPointBinder.stringTbl == null)
			{
				ComExpandControlRedPointBinder.stringTbl = new string[num];
				int i = 0;
				int num2 = ComExpandControlRedPointBinder.stringTbl.Length;
				while (i < num2)
				{
					ComExpandControlRedPointBinder.stringTbl[i] = i.ToString();
					i++;
				}
				return;
			}
			if (ComExpandControlRedPointBinder.stringTbl.Length < num)
			{
				string[] array = new string[num];
				int j = 0;
				int num3 = ComExpandControlRedPointBinder.stringTbl.Length;
				while (j < num3)
				{
					array[j] = ComExpandControlRedPointBinder.stringTbl[j];
					j++;
				}
				int k = ComExpandControlRedPointBinder.stringTbl.Length;
				int num4 = array.Length;
				while (k < num4)
				{
					array[k] = k.ToString();
					k++;
				}
				ComExpandControlRedPointBinder.stringTbl = array;
			}
		}

		// Token: 0x04008F06 RID: 36614
		public GameObject ParentObj;

		// Token: 0x04008F07 RID: 36615
		public Image ParentRedPoint;

		// Token: 0x04008F08 RID: 36616
		public Text ParentRedPointText;

		// Token: 0x04008F09 RID: 36617
		public List<GameObject> ChildrenObj;

		// Token: 0x04008F0A RID: 36618
		public List<Image> ChildrenRedPoint;

		// Token: 0x04008F0B RID: 36619
		public static string[] stringTbl;
	}
}
