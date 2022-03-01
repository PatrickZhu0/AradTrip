using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B35 RID: 6965
	public class FashionMergeNewPropertyView : MonoBehaviour
	{
		// Token: 0x060111A1 RID: 70049 RVA: 0x004E81BF File Offset: 0x004E65BF
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x060111A2 RID: 70050 RVA: 0x004E81C7 File Offset: 0x004E65C7
		private void BindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x060111A3 RID: 70051 RVA: 0x004E8206 File Offset: 0x004E6606
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x060111A4 RID: 70052 RVA: 0x004E820E File Offset: 0x004E660E
		private void UnBindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.SafeRemoveAllListener();
			}
		}

		// Token: 0x060111A5 RID: 70053 RVA: 0x004E822C File Offset: 0x004E662C
		public void InitData()
		{
		}

		// Token: 0x060111A6 RID: 70054 RVA: 0x004E822E File Offset: 0x004E662E
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionMergeNewPropertyFrame>(null, false);
		}

		// Token: 0x0400B043 RID: 45123
		[SerializeField]
		private Button closeButton;
	}
}
