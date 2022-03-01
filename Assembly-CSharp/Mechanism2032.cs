using System;
using System.Collections.Generic;
using Battle;
using GameClient;
using ProtoTable;
using UnityEngine;

// Token: 0x02004356 RID: 17238
public class Mechanism2032 : BeMechanism
{
	// Token: 0x06017DCD RID: 97741 RVA: 0x00760408 File Offset: 0x0075E808
	public Mechanism2032(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017DCE RID: 97742 RVA: 0x0076045C File Offset: 0x0075E85C
	public override void OnInit()
	{
		base.OnInit();
		this.xSpeed = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.ySpeed = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.monsterID = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.skillIDs = new int[this.data.ValueD.Length];
		for (int i = 0; i < this.skillIDs.Length; i++)
		{
			this.skillIDs[i] = TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true);
		}
	}

	// Token: 0x06017DCF RID: 97743 RVA: 0x00760548 File Offset: 0x0075E948
	public override void OnStart()
	{
		base.OnStart();
		this.RestoreSkill2115();
		this.InitSystem(false);
		if (base.owner != null && base.owner.isLocalActor && base.owner.CurrentBeScene != null)
		{
			base.owner.CurrentBeScene.TriggerEvent(BeEventSceneType.OnStartAirBattle, null);
		}
		if (base.owner.isSpecialMonster)
		{
			return;
		}
		this.MoveCamera();
		this.SetPosition();
		this.RegistSummonMonster();
		base.owner.DoSummon(this.monsterID, 1, EffectTable.eSummonPosType.FACE, null, 1, 0, 0, 0, 0, false, 0, 0, null, SummonDisplayType.NONE, null, true);
	}

	// Token: 0x06017DD0 RID: 97744 RVA: 0x007605EA File Offset: 0x0075E9EA
	private void RestoreSkill2115()
	{
		if (base.owner.isSpecialMonster)
		{
			base.owner.DoDead(false);
			base.owner.RegisterEvent(BeEventType.onRemove, delegate(object[] args)
			{
				BeActor beActor = base.owner.GetOwner() as BeActor;
				if (beActor != null)
				{
					beActor.AddMechanism(1468, 0, MechanismSourceType.NONE, null, 0);
				}
			});
		}
	}

	// Token: 0x06017DD1 RID: 97745 RVA: 0x00760624 File Offset: 0x0075EA24
	private void SetPosition()
	{
		VInt3[] array = new VInt3[3];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = base.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().GetAirBattleBornPos(i);
		}
		base.owner.SetPosition(array[this.GetSeat()], true, true, false);
	}

	// Token: 0x06017DD2 RID: 97746 RVA: 0x00760694 File Offset: 0x0075EA94
	private void InitSystem(bool flag)
	{
		if (base.owner.isLocalActor)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				clientSystemBattle.SetWeaponState(flag);
			}
		}
	}

	// Token: 0x06017DD3 RID: 97747 RVA: 0x007606D0 File Offset: 0x0075EAD0
	private int GetSeat()
	{
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (base.owner.GetPID() == allPlayers[i].playerActor.GetPID())
			{
				return (int)allPlayers[i].playerInfo.seat;
			}
		}
		return 0;
	}

	// Token: 0x06017DD4 RID: 97748 RVA: 0x0076073E File Offset: 0x0075EB3E
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
			monster.buffController.TryAddBuff(29, -1, 1);
			monster.SetFace(false, false, false);
			monster.SetPosition(base.owner.GetPosition(), true, true, false);
			monster.actionManager.StopAll();
			base.owner.SetFace(false, true, false);
			base.owner.buffController.TryAddBuff(29, -1, 1);
			base.owner.buffController.TryAddBuff(820004, -1, 1);
			this.DoChangeToMonster(monster);
			BeEventHandle item = monster.RegisterEvent(BeEventType.OnChangeSpeed, delegate(object[] obj)
			{
				VInt[] array = obj[0] as VInt[];
				if (array[1] < 0)
				{
					array[0] = this.xSpeed;
					array[1] = -this.ySpeed;
				}
				else if (array[1] > 0)
				{
					array[0] = -this.xSpeed;
					array[1] = this.ySpeed;
				}
				else
				{
					array[0] = 0;
				}
			});
			this.handList.Add(item);
			BeEventHandle item2 = monster.RegisterEvent(BeEventType.onYInBlock, delegate(object[] obj)
			{
				monster.SetMoveSpeedX(0);
				monster.SetMoveSpeedY(0);
				int[] array = obj[1] as int[];
				if (array != null)
				{
					array[1] = 1;
				}
			});
			this.handList.Add(item2);
			BeEventHandle item3 = monster.RegisterEvent(BeEventType.onChangeFace, delegate(object[] obj)
			{
				monster.SetFace(false, true, false);
			});
			this.handList.Add(item3);
		});
	}

	// Token: 0x06017DD5 RID: 97749 RVA: 0x00760760 File Offset: 0x0075EB60
	private void MoveCamera()
	{
		if (base.owner != null && base.owner.isLocalActor)
		{
			BeUtility.ResetCamera();
			base.owner.CurrentBeScene.DelayCaller.DelayCall(300, delegate
			{
				this.cameraCtrl = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController();
				this.cameraCtrl.SetPause(true);
				this.cameraCtrl.SetCameraPosition(this.cameraPos);
			}, 0, 0, false);
		}
	}

	// Token: 0x06017DD6 RID: 97750 RVA: 0x007607B7 File Offset: 0x0075EBB7
	public void EndAirBattle(int delayTime)
	{
		base.owner.CurrentBeScene.DelayCaller.DelayCall(delayTime, delegate
		{
			this.DoRestoreFromMonster(this.monster);
			base.owner.stateController.SetAbilityEnable(BeAbilityType.CAN_DO_SKILL_CMD, false);
			VInt3 position = base.owner.GetPosition();
			BeMoveTo action = BeMoveTo.Create(base.owner, 500, base.owner.GetPosition(), (new VInt3(-7f, base.owner.GetPosition().fy, 3f) + position) * 0.5f, true, null, false);
			base.owner.actionManager.RunAction(action);
			base.owner.CurrentBeScene.DelayCaller.DelayCall(500, delegate
			{
				BeMoveTo action2 = BeMoveTo.Create(base.owner, 500, base.owner.GetPosition(), new VInt3(-7f, base.owner.GetPosition().fy, 0f), true, null, false);
				base.owner.actionManager.RunAction(action2);
			}, 0, 0, false);
			base.owner.CurrentBeScene.DelayCaller.DelayCall(1000, delegate
			{
				base.owner.stateController.SetAbilityEnable(BeAbilityType.CAN_DO_SKILL_CMD, true);
			}, 0, 0, false);
			BeUtility.ResetCamera();
			if (base.owner != null && base.owner.isLocalActor)
			{
				base.owner.m_pkGeActor.ChangeAction("Anim_Houtiao", 0.4f, false, true, true);
				base.owner.CurrentBeScene.TriggerEvent(BeEventSceneType.OnEndAirBattle, null);
				this.InitSystem(true);
			}
		}, 0, 0, false);
	}

	// Token: 0x06017DD7 RID: 97751 RVA: 0x007607E0 File Offset: 0x0075EBE0
	private void DoChangeToMonster(BeActor monster)
	{
		if (base.owner.CurrentBeBattle != null && !base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.Mechanism2032ToIdle) && base.owner.sgGetCurrentState() == 14)
		{
			base.owner.CancelCurSkill();
		}
		this.SwitchToMonster(monster);
		this.go = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
		GameObject entityNode = monster.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
		this.goParent = this.go.transform.parent.gameObject;
		if (this.go != null && this.goParent != null)
		{
			GeUtility.AttachTo(this.go, entityNode, false);
		}
		this.go.transform.localPosition = new Vector3(-0.4f, 1.36f, 0f);
		base.owner.ResetMoveCmd();
		base.owner.CurrentBeScene.DelayCaller.DelayCall(0, delegate
		{
			base.owner.buffController.RemoveBuff(820004, 0, 0);
			base.owner.CurrentBeScene.RemoveToTemp(base.owner);
		}, 0, 0, false);
		if (base.owner.isLocalActor)
		{
			monster.actorData.isSpecialMonster = true;
		}
	}

	// Token: 0x06017DD8 RID: 97752 RVA: 0x0076091C File Offset: 0x0075ED1C
	public void SwitchToMonster(BeActor monster)
	{
		this.backupPlayer = base.owner;
		BattlePlayer battlePlayer = this.GetBattlePlayer(base.owner);
		if (battlePlayer != null)
		{
			monster.isMainActor = base.owner.isMainActor;
			monster.isLocalActor = base.owner.isLocalActor;
			monster.pauseAI = base.owner.pauseAI;
			monster.aiManager.isAutoFight = base.owner.aiManager.isAutoFight;
			monster.skillSlotMap = new Dictionary<int, int>
			{
				{
					1,
					this.skillIDs[0]
				},
				{
					2,
					-1
				},
				{
					3,
					-1
				},
				{
					4,
					this.skillIDs[1]
				}
			};
			battlePlayer.playerActor = monster;
			monster.m_pkGeActor.SetActorVisible(true);
			monster.m_pkGeActor.SetHPBarVisible(false);
			if (monster.m_pkGeActor.goInfoBar != null)
			{
				monster.m_pkGeActor.goInfoBar.SetActive(false);
			}
			this.ChangeButtons(monster);
			this.backupPlayer.SetAttackButtonState(ButtonState.RELEASE, true);
			monster.SetAttackButtonState(ButtonState.RELEASE, true);
			if (base.owner.pet != null)
			{
				base.owner.pet.m_pkGeActor.SetActorVisible(false);
			}
			this.handleB = monster.RegisterEvent(BeEventType.RaidBattleChangeMonster, new BeEventHandle.Del(this.RegisterDoublePress));
		}
	}

	// Token: 0x06017DD9 RID: 97753 RVA: 0x00760A78 File Offset: 0x0075EE78
	private void RegisterDoublePress(object[] args)
	{
		BeActor[] array = (BeActor[])args[0];
		if (array == null)
		{
			return;
		}
		if (array.Length <= 0)
		{
			return;
		}
		array[0] = this.backupPlayer;
	}

	// Token: 0x06017DDA RID: 97754 RVA: 0x00760AA8 File Offset: 0x0075EEA8
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
		InputManager.instance.ReloadButtons(this.backupPlayer.GetEntityData().professtion, monster, monster.skillSlotMap, true);
		ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle != null && clientSystemBattle.IsDrugVisible())
		{
			clientSystemBattle.SetDrugVisible(false);
			this.needRestoreDrug = true;
		}
		this.backupPlayer.m_pkGeActor.isSyncHPMP = false;
		this.buttonChanged = true;
	}

	// Token: 0x06017DDB RID: 97755 RVA: 0x00760B3C File Offset: 0x0075EF3C
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

	// Token: 0x06017DDC RID: 97756 RVA: 0x00760B98 File Offset: 0x0075EF98
	private void DoRestoreFromMonster(BeActor monster)
	{
		this.SwitchBack(monster);
		base.owner.SetFace(true, false, false);
		base.owner.actionManager.StopAll();
		monster.spirit = null;
		base.owner.CurrentBeScene.RestoreFromTemp(base.owner);
		if (this.go != null && this.goParent != null)
		{
			GeUtility.AttachTo(this.go, this.goParent, false);
		}
		this.RestoreOwner();
		base.owner.pauseAI = monster.pauseAI;
		base.owner.aiManager.isAutoFight = monster.aiManager.isAutoFight;
		this.RestoreButtons();
		if (base.owner.pet != null)
		{
			base.owner.pet.m_pkGeActor.SetActorVisible(true);
		}
	}

	// Token: 0x06017DDD RID: 97757 RVA: 0x00760C7C File Offset: 0x0075F07C
	public void SwitchBack(BeActor monster)
	{
		BattlePlayer battlePlayer = this.GetBattlePlayer(monster);
		if (battlePlayer != null)
		{
			monster.isMainActor = false;
			monster.isLocalActor = false;
			BeActor playerActor = battlePlayer.playerActor;
			this.backupPlayer.m_pkGeActor.SetActorVisible(true);
			this.backupPlayer.Reset();
			this.backupPlayer.SetAttackButtonState(ButtonState.RELEASE, true);
			monster.SetAttackButtonState(ButtonState.RELEASE, true);
			this.backupPlayer.sgSwitchStates(new BeStateData(0, 0));
			battlePlayer.playerActor = this.backupPlayer;
		}
	}

	// Token: 0x06017DDE RID: 97758 RVA: 0x00760CFC File Offset: 0x0075F0FC
	private void RestoreOwner()
	{
		base.owner.buffController.RemoveBuff(29, 0, 0);
		base.owner.GetStateGraph().ResetStateTag(0);
		base.owner.GetStateGraph().ResetCurrentStateTag();
		base.owner.sgSwitchStates(new BeStateData(0, 0));
	}

	// Token: 0x06017DDF RID: 97759 RVA: 0x00760D50 File Offset: 0x0075F150
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
		InputManager.instance.ReloadButtons(this.backupPlayer.GetEntityData().professtion, this.backupPlayer, null, false);
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

	// Token: 0x06017DE0 RID: 97760 RVA: 0x00760DE4 File Offset: 0x0075F1E4
	public override void OnFinish()
	{
		base.OnFinish();
		foreach (BeEventHandle beEventHandle in this.handList)
		{
			beEventHandle.Remove();
		}
		this.handList.Clear();
	}

	// Token: 0x040112C2 RID: 70338
	private int monsterID = 70720011;

	// Token: 0x040112C3 RID: 70339
	private BeActor backupPlayer;

	// Token: 0x040112C4 RID: 70340
	private bool needRestoreDrug;

	// Token: 0x040112C5 RID: 70341
	private bool buttonChanged;

	// Token: 0x040112C6 RID: 70342
	private GameObject go;

	// Token: 0x040112C7 RID: 70343
	private GameObject goParent;

	// Token: 0x040112C8 RID: 70344
	private VInt3 offset = default(VInt3);

	// Token: 0x040112C9 RID: 70345
	private BeActor monster;

	// Token: 0x040112CA RID: 70346
	private int xSpeed;

	// Token: 0x040112CB RID: 70347
	private int ySpeed;

	// Token: 0x040112CC RID: 70348
	private GeCameraControllerScroll cameraCtrl;

	// Token: 0x040112CD RID: 70349
	private List<BeEventHandle> handList = new List<BeEventHandle>();

	// Token: 0x040112CE RID: 70350
	private Vector3 cameraPos = new Vector3(12f, 5.2f, 0.25f);

	// Token: 0x040112CF RID: 70351
	private int[] skillIDs;
}
