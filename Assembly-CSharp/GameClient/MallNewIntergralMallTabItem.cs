using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200178E RID: 6030
	public class MallNewIntergralMallTabItem : MonoBehaviour
	{
		// Token: 0x0600EE1A RID: 60954 RVA: 0x003FE320 File Offset: 0x003FC720
		private void Awake()
		{
			if (this.mTog != null)
			{
				this.mTog.onValueChanged.RemoveAllListeners();
				this.mTog.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClick));
			}
		}

		// Token: 0x0600EE1B RID: 60955 RVA: 0x003FE35F File Offset: 0x003FC75F
		private void OnDestroy()
		{
			this.mIsSeleted = false;
			this.mMallNewIntergralMallTabClick = null;
			this.mTabData = null;
		}

		// Token: 0x0600EE1C RID: 60956 RVA: 0x003FE378 File Offset: 0x003FC778
		public void InitData(MallNewIntergralMallTabData tabData, MallNewIntergralMallTabClick onClick, bool isSeleted)
		{
			this.mTabData = tabData;
			if (this.mTabData == null)
			{
				return;
			}
			MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(tabData.mallTypeTableId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("MallTypeTable is null and mallTypeTableId is {0}", new object[]
				{
					tabData.mallTypeTableId
				});
			}
			if (this.mTabName != null)
			{
				this.mTabName.text = tableItem.MainTypeName;
			}
			this.mMallNewIntergralMallTabClick = onClick;
			if (isSeleted && this.mTog != null)
			{
				this.mTog.isOn = true;
			}
		}

		// Token: 0x0600EE1D RID: 60957 RVA: 0x003FE424 File Offset: 0x003FC824
		private void OnTabClick(bool value)
		{
			if (this.mTabData == null)
			{
				return;
			}
			if (this.mIsSeleted == value)
			{
				return;
			}
			this.mIsSeleted = value;
			if (value && this.mMallNewIntergralMallTabClick != null)
			{
				this.mMallNewIntergralMallTabClick(this.mTabData.mallTypeTableId);
			}
		}

		// Token: 0x04009178 RID: 37240
		[SerializeField]
		private Text mTabName;

		// Token: 0x04009179 RID: 37241
		[SerializeField]
		private Toggle mTog;

		// Token: 0x0400917A RID: 37242
		private bool mIsSeleted;

		// Token: 0x0400917B RID: 37243
		private MallNewIntergralMallTabClick mMallNewIntergralMallTabClick;

		// Token: 0x0400917C RID: 37244
		private MallNewIntergralMallTabData mTabData;
	}
}
