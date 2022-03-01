using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000025 RID: 37
	public class ComDotController : MonoBehaviour
	{
		// Token: 0x060000E3 RID: 227 RVA: 0x00009CAC File Offset: 0x000080AC
		private void OnDestroy()
		{
			if (this.dotsParent != null)
			{
				this.dotsParent.Clear();
			}
			if (this.dots != null)
			{
				this.dots.Clear();
			}
			this.m_MaxPageNum = 0;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00009CE4 File Offset: 0x000080E4
		public void InitDots(int iMaxPage, bool needMoreThanTwo = true)
		{
			this.m_MaxPageNum = iMaxPage;
			if (this.dotParent == null || this.dotRoot == null)
			{
				return;
			}
			for (int i = 0; i < iMaxPage; i++)
			{
				if (i < this.dotsParent.Count)
				{
					GameObject gameObject = this.dotsParent[i];
				}
				else
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.dotParent);
					Utility.AttachTo(gameObject, this.dotRoot, false);
					this.dotsParent.Add(gameObject);
				}
			}
			if (this.dots != null)
			{
				this.dots.Clear();
			}
			for (int j = 0; j < this.dotsParent.Count; j++)
			{
				GameObject gameObject2 = this.dotsParent[j];
				if (gameObject2)
				{
					GameObject gameObject3 = gameObject2.transform.GetChild(0).gameObject;
					if (gameObject3)
					{
						this.dots.Add(gameObject3);
					}
				}
			}
			if (needMoreThanTwo)
			{
				base.gameObject.CustomActive(iMaxPage >= 2);
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00009E08 File Offset: 0x00008208
		public void SetDots(int iPage, int iMaxPage = 0)
		{
			if (iMaxPage <= 0)
			{
				iMaxPage = this.m_MaxPageNum;
			}
			if (this.dotsParent == null || this.dots == null)
			{
				return;
			}
			if (this.dotsParent.Count != this.dots.Count)
			{
				return;
			}
			int num = iPage - 1;
			for (int i = 0; i < this.dotsParent.Count; i++)
			{
				this.dotsParent[i].CustomActive(i < iMaxPage);
			}
			for (int j = 0; j < this.dots.Count; j++)
			{
				this.dots[j].CustomActive(j == num);
			}
		}

		// Token: 0x040000C3 RID: 195
		[SerializeField]
		private GameObject dotRoot;

		// Token: 0x040000C4 RID: 196
		[SerializeField]
		private GameObject dotParent;

		// Token: 0x040000C5 RID: 197
		[SerializeField]
		private List<GameObject> dotsParent = new List<GameObject>();

		// Token: 0x040000C6 RID: 198
		private List<GameObject> dots = new List<GameObject>();

		// Token: 0x040000C7 RID: 199
		private int m_MaxPageNum;
	}
}
