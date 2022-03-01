using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001590 RID: 5520
public class DungeonInfoFrame : ClientFrame
{
	// Token: 0x0600D80D RID: 55309 RVA: 0x0035FD6E File Offset: 0x0035E16E
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/BattleUI/DungeonInfoFrame";
	}

	// Token: 0x0600D80E RID: 55310 RVA: 0x0035FD78 File Offset: 0x0035E178
	protected override void _bindExUI()
	{
		base._bindExUI();
		this.btnClick = this.mBind.GetCom<Button>("btnClick");
		this.closeBtn = this.mBind.GetCom<Button>("closeBtn");
		this.imageContainer = this.mBind.GetCom<Transform>("imageContainer");
		this.singleImage = this.mBind.GetGameObject("singleImage");
		this.knownBtn = this.mBind.GetCom<Button>("knowBtn");
		this.nextPageBtn = this.mBind.GetCom<Button>("nextPageBtn");
	}

	// Token: 0x0600D80F RID: 55311 RVA: 0x0035FE10 File Offset: 0x0035E210
	protected override void _OnOpenFrame()
	{
		base._OnOpenFrame();
		this.closeBtn.onClick.RemoveAllListeners();
		this.closeBtn.onClick.AddListener(delegate()
		{
			base.Close(false);
		});
		this.knownBtn.onClick.RemoveAllListeners();
		this.knownBtn.onClick.AddListener(delegate()
		{
			base.Close(false);
		});
		if (this.userData != null)
		{
			this.PauseFight();
			int num = (int)this.userData;
			if (num == 23101)
			{
				this.nextPageBtn.gameObject.CustomActive(false);
				this.btnClick.gameObject.CustomActive(false);
				this.singleImage.CustomActive(true);
				this.knownBtn.gameObject.CustomActive(true);
				this.imageContainer.gameObject.CustomActive(false);
			}
			else if (num == 23131)
			{
				this.nextPageBtn.gameObject.CustomActive(true);
				this.closeBtn.gameObject.CustomActive(false);
				this.knownBtn.gameObject.CustomActive(false);
				this.btnClick.gameObject.CustomActive(true);
				this.singleImage.CustomActive(false);
				this.ShowImage();
			}
		}
	}

	// Token: 0x0600D810 RID: 55312 RVA: 0x0035FF5C File Offset: 0x0035E35C
	private void ShowImage()
	{
		this.curShowImage = this.imageContainer.GetChild(0).gameObject;
		this.curShowImage.CustomActive(true);
		this.btnClick.onClick.RemoveAllListeners();
		this.btnClick.onClick.AddListener(delegate()
		{
			this.ShowNextPage();
		});
		this.nextPageBtn.onClick.RemoveAllListeners();
		this.nextPageBtn.onClick.AddListener(delegate()
		{
			this.ShowNextPage();
		});
	}

	// Token: 0x0600D811 RID: 55313 RVA: 0x0035FFE4 File Offset: 0x0035E3E4
	private void ShowNextPage()
	{
		int num = 0;
		this.curShowImage.CustomActive(false);
		num++;
		if (num >= this.imageContainer.childCount)
		{
			base.Close(false);
		}
		else
		{
			if (num == this.imageContainer.childCount - 1)
			{
				this.closeBtn.gameObject.CustomActive(true);
				this.btnClick.gameObject.CustomActive(false);
				this.nextPageBtn.gameObject.CustomActive(false);
				this.knownBtn.gameObject.CustomActive(true);
			}
			this.curShowImage = this.imageContainer.GetChild(num).gameObject;
			this.curShowImage.CustomActive(true);
		}
	}

	// Token: 0x0600D812 RID: 55314 RVA: 0x0036009C File Offset: 0x0035E49C
	private void PauseFight()
	{
		this.battle = (BattleMain.instance.GetBattle() as BaseBattle);
		if (this.battle != null && this.battle.dungeonManager != null)
		{
			this.battle.dungeonManager.PauseFight(true, string.Empty, false);
		}
	}

	// Token: 0x0600D813 RID: 55315 RVA: 0x003600F0 File Offset: 0x0035E4F0
	protected override void _OnCloseFrame()
	{
		base._OnCloseFrame();
		if (this.battle != null && this.battle.dungeonManager != null)
		{
			this.battle.dungeonManager.ResumeFight(true, string.Empty, false);
		}
	}

	// Token: 0x0600D814 RID: 55316 RVA: 0x0036012A File Offset: 0x0035E52A
	protected override void _unbindExUI()
	{
		base._unbindExUI();
	}

	// Token: 0x04007ED1 RID: 32465
	private Button btnClick;

	// Token: 0x04007ED2 RID: 32466
	private BaseBattle battle;

	// Token: 0x04007ED3 RID: 32467
	private Transform imageContainer;

	// Token: 0x04007ED4 RID: 32468
	private GameObject curShowImage;

	// Token: 0x04007ED5 RID: 32469
	private GameObject singleImage;

	// Token: 0x04007ED6 RID: 32470
	private Button closeBtn;

	// Token: 0x04007ED7 RID: 32471
	private Button knownBtn;

	// Token: 0x04007ED8 RID: 32472
	private Button nextPageBtn;
}
