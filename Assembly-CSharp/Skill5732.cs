using System;
using System.Collections.Generic;

// Token: 0x020044F7 RID: 17655
public class Skill5732 : BeSkill
{
	// Token: 0x06018915 RID: 100629 RVA: 0x007AC666 File Offset: 0x007AAA66
	public Skill5732(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018916 RID: 100630 RVA: 0x007AC67B File Offset: 0x007AAA7B
	public override void OnInit()
	{
		this.speed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018917 RID: 100631 RVA: 0x007AC6AA File Offset: 0x007AAAAA
	public override void OnStart()
	{
		if (base.owner.stateController != null)
		{
			base.owner.stateController.SetAbilityEnable(BeAbilityType.CHANGE_FACE, false);
		}
		this.PlayersRegisterEvent();
		this.ChangeFace();
	}

	// Token: 0x06018918 RID: 100632 RVA: 0x007AC6DC File Offset: 0x007AAADC
	private void PlayersRegisterEvent()
	{
		this.hitPlayerFlag = false;
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BattlePlayer battlePlayer = allPlayers[i];
			if (battlePlayer == null)
			{
				return;
			}
			if (battlePlayer.playerActor == null)
			{
				return;
			}
			if (battlePlayer.playerActor.IsDead())
			{
				return;
			}
			BeEventHandle item = battlePlayer.playerActor.RegisterEvent(BeEventType.onHit, delegate(object[] args)
			{
				if (args.Length >= 3)
				{
					BeActor beActor = args[2] as BeActor;
					if (beActor == base.owner)
					{
						this.hitPlayerFlag = true;
					}
				}
			});
			this.handleList.Add(item);
		}
	}

	// Token: 0x06018919 RID: 100633 RVA: 0x007AC770 File Offset: 0x007AAB70
	private bool ChangeFace()
	{
		bool flag = base.owner.GetPosition().x < base.owner.CurrentBeScene.GetSceneCenterPosition().x;
		base.owner.SetFace(!flag, false, true);
		return flag;
	}

	// Token: 0x0601891A RID: 100634 RVA: 0x007AC7BD File Offset: 0x007AABBD
	public override void OnEnterPhase(int phase)
	{
		if (phase == 2)
		{
			this.MoveFast();
		}
		else if (phase == 3 && this.hitPlayerFlag)
		{
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
		}
	}

	// Token: 0x0601891B RID: 100635 RVA: 0x007AC7F8 File Offset: 0x007AABF8
	private void MoveFast()
	{
		base.owner.ChangeRunMode(true);
		base.owner.ClearMoveSpeed(7);
		bool flag = this.ChangeFace();
		this.startPos = base.owner.GetPosition();
		int num = (!flag) ? -1 : 1;
		base.owner.SetMoveSpeedX(this.speed.i * num);
	}

	// Token: 0x0601891C RID: 100636 RVA: 0x007AC860 File Offset: 0x007AAC60
	public override void OnCancel()
	{
		this.Release();
	}

	// Token: 0x0601891D RID: 100637 RVA: 0x007AC868 File Offset: 0x007AAC68
	public override void OnFinish()
	{
		this.Release();
	}

	// Token: 0x0601891E RID: 100638 RVA: 0x007AC870 File Offset: 0x007AAC70
	private void Release()
	{
		this.RemoveHandles();
		if (base.owner.stateController != null)
		{
			base.owner.stateController.SetAbilityEnable(BeAbilityType.CHANGE_FACE, true);
		}
		base.owner.ResetMoveCmd();
		base.owner.ChangeRunMode(false);
	}

	// Token: 0x0601891F RID: 100639 RVA: 0x007AC8C0 File Offset: 0x007AACC0
	private void RemoveHandles()
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

	// Token: 0x04011B9D RID: 72605
	private VInt speed;

	// Token: 0x04011B9E RID: 72606
	private int buffId;

	// Token: 0x04011B9F RID: 72607
	private int timer;

	// Token: 0x04011BA0 RID: 72608
	private VInt3 startPos;

	// Token: 0x04011BA1 RID: 72609
	private bool moveFlag;

	// Token: 0x04011BA2 RID: 72610
	private bool hitPlayerFlag;

	// Token: 0x04011BA3 RID: 72611
	private List<BeEventHandle> handleList = new List<BeEventHandle>();
}
