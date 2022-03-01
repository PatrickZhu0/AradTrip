using System;
using GameClient;
using UnityEngine;

// Token: 0x020040F6 RID: 16630
public class BDPlayEffect : BDEventBase
{
	// Token: 0x06016A4F RID: 92751 RVA: 0x006DB352 File Offset: 0x006D9752
	public BDPlayEffect(object info)
	{
		this.info = (info as EffectsFrames);
		this.scaleBackup = this.info.localScale;
	}

	// Token: 0x06016A50 RID: 92752 RVA: 0x006DB378 File Offset: 0x006D9778
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		if (pkEntity == null || this.info == null)
		{
			return;
		}
		if (pkEntity.actionLooped && !this.info.loopLoop)
		{
			return;
		}
		float fTime = 0f;
		if (this.info.playtype == EffectPlayType.GivenTime)
		{
			fTime = this.info.time;
		}
		this.info.localScale = this.scaleBackup * pkEntity.GetEnityScale().scalar;
		float num = 1f;
		float num2 = 1f;
		float num3 = 1f;
		BeActor beActor = pkEntity.GetOwner() as BeActor;
		if (beActor != null)
		{
			for (int i = 0; i < beActor.MechanismList.Count; i++)
			{
				Mechanism122 mechanism = beActor.MechanismList[i] as Mechanism122;
				if (mechanism != null && mechanism.effectNameList.Contains(this.info.name))
				{
					num += mechanism.xRate.single;
					num2 += mechanism.yRate.single;
					num3 += mechanism.zRate.single;
				}
			}
		}
		if (num <= 0f)
		{
			num = 0.1f;
		}
		if (num2 <= 0f)
		{
			num2 = 0.1f;
		}
		if (num3 <= 0f)
		{
			num3 = 0.1f;
		}
		EffectsFrames effectsFrames = this.info;
		effectsFrames.localScale.x = effectsFrames.localScale.x * num;
		EffectsFrames effectsFrames2 = this.info;
		effectsFrames2.localScale.y = effectsFrames2.localScale.y * num2;
		EffectsFrames effectsFrames3 = this.info;
		effectsFrames3.localScale.z = effectsFrames3.localScale.z * num3;
		bool flag = true;
		if (beActor != null)
		{
			BeActor beActor2 = pkEntity.GetTopOwner(beActor) as BeActor;
			if (beActor2 != null && this.info.onlyLocalSee && !beActor2.isLocalActor)
			{
				flag = false;
			}
			if (!this.NeedCreateEffect(beActor2))
			{
				flag = false;
			}
		}
		float fSpeed = 1f;
		BeActor beActor3 = pkEntity as BeActor;
		if (this.info.useActorSpeed && beActor3 != null && beActor3.IsCastingSkill())
		{
			BeSkill currentSkill = beActor3.GetCurrentSkill();
			if (currentSkill != null)
			{
				fSpeed = currentSkill.GetSkillSpeedFactor().single;
			}
		}
		if (flag)
		{
			pkEntity.m_pkGeActor.CreateEffect(this.info.effectAsset, this.info, fTime, pkEntity.GetPosition().vec3, 1f, fSpeed, this.info.loop, false, false);
		}
		this.info.localScale = this.scaleBackup;
	}

	// Token: 0x06016A51 RID: 92753 RVA: 0x006DB62C File Offset: 0x006D9A2C
	protected bool NeedCreateEffect(BeActor actor)
	{
		return BattleMain.instance == null || BattleMain.IsModePvP(BattleMain.battleType) || actor.isLocalActor || !actor.isMainActor || Singleton<SettingManager>.instance.GetCommmonSet("SETTING_SKILLEFFECTSET") != SettingManager.SetCommonType.Close;
	}

	// Token: 0x06016A52 RID: 92754 RVA: 0x006DB688 File Offset: 0x006D9A88
	public override void PreparePreload(BeActionFrameMgr frameMgr, SkillFileListCache fileCache, bool useCube = false)
	{
		if (useCube)
		{
			return;
		}
		if (this.info != null)
		{
			MonoSingleton<CResPreloader>.instance.AddRes(this.info.effectAsset.m_AssetPath, false, 1, null, 0, null, CResPreloader.ResType.OBJECT, null);
		}
	}

	// Token: 0x04010223 RID: 66083
	protected EffectsFrames info;

	// Token: 0x04010224 RID: 66084
	protected Vector3 scaleBackup;
}
