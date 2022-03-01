using System;
using System.Collections.Generic;
using GameClient;
using Network;
using Protocol;
using UnityEngine;

// Token: 0x0200437C RID: 17276
public class Mechanism2069 : BeMechanism
{
	// Token: 0x06017F28 RID: 98088 RVA: 0x0076A4F4 File Offset: 0x007688F4
	public Mechanism2069(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017F29 RID: 98089 RVA: 0x0076A5C0 File Offset: 0x007689C0
	public override void OnInit()
	{
		this.monsterIds.Clear();
		if (this.data.ValueA.Count > 0)
		{
			for (int i = 0; i < this.data.ValueA.Length; i++)
			{
				this.monsterIds.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
			}
		}
		int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (valueFromUnionCell != 0)
		{
			this.procedureMonsterId = valueFromUnionCell;
		}
	}

	// Token: 0x06017F2A RID: 98090 RVA: 0x0076A66C File Offset: 0x00768A6C
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (!this.bInited)
		{
			BeActor beActor = base.owner.CurrentBeScene.FindMonsterByID(this.procedureMonsterId);
			if (beActor != null && beActor.m_pkGeActor != null)
			{
				beActor.m_pkGeActor.HideActor(true);
			}
			this.CreateBossPhaseChange(1);
			this.bInited = true;
		}
	}

	// Token: 0x06017F2B RID: 98091 RVA: 0x0076A6D0 File Offset: 0x00768AD0
	public override void OnUpdateGraphic(int deltaTime)
	{
		if (Singleton<ReplayServer>.GetInstance() != null && Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (this.bInited && this.curSceneIndex >= 0 && this.curSceneIndex < 3 && base.owner != null && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonManager != null && !base.owner.CurrentBeBattle.dungeonManager.IsFinishFight() && FrameSync.instance != null)
		{
			this.preTime += deltaTime;
			if (this.preTime >= 2880)
			{
				this.preTime = 0;
				TeamCopyPhaseBossInfo teamCopyPhaseBossInfo = new TeamCopyPhaseBossInfo();
				if (ClientApplication.playerinfo != null)
				{
					teamCopyPhaseBossInfo.raceId = ClientApplication.playerinfo.session;
				}
				if (base.owner != null && base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.dungeonManager != null)
				{
					BattlePlayer mainPlayer = base.owner.CurrentBeBattle.dungeonPlayerManager.GetMainPlayer();
					if (mainPlayer != null)
					{
						teamCopyPhaseBossInfo.roleId = mainPlayer.playerInfo.roleId;
					}
				}
				teamCopyPhaseBossInfo.curFrame = FrameSync.instance.curFrame;
				teamCopyPhaseBossInfo.phase = (uint)(this.curSceneIndex + 1);
				BeActor beActor = base.owner.CurrentBeScene.FindMonsterByID(this.monsterIds[this.curSceneIndex]);
				if (beActor != null)
				{
					VFactor vfactor = new VFactor((long)(beActor.attribute.GetHP() * 100), (long)beActor.attribute.GetMaxHP());
					teamCopyPhaseBossInfo.bossBloodRate = (uint)vfactor.single;
					NetManager.Instance().SendCommand<TeamCopyPhaseBossInfo>(ServerType.GATE_SERVER, teamCopyPhaseBossInfo);
				}
			}
		}
	}

	// Token: 0x06017F2C RID: 98092 RVA: 0x0076A894 File Offset: 0x00768C94
	public void CreateBossPhaseChange(int phaseIndex)
	{
		if (FrameSync.instance != null)
		{
			BossPhaseChange cmd = new BossPhaseChange
			{
				phase = phaseIndex
			};
			FrameSync.instance.FireFrameCommand(cmd, true);
		}
		if (base.owner.GetRecordServer() != null && base.owner.IsProcessRecord())
		{
			base.owner.GetRecordServer().MarkInt(125269879U, new int[]
			{
				phaseIndex
			});
		}
	}

	// Token: 0x06017F2D RID: 98093 RVA: 0x0076A908 File Offset: 0x00768D08
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.handleA = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onMonsterDead, new BeEventHandle.Del(this.onMonsterDead));
	}

	// Token: 0x06017F2E RID: 98094 RVA: 0x0076A95A File Offset: 0x00768D5A
	public override void OnFinish()
	{
		base.OnFinish();
		this.delayHandle.SetRemove(true);
	}

	// Token: 0x06017F2F RID: 98095 RVA: 0x0076A970 File Offset: 0x00768D70
	private void onMonsterDead(object[] args)
	{
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		for (int i = 0; i < this.monsterIds.Count; i++)
		{
			if (beActor.GetEntityData() == null)
			{
				return;
			}
			if (beActor.GetEntityData().MonsterIDEqual(this.monsterIds[i]))
			{
				if (this.curSceneIndex + 1 >= this.sceneName.Length)
				{
					BeActor beActor2 = base.owner.CurrentBeScene.FindMonsterByID(this.procedureMonsterId);
					if (beActor2 != null)
					{
						beActor2.DoDead(false);
					}
					return;
				}
				if (base.owner.CurrentBeScene.currentGeScene != null)
				{
					GameObject sceneObject = base.owner.CurrentBeScene.currentGeScene.GetSceneObject();
					if (sceneObject != null && sceneObject.transform != null)
					{
						Transform transform = sceneObject.transform.Find(this.sceneName[this.curSceneIndex]);
						if (transform != null && transform.gameObject != null)
						{
							transform.gameObject.CustomActive(false);
						}
					}
				}
				this.curSceneIndex++;
				if (this.curSceneIndex >= this.sceneName.Length)
				{
					return;
				}
				this.CreateBossPhaseChange(this.curSceneIndex + 1);
				if (base.owner.CurrentBeScene.currentGeScene != null)
				{
					if (this.curSceneIndex == 1)
					{
						base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.effectPath[0], 4f, Vec3.zero, 1f, 1f, false, false);
						MonoSingleton<AudioManager>.instance.PlaySound(5004);
					}
					else if (this.curSceneIndex == 2)
					{
						base.owner.CurrentBeScene.currentGeScene.CreateEffect(this.effectPath[1], 4f, Vec3.zero, 1f, 1f, false, false);
						MonoSingleton<AudioManager>.instance.PlaySound(5003);
					}
				}
				if (beActor.m_pkGeActor != null)
				{
					beActor.m_pkGeActor.HideActor(true);
				}
				this.delayHandle = base.owner.CurrentBeScene.DelayCaller.DelayCall(1500, delegate
				{
					if (base.owner == null || base.owner.CurrentBeScene == null)
					{
						return;
					}
					if (base.owner.CurrentBeScene.currentGeScene != null)
					{
						GameObject sceneObject2 = base.owner.CurrentBeScene.currentGeScene.GetSceneObject();
						if (sceneObject2 != null && sceneObject2.transform != null)
						{
							Transform transform2 = sceneObject2.transform.Find(this.sceneName[this.curSceneIndex]);
							if (transform2 != null && transform2.gameObject != null)
							{
								transform2.gameObject.CustomActive(true);
							}
						}
					}
					BeActor beActor3 = base.owner.CurrentBeScene.CreateMonster(this.monsterIds[this.curSceneIndex] + base.owner.GetEntityData().GetLevel() * 100, this.monsterBornPos[this.curSceneIndex]);
					if (beActor3 != null)
					{
						beActor3.StartAI(null, false);
					}
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x040113DC RID: 70620
	private List<int> monsterIds = new List<int>();

	// Token: 0x040113DD RID: 70621
	private DelayCallUnitHandle delayHandle;

	// Token: 0x040113DE RID: 70622
	private string[] effectPath = new string[]
	{
		"Effects/Monster_TB02/Prefab/Eff_Monster_TB02_meimeng",
		"Effects/Monster_TB02/Prefab/Eff_Monster_TB02_emeng"
	};

	// Token: 0x040113DF RID: 70623
	private string[] sceneName = new string[]
	{
		"1haidi",
		"2meimeng",
		"3emeng"
	};

	// Token: 0x040113E0 RID: 70624
	private VInt3[] monsterBornPos = new VInt3[]
	{
		new VInt3(15869, 67344, 0),
		new VInt3(17049, 67783, 0),
		new VInt3(28400, 200300, 0)
	};

	// Token: 0x040113E1 RID: 70625
	private int curSceneIndex;

	// Token: 0x040113E2 RID: 70626
	private bool bInited;

	// Token: 0x040113E3 RID: 70627
	private int procedureMonsterId = 80620011;

	// Token: 0x040113E4 RID: 70628
	private int preTime;
}
