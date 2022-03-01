using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000D68 RID: 3432
public class GeActorState
{
	// Token: 0x06008B7E RID: 35710 RVA: 0x0019AA3E File Offset: 0x00198E3E
	public void Init(IGeAvatarActor avatar)
	{
		if (avatar != null)
		{
			this.m_AvatarActor = avatar;
		}
	}

	// Token: 0x06008B7F RID: 35711 RVA: 0x0019AA50 File Offset: 0x00198E50
	public void LoadState(string state)
	{
		Object obj = Singleton<AssetLoader>.instance.LoadRes(state, typeof(DSkillData), true, 0U).obj;
		DSkillData dskillData = obj as DSkillData;
		if (null == dskillData)
		{
			return;
		}
		GeActorState.GeStateDesc value = this._CreateStateByData(dskillData);
		if (this.m_StateMap == null)
		{
			this.m_StateMap = new Dictionary<string, GeActorState.GeStateDesc>();
		}
		this.m_StateMap.Add(dskillData.moveName, value);
	}

	// Token: 0x06008B80 RID: 35712 RVA: 0x0019AABE File Offset: 0x00198EBE
	public void Deinit()
	{
	}

	// Token: 0x06008B81 RID: 35713 RVA: 0x0019AAC0 File Offset: 0x00198EC0
	public void ChangeState(string res)
	{
		GeActorState.GeStateDesc curState = null;
		if (this.m_StateMap.TryGetValue(res, out curState))
		{
			this.m_CurState = curState;
			this.m_CurStateFrameCnt = 0U;
			this.m_CurFrameTime = 0f;
			if (this.m_AvatarActor != null)
			{
				this.m_AvatarActor.ChangeAction(this.m_CurState.m_ActionName, 1f, false);
			}
		}
	}

	// Token: 0x06008B82 RID: 35714 RVA: 0x0019AB24 File Offset: 0x00198F24
	public void Update(float fDelta)
	{
		if (fDelta > 1f)
		{
			fDelta = 0.033333335f;
		}
		if (this.m_CurState != null)
		{
			this.m_CurFrameTime += fDelta;
			while (this.m_CurFrameTime > this.m_CurState.m_FrameTime)
			{
				this._UpdateFrame(this.m_CurStateFrameCnt);
				this.m_CurStateFrameCnt += 1U;
				this.m_CurFrameTime -= this.m_CurState.m_FrameTime;
			}
		}
	}

	// Token: 0x06008B83 RID: 35715 RVA: 0x0019ABAC File Offset: 0x00198FAC
	public void _UpdateFrame(uint frameIdx)
	{
		if (this.m_CurState != null && this.m_AvatarActor != null && (ulong)frameIdx < (ulong)((long)this.m_CurState.m_TotalFrameNum))
		{
			GeActorState.GeStateFrame geStateFrame = this.m_CurState.m_StateFrames[(int)((UIntPtr)frameIdx)];
			if (geStateFrame.m_EffectFrames.Count > 0)
			{
				int i = 0;
				int count = geStateFrame.m_EffectFrames.Count;
				while (i < count)
				{
					GeActorState.GeFrameEffect geFrameEffect = geStateFrame.m_EffectFrames[i];
					this.m_AvatarActor.CreateEffect(geFrameEffect.m_EffectResPath, geFrameEffect.m_AttachNode, geFrameEffect.m_EffectTimeLen, (EffectTimeType)geFrameEffect.m_Effecttype, geFrameEffect.m_LocalPosition, geFrameEffect.m_LocalRotation, geFrameEffect.m_LocalScale.x, 1f, false);
					i++;
				}
			}
			if (geStateFrame.m_AudioFrames.Count > 0)
			{
				int j = 0;
				int count2 = geStateFrame.m_AudioFrames.Count;
				while (j < count2)
				{
					GeActorState.GeFrameAudio geFrameAudio = geStateFrame.m_AudioFrames[j];
					MonoSingleton<AudioManager>.instance.PlaySound(geFrameAudio.m_AudioClipRes, AudioType.AudioEffect, 1f, false, null, false, false, null, 1f);
					j++;
				}
			}
			if (geStateFrame.m_Events.Count > 0)
			{
				int k = 0;
				int count3 = geStateFrame.m_Events.Count;
				while (k < count3)
				{
					geStateFrame.m_Events[k]();
					k++;
				}
				geStateFrame.m_Events.Clear();
			}
		}
	}

	// Token: 0x06008B84 RID: 35716 RVA: 0x0019AD28 File Offset: 0x00199128
	protected GeActorState.GeStateDesc _CreateStateByData(DSkillData data)
	{
		GeActorState.GeStateDesc geStateDesc = new GeActorState.GeStateDesc();
		geStateDesc.m_ActionName = data.animationName;
		geStateDesc.m_TotalFrameNum = data.totalFrames;
		geStateDesc.m_FrameTime = 1f / (float)data.fps;
		geStateDesc.m_StateTimeLen = (float)(geStateDesc.m_TotalFrameNum - 1) * geStateDesc.m_FrameTime;
		geStateDesc.m_PlaybackSpeed = 1f;
		geStateDesc.m_StateFrames = new GeActorState.GeStateFrame[geStateDesc.m_TotalFrameNum];
		int i = 0;
		int num = geStateDesc.m_StateFrames.Length;
		while (i < num)
		{
			geStateDesc.m_StateFrames[i] = new GeActorState.GeStateFrame();
			i++;
		}
		if (data.effectFrames != null && data.effectFrames.Length > 0)
		{
			for (int j = 0; j < data.effectFrames.Length; j++)
			{
				EffectsFrames effectsFrames = data.effectFrames[j];
				int startFrames = effectsFrames.startFrames;
				if (startFrames >= 0 && startFrames < geStateDesc.m_StateFrames.Length)
				{
					GeActorState.GeStateFrame geStateFrame = geStateDesc.m_StateFrames[startFrames];
					if (geStateFrame != null)
					{
						GeActorState.GeFrameEffect geFrameEffect = new GeActorState.GeFrameEffect();
						geFrameEffect.m_EffectResPath = effectsFrames.effectAsset.m_AssetPath;
						geFrameEffect.m_AttachNode = effectsFrames.attachname;
						geFrameEffect.m_EffectTimeLen = effectsFrames.time;
						geFrameEffect.m_Effecttype = effectsFrames.effecttype;
						geFrameEffect.m_LocalPosition = effectsFrames.localPosition;
						geFrameEffect.m_LocalRotation = effectsFrames.localRotation;
						geFrameEffect.m_LocalScale = effectsFrames.localScale;
						geStateFrame.m_EffectFrames.Add(geFrameEffect);
					}
				}
			}
		}
		if (data.sfx != null && data.sfx.Length > 0)
		{
			for (int k = 0; k < data.sfx.Length; k++)
			{
				DSkillSfx dskillSfx = data.sfx[k];
				int startframe = dskillSfx.startframe;
				if (startframe < geStateDesc.m_StateFrames.Length)
				{
					GeActorState.GeStateFrame geStateFrame2 = geStateDesc.m_StateFrames[startframe];
					GeActorState.GeFrameAudio geFrameAudio = new GeActorState.GeFrameAudio();
					geFrameAudio.m_AudioClipRes = dskillSfx.soundClipAsset.m_AssetPath;
					geStateFrame2.m_AudioFrames.Add(geFrameAudio);
				}
			}
		}
		if (data.attachFrames != null)
		{
			for (int l = 0; l < data.attachFrames.Length; l++)
			{
				EntityAttachFrames entityAttachFrames = data.attachFrames[l];
				if (entityAttachFrames != null)
				{
					int num2 = (int)(entityAttachFrames.start / geStateDesc.m_FrameTime);
					if (num2 >= geStateDesc.m_TotalFrameNum)
					{
						num2 = geStateDesc.m_TotalFrameNum - 1;
					}
					GeActorState.GeStateFrame geStateFrame3 = geStateDesc.m_StateFrames[num2];
					if (geStateFrame3 != null)
					{
						GeActorState.GeFrameAttachment geFrameAttachment = new GeActorState.GeFrameAttachment();
						geFrameAttachment.m_AttachResPath = entityAttachFrames.entityAsset.m_AssetPath;
						geFrameAttachment.m_AttachNode = entityAttachFrames.attachName;
						geFrameAttachment.m_AttachName = entityAttachFrames.name;
						geFrameAttachment.m_StartFrame = num2;
						geFrameAttachment.m_EndFrame = (int)(entityAttachFrames.end / geStateDesc.m_FrameTime);
						if (entityAttachFrames.trans != null)
						{
							geFrameAttachment.m_LocalPosition = entityAttachFrames.trans.localPosition;
							geFrameAttachment.m_LocalRotation = entityAttachFrames.trans.localRotation;
							geFrameAttachment.m_LocalScale = entityAttachFrames.trans.localScale;
						}
						else
						{
							geFrameAttachment.m_LocalPosition = Vector3.zero;
							geFrameAttachment.m_LocalRotation = Quaternion.identity;
							geFrameAttachment.m_LocalScale = Vector3.one;
						}
						for (int m = 0; m < entityAttachFrames.animations.Length; m++)
						{
							GeActorState.GeFrameObjAnimDesc geFrameObjAnimDesc = new GeActorState.GeFrameObjAnimDesc();
							geFrameObjAnimDesc.m_AnimName = entityAttachFrames.animations[m].anim;
							geFrameObjAnimDesc.m_StartFrame = (int)(entityAttachFrames.animations[m].start / geStateDesc.m_FrameTime);
							geFrameObjAnimDesc.m_PlaySpeed = entityAttachFrames.animations[m].speed;
							geFrameAttachment.m_AnimList.Add(geFrameObjAnimDesc);
						}
						geStateFrame3.m_AttachFrames.Add(geFrameAttachment);
					}
				}
			}
		}
		return geStateDesc;
	}

	// Token: 0x040044B5 RID: 17589
	protected Dictionary<string, GeActorState.GeStateDesc> m_StateMap = new Dictionary<string, GeActorState.GeStateDesc>();

	// Token: 0x040044B6 RID: 17590
	protected uint m_CurStateFrameCnt;

	// Token: 0x040044B7 RID: 17591
	protected GeActorState.GeStateDesc m_CurState;

	// Token: 0x040044B8 RID: 17592
	protected float m_CurFrameTime;

	// Token: 0x040044B9 RID: 17593
	protected IGeAvatarActor m_AvatarActor;

	// Token: 0x02000D69 RID: 3433
	protected class GeFrameAudio
	{
		// Token: 0x040044BA RID: 17594
		public string m_AudioClipRes;
	}

	// Token: 0x02000D6A RID: 3434
	protected class GeFrameEffect
	{
		// Token: 0x040044BB RID: 17595
		public string m_EffectResPath;

		// Token: 0x040044BC RID: 17596
		public Vector3 m_LocalPosition = Vector3.zero;

		// Token: 0x040044BD RID: 17597
		public Quaternion m_LocalRotation = Quaternion.identity;

		// Token: 0x040044BE RID: 17598
		public Vector3 m_LocalScale = Vector3.one;

		// Token: 0x040044BF RID: 17599
		public int m_Effecttype;

		// Token: 0x040044C0 RID: 17600
		public string m_AttachNode;

		// Token: 0x040044C1 RID: 17601
		public float m_EffectTimeLen;
	}

	// Token: 0x02000D6B RID: 3435
	protected class GeFrameObjAnimDesc
	{
		// Token: 0x040044C2 RID: 17602
		public int m_StartFrame;

		// Token: 0x040044C3 RID: 17603
		public string m_AnimName = string.Empty;

		// Token: 0x040044C4 RID: 17604
		public float m_PlaySpeed;
	}

	// Token: 0x02000D6C RID: 3436
	protected class GeFrameAttachment
	{
		// Token: 0x040044C5 RID: 17605
		public string m_AttachResPath;

		// Token: 0x040044C6 RID: 17606
		public string m_AttachNode;

		// Token: 0x040044C7 RID: 17607
		public string m_AttachName;

		// Token: 0x040044C8 RID: 17608
		public int m_StartFrame;

		// Token: 0x040044C9 RID: 17609
		public int m_EndFrame;

		// Token: 0x040044CA RID: 17610
		public Vector3 m_LocalPosition = Vector3.zero;

		// Token: 0x040044CB RID: 17611
		public Quaternion m_LocalRotation = Quaternion.identity;

		// Token: 0x040044CC RID: 17612
		public Vector3 m_LocalScale = Vector3.one;

		// Token: 0x040044CD RID: 17613
		public List<GeActorState.GeFrameObjAnimDesc> m_AnimList = new List<GeActorState.GeFrameObjAnimDesc>();
	}

	// Token: 0x02000D6D RID: 3437
	protected class GeStateFrame
	{
		// Token: 0x040044CE RID: 17614
		public List<GeActorState.GeFrameAttachment> m_AttachFrames = new List<GeActorState.GeFrameAttachment>();

		// Token: 0x040044CF RID: 17615
		public List<GeActorState.GeFrameEffect> m_EffectFrames = new List<GeActorState.GeFrameEffect>();

		// Token: 0x040044D0 RID: 17616
		public List<GeActorState.GeFrameAudio> m_AudioFrames = new List<GeActorState.GeFrameAudio>();

		// Token: 0x040044D1 RID: 17617
		public List<GeActorState.FrameEvnetCall> m_Events = new List<GeActorState.FrameEvnetCall>();
	}

	// Token: 0x02000D6E RID: 3438
	// (Invoke) Token: 0x06008B8B RID: 35723
	public delegate void FrameEvnetCall();

	// Token: 0x02000D6F RID: 3439
	protected class GeStateDesc
	{
		// Token: 0x040044D2 RID: 17618
		public string m_ActionName;

		// Token: 0x040044D3 RID: 17619
		public int m_TotalFrameNum;

		// Token: 0x040044D4 RID: 17620
		public float m_FrameTime;

		// Token: 0x040044D5 RID: 17621
		public float m_StateTimeLen;

		// Token: 0x040044D6 RID: 17622
		public float m_PlaybackSpeed;

		// Token: 0x040044D7 RID: 17623
		public GeActorState.GeStateFrame[] m_StateFrames;
	}
}
