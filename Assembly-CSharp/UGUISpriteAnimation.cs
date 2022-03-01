using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000203 RID: 515
[RequireComponent(typeof(Image))]
public class UGUISpriteAnimation : MonoBehaviour
{
	// Token: 0x17000202 RID: 514
	// (get) Token: 0x0600107A RID: 4218 RVA: 0x0005542A File Offset: 0x0005382A
	public int FrameCount
	{
		get
		{
			return this.SpriteFrames.Count;
		}
	}

	// Token: 0x0600107B RID: 4219 RVA: 0x00055437 File Offset: 0x00053837
	private void Awake()
	{
		this.ImageSource = base.GetComponent<Image>();
	}

	// Token: 0x0600107C RID: 4220 RVA: 0x00055445 File Offset: 0x00053845
	private void Start()
	{
		if (this.AutoPlay)
		{
			this.Play();
		}
		else
		{
			this.IsPlaying = false;
		}
	}

	// Token: 0x0600107D RID: 4221 RVA: 0x00055464 File Offset: 0x00053864
	private void SetSprite(int idx)
	{
		this.ImageSource.sprite = this.SpriteFrames[idx];
	}

	// Token: 0x0600107E RID: 4222 RVA: 0x0005547D File Offset: 0x0005387D
	public void Play()
	{
		this.IsPlaying = true;
		this.Foward = true;
		if (this.showTime > 0f)
		{
			base.Invoke("DoHide", this.showTime);
			this.isShow = true;
		}
	}

	// Token: 0x0600107F RID: 4223 RVA: 0x000554B5 File Offset: 0x000538B5
	public void PlayReverse()
	{
		this.IsPlaying = true;
		this.Foward = false;
	}

	// Token: 0x06001080 RID: 4224 RVA: 0x000554C8 File Offset: 0x000538C8
	private void Update()
	{
		if (!this.IsPlaying || this.FrameCount == 0)
		{
			return;
		}
		this.mDelta += Time.deltaTime;
		if (this.mDelta > 1f / this.FPS)
		{
			this.mDelta = 0f;
			if (this.Foward)
			{
				this.mCurFrame++;
			}
			else
			{
				this.mCurFrame--;
			}
			if (this.mCurFrame >= this.FrameCount)
			{
				if (!this.Loop)
				{
					this.IsPlaying = false;
					return;
				}
				this.mCurFrame = 0;
			}
			else if (this.mCurFrame < 0)
			{
				if (!this.Loop)
				{
					this.IsPlaying = false;
					return;
				}
				this.mCurFrame = this.FrameCount - 1;
			}
			this.SetSprite(this.mCurFrame);
		}
	}

	// Token: 0x06001081 RID: 4225 RVA: 0x000555BF File Offset: 0x000539BF
	public void Pause()
	{
		this.IsPlaying = false;
	}

	// Token: 0x06001082 RID: 4226 RVA: 0x000555C8 File Offset: 0x000539C8
	public void Resume()
	{
		if (!this.IsPlaying)
		{
			this.IsPlaying = true;
		}
	}

	// Token: 0x06001083 RID: 4227 RVA: 0x000555DC File Offset: 0x000539DC
	public void Stop()
	{
		this.mCurFrame = 0;
		this.SetSprite(this.mCurFrame);
		this.IsPlaying = false;
	}

	// Token: 0x06001084 RID: 4228 RVA: 0x000555F8 File Offset: 0x000539F8
	public void Rewind()
	{
		this.mCurFrame = 0;
		this.SetSprite(this.mCurFrame);
		this.Play();
	}

	// Token: 0x06001085 RID: 4229 RVA: 0x00055613 File Offset: 0x00053A13
	public void DoHide()
	{
		if (!this.isShow)
		{
			return;
		}
		this.Stop();
		this.isShow = false;
		base.gameObject.CustomActive(false);
	}

	// Token: 0x04000B3F RID: 2879
	private Image ImageSource;

	// Token: 0x04000B40 RID: 2880
	private int mCurFrame;

	// Token: 0x04000B41 RID: 2881
	private float mDelta;

	// Token: 0x04000B42 RID: 2882
	public float FPS = 5f;

	// Token: 0x04000B43 RID: 2883
	public List<Sprite> SpriteFrames;

	// Token: 0x04000B44 RID: 2884
	public bool IsPlaying;

	// Token: 0x04000B45 RID: 2885
	public bool Foward = true;

	// Token: 0x04000B46 RID: 2886
	public bool AutoPlay;

	// Token: 0x04000B47 RID: 2887
	public bool Loop;

	// Token: 0x04000B48 RID: 2888
	public float showTime;

	// Token: 0x04000B49 RID: 2889
	private bool isShow;
}
