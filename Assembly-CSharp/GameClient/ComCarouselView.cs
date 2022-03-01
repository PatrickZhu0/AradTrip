using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015A4 RID: 5540
	[RequireComponent(typeof(RectTransform))]
	[ExecuteInEditMode]
	public class ComCarouselView : UIBehaviour, IEventSystemHandler, IBeginDragHandler, IInitializePotentialDragHandler, IDragHandler, IEndDragHandler, ICanvasElement
	{
		// Token: 0x17001C27 RID: 7207
		// (get) Token: 0x0600D8A7 RID: 55463 RVA: 0x003636B8 File Offset: 0x00361AB8
		public int CurrentIndex
		{
			get
			{
				return this.m_index;
			}
		}

		// Token: 0x17001C28 RID: 7208
		// (get) Token: 0x0600D8A8 RID: 55464 RVA: 0x003636C0 File Offset: 0x00361AC0
		public int CellCount
		{
			get
			{
				if (this.mScrollViewGo)
				{
					return this.mScrollViewGo.transform.childCount;
				}
				return base.transform.childCount;
			}
		}

		// Token: 0x17001C29 RID: 7209
		// (get) Token: 0x0600D8A9 RID: 55465 RVA: 0x003636F0 File Offset: 0x00361AF0
		private float viewRectXMin
		{
			get
			{
				Vector3[] array = new Vector3[4];
				this.m_viewRectTran.GetWorldCorners(array);
				return array[0].x;
			}
		}

		// Token: 0x17001C2A RID: 7210
		// (get) Token: 0x0600D8AA RID: 55466 RVA: 0x0036371C File Offset: 0x00361B1C
		private float viewRectXMax
		{
			get
			{
				Vector3[] array = new Vector3[4];
				this.m_viewRectTran.GetWorldCorners(array);
				return array[3].x;
			}
		}

		// Token: 0x17001C2B RID: 7211
		// (get) Token: 0x0600D8AB RID: 55467 RVA: 0x00363748 File Offset: 0x00361B48
		private float viewRectYMin
		{
			get
			{
				Vector3[] array = new Vector3[4];
				this.m_viewRectTran.GetWorldCorners(array);
				return array[0].y;
			}
		}

		// Token: 0x17001C2C RID: 7212
		// (get) Token: 0x0600D8AC RID: 55468 RVA: 0x00363774 File Offset: 0x00361B74
		private float viewRectYMax
		{
			get
			{
				Vector3[] array = new Vector3[4];
				this.m_viewRectTran.GetWorldCorners(array);
				return array[2].y;
			}
		}

		// Token: 0x0600D8AD RID: 55469 RVA: 0x003637A0 File Offset: 0x00361BA0
		protected override void Awake()
		{
			base.Awake();
			if (this.mScrollViewGo != null)
			{
				this.m_viewRectTran = this.mScrollViewGo.GetComponent<RectTransform>();
			}
			else
			{
				this.m_viewRectTran = base.GetComponent<RectTransform>();
			}
			this._Initialize();
		}

		// Token: 0x0600D8AE RID: 55470 RVA: 0x003637EC File Offset: 0x00361BEC
		protected virtual void Update()
		{
			if (!this.m_isInitChildCell)
			{
				return;
			}
			if (this.ContentIsLongerThanRect())
			{
				if (Application.isPlaying)
				{
					ComCarouselView.Direction boundaryState = this.GetBoundaryState();
					this._LoopCell(boundaryState);
				}
				if (this.m_isNormalizing && this.EnsureListCanAdjust())
				{
					if (this.m_currentStep == this.mTweenStepCount)
					{
						this.m_isNormalizing = false;
						this.m_currentStep = 0;
						this.m_currentPos = Vector2.zero;
						return;
					}
					if (this.mTweenStepCount != 0)
					{
						Vector2 vector = this.m_currentPos / (float)this.mTweenStepCount;
						this.m_currentStep++;
						this._TweenToCorrect(-vector);
					}
				}
				if (this.mAutoLoop && !this.m_isNormalizing && this.EnsureListCanAdjust())
				{
					this.m_currTimeDelta += Time.deltaTime;
					if (this.m_currTimeDelta > this.mLoopSpace)
					{
						this.m_currTimeDelta = 0f;
						this.MoveToIndex((int)(this.m_index + this.mLoopDir));
					}
				}
				if (this.mMoveAxis == ComCarouselView.Axis.Horizontal)
				{
					this.m_cellSizeXAndSpaceX = this.mCellSize.x + this.mSpacing.x - 1f;
					if (this.m_cellSizeXAndSpaceX != 0f)
					{
						this.m_index = (int)(this.m_Header.localPosition.x / this.m_cellSizeXAndSpaceX);
					}
				}
				else
				{
					this.m_cellSizeYAndSpaceY = this.mCellSize.y + this.mSpacing.y - 1f;
					if (this.m_cellSizeYAndSpaceY != 0f)
					{
						this.m_index = (int)(this.m_Header.localPosition.y / this.m_cellSizeYAndSpaceY);
					}
				}
				if (this.m_index <= 0)
				{
					this.m_index = Mathf.Abs(this.m_index);
				}
				else
				{
					this.m_index = this.CellCount - this.m_index;
				}
				if (this.m_index != this.m_preIndex && this.onIndexChange != null)
				{
					this.onIndexChange(this.m_index);
				}
				this.m_preIndex = this.m_index;
			}
		}

		// Token: 0x0600D8AF RID: 55471 RVA: 0x00363A29 File Offset: 0x00361E29
		protected override void OnDestroy()
		{
			base.OnDestroy();
			this._UnInitialize();
		}

		// Token: 0x0600D8B0 RID: 55472 RVA: 0x00363A38 File Offset: 0x00361E38
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
			if (!this.mDrag || !this.m_contentCheckCache)
			{
				return;
			}
			Vector2 prePos;
			if (eventData.button == null && this.IsActive() && RectTransformUtility.ScreenPointToLocalPointInRectangle(this.m_viewRectTran, eventData.position, eventData.pressEventCamera, ref prePos))
			{
				this.m_dragging = true;
				this.m_prePos = prePos;
				this.m_currTimeDelta = 0f;
			}
		}

		// Token: 0x0600D8B1 RID: 55473 RVA: 0x00363AA9 File Offset: 0x00361EA9
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
			if (!this.mDrag)
			{
				return;
			}
		}

		// Token: 0x0600D8B2 RID: 55474 RVA: 0x00363AB8 File Offset: 0x00361EB8
		public virtual void OnDrag(PointerEventData eventData)
		{
			if (!this.mDrag || !this.m_contentCheckCache)
			{
				return;
			}
			Vector2 vector;
			if (eventData.button == null && this.IsActive() && RectTransformUtility.ScreenPointToLocalPointInRectangle(this.m_viewRectTran, eventData.position, eventData.pressEventCamera, ref vector))
			{
				this.m_isNormalizing = false;
				this.m_currentPos = Vector2.zero;
				this.m_currentStep = 0;
				Vector2 delta = vector - this.m_prePos;
				Vector2 position = this._CalculateOffset(delta);
				this._SetContentPosition(position);
				this.m_prePos = vector;
			}
		}

		// Token: 0x0600D8B3 RID: 55475 RVA: 0x00363B4C File Offset: 0x00361F4C
		public virtual void OnEndDrag(PointerEventData eventData)
		{
			if (!this.mDrag || !this.m_contentCheckCache)
			{
				return;
			}
			this.m_dragging = false;
			this.m_isNormalizing = true;
			this.m_currentPos = this.CalcCorrectDeltaPos();
			this.m_currentStep = 0;
		}

		// Token: 0x0600D8B4 RID: 55476 RVA: 0x00363B86 File Offset: 0x00361F86
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		// Token: 0x0600D8B5 RID: 55477 RVA: 0x00363B88 File Offset: 0x00361F88
		public void LayoutComplete()
		{
		}

		// Token: 0x0600D8B6 RID: 55478 RVA: 0x00363B8A File Offset: 0x00361F8A
		public void GraphicUpdateComplete()
		{
		}

		// Token: 0x0600D8B7 RID: 55479 RVA: 0x00363B8C File Offset: 0x00361F8C
		private void _Initialize()
		{
			if (this.m_viewRectTran)
			{
				this.m_Header = this._GetChild(this.m_viewRectTran, 0);
			}
			if (this.mZeroShowGo)
			{
				this.mZeroShowGo.CustomActive(false);
			}
		}

		// Token: 0x0600D8B8 RID: 55480 RVA: 0x00363BD8 File Offset: 0x00361FD8
		private void _UnInitialize()
		{
			this.onIndexChange = null;
			this.onBindItem = null;
			this.onItemCreate = null;
			if (this.m_initializeCellList != null)
			{
				this.m_initializeCellList.Clear();
			}
			this.m_isInitChildCell = false;
		}

		// Token: 0x0600D8B9 RID: 55481 RVA: 0x00363C0C File Offset: 0x0036200C
		private Vector2 _CalculateOffset(Vector2 delta)
		{
			if (this.mMoveAxis == ComCarouselView.Axis.Horizontal)
			{
				delta.y = 0f;
			}
			else
			{
				delta.x = 0f;
			}
			return delta;
		}

		// Token: 0x0600D8BA RID: 55482 RVA: 0x00363C38 File Offset: 0x00362038
		private void _SetContentPosition(Vector2 position)
		{
			IEnumerator enumerator = this.m_viewRectTran.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					RectTransform rectTransform = (RectTransform)obj;
					rectTransform.localPosition += position;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}

		// Token: 0x0600D8BB RID: 55483 RVA: 0x00363CB0 File Offset: 0x003620B0
		private void _LoopCell(ComCarouselView.Direction dir)
		{
			if (dir == ComCarouselView.Direction.None)
			{
				return;
			}
			RectTransform rectTransform;
			RectTransform rectTransform2;
			if (dir == ComCarouselView.Direction.LeftOrDown)
			{
				rectTransform = this._GetChild(this.m_viewRectTran, 0);
				rectTransform2 = this._GetChild(this.m_viewRectTran, this.CellCount - 1);
				rectTransform.SetSiblingIndex(this.CellCount - 1);
			}
			else
			{
				rectTransform2 = this._GetChild(this.m_viewRectTran, 0);
				rectTransform = this._GetChild(this.m_viewRectTran, this.CellCount - 1);
				rectTransform.SetSiblingIndex(0);
			}
			Vector2 vector;
			if (this.mMoveAxis == ComCarouselView.Axis.Horizontal)
			{
				vector = rectTransform2.localPosition + new Vector3((this.mCellSize.x + this.mSpacing.x) * (float)dir, 0f, 0f);
			}
			else
			{
				vector = rectTransform2.localPosition + new Vector2(0f, (this.mCellSize.y + this.mSpacing.y) * (float)dir);
			}
			rectTransform.localPosition = vector;
		}

		// Token: 0x0600D8BC RID: 55484 RVA: 0x00363DB8 File Offset: 0x003621B8
		private void _TweenToCorrect(Vector2 delta)
		{
			IEnumerator enumerator = this.m_viewRectTran.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					RectTransform rectTransform = (RectTransform)obj;
					rectTransform.localPosition += delta;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
		}

		// Token: 0x0600D8BD RID: 55485 RVA: 0x00363E30 File Offset: 0x00362230
		private RectTransform _GetChild(RectTransform parent, int index)
		{
			if (parent == null || index >= parent.childCount)
			{
				return null;
			}
			return parent.GetChild(index) as RectTransform;
		}

		// Token: 0x0600D8BE RID: 55486 RVA: 0x00363E58 File Offset: 0x00362258
		private GameObject _InstantiateCell(GameObject srcGameObject)
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

		// Token: 0x0600D8BF RID: 55487 RVA: 0x00363F14 File Offset: 0x00362314
		private void _ResizeChildren()
		{
			Vector2 vector;
			if (this.mMoveAxis == ComCarouselView.Axis.Horizontal)
			{
				vector..ctor(this.mCellSize.x + this.mSpacing.x, 0f);
			}
			else
			{
				vector..ctor(0f, this.mCellSize.y + this.mSpacing.y);
			}
			for (int i = 0; i < this.CellCount; i++)
			{
				RectTransform rectTransform = this._GetChild(this.m_viewRectTran, i);
				if (rectTransform)
				{
					rectTransform.localPosition = vector * (float)i;
					rectTransform.sizeDelta = this.mCellSize;
				}
			}
			this.m_isNormalizing = false;
			this.m_currentPos = Vector2.zero;
			this.m_currentStep = 0;
		}

		// Token: 0x0600D8C0 RID: 55488 RVA: 0x00363FE0 File Offset: 0x003623E0
		public void SetCellAmount(int amount)
		{
			if (this.m_isInitChildCell)
			{
				return;
			}
			if (this.m_Header == null)
			{
				return;
			}
			if (amount <= 0)
			{
				if (this.mZeroShowGo)
				{
					this.mZeroShowGo.CustomActive(true);
					this.mZeroShowGo.transform.SetAsLastSibling();
				}
				this.m_Header.gameObject.CustomActive(false);
			}
			else
			{
				this.m_Header.gameObject.CustomActive(true);
			}
			string name = this.m_Header.name;
			for (int i = 0; i < amount; i++)
			{
				GameObject gameObject;
				if (i == 0)
				{
					gameObject = this.m_Header.gameObject;
				}
				else
				{
					gameObject = this._InstantiateCell(this.m_Header.gameObject);
				}
				if (!(gameObject == null))
				{
					ComCarouselCell component = gameObject.GetComponent<ComCarouselCell>();
					if (!(component == null))
					{
						if (this.m_initializeCellList != null)
						{
							this.m_initializeCellList.Add(component);
						}
					}
				}
			}
			for (int j = 0; j < this.m_initializeCellList.Count; j++)
			{
				ComCarouselCell comCarouselCell = this.m_initializeCellList[j];
				if (!(comCarouselCell == null))
				{
					RectTransform component2 = comCarouselCell.GetComponent<RectTransform>();
					comCarouselCell.Init(j, component2, name);
					if (this.onBindItem != null)
					{
						comCarouselCell.BindScript = this.onBindItem(comCarouselCell.gameObject);
					}
					if (this.onItemCreate != null)
					{
						this.onItemCreate(comCarouselCell);
					}
				}
			}
			this._ResizeChildren();
			this.m_isInitChildCell = true;
		}

		// Token: 0x0600D8C1 RID: 55489 RVA: 0x0036418D File Offset: 0x0036258D
		public bool EnsureListCanAdjust()
		{
			return !this.m_dragging && this.ContentIsLongerThanRect();
		}

		// Token: 0x0600D8C2 RID: 55490 RVA: 0x003641A4 File Offset: 0x003625A4
		public bool ContentIsLongerThanRect()
		{
			float num;
			float num2;
			if (this.mMoveAxis == ComCarouselView.Axis.Horizontal)
			{
				num = (float)this.CellCount * (this.mCellSize.x + this.mSpacing.x) - this.mSpacing.x;
				num2 = this.m_viewRectTran.rect.xMax - this.m_viewRectTran.rect.xMin;
			}
			else
			{
				num = (float)this.CellCount * (this.mCellSize.y + this.mSpacing.y) - this.mSpacing.y;
				num2 = this.m_viewRectTran.rect.yMax - this.m_viewRectTran.rect.yMin;
			}
			this.m_contentCheckCache = (num > num2);
			return this.m_contentCheckCache;
		}

		// Token: 0x0600D8C3 RID: 55491 RVA: 0x0036427C File Offset: 0x0036267C
		public ComCarouselView.Direction GetBoundaryState()
		{
			RectTransform rectTransform = this._GetChild(this.m_viewRectTran, 0);
			RectTransform rectTransform2 = this._GetChild(this.m_viewRectTran, this.CellCount - 1);
			Vector3[] array = new Vector3[4];
			rectTransform.GetWorldCorners(array);
			Vector3[] array2 = new Vector3[4];
			rectTransform2.GetWorldCorners(array2);
			if (this.mMoveAxis == ComCarouselView.Axis.Horizontal)
			{
				if (array[0].x >= this.viewRectXMin)
				{
					return ComCarouselView.Direction.RightOrUp;
				}
				if (array2[3].x < this.viewRectXMax)
				{
					return ComCarouselView.Direction.LeftOrDown;
				}
			}
			else
			{
				if (array[0].y >= this.viewRectYMin)
				{
					return ComCarouselView.Direction.RightOrUp;
				}
				if (array2[1].y < this.viewRectYMax)
				{
					return ComCarouselView.Direction.LeftOrDown;
				}
			}
			return ComCarouselView.Direction.None;
		}

		// Token: 0x0600D8C4 RID: 55492 RVA: 0x00364340 File Offset: 0x00362740
		public Vector2 CalcCorrectDeltaPos()
		{
			Vector2 result = Vector2.zero;
			float num = float.MaxValue;
			IEnumerator enumerator = this.m_viewRectTran.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					RectTransform rectTransform = (RectTransform)obj;
					float num2 = Mathf.Abs(rectTransform.localPosition.x) + Mathf.Abs(rectTransform.localPosition.y);
					if (num2 > num * this.mDragSensitivity)
					{
						break;
					}
					num = num2;
					result = rectTransform.localPosition;
				}
			}
			finally
			{
				IDisposable disposable;
				if ((disposable = (enumerator as IDisposable)) != null)
				{
					disposable.Dispose();
				}
			}
			return result;
		}

		// Token: 0x0600D8C5 RID: 55493 RVA: 0x00364400 File Offset: 0x00362800
		public void AddChildInTheEnd(RectTransform t)
		{
			if (t != null)
			{
				t.SetParent(this.m_viewRectTran, false);
				t.SetAsLastSibling();
				Vector2 vector;
				if (this.mMoveAxis == ComCarouselView.Axis.Horizontal)
				{
					vector..ctor(this.mCellSize.x + this.mSpacing.x, 0f);
				}
				else
				{
					vector..ctor(0f, this.mCellSize.y + this.mSpacing.y);
				}
				if (this.CellCount == 0)
				{
					t.localPosition = Vector3.zero;
					this.m_Header = t;
				}
				else
				{
					t.localPosition = vector + this._GetChild(this.m_viewRectTran, this.CellCount - 1).localPosition;
				}
			}
		}

		// Token: 0x0600D8C6 RID: 55494 RVA: 0x003644D4 File Offset: 0x003628D4
		public void MoveToIndex(int ind)
		{
			if (this.m_isNormalizing)
			{
				return;
			}
			if (ind == this.m_index)
			{
				return;
			}
			if (ind >= this.CellCount)
			{
				return;
			}
			this.m_isNormalizing = true;
			Vector2 vector;
			if (this.mMoveAxis == ComCarouselView.Axis.Horizontal)
			{
				vector..ctor(this.mCellSize.x + this.mSpacing.x, 0f);
			}
			else
			{
				vector..ctor(0f, this.mCellSize.y + this.mSpacing.y);
			}
			Vector2 vector2 = this.CalcCorrectDeltaPos();
			int index = this.m_index;
			this.m_currentPos = vector2 + vector * (float)(ind - index);
			this.m_currentStep = 0;
		}

		// Token: 0x0600D8C7 RID: 55495 RVA: 0x0036458F File Offset: 0x0036298F
		Transform ICanvasElement.get_transform()
		{
			return base.transform;
		}

		// Token: 0x0600D8C8 RID: 55496 RVA: 0x00364597 File Offset: 0x00362997
		bool ICanvasElement.IsDestroyed()
		{
			return base.IsDestroyed();
		}

		// Token: 0x04007F44 RID: 32580
		[HideInInspector]
		public ComCarouselView.OnBindItemDelegate onBindItem;

		// Token: 0x04007F45 RID: 32581
		[HideInInspector]
		public ComCarouselView.OnItemCreateDelegate onItemCreate;

		// Token: 0x04007F46 RID: 32582
		[HideInInspector]
		public ComCarouselView.OnItemIndexChange onIndexChange;

		// Token: 0x04007F47 RID: 32583
		[SerializeField]
		[Header("滚动的子节点的根节点，即滚动窗口")]
		private GameObject mScrollViewGo;

		// Token: 0x04007F48 RID: 32584
		[SerializeField]
		[Header("滚动的子节点的尺寸，一般设为和其根节点尺寸一致")]
		private Vector2 mCellSize;

		// Token: 0x04007F49 RID: 32585
		[SerializeField]
		[Header("滚动的子节点的间隔")]
		private Vector2 mSpacing;

		// Token: 0x04007F4A RID: 32586
		[SerializeField]
		[Header("滚动动画的方向")]
		private ComCarouselView.Axis mMoveAxis;

		// Token: 0x04007F4B RID: 32587
		[SerializeField]
		[Header("滚动动画的步数，步数越大，滚动越慢")]
		private int mTweenStepCount = 10;

		// Token: 0x04007F4C RID: 32588
		[SerializeField]
		[Header("滚动动画是否自动轮播")]
		private bool mAutoLoop;

		// Token: 0x04007F4D RID: 32589
		[SerializeField]
		[Header("滚动动画自动轮播的时间间隔，单位秒")]
		private float mLoopSpace = 1f;

		// Token: 0x04007F4E RID: 32590
		[SerializeField]
		[Header("滚动动画自动轮播的方向，向右或者向上，向左或者向下")]
		private ComCarouselView.Direction mLoopDir;

		// Token: 0x04007F4F RID: 32591
		[SerializeField]
		[Header("滚动子节点是否可以拖拽")]
		private bool mDrag = true;

		// Token: 0x04007F50 RID: 32592
		[SerializeField]
		private GameObject mZeroShowGo;

		// Token: 0x04007F51 RID: 32593
		[SerializeField]
		[Header("拖动灵敏度，值越大，灵敏度越大")]
		[Range(1f, 5f)]
		private float mDragSensitivity = 1f;

		// Token: 0x04007F52 RID: 32594
		private bool m_dragging;

		// Token: 0x04007F53 RID: 32595
		private bool m_isNormalizing;

		// Token: 0x04007F54 RID: 32596
		private Vector2 m_currentPos;

		// Token: 0x04007F55 RID: 32597
		private int m_currentStep;

		// Token: 0x04007F56 RID: 32598
		private RectTransform m_viewRectTran;

		// Token: 0x04007F57 RID: 32599
		private Vector2 m_prePos;

		// Token: 0x04007F58 RID: 32600
		private int m_index;

		// Token: 0x04007F59 RID: 32601
		private int m_preIndex;

		// Token: 0x04007F5A RID: 32602
		private RectTransform m_Header;

		// Token: 0x04007F5B RID: 32603
		private bool m_contentCheckCache = true;

		// Token: 0x04007F5C RID: 32604
		private List<ComCarouselCell> m_initializeCellList = new List<ComCarouselCell>();

		// Token: 0x04007F5D RID: 32605
		private bool m_isInitChildCell;

		// Token: 0x04007F5E RID: 32606
		private float m_currTimeDelta;

		// Token: 0x04007F5F RID: 32607
		private float m_cellSizeXAndSpaceX;

		// Token: 0x04007F60 RID: 32608
		private float m_cellSizeYAndSpaceY;

		// Token: 0x020015A5 RID: 5541
		public enum Axis
		{
			// Token: 0x04007F62 RID: 32610
			Horizontal,
			// Token: 0x04007F63 RID: 32611
			Vertical
		}

		// Token: 0x020015A6 RID: 5542
		public enum Direction
		{
			// Token: 0x04007F65 RID: 32613
			RightOrUp = -1,
			// Token: 0x04007F66 RID: 32614
			None,
			// Token: 0x04007F67 RID: 32615
			LeftOrDown
		}

		// Token: 0x020015A7 RID: 5543
		// (Invoke) Token: 0x0600D8CA RID: 55498
		public delegate object OnBindItemDelegate(GameObject itemObject);

		// Token: 0x020015A8 RID: 5544
		// (Invoke) Token: 0x0600D8CE RID: 55502
		public delegate void OnItemCreateDelegate(ComCarouselCell item);

		// Token: 0x020015A9 RID: 5545
		// (Invoke) Token: 0x0600D8D2 RID: 55506
		public delegate void OnItemIndexChange(int index);
	}
}
