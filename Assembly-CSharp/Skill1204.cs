using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200444C RID: 17484
public class Skill1204 : BeSkill
{
	// Token: 0x0601844D RID: 99405 RVA: 0x0078E129 File Offset: 0x0078C529
	public Skill1204(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601844E RID: 99406 RVA: 0x0078E164 File Offset: 0x0078C564
	public override void OnPostInit()
	{
		if (this.inTown)
		{
			return;
		}
		if (base.owner == null)
		{
			return;
		}
		if (!base.owner.isLocalActor)
		{
			return;
		}
		if (this.canSlide)
		{
			ComCommonBind arrowBind = base.owner.m_pkGeActor.GetArrowBind(this.strIndicator);
			if (arrowBind == null)
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				this.sprites[i] = arrowBind.GetCom<Image>(string.Format("spr{0}", i));
				this.texts[i] = arrowBind.GetCom<Text>(string.Format("txt{0}", i));
			}
			this.ChangeText();
			if (base.owner != null)
			{
				this.RemoveHandle();
				this.mChangeFaceHandle = base.owner.RegisterEvent(BeEventType.onChangeFace, delegate(object[] args)
				{
					this.ChangeText();
				});
			}
			this.strValue = new string[]
			{
				"上",
				"前",
				"下"
			};
			this.HideAllArrow();
		}
		else
		{
			this.joystickMode = SkillJoystickMode.NONE;
		}
	}

	// Token: 0x0601844F RID: 99407 RVA: 0x0078E283 File Offset: 0x0078C683
	public override void OnInit()
	{
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("1204") == InputManager.SlideSetting.SLIDE);
	}

	// Token: 0x06018450 RID: 99408 RVA: 0x0078E29D File Offset: 0x0078C69D
	public override void OnStart()
	{
		this.HideAllArrow();
	}

	// Token: 0x06018451 RID: 99409 RVA: 0x0078E2A5 File Offset: 0x0078C6A5
	public override void OnCancel()
	{
		this.HideAllArrow();
	}

	// Token: 0x06018452 RID: 99410 RVA: 0x0078E2AD File Offset: 0x0078C6AD
	public override void OnFinish()
	{
		this.HideAllArrow();
	}

	// Token: 0x06018453 RID: 99411 RVA: 0x0078E2B5 File Offset: 0x0078C6B5
	public override void OnReleaseJoystick()
	{
		this.HideAllArrow();
	}

	// Token: 0x06018454 RID: 99412 RVA: 0x0078E2C0 File Offset: 0x0078C6C0
	public override void OnUpdateJoystick(int degree)
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		if (!this.canSlide)
		{
			return;
		}
		InputManager.PressDir dir = InputManager.GetDir(degree);
		if (dir == InputManager.PressDir.TOP)
		{
			this.ShowArrow(Skill1204.DIR.TOP);
		}
		else if (dir == InputManager.PressDir.DOWN)
		{
			this.ShowArrow(Skill1204.DIR.DOWN);
		}
		else
		{
			this.ShowArrow(Skill1204.DIR.FORWARD);
		}
	}

	// Token: 0x06018455 RID: 99413 RVA: 0x0078E320 File Offset: 0x0078C720
	protected void ShowArrow(Skill1204.DIR dir)
	{
		if (!this.CanUseSkill())
		{
			return;
		}
		if (dir >= Skill1204.DIR.COUNT)
		{
			return;
		}
		this.HideAllArrow();
		Color color = this.sprites[(int)dir].color;
		color.a = 255f;
		this.sprites[(int)dir].color = color;
		Color color2 = this.texts[(int)dir].color;
		color2.a = 255f;
		this.texts[(int)dir].text = this.strValue[(int)dir];
		this.texts[(int)dir].color = color2;
	}

	// Token: 0x06018456 RID: 99414 RVA: 0x0078E3B0 File Offset: 0x0078C7B0
	protected void HideAllArrow()
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			if (!(this.sprites[i] == null))
			{
				Color color = this.sprites[i].color;
				color.a = 0f;
				this.sprites[i].color = color;
				Color color2 = this.texts[i].color;
				color2.a = 0f;
				this.texts[i].color = color2;
			}
		}
	}

	// Token: 0x06018457 RID: 99415 RVA: 0x0078E448 File Offset: 0x0078C848
	protected void ChangeText()
	{
		if (base.owner == null)
		{
			return;
		}
		bool face = base.owner.GetFace();
		for (int i = 0; i < this.texts.Length; i++)
		{
			if (this.texts[i] != null)
			{
				int num = (!face) ? 1 : -1;
				this.texts[i].rectTransform.localScale = new Vector3((float)num, 1f, 1f);
			}
		}
	}

	// Token: 0x06018458 RID: 99416 RVA: 0x0078E4CA File Offset: 0x0078C8CA
	protected void RemoveHandle()
	{
		if (this.mChangeFaceHandle != null)
		{
			this.mChangeFaceHandle.Remove();
			this.mChangeFaceHandle = null;
		}
	}

	// Token: 0x0401182B RID: 71723
	protected string strIndicator = "UIFlatten/Prefabs/Battle_Digit/Indicator_ShouLei";

	// Token: 0x0401182C RID: 71724
	protected GameObject objIndicator;

	// Token: 0x0401182D RID: 71725
	protected Image[] sprites = new Image[3];

	// Token: 0x0401182E RID: 71726
	protected Text[] texts = new Text[3];

	// Token: 0x0401182F RID: 71727
	protected BeEventHandle mChangeFaceHandle;

	// Token: 0x04011830 RID: 71728
	protected string[] strValue = new string[3];

	// Token: 0x0200444D RID: 17485
	protected enum DIR
	{
		// Token: 0x04011832 RID: 71730
		TOP,
		// Token: 0x04011833 RID: 71731
		FORWARD,
		// Token: 0x04011834 RID: 71732
		DOWN,
		// Token: 0x04011835 RID: 71733
		COUNT
	}
}
