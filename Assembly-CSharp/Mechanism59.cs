using System;
using System.Collections.Generic;
using GamePool;

// Token: 0x020043FA RID: 17402
public class Mechanism59 : BeMechanism
{
	// Token: 0x0601827B RID: 98939 RVA: 0x00783760 File Offset: 0x00781B60
	public Mechanism59(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601827C RID: 98940 RVA: 0x00783828 File Offset: 0x00781C28
	public override void OnInit()
	{
		this.m_HurtTagBuff = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_HurtId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x0601827D RID: 98941 RVA: 0x00783888 File Offset: 0x00781C88
	public override void OnStart()
	{
		this.RemoveHandle();
		this.ChangeSkillLevel();
		this.m_ReplaceSkillHandle = base.owner.RegisterEvent(BeEventType.onReplaceSkill, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			BeSkill skill = base.owner.GetSkill(array[0]);
			if (array[0] == this.m_OrignGroundSkillId)
			{
				array[0] = this.m_ReplaceGroundSkillId;
			}
			else if (array[0] == this.m_OrignIceSkillId)
			{
				array[0] = this.m_ReplaceIceSkillId;
			}
			else if (array[0] == this.m_OrignFireSkillId)
			{
				array[0] = this.m_ReplaceFireSkillId;
			}
			if (skill != null)
			{
				skill.StartCoolDown();
			}
		});
		this.m_ReplaceSkillPhaseHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			int[] array = (int[])args[0];
			if (array[0] == this.m_OrignPhaseId || array[0] == this.m_OrignPhaseId2)
			{
				array[0] = this.m_ReplaceNormalId;
			}
		});
		this.m_PassDoor = base.owner.RegisterEvent(BeEventType.onPassedDoor, delegate(object[] args)
		{
			this.RefreshEffect();
		});
		this.m_AddBuffHandle = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			BeBuff beBuff = (BeBuff)args[0];
			if (beBuff.buffID == this.m_HurtTagBuff)
			{
				this.DoHurtToAllEnemy();
			}
		});
		this.ChangeButtonEffect(this.m_OrignGroundSkillId, true);
		this.ChangeButtonEffect(this.m_OrignIceSkillId, true);
		this.ChangeButtonEffect(this.m_OrignFireSkillId, true);
		this.AddEffect(true);
	}

	// Token: 0x0601827E RID: 98942 RVA: 0x0078394C File Offset: 0x00781D4C
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (this.m_CurrTimeAcc >= this.m_CreateEntityTime && !this.m_CreateEntityFlag)
		{
			this.m_CreateEntityFlag = true;
			this.CreateEntity();
		}
		else
		{
			this.m_CurrTimeAcc += deltaTime;
		}
	}

	// Token: 0x0601827F RID: 98943 RVA: 0x0078399C File Offset: 0x00781D9C
	public override void OnFinish()
	{
		this.ChangeButtonEffect(this.m_OrignGroundSkillId, false);
		this.ChangeButtonEffect(this.m_OrignIceSkillId, false);
		this.ChangeButtonEffect(this.m_OrignFireSkillId, false);
		this.AddEffect(false);
		this.RemoveHandle();
	}

	// Token: 0x06018280 RID: 98944 RVA: 0x007839D4 File Offset: 0x00781DD4
	protected void ChangeSkillLevel()
	{
		BeSkill skill = base.owner.GetSkill(this.m_AXiuLuoJueXingId);
		if (skill != null)
		{
			int level = skill.level;
			this.UpdateSkillLevel(this.m_ReplaceNormalId, level);
			this.UpdateSkillLevel(this.m_ReplaceGroundSkillId, level);
			this.UpdateSkillLevel(this.m_ReplaceFireSkillId, level);
			this.UpdateSkillLevel(this.m_ReplaceIceSkillId, level);
		}
	}

	// Token: 0x06018281 RID: 98945 RVA: 0x00783A34 File Offset: 0x00781E34
	protected void UpdateSkillLevel(int skillId, int level)
	{
		if (base.owner.GetSkill(skillId) != null)
		{
			base.owner.GetSkill(skillId).level = level;
		}
	}

	// Token: 0x06018282 RID: 98946 RVA: 0x00783A5C File Offset: 0x00781E5C
	protected void AddEffect(bool isAdd)
	{
		if (isAdd)
		{
			VInt3 sceneCenterPosition = base.owner.CurrentBeScene.GetSceneCenterPosition();
			sceneCenterPosition.z = (int)this.m_Offset * GlobalLogic.VALUE_10000;
			this.m_Effect = base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.m_EffectPath, 1000000f, sceneCenterPosition.vec3, 1f, 1f, false, false);
			sceneCenterPosition.z = (int)(this.m_Offset1 * (float)GlobalLogic.VALUE_10000);
			this.m_Effect1 = base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.m_EffectPath1, 1000000f, sceneCenterPosition.vec3, 1f, 1f, false, false);
		}
		else
		{
			if (this.m_Effect != null)
			{
				base.owner.CurrentBeScene.currentGeScene.DestroyEffect(this.m_Effect);
				this.m_Effect = null;
			}
			if (this.m_Effect1 != null)
			{
				base.owner.CurrentBeScene.currentGeScene.DestroyEffect(this.m_Effect1);
				this.m_Effect = null;
			}
		}
	}

	// Token: 0x06018283 RID: 98947 RVA: 0x00783B7C File Offset: 0x00781F7C
	protected void RefreshEffect()
	{
		VInt3 sceneCenterPosition = base.owner.CurrentBeScene.GetSceneCenterPosition();
		sceneCenterPosition.z = (int)(this.m_Offset * (float)GlobalLogic.VALUE_10000);
		if (this.m_Effect != null)
		{
			this.m_Effect.SetPosition(sceneCenterPosition.vector3);
		}
		sceneCenterPosition.z = (int)(this.m_Offset1 * (float)GlobalLogic.VALUE_10000);
		if (this.m_Effect1 != null)
		{
			this.m_Effect1.SetPosition(sceneCenterPosition.vector3);
		}
	}

	// Token: 0x06018284 RID: 98948 RVA: 0x00783C00 File Offset: 0x00782000
	protected void ChangeButtonEffect(int skillId, bool isAdd)
	{
		BeSkill skill = base.owner.GetSkill(skillId);
		if (skill != null && skill.button != null)
		{
			if (!isAdd)
			{
				skill.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
			}
			else
			{
				skill.button.AddEffect(ETCButton.eEffectType.onContinue, false);
			}
		}
	}

	// Token: 0x06018285 RID: 98949 RVA: 0x00783C58 File Offset: 0x00782058
	protected void CreateEntity()
	{
		if (base.owner != null && !base.owner.IsDead())
		{
			VInt3 sceneCenterPosition = base.owner.CurrentBeScene.GetSceneCenterPosition();
			BeEntity beEntity = base.owner.AddEntity(this.m_EntityId, sceneCenterPosition, 1, 0);
		}
	}

	// Token: 0x06018286 RID: 98950 RVA: 0x00783CA8 File Offset: 0x007820A8
	protected void DoHurtToAllEnemy()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindTargets(list, base.owner, VInt.Float2VIntValue(100f), false, null);
		if (list.Count > 0)
		{
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				if (beActor != null)
				{
					VInt3 position = list[i].GetPosition();
					position.z += VInt.one.i;
					base.owner._onHurtEntity(list[i], position, this.m_HurtId);
				}
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06018287 RID: 98951 RVA: 0x00783D60 File Offset: 0x00782160
	protected void RemoveHandle()
	{
		this.m_CurrTimeAcc = 0;
		this.m_CreateEntityFlag = false;
		if (this.m_ReplaceSkillHandle != null)
		{
			this.m_ReplaceSkillHandle.Remove();
			this.m_ReplaceSkillHandle = null;
		}
		if (this.m_ReplaceSkillPhaseHandle != null)
		{
			this.m_ReplaceSkillPhaseHandle.Remove();
			this.m_ReplaceSkillPhaseHandle = null;
		}
		if (this.m_AddBuffHandle != null)
		{
			this.m_AddBuffHandle.Remove();
			this.m_AddBuffHandle = null;
		}
		if (this.m_PassDoor != null)
		{
			this.m_PassDoor.Remove();
			this.m_PassDoor = null;
		}
	}

	// Token: 0x040116C6 RID: 71366
	protected int m_HurtTagBuff;

	// Token: 0x040116C7 RID: 71367
	protected int m_HurtId;

	// Token: 0x040116C8 RID: 71368
	protected int m_OrignPhaseId = 1502;

	// Token: 0x040116C9 RID: 71369
	protected int m_OrignPhaseId2 = 1714;

	// Token: 0x040116CA RID: 71370
	protected int m_ReplaceNormalId = 1719;

	// Token: 0x040116CB RID: 71371
	protected int m_OrignGroundSkillId = 1510;

	// Token: 0x040116CC RID: 71372
	protected int m_ReplaceGroundSkillId = 1720;

	// Token: 0x040116CD RID: 71373
	protected int m_OrignIceSkillId = 1702;

	// Token: 0x040116CE RID: 71374
	protected int m_ReplaceIceSkillId = 1721;

	// Token: 0x040116CF RID: 71375
	protected int m_OrignFireSkillId = 1703;

	// Token: 0x040116D0 RID: 71376
	protected int m_ReplaceFireSkillId = 1722;

	// Token: 0x040116D1 RID: 71377
	protected int m_AXiuLuoJueXingId = 1718;

	// Token: 0x040116D2 RID: 71378
	protected int m_EntityId = 60323;

	// Token: 0x040116D3 RID: 71379
	protected BeEventHandle m_ReplaceSkillHandle;

	// Token: 0x040116D4 RID: 71380
	protected BeEventHandle m_ReplaceSkillPhaseHandle;

	// Token: 0x040116D5 RID: 71381
	protected BeEventHandle m_PassDoor;

	// Token: 0x040116D6 RID: 71382
	protected BeEventHandle m_AddBuffHandle;

	// Token: 0x040116D7 RID: 71383
	protected string m_EffectPath = "Effects/Hero_Axiuluo/Axiuluo_juexing/Perfab/Eff_Xinyanyuzhou_fire";

	// Token: 0x040116D8 RID: 71384
	protected string m_EffectPath1 = "Effects/Hero_Axiuluo/Axiuluo_juexing/Perfab/Eff_Xinyanyuzhou_tian";

	// Token: 0x040116D9 RID: 71385
	protected GeEffectEx m_Effect;

	// Token: 0x040116DA RID: 71386
	protected GeEffectEx m_Effect1;

	// Token: 0x040116DB RID: 71387
	protected float m_Offset;

	// Token: 0x040116DC RID: 71388
	protected float m_Offset1 = 4.4f;

	// Token: 0x040116DD RID: 71389
	protected float m_OffsetZ = 1f;

	// Token: 0x040116DE RID: 71390
	protected int m_CurrTimeAcc;

	// Token: 0x040116DF RID: 71391
	protected bool m_CreateEntityFlag;

	// Token: 0x040116E0 RID: 71392
	protected int m_CreateEntityTime = 24900;
}
