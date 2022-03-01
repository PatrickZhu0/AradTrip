using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001096 RID: 4246
public class ComTipSkill : MonoBehaviour
{
	// Token: 0x0600A006 RID: 40966 RVA: 0x00201804 File Offset: 0x001FFC04
	public void SetSkillTips(string _text, float _time, bool _wait = false)
	{
		if (!this.startClose)
		{
			this.startClose = true;
		}
		if (_wait)
		{
			this.infoQueue.Enqueue(new ComTipSkill.Tips
			{
				Time = _time,
				Text = _text
			});
		}
		else
		{
			if (this.infoText != null)
			{
				this.infoText.text = _text;
			}
			this.lifeTime = _time;
		}
	}

	// Token: 0x0600A007 RID: 40967 RVA: 0x00201876 File Offset: 0x001FFC76
	private void Start()
	{
	}

	// Token: 0x0600A008 RID: 40968 RVA: 0x00201878 File Offset: 0x001FFC78
	private void Update()
	{
		if (this.startClose)
		{
			this.UpdateCloseTime();
		}
	}

	// Token: 0x0600A009 RID: 40969 RVA: 0x0020188C File Offset: 0x001FFC8C
	public void InitBindUI()
	{
		if (this.infoText != null)
		{
			return;
		}
		ComCommonBind component = base.gameObject.GetComponent<ComCommonBind>();
		if (component != null)
		{
			this.infoText = component.GetCom<Text>("txtTip");
		}
	}

	// Token: 0x0600A00A RID: 40970 RVA: 0x002018D4 File Offset: 0x001FFCD4
	protected void UpdateCloseTime()
	{
		this.lifeTime -= this.deltaTime;
		if (this.lifeTime <= 0f)
		{
			if (this.infoQueue.Count > 0)
			{
				ComTipSkill.Tips tips = this.infoQueue.Dequeue();
				if (this.infoText != null)
				{
					this.infoText.text = tips.Text;
				}
				this.lifeTime += tips.Time;
				return;
			}
			this.startClose = false;
			Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040058A5 RID: 22693
	private Text infoText;

	// Token: 0x040058A6 RID: 22694
	private float deltaTime = 0.033f;

	// Token: 0x040058A7 RID: 22695
	private bool startClose;

	// Token: 0x040058A8 RID: 22696
	private float lifeTime;

	// Token: 0x040058A9 RID: 22697
	private Queue<ComTipSkill.Tips> infoQueue = new Queue<ComTipSkill.Tips>();

	// Token: 0x02001097 RID: 4247
	private struct Tips
	{
		// Token: 0x040058AA RID: 22698
		public float Time;

		// Token: 0x040058AB RID: 22699
		public string Text;
	}
}
