using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F17 RID: 3863
	[RequireComponent(typeof(ToggleGroup))]
	public sealed class ComTabGroup : MonoBehaviour, IDisposable
	{
		// Token: 0x1700191C RID: 6428
		// (get) Token: 0x060096B3 RID: 38579 RVA: 0x001CB688 File Offset: 0x001C9A88
		public int SelectId
		{
			get
			{
				return this.mSelectedId;
			}
		}

		// Token: 0x1700191D RID: 6429
		// (get) Token: 0x060096B4 RID: 38580 RVA: 0x001CB690 File Offset: 0x001C9A90
		public RectTransform Content
		{
			get
			{
				return this.mToggleRoot;
			}
		}

		// Token: 0x060096B5 RID: 38581 RVA: 0x001CB698 File Offset: 0x001C9A98
		public static ComTabGroup CreateHorizontal(Transform parent, string[] toggleNames, string togglePrefabPath, ComTabGroup.OnToggleValueChanged onToggleValueChanged, int defaultSelectId = 0, bool[] isShowRedPoints = null, string[] selectedNames = null)
		{
			return ComTabGroup.Create("UIFlatten/Prefabs/Common/ComHorizontalTabGroup", parent, toggleNames, togglePrefabPath, onToggleValueChanged, defaultSelectId, isShowRedPoints, selectedNames);
		}

		// Token: 0x060096B6 RID: 38582 RVA: 0x001CB6AE File Offset: 0x001C9AAE
		public static ComTabGroup CreateVertical(Transform parent, string[] toggleNames, string togglePrefabPath, ComTabGroup.OnToggleValueChanged onToggleValueChanged, int defaultSelectId = 0, bool[] isShowRedPoints = null, string[] selectedNames = null)
		{
			return ComTabGroup.Create("UIFlatten/Prefabs/Common/ComVerticalTabGroup", parent, toggleNames, togglePrefabPath, onToggleValueChanged, defaultSelectId, isShowRedPoints, selectedNames);
		}

		// Token: 0x060096B7 RID: 38583 RVA: 0x001CB6C4 File Offset: 0x001C9AC4
		private static ComTabGroup Create(string prefabPath, Transform parent, string[] toggleNames, string togglePrefabPath, ComTabGroup.OnToggleValueChanged onToggleValueChanged, int defaultSelectId = 0, bool[] isShowRedPoints = null, string[] selectedNames = null)
		{
			if (parent == null)
			{
				Logger.LogError("Create ComTapGroup failed, parent is null");
				return null;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(prefabPath, true, 0U);
			if (!(gameObject != null))
			{
				Logger.LogError("LoadResAsGameObject ComTapGroup failed");
				return null;
			}
			ComTabGroup component = gameObject.GetComponent<ComTabGroup>();
			if (component == null)
			{
				Debug.LogError("Can't get scripte <ComTapGroup> from prefab!");
				return null;
			}
			gameObject.transform.SetParent(parent, false);
			if (isShowRedPoints != null)
			{
				component.Init(toggleNames, isShowRedPoints, togglePrefabPath, onToggleValueChanged, selectedNames, defaultSelectId, null, null);
			}
			else
			{
				component.Init(toggleNames, togglePrefabPath, onToggleValueChanged, selectedNames, defaultSelectId, null, null);
			}
			return component;
		}

		// Token: 0x060096B8 RID: 38584 RVA: 0x001CB76C File Offset: 0x001C9B6C
		public void Init(string[] toggleNames, string togglePrefabPath, ComTabGroup.OnToggleValueChanged onToggleValueChanged, string[] selectedNames = null, int defaultSelectId = 0, string selectedImagePath = null, string unSelectedImagePath = null)
		{
			if (this.mToggleGroup == null)
			{
				this.mToggleGroup = base.GetComponent<ToggleGroup>();
			}
			this.Dispose();
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(togglePrefabPath, true, 0U);
			if (gameObject == null)
			{
				Logger.LogError("加载预制体失败,路径:" + togglePrefabPath);
			}
			Toggle toggle = gameObject.GetComponent<Toggle>();
			if (toggle == null)
			{
				toggle = base.GetComponentInChildren<Toggle>();
				if (toggle == null)
				{
					Logger.LogError("Can't find Toggle in togglePrefab ");
					return;
				}
			}
			if (!string.IsNullOrEmpty(selectedImagePath))
			{
				Image image = toggle.graphic as Image;
				ETCImageLoader.LoadSprite(ref image, selectedImagePath, true);
			}
			if (!string.IsNullOrEmpty(unSelectedImagePath))
			{
				Image image2 = toggle.targetGraphic as Image;
				ETCImageLoader.LoadSprite(ref image2, unSelectedImagePath, true);
			}
			this.mOnToggleValueChanged = onToggleValueChanged;
			if (toggleNames != null)
			{
				for (int i = 0; i < toggleNames.Length; i++)
				{
					GameObject toggleGameObject = Object.Instantiate<GameObject>(gameObject);
					string selectedName = null;
					if (selectedNames != null && i >= 0 && i < selectedNames.Length)
					{
						selectedName = selectedNames[i];
					}
					this._AddToggle(toggleNames[i], selectedName, toggleGameObject, i);
				}
				if (defaultSelectId >= 0 && this.mToggles.Count > defaultSelectId)
				{
					this.mSelectedId = defaultSelectId;
					this.mToggles[defaultSelectId].isOn = true;
				}
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x060096B9 RID: 38585 RVA: 0x001CB8DC File Offset: 0x001C9CDC
		public void Init(string[] toggleNames, bool[] isShowRedPoints, string togglePrefabPath, ComTabGroup.OnToggleValueChanged onToggleValueChanged, string[] selectedNames = null, int defaultSelectId = 0, string selectedImagePath = null, string unSelectedImagePath = null)
		{
			this._ClearToggles();
			this.Init(toggleNames, togglePrefabPath, onToggleValueChanged, selectedNames, -1, selectedImagePath, unSelectedImagePath);
			if (isShowRedPoints != null)
			{
				if (toggleNames.Length != isShowRedPoints.Length)
				{
					Logger.LogError("toggle数量和红点数组数量不一致");
				}
				for (int i = 0; i < isShowRedPoints.Length; i++)
				{
					this.SetRedPoint(i, isShowRedPoints[i]);
				}
			}
			this.Select(defaultSelectId);
		}

		// Token: 0x060096BA RID: 38586 RVA: 0x001CB941 File Offset: 0x001C9D41
		public void Select(int id)
		{
			if (id >= 0 && this.mToggles.Count > id)
			{
				this.mSelectedId = id;
				this.mToggles[id].isOn = true;
			}
		}

		// Token: 0x060096BB RID: 38587 RVA: 0x001CB974 File Offset: 0x001C9D74
		public void SetRedPoint(int id, bool value)
		{
			if (id >= 0 && id < this.mToggles.Count)
			{
				IRedPointToggle component = this.mToggles[id].GetComponent<IRedPointToggle>();
				if (component != null)
				{
					component.SetRedPointActive(value);
				}
			}
		}

		// Token: 0x060096BC RID: 38588 RVA: 0x001CB9B8 File Offset: 0x001C9DB8
		public void SetSelectOutLineColor(Color color)
		{
			for (int i = 0; i < this.mToggles.Count; i++)
			{
				IOutLineToggle component = this.mToggles[i].GetComponent<IOutLineToggle>();
				if (component != null)
				{
					component.SetSelectOutLineColor(color);
				}
			}
		}

		// Token: 0x060096BD RID: 38589 RVA: 0x001CBA00 File Offset: 0x001C9E00
		public int GetToggleCount()
		{
			if (this.mToggles != null)
			{
				return this.mToggles.Count;
			}
			return 0;
		}

		// Token: 0x060096BE RID: 38590 RVA: 0x001CBA1C File Offset: 0x001C9E1C
		public void AddTap(string name, string selectedName, string togglePrefabPath, ComTabGroup.OnToggleValueChanged onToggleValueChanged, bool isShowRedPoint = false, int siblingIndex = -1)
		{
			GameObject toggleGameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(togglePrefabPath, true, 0U);
			this.mOnToggleValueChanged = onToggleValueChanged;
			this._AddToggle(name, selectedName, toggleGameObject, siblingIndex);
			this.SetRedPoint(siblingIndex, isShowRedPoint);
		}

		// Token: 0x060096BF RID: 38591 RVA: 0x001CBA54 File Offset: 0x001C9E54
		public void RemoveTap(int siblingIndex)
		{
			if (siblingIndex < 0 || siblingIndex >= this.mToggles.Count)
			{
				Logger.LogError("错误的id");
			}
			Toggle toggle = this.mToggles[siblingIndex];
			for (int i = siblingIndex + 1; i < this.mToggles.Count; i++)
			{
				this.mToggles[i].onValueChanged.RemoveAllListeners();
				IComTabToggle component = this.mToggles[i].GetComponent<IComTabToggle>();
				if (component != null)
				{
					component.BindEvent();
				}
				this.mToggles[i].SafeAddOnValueChangedListener(this._ToggleListener(i - 1));
			}
			this.mToggles[siblingIndex].onValueChanged.RemoveAllListeners();
			if (this.mSelectedId == siblingIndex)
			{
				toggle.group = null;
				toggle.isOn = false;
				if (siblingIndex + 1 < this.mToggles.Count)
				{
					this.mToggles[siblingIndex + 1].isOn = true;
				}
				else if (siblingIndex - 1 >= 0)
				{
					this.mToggles[siblingIndex - 1].isOn = true;
					this.mSelectedId--;
				}
				else
				{
					this.mSelectedId = 0;
				}
			}
			else if (this.mSelectedId > siblingIndex)
			{
				this.mSelectedId--;
			}
			this.mToggles.RemoveAt(siblingIndex);
			Object.Destroy(toggle.gameObject);
		}

		// Token: 0x060096C0 RID: 38592 RVA: 0x001CBBC8 File Offset: 0x001C9FC8
		private void _AddToggle(string toggleName, string selectedName, GameObject toggleGameObject, int index)
		{
			if (toggleGameObject == null)
			{
				Logger.LogError("toggle prefab load failed");
				return;
			}
			Toggle component = toggleGameObject.GetComponent<Toggle>();
			component.group = this.mToggleGroup;
			component.transform.SetParent(this.mToggleRoot, false);
			component.transform.SetSiblingIndex(index);
			component.onValueChanged.RemoveAllListeners();
			if (this.mSelectedId >= index)
			{
				this.mSelectedId++;
			}
			if (index < 0 || index >= this.mToggles.Count)
			{
				this.mToggles.Add(component);
				component.SafeAddOnValueChangedListener(this._ToggleListener(this.mToggles.Count - 1));
			}
			else
			{
				this.mToggles.Insert(index, component);
				component.SafeAddOnValueChangedListener(this._ToggleListener(index));
				for (int i = index + 1; i < this.mToggles.Count; i++)
				{
					this.mToggles[i].onValueChanged.RemoveAllListeners();
					IComTabToggle component2 = this.mToggles[i].GetComponent<IComTabToggle>();
					if (component2 != null)
					{
						component2.BindEvent();
					}
					this.mToggles[i].SafeAddOnValueChangedListener(this._ToggleListener(i));
				}
			}
			ISetNameToggle component3 = toggleGameObject.GetComponent<ISetNameToggle>();
			if (component3 != null)
			{
				component3.SetName(toggleName, selectedName);
			}
			else
			{
				Text componentInChildren = component.GetComponentInChildren<Text>();
				if (componentInChildren != null)
				{
					componentInChildren.text = toggleName;
				}
			}
			IComTabToggle component4 = component.GetComponent<IComTabToggle>();
			if (component4 != null)
			{
				component4.Init();
			}
		}

		// Token: 0x060096C1 RID: 38593 RVA: 0x001CBD5C File Offset: 0x001CA15C
		private void _ClearToggles()
		{
			for (int i = this.mToggles.Count - 1; i >= 0; i--)
			{
				this.mToggles[i].onValueChanged.RemoveAllListeners();
				Object.Destroy(this.mToggles[i].gameObject);
			}
			this.mToggles.Clear();
			this.mSelectedId = 0;
		}

		// Token: 0x060096C2 RID: 38594 RVA: 0x001CBDC8 File Offset: 0x001CA1C8
		private UnityAction<bool> _ToggleListener(int id)
		{
			return delegate(bool val)
			{
				this._OnTapToggleValueChanged(val, id);
			};
		}

		// Token: 0x060096C3 RID: 38595 RVA: 0x001CBDF5 File Offset: 0x001CA1F5
		private void _OnTapToggleValueChanged(bool value, int id)
		{
			if (value)
			{
				this.mSelectedId = id;
			}
			if (this.mOnToggleValueChanged != null)
			{
				this.mOnToggleValueChanged(value, id);
			}
		}

		// Token: 0x060096C4 RID: 38596 RVA: 0x001CBE1C File Offset: 0x001CA21C
		public void Dispose()
		{
			if (this.mToggles != null)
			{
				for (int i = 0; i < this.mToggles.Count; i++)
				{
					if (this.mToggles[i] != null)
					{
						this.mToggles[i].onValueChanged.RemoveAllListeners();
					}
				}
				this.mToggles.Clear();
			}
			this.mSelectedId = 0;
			this.mOnToggleValueChanged = null;
		}

		// Token: 0x060096C5 RID: 38597 RVA: 0x001CBE96 File Offset: 0x001CA296
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x04004D85 RID: 19845
		[SerializeField]
		private RectTransform mToggleRoot;

		// Token: 0x04004D86 RID: 19846
		[SerializeField]
		private ToggleGroup mToggleGroup;

		// Token: 0x04004D87 RID: 19847
		private List<Toggle> mToggles = new List<Toggle>();

		// Token: 0x04004D88 RID: 19848
		private ComTabGroup.OnToggleValueChanged mOnToggleValueChanged;

		// Token: 0x04004D89 RID: 19849
		private int mSelectedId;

		// Token: 0x02000F18 RID: 3864
		// (Invoke) Token: 0x060096C7 RID: 38599
		public delegate void OnToggleValueChanged(bool value, int selectId);
	}
}
