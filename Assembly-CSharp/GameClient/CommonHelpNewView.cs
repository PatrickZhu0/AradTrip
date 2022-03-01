using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E02 RID: 3586
	public class CommonHelpNewView : MonoBehaviour
	{
		// Token: 0x06008FC5 RID: 36805 RVA: 0x001A92CA File Offset: 0x001A76CA
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06008FC6 RID: 36806 RVA: 0x001A92D2 File Offset: 0x001A76D2
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06008FC7 RID: 36807 RVA: 0x001A92E0 File Offset: 0x001A76E0
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x06008FC8 RID: 36808 RVA: 0x001A931F File Offset: 0x001A771F
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06008FC9 RID: 36809 RVA: 0x001A9342 File Offset: 0x001A7742
		private void ClearData()
		{
			this._helpId = 0;
			this._commonHelpTable = null;
		}

		// Token: 0x06008FCA RID: 36810 RVA: 0x001A9354 File Offset: 0x001A7754
		public void InitView(int helpId)
		{
			this._helpId = helpId;
			this._commonHelpTable = Singleton<TableManager>.GetInstance().GetTableItem<CommonHelpTable>(this._helpId, string.Empty, string.Empty);
			if (this._commonHelpTable == null)
			{
				Logger.LogErrorFormat("CommonHelpTable is null and helpId is {0}", new object[]
				{
					this._helpId
				});
				return;
			}
			this.InitContent();
		}

		// Token: 0x06008FCB RID: 36811 RVA: 0x001A93B8 File Offset: 0x001A77B8
		private void InitContent()
		{
			if (this.titleText != null && !string.IsNullOrEmpty(this._commonHelpTable.TitleText))
			{
				this.titleText.text = this._commonHelpTable.TitleText;
			}
			if (this.descriptionText != null)
			{
				string finalStringByUpdateChangeLineFlag = CommonUtility.GetFinalStringByUpdateChangeLineFlag(this._commonHelpTable.Descs);
				this.descriptionText.text = finalStringByUpdateChangeLineFlag;
			}
		}

		// Token: 0x06008FCC RID: 36812 RVA: 0x001A942F File Offset: 0x001A782F
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonHelpNewFrame>(null, false);
		}

		// Token: 0x04004754 RID: 18260
		private int _helpId;

		// Token: 0x04004755 RID: 18261
		private CommonHelpTable _commonHelpTable;

		// Token: 0x04004756 RID: 18262
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private Text titleText;

		// Token: 0x04004757 RID: 18263
		[SerializeField]
		private Text descriptionText;

		// Token: 0x04004758 RID: 18264
		[SerializeField]
		private Button closeButton;
	}
}
