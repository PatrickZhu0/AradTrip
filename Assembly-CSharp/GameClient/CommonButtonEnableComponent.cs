using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F51 RID: 3921
	public class CommonButtonEnableComponent : MonoBehaviour
	{
		// Token: 0x06009866 RID: 39014 RVA: 0x001D539E File Offset: 0x001D379E
		private void Start()
		{
			this.button = base.gameObject.GetComponent<Button>();
			if (this.button != null)
			{
				this.button.onClick.AddListener(new UnityAction(this.OnButtonClick));
			}
		}

		// Token: 0x06009867 RID: 39015 RVA: 0x001D53DE File Offset: 0x001D37DE
		private void OnDestroy()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveListener(new UnityAction(this.OnButtonClick));
			}
		}

		// Token: 0x06009868 RID: 39016 RVA: 0x001D540D File Offset: 0x001D380D
		private void Update()
		{
			if (this._intervalTime <= 0f)
			{
				this.ResetButtonEnable();
				this._intervalTime = 0f;
			}
			else
			{
				this._intervalTime -= Time.deltaTime;
			}
		}

		// Token: 0x06009869 RID: 39017 RVA: 0x001D5447 File Offset: 0x001D3847
		private void OnButtonClick()
		{
			this.SetButtonDisable();
			this._intervalTime = this.disableTime;
		}

		// Token: 0x0600986A RID: 39018 RVA: 0x001D545B File Offset: 0x001D385B
		private void ResetButtonEnable()
		{
			if (this.button != null && !this.button.interactable)
			{
				this.button.interactable = true;
			}
		}

		// Token: 0x0600986B RID: 39019 RVA: 0x001D548A File Offset: 0x001D388A
		private void SetButtonDisable()
		{
			if (this.button != null)
			{
				this.button.interactable = false;
			}
		}

		// Token: 0x04004EAC RID: 20140
		private Button button;

		// Token: 0x04004EAD RID: 20141
		private float _intervalTime;

		// Token: 0x04004EAE RID: 20142
		public float disableTime = 0.5f;
	}
}
