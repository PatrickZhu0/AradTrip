using System;
using System.Collections.Generic;

// Token: 0x02004415 RID: 17429
public class Mechanism82 : BeMechanism
{
	// Token: 0x06018340 RID: 99136 RVA: 0x00788D40 File Offset: 0x00787140
	public Mechanism82(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018341 RID: 99137 RVA: 0x00788D94 File Offset: 0x00787194
	public override void OnInit()
	{
		for (int i = 0; i < this.data.ValueA.Count; i++)
		{
			this.buffList.Add(TableManager.GetValueFromUnionCell(this.data.ValueA[i], this.level, true));
		}
		this.buffList.Add(21);
		this.distance = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018342 RID: 99138 RVA: 0x00788E2E File Offset: 0x0078722E
	public override void OnStart()
	{
		this.timer = 0;
		this._initPlayerList();
		this._switchSceneEffect(true);
	}

	// Token: 0x06018343 RID: 99139 RVA: 0x00788E44 File Offset: 0x00787244
	private void _switchSceneEffect(bool flag)
	{
		if (flag)
		{
			this.blackSceneID = base.owner.CurrentBeScene.currentGeScene.BlendSceneSceneColor(0.3f, 0.5f, true);
		}
		else
		{
			base.owner.CurrentBeScene.currentGeScene.RecoverSceneColor(0.5f, this.blackSceneID);
		}
	}

	// Token: 0x06018344 RID: 99140 RVA: 0x00788EA4 File Offset: 0x007872A4
	private void _initPlayerList()
	{
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return;
		}
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i] != null)
			{
				BeActor actor = allPlayers[i].playerActor;
				this.playerList.Add(actor);
				this._addEffect(actor);
				BeEventHandle item = actor.RegisterEvent(BeEventType.onReborn, delegate(object[] args)
				{
					this._addEffect(actor);
				});
				this.handleList.Add(item);
			}
		}
		this.playerList.Add(base.owner);
		this._addEffect(base.owner);
	}

	// Token: 0x06018345 RID: 99141 RVA: 0x00788F70 File Offset: 0x00787370
	private void _addEffect(BeActor actor)
	{
		if (actor.IsDead())
		{
			return;
		}
		actor.m_pkGeActor.CreateEffect("Effects/Monster_huopen/Prefab/Eff_huopen_juesejiaodi", "[actor]Orign", 999999f, Vec3.zero, 1f, 1f, true, false, EffectTimeType.BUFF, false);
	}

	// Token: 0x06018346 RID: 99142 RVA: 0x00788FB8 File Offset: 0x007873B8
	private bool _checkInDistance(BeActor monster)
	{
		if (monster == null)
		{
			return false;
		}
		if (monster.IsDead())
		{
			return false;
		}
		for (int i = 0; i < this.playerList.Count; i++)
		{
			if (this.playerList[i] != null && !this.playerList[i].IsDead() && (monster.GetPosition() - this.playerList[i].GetPosition()).magnitude < this.distance.i)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018347 RID: 99143 RVA: 0x00789054 File Offset: 0x00787454
	private void _addBuffs(BeActor monster)
	{
		if (monster != null)
		{
			for (int i = 0; i < this.buffList.Count; i++)
			{
				if (monster.buffController.HasBuffByID(this.buffList[i]) == null)
				{
					monster.buffController.TryAddBuff(this.buffList[i], GlobalLogic.VALUE_100000 * 10, 1);
				}
			}
			BeBuff beBuff = monster.buffController.HasBuffByID(42);
			if (beBuff != null)
			{
				monster.buffController.RemoveBuff(beBuff);
			}
		}
	}

	// Token: 0x06018348 RID: 99144 RVA: 0x007890E4 File Offset: 0x007874E4
	private void _removeBuffs(BeActor monster)
	{
		if (monster != null)
		{
			for (int i = 0; i < this.buffList.Count; i++)
			{
				BeBuff beBuff = monster.buffController.HasBuffByID(this.buffList[i]);
				if (beBuff != null)
				{
					monster.buffController.RemoveBuff(beBuff);
				}
			}
			if (monster.buffController.HasBuffByID(42) == null)
			{
				monster.buffController.TryAddBuff(42, GlobalLogic.VALUE_1500, 1);
			}
			if (monster.m_pkGeActor != null && monster.m_cpkCurEntityActionInfo != null)
			{
				monster.m_pkGeActor.ChangeAction(monster.m_cpkCurEntityActionInfo.actionName, 0.25f, true, true, false);
			}
		}
	}

	// Token: 0x06018349 RID: 99145 RVA: 0x0078919C File Offset: 0x0078759C
	private void _removeAllBuffs()
	{
		for (int i = 0; i < this.targetList.Count; i++)
		{
			this._removeBuffs(this.targetList[i]);
		}
	}

	// Token: 0x0601834A RID: 99146 RVA: 0x007891D8 File Offset: 0x007875D8
	public override void OnUpdate(int deltaTime)
	{
		if (base.owner == null)
		{
			return;
		}
		if (base.owner.IsDead())
		{
			return;
		}
		this.timer += deltaTime;
		if (this.timer >= this.interval)
		{
			this.timer = 0;
			base.owner.CurrentBeScene.FindTargets(this.targetList, base.owner, VInt.Float2VIntValue(100f), true, null);
			for (int i = 0; i < this.targetList.Count; i++)
			{
				if (this.targetList[i] != null)
				{
					if (this.targetList[i] != base.owner)
					{
						if (!this.targetList[i].IsDead())
						{
							if (this._checkInDistance(this.targetList[i]))
							{
								this._removeBuffs(this.targetList[i]);
							}
							else
							{
								this._addBuffs(this.targetList[i]);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0601834B RID: 99147 RVA: 0x00789300 File Offset: 0x00787700
	private void _removeAllEffects()
	{
		for (int i = 0; i < this.playerList.Count; i++)
		{
			if (this.playerList[i] != null && !this.playerList[i].IsDead())
			{
				GeEffectEx geEffectEx = this.playerList[i].m_pkGeActor.FindEffect("Effects/Monster_huopen/Prefab/Eff_huopen_juesejiaodi");
				if (geEffectEx != null)
				{
					this.playerList[i].m_pkGeActor.DestroyEffect(geEffectEx);
				}
			}
		}
	}

	// Token: 0x0601834C RID: 99148 RVA: 0x0078938C File Offset: 0x0078778C
	private void _removeHandles()
	{
		for (int i = 0; i < this.handleList.Count; i++)
		{
			BeEventHandle beEventHandle = this.handleList[i];
			if (beEventHandle != null)
			{
				beEventHandle.Remove();
			}
		}
		this.handleList.Clear();
	}

	// Token: 0x0601834D RID: 99149 RVA: 0x007893DB File Offset: 0x007877DB
	public override void OnFinish()
	{
		this._removeAllBuffs();
		this._removeAllEffects();
		this._removeHandles();
		this._switchSceneEffect(false);
		this.targetList.Clear();
		this.buffList.Clear();
		this.playerList.Clear();
	}

	// Token: 0x04011780 RID: 71552
	private const string effectPath = "Effects/Monster_huopen/Prefab/Eff_huopen_juesejiaodi";

	// Token: 0x04011781 RID: 71553
	private List<int> buffList = new List<int>();

	// Token: 0x04011782 RID: 71554
	private VInt distance;

	// Token: 0x04011783 RID: 71555
	private List<BeActor> playerList = new List<BeActor>();

	// Token: 0x04011784 RID: 71556
	private List<BeActor> targetList = new List<BeActor>();

	// Token: 0x04011785 RID: 71557
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x04011786 RID: 71558
	private int timer;

	// Token: 0x04011787 RID: 71559
	private int interval = 150;

	// Token: 0x04011788 RID: 71560
	private int blackSceneID = -1;
}
