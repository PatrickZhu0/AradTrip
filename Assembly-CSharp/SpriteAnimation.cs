using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E51 RID: 3665
[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class SpriteAnimation : MonoBehaviour
{
	// Token: 0x170018F0 RID: 6384
	// (get) Token: 0x060091CA RID: 37322 RVA: 0x001B001C File Offset: 0x001AE41C
	public int FrameCount
	{
		get
		{
			return this.SpriteFrames.Count;
		}
	}

	// Token: 0x060091CB RID: 37323 RVA: 0x001B0029 File Offset: 0x001AE429
	private void Awake()
	{
		this.ImageSource = base.GetComponent<Image>();
	}

	// Token: 0x060091CC RID: 37324 RVA: 0x001B0037 File Offset: 0x001AE437
	private void Start()
	{
		this.SpriteFrames.Clear();
		this.bLoadSucceeded = this.LoadSpritesFromFile(this.pathPre);
		if (this.AutoPlay)
		{
			this.Play();
		}
		else
		{
			this.IsPlaying = false;
		}
	}

	// Token: 0x060091CD RID: 37325 RVA: 0x001B0073 File Offset: 0x001AE473
	private void SetSprite(int idx)
	{
		this.ImageSource.sprite = this.SpriteFrames[idx];
		if (this.bSetNativeSize)
		{
			this.ImageSource.SetNativeSize();
		}
	}

	// Token: 0x060091CE RID: 37326 RVA: 0x001B00A4 File Offset: 0x001AE4A4
	private bool LoadSpritesFromFile(string path)
	{
		this.SpriteFrames.Clear();
		if (path == null || this.iCount <= 0)
		{
			return false;
		}
		StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
		for (int i = 0; i < this.iCount; i++)
		{
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("{0}{1:00000}", path, i);
			Sprite sprite = Singleton<AssetLoader>.instance.LoadRes(stringBuilder.ToString(), typeof(Sprite), true, 0U).obj as Sprite;
			if (sprite != null)
			{
				this.SpriteFrames.Add(sprite);
			}
		}
		StringBuilderCache.Release(stringBuilder);
		return this.SpriteFrames.Count > 0;
	}

	// Token: 0x060091CF RID: 37327 RVA: 0x001B0164 File Offset: 0x001AE564
	public void Play()
	{
		this.IsPlaying = true;
		this.Foward = true;
	}

	// Token: 0x060091D0 RID: 37328 RVA: 0x001B0174 File Offset: 0x001AE574
	public void PlayReverse()
	{
		this.IsPlaying = true;
		this.Foward = false;
	}

	// Token: 0x060091D1 RID: 37329 RVA: 0x001B0184 File Offset: 0x001AE584
	private void Update()
	{
		if (!this.IsPlaying || this.FrameCount == 0 || !this.bLoadSucceeded)
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
			if (this.bLoadSucceeded && this.target != null)
			{
				Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(this.target.transform);
				Vector3 size = this.ImageSource.sprite.bounds.size;
				Vector3 localScale;
				localScale..ctor(bounds.size.x / size.x * 0.01f, bounds.size.y / size.y * 0.01f, 1f);
				base.transform.localScale = localScale;
			}
		}
	}

	// Token: 0x060091D2 RID: 37330 RVA: 0x001B0320 File Offset: 0x001AE720
	public void Pause()
	{
		this.IsPlaying = false;
	}

	// Token: 0x060091D3 RID: 37331 RVA: 0x001B0329 File Offset: 0x001AE729
	public void Resume()
	{
		if (!this.IsPlaying)
		{
			this.IsPlaying = true;
		}
	}

	// Token: 0x060091D4 RID: 37332 RVA: 0x001B033D File Offset: 0x001AE73D
	public void Stop()
	{
		this.mCurFrame = 0;
		this.SetSprite(this.mCurFrame);
		this.IsPlaying = false;
	}

	// Token: 0x060091D5 RID: 37333 RVA: 0x001B0359 File Offset: 0x001AE759
	public void Rewind()
	{
		this.mCurFrame = 0;
		this.SetSprite(this.mCurFrame);
		this.Play();
	}

	// Token: 0x040048E2 RID: 18658
	private Image ImageSource;

	// Token: 0x040048E3 RID: 18659
	private int mCurFrame;

	// Token: 0x040048E4 RID: 18660
	private float mDelta;

	// Token: 0x040048E5 RID: 18661
	private List<Sprite> SpriteFrames = new List<Sprite>();

	// Token: 0x040048E6 RID: 18662
	private bool bLoadSucceeded;

	// Token: 0x040048E7 RID: 18663
	private Vector3 nativeSize = Vector3.zero;

	// Token: 0x040048E8 RID: 18664
	public float FPS = 5f;

	// Token: 0x040048E9 RID: 18665
	public string pathPre;

	// Token: 0x040048EA RID: 18666
	public int iCount;

	// Token: 0x040048EB RID: 18667
	public bool IsPlaying;

	// Token: 0x040048EC RID: 18668
	public bool Foward = true;

	// Token: 0x040048ED RID: 18669
	public bool AutoPlay;

	// Token: 0x040048EE RID: 18670
	public bool Loop;

	// Token: 0x040048EF RID: 18671
	public RectTransform target;

	// Token: 0x040048F0 RID: 18672
	public bool bSetNativeSize = true;
}
