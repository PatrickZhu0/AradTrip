using System;
using UnityEngine;

// Token: 0x020040F7 RID: 16631
public class BDModifySpeed : BDEventBase
{
	// Token: 0x06016A53 RID: 92755 RVA: 0x006DB6C8 File Offset: 0x006D9AC8
	public BDModifySpeed(int tag, DSkillPropertyModifyType type, float value, float movedValue = 0f, bool jumpToTargetPos = false, bool joystickControl = false, float valueAcc = 0f, float movedValueAcc = 0f, DModifyXBackward modifyXBackward = DModifyXBackward.NONE, bool eachFrameModify = false, bool useMovedYValue = false, float movedYValue = 0f, float movedYValueAcc = 0f)
	{
		this.tag = tag;
		this.filter = type;
		this.value = new VInt(value);
		this.valueAcc = new VInt(valueAcc);
		this.movedValue = new VInt(movedValue);
		this.movedValueAcc = new VInt(movedValueAcc);
		this.modifyXBackward = modifyXBackward;
		this.movedYValue = new VInt(movedYValue);
		this.movedYValueAcc = new VInt(movedYValueAcc);
		this.jumpToTargetPos = jumpToTargetPos;
		this.joystickControl = joystickControl;
		this.eachFrameModify = eachFrameModify;
		this.useMovedYValue = useMovedYValue;
	}

	// Token: 0x06016A54 RID: 92756 RVA: 0x006DB760 File Offset: 0x006D9B60
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		VInt vint = this.value;
		VInt vint2 = this.value;
		if (pkEntity.IsCastingSkill())
		{
			BeActor beActor = pkEntity as BeActor;
			if (beActor != null)
			{
				BeSkill currentSkill = beActor.GetCurrentSkill();
				if (currentSkill != null)
				{
					if (this.eachFrameModify)
					{
						if (beActor.IsPressForwardMoveCmd() && this.movedValue != 0)
						{
							vint = this.movedValue + this.movedValueAcc.i * (currentSkill.level - 1);
						}
						else if (beActor.IsPressBackwardMoveCmd() && this.modifyXBackward == DModifyXBackward.STOP)
						{
							vint = 0;
						}
						else if (beActor.IsPressBackwardMoveCmd() && this.modifyXBackward == DModifyXBackward.BACKMOVE)
						{
							vint = -this.movedValue - this.movedValueAcc.i * (currentSkill.level - 1);
						}
						else
						{
							vint = this.value + this.valueAcc.i * (currentSkill.level - 1);
						}
						vint2 = this.movedYValue + this.movedYValueAcc.i * (currentSkill.level - 1);
					}
					else
					{
						if (currentSkill.pressedForwardMove && this.movedValue != 0)
						{
							vint = this.movedValue + this.movedValueAcc.i * (currentSkill.level - 1);
						}
						else
						{
							vint = this.value + this.valueAcc.i * (currentSkill.level - 1);
						}
						vint2 = this.movedYValue + this.movedYValueAcc.i * (currentSkill.level - 1);
					}
				}
			}
		}
		int[] array = new int[]
		{
			GlobalLogic.VALUE_1000
		};
		pkEntity.TriggerEvent(BeEventType.onChangeModifySpeed, new object[]
		{
			this.tag,
			array
		});
		vint = vint.i * VFactor.NewVFactor(array[0], GlobalLogic.VALUE_1000);
		if (this.joystickControl)
		{
			switch (InputManager.GetDir8(pkEntity.GetJoystickDegree()))
			{
			case BeAIManager.MoveDir2.RIGHT:
			case BeAIManager.MoveDir2.LEFT:
				pkEntity.SetMoveSpeedXLocal(vint);
				break;
			case BeAIManager.MoveDir2.RIGHT_TOP:
			case BeAIManager.MoveDir2.TOP:
			case BeAIManager.MoveDir2.LEFT_TOP:
				pkEntity.SetMoveSpeedXLocal(vint);
				if (this.useMovedYValue)
				{
					pkEntity.SetMoveSpeedY(vint2);
				}
				else
				{
					VFactor f = new VFactor(500L, (long)GlobalLogic.VALUE_1000);
					pkEntity.SetMoveSpeedY(vint.i * f);
				}
				break;
			case BeAIManager.MoveDir2.LEFT_DOWN:
			case BeAIManager.MoveDir2.DOWN:
			case BeAIManager.MoveDir2.RIGHT_DOWN:
				pkEntity.SetMoveSpeedXLocal(vint);
				if (this.useMovedYValue)
				{
					pkEntity.SetMoveSpeedY(-vint2);
				}
				else
				{
					VFactor f2 = new VFactor(500L, (long)GlobalLogic.VALUE_1000);
					pkEntity.SetMoveSpeedY(-vint.i * f2);
				}
				break;
			case BeAIManager.MoveDir2.COUNT:
				break;
			default:
				pkEntity.SetMoveSpeedXLocal(vint);
				break;
			}
		}
		else
		{
			switch (this.filter)
			{
			case DSkillPropertyModifyType.SPEED_X:
				pkEntity.SetMoveSpeedXLocal(vint);
				break;
			case DSkillPropertyModifyType.SPEED_Y:
				pkEntity.SetMoveSpeedY(vint);
				break;
			case DSkillPropertyModifyType.SPEED_Z:
				pkEntity.SetMoveSpeedZ(vint);
				if (this.jumpToTargetPos)
				{
					BeActor beActor2 = pkEntity as BeActor;
					if (beActor2 != null && beActor2.IsMonster() && beActor2.aiManager != null && beActor2.aiManager.aiTarget != null)
					{
						VInt2 vint3 = new VInt2(5f, 4f);
						VFactor vfactor = VFactor.NewVFactor(1L, 180000L) * (long)Mathf.Abs(vint.i) * 2L * 30L / 60L;
						VInt3 position = beActor2.GetPosition();
						VInt3 position2 = beActor2.aiManager.aiTarget.GetPosition();
						if (vfactor != VFactor.zero)
						{
							if (Mathf.Abs(position2.x - position.x) > BDModifySpeed.halfMI.i)
							{
								int num = Mathf.Abs(position2.x - position.x) * (VFactor.one / vfactor);
								num = Mathf.Min(num, vint3.x);
								pkEntity.SetMoveSpeedX((position2.x - position.x <= 0) ? (-num) : num);
							}
							if (Mathf.Abs(position2.y - position.y) > BDModifySpeed.halfMI.i)
							{
								int num2 = Mathf.Abs(position2.y - position.y) * (VFactor.one / vfactor);
								num2 = Mathf.Min(num2, vint3.y);
								pkEntity.SetMoveSpeedY((position2.y - position.y <= 0) ? (-num2) : num2);
							}
						}
						pkEntity.SetFace(position2.x < position.x, false, false);
					}
				}
				break;
			case DSkillPropertyModifyType.SPEED_XACC:
				pkEntity.SetMoveSpeedXAcc(vint);
				break;
			case DSkillPropertyModifyType.SPEED_YACC:
				pkEntity.SetMoveSpeedYAcc(vint);
				break;
			case DSkillPropertyModifyType.SPEED_ZACC:
				pkEntity.SetMoveSpeedZAcc(vint);
				break;
			case DSkillPropertyModifyType.SPEED_ZACC_NEW:
				pkEntity.SetMoveSpeedZAccExtra(vint);
				break;
			}
		}
	}

	// Token: 0x04010225 RID: 66085
	public int tag;

	// Token: 0x04010226 RID: 66086
	public DSkillPropertyModifyType filter;

	// Token: 0x04010227 RID: 66087
	public VInt value;

	// Token: 0x04010228 RID: 66088
	public VInt valueAcc;

	// Token: 0x04010229 RID: 66089
	public VInt movedValue;

	// Token: 0x0401022A RID: 66090
	public VInt movedValueAcc;

	// Token: 0x0401022B RID: 66091
	public DModifyXBackward modifyXBackward;

	// Token: 0x0401022C RID: 66092
	public VInt movedYValue;

	// Token: 0x0401022D RID: 66093
	public VInt movedYValueAcc;

	// Token: 0x0401022E RID: 66094
	public bool jumpToTargetPos;

	// Token: 0x0401022F RID: 66095
	public bool joystickControl;

	// Token: 0x04010230 RID: 66096
	public bool eachFrameModify;

	// Token: 0x04010231 RID: 66097
	public bool useMovedYValue;

	// Token: 0x04010232 RID: 66098
	private static readonly VInt halfMI = VInt.Float2VIntValue(0.5f);
}
