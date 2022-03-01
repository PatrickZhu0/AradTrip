using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017A5 RID: 6053
	public class MallNewPropertyMallTabItem : MonoBehaviour
	{
		// Token: 0x0600EEAB RID: 61099 RVA: 0x00401556 File Offset: 0x003FF956
		private void Awake()
		{
			this._isSelected = false;
			this._propertyMallTabData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x0600EEAC RID: 61100 RVA: 0x0040156C File Offset: 0x003FF96C
		private void BindUiEventSystem()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600EEAD RID: 61101 RVA: 0x004015AB File Offset: 0x003FF9AB
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x0600EEAE RID: 61102 RVA: 0x004015B3 File Offset: 0x003FF9B3
		private void UnBindUiEventSystem()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
		}

		// Token: 0x0600EEAF RID: 61103 RVA: 0x004015D8 File Offset: 0x003FF9D8
		public void InitData(MallNewPropertyMallTabData propertyMallTabData, OnPropertyMallTabValueChanged toggleValueChanged = null, bool isSelected = false)
		{
			this._propertyMallTabData = propertyMallTabData;
			if (this._propertyMallTabData == null)
			{
				return;
			}
			MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(this._propertyMallTabData.MallTypeTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("MallTypeTable is null and mallTypeTableId is {0}", new object[]
				{
					this._propertyMallTabData.MallTypeTableId
				});
			}
			if (this.nameText != null)
			{
				this.nameText.text = tableItem.MainTypeName;
			}
			this.onToggleValueChanged = toggleValueChanged;
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x0600EEB0 RID: 61104 RVA: 0x00401690 File Offset: 0x003FFA90
		private void OnTabClicked(bool value)
		{
			if (this._propertyMallTabData == null)
			{
				return;
			}
			if (this._isSelected == value)
			{
				return;
			}
			this._isSelected = value;
			if (value && this.onToggleValueChanged != null)
			{
				this.onToggleValueChanged(this._propertyMallTabData.Index, this._propertyMallTabData.MallTypeTableId);
			}
		}

		// Token: 0x0400921F RID: 37407
		private OnPropertyMallTabValueChanged onToggleValueChanged;

		// Token: 0x04009220 RID: 37408
		private bool _isSelected;

		// Token: 0x04009221 RID: 37409
		private MallNewPropertyMallTabData _propertyMallTabData;

		// Token: 0x04009222 RID: 37410
		[SerializeField]
		private Text nameText;

		// Token: 0x04009223 RID: 37411
		[SerializeField]
		private Toggle toggle;
	}
}
