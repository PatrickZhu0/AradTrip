using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x02004252 RID: 16978
public class Mechanism1012 : BeMechanism
{
	// Token: 0x060177D5 RID: 96213 RVA: 0x00739499 File Offset: 0x00737899
	public Mechanism1012(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060177D6 RID: 96214 RVA: 0x007394BC File Offset: 0x007378BC
	public override void OnInit()
	{
		base.OnInit();
		int count = this.data.ValueA.Count;
		for (int i = 0; i < count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[i], 1, true);
			if (valueFromUnionCell > 0)
			{
				this.skillIDList.Add(valueFromUnionCell);
			}
		}
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x060177D7 RID: 96215 RVA: 0x00739548 File Offset: 0x00737948
	public override void OnStart()
	{
		base.OnStart();
		this.RegistSummonMonster();
		base.owner.DoSummon(this.monsterID, 1, EffectTable.eSummonPosType.FACE, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, null, true);
	}

	// Token: 0x060177D8 RID: 96216 RVA: 0x00739582 File Offset: 0x00737982
	private void RegistSummonMonster()
	{
		this.handleA = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			BeActor monster = args[0] as BeActor;
			if (monster == null)
			{
				return;
			}
			if (!monster.GetEntityData().MonsterIDEqual(this.monsterID) || monster.IsDead())
			{
				return;
			}
			this.monster = monster;
			monster.stateController.SetAbilityEnable(BeAbilityType.CANATTACKFRIEND, false);
			base.owner.CancelSkill(base.owner.GetCurSkillID(), true);
			monster.SetFace(base.owner.GetFace(), false, false);
			monster.m_pkGeActor.SetHeadInfoVisible(false);
			monster.m_pkGeActor.SetFootIndicatorVisible(false);
			monster.SetPosition(base.owner.GetPosition(), true, true, false);
			monster.actionManager.StopAll();
			base.owner.buffController.TryAddBuff(29, -1, 1);
			base.owner.buffController.TryAddBuff(820004, -1, 1);
			this.DoChangeToMonster(monster);
			if (this.attachBuff != null)
			{
				monster.CurrentBeScene.DelayCaller.DelayCall(this.attachBuff.duration, delegate
				{
					this.owner.buffController.RemoveBuff(this.attachBuff);
				}, 0, 0, false);
			}
			monster.RegisterEvent(BeEventType.onDead, delegate(object[] obj)
			{
				if (!this.isTimeUp)
				{
					this.owner.buffController.RemoveBuff(this.attachBuff);
					this.owner.DoDead(false);
				}
				monster.m_pkGeActor.SetActorVisible(false);
				this.owner.SetPosition(monster.GetPosition(), true, true, false);
				this.owner.SetFace(true, false, false);
				this.owner.actionManager.StopAll();
				monster.spirit = null;
				this.owner.CurrentBeScene.RestoreFromTemp(this.owner);
				if (this.go != null)
				{
					this.go.CustomActive(true);
				}
				this.RestoreButtons();
				if (this.owner.pet != null && this.owner.pet.m_pkGeActor != null)
				{
					this.owner.pet.m_pkGeActor.SetActorVisible(true);
				}
				this.RestoreOwner();
				this.owner.pauseAI = monster.pauseAI;
				if (monster.aiManager != null && this.owner.aiManager != null)
				{
					this.owner.aiManager.isAutoFight = monster.aiManager.isAutoFight;
				}
			});
			monster.RegisterEvent(BeEventType.onBeHitAfterFinalDamage, delegate(object[] obj)
			{
				int[] array = obj[0] as int[];
				if (this.backupPlayer != null)
				{
					this.backupPlayer.DoHPChange(-array[0], false);
				}
			});
		});
	}

	// Token: 0x060177D9 RID: 96217 RVA: 0x007395A4 File Offset: 0x007379A4
	private void DoChangeToMonster(BeActor monster)
	{
		this.SwitchToMonster(monster);
		this.go = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
		this.go.CustomActive(false);
		base.owner.CurrentBeScene.DelayCaller.DelayCall(0, delegate
		{
			base.owner.buffController.RemoveBuff(820004, 0, 0);
			base.owner.CurrentBeScene.RemoveToTemp(base.owner);
		}, 0, 0, false);
		monster.isSpecialMonster = true;
	}

	// Token: 0x060177DA RID: 96218 RVA: 0x00739608 File Offset: 0x00737A08
	public void SwitchToMonster(BeActor monster)
	{
		this.backupPlayer = base.owner;
		BattlePlayer battlePlayer = this.GetBattlePlayer(base.owner);
		if (battlePlayer != null)
		{
			if (monster.attribute != null && this.backupPlayer.attribute != null)
			{
				monster.attribute.SetMaxHP(this.backupPlayer.attribute.GetMaxHP());
				monster.attribute.SetHP(this.backupPlayer.attribute.GetHP());
				this.backUpAttackID = this.backupPlayer.attribute.normalAttackID;
				monster.attribute.normalAttackID = this.skillIDList[0];
			}
			monster.isMainActor = base.owner.isMainActor;
			monster.isLocalActor = base.owner.isLocalActor;
			monster.pauseAI = base.owner.pauseAI;
			if (monster.aiManager != null && base.owner.aiManager != null)
			{
				monster.aiManager.isAutoFight = base.owner.aiManager.isAutoFight;
			}
			monster.skillSlotMap = new Dictionary<int, int>
			{
				{
					1,
					this.skillIDList[0]
				},
				{
					2,
					-1
				},
				{
					3,
					-1
				}
			};
			battlePlayer.playerActor = monster;
			if (monster.m_pkGeActor != null)
			{
				monster.m_pkGeActor.SetActorVisible(true);
			}
			this.backupPlayer.SetAttackButtonState(ButtonState.RELEASE, true);
			monster.SetAttackButtonState(ButtonState.RELEASE, true);
			monster.sgSwitchStates(new BeStateData(0, 0));
			this.ChangeButtons(monster);
			if (base.owner.pet != null && base.owner.pet.m_pkGeActor != null)
			{
				base.owner.pet.m_pkGeActor.SetActorVisible(false);
			}
		}
	}

	// Token: 0x060177DB RID: 96219 RVA: 0x007397D0 File Offset: 0x00737BD0
	private void ChangeButtons(BeActor monster)
	{
		if (!this.backupPlayer.isLocalActor)
		{
			return;
		}
		if (this.buttonChanged)
		{
			return;
		}
		InputManager.instance.SetButtonStateActive(0);
		base.owner.CurrentBeBattle.dungeonManager.GetGeScene().AttachCameraTo(monster.m_pkGeActor);
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle != null && clientSystemBattle.IsDrugVisible())
		{
			clientSystemBattle.SetDrugVisible(false);
			this.needRestoreDrug = true;
		}
		this.backupPlayer.m_pkGeActor.isSyncHPMP = false;
		this.buttonChanged = true;
	}

	// Token: 0x060177DC RID: 96220 RVA: 0x0073986C File Offset: 0x00737C6C
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

	// Token: 0x060177DD RID: 96221 RVA: 0x007398C8 File Offset: 0x00737CC8
	private void DoRestoreFromMonster(BeActor monster)
	{
		this.isTimeUp = true;
		this.SwitchBack(monster);
		monster.DoDead(false);
	}

	// Token: 0x060177DE RID: 96222 RVA: 0x007398E0 File Offset: 0x00737CE0
	public void SwitchBack(BeActor monster)
	{
		BattlePlayer battlePlayer = this.GetBattlePlayer(monster);
		if (battlePlayer != null)
		{
			monster.isMainActor = false;
			monster.isLocalActor = false;
			BeActor playerActor = battlePlayer.playerActor;
			VInt3 position = playerActor.GetPosition();
			position.z = 0;
			if (this.backupPlayer.attribute != null)
			{
				this.backupPlayer.attribute.normalAttackID = this.backUpAttackID;
			}
			this.backupPlayer.SetPosition(position, false, true, false);
			this.backupPlayer.m_pkGeActor.SetActorVisible(true);
			this.backupPlayer.Reset();
			this.backupPlayer.SetAttackButtonState(ButtonState.RELEASE, true);
			monster.SetAttackButtonState(ButtonState.RELEASE, true);
			this.backupPlayer.sgSwitchStates(new BeStateData(0, 0));
			battlePlayer.playerActor = this.backupPlayer;
		}
	}

	// Token: 0x060177DF RID: 96223 RVA: 0x007399A4 File Offset: 0x00737DA4
	private void RestoreOwner()
	{
		base.owner.buffController.RemoveBuff(29, 0, 0);
		base.owner.GetStateGraph().ResetStateTag(0);
		base.owner.GetStateGraph().ResetCurrentStateTag();
		base.owner.sgSwitchStates(new BeStateData(0, 0));
		base.owner.SetScale(VInt.one);
	}

	// Token: 0x060177E0 RID: 96224 RVA: 0x00739A08 File Offset: 0x00737E08
	private void RestoreButtons()
	{
		if (!this.backupPlayer.isLocalActor)
		{
			return;
		}
		if (!this.buttonChanged)
		{
			return;
		}
		this.buttonChanged = false;
		InputManager.instance.ResetButtonState();
		this.backupPlayer.CurrentBeBattle.dungeonManager.GetGeScene().AttachCameraTo(this.backupPlayer.m_pkGeActor);
		if (this.needRestoreDrug)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetDrugVisible(true);
				this.needRestoreDrug = false;
			}
		}
		this.backupPlayer.m_pkGeActor.isSyncHPMP = true;
	}

	// Token: 0x060177E1 RID: 96225 RVA: 0x00739AA8 File Offset: 0x00737EA8
	public override void OnFinish()
	{
		base.OnFinish();
		this.DoRestoreFromMonster(this.monster);
	}

	// Token: 0x04010E10 RID: 69136
	private List<int> skillIDList = new List<int>();

	// Token: 0x04010E11 RID: 69137
	private int monsterID = 9080031;

	// Token: 0x04010E12 RID: 69138
	private BeActor backupPlayer;

	// Token: 0x04010E13 RID: 69139
	private bool needRestoreDrug;

	// Token: 0x04010E14 RID: 69140
	private bool buttonChanged;

	// Token: 0x04010E15 RID: 69141
	private GameObject go;

	// Token: 0x04010E16 RID: 69142
	private GameObject goParent;

	// Token: 0x04010E17 RID: 69143
	private BeActor monster;

	// Token: 0x04010E18 RID: 69144
	private bool isTimeUp;

	// Token: 0x04010E19 RID: 69145
	private int backUpAttackID;
}
