using System;
using System.Collections.Generic;

// Token: 0x0200414B RID: 16715
public class BeAttachFramesProxy
{
	// Token: 0x06016D2E RID: 93486 RVA: 0x007058E1 File Offset: 0x00703CE1
	public void SetWeaponReplace(string rp, string sp, int t, int slevel = 0)
	{
		this.replaceWeaponPath = rp;
		this.strengthenLevel = slevel;
		this.needReplace = true;
		this.samepleWeaponPath = sp;
		this.tag = t;
	}

	// Token: 0x06016D2F RID: 93487 RVA: 0x00705907 File Offset: 0x00703D07
	public void SetShowFashionWeapon(string rp, string rdw)
	{
		this.fashionWeaponPath = rp;
		this.roleDefaultWeaponName = rdw;
	}

	// Token: 0x06016D30 RID: 93488 RVA: 0x00705918 File Offset: 0x00703D18
	public void Clear()
	{
		if (this.actor == null)
		{
			return;
		}
		for (int i = 0; i < this.att_frame.Count; i++)
		{
			BeAttachFramesProxy.AttachFrame attachFrame = this.att_frame[i];
			if (attachFrame.attach != null)
			{
				this.actor.DestroyAttachment(attachFrame.attach);
			}
			attachFrame.attach = null;
		}
		this.att_frame.Clear();
	}

	// Token: 0x06016D31 RID: 93489 RVA: 0x00705988 File Offset: 0x00703D88
	public void Init(BDEntityActionInfo info)
	{
		this.Clear();
		if (info != null)
		{
			for (int i = 0; i < info.vAttachFrames.Count; i++)
			{
				BeAttachFramesProxy.AttachFrame attachFrame = new BeAttachFramesProxy.AttachFrame();
				attachFrame.frame = info.vAttachFrames[i];
				this.att_frame.Add(attachFrame);
			}
		}
		this.pretime = 0f;
	}

	// Token: 0x06016D32 RID: 93490 RVA: 0x007059EC File Offset: 0x00703DEC
	public void Update(float time)
	{
		if (this.actor == null)
		{
			return;
		}
		if (this.pretime > time)
		{
			this.pretime = 0f;
		}
		for (int i = 0; i < this.att_frame.Count; i++)
		{
			BeAttachFramesProxy.AttachFrame attachFrame = this.att_frame[i];
			if (attachFrame.frame.start >= this.pretime && attachFrame.frame.start <= time)
			{
				if (attachFrame.attach == null)
				{
					bool flag = false;
					string assetPath = attachFrame.frame.entityAsset.m_AssetPath;
					if (this.needReplace && assetPath == this.samepleWeaponPath)
					{
						flag = true;
						if (this.fashionWeaponPath != null)
						{
							assetPath = this.fashionWeaponPath;
						}
						else
						{
							assetPath = this.replaceWeaponPath;
						}
					}
					if (this.samepleWeaponPath == null && assetPath == this.roleDefaultWeaponName && this.fashionWeaponPath != null)
					{
						assetPath = this.fashionWeaponPath;
					}
					string text = attachFrame.frame.name;
					if (text.Contains("["))
					{
						text += assetPath;
					}
					attachFrame.attach = this.actor.CreateAttachment(text, assetPath, attachFrame.frame.attachName, true, false, false);
					if (flag && (this.strengthenLevel > 0 || !string.IsNullOrEmpty(this.fashionWeaponPath)) && attachFrame.attach != null)
					{
						attachFrame.attach.ChangePhase(BeUtility.GetStrengthenEffectName(attachFrame.attach.ResPath), this.strengthenLevel, false);
					}
				}
				if (attachFrame.attach != null)
				{
					for (int j = 0; j < attachFrame.frame.animations.Length; j++)
					{
						BeAnimationFrame beAnimationFrame = attachFrame.frame.animations[j];
						if (beAnimationFrame.start >= this.pretime && beAnimationFrame.start <= time && beAnimationFrame.anim != attachFrame.attach.GetCurActionName())
						{
							attachFrame.attach.PlayAction(beAnimationFrame.anim, beAnimationFrame.speed * this.actor.GetCurActionSpeed(), this.actor.IsActionLoop(beAnimationFrame.anim), this.actor.GetCurActionOffset());
						}
					}
				}
			}
			else if ((time > attachFrame.frame.end || attachFrame.frame.start > time) && attachFrame.attach != null)
			{
				this.actor.DestroyAttachment(attachFrame.attach);
				attachFrame.attach = null;
			}
		}
		this.pretime = time;
		this.actor.UpdateAttach();
	}

	// Token: 0x040104D5 RID: 66773
	public List<BeAttachFramesProxy.AttachFrame> att_frame = new List<BeAttachFramesProxy.AttachFrame>();

	// Token: 0x040104D6 RID: 66774
	public GeActorEx actor;

	// Token: 0x040104D7 RID: 66775
	public float pretime;

	// Token: 0x040104D8 RID: 66776
	public string replaceWeaponPath;

	// Token: 0x040104D9 RID: 66777
	public string samepleWeaponPath;

	// Token: 0x040104DA RID: 66778
	public bool needReplace;

	// Token: 0x040104DB RID: 66779
	public int tag;

	// Token: 0x040104DC RID: 66780
	public int strengthenLevel;

	// Token: 0x040104DD RID: 66781
	public string fashionWeaponPath;

	// Token: 0x040104DE RID: 66782
	public string roleDefaultWeaponName;

	// Token: 0x0200414C RID: 16716
	public class AttachFrame
	{
		// Token: 0x040104DF RID: 66783
		public BeAttachFrames frame;

		// Token: 0x040104E0 RID: 66784
		public GeAttach attach;
	}
}
