using System;
using System.Collections.Generic;
using behaviac;
using GameClient;
using UnityEngine;

// Token: 0x02004201 RID: 16897
public class LevelManager
{
	// Token: 0x17001FDF RID: 8159
	// (get) Token: 0x0601761C RID: 95772 RVA: 0x0073102A File Offset: 0x0072F42A
	// (set) Token: 0x0601761D RID: 95773 RVA: 0x00731032 File Offset: 0x0072F432
	public BaseBattle baseBattle { get; private set; }

	// Token: 0x17001FE0 RID: 8160
	// (get) Token: 0x0601761E RID: 95774 RVA: 0x0073103B File Offset: 0x0072F43B
	// (set) Token: 0x0601761F RID: 95775 RVA: 0x00731043 File Offset: 0x0072F443
	public int CountTime
	{
		get
		{
			return this.countTime;
		}
		set
		{
			this.countTime = value;
		}
	}

	// Token: 0x17001FE1 RID: 8161
	// (get) Token: 0x06017620 RID: 95776 RVA: 0x0073104C File Offset: 0x0072F44C
	// (set) Token: 0x06017621 RID: 95777 RVA: 0x00731054 File Offset: 0x0072F454
	public int RoomRunningTime
	{
		get
		{
			return this.roomRunningTime;
		}
		set
		{
			this.roomRunningTime = value;
		}
	}

	// Token: 0x06017622 RID: 95778 RVA: 0x0073105D File Offset: 0x0072F45D
	public void PassedDoor()
	{
		this.roomRunningTime = 0;
	}

	// Token: 0x06017623 RID: 95779 RVA: 0x00731068 File Offset: 0x0072F468
	public bool Init(string levelFileName, BaseBattle baseBattle)
	{
		this.baseBattle = baseBattle;
		this.mAgent = new LevelAgent();
		this.mIsFight = false;
		this.InitBehavic();
		bool flag = this.mAgent.btload(levelFileName);
		if (flag)
		{
			this.mAgent.btsetcurrent(levelFileName);
			this.mAgent.SetLevelMgr(this);
			this.mIsFight = true;
			return true;
		}
		return false;
	}

	// Token: 0x06017624 RID: 95780 RVA: 0x007310D1 File Offset: 0x0072F4D1
	private bool InitBehavic()
	{
		Workspace.Instance.FilePath = this.GetFilePath();
		Workspace.Instance.FileFormat = Workspace.EFileFormat.EFF_cs;
		return true;
	}

	// Token: 0x06017625 RID: 95781 RVA: 0x007310F0 File Offset: 0x0072F4F0
	private string GetFilePath()
	{
		string str = "/Resources/Data/AI/behaviac/exported";
		if (Application.platform == 7)
		{
			return Application.dataPath + str;
		}
		if (Application.platform == 2)
		{
			return Application.dataPath + str;
		}
		return "Assets" + str;
	}

	// Token: 0x06017626 RID: 95782 RVA: 0x0073113C File Offset: 0x0072F53C
	public void DeInit()
	{
		if (this.mAgent != null)
		{
			this.mAgent.UnLoad();
			this.mAgent.SetLevelMgr(null);
			this.mAgent = null;
		}
		this.mIsFight = false;
	}

	// Token: 0x06017627 RID: 95783 RVA: 0x0073116E File Offset: 0x0072F56E
	public void Update(int deltaTime)
	{
		if (this.mIsFight && this.mAgent != null)
		{
			this.mAgent.Tick();
			this.countTime += deltaTime;
			this.roomRunningTime += deltaTime;
		}
	}

	// Token: 0x06017628 RID: 95784 RVA: 0x007311AD File Offset: 0x0072F5AD
	public int GetCounter(int id)
	{
		if (!this.mCounterDic.ContainsKey(id))
		{
			return -1;
		}
		return this.mCounterDic[id];
	}

	// Token: 0x06017629 RID: 95785 RVA: 0x007311CE File Offset: 0x0072F5CE
	public void SetCounter(int id, int value)
	{
		if (!this.mCounterDic.ContainsKey(id))
		{
			this.mCounterDic.Add(id, value);
		}
		else
		{
			this.mCounterDic[id] = value;
		}
		this.OnWindChange(id, value);
	}

	// Token: 0x0601762A RID: 95786 RVA: 0x00731208 File Offset: 0x0072F608
	public void OnWindChange(int id, int value)
	{
		if (id != 1)
		{
			return;
		}
		GeSceneEx geScene = this.GetGeScene();
		if (geScene == null)
		{
			return;
		}
		GeSkyRotateEx geSkyRotateEx = new GeSkyRotateEx();
		geScene.GeSpecialSceneEx = geSkyRotateEx;
		geSkyRotateEx.Init(geScene.GetSceneObject());
		geSkyRotateEx.SetSkyRotateData(value);
	}

	// Token: 0x0601762B RID: 95787 RVA: 0x0073124B File Offset: 0x0072F64B
	public BeScene GetBeScene()
	{
		if (this.baseBattle == null)
		{
			return null;
		}
		if (this.baseBattle.dungeonManager == null)
		{
			return null;
		}
		return this.baseBattle.dungeonManager.GetBeScene();
	}

	// Token: 0x0601762C RID: 95788 RVA: 0x0073127C File Offset: 0x0072F67C
	public GeSceneEx GetGeScene()
	{
		if (this.baseBattle == null)
		{
			return null;
		}
		if (this.baseBattle.dungeonManager == null)
		{
			return null;
		}
		return this.baseBattle.dungeonManager.GetGeScene();
	}

	// Token: 0x04010CB9 RID: 68793
	private LevelAgent mAgent;

	// Token: 0x04010CBB RID: 68795
	private bool mIsFight;

	// Token: 0x04010CBC RID: 68796
	private Dictionary<int, int> mCounterDic = new Dictionary<int, int>();

	// Token: 0x04010CBD RID: 68797
	private int countTime;

	// Token: 0x04010CBE RID: 68798
	private int roomRunningTime;

	// Token: 0x02004202 RID: 16898
	public enum CounterTypeId
	{
		// Token: 0x04010CC0 RID: 68800
		NONE,
		// Token: 0x04010CC1 RID: 68801
		WIND_DIR
	}
}
