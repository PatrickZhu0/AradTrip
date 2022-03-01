using System;
using ProtoTable;
using UnityEngine;

// Token: 0x020040FD RID: 16637
public class BDSkillSfx : BDEventBase
{
	// Token: 0x06016A67 RID: 92775 RVA: 0x006DD598 File Offset: 0x006DB998
	public BDSkillSfx(DAssetObject assetObj, int soundID = 0, bool loop = false, bool useActorSpeed = false, bool phaseFinishDelete = false, bool finishDelete = false, float volume = 0f)
	{
		this.objSfx = assetObj.m_AssetObj;
		this.objSfxPath = assetObj.m_AssetPath;
		this.loop = loop;
		this.soundID = soundID;
		this.m_UseActorSpeed = useActorSpeed;
		this.m_PhaseFinishDelete = phaseFinishDelete;
		this.m_FinishDelete = finishDelete;
		this.m_Volume = volume;
		if (this.soundID > 0)
		{
			this.soundData = Singleton<TableManager>.GetInstance().GetTableItem<SoundTable>(soundID, string.Empty, string.Empty);
		}
	}

	// Token: 0x06016A68 RID: 92776 RVA: 0x006DD61A File Offset: 0x006DBA1A
	public BDSkillSfx(Object obj)
	{
		this.objSfx = obj;
	}

	// Token: 0x06016A69 RID: 92777 RVA: 0x006DD62C File Offset: 0x006DBA2C
	public override void OnEvent(BeEntity pkEntity)
	{
		if (pkEntity.actionLooped && !this.loop)
		{
			return;
		}
		if (pkEntity.m_pkGeActor != null && pkEntity.m_pkGeActor.GetUseCube())
		{
			return;
		}
		float speed = 1f;
		BeActor beActor = pkEntity as BeActor;
		if (this.m_UseActorSpeed && beActor != null && beActor.IsCastingSkill())
		{
			BeSkill currentSkill = beActor.GetCurrentSkill();
			if (currentSkill != null)
			{
				speed = currentSkill.GetSkillSpeedFactor().single;
			}
		}
		uint item;
		if (this.soundID > 0)
		{
			item = MonoSingleton<AudioManager>.instance.PlaySound(this.soundData, speed, this.m_Volume);
		}
		else if (this.objSfx != null)
		{
			item = MonoSingleton<AudioManager>.instance.PlaySound(this.objSfx as AudioClip, AudioType.AudioEffect, this.m_Volume, false, null, true, false, null, speed);
		}
		else
		{
			item = MonoSingleton<AudioManager>.instance.PlaySound(this.objSfxPath, AudioType.AudioEffect, this.m_Volume, false, null, true, false, null, speed);
		}
		if (this.m_PhaseFinishDelete && !pkEntity.PhaseDeleteAudioList.Contains(item))
		{
			pkEntity.PhaseDeleteAudioList.Add(item);
		}
		if (this.m_FinishDelete && !pkEntity.FinishDeleteAudioList.Contains(item))
		{
			pkEntity.FinishDeleteAudioList.Add(item);
		}
	}

	// Token: 0x06016A6A RID: 92778 RVA: 0x006DD78C File Offset: 0x006DBB8C
	public override void PreparePreload(BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool useCube = false)
	{
		if (useCube)
		{
			return;
		}
		if (this.soundID > 0)
		{
			MonoSingleton<AudioManager>.instance.PreloadSound(this.soundID);
		}
		else if (this.objSfx == null)
		{
			MonoSingleton<AudioManager>.instance.PreloadSound(this.objSfxPath);
		}
	}

	// Token: 0x04010249 RID: 66121
	public Object objSfx;

	// Token: 0x0401024A RID: 66122
	public string objSfxPath;

	// Token: 0x0401024B RID: 66123
	public bool loop;

	// Token: 0x0401024C RID: 66124
	public int soundID;

	// Token: 0x0401024D RID: 66125
	protected bool m_UseActorSpeed;

	// Token: 0x0401024E RID: 66126
	protected bool m_PhaseFinishDelete;

	// Token: 0x0401024F RID: 66127
	protected bool m_FinishDelete;

	// Token: 0x04010250 RID: 66128
	public SoundTable soundData;

	// Token: 0x04010251 RID: 66129
	public float m_Volume;
}
