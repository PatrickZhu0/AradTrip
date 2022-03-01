using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x0200448C RID: 17548
public class Skill2114 : BeSkill
{
	// Token: 0x06018650 RID: 99920 RVA: 0x0079A414 File Offset: 0x00798814
	public Skill2114(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018651 RID: 99921 RVA: 0x0079A46B File Offset: 0x0079886B
	public override bool CanUseSkill()
	{
		return base.CanUseSkill();
	}

	// Token: 0x06018652 RID: 99922 RVA: 0x0079A474 File Offset: 0x00798874
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.monsterIDs.Clear();
		this.entityMap.Clear();
		if (!BattleMain.IsModePvP(base.battleType))
		{
			this.diameter = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true), GlobalLogic.VALUE_1000);
			float num = (float)TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], 1, true) / 1000f;
			this.scale = (float)this.diameter.i / (num * 10000f);
			for (int i = 0; i < this.skillData.ValueB.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true);
				this.monsterIDs.Add(valueFromUnionCell);
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(this.skillData.ValueC[i], base.level, true);
				if (!this.entityMap.ContainsKey(valueFromUnionCell))
				{
					this.entityMap.Add(valueFromUnionCell, valueFromUnionCell2);
				}
			}
		}
		else
		{
			this.diameter = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], base.level, true), GlobalLogic.VALUE_1000);
			float num2 = (float)TableManager.GetValueFromUnionCell(this.skillData.ValueD[0], 1, true) / 1000f;
			this.scale = (float)this.diameter.i / (num2 * 10000f);
			for (int j = 0; j < this.skillData.ValueE.Count; j++)
			{
				int valueFromUnionCell3 = TableManager.GetValueFromUnionCell(this.skillData.ValueE[j], base.level, true);
				this.monsterIDs.Add(valueFromUnionCell3);
				int valueFromUnionCell4 = TableManager.GetValueFromUnionCell(this.skillData.ValueF[j], base.level, true);
				if (!this.entityMap.ContainsKey(valueFromUnionCell3))
				{
					this.entityMap.Add(valueFromUnionCell3, valueFromUnionCell4);
				}
			}
		}
	}

	// Token: 0x06018653 RID: 99923 RVA: 0x0079A69C File Offset: 0x00798A9C
	public override void OnStart()
	{
		this.findEffect = false;
	}

	// Token: 0x06018654 RID: 99924 RVA: 0x0079A6A8 File Offset: 0x00798AA8
	public override void OnEnterPhase(int phase)
	{
		if (phase == 2)
		{
			VInt3 position = base.owner.GetPosition();
			if (base.owner.GetFace())
			{
				position.x -= this.diameter.i / 2;
			}
			else
			{
				position.x += this.diameter.i / 2;
			}
			List<BeActor> list = ListPool<BeActor>.Get();
			base.owner.CurrentBeScene.GetSummonBySummoner(list, base.owner, false, false);
			for (int i = 0; i < list.Count; i++)
			{
				BeActor beActor = list[i];
				VInt3 position2 = beActor.GetPosition();
				if (!BattleMain.IsModePvP(base.owner.battleType))
				{
					if (BeUtility.IsMonsterIDEqualList(this.monsterIDs, beActor.GetEntityData().monsterID))
					{
						this.TriggerExplosionPVE(beActor, this.entityMap[beActor.GetEntityData().monsterID]);
					}
				}
				else if ((position - position2).magnitude <= this.diameter.i / 2 && BeUtility.IsMonsterIDEqualList(this.monsterIDs, beActor.GetEntityData().monsterID))
				{
					this.TriggerExplosionPVP(beActor, this.entityMap[beActor.GetEntityData().monsterID]);
				}
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x06018655 RID: 99925 RVA: 0x0079A810 File Offset: 0x00798C10
	public override void OnUpdate(int iDeltime)
	{
		if (!this.findEffect)
		{
			GeEffectEx geEffectEx = base.owner.m_pkGeActor.FindEffect(this.effectName);
			if (geEffectEx != null)
			{
				this.findEffect = true;
				geEffectEx.SetScale(this.scale);
			}
		}
	}

	// Token: 0x06018656 RID: 99926 RVA: 0x0079A858 File Offset: 0x00798C58
	private void TriggerExplosionPVE(BeActor actor, int entityID)
	{
		VInt3 rhs = new VInt3((!base.owner.GetFace()) ? 2.8f : -2.8f, 0f, 0f);
		VInt3 vint = base.owner.GetPosition() + rhs;
		if (base.owner.CurrentBeScene.IsInBlockPlayer(vint))
		{
			vint = actor.GetPosition();
		}
		actor.SetPosition(vint, true, true, false);
		base.owner.AddEntity(entityID, actor.GetPosition(), base.GetLevel(), 0);
		float num = (float)actor.GetEntityData().GetMaxHP() * 0.55f;
		actor.DoHurt((int)num, null, HitTextType.NORMAL, null, HitTextType.NORMAL, false);
	}

	// Token: 0x06018657 RID: 99927 RVA: 0x0079A908 File Offset: 0x00798D08
	private void TriggerExplosionPVP(BeActor actor, int entityID)
	{
		if (actor.aiManager != null)
		{
			actor.aiManager.Stop();
		}
		actor.Locomote(new BeStateData(0, 0), false);
		actor.m_pkGeActor.SetActorVisible(false);
		bool flag = false;
		if (actor.GetEntityData().MonsterIDEqual(this.bingnaisi))
		{
			flag = true;
		}
		else if (actor.GetEntityData().MonsterIDEqual(this.leiwosi))
		{
			flag = true;
			if (actor.aiManager.aiTarget != null)
			{
				actor.SetPosition(actor.aiManager.aiTarget.GetPosition(), false, true, false);
			}
		}
		if (flag && actor.floatingHeight > 0)
		{
			actor.RemoveFloating();
			VInt3 position = actor.GetPosition();
			position.z = 0;
			actor.SetPosition(position, false, true, false);
		}
		Buff12 buff = actor.buffController.HasBuffByID(12) as Buff12;
		if (buff != null)
		{
			buff.showDisappearEffect = false;
		}
		base.owner.AddEntity(entityID, actor.GetPosition(), base.GetLevel(), 0);
		actor.delayCaller.DelayCall(1500, delegate
		{
			actor.DoDead(false);
		}, 0, 0, false);
	}

	// Token: 0x040119A5 RID: 72101
	private VInt diameter;

	// Token: 0x040119A6 RID: 72102
	private List<int> monsterIDs = new List<int>();

	// Token: 0x040119A7 RID: 72103
	private int leiwosi = 9030011;

	// Token: 0x040119A8 RID: 72104
	private int bingnaisi = 9010011;

	// Token: 0x040119A9 RID: 72105
	private Dictionary<int, int> entityMap = new Dictionary<int, int>();

	// Token: 0x040119AA RID: 72106
	private float scale = 1f;

	// Token: 0x040119AB RID: 72107
	private bool findEffect;

	// Token: 0x040119AC RID: 72108
	private string effectName = "Effects/Hero_Zhaohuanshi/Xianji/Prefab/Eff_xianji_fazhen";
}
