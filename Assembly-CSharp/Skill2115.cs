using System;
using System.Collections.Generic;
using Battle;
using GameClient;
using GamePool;
using UnityEngine;

// Token: 0x0200448D RID: 17549
public class Skill2115 : BeSkill
{
	// Token: 0x06018658 RID: 99928 RVA: 0x0079AAB4 File Offset: 0x00798EB4
	public Skill2115(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018659 RID: 99929 RVA: 0x0079AB18 File Offset: 0x00798F18
	public override void OnInit()
	{
		this.monsterID = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.secondSkillID = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.monsterSkillID = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		if (this.skillData.ValueD.Length != 0)
		{
			this.m_HideBuffL.Clear();
			for (int i = 0; i < this.skillData.ValueD.Count; i++)
			{
				this.m_HideBuffL.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueD[i], base.level, true));
			}
		}
	}

	// Token: 0x0601865A RID: 99930 RVA: 0x0079ABF7 File Offset: 0x00798FF7
	public void Prepare()
	{
		this.state = Skill2115.State.SUMMON;
		this.buttonChanged = false;
		this.go = null;
		this.goParent = null;
		this.effect = null;
		this.RemoveUIEffect();
		this.RemoveHandler();
	}

	// Token: 0x0601865B RID: 99931 RVA: 0x0079AC28 File Offset: 0x00799028
	public override void OnStart()
	{
		this.Prepare();
		if (base.owner.IsDead())
		{
			return;
		}
		this.handler = base.owner.RegisterEvent(BeEventType.onSummon, delegate(object[] args)
		{
			if (base.owner.IsDead())
			{
				return;
			}
			BeActor monster = args[0] as BeActor;
			if (monster == null)
			{
				return;
			}
			if (!monster.GetEntityData().MonsterIDEqual(this.monsterID) || monster.IsDead())
			{
				return;
			}
			this.AddMechanism(monster);
			base.owner.TriggerEvent(BeEventType.onMagicGirlMonsterChange, new object[]
			{
				monster,
				base.owner
			});
			this.ChangeSummonerFollower(monster);
			monster.buffController.RemoveBuff(2, 0, 0);
			monster.buffController.TryAddBuff(29, GlobalLogic.VALUE_1500, 1);
			monster.SetFace(base.owner.GetFace(), false, false);
			monster.m_pkGeActor.SetHeadInfoVisible(false);
			monster.m_pkGeActor.SetFootIndicatorVisible(false);
			monster.SetRestrainPosition(false);
			VInt3 position = base.owner.GetPosition();
			VInt3 ownerOriginPos = position;
			position.x += base.owner._getFaceCoff() * VInt.one.i;
			bool faceDir = base.owner.GetFace();
			this.SetMoFaDunBuff(base.owner, true);
			monster.delayCaller.DelayCall(1000, delegate
			{
				monster.actionManager.StopAll();
				this.owner.buffController.TryAddBuff(29, -1, 1);
				monster.m_pkGeActor.SetHeadInfoVisible(true);
				monster.m_pkGeActor.SetFootIndicatorVisible(true);
				monster.SetRestrainPosition(true);
				Buff12 buff = monster.buffController.HasBuffByID(12) as Buff12;
				if (buff != null)
				{
					buff.showDisappearEffect = false;
				}
				if (monster.CurrentBeScene.IsInBlockPlayer(monster.GetPosition()))
				{
					VInt3 rkPos = BeAIManager.FindStandPositionNew(ownerOriginPos, monster.CurrentBeScene, faceDir, false, 12);
					monster.SetPosition(rkPos, false, true, false);
				}
				this.DoChangeToMonster(monster);
			}, 0, 0, false);
			monster.RegisterEvent(BeEventType.onDead, delegate(object[] args2)
			{
				this.DoRestoreFromMonster(monster);
				this.CreateBoomEntityId(this.owner, monster);
			});
		});
	}

	// Token: 0x0601865C RID: 99932 RVA: 0x0079AC60 File Offset: 0x00799060
	private void AddMechanism(BeActor monster)
	{
		Mechanism2004 mechanism = base.owner.GetMechanism(5300) as Mechanism2004;
		if (mechanism != null)
		{
			Mechanism2004 mechanism2 = monster.AddMechanism(5300, 0, MechanismSourceType.NONE, null, 0) as Mechanism2004;
			if (mechanism2 != null)
			{
				mechanism2.CopyMechanims(mechanism.GetResentmentValue(), mechanism.IsBetray());
			}
		}
	}

	// Token: 0x0601865D RID: 99933 RVA: 0x0079ACB8 File Offset: 0x007990B8
	private void RestoreMechanism(BeActor monster)
	{
		Mechanism2004 mechanism = base.owner.GetMechanism(5300) as Mechanism2004;
		if (mechanism != null)
		{
			Mechanism2004 mechanism2 = monster.GetMechanism(5300) as Mechanism2004;
			if (mechanism2 != null)
			{
				mechanism2.CopyMechanims(mechanism.GetResentmentValue(), mechanism.IsBetray());
				mechanism2.OnChangeResentmentValue(mechanism.GetResentmentValue());
			}
		}
	}

	// Token: 0x0601865E RID: 99934 RVA: 0x0079AD18 File Offset: 0x00799118
	private void DoChangeToMonster(BeActor monster)
	{
		if (this.state != Skill2115.State.SUMMON)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		this.SwitchToMonster(monster);
		VInt3 position = base.owner.GetPosition();
		position.y -= VInt.Float2VIntValue(0.5f);
		base.owner.SetPosition(position, true, true, false);
		if (base.owner.isLocalActor && base.owner.CurrentBeScene != null)
		{
			base.owner.CurrentBeScene.StopBlindMask();
		}
		base.owner.m_pkGeActor.ChangeAction("Anim_Zhaohuan_juexing_Idle", 1f, true, true, false);
		this.effect = base.owner.m_pkGeActor.CreateEffect("Effects/Hero_Zhaohuanshi/Zhaohuanshi_juexing/Prefab/Eff_Zhaohuanshi_juexing_bodyloop", "[actor]Body", 2147483.8f, Vec3.zero, 0.5f, 1f, true, false, EffectTimeType.SYNC_ANIMATION, false);
		this.AddUIEffect();
		this.go = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
		GameObject entityNode = monster.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root);
		this.goParent = this.go.transform.parent.gameObject;
		if (this.go != null && this.goParent != null)
		{
			GeUtility.AttachTo(this.go, entityNode, false);
		}
		monster.spirit = base.owner.m_pkGeActor;
		monster.RegisterEvent(BeEventType.onChangeFace, delegate(object[] args2)
		{
			this.SetSpiritPos(monster.GetFace(), this.go);
		});
		this.SetSpiritPos(monster.GetFace(), this.go);
		base.owner.CurrentBeScene.RemoveToTemp(base.owner);
		if (base.owner.isLocalActor)
		{
			monster.actorData.isSpecialMonster = true;
		}
	}

	// Token: 0x0601865F RID: 99935 RVA: 0x0079AF14 File Offset: 0x00799314
	private void DoRestoreFromMonster(BeActor monster)
	{
		if (this.state == Skill2115.State.TRANSFORM)
		{
			this.state = Skill2115.State.FINISH;
			monster.m_pkGeActor.SetActorVisible(false);
			this.SwitchBack(monster);
			base.owner.actionManager.StopAll();
			monster.spirit = null;
			base.owner.CurrentBeScene.RestoreFromTemp(base.owner);
			this.RestoreMechanism(monster);
			monster.TriggerEvent(BeEventType.onMagicGirlMonsterRestore, new object[]
			{
				base.owner,
				monster
			});
			this.ChangeSummonerFollower(base.owner);
			if (this.go != null && this.goParent != null)
			{
				GeUtility.AttachTo(this.go, this.goParent, false);
			}
			if (this.effect != null)
			{
				base.owner.m_pkGeActor.DestroyEffect(this.effect);
				this.effect = null;
			}
			this.RemoveUIEffect();
			if (base.owner.isLocalActor && base.owner.CurrentBeScene != null)
			{
				base.owner.CurrentBeScene.StopBlindMask();
			}
			base.owner.GetStateGraph().SetCurrentStateTag(3, true);
			base.owner.GetStateGraph().ResetCurrentStateTime();
			int num = base.owner.PlayAction("Qyzh_Kaxiliyasi_07", 1f);
			if (monster.GetMechanism(1468) != null)
			{
				num = 0;
			}
			base.owner.GetStateGraph().SetCurrentStatesTimeout(num, false);
			base.owner.delayCaller.DelayCall(num, delegate
			{
				this.RestoreOwner();
				if (this.owner.CurrentBeScene.IsInBlockPlayer(this.owner.GetPosition()))
				{
					VInt3 vint = BeAIManager.FindStandPositionNew(this.owner.GetPosition(), this.owner.CurrentBeScene, this.owner.GetFace(), false, 30);
					if (vint == this.owner.GetPosition() && !this.owner.CurrentBeScene.IsInBlockPlayer(monster.savedPosition))
					{
						monster.SetPosition(monster.savedPosition, false, true, false);
					}
					else
					{
						vint = BeAIManager.FindStandPositionNew(monster.savedPosition, this.owner.CurrentBeScene, this.owner.GetFace(), false, 30);
						this.owner.SetPosition(vint, false, true, false);
					}
				}
			}, 0, 0, false);
			base.owner.pauseAI = monster.pauseAI;
			base.owner.aiManager.isAutoFight = monster.aiManager.isAutoFight;
		}
		else if (this.state == Skill2115.State.SUMMON)
		{
			this.RestoreOwner();
		}
	}

	// Token: 0x06018660 RID: 99936 RVA: 0x0079B138 File Offset: 0x00799538
	private void AddUIEffect()
	{
		if (base.owner.isLocalActor)
		{
			this.RemoveUIEffect();
			this.uieffect = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_Zhaohuanshi_juexing/Prefab/EffUI_Zhaohuanshi_juexing_pinmu", true, 0U);
			if (this.uieffect != null)
			{
				Utility.AttachTo(this.uieffect, Singleton<ClientSystemManager>.instance.GetLayer(FrameLayer.TopMost), false);
			}
		}
	}

	// Token: 0x06018661 RID: 99937 RVA: 0x0079B19A File Offset: 0x0079959A
	private void RemoveUIEffect()
	{
		if (base.owner.isLocalActor && this.uieffect != null)
		{
			Object.Destroy(this.uieffect);
			this.uieffect = null;
		}
	}

	// Token: 0x06018662 RID: 99938 RVA: 0x0079B1D0 File Offset: 0x007995D0
	private void SetSpiritPos(bool faceLeft, GameObject target)
	{
		if (target == null)
		{
			return;
		}
		float num = (!faceLeft) ? -0.4f : 0.4f;
		target.transform.localPosition = new Vector3(num, 1.59f, -0.2f);
	}

	// Token: 0x06018663 RID: 99939 RVA: 0x0079B21C File Offset: 0x0079961C
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

	// Token: 0x06018664 RID: 99940 RVA: 0x0079B278 File Offset: 0x00799678
	public void SwitchToMonster(BeActor monster)
	{
		if (this.state == Skill2115.State.TRANSFORM)
		{
			return;
		}
		this.backupPlayer = base.owner;
		BattlePlayer battlePlayer = this.GetBattlePlayer(base.owner);
		if (battlePlayer != null)
		{
			monster.isMainActor = base.owner.isMainActor;
			monster.isLocalActor = base.owner.isLocalActor;
			monster.pauseAI = base.owner.pauseAI;
			monster.aiManager.isAutoFight = base.owner.aiManager.isAutoFight;
			monster.isSpecialMonster = true;
			monster.skillSlotMap = new Dictionary<int, int>
			{
				{
					1,
					5321
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
					5322
				},
				{
					5,
					5323
				},
				{
					6,
					5324
				}
			};
			this.backupPlayer.GetPosition().z = 0;
			battlePlayer.playerActor = monster;
			this.backupPlayer.SetRestrainPosition(false);
			monster.m_pkGeActor.SetActorVisible(true);
			this.backupPlayer.m_pkGeActor.SetFootIndicatorVisible(false);
			this.ChangeButtons(monster);
			this.backupPlayer.SetAttackButtonState(ButtonState.RELEASE, true);
			monster.SetAttackButtonState(ButtonState.RELEASE, true);
			monster.sgSwitchStates(new BeStateData(0, 0));
			monster.SetRestrainPosition(true);
			if (base.owner.pet != null)
			{
				if (base.owner.pet.m_pkGeActor != null)
				{
					base.owner.pet.m_pkGeActor.SetActorVisible(false);
				}
				else
				{
					Logger.LogErrorFormat("SwitchToMonster  pet.m_pkGeActor is null ,pet ResID:{0},MonsterID:{1}", new object[]
					{
						base.owner.pet.m_iResID,
						base.owner.pet.GetEntityData().monsterID
					});
				}
			}
		}
		this.state = Skill2115.State.TRANSFORM;
	}

	// Token: 0x06018665 RID: 99941 RVA: 0x0079B454 File Offset: 0x00799854
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
			this.backupPlayer.SetRestrainPosition(true);
			this.backupPlayer.SetPosition(position, false, true, false);
			this.backupPlayer.m_pkGeActor.SetActorVisible(true);
			this.backupPlayer.Reset();
			if (this.backupPlayer.m_pkGeActor != null)
			{
				this.backupPlayer.m_pkGeActor.SetFootIndicatorVisible(true);
				this.RestoreButtons();
				if (this.backupPlayer.pet != null)
				{
					if (this.backupPlayer.pet.m_pkGeActor != null)
					{
						this.backupPlayer.pet.m_pkGeActor.SetActorVisible(true);
					}
					else
					{
						Logger.LogErrorFormat("SwitchBack  pet.m_pkGeActor is null ,pet ResID:{0},MonsterID:{1}", new object[]
						{
							this.backupPlayer.pet.m_iResID,
							this.backupPlayer.pet.GetEntityData().monsterID
						});
					}
				}
			}
			else
			{
				Logger.LogErrorFormat("SwitchBack,backupPlayer.m_pkGeActor is null", new object[0]);
			}
			if (base.owner.IsDead())
			{
				this.ResetAttackBtnState(this.backupPlayer, monster);
			}
			else
			{
				base.owner.delayCaller.DelayCall(1000, delegate
				{
					this.ResetAttackBtnState(this.backupPlayer, monster);
				}, 0, 0, false);
			}
			this.backupPlayer.sgSwitchStates(new BeStateData(0, 0));
			battlePlayer.playerActor = this.backupPlayer;
		}
		this.state = Skill2115.State.FINISH;
	}

	// Token: 0x06018666 RID: 99942 RVA: 0x0079B61F File Offset: 0x00799A1F
	protected void ResetAttackBtnState(BeActor backUp, BeActor current)
	{
		if (backUp != null)
		{
			backUp.SetAttackButtonState(ButtonState.RELEASE, true);
		}
		if (current != null)
		{
			current.SetAttackButtonState(ButtonState.RELEASE, true);
		}
	}

	// Token: 0x06018667 RID: 99943 RVA: 0x0079B640 File Offset: 0x00799A40
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

	// Token: 0x06018668 RID: 99944 RVA: 0x0079B6F4 File Offset: 0x00799AF4
	private void RestoreButtons()
	{
		base.owner.delayCaller.DelayCall(1000, delegate
		{
			this.SetMoFaDunBuff(this.backupPlayer, false);
		}, 0, 0, false);
		if (!this.backupPlayer.isLocalActor)
		{
			return;
		}
		if (!this.buttonChanged)
		{
			return;
		}
		this.buttonChanged = false;
		if (base.owner.IsDead())
		{
			InputManager.instance.ReloadButtons(this.backupPlayer.GetEntityData().professtion, this.backupPlayer, null, false);
		}
		else
		{
			base.owner.delayCaller.DelayCall(1000, delegate
			{
				InputManager.instance.ReloadButtons(this.backupPlayer.GetEntityData().professtion, this.backupPlayer, null, false);
				this.ShowMofadunBtnEffect(this.backupPlayer);
			}, 0, 0, false);
		}
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

	// Token: 0x06018669 RID: 99945 RVA: 0x0079B80C File Offset: 0x00799C0C
	private void RestoreOwner()
	{
		base.owner.buffController.RemoveBuff(29, 0, 0);
		base.owner.GetStateGraph().ResetStateTag(0);
		base.owner.GetStateGraph().ResetCurrentStateTag();
		base.owner.sgSwitchStates(new BeStateData(0, 0));
		base.owner.SetScale(VInt.one);
		this.RestoreButtons();
	}

	// Token: 0x0601866A RID: 99946 RVA: 0x0079B876 File Offset: 0x00799C76
	private void Restore()
	{
		this.RemoveUIEffect();
		this.RemoveHandler();
	}

	// Token: 0x0601866B RID: 99947 RVA: 0x0079B884 File Offset: 0x00799C84
	private void RemoveHandler()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x0601866C RID: 99948 RVA: 0x0079B8A3 File Offset: 0x00799CA3
	public override void OnCancel()
	{
		this.Restore();
	}

	// Token: 0x0601866D RID: 99949 RVA: 0x0079B8AC File Offset: 0x00799CAC
	private void ChangeSummonerFollower(BeActor target)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.GetSummonBySummoner(list, base.owner, false, false);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			if (beActor != null && !beActor.IsDead() && beActor.aiManager != null)
			{
				beActor.aiManager.followTarget = target;
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x0601866E RID: 99950 RVA: 0x0079B928 File Offset: 0x00799D28
	private void SetMoFaDunBuff(BeActor actor, bool isHide = true)
	{
		if (actor == null)
		{
			return;
		}
		for (int i = 0; i < this.m_HideBuffL.Count; i++)
		{
			BeBuff beBuff = actor.buffController.HasBuffByID(this.m_HideBuffL[i]);
			if (beBuff != null)
			{
				GeEffectEx effectEx = beBuff.GetEffectEx();
				if (effectEx != null)
				{
					effectEx.SetVisible(!isHide);
				}
			}
		}
	}

	// Token: 0x0601866F RID: 99951 RVA: 0x0079B998 File Offset: 0x00799D98
	private void ShowMofadunBtnEffect(BeActor actor)
	{
		if (actor == null)
		{
			return;
		}
		BeSkill skill = actor.GetSkill(2113);
		BeBuff beBuff = actor.buffController.HasBuffByID(211301);
		if (skill != null && beBuff != null && skill.button != null)
		{
			skill.button.AddEffect(ETCButton.eEffectType.onContinue, true);
		}
	}

	// Token: 0x06018670 RID: 99952 RVA: 0x0079B9F4 File Offset: 0x00799DF4
	private void CreateBoomEntityId(BeActor actor, BeActor monster)
	{
		if (actor == null)
		{
			return;
		}
		if (monster == null)
		{
			return;
		}
		VInt3 position = monster.GetPosition();
		position.z += GlobalLogic.VALUE_10000;
		actor.AddEntity(this.m_BoomEntityId, position, base.level, 0);
	}

	// Token: 0x040119AD RID: 72109
	private int monsterID = 9080031;

	// Token: 0x040119AE RID: 72110
	private int secondSkillID = 2011;

	// Token: 0x040119AF RID: 72111
	private int monsterSkillID = 5323;

	// Token: 0x040119B0 RID: 72112
	private GameObject go;

	// Token: 0x040119B1 RID: 72113
	private GameObject goParent;

	// Token: 0x040119B2 RID: 72114
	private GeEffectEx effect;

	// Token: 0x040119B3 RID: 72115
	private GameObject uieffect;

	// Token: 0x040119B4 RID: 72116
	private bool needRestoreDrug;

	// Token: 0x040119B5 RID: 72117
	private bool buttonChanged;

	// Token: 0x040119B6 RID: 72118
	private BeActor backupPlayer;

	// Token: 0x040119B7 RID: 72119
	protected int m_BoomEntityId = 60128;

	// Token: 0x040119B8 RID: 72120
	private BeEventHandle handler;

	// Token: 0x040119B9 RID: 72121
	protected Skill2115.State state;

	// Token: 0x040119BA RID: 72122
	private const int m_MoFaDunBuffId = 211301;

	// Token: 0x040119BB RID: 72123
	private const int m_MoFaDunSkillId = 2113;

	// Token: 0x040119BC RID: 72124
	private List<int> m_HideBuffL = new List<int>(new int[]
	{
		211301,
		10090
	});

	// Token: 0x0200448E RID: 17550
	protected enum State
	{
		// Token: 0x040119BE RID: 72126
		SUMMON,
		// Token: 0x040119BF RID: 72127
		TRANSFORM,
		// Token: 0x040119C0 RID: 72128
		FINISH
	}
}
