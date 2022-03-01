using System;

// Token: 0x02004490 RID: 17552
public class Skill21200 : BeSkill
{
	// Token: 0x06018674 RID: 99956 RVA: 0x0079BED5 File Offset: 0x0079A2D5
	public Skill21200(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x17002012 RID: 8210
	// (get) Token: 0x06018675 RID: 99957 RVA: 0x0079BEF6 File Offset: 0x0079A2F6
	public MouthState stat
	{
		get
		{
			return this.curState;
		}
	}

	// Token: 0x06018676 RID: 99958 RVA: 0x0079BF00 File Offset: 0x0079A300
	public override void OnInit()
	{
		this.bInitClose = (TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true) == 0);
		this.height = new VInt((float)TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true) / 1000f);
		this.totalTime = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.mouseOpenSpeed = VFactor.NewVFactor(this.height.i, this.totalTime);
		if (this.bInitClose)
		{
			this.curState = MouthState.Mouth_Close;
		}
		else
		{
			this.curState = MouthState.Mouth_Open;
			this.curheightAdd = this.height.i;
		}
		if (base.owner == null || base.owner.CurrentBeScene == null)
		{
			return;
		}
		base.owner.CurrentBeScene.SetDayTime(!this.bInitClose);
	}

	// Token: 0x06018677 RID: 99959 RVA: 0x0079C010 File Offset: 0x0079A410
	public override void OnStart()
	{
		switch (this.curState)
		{
		case MouthState.Mouth_Open:
			this.curState = MouthState.Mouth_Ready_Close;
			if (base.owner != null && base.owner.CurrentBeScene != null)
			{
				base.owner.CurrentBeScene.SetDayTime(false);
				base.owner.CurrentBeScene.TriggerEvent(BeEventSceneType.onMouthClose, new object[]
				{
					true
				});
			}
			break;
		case MouthState.Mouth_Ready_Open:
			this.curState = MouthState.Mouth_Ready_Close;
			if (base.owner != null && base.owner.CurrentBeScene != null)
			{
				base.owner.CurrentBeScene.SetDayTime(false);
				base.owner.CurrentBeScene.TriggerEvent(BeEventSceneType.onMouthClose, new object[]
				{
					true
				});
			}
			break;
		case MouthState.Mouth_Close:
			this.curState = MouthState.Mouth_Ready_Open;
			if (base.owner != null && base.owner.CurrentBeScene != null)
			{
				base.owner.CurrentBeScene.SetDayTime(true);
				base.owner.CurrentBeScene.TriggerEvent(BeEventSceneType.onMouthClose, new object[]
				{
					false
				});
			}
			break;
		case MouthState.Mouth_Ready_Close:
			this.curState = MouthState.Mouth_Ready_Open;
			if (base.owner != null && base.owner.CurrentBeScene != null)
			{
				base.owner.CurrentBeScene.SetDayTime(true);
				base.owner.CurrentBeScene.TriggerEvent(BeEventSceneType.onMouthClose, new object[]
				{
					false
				});
			}
			break;
		}
	}

	// Token: 0x06018678 RID: 99960 RVA: 0x0079C1A4 File Offset: 0x0079A5A4
	public override void OnUpdate(int iDeltime)
	{
		base.OnUpdate(iDeltime);
		MouthState mouthState = this.curState;
		if (mouthState != MouthState.Mouth_Ready_Close)
		{
			if (mouthState == MouthState.Mouth_Ready_Open)
			{
				int num = (this.mouseOpenSpeed * (long)iDeltime).integer;
				int i = this.curheightAdd + num;
				if (i > this.height)
				{
					num = this.height.i - this.curheightAdd;
				}
				VInt3 position = base.owner.GetPosition();
				position.z += num;
				this.curheightAdd += num;
				base.owner.SetPosition(position, false, true, false);
				if (i >= this.height)
				{
					this.curState = MouthState.Mouth_Open;
				}
			}
		}
		else
		{
			int integer = (this.mouseOpenSpeed * (long)iDeltime).integer;
			int num2 = this.curheightAdd - integer;
			if (num2 < 0)
			{
				integer = this.curheightAdd;
			}
			VInt3 position2 = base.owner.GetPosition();
			this.curheightAdd -= integer;
			position2.z -= integer;
			base.owner.SetPosition(position2, false, true, false);
			if (this.curheightAdd <= 0)
			{
				this.curState = MouthState.Mouth_Close;
			}
		}
	}

	// Token: 0x040119C6 RID: 72134
	private bool bInitClose;

	// Token: 0x040119C7 RID: 72135
	private int totalTime;

	// Token: 0x040119C8 RID: 72136
	private VFactor mouseOpenSpeed = VFactor.zero;

	// Token: 0x040119C9 RID: 72137
	private int durTime;

	// Token: 0x040119CA RID: 72138
	private VInt height = 0;

	// Token: 0x040119CB RID: 72139
	private int curheightAdd;

	// Token: 0x040119CC RID: 72140
	private MouthState curState;
}
