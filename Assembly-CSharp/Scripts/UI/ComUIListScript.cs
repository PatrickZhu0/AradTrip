using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
	// Token: 0x02000F46 RID: 3910
	public class ComUIListScript : MonoBehaviour
	{
		// Token: 0x17001925 RID: 6437
		// (get) Token: 0x0600980D RID: 38925 RVA: 0x001D2756 File Offset: 0x001D0B56
		public Vector2 contentSize
		{
			get
			{
				return this.m_contentSize;
			}
		}

		// Token: 0x0600980E RID: 38926 RVA: 0x001D2760 File Offset: 0x001D0B60
		protected GameObject InstantiateElement(GameObject srcGameObject)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(srcGameObject);
			gameObject.transform.SetParent(srcGameObject.transform.parent);
			RectTransform rectTransform = srcGameObject.transform as RectTransform;
			RectTransform rectTransform2 = gameObject.transform as RectTransform;
			if (rectTransform != null && rectTransform2 != null)
			{
				rectTransform2.pivot = rectTransform.pivot;
				rectTransform2.anchorMin = rectTransform.anchorMin;
				rectTransform2.anchorMax = rectTransform.anchorMax;
				rectTransform2.offsetMin = rectTransform.offsetMin;
				rectTransform2.offsetMax = rectTransform.offsetMax;
				rectTransform2.localPosition = rectTransform.localPosition;
				rectTransform2.localRotation = rectTransform.localRotation;
				rectTransform2.localScale = rectTransform.localScale;
			}
			return gameObject;
		}

		// Token: 0x0600980F RID: 38927 RVA: 0x001D281B File Offset: 0x001D0C1B
		private void Start()
		{
		}

		// Token: 0x06009810 RID: 38928 RVA: 0x001D2820 File Offset: 0x001D0C20
		protected virtual ComUIListElementScript CreateElement(int index, ref stRect rect)
		{
			ComUIListElementScript comUIListElementScript = null;
			if (this.m_unUsedElementScripts.Count > 0)
			{
				comUIListElementScript = this.m_unUsedElementScripts[0];
				this.m_unUsedElementScripts.RemoveAt(0);
			}
			else if (this.m_elementTemplate != null)
			{
				GameObject gameObject = this.InstantiateElement(this.m_elementTemplate);
				gameObject.transform.SetParent(this.m_content.transform);
				gameObject.transform.localScale = Vector3.one;
				comUIListElementScript = gameObject.GetComponent<ComUIListElementScript>();
			}
			if (comUIListElementScript != null)
			{
				if (this.onBindItem != null && comUIListElementScript.gameObjectBindScript == null)
				{
					comUIListElementScript.gameObjectBindScript = this.onBindItem(comUIListElementScript.gameObject);
				}
				comUIListElementScript.Initialize();
				comUIListElementScript.Enable(this, index, this.m_elementName, ref rect, this.IsSelectedIndex(index));
				this.m_elementScripts.Add(comUIListElementScript);
				if (this.onItemVisiable != null)
				{
					this.onItemVisiable(comUIListElementScript);
				}
			}
			return comUIListElementScript;
		}

		// Token: 0x06009811 RID: 38929 RVA: 0x001D2924 File Offset: 0x001D0D24
		protected void DetectScroll()
		{
			if (this.m_contentRectTransform.anchoredPosition != this.m_lastContentPosition)
			{
				if (this.m_listType == ComUIListScript.enUIListType.Horizontal || this.m_listType == ComUIListScript.enUIListType.HorizontalGrid)
				{
					float num = (this.m_contentSize.x == this.m_scrollAreaSize.x) ? 0f : (this.m_contentRectTransform.anchoredPosition.x / (this.m_contentSize.x - this.m_scrollAreaSize.x));
					this.OnScrollValueChanged(new Vector2(num, 0f));
				}
				else if (this.m_listType == ComUIListScript.enUIListType.VerticalGrid || this.m_listType == ComUIListScript.enUIListType.Vertical)
				{
					float num2 = (this.m_contentSize.y == this.m_scrollAreaSize.y) ? 0f : (this.m_contentRectTransform.anchoredPosition.y / (this.m_contentSize.y - this.m_scrollAreaSize.y));
					this.OnScrollValueChanged(new Vector2(0f, num2));
				}
				this.m_lastContentPosition = this.m_contentRectTransform.anchoredPosition;
			}
		}

		// Token: 0x06009812 RID: 38930 RVA: 0x001D2A58 File Offset: 0x001D0E58
		public ComUIListElementScript GetElemenet(int index)
		{
			if (index >= 0 && index < this.m_elementAmount)
			{
				if (!this.m_useOptimized)
				{
					return this.m_elementScripts[index];
				}
				for (int i = 0; i < this.m_elementScripts.Count; i++)
				{
					if (this.m_elementScripts[i].m_index == index)
					{
						return this.m_elementScripts[i];
					}
				}
			}
			return null;
		}

		// Token: 0x06009813 RID: 38931 RVA: 0x001D2AD4 File Offset: 0x001D0ED4
		public stRect GetElementRect(int index)
		{
			if (index < 0 || index >= this.m_elementAmount)
			{
				return default(stRect);
			}
			if (!this.m_useOptimized)
			{
				return this.m_elementScripts[index].m_rect;
			}
			return this.m_elementsRect[index];
		}

		// Token: 0x06009814 RID: 38932 RVA: 0x001D2B28 File Offset: 0x001D0F28
		public void EnsureElementVisable(int index)
		{
			if (this.m_listType == ComUIListScript.enUIListType.Vertical || this.m_listType == ComUIListScript.enUIListType.VerticalGrid)
			{
				stRect elementRect = this.GetElementRect(index);
				this.m_contentRectTransform.anchoredPosition = new Vector2(this.m_contentRectTransform.anchoredPosition.x, (float)(-(float)elementRect.m_top));
			}
			else if (this.m_listType == ComUIListScript.enUIListType.Horizontal || this.m_listType == ComUIListScript.enUIListType.HorizontalGrid)
			{
				stRect elementRect2 = this.GetElementRect(index);
				this.m_contentRectTransform.anchoredPosition = new Vector2((float)(-(float)elementRect2.m_left), this.m_contentRectTransform.anchoredPosition.y);
			}
		}

		// Token: 0x06009815 RID: 38933 RVA: 0x001D2BD1 File Offset: 0x001D0FD1
		public int GetElementAmount()
		{
			return this.m_elementAmount;
		}

		// Token: 0x06009816 RID: 38934 RVA: 0x001D2BD9 File Offset: 0x001D0FD9
		public ComUIListElementScript GetLastSelectedElement()
		{
			return this.GetElemenet(this.m_lastSelectedElementIndex);
		}

		// Token: 0x06009817 RID: 38935 RVA: 0x001D2BE7 File Offset: 0x001D0FE7
		public int GetLastSelectedIndex()
		{
			return this.m_lastSelectedElementIndex;
		}

		// Token: 0x06009818 RID: 38936 RVA: 0x001D2BEF File Offset: 0x001D0FEF
		public Vector2 GetScrollValue()
		{
			return this.m_scrollValue;
		}

		// Token: 0x06009819 RID: 38937 RVA: 0x001D2BF7 File Offset: 0x001D0FF7
		public ComUIListElementScript GetSelectedElement()
		{
			return this.GetElemenet(this.m_selectedElementIndex);
		}

		// Token: 0x0600981A RID: 38938 RVA: 0x001D2C05 File Offset: 0x001D1005
		public int GetSelectedIndex()
		{
			return this.m_selectedElementIndex;
		}

		// Token: 0x0600981B RID: 38939 RVA: 0x001D2C0D File Offset: 0x001D100D
		public void HideExtraContent()
		{
			if (this.m_extraContent != null)
			{
				this.m_extraContent.CustomActive(false);
			}
		}

		// Token: 0x0600981C RID: 38940 RVA: 0x001D2C2C File Offset: 0x001D102C
		public bool IsInitialised()
		{
			return this.m_isInitialized;
		}

		// Token: 0x0600981D RID: 38941 RVA: 0x001D2C34 File Offset: 0x001D1034
		public void InitialLizeWithExternalElement(string prefabPath)
		{
			this.m_externalElementPrefabPath = prefabPath;
			this.m_useExternalElement = true;
			this.Initialize();
		}

		// Token: 0x0600981E RID: 38942 RVA: 0x001D2C4C File Offset: 0x001D104C
		public void Initialize()
		{
			if (!this.m_isInitialized)
			{
				this.m_isInitialized = true;
				this.m_selectedElementIndex = -1;
				this.m_lastSelectedElementIndex = -1;
				this.m_scrollRect = base.GetComponentInChildren<ScrollRect>(base.gameObject);
				if (this.m_scrollRect != null)
				{
					if (!this.m_scrollExternal)
					{
						this.m_scrollRect.enabled = false;
					}
					RectTransform rectTransform = this.m_scrollRect.transform as RectTransform;
					this.m_scrollAreaSize = new Vector2(rectTransform.rect.width, rectTransform.rect.height);
					this.m_content = this.m_scrollRect.content.gameObject;
				}
				this.m_scrollBar = base.GetComponentInChildren<Scrollbar>(base.gameObject);
				if (this.m_listType == ComUIListScript.enUIListType.Vertical || this.m_listType == ComUIListScript.enUIListType.VerticalGrid)
				{
					if (this.m_scrollBar != null)
					{
						this.m_scrollBar.direction = 2;
					}
					if (this.m_scrollRect != null)
					{
						this.m_scrollRect.horizontal = false;
						this.m_scrollRect.vertical = true;
						this.m_scrollRect.horizontalScrollbar = null;
						this.m_scrollRect.verticalScrollbar = this.m_scrollBar;
					}
				}
				else if (this.m_listType == ComUIListScript.enUIListType.Horizontal || this.m_listType == ComUIListScript.enUIListType.HorizontalGrid)
				{
					if (this.m_scrollBar != null)
					{
						this.m_scrollBar.direction = 0;
					}
					if (this.m_scrollRect != null)
					{
						this.m_scrollRect.horizontal = true;
						this.m_scrollRect.vertical = false;
						this.m_scrollRect.horizontalScrollbar = this.m_scrollBar;
						this.m_scrollRect.verticalScrollbar = null;
					}
				}
				this.m_elementScripts = new List<ComUIListElementScript>();
				this.m_unUsedElementScripts = new List<ComUIListElementScript>();
				if (this.m_useOptimized)
				{
					this.m_elementsRect = new List<stRect>();
				}
				if (this.m_useExternalElement)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.m_externalElementPrefabPath, true, 0U);
					ComUIListElementScript comUIListElementScript = gameObject.GetComponent<ComUIListElementScript>();
					if (comUIListElementScript != null)
					{
						comUIListElementScript.Initialize();
						this.m_elementTemplate = gameObject;
						this.m_elementName = gameObject.name;
						this.m_elementDefaultSize = comUIListElementScript.m_defaultSize;
						this.m_elementTemplate.name = this.m_elementName + "_Template";
						this.m_elementTemplate.transform.SetParent(this.m_content.transform, false);
					}
				}
				else
				{
					ComUIListElementScript comUIListElementScript = base.GetComponentInChildren<ComUIListElementScript>(base.gameObject);
					if (comUIListElementScript != null)
					{
						comUIListElementScript.Initialize();
						this.m_elementTemplate = comUIListElementScript.gameObject;
						this.m_elementName = comUIListElementScript.gameObject.name;
						this.m_elementDefaultSize = comUIListElementScript.m_defaultSize;
						if (this.m_elementTemplate != null)
						{
							this.m_elementTemplate.name = this.m_elementName + "_Template";
						}
					}
				}
				if (this.m_elementTemplate != null)
				{
					ComUIListElementScript component = this.m_elementTemplate.GetComponent<ComUIListElementScript>();
					if (component != null && component.m_useSetActiveForDisplay)
					{
						this.m_elementTemplate.CustomActive(false);
					}
					else
					{
						if (!this.m_elementTemplate.activeSelf)
						{
							this.m_elementTemplate.SetActive(true);
						}
						CanvasGroup canvasGroup = this.m_elementTemplate.GetComponent<CanvasGroup>();
						if (canvasGroup == null)
						{
							canvasGroup = this.m_elementTemplate.AddComponent<CanvasGroup>();
						}
						canvasGroup.alpha = 0f;
						canvasGroup.blocksRaycasts = false;
					}
				}
				if (this.m_content != null)
				{
					this.m_contentRectTransform = (this.m_content.transform as RectTransform);
					this.m_contentRectTransform.pivot = new Vector2(0f, 1f);
					this.m_contentRectTransform.anchorMin = new Vector2(0f, 1f);
					this.m_contentRectTransform.anchorMax = new Vector2(0f, 1f);
					this.m_contentRectTransform.anchoredPosition = Vector2.zero;
					this.m_contentRectTransform.localRotation = Quaternion.identity;
					this.m_contentRectTransform.localScale = new Vector3(1f, 1f, 1f);
					this.m_lastContentPosition = this.m_contentRectTransform.anchoredPosition;
				}
				if (this.m_extraContent != null)
				{
					RectTransform rectTransform2 = this.m_extraContent.transform as RectTransform;
					rectTransform2.pivot = new Vector2(0f, 1f);
					rectTransform2.anchorMin = new Vector2(0f, 1f);
					rectTransform2.anchorMax = new Vector2(0f, 1f);
					rectTransform2.anchoredPosition = Vector2.zero;
					rectTransform2.localRotation = Quaternion.identity;
					rectTransform2.localScale = Vector3.one;
					if (this.m_elementTemplate != null)
					{
						rectTransform2.sizeDelta = new Vector2((this.m_elementTemplate.transform as RectTransform).rect.width, rectTransform2.sizeDelta.y);
					}
					if (rectTransform2.parent != null && this.m_content != null)
					{
						rectTransform2.parent.SetParent(this.m_content.transform);
					}
					this.m_extraContent.SetActive(false);
				}
				this.SetElementAmount(this.m_elementAmount);
			}
		}

		// Token: 0x0600981F RID: 38943 RVA: 0x001D31E0 File Offset: 0x001D15E0
		public void UnInitialize()
		{
			this.m_isInitialized = false;
			this.m_lastSelectedElementIndex = -1;
			this.m_selectedElementIndex = -1;
			this.onBindItem = null;
			this.onItemVisiable = null;
			this.onItemSelected = null;
			this.onItemChageDisplay = null;
			this.OnItemRecycle = null;
			this.OnItemUpdate = null;
		}

		// Token: 0x06009820 RID: 38944 RVA: 0x001D322C File Offset: 0x001D162C
		public bool IsElementInScrollArea(int index)
		{
			if (index < 0 || index >= this.m_elementAmount)
			{
				return false;
			}
			stRect stRect = this.m_useOptimized ? this.m_elementsRect[index] : this.m_elementScripts[index].m_rect;
			return this.IsRectInScrollArea(ref stRect);
		}

		// Token: 0x06009821 RID: 38945 RVA: 0x001D3284 File Offset: 0x001D1684
		protected bool IsRectInScrollArea(ref stRect rect)
		{
			Vector2 zero = Vector2.zero;
			zero.x = this.m_contentRectTransform.anchoredPosition.x + (float)rect.m_left;
			zero.y = this.m_contentRectTransform.anchoredPosition.y + (float)rect.m_top;
			return zero.x + (float)rect.m_width >= 0f && zero.x <= this.m_scrollAreaSize.x && zero.y - (float)rect.m_height <= 0f && zero.y >= -this.m_scrollAreaSize.y;
		}

		// Token: 0x06009822 RID: 38946 RVA: 0x001D3342 File Offset: 0x001D1742
		public virtual bool IsSelectedIndex(int index)
		{
			return this.m_selectedElementIndex == index;
		}

		// Token: 0x06009823 RID: 38947 RVA: 0x001D3350 File Offset: 0x001D1750
		protected stRect LayoutElement(int index, ref Vector2 contentSize, ref Vector2 offset)
		{
			stRect result = default(stRect);
			result.m_width = ((this.m_elementsSize == null || this.m_listType == ComUIListScript.enUIListType.Vertical || this.m_listType == ComUIListScript.enUIListType.VerticalGrid || this.m_listType == ComUIListScript.enUIListType.HorizontalGrid) ? ((int)this.m_elementDefaultSize.x) : ((int)this.m_elementsSize[index].x));
			result.m_height = ((this.m_elementsSize == null || this.m_listType == ComUIListScript.enUIListType.Horizontal || this.m_listType == ComUIListScript.enUIListType.VerticalGrid || this.m_listType == ComUIListScript.enUIListType.HorizontalGrid) ? ((int)this.m_elementDefaultSize.y) : ((int)this.m_elementsSize[index].y));
			result.m_left = (int)offset.x;
			result.m_top = (int)offset.y;
			result.m_right = result.m_left + result.m_width;
			result.m_bottom = result.m_top - result.m_height;
			result.m_center = new Vector2((float)result.m_left + (float)result.m_width * 0.5f, (float)result.m_top - (float)result.m_height * 0.5f);
			if ((float)result.m_right > contentSize.x)
			{
				contentSize.x = (float)result.m_right;
			}
			if ((float)(-(float)result.m_bottom) > contentSize.y)
			{
				contentSize.y = (float)(-(float)result.m_bottom);
			}
			switch (this.m_listType)
			{
			case ComUIListScript.enUIListType.Vertical:
				offset.y -= (float)result.m_height + this.m_elementSpacing.y;
				return result;
			case ComUIListScript.enUIListType.Horizontal:
				offset.x += (float)result.m_width + this.m_elementSpacing.x;
				return result;
			case ComUIListScript.enUIListType.VerticalGrid:
				offset.x += (float)result.m_width + this.m_elementSpacing.x;
				if (offset.x + (float)result.m_width > this.m_scrollAreaSize.x)
				{
					offset.x = this.m_elementPadding.x;
					offset.y -= (float)result.m_height + this.m_elementSpacing.y;
				}
				return result;
			case ComUIListScript.enUIListType.HorizontalGrid:
				offset.y -= (float)result.m_height + this.m_elementSpacing.y;
				if (-offset.y + (float)result.m_height > this.m_scrollAreaSize.y)
				{
					offset.y = this.m_elementPadding.y;
					offset.x += (float)result.m_width + this.m_elementSpacing.x;
				}
				return result;
			default:
				return result;
			}
		}

		// Token: 0x06009824 RID: 38948 RVA: 0x001D3634 File Offset: 0x001D1A34
		public void MoveElementInScrollArea(int index, bool moveImmediately)
		{
			if (index >= 0 && index < this.m_elementAmount)
			{
				Vector2 zero = Vector2.zero;
				Vector2 zero2 = Vector2.zero;
				stRect stRect = this.m_useOptimized ? this.m_elementsRect[index] : this.m_elementScripts[index].m_rect;
				zero2.x = this.m_contentRectTransform.anchoredPosition.x + (float)stRect.m_left;
				zero2.y = this.m_contentRectTransform.anchoredPosition.y + (float)stRect.m_top;
				if (zero2.x < 0f)
				{
					zero.x = -zero2.x;
				}
				else if (zero2.x + (float)stRect.m_width > this.m_scrollAreaSize.x)
				{
					zero.x = this.m_scrollAreaSize.x - (zero2.x + (float)stRect.m_width);
				}
				if (zero2.y > 0f)
				{
					zero.y = -zero2.y;
				}
				else if (zero2.y - (float)stRect.m_height < -this.m_scrollAreaSize.y)
				{
					zero.y = -this.m_scrollAreaSize.y - (zero2.y - (float)stRect.m_height);
				}
				if (moveImmediately)
				{
					this.m_contentRectTransform.anchoredPosition += zero;
				}
				else
				{
					Vector2 vector = this.m_contentRectTransform.anchoredPosition + zero;
				}
			}
		}

		// Token: 0x06009825 RID: 38949 RVA: 0x001D37DC File Offset: 0x001D1BDC
		private void OnDestroy()
		{
		}

		// Token: 0x06009826 RID: 38950 RVA: 0x001D37DE File Offset: 0x001D1BDE
		protected void OnScrollValueChanged(Vector2 value)
		{
			this.m_scrollValue = value;
		}

		// Token: 0x06009827 RID: 38951 RVA: 0x001D37E8 File Offset: 0x001D1BE8
		public void AutoScroll2Bottom()
		{
			Vector2 scrollValue = default(Vector2);
			scrollValue.x = 0f;
			scrollValue.y = 1f;
			this.m_scrollValue = scrollValue;
		}

		// Token: 0x06009828 RID: 38952 RVA: 0x001D381C File Offset: 0x001D1C1C
		protected virtual void ProcessElements()
		{
			this.m_contentSize = Vector2.zero;
			Vector2 zero = Vector2.zero;
			if (this.m_listType == ComUIListScript.enUIListType.Vertical || this.m_listType == ComUIListScript.enUIListType.VerticalGrid)
			{
				zero.y += this.m_elementLayoutOffset;
			}
			else
			{
				zero.x += this.m_elementLayoutOffset;
			}
			zero.x += this.m_elementPadding.x;
			zero.y -= this.m_elementPadding.y;
			for (int i = 0; i < this.m_elementAmount; i++)
			{
				stRect stRect = this.LayoutElement(i, ref this.m_contentSize, ref zero);
				if (this.m_useOptimized)
				{
					if (i < this.m_elementsRect.Count)
					{
						this.m_elementsRect[i] = stRect;
					}
					else
					{
						this.m_elementsRect.Add(stRect);
					}
				}
				if (!this.m_useOptimized || this.IsRectInScrollArea(ref stRect))
				{
					this.CreateElement(i, ref stRect);
				}
			}
			if (this.m_listType == ComUIListScript.enUIListType.Vertical || this.m_listType == ComUIListScript.enUIListType.VerticalGrid)
			{
				this.m_contentSize.y = this.m_contentSize.y + this.m_elementPadding.y;
			}
			else
			{
				this.m_contentSize.x = this.m_contentSize.x + this.m_elementPadding.x;
			}
			if (this.m_extraContent != null)
			{
				if (this.m_elementAmount > 0)
				{
					this.ProcessExtraContent(ref this.m_contentSize, zero);
				}
				else
				{
					this.m_extraContent.CustomActive(false);
				}
			}
			this.ResizeContent(ref this.m_contentSize, false);
		}

		// Token: 0x06009829 RID: 38953 RVA: 0x001D39D4 File Offset: 0x001D1DD4
		private void ProcessExtraContent(ref Vector2 contentSize, Vector2 offset)
		{
			RectTransform rectTransform = this.m_extraContent.transform as RectTransform;
			rectTransform.anchoredPosition = offset;
			this.m_extraContent.CustomActive(true);
			if (this.m_listType == ComUIListScript.enUIListType.Horizontal || this.m_listType == ComUIListScript.enUIListType.HorizontalGrid)
			{
				contentSize.x += rectTransform.rect.width + this.m_elementSpacing.x;
			}
			else
			{
				contentSize.y += rectTransform.rect.height + this.m_elementSpacing.y;
			}
		}

		// Token: 0x0600982A RID: 38954 RVA: 0x001D3A70 File Offset: 0x001D1E70
		protected void ProcessUnUsedElement()
		{
			if (this.m_unUsedElementScripts != null && this.m_unUsedElementScripts.Count > 0)
			{
				for (int i = 0; i < this.m_unUsedElementScripts.Count; i++)
				{
					this.m_unUsedElementScripts[i].Disable();
				}
			}
		}

		// Token: 0x0600982B RID: 38955 RVA: 0x001D3AC8 File Offset: 0x001D1EC8
		protected void RecycleElement(bool disableElement)
		{
			if (this.m_elementScripts == null)
			{
				return;
			}
			while (this.m_elementScripts.Count > 0)
			{
				ComUIListElementScript comUIListElementScript = this.m_elementScripts[0];
				this.m_elementScripts.RemoveAt(0);
				if (disableElement)
				{
					comUIListElementScript.Disable();
				}
				if (this.OnItemRecycle != null)
				{
					this.OnItemRecycle(comUIListElementScript);
				}
				this.m_unUsedElementScripts.Add(comUIListElementScript);
			}
		}

		// Token: 0x0600982C RID: 38956 RVA: 0x001D3B3F File Offset: 0x001D1F3F
		protected void RecycleElement(ComUIListElementScript elementScript, bool disableElement)
		{
			if (disableElement)
			{
				elementScript.Disable();
			}
			if (this.OnItemRecycle != null)
			{
				this.OnItemRecycle(elementScript);
			}
			this.m_elementScripts.Remove(elementScript);
			this.m_unUsedElementScripts.Add(elementScript);
		}

		// Token: 0x0600982D RID: 38957 RVA: 0x001D3B7D File Offset: 0x001D1F7D
		public void ResetContentPosition()
		{
			if (this.m_contentRectTransform != null)
			{
				this.m_contentRectTransform.anchoredPosition = Vector2.zero;
			}
		}

		// Token: 0x0600982E RID: 38958 RVA: 0x001D3BA0 File Offset: 0x001D1FA0
		protected virtual void ResizeContent(ref Vector2 size, bool resetPosition)
		{
			float num = 0f;
			float num2 = 0f;
			if (this.m_autoAdjustScrollAreaSize)
			{
				Vector2 scrollAreaSize = this.m_scrollAreaSize;
				this.m_scrollAreaSize = size;
				if (this.m_scrollAreaSize.x > this.m_scrollRectAreaMaxSize.x)
				{
					this.m_scrollAreaSize.x = this.m_scrollRectAreaMaxSize.x;
				}
				if (this.m_scrollAreaSize.y > this.m_scrollRectAreaMaxSize.y)
				{
					this.m_scrollAreaSize.y = this.m_scrollRectAreaMaxSize.y;
				}
				Vector2 vector = this.m_scrollAreaSize - scrollAreaSize;
				if (vector != Vector2.zero)
				{
					RectTransform rectTransform = base.gameObject.transform as RectTransform;
					if (rectTransform.anchorMin == rectTransform.anchorMax)
					{
						rectTransform.sizeDelta += vector;
					}
				}
			}
			else if (this.m_autoCenteredElements)
			{
				if (this.m_listType == ComUIListScript.enUIListType.Vertical && size.y < this.m_scrollAreaSize.y)
				{
					num2 = (size.y - this.m_scrollAreaSize.y) / 2f;
				}
				else if (this.m_listType == ComUIListScript.enUIListType.Horizontal && size.x < this.m_scrollAreaSize.x)
				{
					num = (this.m_scrollAreaSize.x - size.x) / 2f;
				}
				else if (this.m_listType == ComUIListScript.enUIListType.VerticalGrid && size.x < this.m_scrollAreaSize.x)
				{
					num = (this.m_scrollAreaSize.x - size.x) / 2f;
				}
			}
			if (size.x < this.m_scrollAreaSize.x)
			{
				size.x = this.m_scrollAreaSize.x;
			}
			if (size.y < this.m_scrollAreaSize.y)
			{
				size.y = this.m_scrollAreaSize.y;
			}
			if (this.m_contentRectTransform != null)
			{
				this.m_contentRectTransform.sizeDelta = size;
				if (resetPosition)
				{
					this.m_contentRectTransform.anchoredPosition = Vector2.zero;
				}
				if (this.m_autoCenteredElements)
				{
					if (num != 0f)
					{
						this.m_contentRectTransform.anchoredPosition = new Vector2(num, this.m_contentRectTransform.anchoredPosition.y);
					}
					if (num2 != 0f)
					{
						this.m_contentRectTransform.anchoredPosition = new Vector2(this.m_contentRectTransform.anchoredPosition.x, num2);
					}
				}
			}
		}

		// Token: 0x0600982F RID: 38959 RVA: 0x001D3E50 File Offset: 0x001D2250
		public virtual void SelectElement(int index, bool isDispatchSelectedChangeEvent = true)
		{
			this.m_lastSelectedElementIndex = this.m_selectedElementIndex;
			this.m_selectedElementIndex = index;
			if (this.m_lastSelectedElementIndex == this.m_selectedElementIndex)
			{
				if (this.m_alwaysDispatchSelectedChangeEvent)
				{
				}
			}
			else
			{
				if (this.m_lastSelectedElementIndex >= 0)
				{
					ComUIListElementScript elemenet = this.GetElemenet(this.m_lastSelectedElementIndex);
					if (elemenet != null)
					{
						elemenet.ChangeDisplay(false);
					}
				}
				if (this.m_selectedElementIndex >= 0)
				{
					ComUIListElementScript elemenet2 = this.GetElemenet(this.m_selectedElementIndex);
					if (elemenet2 != null)
					{
						elemenet2.ChangeDisplay(true);
						if (this.onItemSelected != null)
						{
							this.onItemSelected(elemenet2);
						}
					}
				}
				if (isDispatchSelectedChangeEvent)
				{
				}
			}
		}

		// Token: 0x06009830 RID: 38960 RVA: 0x001D3F06 File Offset: 0x001D2306
		public void ResetSelectedElementIndex()
		{
			this.m_selectedElementIndex = -1;
			this.m_lastSelectedElementIndex = 0;
		}

		// Token: 0x06009831 RID: 38961 RVA: 0x001D3F16 File Offset: 0x001D2316
		public void SetElementAmount(int amount)
		{
			this.SetElementAmount(amount, null);
		}

		// Token: 0x06009832 RID: 38962 RVA: 0x001D3F20 File Offset: 0x001D2320
		public void UpdateElementAmount(int amount)
		{
			if (this.m_useOptimized && this.m_elementsRect == null)
			{
				this.SetElementAmount(amount);
				return;
			}
			Vector2 zero = Vector2.zero;
			Vector2 vector = zero;
			int num = (this.m_elementsSize == null || this.m_listType == ComUIListScript.enUIListType.Vertical || this.m_listType == ComUIListScript.enUIListType.VerticalGrid || this.m_listType == ComUIListScript.enUIListType.HorizontalGrid) ? ((int)this.m_elementDefaultSize.x) : ((int)this.m_elementsSize[this.m_elementsSize.Count - 1].x);
			int num2 = (this.m_elementsSize == null || this.m_listType == ComUIListScript.enUIListType.Horizontal || this.m_listType == ComUIListScript.enUIListType.VerticalGrid || this.m_listType == ComUIListScript.enUIListType.HorizontalGrid) ? ((int)this.m_elementDefaultSize.y) : ((int)this.m_elementsSize[this.m_elementsSize.Count - 1].y);
			if (this.m_listType == ComUIListScript.enUIListType.Vertical || this.m_listType == ComUIListScript.enUIListType.VerticalGrid)
			{
				zero.y += this.m_elementLayoutOffset;
				vector.y += (float)num2;
			}
			else
			{
				zero.x += this.m_elementLayoutOffset;
				vector.x += (float)num;
			}
			zero.x += this.m_elementPadding.x;
			zero.y -= this.m_elementPadding.y;
			vector += zero;
			if (this.m_ZeroTipsObj != null)
			{
				if (amount <= 0)
				{
					this.m_ZeroTipsObj.SetActive(true);
				}
				else
				{
					this.m_ZeroTipsObj.SetActive(false);
				}
			}
			if (amount > this.m_elementAmount)
			{
				float num3 = 0f;
				float num4 = 0f;
				switch (this.m_listType)
				{
				case ComUIListScript.enUIListType.Vertical:
					num3 -= (float)num2 + this.m_elementSpacing.y;
					break;
				case ComUIListScript.enUIListType.Horizontal:
					num4 += (float)num + this.m_elementSpacing.x;
					break;
				case ComUIListScript.enUIListType.VerticalGrid:
					num4 += (float)num + this.m_elementSpacing.x;
					if (num4 + (float)num > this.m_scrollAreaSize.x)
					{
						num4 = this.m_elementPadding.x;
						num3 -= (float)num2 + this.m_elementSpacing.y;
					}
					break;
				case ComUIListScript.enUIListType.HorizontalGrid:
					num3 -= (float)num2 + this.m_elementSpacing.y;
					if (-num3 + (float)num2 > this.m_scrollAreaSize.y)
					{
						num3 = this.m_elementPadding.y;
						num4 += (float)num + this.m_elementSpacing.x;
					}
					break;
				}
				zero.x += num4 * (float)this.m_elementAmount;
				zero.y += num3 * (float)this.m_elementAmount;
				for (int i = 0; i < this.m_elementScripts.Count; i++)
				{
					if (this.OnItemUpdate != null)
					{
						this.OnItemUpdate(this.m_elementScripts[i]);
					}
				}
				for (int j = this.m_elementAmount; j < amount; j++)
				{
					stRect stRect = this.LayoutElement(j, ref this.m_contentSize, ref zero);
					if (this.m_useOptimized)
					{
						if (j < this.m_elementsRect.Count)
						{
							this.m_elementsRect[j] = stRect;
						}
						else
						{
							this.m_elementsRect.Add(stRect);
						}
					}
					if (!this.m_useOptimized || this.IsRectInScrollArea(ref stRect))
					{
						this.CreateElement(j, ref stRect);
					}
				}
				this.ResizeContent(ref this.m_contentSize, false);
				this.m_elementAmount = amount;
			}
			else
			{
				bool flag = false;
				for (int k = this.m_elementScripts.Count - 1; k >= 0; k--)
				{
					ComUIListElementScript comUIListElementScript = this.m_elementScripts[k];
					if (comUIListElementScript.m_index >= amount)
					{
						this.RecycleElement(comUIListElementScript, true);
						flag = true;
					}
				}
				this.m_contentSize += vector * (float)(amount - this.m_elementAmount);
				this.ResizeContent(ref this.m_contentSize, false);
				this.m_elementAmount = amount;
				if (flag)
				{
					this.MoveElementInScrollArea(amount - 1, true);
				}
				for (int l = 0; l < this.m_elementScripts.Count; l++)
				{
					if (this.OnItemUpdate != null)
					{
						this.OnItemUpdate(this.m_elementScripts[l]);
					}
				}
			}
		}

		// Token: 0x06009833 RID: 38963 RVA: 0x001D43E8 File Offset: 0x001D27E8
		public void UpdateElement()
		{
			if (this.m_elementScripts == null || this.m_elementScripts.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.m_elementScripts.Count; i++)
			{
				if (this.OnItemUpdate != null)
				{
					this.OnItemUpdate(this.m_elementScripts[i]);
				}
			}
		}

		// Token: 0x06009834 RID: 38964 RVA: 0x001D4450 File Offset: 0x001D2850
		public virtual void SetElementAmount(int amount, List<Vector2> elementsSize)
		{
			if (amount < 0)
			{
				amount = 0;
			}
			if (elementsSize == null || amount == elementsSize.Count)
			{
				this.RecycleElement(false);
				this.m_elementAmount = amount;
				this.m_elementsSize = elementsSize;
				this.ProcessElements();
				this.ProcessUnUsedElement();
				if (this.m_ZeroTipsObj != null)
				{
					if (amount <= 0)
					{
						this.m_ZeroTipsObj.SetActive(true);
					}
					else
					{
						this.m_ZeroTipsObj.SetActive(false);
					}
				}
			}
		}

		// Token: 0x06009835 RID: 38965 RVA: 0x001D44CF File Offset: 0x001D28CF
		public void ShowExtraContent()
		{
			if (this.m_extraContent != null)
			{
				this.m_extraContent.CustomActive(true);
			}
		}

		// Token: 0x06009836 RID: 38966 RVA: 0x001D44F0 File Offset: 0x001D28F0
		protected virtual void Update()
		{
			if (this.m_isInitialized)
			{
				if (this.m_useOptimized)
				{
					this.UpdateElementsScroll();
				}
				if (this.m_scrollRect != null && !this.m_scrollExternal)
				{
					if (this.m_contentSize.x > this.m_scrollAreaSize.x || this.m_contentSize.y > this.m_scrollAreaSize.y)
					{
						if (!this.m_scrollRect.enabled)
						{
							this.m_scrollRect.enabled = true;
						}
					}
					else if ((double)Mathf.Abs(this.m_contentRectTransform.anchoredPosition.x) >= 0.001 || (double)Mathf.Abs(this.m_contentRectTransform.anchoredPosition.y) >= 0.001 || this.m_scrollRect.enabled)
					{
					}
					this.DetectScroll();
				}
			}
		}

		// Token: 0x06009837 RID: 38967 RVA: 0x001D45F0 File Offset: 0x001D29F0
		protected void UpdateElementsScroll()
		{
			int i = 0;
			while (i < this.m_elementScripts.Count)
			{
				if (!this.IsRectInScrollArea(ref this.m_elementScripts[i].m_rect))
				{
					this.RecycleElement(this.m_elementScripts[i], true);
				}
				else
				{
					i++;
				}
			}
			for (int j = 0; j < this.m_elementAmount; j++)
			{
				if (j < this.m_elementsRect.Count)
				{
					stRect stRect = this.m_elementsRect[j];
					if (this.IsRectInScrollArea(ref stRect))
					{
						bool flag = false;
						for (int k = 0; k < this.m_elementScripts.Count; k++)
						{
							if (this.m_elementScripts[k].m_index == j)
							{
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							this.CreateElement(j, ref stRect);
						}
					}
				}
			}
		}

		// Token: 0x06009838 RID: 38968 RVA: 0x001D46E0 File Offset: 0x001D2AE0
		protected void SetProperty<T>(ref T currentValue, T newValue)
		{
			if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
			{
				return;
			}
			currentValue = newValue;
			this.SetDirty();
		}

		// Token: 0x06009839 RID: 38969 RVA: 0x001D473D File Offset: 0x001D2B3D
		public virtual bool IsActive()
		{
			return base.isActiveAndEnabled;
		}

		// Token: 0x0600983A RID: 38970 RVA: 0x001D4745 File Offset: 0x001D2B45
		protected void SetDirty()
		{
			if (!this.IsActive())
			{
				return;
			}
			this.SetElementAmount(this.m_elementAmount, this.m_elementsSize);
		}

		// Token: 0x0600983B RID: 38971 RVA: 0x001D4765 File Offset: 0x001D2B65
		protected virtual void OnDidApplyAnimationProperties()
		{
			if (!this.IsActive())
			{
				return;
			}
			this.SetDirty();
		}

		// Token: 0x0600983C RID: 38972 RVA: 0x001D4779 File Offset: 0x001D2B79
		public void StopListMovement()
		{
			if (this.m_scrollRect != null)
			{
				this.m_scrollRect.StopMovement();
			}
		}

		// Token: 0x04004E73 RID: 20083
		[HideInInspector]
		public ComUIListScript.OnBindItemDelegate onBindItem;

		// Token: 0x04004E74 RID: 20084
		[HideInInspector]
		public ComUIListScript.OnItemSelectedDelegate onItemSelected;

		// Token: 0x04004E75 RID: 20085
		[HideInInspector]
		public ComUIListScript.OnItemVisiableDelegate onItemVisiable;

		// Token: 0x04004E76 RID: 20086
		[HideInInspector]
		public ComUIListScript.OnItemChangeDisplayDelegate onItemChageDisplay;

		// Token: 0x04004E77 RID: 20087
		[HideInInspector]
		public ComUIListScript.OnItemRecycleDelegate OnItemRecycle;

		// Token: 0x04004E78 RID: 20088
		[HideInInspector]
		public ComUIListScript.OnItemUpdateDelegate OnItemUpdate;

		// Token: 0x04004E79 RID: 20089
		public bool m_alwaysDispatchSelectedChangeEvent;

		// Token: 0x04004E7A RID: 20090
		[HideInInspector]
		public bool m_autoAdjustScrollAreaSize;

		// Token: 0x04004E7B RID: 20091
		public bool m_autoCenteredElements;

		// Token: 0x04004E7C RID: 20092
		protected GameObject m_content;

		// Token: 0x04004E7D RID: 20093
		protected RectTransform m_contentRectTransform;

		// Token: 0x04004E7E RID: 20094
		protected Vector2 m_contentSize;

		// Token: 0x04004E7F RID: 20095
		public int m_elementAmount;

		// Token: 0x04004E80 RID: 20096
		protected Vector2 m_elementDefaultSize;

		// Token: 0x04004E81 RID: 20097
		public float m_elementLayoutOffset;

		// Token: 0x04004E82 RID: 20098
		protected string m_elementName;

		// Token: 0x04004E83 RID: 20099
		protected List<ComUIListElementScript> m_elementScripts;

		// Token: 0x04004E84 RID: 20100
		public Vector2 m_elementPadding = default(Vector2);

		// Token: 0x04004E85 RID: 20101
		public Vector2 m_elementSpacing = default(Vector2);

		// Token: 0x04004E86 RID: 20102
		protected List<stRect> m_elementsRect;

		// Token: 0x04004E87 RID: 20103
		protected List<Vector2> m_elementsSize;

		// Token: 0x04004E88 RID: 20104
		protected GameObject m_elementTemplate;

		// Token: 0x04004E89 RID: 20105
		public string m_externalElementPrefabPath;

		// Token: 0x04004E8A RID: 20106
		public GameObject m_extraContent;

		// Token: 0x04004E8B RID: 20107
		public float m_fSpeed = 0.2f;

		// Token: 0x04004E8C RID: 20108
		protected Vector2 m_lastContentPosition;

		// Token: 0x04004E8D RID: 20109
		protected int m_lastSelectedElementIndex = -1;

		// Token: 0x04004E8E RID: 20110
		protected bool m_isInitialized;

		// Token: 0x04004E8F RID: 20111
		public ComUIListScript.enUIListType m_listType;

		// Token: 0x04004E90 RID: 20112
		[HideInInspector]
		public Vector2 m_scrollAreaSize;

		// Token: 0x04004E91 RID: 20113
		protected Scrollbar m_scrollBar;

		// Token: 0x04004E92 RID: 20114
		public bool m_scrollExternal;

		// Token: 0x04004E93 RID: 20115
		[HideInInspector]
		public ScrollRect m_scrollRect;

		// Token: 0x04004E94 RID: 20116
		[HideInInspector]
		public Vector2 m_scrollRectAreaMaxSize = new Vector2(100f, 100f);

		// Token: 0x04004E95 RID: 20117
		protected Vector2 m_scrollValue;

		// Token: 0x04004E96 RID: 20118
		protected int m_selectedElementIndex = -1;

		// Token: 0x04004E97 RID: 20119
		protected List<ComUIListElementScript> m_unUsedElementScripts;

		// Token: 0x04004E98 RID: 20120
		public bool m_useExternalElement;

		// Token: 0x04004E99 RID: 20121
		public bool m_useOptimized = true;

		// Token: 0x04004E9A RID: 20122
		public GameObject m_ZeroTipsObj;

		// Token: 0x02000F47 RID: 3911
		// (Invoke) Token: 0x0600983E RID: 38974
		public delegate object OnBindItemDelegate(GameObject itemObject);

		// Token: 0x02000F48 RID: 3912
		// (Invoke) Token: 0x06009842 RID: 38978
		public delegate void OnItemSelectedDelegate(ComUIListElementScript item);

		// Token: 0x02000F49 RID: 3913
		// (Invoke) Token: 0x06009846 RID: 38982
		public delegate void OnItemVisiableDelegate(ComUIListElementScript item);

		// Token: 0x02000F4A RID: 3914
		// (Invoke) Token: 0x0600984A RID: 38986
		public delegate void OnItemUpdateDelegate(ComUIListElementScript item);

		// Token: 0x02000F4B RID: 3915
		// (Invoke) Token: 0x0600984E RID: 38990
		public delegate void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected);

		// Token: 0x02000F4C RID: 3916
		// (Invoke) Token: 0x06009852 RID: 38994
		public delegate void OnItemRecycleDelegate(ComUIListElementScript item);

		// Token: 0x02000F4D RID: 3917
		public enum enUIListType
		{
			// Token: 0x04004E9C RID: 20124
			Vertical,
			// Token: 0x04004E9D RID: 20125
			Horizontal,
			// Token: 0x04004E9E RID: 20126
			VerticalGrid,
			// Token: 0x04004E9F RID: 20127
			HorizontalGrid
		}
	}
}
