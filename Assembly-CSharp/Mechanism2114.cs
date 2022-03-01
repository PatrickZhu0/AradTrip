using System;
using System.Collections.Generic;

// Token: 0x020043AD RID: 17325
public class Mechanism2114 : BeMechanism
{
	// Token: 0x06018073 RID: 98419 RVA: 0x00774EBC File Offset: 0x007732BC
	public Mechanism2114(int mid, int lv)
	{
		VInt3[,] array = new VInt3[8, 3];
		array[0, 0] = new VInt3(1, 0, 0);
		array[0, 1] = new VInt3(1, -1, 0);
		array[0, 2] = new VInt3(0, -1, 0);
		array[1, 0] = new VInt3(-1, -1, 0);
		array[1, 1] = new VInt3(0, -1, 0);
		array[1, 2] = new VInt3(1, -1, 0);
		array[2, 0] = new VInt3(-1, 0, 0);
		array[2, 1] = new VInt3(-1, -1, 0);
		array[2, 2] = new VInt3(0, -1, 0);
		array[3, 0] = new VInt3(1, -1, 0);
		array[3, 1] = new VInt3(1, 1, 0);
		array[3, 2] = new VInt3(1, 0, 0);
		array[4, 0] = new VInt3(0, 1, 0);
		array[4, 1] = new VInt3(1, 1, 0);
		array[4, 2] = new VInt3(1, 0, 0);
		array[5, 0] = new VInt3(-1, 1, 0);
		array[5, 1] = new VInt3(0, 1, 0);
		array[5, 2] = new VInt3(1, 1, 0);
		array[6, 0] = new VInt3(-1, 0, 0);
		array[6, 1] = new VInt3(-1, 1, 0);
		array[6, 2] = new VInt3(0, 1, 0);
		array[7, 0] = new VInt3(-1, 0, 0);
		array[7, 1] = new VInt3(-1, 1, 0);
		array[7, 2] = new VInt3(-1, -1, 0);
		this.m_edgeCorner_dir = array;
		base..ctor(mid, lv);
	}

	// Token: 0x06018074 RID: 98420 RVA: 0x007750FE File Offset: 0x007734FE
	public override void OnInit()
	{
		this.mSpeed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x06018075 RID: 98421 RVA: 0x00775134 File Offset: 0x00773534
	public override void OnUpdate(int deltaTime)
	{
		base.OnUpdate(deltaTime);
		for (int i = 0; i < this.mActorInfo.Count; i++)
		{
			Mechanism2114.ActorInfo actorInfo = this.mActorInfo[i];
			if (actorInfo != null)
			{
				actorInfo.actor.extraSpeed = actorInfo.speed;
			}
		}
	}

	// Token: 0x06018076 RID: 98422 RVA: 0x00775188 File Offset: 0x00773588
	public override void OnStart()
	{
		if (base.owner.CurrentBeBattle == null || base.owner.CurrentBeBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = base.owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
		if (allPlayers == null)
		{
			return;
		}
		VInt3[] array = new VInt3[3];
		int num = base.FrameRandom.InRange(0, 360);
		int num2 = (num + 120) % 360;
		int degree = (num2 + 120) % 360;
		VInt3 vint = new VInt3(1f, 0f, 0f);
		VFactor vfactor = this.DegreeToRadian(num);
		VFactor vfactor2 = this.DegreeToRadian(num2);
		VFactor vfactor3 = this.DegreeToRadian(degree);
		array[0] = vint.RotateZ(ref vfactor);
		array[1] = vint.RotateZ(ref vfactor2);
		array[2] = vint.RotateZ(ref vfactor3);
		int num3 = 0;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			BattlePlayer battlePlayer = allPlayers[i];
			if (battlePlayer != null)
			{
				BeActor playerActor = battlePlayer.playerActor;
				if (playerActor != null && !playerActor.IsDead())
				{
					num3++;
				}
			}
		}
		if (num3 > 1)
		{
			for (int j = 0; j < allPlayers.Count; j++)
			{
				BattlePlayer battlePlayer2 = allPlayers[j];
				if (battlePlayer2 != null)
				{
					BeActor playerActor2 = battlePlayer2.playerActor;
					if (playerActor2 != null && !playerActor2.IsDead() && !playerActor2.isSpecialMonster)
					{
						if (playerActor2.IsCastingSkill())
						{
							BeSkill curSkill = playerActor2.GetCurSkill();
							if (curSkill != null && curSkill.IsJueXingSkill())
							{
								goto IL_48E;
							}
						}
						this.mHandlList.Add(playerActor2.RegisterEvent(BeEventType.onXInBlock, new BeEventHandle.Del(this.onActorInBlock)));
						this.mHandlList.Add(playerActor2.RegisterEvent(BeEventType.onYInBlock, new BeEventHandle.Del(this.onActorInBlock)));
						this.m_edgeDist_InFour[0] = Math.Abs(playerActor2.CurrentBeScene.logicXSize.x - playerActor2.GetPosition().x);
						this.m_edgeDist_InFour[1] = Math.Abs(playerActor2.CurrentBeScene.logicXSize.y - playerActor2.GetPosition().x);
						this.m_edgeDist_InFour[2] = Math.Abs(playerActor2.CurrentBeScene.logicZSize.y - playerActor2.GetPosition().y);
						this.m_edgeDist_InFour[3] = Math.Abs(playerActor2.CurrentBeScene.logicZSize.x - playerActor2.GetPosition().y);
						bool flag = false;
						int num4 = -1;
						if (this.m_edgeDist_InFour[0] < this.m_edgeDist_InFour[1])
						{
							if (this.m_edgeDist_InFour[0] <= this.m_edgeDist_Threshold[0])
							{
								flag = true;
								num4 = 3;
								if (this.m_edgeDist_InFour[2] <= this.m_edgeDist_Threshold[2])
								{
									num4 = 0;
								}
								if (this.m_edgeDist_InFour[3] <= this.m_edgeDist_Threshold[3])
								{
									num4 = 4;
								}
							}
						}
						else if (this.m_edgeDist_InFour[1] <= this.m_edgeDist_Threshold[1])
						{
							flag = true;
							num4 = 7;
							if (this.m_edgeDist_InFour[2] <= this.m_edgeDist_Threshold[2])
							{
								num4 = 2;
							}
							if (this.m_edgeDist_InFour[3] <= this.m_edgeDist_Threshold[3])
							{
								num4 = 6;
							}
						}
						if (!flag)
						{
							if (this.m_edgeDist_InFour[2] < this.m_edgeDist_InFour[3])
							{
								if (this.m_edgeDist_InFour[0] > this.m_edgeDist_Threshold[0] && this.m_edgeDist_InFour[1] > this.m_edgeDist_Threshold[1])
								{
									num4 = 1;
								}
							}
							else if (this.m_edgeDist_InFour[0] > this.m_edgeDist_Threshold[0] && this.m_edgeDist_InFour[1] > this.m_edgeDist_Threshold[1])
							{
								num4 = 5;
							}
						}
						if (num4 >= 0)
						{
							array[j] = this.m_edgeCorner_dir[num4, j];
						}
						VInt3 vint2 = array[j].NormalizeTo(this.mSpeed.i);
						playerActor2.extraSpeed += vint2;
						this.mActorInfo.Add(new Mechanism2114.ActorInfo
						{
							actor = playerActor2,
							speed = vint2
						});
						playerActor2.stateController.SetAbilityEnable(BeAbilityType.MOVE, false);
						playerActor2.stateController.SetAbilityEnable(BeAbilityType.BEHIT, false);
						playerActor2.stateController.SetAbilityEnable(BeAbilityType.ATTACK, false);
					}
				}
				IL_48E:;
			}
		}
	}

	// Token: 0x06018077 RID: 98423 RVA: 0x00775638 File Offset: 0x00773A38
	public override void OnFinish()
	{
		base.OnFinish();
		for (int i = 0; i < this.mHandlList.Count; i++)
		{
			if (this.mHandlList[i] != null)
			{
				this.mHandlList[i].Remove();
			}
		}
		this.mHandlList.Clear();
		for (int j = 0; j < this.mActorInfo.Count; j++)
		{
			BeActor actor = this.mActorInfo[j].actor;
			if (actor != null)
			{
				actor.extraSpeed -= this.mActorInfo[j].speed;
				actor.stateController.SetAbilityEnable(BeAbilityType.MOVE, true);
				actor.stateController.SetAbilityEnable(BeAbilityType.BEHIT, true);
				actor.stateController.SetAbilityEnable(BeAbilityType.ATTACK, true);
			}
		}
		this.mActorInfo.Clear();
	}

	// Token: 0x06018078 RID: 98424 RVA: 0x0077571C File Offset: 0x00773B1C
	public VFactor DegreeToRadian(int degree)
	{
		return VFactor.pi / 180L * (long)degree / 100L;
	}

	// Token: 0x06018079 RID: 98425 RVA: 0x00775740 File Offset: 0x00773B40
	private void onActorInBlock(object[] args)
	{
		if (args == null || args.Length <= 0)
		{
			return;
		}
		BeActor beActor = args[0] as BeActor;
		if (beActor == null)
		{
			return;
		}
		for (int i = 0; i < this.mActorInfo.Count; i++)
		{
			BeActor actor = this.mActorInfo[i].actor;
			if (actor != null && actor.GetPID() == beActor.GetPID())
			{
				beActor.extraSpeed = VInt3.zero;
				beActor.stateController.SetAbilityEnable(BeAbilityType.MOVE, true);
				beActor.stateController.SetAbilityEnable(BeAbilityType.BEHIT, true);
				beActor.stateController.SetAbilityEnable(BeAbilityType.ATTACK, true);
				this.mActorInfo.RemoveAt(i);
				return;
			}
		}
	}

	// Token: 0x040114FB RID: 70907
	private List<BeEventHandle> mHandlList = new List<BeEventHandle>();

	// Token: 0x040114FC RID: 70908
	private VInt mSpeed = VInt.zero;

	// Token: 0x040114FD RID: 70909
	private List<Mechanism2114.ActorInfo> mActorInfo = new List<Mechanism2114.ActorInfo>();

	// Token: 0x040114FE RID: 70910
	private VInt3[] m_dir_InFour = new VInt3[]
	{
		new VInt3(1, 0, 0),
		new VInt3(-1, 0, 0),
		new VInt3(0, -1, 0),
		new VInt3(0, 1, 0)
	};

	// Token: 0x040114FF RID: 70911
	private int[] m_edgeDist_InFour = new int[4];

	// Token: 0x04011500 RID: 70912
	private int[] m_edgeDist_Threshold = new int[]
	{
		100000,
		100000,
		40000,
		40000
	};

	// Token: 0x04011501 RID: 70913
	private VInt3[,] m_edgeCorner_dir;

	// Token: 0x020043AE RID: 17326
	private class ActorInfo
	{
		// Token: 0x04011502 RID: 70914
		public BeActor actor;

		// Token: 0x04011503 RID: 70915
		public VInt3 speed;
	}
}
