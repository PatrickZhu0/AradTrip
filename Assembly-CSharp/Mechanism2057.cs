using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;

// Token: 0x02004371 RID: 17265
public class Mechanism2057 : BeMechanism
{
	// Token: 0x06017EA2 RID: 97954 RVA: 0x00766F34 File Offset: 0x00765334
	public Mechanism2057(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017EA3 RID: 97955 RVA: 0x00766F9C File Offset: 0x0076539C
	public override void OnInit()
	{
		base.OnInit();
		this.monsterNum = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.totalTime = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		if (this.data.ValueC.Count == 2)
		{
			this.monsterIDs[0] = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
			this.monsterIDs[1] = TableManager.GetValueFromUnionCell(this.data.ValueC[1], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.blindBuffId = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
	}

	// Token: 0x06017EA4 RID: 97956 RVA: 0x007670A8 File Offset: 0x007654A8
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			if (!this.flag && base.owner.attribute.GetHPRate() <= VFactor.NewVFactor(20, 100))
			{
				this.flag = true;
				base.owner.UseSkill(this.skillID, true);
				base.owner.buffController.TryAddBuff(this.buffID, -1, 1);
				this.OpenFrame();
			}
		});
		this.handleB = base.owner.CurrentBeScene.RegisterEvent(BeEventSceneType.onMonsterDead, delegate(object[] args)
		{
			if (this.timeStop)
			{
				return;
			}
			BeActor beActor = args[0] as BeActor;
			if (beActor != null && Array.IndexOf<int>(this.monsterIDs, beActor.GetEntityData().monsterID) != -1)
			{
				this.monsterCnt++;
				if (this.monsterCnt >= this.monsterNum && this.totalTime > 0)
				{
					this.timeStop = true;
					this.RestoreSceneClearMonster(true);
					base.owner.buffController.TryAddBuff(this.weakBuffID, -1, 1);
				}
				if (this.uiFrame != null)
				{
					this.uiFrame.SetNumText((this.monsterNum - this.monsterCnt).ToString());
				}
			}
		});
	}

	// Token: 0x06017EA5 RID: 97957 RVA: 0x007670FD File Offset: 0x007654FD
	public bool IsTimeStop()
	{
		return this.timeStop;
	}

	// Token: 0x06017EA6 RID: 97958 RVA: 0x00767108 File Offset: 0x00765508
	private void RestoreSceneClearMonster(bool success)
	{
		base.owner.buffController.RemoveBuff(this.buffID, 0, 0);
		List<BeActor> list = new List<BeActor>();
		for (int i = 0; i < this.monsterIDs.Length; i++)
		{
			base.owner.CurrentBeScene.FindActorById2(list, this.monsterIDs[i], false);
			for (int j = 0; j < list.Count; j++)
			{
				list[j].DoDead(false);
			}
		}
		this.CreateEffect(success);
		if (this.uiFrame != null)
		{
			this.uiFrame.Close(false);
			this.uiFrame = null;
		}
		BeUtility.GetAllEnemyPlayers(base.owner, list);
		for (int k = 0; k < list.Count; k++)
		{
			BeActor beActor = list[k];
			if (beActor != null)
			{
				beActor.buffController.RemoveBuff(this.blindBuffId, 0, 0);
				if (!success && !beActor.IsDead())
				{
					beActor.DoDead(false);
					beActor.GetEntityData().SetHP(0);
					if (beActor.m_pkGeActor != null)
					{
						beActor.m_pkGeActor.SyncHPBar();
					}
				}
			}
		}
	}

	// Token: 0x06017EA7 RID: 97959 RVA: 0x0076723C File Offset: 0x0076563C
	private void CreateEffect(bool success)
	{
		string path = (!success) ? "Effects/Monster_TB02/Prefab/Eff_Monster_TB02_kexila_Emeng_Mengyan_05" : "Effects/Monster_TB02/Prefab/Eff_Monster_TB02_kexila_Emeng_Mengyan_06";
		GameObject obj = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		Utility.AttachTo(obj, Singleton<ClientSystemManager>.instance.GetLayer(FrameLayer.TopMost), false);
		int ms = (!success) ? 5600 : 2580;
		Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(ms, delegate
		{
			if (obj != null)
			{
				Object.Destroy(obj);
			}
		}, 0, 0, false);
	}

	// Token: 0x06017EA8 RID: 97960 RVA: 0x007672C5 File Offset: 0x007656C5
	private void OpenFrame()
	{
		this.uiFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<GoblinKingdomFrame>(FrameLayer.Middle, null, string.Empty) as GoblinKingdomFrame);
		this.uiFrame.SetNumText(this.monsterNum.ToString());
	}

	// Token: 0x06017EA9 RID: 97961 RVA: 0x007672FF File Offset: 0x007656FF
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		if (!this.flag)
		{
			return;
		}
		if (this.timeStop)
		{
			return;
		}
		this.UpdateTotalTime(deltaTime);
	}

	// Token: 0x06017EAA RID: 97962 RVA: 0x00767328 File Offset: 0x00765728
	private void UpdateTotalTime(int deltaTime)
	{
		this.totalTime -= deltaTime;
		if (this.totalTime > 0)
		{
			if (this.uiFrame != null)
			{
				int num = this.totalTime / 60000;
				int num2 = this.totalTime % 60000 / 1000;
				int num3 = this.totalTime % 1000 / 10;
				string timeText = string.Format("{0}.{1:D2}.{2:D2}", num, num2, num3);
				this.uiFrame.SetTimeText(timeText);
			}
		}
		else
		{
			this.timeStop = true;
			this.RestoreSceneClearMonster(false);
			base.owner.buffController.TryAddBuff(this.endBuffID, -1, 1);
		}
	}

	// Token: 0x06017EAB RID: 97963 RVA: 0x007673DF File Offset: 0x007657DF
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x0401136B RID: 70507
	private int skillID = 21216;

	// Token: 0x0401136C RID: 70508
	private int buffID = 521633;

	// Token: 0x0401136D RID: 70509
	private int blindBuffId = 521631;

	// Token: 0x0401136E RID: 70510
	private int weakBuffID = 521632;

	// Token: 0x0401136F RID: 70511
	private int endBuffID = 521636;

	// Token: 0x04011370 RID: 70512
	private bool flag;

	// Token: 0x04011371 RID: 70513
	private int monsterNum;

	// Token: 0x04011372 RID: 70514
	private int monsterCnt;

	// Token: 0x04011373 RID: 70515
	private bool timeStop;

	// Token: 0x04011374 RID: 70516
	private GoblinKingdomFrame uiFrame;

	// Token: 0x04011375 RID: 70517
	private int totalTime;

	// Token: 0x04011376 RID: 70518
	private int[] monsterIDs = new int[]
	{
		81110011,
		81120011
	};
}
