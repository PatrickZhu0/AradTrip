using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Scripts.UI
{
	// Token: 0x02000F3F RID: 3903
	public class ComUIListElementScript : MonoBehaviour
	{
		// Token: 0x060097E4 RID: 38884 RVA: 0x001D2172 File Offset: 0x001D0572
		public virtual void ChangeDisplay(bool selected)
		{
			if (this.m_belongedListScript.onItemChageDisplay != null)
			{
				this.m_belongedListScript.onItemChageDisplay(this, selected);
			}
		}

		// Token: 0x060097E5 RID: 38885 RVA: 0x001D2196 File Offset: 0x001D0596
		public void Disable()
		{
			if (this.m_useSetActiveForDisplay)
			{
				base.gameObject.CustomActive(false);
			}
			else
			{
				this.m_canvasGroup.alpha = 0f;
				this.m_canvasGroup.blocksRaycasts = false;
			}
		}

		// Token: 0x060097E6 RID: 38886 RVA: 0x001D21D0 File Offset: 0x001D05D0
		public void Enable(ComUIListScript belongedList, int index, string name, ref stRect rect, bool selected)
		{
			this.m_belongedListScript = belongedList;
			this.m_index = index;
			base.gameObject.name = name + "_" + index.ToString();
			if (this.m_useSetActiveForDisplay)
			{
				base.gameObject.CustomActive(true);
			}
			else
			{
				this.m_canvasGroup.alpha = 1f;
				this.m_canvasGroup.blocksRaycasts = true;
			}
			this.SetComponentBelongedList(base.gameObject);
			this.SetRect(ref rect);
			this.ChangeDisplay(selected);
		}

		// Token: 0x060097E7 RID: 38887 RVA: 0x001D2264 File Offset: 0x001D0664
		protected virtual Vector2 GetDefaultSize()
		{
			return new Vector2(((RectTransform)base.gameObject.transform).rect.width, ((RectTransform)base.gameObject.transform).rect.height);
		}

		// Token: 0x060097E8 RID: 38888 RVA: 0x001D22B0 File Offset: 0x001D06B0
		public void Initialize()
		{
			if (!this.m_isInitialized)
			{
				this.m_isInitialized = true;
				if (this.m_autoAddSelectionScript && base.gameObject.GetComponent<ComUIListElementSelectionScript>() == null)
				{
					base.gameObject.AddComponent<ComUIListElementSelectionScript>();
				}
				if (!this.m_useSetActiveForDisplay)
				{
					this.m_canvasGroup = base.gameObject.GetComponent<CanvasGroup>();
					if (this.m_canvasGroup == null)
					{
						this.m_canvasGroup = base.gameObject.AddComponent<CanvasGroup>();
					}
				}
				this.m_defaultSize = this.GetDefaultSize();
				this.InitRectTransform();
			}
		}

		// Token: 0x060097E9 RID: 38889 RVA: 0x001D234C File Offset: 0x001D074C
		private void InitRectTransform()
		{
			RectTransform rectTransform = base.gameObject.transform as RectTransform;
			rectTransform.anchorMin = new Vector2(0f, 1f);
			rectTransform.anchorMax = new Vector2(0f, 1f);
			rectTransform.pivot = new Vector2(0f, 1f);
			rectTransform.sizeDelta = this.m_defaultSize;
			rectTransform.localRotation = Quaternion.identity;
			rectTransform.localScale = new Vector3(1f, 1f, 1f);
		}

		// Token: 0x060097EA RID: 38890 RVA: 0x001D23DA File Offset: 0x001D07DA
		public void OnSelected(BaseEventData baseEventData)
		{
			this.m_belongedListScript.SelectElement(this.m_index, true);
		}

		// Token: 0x060097EB RID: 38891 RVA: 0x001D23F0 File Offset: 0x001D07F0
		public void SetComponentBelongedList(GameObject gameObject)
		{
			List<Component> list = ListPool<Component>.Get();
			gameObject.GetComponents(typeof(ComUIListElementSelectionScript), list);
			if (list != null && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					ComUIListElementSelectionScript comUIListElementSelectionScript = list[i] as ComUIListElementSelectionScript;
					comUIListElementSelectionScript.SetBelongedList(this.m_belongedListScript, this.m_index);
				}
			}
			ListPool<Component>.Release(list);
			for (int j = 0; j < gameObject.transform.childCount; j++)
			{
				this.SetComponentBelongedList(gameObject.transform.GetChild(j).gameObject);
			}
		}

		// Token: 0x060097EC RID: 38892 RVA: 0x001D2498 File Offset: 0x001D0898
		public void SetRect(ref stRect rect)
		{
			this.m_rect = rect;
			RectTransform rectTransform = base.gameObject.transform as RectTransform;
			rectTransform.sizeDelta = new Vector2((float)this.m_rect.m_width, (float)this.m_rect.m_height);
			rectTransform.anchoredPosition = new Vector2((float)rect.m_left, (float)rect.m_top);
		}

		// Token: 0x04004E5F RID: 20063
		[HideInInspector]
		public int m_index;

		// Token: 0x04004E60 RID: 20064
		public stRect m_rect;

		// Token: 0x04004E61 RID: 20065
		[HideInInspector]
		public object gameObjectBindScript;

		// Token: 0x04004E62 RID: 20066
		public bool m_autoAddSelectionScript = true;

		// Token: 0x04004E63 RID: 20067
		private CanvasGroup m_canvasGroup;

		// Token: 0x04004E64 RID: 20068
		[HideInInspector]
		public Vector2 m_defaultSize;

		// Token: 0x04004E65 RID: 20069
		public bool m_useSetActiveForDisplay;

		// Token: 0x04004E66 RID: 20070
		[HideInInspector]
		public ComUIListScript m_belongedListScript;

		// Token: 0x04004E67 RID: 20071
		protected bool m_isInitialized;

		// Token: 0x02000F40 RID: 3904
		// (Invoke) Token: 0x060097EE RID: 38894
		public delegate void OnSelectedDelegate();
	}
}
