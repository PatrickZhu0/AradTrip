using System;

// Token: 0x02004426 RID: 17446
public abstract class MoveCtrlSkill : BeSkill
{
	// Token: 0x060183B4 RID: 99252 RVA: 0x0078BBE3 File Offset: 0x00789FE3
	protected MoveCtrlSkill(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x1700200F RID: 8207
	// (get) Token: 0x060183B5 RID: 99253
	protected abstract bool SettingSwitch { get; }

	// Token: 0x060183B6 RID: 99254 RVA: 0x0078BBF0 File Offset: 0x00789FF0
	public override void OnStart()
	{
		base.OnStart();
		if (this.SettingSwitch && base.owner.IsInMoveDirection())
		{
			InputManager.PressDir dir = InputManager.GetDir((int)(base.owner.MoveDirectionDegree() * 15));
			if (dir == InputManager.PressDir.DOWN)
			{
				this.useInternalID = true;
			}
			else if (dir != InputManager.PressDir.TOP)
			{
				this.useInternalID = false;
			}
		}
	}
}
