using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200449B RID: 17563
public class Skill2301 : BeSkill
{
	// Token: 0x060186BC RID: 100028 RVA: 0x0079D6F4 File Offset: 0x0079BAF4
	public Skill2301(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060186BD RID: 100029 RVA: 0x0079D730 File Offset: 0x0079BB30
	public override void OnPostInit()
	{
		if (this.inTown)
		{
			return;
		}
		if (base.owner == null || base.owner.m_pkGeActor == null)
		{
			return;
		}
		if (!base.owner.isLocalActor)
		{
			return;
		}
		if (this.canSlide)
		{
			ComCommonBind forwardBackArrowBind = base.owner.m_pkGeActor.GetForwardBackArrowBind(this.strIndicator);
			if (forwardBackArrowBind == null)
			{
				return;
			}
			this.objIndicator = forwardBackArrowBind.gameObject;
			for (int i = 0; i < 2; i++)
			{
				this.objs[i] = forwardBackArrowBind.GetGameObject(string.Format("obj{0}", i));
				this.texts[i] = forwardBackArrowBind.GetCom<Text>(string.Format("txt{0}", i));
			}
			this.ChangeDir();
			if (base.owner != null)
			{
				this.RemoveHandle();
				this.mChangeFaceHandle = base.owner.RegisterEvent(BeEventType.onChangeFace, delegate(object[] args)
				{
					this.ChangeDir();
				});
			}
			this.strValue = new string[]
			{
				string.Empty,
				string.Empty
			};
			this.SetAllArrowActive(false);
		}
		else
		{
			this.joystickMode = SkillJoystickMode.NONE;
		}
	}

	// Token: 0x060186BE RID: 100030 RVA: 0x0079D864 File Offset: 0x0079BC64
	public override void OnInit()
	{
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("2301") == InputManager.SlideSetting.SLIDE);
	}

	// Token: 0x060186BF RID: 100031 RVA: 0x0079D87E File Offset: 0x0079BC7E
	public override void OnStart()
	{
		this.SetAllArrowActive(false);
	}

	// Token: 0x060186C0 RID: 100032 RVA: 0x0079D887 File Offset: 0x0079BC87
	public override void OnCancel()
	{
		this.SetAllArrowActive(false);
	}

	// Token: 0x060186C1 RID: 100033 RVA: 0x0079D890 File Offset: 0x0079BC90
	public override void OnFinish()
	{
		this.SetAllArrowActive(false);
	}

	// Token: 0x060186C2 RID: 100034 RVA: 0x0079D899 File Offset: 0x0079BC99
	public override void OnReleaseJoystick()
	{
		this.SetAllArrowActive(false);
	}

	// Token: 0x060186C3 RID: 100035 RVA: 0x0079D8A4 File Offset: 0x0079BCA4
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
		InputManager.PressDir forwardBack = InputManager.GetForwardBack(degree);
		if (forwardBack == InputManager.PressDir.LEFT)
		{
			this.ShowArrow(Skill2301.DIR.LEFT);
		}
		else
		{
			this.ShowArrow(Skill2301.DIR.RIGHT);
		}
	}

	// Token: 0x060186C4 RID: 100036 RVA: 0x0079D8F0 File Offset: 0x0079BCF0
	protected void ShowArrow(Skill2301.DIR dir)
	{
		if (!this.CanUseSkill())
		{
			return;
		}
		if (dir >= Skill2301.DIR.COUNT)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			if (i >= this.objs.Length || i >= this.texts.Length)
			{
				break;
			}
			GameObject gameObject = this.objs[i];
			if (!(gameObject == null))
			{
				if (dir == (Skill2301.DIR)i)
				{
					this.texts[i].text = this.strValue[i];
					this.objs[i].CustomActive(true);
				}
				else
				{
					this.objs[i].CustomActive(false);
				}
			}
		}
	}

	// Token: 0x060186C5 RID: 100037 RVA: 0x0079D99C File Offset: 0x0079BD9C
	protected void SetAllArrowActive(bool active)
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		for (int i = 0; i < 2; i++)
		{
			if (i >= this.objs.Length)
			{
				break;
			}
			GameObject gameObject = this.objs[i];
			if (!(gameObject == null))
			{
				gameObject.CustomActive(active);
			}
		}
	}

	// Token: 0x060186C6 RID: 100038 RVA: 0x0079DA00 File Offset: 0x0079BE00
	protected void ChangeDir()
	{
		if (base.owner == null)
		{
			return;
		}
		bool face = base.owner.GetFace();
		int num = (!face) ? 1 : -1;
		if (this.objIndicator != null)
		{
			Vector3 localScale = this.objIndicator.transform.localScale;
			localScale.x = Mathf.Abs(localScale.x) * (float)num;
			this.objIndicator.transform.localScale = localScale;
		}
	}

	// Token: 0x060186C7 RID: 100039 RVA: 0x0079DA7C File Offset: 0x0079BE7C
	protected void RemoveHandle()
	{
		if (this.mChangeFaceHandle != null)
		{
			this.mChangeFaceHandle.Remove();
			this.mChangeFaceHandle = null;
		}
	}

	// Token: 0x040119F0 RID: 72176
	protected string strIndicator = "UIFlatten/Prefabs/Battle_Digit/Indicator_ForwardBack";

	// Token: 0x040119F1 RID: 72177
	protected GameObject objIndicator;

	// Token: 0x040119F2 RID: 72178
	protected GameObject[] objs = new GameObject[2];

	// Token: 0x040119F3 RID: 72179
	protected Text[] texts = new Text[2];

	// Token: 0x040119F4 RID: 72180
	protected BeEventHandle mChangeFaceHandle;

	// Token: 0x040119F5 RID: 72181
	protected string[] strValue = new string[2];

	// Token: 0x0200449C RID: 17564
	protected enum DIR
	{
		// Token: 0x040119F7 RID: 72183
		LEFT,
		// Token: 0x040119F8 RID: 72184
		RIGHT,
		// Token: 0x040119F9 RID: 72185
		COUNT
	}
}
