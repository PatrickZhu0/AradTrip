using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02004408 RID: 17416
public class Mechanism70 : BeMechanism
{
	// Token: 0x060182F0 RID: 99056 RVA: 0x00786B60 File Offset: 0x00784F60
	public Mechanism70(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060182F1 RID: 99057 RVA: 0x00786C44 File Offset: 0x00785044
	public override void OnInit()
	{
		base.OnInit();
		this.pveSpeed = new VInt((float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f);
		this.pvpSpeed = new VInt((float)TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) / 1000f);
		if (this.data.ValueC.Length > 0)
		{
			this.updateControllDuration = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		this.speed = ((!BattleMain.IsModePvP(base.owner.battleType)) ? this.pveSpeed : this.pvpSpeed);
	}

	// Token: 0x060182F2 RID: 99058 RVA: 0x00786D29 File Offset: 0x00785129
	public override void OnUpdate(int deltaTime)
	{
		if (this.isFinish)
		{
			return;
		}
		this.UpdateMove(deltaTime);
		if (!this.canControl)
		{
			return;
		}
		this.UpdateControl(deltaTime);
		this.UpdateMoveOut(deltaTime);
	}

	// Token: 0x060182F3 RID: 99059 RVA: 0x00786D58 File Offset: 0x00785158
	public void DoStart()
	{
		this.dirRecords.Clear();
		this.dirTimeRecords.Clear();
		int num = 0;
		VInt3 position = base.owner.GetPosition();
		position.z += this.height.i;
		int num2 = (!base.owner.GetFace()) ? 1 : -1;
		for (int i = 0; i < this.dragonPartNum.Length; i++)
		{
			for (int j = 0; j < this.dragonPartNum[i]; j++)
			{
				VInt3 pos = position;
				BeProjectile beProjectile = base.owner.AddEntity(this.dragonIDs[i], pos, 1, 0) as BeProjectile;
				this.dragonPartTimeAcc[num] = 0;
				this.dragonParts[num] = beProjectile;
				if (num == 0)
				{
					this.dragonPartMoveDir[num] = ((!base.owner.GetFace()) ? BeAIManager.MoveDir2.RIGHT : BeAIManager.MoveDir2.LEFT);
					beProjectile.SetFace(false, false, false);
				}
				else
				{
					this.dragonPartMoveDir[num] = BeAIManager.MoveDir2.COUNT;
					this.dragonPartTimeAcc[num] = 256 * -num;
				}
				num++;
			}
		}
		this.head = this.dragonParts[0];
		this.headLastPos = this.head.GetPosition();
		this.tail = this.dragonParts[this.dragonParts.Length - 1];
		this.head.RegisterEvent(BeEventType.onDead, delegate(object[] args)
		{
			this.isFinish = true;
		});
		this.dirTimeRecords.Add(0);
		this.dirRecords.Add((int)this.dragonPartMoveDir[0]);
		this.UpdateMove(0);
		for (int k = 0; k < this.dragonParts.Length; k++)
		{
			this.ChangeRotation(k);
		}
		this.updateControllTimeAcc = this.updateControllDuration;
		this.skill.AttackCamera(this.head);
	}

	// Token: 0x060182F4 RID: 99060 RVA: 0x00786F2D File Offset: 0x0078532D
	public void SetDead()
	{
		base.owner.delayCaller.DelayCall(100, delegate
		{
			for (int i = 0; i < this.dragonParts.Length; i++)
			{
				if (this.dragonParts[i] != null)
				{
					this.dragonParts[i].DoDie();
				}
			}
		}, 0, 0, false);
	}

	// Token: 0x060182F5 RID: 99061 RVA: 0x00786F54 File Offset: 0x00785354
	private void UpdateControl(int delta)
	{
		this.updateControllTimeAcc += delta;
		if (this.updateControllTimeAcc < this.updateControllDuration)
		{
			return;
		}
		this.updateControllTimeAcc -= this.updateControllDuration;
		BeAIManager.MoveDir2 joystickDir = this.GetJoystickDir();
		if (this.dragonPartMoveDir[0] == joystickDir || joystickDir == BeAIManager.MoveDir2.COUNT)
		{
			return;
		}
		int num = (int)((this.dragonPartMoveDir[0] + 1 + 8) % BeAIManager.MoveDir2.COUNT);
		int num2 = (this.dragonPartMoveDir[0] - BeAIManager.MoveDir2.RIGHT_TOP + 8) % 8;
		int num3 = num2;
		if (this.GetStep(this.dragonPartMoveDir[0], joystickDir, true) < this.GetStep(this.dragonPartMoveDir[0], joystickDir, false))
		{
			num3 = num;
		}
		this.dragonPartMoveDir[0] = (BeAIManager.MoveDir2)num3;
		this.ChangeRotation(0);
		this.dirRecords.Add(num3);
		this.dirTimeRecords.Add(this.dragonPartTimeAcc[0]);
		this.headLastPos = this.head.GetPosition();
	}

	// Token: 0x060182F6 RID: 99062 RVA: 0x00787038 File Offset: 0x00785438
	private int GetStep(BeAIManager.MoveDir2 start, BeAIManager.MoveDir2 target, bool isDown = true)
	{
		if (start == target)
		{
			return 0;
		}
		int num = 0;
		int num2 = (!isDown) ? -1 : 1;
		while (start != target)
		{
			int num3 = (int)((start + num2 + 8) % BeAIManager.MoveDir2.COUNT);
			start = (BeAIManager.MoveDir2)num3;
			num++;
		}
		return num;
	}

	// Token: 0x060182F7 RID: 99063 RVA: 0x0078707C File Offset: 0x0078547C
	private void UpdateMoveOut(int delta)
	{
		if (this.tail == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		this.updateMoveOutTimeAcc += delta;
		if (this.updateMoveOutTimeAcc >= this.updateMoveoutDuration)
		{
			this.updateMoveOutTimeAcc -= this.updateMoveoutDuration;
			if (base.owner.isLocalActor && !base.owner.CurrentBeScene.IsInScreen(this.tail.GetPosition().vec3) && !base.owner.CurrentBeScene.IsInScreen(this.head.GetPosition().vec3))
			{
				InputManager.CreateStopSkillFrameCommand(this.skill.skillID);
				this.tail = null;
			}
			return;
		}
	}

	// Token: 0x060182F8 RID: 99064 RVA: 0x00787158 File Offset: 0x00785558
	private void UpdateMove(int delta)
	{
		VInt3 position = this.head.GetPosition();
		VInt3 vint = position - this.headLastPos;
		if (Mathf.Abs(vint.x) >= this.size || Mathf.Abs(vint.y) >= this.size)
		{
			this.dirTimeRecords.Add(this.dragonPartTimeAcc[0]);
			this.dirRecords.Add((int)this.dragonPartMoveDir[0]);
		}
		for (int i = 0; i < this.dragonParts.Length; i++)
		{
			this.dragonPartTimeAcc[i] += delta;
			for (int j = this.dirTimeRecords.Count - 1; j >= 0; j--)
			{
				if (this.dragonPartTimeAcc[i] >= this.dirTimeRecords[j])
				{
					this.DoTurn(i, this.dirRecords[j]);
					break;
				}
			}
		}
		for (int k = 0; k < this.dragonParts.Length; k++)
		{
			BeAIManager.MoveDir2 moveDir = this.dragonPartMoveDir[k];
			if (moveDir != BeAIManager.MoveDir2.COUNT)
			{
				VInt moveSpeedX = this.speed.i * BeAIManager.DIR_VALUE3[(int)moveDir, 0];
				VInt moveSpeedY = this.speed.i * BeAIManager.DIR_VALUE3[(int)moveDir, 1];
				this.dragonParts[k].SetFace(false, false, false);
				this.dragonParts[k].SetMoveSpeedX(moveSpeedX);
				this.dragonParts[k].SetMoveSpeedY(moveSpeedY);
			}
		}
	}

	// Token: 0x060182F9 RID: 99065 RVA: 0x00787308 File Offset: 0x00785708
	private void DoTurn(int index, int dir)
	{
		BeAIManager.MoveDir2 moveDir = this.dragonPartMoveDir[index];
		this.dragonPartMoveDir[index] = (BeAIManager.MoveDir2)dir;
		if (moveDir != this.dragonPartMoveDir[index])
		{
			this.ChangeRotation(index);
		}
	}

	// Token: 0x060182FA RID: 99066 RVA: 0x0078733C File Offset: 0x0078573C
	private void ChangeRotation(int index)
	{
		int num = (int)(this.dragonPartMoveDir[index] * (BeAIManager.MoveDir2)45);
		num = 360 - num;
		this.dragonParts[index].m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Actor).transform.localRotation = Quaternion.AngleAxis((float)num, Vector3.up);
	}

	// Token: 0x060182FB RID: 99067 RVA: 0x00787388 File Offset: 0x00785788
	private BeAIManager.MoveDir2 GetJoystickDir()
	{
		BeAIManager.MoveDir2 result = BeAIManager.MoveDir2.COUNT;
		if (base.owner.IsInMoveDirection())
		{
			int joystickDegree = base.owner.GetJoystickDegree();
			result = InputManager.GetDir8(joystickDegree);
		}
		return result;
	}

	// Token: 0x04011736 RID: 71478
	private int[] dragonIDs = new int[]
	{
		60280,
		60281,
		60282
	};

	// Token: 0x04011737 RID: 71479
	private int[] dragonPartNum = new int[]
	{
		1,
		6,
		1
	};

	// Token: 0x04011738 RID: 71480
	private BeAIManager.MoveDir2[] dragonPartMoveDir = new BeAIManager.MoveDir2[8];

	// Token: 0x04011739 RID: 71481
	private BeProjectile head;

	// Token: 0x0401173A RID: 71482
	private BeProjectile tail;

	// Token: 0x0401173B RID: 71483
	private int[] dragonPartTimeAcc = new int[8];

	// Token: 0x0401173C RID: 71484
	private BeProjectile[] dragonParts = new BeProjectile[8];

	// Token: 0x0401173D RID: 71485
	private VInt speed = new VInt(3f);

	// Token: 0x0401173E RID: 71486
	private VInt size = new VInt(0.65f);

	// Token: 0x0401173F RID: 71487
	private VInt pveSpeed = new VInt(3f);

	// Token: 0x04011740 RID: 71488
	private VInt pvpSpeed = new VInt(3f);

	// Token: 0x04011741 RID: 71489
	private VInt height = new VInt(1.3f);

	// Token: 0x04011742 RID: 71490
	private VInt3 headLastPos;

	// Token: 0x04011743 RID: 71491
	private int updateControllTimeAcc;

	// Token: 0x04011744 RID: 71492
	private int updateControllDuration = 250;

	// Token: 0x04011745 RID: 71493
	private int updateMoveOutTimeAcc;

	// Token: 0x04011746 RID: 71494
	private int updateMoveoutDuration = 200;

	// Token: 0x04011747 RID: 71495
	private List<int> dirRecords = new List<int>();

	// Token: 0x04011748 RID: 71496
	private List<int> dirTimeRecords = new List<int>();

	// Token: 0x04011749 RID: 71497
	public Skill3118 skill;

	// Token: 0x0401174A RID: 71498
	public bool canControl;

	// Token: 0x0401174B RID: 71499
	private bool isFinish;
}
