using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x02004476 RID: 17526
public class Skill1921 : BeSkill
{
	// Token: 0x060185D9 RID: 99801 RVA: 0x00797500 File Offset: 0x00795900
	public Skill1921(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185DA RID: 99802 RVA: 0x00797574 File Offset: 0x00795974
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x060185DB RID: 99803 RVA: 0x0079757C File Offset: 0x0079597C
	public override void OnStart()
	{
		base.OnStart();
		this.handle1 = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string a = (string)args[0];
			if (base.owner.isLocalActor)
			{
				if (a == "true")
				{
					this._switchSceneEffect(true);
				}
				else if (a == "false")
				{
					this.hideFlag = false;
					this._switchSceneEffect(false);
				}
			}
			if (a == "192101")
			{
				if (base.owner.m_pkGeActor != null)
				{
					base.owner.m_pkGeActor.SetActorVisible(false);
				}
			}
			else if (a == "192102" && base.owner.m_pkGeActor != null)
			{
				base.owner.m_pkGeActor.SetActorVisible(true);
			}
			if (a == "19211")
			{
				int weaponType = base.owner.GetWeaponType();
				int hurtID = this.effectId;
				switch (weaponType)
				{
				case 1:
					hurtID = 19217;
					break;
				case 2:
					hurtID = 19211;
					break;
				case 3:
					hurtID = 19219;
					break;
				case 4:
					hurtID = 19215;
					break;
				}
				this._OnHurtEntity(hurtID);
			}
		});
		this.handle2 = base.owner.RegisterEvent(BeEventType.onAfterFinalDamageNew, delegate(object[] args)
		{
			BeActor beActor = args[1] as BeActor;
			if (beActor != null && !this.hitList.Contains(beActor))
			{
				this.hitList.Add(beActor);
			}
		});
		this.handle3 = base.owner.RegisterEvent(BeEventType.onKill, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null)
			{
				beActor.Pause(GlobalLogic.VALUE_10000, true);
				this.killList.Add(beActor);
			}
		});
		this.handle4 = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = args[0] as BeBuff;
			if (beBuff != null && beBuff.buffID == this.buffID)
			{
				if (base.owner.isLocalActor)
				{
					if (base.owner.m_pkGeActor != null)
					{
						base.owner.m_pkGeActor.SetAttachmentVisible("wing", false);
					}
					this.hideFlag = true;
					this.AddJianYingBuff();
					if (base.owner.CurrentBeScene != null)
					{
						Vec3 vec = base.owner.CurrentBeScene.GetSceneCenterPosition().vec3;
						Vector3 vector;
						vector..ctor((float)Screen.width / 2f, (float)Screen.height / 2f, 0f);
						Ray ray = Camera.main.ScreenPointToRay(vector);
						float num = -ray.origin.y / ray.direction.y;
						Vec3 initPos = new Vec3(ray.GetPoint(num).x, base.owner.CurrentBeScene.logicZSize.fy, 0f);
						if (base.owner.CurrentBeScene.currentGeScene != null)
						{
							this.baipingEffect = base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.effectPath, 1.2f, initPos, 2f, 1f, false, false);
						}
					}
				}
				this.TryAddControlBuff();
			}
		});
		this.handle5 = base.owner.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.buffID && base.owner.isLocalActor)
			{
				if (base.owner.m_pkGeActor != null)
				{
					base.owner.m_pkGeActor.SetAttachmentVisible("wing", true);
				}
				if (this.baipingEffect != null)
				{
					if (base.owner.CurrentBeScene != null && base.owner.CurrentBeScene.currentGeScene != null)
					{
						base.owner.CurrentBeScene.currentGeScene.DestroyEffect(this.baipingEffect);
					}
					this.baipingEffect = null;
				}
			}
		});
		this.handle6 = base.owner.RegisterEvent(BeEventType.onChangeHitEffect, delegate(object[] args)
		{
			int num = (int)args[0];
			if (num == this.effectId)
			{
				string[] array = (string[])args[1];
				array[0] = this.hitEffectPath;
			}
		});
	}

	// Token: 0x060185DC RID: 99804 RVA: 0x0079764C File Offset: 0x00795A4C
	public override void OnUpdate(int iDeltime)
	{
		base.OnUpdate(iDeltime);
		if (!base.owner.isLocalActor)
		{
			return;
		}
		if (this.hideFlag)
		{
			List<BeEntity> list = ListPool<BeEntity>.Get();
			base.owner.CurrentBeScene.GetEntitys2(list);
			for (int i = 0; i < list.Count; i++)
			{
				if (!this.hideList.Contains(list[i]) && list[i] != null && list[i].m_pkGeActor != null && !list[i].m_pkGeActor.IsActorHide())
				{
					this._hideOtherActor(list[i]);
				}
			}
			ListPool<BeEntity>.Release(list);
		}
		else
		{
			this._showActor();
		}
	}

	// Token: 0x060185DD RID: 99805 RVA: 0x00797714 File Offset: 0x00795B14
	private void _OnHurtEntity(int hurtID)
	{
		for (int i = 0; i < this.hitList.Count; i++)
		{
			BeActor beActor = this.hitList[i];
			if (beActor != null && beActor.m_pkGeActor != null)
			{
				VInt3 position = beActor.GetPosition();
				position.z += VInt.one.i;
				base.owner._onHurtEntity(beActor, position, hurtID);
			}
		}
		this.hitList.Clear();
		base.owner.delayCaller.DelayCall(400, delegate
		{
			for (int j = 0; j < this.killList.Count; j++)
			{
				BeActor beActor2 = this.killList[j];
				if (beActor2 != null && beActor2.m_pkGeActor != null)
				{
					beActor2.Resume();
					beActor2.DoDead(false);
				}
			}
			this.killList.Clear();
		}, 0, 0, false);
	}

	// Token: 0x060185DE RID: 99806 RVA: 0x007977C0 File Offset: 0x00795BC0
	private void TryAddControlBuff()
	{
		for (int i = 0; i < this.hitList.Count; i++)
		{
			if (this.hitList[i] != null && !this.hitList[i].IsDead())
			{
				this.hitList[i].buffController.TryAddBuff(this.buffInfoID, null, false, null, 0);
			}
		}
	}

	// Token: 0x060185DF RID: 99807 RVA: 0x00797834 File Offset: 0x00795C34
	private void _switchSceneEffect(bool flag)
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (flag)
		{
			this.blackSceneID = base.owner.CurrentBeScene.currentGeScene.BlendSceneSceneColor(0.1f, 0.3f, true);
			this.delayCall = base.owner.delayCaller.DelayCall(300, delegate
			{
				if (this.canceled)
				{
					return;
				}
				base.owner.CurrentBeScene.currentGeScene.GetSceneRoot().CustomActive(false);
				base.owner.CurrentBeScene.currentGeScene.GetSceneActorRoot().CustomActive(false);
			}, 0, 0, false);
		}
		else
		{
			base.owner.CurrentBeScene.currentGeScene.GetSceneRoot().CustomActive(true);
			base.owner.CurrentBeScene.currentGeScene.GetSceneActorRoot().CustomActive(true);
			base.owner.CurrentBeScene.currentGeScene.RecoverSceneColor(0.3f, this.blackSceneID);
		}
	}

	// Token: 0x060185E0 RID: 99808 RVA: 0x00797904 File Offset: 0x00795D04
	private void _recoverScene()
	{
		base.owner.CurrentBeScene.currentGeScene.GetSceneRoot().CustomActive(true);
		base.owner.CurrentBeScene.currentGeScene.GetSceneActorRoot().CustomActive(true);
		base.owner.CurrentBeScene.currentGeScene.RecoverSceneColor(0.01f, this.blackSceneID);
	}

	// Token: 0x060185E1 RID: 99809 RVA: 0x00797968 File Offset: 0x00795D68
	private void _hideOtherActor(BeEntity entity)
	{
		if (entity == null || entity.GetPID() == base.owner.GetPID())
		{
			return;
		}
		BeActor beActor = entity as BeActor;
		if (beActor != null)
		{
			if (beActor.GetEntityData() != null && BeUtility.IsMonsterIDEqual(beActor.GetEntityData().monsterID, 30430011))
			{
				return;
			}
			if (beActor.IsSkillMonster() || beActor.GetCamp() == base.owner.GetCamp())
			{
				if (beActor.m_pkGeActor != null)
				{
					beActor.m_pkGeActor.HideActor(true);
					this.hideList.Add(entity);
				}
			}
			else if (beActor.GetCamp() != base.owner.GetCamp() && !this.hitList.Contains(beActor) && beActor.m_pkGeActor != null)
			{
				beActor.m_pkGeActor.HideActor(true);
				this.hideList.Add(entity);
			}
		}
		else if (entity.GetOwner() != null && entity.GetOwner().GetPID() != base.owner.GetPID() && entity.m_pkGeActor != null)
		{
			entity.m_pkGeActor.HideActor(true);
			this.hideList.Add(entity);
		}
	}

	// Token: 0x060185E2 RID: 99810 RVA: 0x00797AA8 File Offset: 0x00795EA8
	private void _showActor()
	{
		for (int i = 0; i < this.hideList.Count; i++)
		{
			BeEntity beEntity = this.hideList[i];
			if (beEntity != null && beEntity.m_pkGeActor != null && beEntity.m_pkGeActor.IsActorHide())
			{
				beEntity.m_pkGeActor.HideActor(false);
			}
		}
		this.hideList.Clear();
	}

	// Token: 0x060185E3 RID: 99811 RVA: 0x00797B18 File Offset: 0x00795F18
	private void AddJianYingBuff()
	{
		for (int i = 0; i < this.hitList.Count; i++)
		{
			BeActor beActor = this.hitList[i];
			if (beActor != null && beActor.m_pkGeActor != null)
			{
				beActor.m_pkGeActor.ChangeSurface("寸拳", 1.5f, true, true);
			}
		}
		if (base.owner != null && base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.ChangeSurface("寸拳", 1.2f, true, true);
		}
	}

	// Token: 0x060185E4 RID: 99812 RVA: 0x00797BB4 File Offset: 0x00795FB4
	public override void OnCancel()
	{
		base.OnCancel();
		this.RemoveHandle();
	}

	// Token: 0x060185E5 RID: 99813 RVA: 0x00797BC2 File Offset: 0x00795FC2
	public override void OnFinish()
	{
		base.OnFinish();
		this.RemoveHandle();
	}

	// Token: 0x060185E6 RID: 99814 RVA: 0x00797BD0 File Offset: 0x00795FD0
	private void RemoveHandle()
	{
		if (this.handle1 != null)
		{
			this.handle1.Remove();
			this.handle1 = null;
		}
		if (this.handle2 != null)
		{
			this.handle2.Remove();
			this.handle2 = null;
		}
		if (this.handle3 != null)
		{
			this.handle3.Remove();
			this.handle3 = null;
		}
		if (this.handle4 != null)
		{
			this.handle4.Remove();
			this.handle4 = null;
		}
		if (this.handle5 != null)
		{
			this.handle5.Remove();
			this.handle5 = null;
		}
		if (this.handle6 != null)
		{
			this.handle6.Remove();
			this.handle6 = null;
		}
		if (base.owner.isLocalActor)
		{
			this._showActor();
			this.hideFlag = false;
			this._recoverScene();
			if (this.delayCall.IsValid())
			{
				this.delayCall.SetRemove(true);
			}
		}
		if (base.owner.m_pkGeActor != null)
		{
			base.owner.m_pkGeActor.SetActorVisible(true);
		}
	}

	// Token: 0x0401196A RID: 72042
	private BeEventHandle handle1;

	// Token: 0x0401196B RID: 72043
	private BeEventHandle handle2;

	// Token: 0x0401196C RID: 72044
	private BeEventHandle handle3;

	// Token: 0x0401196D RID: 72045
	private BeEventHandle handle4;

	// Token: 0x0401196E RID: 72046
	private BeEventHandle handle5;

	// Token: 0x0401196F RID: 72047
	private BeEventHandle handle6;

	// Token: 0x04011970 RID: 72048
	private List<BeActor> hitList = new List<BeActor>();

	// Token: 0x04011971 RID: 72049
	private List<BeActor> killList = new List<BeActor>();

	// Token: 0x04011972 RID: 72050
	private int buffID = 192101;

	// Token: 0x04011973 RID: 72051
	private int buffInfoID = 192105;

	// Token: 0x04011974 RID: 72052
	private int effectId = 19211;

	// Token: 0x04011975 RID: 72053
	private string hitEffectPath = "Effects/Common/Sfx/Hit/Prefab/Eff_hit_kong";

	// Token: 0x04011976 RID: 72054
	private string effectPath = "Effects/Hero_Jianhun/Eff_jianhun_juexing/Prefeb/Eff_jianhun_juexing_inbaiping";

	// Token: 0x04011977 RID: 72055
	private GeEffectEx baipingEffect;

	// Token: 0x04011978 RID: 72056
	private DelayCallUnitHandle delayCall;

	// Token: 0x04011979 RID: 72057
	private bool hideFlag;

	// Token: 0x0401197A RID: 72058
	private int blackSceneID = -1;

	// Token: 0x0401197B RID: 72059
	private List<BeEntity> hideList = new List<BeEntity>();
}
