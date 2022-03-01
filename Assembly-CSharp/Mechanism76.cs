using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x0200440D RID: 17421
public sealed class Mechanism76 : BeMechanism
{
	// Token: 0x0601831A RID: 99098 RVA: 0x00787B48 File Offset: 0x00785F48
	public Mechanism76(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x0601831B RID: 99099 RVA: 0x00787B70 File Offset: 0x00785F70
	public override void OnInit()
	{
		this.distance = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
		this.type = (Mechanism76.eCalcType)TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
		this.skillId = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		for (int i = 0; i < this.data.ValueD.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.data.ValueD[i], this.level, true);
			this.listBuffId.Add(valueFromUnionCell);
		}
		this.totalTime = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
	}

	// Token: 0x0601831C RID: 99100 RVA: 0x00787C77 File Offset: 0x00786077
	public override void OnStart()
	{
		this.timer = 0;
		this.usedSkill = false;
	}

	// Token: 0x0601831D RID: 99101 RVA: 0x00787C88 File Offset: 0x00786088
	public override void OnUpdate(int deltaTime)
	{
		if (base.owner != null && !this.usedSkill)
		{
			if (base.owner.aiManager.IsRunning())
			{
				base.owner.aiManager.Stop();
			}
			this.totalTime -= deltaTime;
			if (this.totalTime <= 0)
			{
				this.UseSkill(null);
				return;
			}
			this.timer += deltaTime;
			if (this.timer >= this.interval)
			{
				this.timer = 0;
				List<BeActor> list = ListPool<BeActor>.Get();
				base.owner.CurrentBeScene.FindTargets(list, base.owner, VInt.Float2VIntValue(100f), false, null);
				for (int i = 0; i < list.Count; i++)
				{
					BeActor beActor = list[i];
					if (beActor != null && !beActor.IsDead())
					{
						if (this.type == Mechanism76.eCalcType.CalcXY)
						{
							if ((beActor.GetPosition() - base.owner.GetPosition()).magnitude < this.distance.i)
							{
								this.UseSkill(beActor);
								break;
							}
						}
						else if (this.type == Mechanism76.eCalcType.CalcX)
						{
							int num = Mathf.Abs(beActor.GetPosition().x - base.owner.GetPosition().x);
							if (num < this.distance.i)
							{
								this.UseSkill(beActor);
								break;
							}
						}
						else if (this.type == Mechanism76.eCalcType.CalcY)
						{
							int num2 = Mathf.Abs(beActor.GetPosition().y - base.owner.GetPosition().y);
							if (num2 < this.distance.i)
							{
								this.UseSkill(beActor);
								break;
							}
						}
					}
				}
				ListPool<BeActor>.Release(list);
			}
		}
	}

	// Token: 0x0601831E RID: 99102 RVA: 0x00787E78 File Offset: 0x00786278
	private void UseSkill(BeActor target)
	{
		this.usedSkill = base.owner.UseSkill(this.skillId, this.isForceUse);
		if (this.usedSkill)
		{
			if (base.owner.aiManager.state == BeAIManager.State.STOP)
			{
				base.owner.aiManager.Start();
			}
			if (target != null)
			{
				base.owner.SetFace(target.GetPosition().x < base.owner.GetPosition().x, false, false);
			}
			else
			{
				List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
				int num = -1;
				for (int i = 0; i < allPlayers.Count; i++)
				{
					BeActor playerActor = allPlayers[i].playerActor;
					if (playerActor != null && !playerActor.IsDead())
					{
						num = i;
						break;
					}
				}
				if (num >= 0 && num < allPlayers.Count)
				{
					base.owner.SetFace(allPlayers[num].playerActor.GetPosition().x < base.owner.GetPosition().x, false, false);
				}
			}
			this.RemoveBuffs();
		}
	}

	// Token: 0x0601831F RID: 99103 RVA: 0x00787FC4 File Offset: 0x007863C4
	private void RemoveBuffs()
	{
		for (int i = 0; i < this.listBuffId.Count; i++)
		{
			base.owner.buffController.RemoveBuff(this.listBuffId[i], 0, 0);
		}
		this.listBuffId.Clear();
	}

	// Token: 0x0401175E RID: 71518
	private VInt distance;

	// Token: 0x0401175F RID: 71519
	private Mechanism76.eCalcType type;

	// Token: 0x04011760 RID: 71520
	private int skillId;

	// Token: 0x04011761 RID: 71521
	private List<int> listBuffId = new List<int>();

	// Token: 0x04011762 RID: 71522
	private int totalTime;

	// Token: 0x04011763 RID: 71523
	private bool isForceUse = true;

	// Token: 0x04011764 RID: 71524
	private int interval = 250;

	// Token: 0x04011765 RID: 71525
	private int timer;

	// Token: 0x04011766 RID: 71526
	private bool usedSkill;

	// Token: 0x0200440E RID: 17422
	private enum eCalcType
	{
		// Token: 0x04011768 RID: 71528
		CalcXY,
		// Token: 0x04011769 RID: 71529
		CalcX,
		// Token: 0x0401176A RID: 71530
		CalcY
	}
}
