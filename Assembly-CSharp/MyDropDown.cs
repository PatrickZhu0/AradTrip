using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020001B7 RID: 439
internal class MyDropDown : MonoBehaviour
{
	// Token: 0x06000E24 RID: 3620 RVA: 0x00048F0C File Offset: 0x0004730C
	private void Start()
	{
		if (null != this.m_button)
		{
			this.m_button.onClick.RemoveListener(new UnityAction(this._OnVisibleChanged));
			this.m_button.onClick.AddListener(new UnityAction(this._OnVisibleChanged));
		}
	}

	// Token: 0x06000E25 RID: 3621 RVA: 0x00048F62 File Offset: 0x00047362
	private void _OnVisibleChanged()
	{
		this.m_template.CustomActive(!this.m_template.activeSelf);
	}

	// Token: 0x06000E26 RID: 3622 RVA: 0x00048F7D File Offset: 0x0004737D
	public void CloseTemplate()
	{
		this.m_template.CustomActive(false);
	}

	// Token: 0x06000E27 RID: 3623 RVA: 0x00048F8C File Offset: 0x0004738C
	public void BindItems(string[] content, ChatType[] eChatTypes, UnityAction<ChatType> actions)
	{
		for (int i = 0; i < this.onActions.Length; i++)
		{
			Button com = this.onActions[i];
			com.CustomActive(false);
		}
		int num = 0;
		if (content != null && eChatTypes != null)
		{
			num = Math.Min(content.Length, eChatTypes.Length);
			for (int j = 0; j < num; j++)
			{
				Button com2 = this.onActions[j];
				com2.CustomActive(true);
			}
		}
		for (int k = 0; k < num; k++)
		{
			if (null != this.onActions[k])
			{
				this.onActions[k].onClick.RemoveAllListeners();
			}
			if (k < content.Length && k < eChatTypes.Length && k < this.descs.Length)
			{
				ChatType eValue = eChatTypes[k];
				this.onActions[k].onClick.AddListener(delegate()
				{
					if (actions != null)
					{
						actions.Invoke(eValue);
						this.CloseTemplate();
					}
				});
				if (this.descs != null && null != this.descs[k])
				{
					this.descs[k].text = content[k];
				}
			}
		}
	}

	// Token: 0x06000E28 RID: 3624 RVA: 0x000490E4 File Offset: 0x000474E4
	public void OnDestroy()
	{
		if (null != this.m_button)
		{
			this.m_button.onClick.RemoveListener(new UnityAction(this._OnVisibleChanged));
		}
		if (this.onActions != null)
		{
			for (int i = 0; i < this.onActions.Length; i++)
			{
				if (null != this.onActions[i])
				{
					this.onActions[i].onClick.RemoveAllListeners();
				}
			}
		}
	}

	// Token: 0x040009CD RID: 2509
	public Button m_button;

	// Token: 0x040009CE RID: 2510
	public GameObject m_template;

	// Token: 0x040009CF RID: 2511
	public Button[] onActions;

	// Token: 0x040009D0 RID: 2512
	public Text[] descs;
}
