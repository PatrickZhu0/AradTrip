using System;
using UnityEngine;

// Token: 0x0200011C RID: 284
public class FpsShow : MonoSingleton<FpsShow>
{
	// Token: 0x06000662 RID: 1634 RVA: 0x000261B2 File Offset: 0x000245B2
	private void Awake()
	{
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x000261B4 File Offset: 0x000245B4
	private void Update()
	{
		if (!this.showFps)
		{
			return;
		}
		this._frameNumber++;
		float num = Time.realtimeSinceStartup - this._lastShowFPSTime;
		if (num >= 0.2f)
		{
			if (this.FpsUpdateCb != null)
			{
				this.FpsUpdateCb((float)((int)((float)this._frameNumber / num * 100f)) * 0.01f);
			}
			this._fps = (int)((float)this._frameNumber / num);
			this._frameNumber = 0;
			this._lastShowFPSTime = Time.realtimeSinceStartup;
		}
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x00026244 File Offset: 0x00024644
	private void OnGUI()
	{
		if (!this.showFps)
		{
			return;
		}
		this._fpsRect = new Rect(25f, (float)(Screen.height - 60), 100f, 60f);
		if (this._fps >= 18)
		{
			this._fpsColor = Color.Lerp(Color.yellow, Color.green, (float)(this._fps - 18) / 12f);
		}
		else if (this._fps >= 10)
		{
			this._fpsColor = Color.Lerp(Color.red, Color.yellow, (float)(this._fps - 10) / 8f);
		}
		else
		{
			this._fpsColor = Color.red;
		}
		Color contentColor = GUI.contentColor;
		GUIStyle style = GUI.skin.GetStyle("label");
		int fontSize = style.fontSize;
		GUI.contentColor = this._fpsColor;
		style.fontSize = 20;
		GUI.Label(this._fpsRect, "FPS:" + this._fps.ToString());
		GUI.contentColor = contentColor;
		style.fontSize = fontSize;
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x0002635C File Offset: 0x0002475C
	public void RegisterFpsUpdateCb(Action<float> cb)
	{
		this.FpsUpdateCb = (Action<float>)Delegate.Combine(this.FpsUpdateCb, cb);
	}

	// Token: 0x06000666 RID: 1638 RVA: 0x00026375 File Offset: 0x00024775
	public void UnRegisterFpsUpdateCb(Action<float> cb)
	{
		this.FpsUpdateCb = (Action<float>)Delegate.Remove(this.FpsUpdateCb, cb);
	}

	// Token: 0x0400052D RID: 1325
	private Rect _fpsRect = new Rect(25f, (float)(Screen.height - 60), 100f, 60f);

	// Token: 0x0400052E RID: 1326
	private int _fps;

	// Token: 0x0400052F RID: 1327
	private Color _fpsColor = Color.white;

	// Token: 0x04000530 RID: 1328
	private int _frameNumber;

	// Token: 0x04000531 RID: 1329
	private float _lastShowFPSTime;

	// Token: 0x04000532 RID: 1330
	public bool showFps;

	// Token: 0x04000533 RID: 1331
	public const float RecordUnit = 0.2f;

	// Token: 0x04000534 RID: 1332
	private Action<float> FpsUpdateCb;
}
