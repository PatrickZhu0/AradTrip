using System;
using System.Collections;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000DC4 RID: 3524
public class ComShowText : MonoBehaviour
{
	// Token: 0x06008EA3 RID: 36515 RVA: 0x001A6CB7 File Offset: 0x001A50B7
	private void Start()
	{
	}

	// Token: 0x06008EA4 RID: 36516 RVA: 0x001A6CB9 File Offset: 0x001A50B9
	public void Begin(Text control, string text, float speed, float delay, IClientFrame frame)
	{
		control.text = string.Empty;
		this.control = control;
		this.text = text;
		this.speed = speed;
		this.delay = delay;
		this.frame = frame;
		base.StartCoroutine(this._update());
	}

	// Token: 0x06008EA5 RID: 36517 RVA: 0x001A6CF8 File Offset: 0x001A50F8
	private int getShowCount(float delta)
	{
		if (this.speed <= 0f)
		{
			return this.text.Length;
		}
		return (int)(delta / this.speed);
	}

	// Token: 0x06008EA6 RID: 36518 RVA: 0x001A6D20 File Offset: 0x001A5120
	private IEnumerator _update()
	{
		float begin = Time.realtimeSinceStartup;
		int countshow = this.getShowCount(Time.deltaTime);
		if (countshow >= this.text.Length)
		{
			this.control.text = this.text;
		}
		else
		{
			while (this.control.text.Length < this.text.Length)
			{
				while (this.control.text.Length < countshow && this.control.text.Length < this.text.Length)
				{
					Text text = this.control;
					text.text += this.text[this.control.text.Length];
				}
				yield return Yielders.EndOfFrame;
				countshow = this.getShowCount(Time.realtimeSinceStartup - begin);
			}
		}
		if (this.delay < 0f)
		{
			yield break;
		}
		yield return Yielders.GetWaitForSeconds(this.delay);
		this.frame.Close(false);
		yield break;
	}

	// Token: 0x040046BB RID: 18107
	private Text control;

	// Token: 0x040046BC RID: 18108
	private string text;

	// Token: 0x040046BD RID: 18109
	private float speed;

	// Token: 0x040046BE RID: 18110
	private float delay;

	// Token: 0x040046BF RID: 18111
	private IClientFrame frame;
}
