using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F3D RID: 3901
	public class ComTwoLevelToggleGroup : MonoBehaviour, IDisposable
	{
		// Token: 0x060097CD RID: 38861 RVA: 0x001D1520 File Offset: 0x001CF920
		public void Init(List<ITwoLevelToggleData> parentToggleDatas, List<List<ITwoLevelToggleData>> subToggleDatas, ComTwoLevelToggleGroup.OnValueChanged onParentValueChanged, ComTwoLevelToggleGroup.OnValueChanged onSubValueChanged, uint defaultSelectParent = 0U, uint defaultSelectSub = 0U)
		{
			if (parentToggleDatas.Count != subToggleDatas.Count)
			{
				return;
			}
			this.Dispose();
			List<string> list = new List<string>(parentToggleDatas.Count);
			List<bool> list2 = new List<bool>(parentToggleDatas.Count);
			for (int i = 0; i < parentToggleDatas.Count; i++)
			{
				list.Add(parentToggleDatas[i].Name);
				list2.Add(parentToggleDatas[i].IsShowRedPoint);
			}
			for (int j = 0; j < subToggleDatas.Count; j++)
			{
				this.mSubToggleNames.Add(new List<string>(subToggleDatas[j].Count));
				this.mSubToggleSelectNames.Add(new List<string>(subToggleDatas[j].Count));
				this.mSubToggleRedPoint.Add(new List<bool>(subToggleDatas[j].Count));
				for (int k = 0; k < subToggleDatas[j].Count; k++)
				{
					this.mSubToggleNames[j].Add(subToggleDatas[j][k].Name);
					this.mSubToggleSelectNames[j].Add(subToggleDatas[j][k].SelectName);
					this.mSubToggleRedPoint[j].Add(subToggleDatas[j][k].IsShowRedPoint);
				}
				this.mSubToggleSelectId.Add(0U);
			}
			this.mOnParentValueChanged = onParentValueChanged;
			this.mOnSubValueChanged = onSubValueChanged;
			if ((ulong)defaultSelectParent < (ulong)((long)this.mSubToggleSelectId.Count))
			{
				this.mSubToggleSelectId[(int)defaultSelectParent] = defaultSelectSub;
			}
			if (this.mSubGroupLayout == ETwoLevelToggleGroupLayout.Horizontal)
			{
				this.mSubGroup = ComTabGroup.CreateHorizontal(this.mSubToggleGroupRoot, null, this.mSubTogglePrefabPath, new ComTabGroup.OnToggleValueChanged(this._OnParentToggleValueChanged), 0, null, null);
			}
			else
			{
				this.mSubGroup = ComTabGroup.CreateVertical(this.mSubToggleGroupRoot, null, this.mSubTogglePrefabPath, new ComTabGroup.OnToggleValueChanged(this._OnParentToggleValueChanged), 0, null, null);
			}
			if (this.mParentGroupLayout == ETwoLevelToggleGroupLayout.Horizontal)
			{
				this.mParentGroup = ComTabGroup.CreateHorizontal(this.mParentToggleGroupRoot, list.ToArray(), this.mParentTogglePrefabPath, new ComTabGroup.OnToggleValueChanged(this._OnParentToggleValueChanged), (int)defaultSelectParent, list2.ToArray(), null);
			}
			else
			{
				this.mParentGroup = ComTabGroup.CreateVertical(this.mParentToggleGroupRoot, list.ToArray(), this.mParentTogglePrefabPath, new ComTabGroup.OnToggleValueChanged(this._OnParentToggleValueChanged), (int)defaultSelectParent, list2.ToArray(), null);
			}
		}

		// Token: 0x060097CE RID: 38862 RVA: 0x001D17A0 File Offset: 0x001CFBA0
		public void SelectToggle(int parentId, int subId = -1)
		{
			if (this.mParentGroup != null)
			{
				this.mParentGroup.Select(parentId);
			}
			if (this.mSubGroup != null && subId != -1)
			{
				this.mSubGroup.Select(subId);
			}
		}

		// Token: 0x060097CF RID: 38863 RVA: 0x001D17EE File Offset: 0x001CFBEE
		public void SetParentRedPoint(int id, bool value)
		{
			if (this.mParentGroup != null)
			{
				this.mParentGroup.SetRedPoint(id, value);
			}
		}

		// Token: 0x060097D0 RID: 38864 RVA: 0x001D1810 File Offset: 0x001CFC10
		public void SetSubRedPoint(int parentId, int id, bool value)
		{
			if (this.mParentGroup != null && parentId == this.mParentGroup.SelectId && this.mSubGroup != null)
			{
				this.mSubGroup.SetRedPoint(id, value);
			}
			if (this.mSubToggleRedPoint != null && this.mParentGroup != null && parentId >= 0 && parentId < this.mSubToggleRedPoint.Count && id >= 0 && id < this.mSubToggleRedPoint[parentId].Count)
			{
				this.mSubToggleRedPoint[parentId][id] = value;
			}
		}

		// Token: 0x060097D1 RID: 38865 RVA: 0x001D18C2 File Offset: 0x001CFCC2
		public int GetParentToggleCount()
		{
			if (this.mParentGroup != null)
			{
				return this.mParentGroup.GetToggleCount();
			}
			return 0;
		}

		// Token: 0x060097D2 RID: 38866 RVA: 0x001D18E4 File Offset: 0x001CFCE4
		public void AddSubToggle(uint parentId, ITwoLevelToggleData data, int insertPosition = -1)
		{
			if ((ulong)parentId < (ulong)((long)this.mSubToggleNames.Count))
			{
				this.mSubToggleNames[(int)parentId].Insert((insertPosition < 0) ? (this.mSubToggleNames[(int)parentId].Count - 1) : insertPosition, data.Name);
			}
			if ((ulong)parentId < (ulong)((long)this.mSubToggleSelectNames.Count))
			{
				this.mSubToggleSelectNames[(int)parentId].Insert((insertPosition < 0) ? (this.mSubToggleSelectNames[(int)parentId].Count - 1) : insertPosition, data.Name);
			}
			if ((ulong)parentId < (ulong)((long)this.mSubToggleRedPoint.Count))
			{
				this.mSubToggleRedPoint[(int)parentId].Insert((insertPosition < 0) ? (this.mSubToggleRedPoint[(int)parentId].Count - 1) : insertPosition, data.IsShowRedPoint);
			}
			if (this.mParentGroup != null && (ulong)parentId == (ulong)((long)this.mParentGroup.SelectId) && this.mSubGroup != null)
			{
				this.mSubGroup.AddTap(data.Name, data.SelectName, this.mSubTogglePrefabPath, new ComTabGroup.OnToggleValueChanged(this._OnSubToggleValueChanged), data.IsShowRedPoint, insertPosition);
			}
		}

		// Token: 0x060097D3 RID: 38867 RVA: 0x001D1A34 File Offset: 0x001CFE34
		public void RemoveSubToggle(uint parentId, uint id)
		{
			if ((ulong)parentId < (ulong)((long)this.mSubToggleNames.Count) && (ulong)id < (ulong)((long)this.mSubToggleNames[(int)parentId].Count))
			{
				this.mSubToggleNames[(int)parentId].RemoveAt((int)id);
			}
			if ((ulong)parentId < (ulong)((long)this.mSubToggleRedPoint.Count) && (ulong)id < (ulong)((long)this.mSubToggleRedPoint[(int)parentId].Count))
			{
				this.mSubToggleRedPoint[(int)parentId].RemoveAt((int)id);
			}
			if ((ulong)parentId < (ulong)((long)this.mSubToggleSelectNames.Count) && (ulong)id < (ulong)((long)this.mSubToggleSelectNames[(int)parentId].Count))
			{
				this.mSubToggleSelectNames[(int)parentId].RemoveAt((int)id);
			}
			if (this.mParentGroup != null && (ulong)parentId == (ulong)((long)this.mParentGroup.SelectId) && this.mSubGroup != null)
			{
				this.mSubGroup.RemoveTap((int)id);
			}
		}

		// Token: 0x060097D4 RID: 38868 RVA: 0x001D1B3C File Offset: 0x001CFF3C
		public void AddParentToggle(List<ITwoLevelToggleData> subToggleDatas, ITwoLevelToggleData data, int insertPosition = -1)
		{
			if (insertPosition < 0 || insertPosition >= this.mSubToggleNames.Count)
			{
				this.mSubToggleNames.Add(new List<string>(subToggleDatas.Count));
				this.mSubToggleSelectNames.Add(new List<string>(subToggleDatas.Count));
				this.mSubToggleRedPoint.Add(new List<bool>(subToggleDatas.Count));
				this.mSubToggleSelectId.Add(0U);
			}
			else
			{
				this.mSubToggleNames.Insert(insertPosition, new List<string>(subToggleDatas.Count));
				this.mSubToggleSelectNames.Insert(insertPosition, new List<string>(subToggleDatas.Count));
				this.mSubToggleRedPoint.Insert(insertPosition, new List<bool>(subToggleDatas.Count));
				this.mSubToggleSelectId.Insert(insertPosition, 0U);
			}
			if (this.mSubToggleNames.Count == this.mSubToggleSelectNames.Count && this.mSubToggleNames.Count == this.mSubToggleRedPoint.Count)
			{
				for (int i = 0; i < subToggleDatas.Count; i++)
				{
					this.mSubToggleNames[i].Add(subToggleDatas[i].Name);
					this.mSubToggleSelectNames[i].Add(subToggleDatas[i].Name);
					this.mSubToggleRedPoint[i].Add(subToggleDatas[i].IsShowRedPoint);
				}
			}
			if (this.mParentGroup != null)
			{
				this.mParentGroup.AddTap(data.Name, data.SelectName, this.mParentTogglePrefabPath, new ComTabGroup.OnToggleValueChanged(this._OnParentToggleValueChanged), data.IsShowRedPoint, insertPosition);
			}
		}

		// Token: 0x060097D5 RID: 38869 RVA: 0x001D1CEC File Offset: 0x001D00EC
		public void RemoveParentToggle(int id)
		{
			if (this.mParentGroup != null)
			{
				if (this.mSubToggleNames != null && id >= 0 && id < this.mSubToggleNames.Count)
				{
					this.mSubToggleNames.RemoveAt(id);
				}
				if (this.mSubToggleSelectNames != null && id >= 0 && id < this.mSubToggleSelectNames.Count)
				{
					this.mSubToggleSelectNames.RemoveAt(id);
				}
				if (this.mSubToggleRedPoint != null && id >= 0 && id < this.mSubToggleRedPoint.Count)
				{
					this.mSubToggleRedPoint.RemoveAt(id);
				}
				this.mParentGroup.RemoveTap(id);
			}
		}

		// Token: 0x060097D6 RID: 38870 RVA: 0x001D1DA4 File Offset: 0x001D01A4
		public void SetParentGroupCanScroll(ScrollRect.MovementType movementType = 1)
		{
			if (this.mParentGroup == null)
			{
				return;
			}
			this._AddScrollRect(this.mParentGroup.gameObject, this.mParentToggleGroupRoot as RectTransform, this.mParentGroup.Content, this.mParentGroupLayout == ETwoLevelToggleGroupLayout.Horizontal, this.mParentGroupLayout == ETwoLevelToggleGroupLayout.Vertical, movementType);
		}

		// Token: 0x060097D7 RID: 38871 RVA: 0x001D1DFD File Offset: 0x001D01FD
		public void SetParentGroupCanScroll(bool isHorizontal, bool isVertical, ScrollRect.MovementType movementType = 1)
		{
			if (this.mParentGroup == null)
			{
				return;
			}
			this._AddScrollRect(this.mParentGroup.gameObject, this.mParentToggleGroupRoot as RectTransform, this.mParentGroup.Content, isHorizontal, isVertical, movementType);
		}

		// Token: 0x060097D8 RID: 38872 RVA: 0x001D1E3C File Offset: 0x001D023C
		public void SetSubGroupCanScroll(ScrollRect.MovementType movementType = 1)
		{
			if (this.mSubGroup == null)
			{
				return;
			}
			this._AddScrollRect(this.mSubGroup.gameObject, this.mSubToggleGroupRoot as RectTransform, this.mSubGroup.Content, this.mSubGroupLayout == ETwoLevelToggleGroupLayout.Horizontal, this.mSubGroupLayout == ETwoLevelToggleGroupLayout.Vertical, movementType);
		}

		// Token: 0x060097D9 RID: 38873 RVA: 0x001D1E95 File Offset: 0x001D0295
		public void SetSubGroupCanScroll(bool isHorizontal, bool isVertical, ScrollRect.MovementType movementType = 1)
		{
			if (this.mSubGroup == null)
			{
				return;
			}
			this._AddScrollRect(this.mSubGroup.gameObject, this.mSubToggleGroupRoot as RectTransform, this.mSubGroup.Content, isHorizontal, isVertical, movementType);
		}

		// Token: 0x060097DA RID: 38874 RVA: 0x001D1ED4 File Offset: 0x001D02D4
		private void _AddScrollRect(GameObject groupObject, RectTransform viewPort, RectTransform content, bool isHorizontal, bool isVertical, ScrollRect.MovementType movementType = 1)
		{
			if (groupObject == null)
			{
				return;
			}
			ScrollRect scrollRect = groupObject.gameObject.GetComponent<ScrollRect>();
			if (scrollRect == null)
			{
				scrollRect = groupObject.gameObject.AddComponent<ScrollRect>();
			}
			if (scrollRect != null)
			{
				scrollRect.viewport = viewPort;
				scrollRect.horizontal = isHorizontal;
				scrollRect.vertical = isVertical;
				scrollRect.movementType = movementType;
				scrollRect.content = content;
			}
		}

		// Token: 0x060097DB RID: 38875 RVA: 0x001D1F44 File Offset: 0x001D0344
		private void _OnParentToggleValueChanged(bool value, int selectId)
		{
			if (this.mOnParentValueChanged != null)
			{
				this.mOnParentValueChanged(selectId, value);
			}
			if (value && this.mSubGroup != null && this.mSubToggleNames != null && this.mSubToggleSelectNames != null && this.mSubToggleRedPoint != null && this.mSubToggleRedPoint.Count == this.mSubToggleNames.Count && this.mSubToggleNames.Count == this.mSubToggleSelectNames.Count && selectId >= 0 && selectId < this.mSubToggleNames.Count)
			{
				this.mSubGroup.Init(this.mSubToggleNames[selectId].ToArray(), this.mSubToggleRedPoint[selectId].ToArray(), this.mSubTogglePrefabPath, new ComTabGroup.OnToggleValueChanged(this._OnSubToggleValueChanged), this.mSubToggleSelectNames[selectId].ToArray(), (int)this.mSubToggleSelectId[selectId], null, null);
			}
		}

		// Token: 0x060097DC RID: 38876 RVA: 0x001D2050 File Offset: 0x001D0450
		private void _OnSubToggleValueChanged(bool value, int selectId)
		{
			if (this.mOnSubValueChanged != null)
			{
				this.mOnSubValueChanged(selectId, value);
			}
			if (value && this.mParentGroup != null && this.mSubToggleSelectId != null && this.mParentGroup.SelectId >= 0 && this.mParentGroup.SelectId < this.mSubToggleSelectId.Count)
			{
				this.mSubToggleSelectId[this.mParentGroup.SelectId] = (uint)selectId;
			}
		}

		// Token: 0x060097DD RID: 38877 RVA: 0x001D20DC File Offset: 0x001D04DC
		public void Dispose()
		{
			if (this.mParentGroup != null)
			{
				this.mParentGroup.Dispose();
			}
			if (this.mSubGroup != null)
			{
				this.mSubGroup.Dispose();
			}
			this.mSubToggleNames.Clear();
			this.mSubToggleSelectNames.Clear();
			this.mSubToggleRedPoint.Clear();
			this.mSubToggleSelectId.Clear();
			this.mOnSubValueChanged = null;
			this.mOnParentValueChanged = null;
		}

		// Token: 0x060097DE RID: 38878 RVA: 0x001D215B File Offset: 0x001D055B
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x04004E51 RID: 20049
		[SerializeField]
		private Transform mParentToggleGroupRoot;

		// Token: 0x04004E52 RID: 20050
		[SerializeField]
		private Transform mSubToggleGroupRoot;

		// Token: 0x04004E53 RID: 20051
		[Header("一级页签布局")]
		[SerializeField]
		private ETwoLevelToggleGroupLayout mParentGroupLayout;

		// Token: 0x04004E54 RID: 20052
		[Header("二级页签布局")]
		[SerializeField]
		private ETwoLevelToggleGroupLayout mSubGroupLayout;

		// Token: 0x04004E55 RID: 20053
		[Header("一级页签预制体路径")]
		[SerializeField]
		private string mParentTogglePrefabPath;

		// Token: 0x04004E56 RID: 20054
		[Header("二级页签预制体路径")]
		[SerializeField]
		private string mSubTogglePrefabPath;

		// Token: 0x04004E57 RID: 20055
		private ComTabGroup mParentGroup;

		// Token: 0x04004E58 RID: 20056
		private ComTabGroup mSubGroup;

		// Token: 0x04004E59 RID: 20057
		private ComTwoLevelToggleGroup.OnValueChanged mOnParentValueChanged;

		// Token: 0x04004E5A RID: 20058
		private ComTwoLevelToggleGroup.OnValueChanged mOnSubValueChanged;

		// Token: 0x04004E5B RID: 20059
		private readonly List<List<string>> mSubToggleNames = new List<List<string>>();

		// Token: 0x04004E5C RID: 20060
		private readonly List<List<string>> mSubToggleSelectNames = new List<List<string>>();

		// Token: 0x04004E5D RID: 20061
		private readonly List<List<bool>> mSubToggleRedPoint = new List<List<bool>>();

		// Token: 0x04004E5E RID: 20062
		private readonly List<uint> mSubToggleSelectId = new List<uint>();

		// Token: 0x02000F3E RID: 3902
		// (Invoke) Token: 0x060097E0 RID: 38880
		public delegate void OnValueChanged(int id, bool isOn);
	}
}
