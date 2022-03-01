using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200443C RID: 17468
public class Skill1114 : BeSkill
{
	// Token: 0x06018419 RID: 99353 RVA: 0x0078D888 File Offset: 0x0078BC88
	public Skill1114(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601841A RID: 99354 RVA: 0x0078D904 File Offset: 0x0078BD04
	public override void OnInit()
	{
		this.posX = new int[this.skillData.ValueA.Count];
		for (int i = 0; i < this.skillData.ValueA.Count; i++)
		{
			this.posX[i] = TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true);
		}
		this.posY = new int[this.skillData.ValueB.Count];
		for (int j = 0; j < this.skillData.ValueB.Count; j++)
		{
			this.posY[j] = TableManager.GetValueFromUnionCell(this.skillData.ValueB[j], base.level, true);
		}
	}

	// Token: 0x0601841B RID: 99355 RVA: 0x0078D9D4 File Offset: 0x0078BDD4
	public override void OnStart()
	{
		this.camera = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController();
		this.m_CurrBoomNum = 0;
		this.time = 0;
		this.flag = false;
		this.m_BoomFlag = false;
		this.GetMovePos();
		this.KillOther();
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			if (!base.owner.isLocalActor)
			{
				return;
			}
			string a = args[0] as string;
			if (a == "removeCamera")
			{
				this.flag = true;
				this.SetCameraPause(true);
				Vector3 localPosition = this.camera.transform.localPosition;
				this.startPos = localPosition;
				int num = (!base.owner.GetFace()) ? 4 : -4;
				this.pos = new Vector3(base.owner.GetPosition().vector3.x + (float)num, localPosition.y, localPosition.z);
			}
			else if (a == "addCamera")
			{
				this.flag = false;
				this.RestoreCamera();
			}
		});
		this.m_BoomHandle = base.owner.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
		{
			if (!this.m_BoomFlag)
			{
				BeBuff beBuff = args[0] as BeBuff;
				if (beBuff.buffID == this.m_AddBuffId)
				{
					this.m_BoomFlag = true;
					if (this.m_KillList.Count > 0)
					{
						for (int i = 0; i < this.m_KillList.Count; i++)
						{
							if (this.m_KillList[i] != null)
							{
								BeEntity beEntity = this.m_KillList[i];
								if (beEntity != null)
								{
									this.CreateBoomEntity(beEntity);
								}
							}
						}
					}
				}
			}
		});
	}

	// Token: 0x0601841C RID: 99356 RVA: 0x0078DA68 File Offset: 0x0078BE68
	public override void OnUpdate(int iDeltime)
	{
		base.OnUpdate(iDeltime);
		if (base.owner.isLocalActor && this.flag)
		{
			base.OnUpdate(iDeltime);
			this.time += iDeltime;
			this.camera.SetCameraPos(Vector3.Lerp(this.startPos, this.pos, (float)this.time / 1000f * this.speed));
		}
	}

	// Token: 0x0601841D RID: 99357 RVA: 0x0078DADC File Offset: 0x0078BEDC
	private void SetCameraPause(bool flag)
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().SetPause(flag);
	}

	// Token: 0x0601841E RID: 99358 RVA: 0x0078DB10 File Offset: 0x0078BF10
	protected void GetMovePos()
	{
		BeScene currentBeScene = base.owner.CurrentBeScene;
		this.m_OwnerStartPos = base.owner.GetPosition();
		int num = currentBeScene.logicXSize.y - currentBeScene.logicXSize.x - GlobalLogic.VALUE_100000;
		int num2 = currentBeScene.logicZSize.y - currentBeScene.logicZSize.x;
		int num3 = (!base.owner.GetFace()) ? 1 : -1;
		int num4 = num2 / 4;
		int x = this.m_OwnerStartPos.x;
		int y = this.m_OwnerStartPos.y;
		int z = this.m_OwnerStartPos.z;
		for (int i = 0; i < this.posX.Length; i++)
		{
			this.m_MovePosArray[i] = new VInt3(x + this.posX[i] * num3, y + this.posY[i], z);
		}
	}

	// Token: 0x0601841F RID: 99359 RVA: 0x0078DC04 File Offset: 0x0078C004
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase < 10 && phase > 1)
		{
			VInt3 vint = default(VInt3);
			if (phase > 1 && phase < 10)
			{
				vint = this.m_MovePosArray[phase - 2];
			}
			if (base.owner.CurrentBeScene.IsInBlockPlayer(vint))
			{
				BeAIManager.FindStandPositionNew(vint, base.owner.CurrentBeScene, base.owner.GetFace(), false, 30);
			}
			else
			{
				base.owner.SetPosition(vint, false, true, false);
			}
		}
		else if (phase == 10 && this.m_KillList.Count <= 0)
		{
			base.Cancel();
			base.owner.sgSwitchStates(new BeStateData(0, 0));
		}
	}

	// Token: 0x06018420 RID: 99360 RVA: 0x0078DCD2 File Offset: 0x0078C0D2
	protected void KillOther()
	{
		this.m_KillHandle = base.owner.RegisterEvent(BeEventType.onKill, delegate(object[] args)
		{
			if (!this.m_BoomFlag)
			{
				BeActor beActor = args[0] as BeActor;
				if (beActor != null && beActor.GetPID() != base.owner.GetPID())
				{
					beActor.showDamageNumber = false;
					beActor.Pause(GlobalLogic.VALUE_10000, true);
					if (beActor.buffController != null)
					{
						beActor.buffController.TryAddBuff(this.m_DeadFlagBuffId, GlobalLogic.VALUE_10000, 1);
					}
					this.m_KillList.Add(beActor);
					GeEffectEx geEffectEx = beActor.m_pkGeActor.CreateEffect(this.m_DeadEffect, "[actor]OrignBuff", 0f, Vec3.zero, 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
				}
			}
		});
	}

	// Token: 0x06018421 RID: 99361 RVA: 0x0078DCF4 File Offset: 0x0078C0F4
	protected void CreateBoomEntity(BeEntity entity)
	{
		this.m_CurrBoomNum++;
		if (this.m_CurrBoomNum < this.m_BoomMaxNum)
		{
			base.owner.AddEntity(this.m_BoomEntityId, this.GetBuffPos(entity), 1, 0);
		}
		entity.Resume();
		entity.DoDead(false);
	}

	// Token: 0x06018422 RID: 99362 RVA: 0x0078DD48 File Offset: 0x0078C148
	protected VInt3 GetBuffPos(BeEntity entity)
	{
		VInt3 position = entity.GetPosition();
		return new VInt3(position.x, position.y, position.z);
	}

	// Token: 0x06018423 RID: 99363 RVA: 0x0078DD76 File Offset: 0x0078C176
	protected void RemoveEffecct()
	{
		this.m_KillList.Clear();
		if (this.m_KillHandle != null)
		{
			this.m_KillHandle.Remove();
		}
		if (this.m_BoomHandle != null)
		{
			this.m_BoomHandle.Remove();
		}
	}

	// Token: 0x06018424 RID: 99364 RVA: 0x0078DDAF File Offset: 0x0078C1AF
	private void RestoreCamera()
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		this.SetCameraPause(false);
	}

	// Token: 0x06018425 RID: 99365 RVA: 0x0078DDC9 File Offset: 0x0078C1C9
	public override void OnCancel()
	{
		this.RemoveEffecct();
		this.RestoreCamera();
	}

	// Token: 0x06018426 RID: 99366 RVA: 0x0078DDD7 File Offset: 0x0078C1D7
	public override void OnFinish()
	{
		this.RemoveEffecct();
		this.RestoreCamera();
	}

	// Token: 0x0401180F RID: 71695
	protected VInt3 m_OwnerStartPos = default(VInt3);

	// Token: 0x04011810 RID: 71696
	protected VInt3[] m_MovePosArray = new VInt3[8];

	// Token: 0x04011811 RID: 71697
	protected string m_DeadEffect = "Effects/Hero_Gunman/Gunman_juexing/Perfab/Eff_Gunman_juexing_ztbzbuff";

	// Token: 0x04011812 RID: 71698
	protected int m_BoomEntityId = 60279;

	// Token: 0x04011813 RID: 71699
	protected int m_BoomMaxNum = 10;

	// Token: 0x04011814 RID: 71700
	protected int m_CurrBoomNum;

	// Token: 0x04011815 RID: 71701
	protected int m_DeadFlagBuffId = 111403;

	// Token: 0x04011816 RID: 71702
	protected int m_AddBuffId = 111402;

	// Token: 0x04011817 RID: 71703
	protected BeEventHandle m_BoomHandle;

	// Token: 0x04011818 RID: 71704
	protected BeEventHandle m_KillHandle;

	// Token: 0x04011819 RID: 71705
	protected List<BeEntity> m_KillList = new List<BeEntity>();

	// Token: 0x0401181A RID: 71706
	protected bool m_BoomFlag;

	// Token: 0x0401181B RID: 71707
	private int[] posX;

	// Token: 0x0401181C RID: 71708
	private int[] posY;

	// Token: 0x0401181D RID: 71709
	private Vector3 pos;

	// Token: 0x0401181E RID: 71710
	private bool flag;

	// Token: 0x0401181F RID: 71711
	private float speed = 3f;

	// Token: 0x04011820 RID: 71712
	private GeCameraControllerScroll camera;

	// Token: 0x04011821 RID: 71713
	private Vector3 startPos;

	// Token: 0x04011822 RID: 71714
	private int time;
}
