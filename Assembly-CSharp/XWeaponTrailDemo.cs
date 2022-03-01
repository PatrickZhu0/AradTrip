using System;
using UnityEngine;
using Xft;

// Token: 0x02000DA4 RID: 3492
public class XWeaponTrailDemo : MonoBehaviour
{
	// Token: 0x06008D77 RID: 36215 RVA: 0x001A54D3 File Offset: 0x001A38D3
	public void Start()
	{
		this.ProTrailDistort.Init();
		this.ProTrailShort.Init();
		this.ProTraillong.Init();
		this.SimpleTrail.Init();
	}

	// Token: 0x06008D78 RID: 36216 RVA: 0x001A5504 File Offset: 0x001A3904
	private void OnGUI()
	{
		if (GUI.Button(new Rect(0f, 0f, 150f, 30f), "Activate Trail1"))
		{
			this.ProTrailDistort.Deactivate();
			this.ProTrailShort.Deactivate();
			this.ProTraillong.Deactivate();
			this.SwordAnimation.Play();
			this.SimpleTrail.Activate();
		}
		if (GUI.Button(new Rect(0f, 30f, 150f, 30f), "Stop Trail1"))
		{
			this.SimpleTrail.Deactivate();
		}
		if (GUI.Button(new Rect(0f, 60f, 150f, 30f), "Stop Trail1 Smoothly"))
		{
			this.SimpleTrail.StopSmoothly(0.3f);
		}
		if (GUI.Button(new Rect(0f, 120f, 150f, 30f), "Activate Trail2"))
		{
			this.SimpleTrail.Deactivate();
			this.SwordAnimation.Play();
			this.ProTrailDistort.Activate();
			this.ProTrailShort.Activate();
			this.ProTraillong.Activate();
		}
		if (GUI.Button(new Rect(0f, 150f, 150f, 30f), "Stop Trail2"))
		{
			this.ProTrailDistort.Deactivate();
			this.ProTrailShort.Deactivate();
			this.ProTraillong.Deactivate();
		}
		if (GUI.Button(new Rect(0f, 180f, 150f, 30f), "Stop Trail2 Smoothly"))
		{
			this.ProTrailDistort.StopSmoothly(0.3f);
			this.ProTrailShort.StopSmoothly(0.3f);
			this.ProTraillong.StopSmoothly(0.3f);
		}
	}

	// Token: 0x04004631 RID: 17969
	public Animation SwordAnimation;

	// Token: 0x04004632 RID: 17970
	public XWeaponTrail ProTrailDistort;

	// Token: 0x04004633 RID: 17971
	public XWeaponTrail ProTrailShort;

	// Token: 0x04004634 RID: 17972
	public XWeaponTrail ProTraillong;

	// Token: 0x04004635 RID: 17973
	public XWeaponTrail SimpleTrail;
}
