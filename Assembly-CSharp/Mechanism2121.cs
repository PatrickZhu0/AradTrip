using System;
using GameClient;
using UnityEngine;

// Token: 0x020043B5 RID: 17333
public class Mechanism2121 : BeMechanism
{
	// Token: 0x0601809F RID: 98463 RVA: 0x0077650A File Offset: 0x0077490A
	public Mechanism2121(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180A0 RID: 98464 RVA: 0x00776530 File Offset: 0x00774930
	public override void OnInit()
	{
		this.m_monsterID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_isPlayer = (TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) != 0);
		this.m_SlowTime = (double)TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) / 1000.0;
		this.m_effectPath = this.data.StringValueA[0];
	}

	// Token: 0x060180A1 RID: 98465 RVA: 0x007765E3 File Offset: 0x007749E3
	public override void OnStart()
	{
		this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onHurtEntity, new BeEvent.BeEventHandleNew.Function(this._onHurtEntity));
	}

	// Token: 0x060180A2 RID: 98466 RVA: 0x0077660C File Offset: 0x00774A0C
	public override void OnUpdateGraphic(int deltaTime)
	{
		base.OnUpdateGraphic(deltaTime);
		if (this.m_EndTimeStamp > 0.0)
		{
			double timeStamp = Utility.GetTimeStamp();
			if (timeStamp - this.m_EndTimeStamp >= this.m_SlowTime)
			{
				Time.timeScale = 1f;
				this.m_EndTimeStamp = -1.0;
			}
		}
	}

	// Token: 0x060180A3 RID: 98467 RVA: 0x00776668 File Offset: 0x00774A68
	private void _onHurtEntity(BeEvent.BeEventParam param)
	{
		if (base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonManager == null)
		{
			return;
		}
		BeActor beActor = param.m_Obj as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (beActor != null && beActor.IsMonster() && beActor.GetEntityData() != null && beActor.GetEntityData().MonsterIDEqual(this.m_monsterID))
		{
			param.m_Int = 0;
		}
		if (base.owner.CurrentBeBattle.dungeonManager.IsFinishFight())
		{
			return;
		}
		BeActor beActor2 = param.m_Obj2 as BeActor;
		if (beActor2 == null)
		{
			return;
		}
		if (beActor2.GetPID() != base.owner.GetPID())
		{
			return;
		}
		if (beActor.IsMonster() && beActor.GetEntityData() != null && beActor.GetEntityData().MonsterIDEqual(this.m_monsterID))
		{
			this.m_EndTimeStamp = Utility.GetTimeStamp();
			Time.timeScale = Global.Settings.bullteScale;
			if (!this.m_isPlayer)
			{
				base.owner.CurrentBeBattle.OnCriticalElementDisappear();
				base.owner.CurrentBeScene.TriggerEventNew(BeEventSceneType.onRaceGameEnd, new EventParam
				{
					m_Int = 2
				});
			}
			else
			{
				PVEBattle pvebattle = base.owner.CurrentBeBattle as PVEBattle;
				if (pvebattle != null)
				{
					pvebattle.DoFightSuccess();
					base.owner.CurrentBeScene.TriggerEventNew(BeEventSceneType.onRaceGameEnd, new EventParam
					{
						m_Int = 1
					});
					Singleton<ClientSystemManager>.instance.PlayUIEffect(FrameLayer.Top, this.m_effectPath, 20f);
				}
			}
		}
	}

	// Token: 0x0401151D RID: 70941
	private int m_monsterID;

	// Token: 0x0401151E RID: 70942
	private bool m_isPlayer;

	// Token: 0x0401151F RID: 70943
	private double m_SlowTime;

	// Token: 0x04011520 RID: 70944
	private double m_EndTimeStamp = -1.0;

	// Token: 0x04011521 RID: 70945
	private string m_effectPath = string.Empty;
}
