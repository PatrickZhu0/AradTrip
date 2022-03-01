using System;
using System.Collections.Generic;
using Battle;
using GameClient;
using GamePool;
using UnityEngine;

// Token: 0x02004221 RID: 16929
public class Buff2000020 : BeBuff
{
	// Token: 0x060176F1 RID: 95985 RVA: 0x00733218 File Offset: 0x00731618
	public Buff2000020(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
	}

	// Token: 0x060176F2 RID: 95986 RVA: 0x00733280 File Offset: 0x00731680
	public override void OnInit()
	{
		base.OnInit();
		this.totalTime = TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true);
		this.monsterId = TableManager.GetValueFromUnionCell(this.buffData.ValueB[0], this.level, true);
		this.radius = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.buffData.ValueC[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x060176F3 RID: 95987 RVA: 0x00733315 File Offset: 0x00731715
	public override void OnStart()
	{
		base.OnStart();
		this.curTotalTime = this.totalTime;
		this.curCheckTargetTime = this.checkTargetTime;
		this.CreateCountDownPrefab();
		this.JudgeMagicGirl();
		this.JudgeMagicGirlMonster();
	}

	// Token: 0x060176F4 RID: 95988 RVA: 0x00733347 File Offset: 0x00731747
	private void JudgeMagicGirl()
	{
		if (base.owner.professionID != 33)
		{
			return;
		}
		this.changeHandle = base.owner.RegisterEvent(BeEventType.onMagicGirlMonsterChange, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null)
			{
				this.PassBuff(beActor, base.GetLeftTime());
				base.Finish();
			}
		});
	}

	// Token: 0x060176F5 RID: 95989 RVA: 0x0073337E File Offset: 0x0073177E
	private void JudgeMagicGirlMonster()
	{
		if (!base.owner.GetEntityData().MonsterIDEqual(this.magicMonsterId))
		{
			return;
		}
		this.restoreHandle = base.owner.RegisterEvent(BeEventType.onMagicGirlMonsterRestore, delegate(object[] args)
		{
			BeActor beActor = args[0] as BeActor;
			if (beActor != null)
			{
				this.PassBuff(beActor, base.GetLeftTime());
				base.Finish();
			}
		});
	}

	// Token: 0x060176F6 RID: 95990 RVA: 0x007333BE File Offset: 0x007317BE
	public void SetTotalTime(int time)
	{
		this.curTotalTime = time;
	}

	// Token: 0x060176F7 RID: 95991 RVA: 0x007333C7 File Offset: 0x007317C7
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		this.UpdateTotalTime(deltaTime);
		this.UpdateCheckTarget(deltaTime);
	}

	// Token: 0x060176F8 RID: 95992 RVA: 0x007333E0 File Offset: 0x007317E0
	private void UpdateCheckTarget(int deltaTime)
	{
		if (this.curCheckTargetTime <= 0)
		{
			this.curCheckTargetTime = this.checkTargetTime;
			List<BeEntity> list = ListPool<BeEntity>.Get();
			base.owner.CurrentBeScene.GetEntitys2(list);
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					BeActor beActor = list[i] as BeActor;
					if (beActor != null && !beActor.IsDead() && !beActor.IsRemoved())
					{
						if (beActor != base.owner)
						{
							if (beActor.IsBoss() || beActor.professionID != 0)
							{
								if ((beActor.GetPosition() - base.owner.GetPosition()).magnitude > this.radius)
								{
									this.UpdateOutRangeTarget(beActor);
								}
								else if (this.outRangeList.Contains(beActor))
								{
									this.PassBuff(beActor, this.duration);
									if (this.passFlag)
									{
										break;
									}
								}
							}
						}
					}
				}
			}
			ListPool<BeEntity>.Release(list);
			if (this.passFlag)
			{
				base.Finish();
			}
		}
		else
		{
			this.curCheckTargetTime -= deltaTime;
		}
	}

	// Token: 0x060176F9 RID: 95993 RVA: 0x00733534 File Offset: 0x00731934
	private void UpdateOutRangeTarget(BeActor actor)
	{
		if (this.outRangeList.Contains(actor))
		{
			return;
		}
		this.outRangeList.Add(actor);
	}

	// Token: 0x060176FA RID: 95994 RVA: 0x00733554 File Offset: 0x00731954
	private void CreateCountDownPrefab()
	{
		this.countDownPrefab = Singleton<CGameObjectPool>.instance.GetGameObject(this.countDownPath, enResourceType.BattleScene, 2U);
		if (this.countDownPrefab != null)
		{
			ShowCountDownComponent component = this.countDownPrefab.GetComponent<ShowCountDownComponent>();
			component.InitData((int)((float)base.GetLeftTime() / 1000f));
			if (base.owner.m_pkGeActor != null)
			{
				GeUtility.AttachTo(this.countDownPrefab, base.owner.m_pkGeActor.goInfoBar, false);
				Vector3 buffOriginLocalPosition = base.owner.m_pkGeActor.buffOriginLocalPosition;
				if (base.owner.IsBoss())
				{
					buffOriginLocalPosition.y += 50f;
				}
				this.countDownPrefab.transform.localPosition = buffOriginLocalPosition;
			}
		}
	}

	// Token: 0x060176FB RID: 95995 RVA: 0x0073361B File Offset: 0x00731A1B
	private void UpdateTotalTime(int deltaTime)
	{
		if (this.curTotalTime <= 0)
		{
			base.Finish();
		}
		else
		{
			this.curTotalTime -= deltaTime;
		}
	}

	// Token: 0x060176FC RID: 95996 RVA: 0x00733644 File Offset: 0x00731A44
	protected void CreateBoomEntity(int summonID)
	{
		if (base.owner.IsDead())
		{
			return;
		}
		BeActor boss = this.GetBoss();
		if (boss == null)
		{
			return;
		}
		int monsterID = boss.GenNewMonsterID(summonID, boss.GetEntityData().level);
		BeActor beActor = boss.CurrentBeScene.SummonMonster(monsterID, base.owner.GetPosition(), boss.GetCamp(), null, false, 0, true, 0, false, false);
		if (base.owner.IsBoss() && beActor != null)
		{
			beActor.stateController.SetAbilityEnable(BeAbilityType.ATTACK_FRIEND_ENEMY, false);
		}
	}

	// Token: 0x060176FD RID: 95997 RVA: 0x007336D4 File Offset: 0x00731AD4
	protected BeActor GetBoss()
	{
		BeActor result = null;
		List<BeActor> list = ListPool<BeActor>.Get();
		base.owner.CurrentBeScene.FindBoss(list);
		if (list.Count > 0)
		{
			result = list[0];
		}
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x060176FE RID: 95998 RVA: 0x00733718 File Offset: 0x00731B18
	protected virtual void PassBuff(BeActor target, int time)
	{
		Buff2000020 buff = target.buffController.TryAddBuff(2000020, time, this.level) as Buff2000020;
		if (buff != null)
		{
			this.passFlag = true;
			buff.SetTotalTime(this.curTotalTime);
		}
	}

	// Token: 0x060176FF RID: 95999 RVA: 0x00733760 File Offset: 0x00731B60
	public override void OnFinish()
	{
		base.OnFinish();
		if (!this.passFlag)
		{
			this.CreateBoomEntity(this.monsterId);
			BeActor boss = this.GetBoss();
			if (boss == null)
			{
				return;
			}
			boss.Locomote(new BeStateData(0, 0), true);
		}
		if (this.countDownPrefab != null)
		{
			Object.Destroy(this.countDownPrefab);
		}
		this.outRangeList.Clear();
		this.RemoveHandle();
	}

	// Token: 0x06017700 RID: 96000 RVA: 0x007337D3 File Offset: 0x00731BD3
	private void RemoveHandle()
	{
		if (this.changeHandle != null)
		{
			this.changeHandle.Remove();
			this.changeHandle = null;
		}
		if (this.restoreHandle != null)
		{
			this.restoreHandle.Remove();
			this.restoreHandle = null;
		}
	}

	// Token: 0x04010D32 RID: 68914
	private int totalTime = 25000;

	// Token: 0x04010D33 RID: 68915
	private int monsterId = 60011;

	// Token: 0x04010D34 RID: 68916
	private VInt radius = VInt.zero;

	// Token: 0x04010D35 RID: 68917
	protected int curTotalTime;

	// Token: 0x04010D36 RID: 68918
	private readonly int checkTargetTime = 1000;

	// Token: 0x04010D37 RID: 68919
	private int curCheckTargetTime;

	// Token: 0x04010D38 RID: 68920
	private string countDownPath = "UIFlatten/Prefabs/BattleUI/FeatherBuffText";

	// Token: 0x04010D39 RID: 68921
	private GameObject countDownPrefab;

	// Token: 0x04010D3A RID: 68922
	protected bool passFlag;

	// Token: 0x04010D3B RID: 68923
	private int magicMonsterId = 9080031;

	// Token: 0x04010D3C RID: 68924
	private BeEventHandle changeHandle;

	// Token: 0x04010D3D RID: 68925
	private BeEventHandle restoreHandle;

	// Token: 0x04010D3E RID: 68926
	private List<BeActor> outRangeList = new List<BeActor>();
}
