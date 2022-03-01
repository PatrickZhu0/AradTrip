using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004AF6 RID: 19190
	public class TitleConvert : MonoBehaviour
	{
		// Token: 0x170025EF RID: 9711
		// (get) Token: 0x0601BEAD RID: 114349 RVA: 0x0088BF62 File Offset: 0x0088A362
		// (set) Token: 0x0601BEAE RID: 114350 RVA: 0x0088BF6A File Offset: 0x0088A36A
		public int TitleID
		{
			get
			{
				return this.iTitleID;
			}
			set
			{
				if (this.iTitleID != value)
				{
					this.iTitleID = value;
					this._OnUpdateResource();
				}
			}
		}

		// Token: 0x0601BEAF RID: 114351 RVA: 0x0088BF85 File Offset: 0x0088A385
		public void Active(bool active)
		{
			if (null != this.animator)
			{
				this.animator.SetPause(!active);
				this.animator.SetVisible(active);
			}
		}

		// Token: 0x0601BEB0 RID: 114352 RVA: 0x0088BFB4 File Offset: 0x0088A3B4
		public float GetAnimationTime(float fDefault = 5f)
		{
			if (this.ani != null && this.animator != null)
			{
				float timeLength = this.animator.GetTimeLength();
				return (timeLength >= fDefault) ? timeLength : fDefault;
			}
			return fDefault;
		}

		// Token: 0x0601BEB1 RID: 114353 RVA: 0x0088C000 File Offset: 0x0088A400
		private void _OnUpdateResource()
		{
			if (this.ani != null)
			{
				this.ani.transform.SetParent(null);
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.ani.gameObject);
				this.ani = null;
				this.animator = null;
				this.render = null;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.iTitleID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.ani = Singleton<CGameObjectPool>.instance.GetGameObject(tableItem.ModelPath, enResourceType.UIPrefab, 2U);
				if (this.ani != null)
				{
					this.animator = this.ani.GetComponent<GeAnimFrameBillboard>();
					this.animator.Init();
					this.render = this.ani.GetComponent<SpriteRenderer>();
					Utility.AttachTo(this.ani, base.gameObject, false);
					base.gameObject.SetActive(true);
					this.Active(false);
					if (this.render != null)
					{
						this.render.sortingOrder = this.iSortInLayer;
					}
				}
				if (this.ani == null || this.animator == null || this.render == null)
				{
					Logger.LogErrorFormat("create title failed with title id = {0}", new object[]
					{
						this.iTitleID
					});
				}
			}
			if (this.element != null && this.ani != null)
			{
				this.ani.layer = this.sortingLayerID;
				this.element.ignoreLayout = false;
				if (!this.bUseScale)
				{
					this.element.preferredWidth = this.ani.transform.localScale.x / 100f * (float)this.width;
					this.element.preferredHeight = this.ani.transform.localScale.y / 100f * (float)this.height;
				}
				else
				{
					this.ani.transform.localScale = new Vector3(this.ani.transform.localScale.x * this.scale.x, this.ani.transform.localScale.y * this.scale.y, 1f);
					this.element.preferredWidth = this.ani.transform.localScale.x / 100f * (float)this.width;
					this.element.preferredHeight = this.ani.transform.localScale.y / 100f * (float)this.height;
				}
			}
		}

		// Token: 0x0601BEB2 RID: 114354 RVA: 0x0088C2E0 File Offset: 0x0088A6E0
		public void OnRecycle()
		{
			if (this.ani != null)
			{
				this.ani.transform.SetParent(null);
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.ani.gameObject);
				this.ani = null;
				this.animator = null;
				this.render = null;
			}
			this.iTitleID = 0;
		}

		// Token: 0x0401376C RID: 79724
		public int width;

		// Token: 0x0401376D RID: 79725
		public int height;

		// Token: 0x0401376E RID: 79726
		public LayoutElement element;

		// Token: 0x0401376F RID: 79727
		public GameObject ani;

		// Token: 0x04013770 RID: 79728
		public GeAnimFrameBillboard animator;

		// Token: 0x04013771 RID: 79729
		public SpriteRenderer render;

		// Token: 0x04013772 RID: 79730
		public Vector2 scale = Vector2.one;

		// Token: 0x04013773 RID: 79731
		public bool bUseScale;

		// Token: 0x04013774 RID: 79732
		public int iSortInLayer;

		// Token: 0x04013775 RID: 79733
		private Canvas canvas;

		// Token: 0x04013776 RID: 79734
		public int sortingLayerID;

		// Token: 0x04013777 RID: 79735
		private bool bNeedUpdateScale;

		// Token: 0x04013778 RID: 79736
		private int iTitleID;
	}
}
