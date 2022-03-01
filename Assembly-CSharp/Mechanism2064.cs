using System;
using System.Collections.Generic;
using GameClient;
using GamePool;

// Token: 0x02004378 RID: 17272
public class Mechanism2064 : BeMechanism
{
	// Token: 0x06017EF6 RID: 98038 RVA: 0x007694A0 File Offset: 0x007678A0
	public Mechanism2064(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017EF7 RID: 98039 RVA: 0x00769530 File Offset: 0x00767930
	public override void OnInit()
	{
		base.OnInit();
		this.totalTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.entityResId = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.totalQteCountArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		this.totalQteCountArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
		this.totalQteCountArr[2] = TableManager.GetValueFromUnionCell(this.data.ValueC[2], this.level, true);
		this.skillIdArr[0] = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		this.skillIdArr[1] = TableManager.GetValueFromUnionCell(this.data.ValueD[1], this.level, true);
		this.radiusArr[0] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true), GlobalLogic.VALUE_1000);
		this.radiusArr[1] = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueE[1], this.level, true), GlobalLogic.VALUE_1000);
		this.reduceTime = TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true);
	}

	// Token: 0x06017EF8 RID: 98040 RVA: 0x00769707 File Offset: 0x00767B07
	public override void OnStart()
	{
		base.OnStart();
		this.InitStartPos();
		this.InitPlayerData();
		this.InitTime();
		this.HideJoystickAndSkill(false);
	}

	// Token: 0x06017EF9 RID: 98041 RVA: 0x00769728 File Offset: 0x00767B28
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.HideJoystickAndSkill(false);
		this.UpdateProgressBar(deltaTime);
	}

	// Token: 0x06017EFA RID: 98042 RVA: 0x0076973F File Offset: 0x00767B3F
	public override void OnFinish()
	{
		base.OnFinish();
		this.JudgeResult();
		this.ClearHandles();
		this.RemoveStrainBuff();
		this.HideJoystickAndSkill(true);
		this.CloseSpecialFrame();
		this.ClearMonsters();
	}

	// Token: 0x06017EFB RID: 98043 RVA: 0x0076976C File Offset: 0x00767B6C
	private void InitStartPos()
	{
		this.posArr[0] = new VInt3(25000, 30000, 0);
		this.posArr[1] = new VInt3(-15000, 30000, 0);
		this.posArr[2] = new VInt3(65000, 30000, 0);
	}

	// Token: 0x06017EFC RID: 98044 RVA: 0x007697DC File Offset: 0x00767BDC
	private void InitPlayerData()
	{
		if (base.owner.CurrentBeBattle == null)
		{
			return;
		}
		if (base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		int num = 0;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BattlePlayer battlePlayer = allPlayers[i];
			if (battlePlayer != null)
			{
				BeActor playerActor = battlePlayer.playerActor;
				if (playerActor != null)
				{
					if (!playerActor.IsDead())
					{
						num++;
					}
					VInt3 vint = this.posArr[i];
					playerActor.SetPosition(vint, false, true, false);
					this.InitSummonMonster(playerActor, vint);
					this.InitLocalPlayerPos(playerActor);
					BeActor playerActor2 = allPlayers[i].playerActor;
					if (playerActor2 != null)
					{
						playerActor2.sgSwitchStates(new BeStateData(0, 0));
						this.playerActorList.Add(playerActor2);
						playerActor2.buffController.TryAddBuff(this.strainBuffId, GlobalLogic.VALUE_100000, 60);
						BeEventHandle item = playerActor2.RegisterEvent(BeEventType.onSyncDungeonOperation, new BeEventHandle.Del(this.OnSyncDungeonOperation));
						BeEventHandle item2 = playerActor2.RegisterEvent(BeEventType.onHit, new BeEventHandle.Del(this.RegisterBeHit));
						BeEventHandle item3 = playerActor2.RegisterEvent(BeEventType.onMagicGirlMonsterRestore, new BeEventHandle.Del(this.OnMagicGirlMonsterRestore));
						this.handleList.Add(item);
						this.handleList.Add(item2);
						this.handleList.Add(item3);
						this.InitLocalActorAttack(playerActor2);
						playerActor2.SetAttackButtonState(ButtonState.RELEASE, true);
						this.playerPosDic.Add(playerActor.GetPID(), vint);
					}
				}
			}
		}
		this.curTotalCount = this.totalQteCountArr[num - 1];
		this.RefreshCompleteNum();
	}

	// Token: 0x06017EFD RID: 98045 RVA: 0x007699A4 File Offset: 0x00767DA4
	private void InitSummonMonster(BeActor playerActor, VInt3 pos)
	{
		BeActor monster = base.owner.CurrentBeScene.SummonMonster(this.monsterId, pos, base.owner.m_iCamp, base.owner, false, 60, true, 0, false, false);
		if (playerActor.IsDead() && monster != null)
		{
			monster.aiManager.Stop();
			BeEventHandle item = playerActor.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
			{
				BeActor beActor = (BeActor)args[0];
				if (beActor != null)
				{
					beActor.buffController.RemoveBuff(this.strainBuffId, 0, 0);
					beActor.buffController.TryAddBuff(this.strainBuffId, GlobalLogic.VALUE_100000, 60);
				}
				monster.aiManager.Start();
			});
			this.handleList.Add(item);
		}
	}

	// Token: 0x06017EFE RID: 98046 RVA: 0x00769A3A File Offset: 0x00767E3A
	private void InitTime()
	{
		this.curTime = this.totalTime;
	}

	// Token: 0x06017EFF RID: 98047 RVA: 0x00769A48 File Offset: 0x00767E48
	private void RegisterBeHit(object[] args)
	{
		this.ReduceTime();
	}

	// Token: 0x06017F00 RID: 98048 RVA: 0x00769A50 File Offset: 0x00767E50
	private void OnMagicGirlMonsterRestore(object[] args)
	{
		BeActor beActor = (BeActor)args[0];
		if (beActor == null)
		{
			return;
		}
		if (beActor.isLocalActor)
		{
			this.localActor = beActor;
		}
		beActor.buffController.RemoveBuff(this.strainBuffId, 0, 0);
		beActor.buffController.TryAddBuff(this.strainBuffId, GlobalLogic.VALUE_100000, 60);
	}

	// Token: 0x06017F01 RID: 98049 RVA: 0x00769AAC File Offset: 0x00767EAC
	private void OnSyncDungeonOperation(object[] args)
	{
		int num = (int)args[0];
		int operationPid = (int)args[1];
		int num2 = (int)args[2];
		if (num != this.commandSkillId)
		{
			return;
		}
		if (num2 == 0)
		{
			this.ReduceTime();
			this.PlayAudio(false);
			this.PlayEffect("Effects/UI/Prefab/EffUI_tuanben/Prefab/Eff_tuanben_wanchengdu_jianmiao", operationPid, true);
			this.PlayEffect("Effects/Monster_TB02/Prefab/Eff_Monster_TB02_kexila_hongquan", operationPid, false);
			this.PlayUIEffect(false);
		}
		else
		{
			this.DoProjectilDie(num2);
			this.UpdateCompleteCount();
			this.PlayAudio(true);
			this.PlayEffect("Effects/UI/Prefab/EffUI_tuanben/Prefab/Eff_tuanben_wanchengdu_jiayi", operationPid, true);
			this.PlayEffect("Effects/Monster_TB02/Prefab/Eff_Monster_TB02_kexila_lvquan", operationPid, false);
			this.PlayUIEffect(true);
		}
	}

	// Token: 0x06017F02 RID: 98050 RVA: 0x00769B50 File Offset: 0x00767F50
	private void DoProjectilDie(int pid)
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.GetEntityByPID(pid) == null)
		{
			return;
		}
		BeProjectile beProjectile = base.owner.CurrentBeScene.GetEntityByPID(pid) as BeProjectile;
		if (beProjectile == null)
		{
			return;
		}
		if (beProjectile.IsDead())
		{
			return;
		}
		beProjectile.DoDie();
		this.PlayEffectBase("Effects/Monster_TB02/Prefab/Eff_Monster_TB02_kexila_suipianbaozha", beProjectile.GetPosition().vec3);
	}

	// Token: 0x06017F03 RID: 98051 RVA: 0x00769BCE File Offset: 0x00767FCE
	private void ReduceTime()
	{
		this.curTime -= this.reduceTime;
		this.AttackFail(this.reduceTime);
	}

	// Token: 0x06017F04 RID: 98052 RVA: 0x00769BEF File Offset: 0x00767FEF
	private void UpdateProgressBar(int deltaTime)
	{
		if (this.curTime <= 0)
		{
			this.SwitchSkill(false);
		}
		else
		{
			this.curTime -= deltaTime;
			this.RefreshProgressUI(deltaTime);
		}
	}

	// Token: 0x06017F05 RID: 98053 RVA: 0x00769C1E File Offset: 0x0076801E
	private void UpdateCompleteCount()
	{
		this.curQteCount++;
		this.RefreshCompleteNum();
		if (this.curQteCount >= this.curTotalCount)
		{
			this.successFlag = true;
			this.SwitchSkill(true);
		}
	}

	// Token: 0x06017F06 RID: 98054 RVA: 0x00769C53 File Offset: 0x00768053
	private void SendSyncOperationCommand(int pid)
	{
		if (this.localActor == null)
		{
			return;
		}
		InputManager.CreateSkillDoattackFrameCommand(this.commandSkillId, this.localActor.GetPID(), pid);
	}

	// Token: 0x06017F07 RID: 98055 RVA: 0x00769C78 File Offset: 0x00768078
	private void JudgeResult()
	{
		if (this.successFlag)
		{
			return;
		}
		this.SwitchSkill(false);
	}

	// Token: 0x06017F08 RID: 98056 RVA: 0x00769C90 File Offset: 0x00768090
	private void SwitchSkill(bool isSuccess)
	{
		if (this.finishFlag)
		{
			return;
		}
		this.finishFlag = true;
		base.owner.CancelSkill(base.owner.m_iCurSkillID, true);
		base.owner.UseSkill((!isSuccess) ? this.skillIdArr[1] : this.skillIdArr[0], true);
	}

	// Token: 0x06017F09 RID: 98057 RVA: 0x00769CF0 File Offset: 0x007680F0
	private void ClearMonsters()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindActorById2(list, this.monsterId, false);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].DoDead(false);
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x06017F0A RID: 98058 RVA: 0x00769D58 File Offset: 0x00768158
	private void RemoveStrainBuff()
	{
		for (int i = 0; i < this.playerActorList.Count; i++)
		{
			BeActor beActor = this.playerActorList[i];
			beActor.buffController.RemoveBuff(this.strainBuffId, 0, 0);
			beActor.buffController.TryAddBuff(63, 2000, 60);
		}
	}

	// Token: 0x06017F0B RID: 98059 RVA: 0x00769DB8 File Offset: 0x007681B8
	private void ClearHandles()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			if (this.handleList[i] != null)
			{
				this.handleList[i].Remove();
				this.handleList[i] = null;
			}
		}
		this.handleList.Clear();
	}

	// Token: 0x06017F0C RID: 98060 RVA: 0x00769E1B File Offset: 0x0076821B
	private void InitLocalPlayerPos(BeActor playerActor)
	{
		if (playerActor.isLocalActor)
		{
			this.localActorPos = playerActor.GetPosition();
			this.localActorPos.z = this.localActorPos.z + 7900;
		}
	}

	// Token: 0x06017F0D RID: 98061 RVA: 0x00769E4C File Offset: 0x0076824C
	private void InitLocalActorAttack(BeActor actor)
	{
		if (actor.isLocalActor)
		{
			this.localActor = actor;
			if (this.frame == null)
			{
				this.frame = (Singleton<ClientSystemManager>.instance.OpenFrame<TeamDungeonBattleFrame>(FrameLayer.Middle, null, string.Empty) as TeamDungeonBattleFrame);
			}
			if (this.frame != null)
			{
				this.frame.InitLiuXingData(this.totalTime);
				this.attackDel = new Mechanism2064.Del(this.OnDungeonAttack);
				this.frame.SetLiuXingAttackBtn(this.attackDel);
				this.frame.SetLiuXingCompleteNum(0, this.curTotalCount);
			}
		}
	}

	// Token: 0x06017F0E RID: 98062 RVA: 0x00769EE4 File Offset: 0x007682E4
	private void OnDungeonAttack()
	{
		if (this.localActor == null || this.localActor.IsDead())
		{
			return;
		}
		bool flag = false;
		List<BeEntity> list = ListPool<BeEntity>.Get();
		base.owner.CurrentBeScene.GetEntitys2(list);
		for (int i = 0; i < list.Count; i++)
		{
			BeProjectile beProjectile = list[i] as BeProjectile;
			if (beProjectile != null)
			{
				if (beProjectile.m_iResID == this.entityResId)
				{
					int magnitude = (beProjectile.GetPosition() - this.localActorPos).magnitude;
					if (magnitude >= this.radiusArr[0] && magnitude <= this.radiusArr[1])
					{
						this.SendSyncOperationCommand(beProjectile.GetPID());
						flag = true;
						break;
					}
				}
			}
		}
		if (!flag)
		{
			this.SendSyncOperationCommand(0);
		}
		ListPool<BeEntity>.Release(list);
	}

	// Token: 0x06017F0F RID: 98063 RVA: 0x00769FF1 File Offset: 0x007683F1
	private void HideJoystickAndSkill(bool isRestore = false)
	{
		InputManager.instance.SetVisible(isRestore);
	}

	// Token: 0x06017F10 RID: 98064 RVA: 0x00769FFE File Offset: 0x007683FE
	private void CloseSpecialFrame()
	{
		if (this.frame == null)
		{
			return;
		}
		this.frame.Close(false);
		this.frame = null;
	}

	// Token: 0x06017F11 RID: 98065 RVA: 0x0076A01F File Offset: 0x0076841F
	private void RefreshProgressUI(int reduceTime)
	{
		if (this.frame != null)
		{
			this.frame.RefreshLiuXingTime(reduceTime);
		}
	}

	// Token: 0x06017F12 RID: 98066 RVA: 0x0076A038 File Offset: 0x00768438
	private void AttackFail(int reduceTime)
	{
		if (this.frame != null)
		{
			this.frame.AttackFial(reduceTime);
		}
	}

	// Token: 0x06017F13 RID: 98067 RVA: 0x0076A051 File Offset: 0x00768451
	private void RefreshCompleteNum()
	{
		if (this.frame != null)
		{
			this.frame.SetLiuXingCompleteNum(this.curQteCount, this.curTotalCount);
		}
	}

	// Token: 0x06017F14 RID: 98068 RVA: 0x0076A078 File Offset: 0x00768478
	private void PlayEffect(string path, int operationPid, bool offsetFlag = false)
	{
		if (!this.playerPosDic.ContainsKey(operationPid))
		{
			return;
		}
		VInt3 vint = this.playerPosDic[operationPid];
		vint.z += 7900;
		if (offsetFlag)
		{
			vint.y -= 25000;
			vint.z += 11000;
		}
		this.PlayEffectBase(path, vint.vec3);
	}

	// Token: 0x06017F15 RID: 98069 RVA: 0x0076A0F4 File Offset: 0x007684F4
	private void PlayAudio(bool isSuccess = false)
	{
		int soundID = (!isSuccess) ? 5015 : 5014;
		MonoSingleton<AudioManager>.instance.PlaySound(soundID);
	}

	// Token: 0x06017F16 RID: 98070 RVA: 0x0076A124 File Offset: 0x00768524
	private void PlayEffectBase(string path, Vec3 pos)
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.currentGeScene == null)
		{
			return;
		}
		base.owner.CurrentBeScene.currentGeScene.CreateEffect(path, 0.267f, pos, 1f, 1f, false, false);
	}

	// Token: 0x06017F17 RID: 98071 RVA: 0x0076A181 File Offset: 0x00768581
	private void PlayUIEffect(bool isSuccess)
	{
		if (this.frame == null)
		{
			return;
		}
		this.frame.PlayAttackResultEffect(isSuccess);
	}

	// Token: 0x040113C1 RID: 70593
	private int totalTime = 40000;

	// Token: 0x040113C2 RID: 70594
	private int entityResId;

	// Token: 0x040113C3 RID: 70595
	private int[] totalQteCountArr = new int[3];

	// Token: 0x040113C4 RID: 70596
	private int[] skillIdArr = new int[2];

	// Token: 0x040113C5 RID: 70597
	private VInt[] radiusArr = new VInt[2];

	// Token: 0x040113C6 RID: 70598
	private int reduceTime;

	// Token: 0x040113C7 RID: 70599
	private VInt3[] posArr = new VInt3[3];

	// Token: 0x040113C8 RID: 70600
	private int commandSkillId = 21080;

	// Token: 0x040113C9 RID: 70601
	private int curTime;

	// Token: 0x040113CA RID: 70602
	private int curTotalCount;

	// Token: 0x040113CB RID: 70603
	private int curQteCount;

	// Token: 0x040113CC RID: 70604
	private int monsterId = 80320011;

	// Token: 0x040113CD RID: 70605
	private bool successFlag;

	// Token: 0x040113CE RID: 70606
	private List<BeActor> playerActorList = new List<BeActor>();

	// Token: 0x040113CF RID: 70607
	private int strainBuffId = 98;

	// Token: 0x040113D0 RID: 70608
	private VInt3 localActorPos;

	// Token: 0x040113D1 RID: 70609
	private Dictionary<int, VInt3> playerPosDic = new Dictionary<int, VInt3>();

	// Token: 0x040113D2 RID: 70610
	private BeActor localActor;

	// Token: 0x040113D3 RID: 70611
	private TeamDungeonBattleFrame frame;

	// Token: 0x040113D4 RID: 70612
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x040113D5 RID: 70613
	private bool finishFlag;

	// Token: 0x040113D6 RID: 70614
	private Mechanism2064.Del attackDel;

	// Token: 0x02004379 RID: 17273
	// (Invoke) Token: 0x06017F19 RID: 98073
	public delegate void Del();
}
