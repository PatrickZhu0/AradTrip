using System;
using System.Collections.Generic;

// Token: 0x0200434B RID: 17227
public class Mechanism2021 : BeMechanism
{
	// Token: 0x06017D9E RID: 97694 RVA: 0x0075F1BC File Offset: 0x0075D5BC
	public Mechanism2021(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017D9F RID: 97695 RVA: 0x0075F1E8 File Offset: 0x0075D5E8
	public override void OnInit()
	{
		base.OnInit();
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.buffList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.buffID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017DA0 RID: 97696 RVA: 0x0075F274 File Offset: 0x0075D674
	public override void OnStart()
	{
		base.OnStart();
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BeActor actor = allPlayers[i].playerActor;
			if (actor != null && !actor.IsDead())
			{
				BeEventHandle item = actor.RegisterEvent(BeEventType.onBuffBeforePostInit, delegate(object[] args)
				{
					if (this.owner.aiManager == null || actor.buffController == null)
					{
						return;
					}
					BeBuff beBuff = args[0] as BeBuff;
					if (this.buffList.Contains(beBuff.buffID))
					{
						if (this.owner.aiManager.aiTarget != null && this.AITargetHaveBuff(this.owner.aiManager.aiTarget))
						{
							return;
						}
						actor.buffController.TryAddBuff(this.buffID, -1, 1, GlobalLogic.VALUE_1000, 0, false, null, 0, 0, this.owner);
						this.owner.aiManager.SetTarget(actor, false);
						if (this.owner.buffController != null)
						{
							this.owner.buffController.TryAddBuff(this.buffID01, -1, 1);
						}
					}
				});
				BeEventHandle item2 = actor.RegisterEvent(BeEventType.onRemoveBuff, delegate(object[] args)
				{
					if (this.owner.aiManager == null || actor.buffController == null)
					{
						return;
					}
					int item3 = (int)args[0];
					if (this.buffList.Contains(item3) && actor == this.owner.aiManager.aiTarget)
					{
						this.owner.aiManager.SetTarget(null, false);
						actor.buffController.RemoveBuff(this.buffID, 0, 0);
						if (this.owner.buffController != null)
						{
							this.owner.buffController.RemoveBuff(this.buffID01, 0, 0);
						}
					}
				});
				this.handleList.Add(item);
				this.handleList.Add(item2);
			}
		}
	}

	// Token: 0x06017DA1 RID: 97697 RVA: 0x0075F340 File Offset: 0x0075D740
	private bool AITargetHaveBuff(BeActor actor)
	{
		if (actor.buffController != null)
		{
			List<BeBuff> list = actor.buffController.GetBuffList();
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < this.buffList.Count; j++)
				{
					if (list[i].buffID == this.buffList[j])
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06017DA2 RID: 97698 RVA: 0x0075F3B8 File Offset: 0x0075D7B8
	private void RemoveHandle()
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

	// Token: 0x06017DA3 RID: 97699 RVA: 0x0075F41B File Offset: 0x0075D81B
	public override void OnDead()
	{
		base.OnDead();
		this.RemoveHandle();
	}

	// Token: 0x06017DA4 RID: 97700 RVA: 0x0075F429 File Offset: 0x0075D829
	public override void OnFinish()
	{
		this.RemoveHandle();
		base.OnFinish();
	}

	// Token: 0x0401129B RID: 70299
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x0401129C RID: 70300
	private List<int> buffList = new List<int>();

	// Token: 0x0401129D RID: 70301
	private int buffID;

	// Token: 0x0401129E RID: 70302
	private int buffID01 = 521732;
}
