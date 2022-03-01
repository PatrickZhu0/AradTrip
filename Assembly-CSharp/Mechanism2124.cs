using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020043B8 RID: 17336
public class Mechanism2124 : BeMechanism
{
	// Token: 0x060180AE RID: 98478 RVA: 0x00776DBD File Offset: 0x007751BD
	public Mechanism2124(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180AF RID: 98479 RVA: 0x00776DC8 File Offset: 0x007751C8
	public override void OnInit()
	{
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true);
		this.bornPos.x = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.bornPos.y = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
		this.bornPos.z = TableManager.GetValueFromUnionCell(this.data.ValueC[2], this.level, true);
		this.openFrameSkillID = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
	}

	// Token: 0x060180B0 RID: 98480 RVA: 0x00776ED4 File Offset: 0x007752D4
	public override void OnStart()
	{
		this.RegistEvent();
		base.owner.DoSummon(this.monsterID, base.owner.GetEntityData().level, EffectTable.eSummonPosType.FACE, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, null, true);
	}

	// Token: 0x060180B1 RID: 98481 RVA: 0x00776F1C File Offset: 0x0077531C
	protected void RegistEvent()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, new BeEventHandle.Del(this.OnSummon));
	}

	// Token: 0x060180B2 RID: 98482 RVA: 0x00776F40 File Offset: 0x00775340
	protected void OnSummon(object[] args)
	{
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (beActor.GetEntityData() == null || !beActor.GetEntityData().MonsterIDEqual(this.monsterID) || beActor.IsDead())
		{
			return;
		}
		this.monster = beActor;
		beActor.SetFace(false, false, false);
		beActor.SetPosition(this.bornPos, true, true, false);
		if (base.owner.buffController != null)
		{
			base.owner.buffController.TryAddBuff(29, -1, 1);
		}
		if (base.owner.CurrentBeScene != null)
		{
			base.owner.CurrentBeScene.RemoveToTemp(base.owner);
		}
		if (base.owner.isLocalActor && beActor.actorData != null)
		{
			beActor.actorData.isSpecialMonster = true;
		}
		this.SwitchToMonster(beActor);
	}

	// Token: 0x060180B3 RID: 98483 RVA: 0x00777024 File Offset: 0x00775424
	protected void SwitchToMonster(BeActor monster)
	{
		this.player = base.owner;
		BattlePlayer battlePlayer = this.GetBattlePlayer(this.player);
		if (battlePlayer != null)
		{
			monster.isMainActor = this.player.isMainActor;
			monster.isLocalActor = this.player.isLocalActor;
			monster.pauseAI = this.player.pauseAI;
			monster.aiManager.isAutoFight = this.player.aiManager.isAutoFight;
			Dictionary<int, int> skillSlotMap = new Dictionary<int, int>();
			monster.skillSlotMap = skillSlotMap;
			battlePlayer.playerActor = monster;
			if (this.player != null && this.player.m_pkGeActor != null)
			{
				this.player.m_pkGeActor.HideActor(true);
				if (monster != null && monster.m_pkGeActor != null)
				{
					GameObject gameObject = Utility.FindChild(monster.m_pkGeActor.goInfoBar, "Name");
					if (null != gameObject)
					{
						Text component = gameObject.GetComponent<Text>();
						if (null != component)
						{
							component.text = this.player.GetEntityData().name;
						}
					}
					ComCharactorHPBar component2 = this.player.m_pkGeActor.goHPBarHUD.GetComponent<ComCharactorHPBar>();
					component2.SetIcon(monster.m_pkGeActor.EntityHeadIcon, monster.m_pkGeActor.EntityHeadIconMaterial);
				}
			}
			this.ChangeButtons(monster);
			if (this.player.pet != null && this.player.pet.m_pkGeActor != null)
			{
				this.player.pet.m_pkGeActor.SetActorVisible(false);
			}
			this.player.SetAttackButtonState(ButtonState.RELEASE, true);
			monster.SetAttackButtonState(ButtonState.RELEASE, true);
		}
	}

	// Token: 0x060180B4 RID: 98484 RVA: 0x007771C8 File Offset: 0x007755C8
	private BattlePlayer GetBattlePlayer(BeActor actor)
	{
		BattlePlayer result = null;
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i].playerActor == actor)
			{
				result = allPlayers[i];
				break;
			}
		}
		return result;
	}

	// Token: 0x060180B5 RID: 98485 RVA: 0x00777224 File Offset: 0x00775624
	private void ChangeButtons(BeActor monster)
	{
		if (!this.player.isLocalActor)
		{
			return;
		}
		if (InputManager.instance != null)
		{
			InputManager.instance.ReloadButtons(this.player.GetEntityData().professtion, monster, monster.skillSlotMap, true);
			InputManager.instance.SetVisible(false);
		}
		this.handleB = monster.RegisterEvent(BeEventType.onCastSkillFinish, new BeEventHandle.Del(this.OnFinishSkill));
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle != null && clientSystemBattle.IsDrugVisible())
		{
			clientSystemBattle.SetDrugVisible(false);
			clientSystemBattle.SetWeaponState(false);
			clientSystemBattle.CloseProfessionFrame();
			clientSystemBattle.SetMuscleShiftActive(false);
		}
		this.player.m_pkGeActor.isSyncHPMP = false;
	}

	// Token: 0x060180B6 RID: 98486 RVA: 0x007772E0 File Offset: 0x007756E0
	protected void OnFinishSkill(object[] args)
	{
		int num = (int)args[0];
		if (num != this.openFrameSkillID)
		{
			return;
		}
		if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamDungeonBattleCarFrame>(null))
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDungeonBattleCarFrame>(FrameLayer.Middle, this.skillID, string.Empty);
		}
		InputManager.instance.SetVisible(true, false);
	}

	// Token: 0x0401152A RID: 70954
	protected int monsterID;

	// Token: 0x0401152B RID: 70955
	protected VInt3 bornPos;

	// Token: 0x0401152C RID: 70956
	protected BeActor player;

	// Token: 0x0401152D RID: 70957
	protected BeActor monster;

	// Token: 0x0401152E RID: 70958
	protected int skillID;

	// Token: 0x0401152F RID: 70959
	protected int openFrameSkillID;
}
