using System;
using GameClient;

// Token: 0x020043C1 RID: 17345
public class Mechanism2132 : BeMechanism
{
	// Token: 0x060180EC RID: 98540 RVA: 0x00778BE8 File Offset: 0x00776FE8
	public Mechanism2132(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x060180ED RID: 98541 RVA: 0x00778C04 File Offset: 0x00777004
	public override void OnInit()
	{
		this.m_frameTime = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.m_effectPath = this.data.StringValueA[0];
	}

	// Token: 0x060180EE RID: 98542 RVA: 0x00778C50 File Offset: 0x00777050
	public override void OnStart()
	{
		if (base.owner.CurrentBeScene != null)
		{
			this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onEnter, new BeEvent.BeEventHandleNew.Function(this._onGameStart));
		}
	}

	// Token: 0x060180EF RID: 98543 RVA: 0x00778C85 File Offset: 0x00777085
	private void _onGameStart(BeEvent.BeEventParam param)
	{
		Singleton<ClientSystemManager>.instance.OpenFrame<RaceGameTipFrame>(FrameLayer.Middle, null, string.Empty);
		this.m_durTime = 0;
	}

	// Token: 0x060180F0 RID: 98544 RVA: 0x00778CA0 File Offset: 0x007770A0
	public override void OnUpdateGraphic(int deltaTime)
	{
		base.OnUpdateGraphic(deltaTime);
		if (this.m_durTime < 0)
		{
			return;
		}
		this.m_durTime += deltaTime;
		if (this.m_durTime >= this.m_frameTime)
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<RaceGameTipFrame>(null, false);
			Singleton<ClientSystemManager>.instance.PlayUIEffect(FrameLayer.Top, this.m_effectPath, 20f);
			base.Finish();
		}
	}

	// Token: 0x04011567 RID: 71015
	private int m_frameTime;

	// Token: 0x04011568 RID: 71016
	private int m_durTime = -1;

	// Token: 0x04011569 RID: 71017
	private string m_effectPath = string.Empty;
}
