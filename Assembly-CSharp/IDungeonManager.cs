using System;

// Token: 0x020041F5 RID: 16885
public interface IDungeonManager
{
	// Token: 0x06017591 RID: 95633
	BeScene CreateBeScene();

	// Token: 0x06017592 RID: 95634
	void DestoryBeScene();

	// Token: 0x06017593 RID: 95635
	BeScene GetBeScene();

	// Token: 0x06017594 RID: 95636
	GeSceneEx GetGeScene();

	// Token: 0x06017595 RID: 95637
	DungeonDataManager GetDungeonDataManager();

	// Token: 0x06017596 RID: 95638
	void StartFight(bool isFinishFight = false);

	// Token: 0x06017597 RID: 95639
	void FinishFight();

	// Token: 0x06017598 RID: 95640
	bool IsFinishFight();

	// Token: 0x06017599 RID: 95641
	void PauseFight(bool pauseAnimation = true, string tag = "", bool force = false);

	// Token: 0x0601759A RID: 95642
	void ResumeFight(bool pauseAnimation = true, string tag = "", bool force = false);

	// Token: 0x0601759B RID: 95643
	void OpenFade(DungeonFadeCallback fadein, DungeonFadeCallback load, DungeonFadeCallback fadeout, uint intime, uint outime);

	// Token: 0x0601759C RID: 95644
	void Update(int delta);

	// Token: 0x0601759D RID: 95645
	void UpdateGraphic(int delta);

	// Token: 0x0601759E RID: 95646
	void DoGraphicBackToFront();
}
