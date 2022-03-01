using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000EF3 RID: 3827
[ExecuteInEditMode]
public class ComInputModeChange : MonoBehaviour
{
	// Token: 0x060095BE RID: 38334 RVA: 0x001C45DE File Offset: 0x001C29DE
	private void Start()
	{
		this._reloadButton();
		this._updateText();
	}

	// Token: 0x060095BF RID: 38335 RVA: 0x001C45EC File Offset: 0x001C29EC
	private void _reloadButton()
	{
		this.mButton.onClick.RemoveAllListeners();
		this.mButton.onClick.AddListener(delegate()
		{
			if (BattleMain.instance != null)
			{
			}
		});
	}

	// Token: 0x060095C0 RID: 38336 RVA: 0x001C462B File Offset: 0x001C2A2B
	private void _updateText()
	{
		this.mText.text = this.mMode.GetDescription(true);
	}

	// Token: 0x060095C1 RID: 38337 RVA: 0x001C4649 File Offset: 0x001C2A49
	private void Update()
	{
	}

	// Token: 0x04004CA3 RID: 19619
	public Button mButton;

	// Token: 0x04004CA4 RID: 19620
	public Text mText;

	// Token: 0x04004CA5 RID: 19621
	public InputManager.ButtonMode mMode;
}
