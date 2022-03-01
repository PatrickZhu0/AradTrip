using System;
using GameClient;
using ProtoTable;

// Token: 0x0200419A RID: 16794
public class BeMechanism
{
	// Token: 0x06017089 RID: 94345 RVA: 0x00710EFC File Offset: 0x0070F2FC
	public BeMechanism(int mid, int lv)
	{
		this.level = lv;
		this.mechianismID = mid;
		if (mid > 0)
		{
			this.data = Singleton<TableManager>.GetInstance().GetTableItem<MechanismTable>(mid, string.Empty, string.Empty);
			this.SetCanRemoveFlag();
		}
	}

	// Token: 0x17001F70 RID: 8048
	// (get) Token: 0x0601708A RID: 94346 RVA: 0x00710F68 File Offset: 0x0070F368
	// (set) Token: 0x0601708B RID: 94347 RVA: 0x00710F70 File Offset: 0x0070F370
	public BeActor owner { get; set; }

	// Token: 0x17001F71 RID: 8049
	// (get) Token: 0x0601708C RID: 94348 RVA: 0x00710F79 File Offset: 0x0070F379
	public FrameRandomImp FrameRandom
	{
		get
		{
			if (this.owner.FrameRandom == null)
			{
				return BeSkill.randomForTown;
			}
			return this.owner.FrameRandom;
		}
	}

	// Token: 0x0601708D RID: 94349 RVA: 0x00710F9C File Offset: 0x0070F39C
	public static BeMechanism Create(int mid, int lv = 1)
	{
		BeMechanism result = null;
		MechanismTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MechanismTable>(mid, string.Empty, string.Empty);
		if (tableItem != null)
		{
			string typeName = "Mechanism" + tableItem.Index;
			Type type = TypeTable.GetType(typeName);
			if (type != null)
			{
				result = (BeMechanism)Activator.CreateInstance(type, new object[]
				{
					mid,
					lv
				});
			}
			else
			{
				result = new BeMechanism(mid, lv);
			}
		}
		return result;
	}

	// Token: 0x17001F72 RID: 8050
	// (get) Token: 0x0601708E RID: 94350 RVA: 0x0071101C File Offset: 0x0070F41C
	public BattleType battleType
	{
		get
		{
			return this.owner.battleType;
		}
	}

	// Token: 0x0601708F RID: 94351 RVA: 0x00711029 File Offset: 0x0070F429
	public void Init(int time = 0)
	{
		this.duration = time;
		this.OnInit();
	}

	// Token: 0x06017090 RID: 94352 RVA: 0x00711038 File Offset: 0x0070F438
	public void Update(int deltaTime)
	{
		if (!this.isRunning)
		{
			return;
		}
		this.OnUpdate(deltaTime);
		this.UpdateDelayCall(deltaTime);
		this.UpdateTimeAcc(deltaTime);
		this.UpdateLifeTime(deltaTime);
	}

	// Token: 0x06017091 RID: 94353 RVA: 0x00711062 File Offset: 0x0070F462
	public void UpdateImpactBySpeed(int deltaTime)
	{
		if (!this.isRunning)
		{
			return;
		}
		this.OnUpdateImpactBySpeed(deltaTime);
	}

	// Token: 0x06017092 RID: 94354 RVA: 0x00711077 File Offset: 0x0070F477
	private void UpdateLifeTime(int deltaTime)
	{
		if (this.duration <= 0)
		{
			return;
		}
		this.runningTime += deltaTime;
		if (this.runningTime >= this.duration)
		{
			this.Finish();
		}
	}

	// Token: 0x06017093 RID: 94355 RVA: 0x007110AB File Offset: 0x0070F4AB
	public void UpdateGraphic(int deltaTime)
	{
		this.OnUpdateGraphic(deltaTime);
	}

	// Token: 0x06017094 RID: 94356 RVA: 0x007110B4 File Offset: 0x0070F4B4
	public void Start()
	{
		this.RemoveAllHandles();
		this.RemoveSceneHandle();
		this.isRunning = true;
		this.runningTime = 0;
		this.OnStart();
	}

	// Token: 0x06017095 RID: 94357 RVA: 0x007110D6 File Offset: 0x0070F4D6
	public void Finish()
	{
		if (!this.isRunning)
		{
			return;
		}
		this.isRunning = false;
		this.RemoveAllHandles();
		this.RemoveSceneHandle();
		this.RemoveDelayCall();
		this.OnFinish();
	}

	// Token: 0x06017096 RID: 94358 RVA: 0x00711103 File Offset: 0x0070F503
	protected void InitTimeAcc(int updateTime)
	{
		this.timeAcc = updateTime;
	}

	// Token: 0x06017097 RID: 94359 RVA: 0x0071110C File Offset: 0x0070F50C
	private void UpdateTimeAcc(int deltaTIme)
	{
		if (this.timeAcc <= 0)
		{
			return;
		}
		this.curTimeAcc -= deltaTIme;
		if (this.curTimeAcc <= 0)
		{
			this.curTimeAcc += this.timeAcc;
			this.OnUpdateTimeAcc();
		}
	}

	// Token: 0x06017098 RID: 94360 RVA: 0x00711159 File Offset: 0x0070F559
	public void UpdateDelayCall(int deltaTime)
	{
		if (this.delayCaller != null)
		{
			this.delayCaller.Update(deltaTime);
		}
	}

	// Token: 0x06017099 RID: 94361 RVA: 0x00711172 File Offset: 0x0070F572
	private void RemoveDelayCall()
	{
		if (this.delayCaller != null)
		{
			this.delayCaller.Clear();
			this.delayCaller = null;
		}
	}

	// Token: 0x0601709A RID: 94362 RVA: 0x00711194 File Offset: 0x0070F594
	public void RemoveAllHandles()
	{
		if (this.handleA != null)
		{
			this.handleA.Remove();
			this.handleA = null;
		}
		if (this.handleB != null)
		{
			this.handleB.Remove();
			this.handleB = null;
		}
		if (this.handleC != null)
		{
			this.handleC.Remove();
			this.handleC = null;
		}
		if (this.handleD != null)
		{
			this.handleD.Remove();
			this.handleD = null;
		}
		if (this.handleNewA != null)
		{
			this.handleNewA.Remove();
			this.handleNewA = null;
		}
	}

	// Token: 0x0601709B RID: 94363 RVA: 0x00711234 File Offset: 0x0070F634
	protected void RemoveSceneHandle()
	{
		if (this.owner.CurrentBeScene == null)
		{
			return;
		}
		if (this.sceneHandleA is BeEventHandle)
		{
			this.owner.CurrentBeScene.RemoveHandle(this.sceneHandleA as BeEventHandle);
			this.sceneHandleA = null;
		}
		if (this.sceneHandleB is BeEventHandle)
		{
			this.owner.CurrentBeScene.RemoveHandle(this.sceneHandleB as BeEventHandle);
			this.sceneHandleB = null;
		}
		if (this.SceneHandleNewA is BeEvent.BeEventHandleNew)
		{
			this.owner.CurrentBeScene.RemoveEventNew(this.SceneHandleNewA as BeEvent.BeEventHandleNew);
			this.SceneHandleNewA = null;
		}
	}

	// Token: 0x0601709C RID: 94364 RVA: 0x007112E8 File Offset: 0x0070F6E8
	protected void SetCanRemoveFlag()
	{
		if (this.data == null)
		{
			return;
		}
		if (this.data.RemoveFlag == 0)
		{
			return;
		}
		this.canRemove = (this.data.RemoveFlag == 1);
	}

	// Token: 0x0601709D RID: 94365 RVA: 0x00711325 File Offset: 0x0070F725
	public int GetRunningTime()
	{
		return this.runningTime;
	}

	// Token: 0x0601709E RID: 94366 RVA: 0x0071132D File Offset: 0x0070F72D
	protected BeActor GetAttachBuffReleaser()
	{
		if (this.attachBuff == null)
		{
			return null;
		}
		return this.attachBuff.releaser;
	}

	// Token: 0x0601709F RID: 94367 RVA: 0x00711347 File Offset: 0x0070F747
	public void DealDead()
	{
		this.OnDead();
	}

	// Token: 0x060170A0 RID: 94368 RVA: 0x0071134F File Offset: 0x0070F74F
	public int GetMechanismIndex()
	{
		if (this.data == null)
		{
			return -1;
		}
		return this.data.Index;
	}

	// Token: 0x060170A1 RID: 94369 RVA: 0x00711369 File Offset: 0x0070F769
	public BeActor GetTopOwner()
	{
		return this.owner.GetTopOwner(this.owner) as BeActor;
	}

	// Token: 0x060170A2 RID: 94370 RVA: 0x00711381 File Offset: 0x0070F781
	public virtual void OnInit()
	{
	}

	// Token: 0x060170A3 RID: 94371 RVA: 0x00711383 File Offset: 0x0070F783
	public virtual void OnPostInit()
	{
	}

	// Token: 0x060170A4 RID: 94372 RVA: 0x00711385 File Offset: 0x0070F785
	public virtual void OnStart()
	{
	}

	// Token: 0x060170A5 RID: 94373 RVA: 0x00711387 File Offset: 0x0070F787
	public virtual void OnFinish()
	{
	}

	// Token: 0x060170A6 RID: 94374 RVA: 0x00711389 File Offset: 0x0070F789
	public virtual void OnUpdate(int deltaTime)
	{
	}

	// Token: 0x060170A7 RID: 94375 RVA: 0x0071138B File Offset: 0x0070F78B
	public virtual void OnUpdateGraphic(int deltaTime)
	{
	}

	// Token: 0x060170A8 RID: 94376 RVA: 0x0071138D File Offset: 0x0070F78D
	public virtual void OnDead()
	{
	}

	// Token: 0x060170A9 RID: 94377 RVA: 0x0071138F File Offset: 0x0070F78F
	public virtual void OnUpdateTimeAcc()
	{
	}

	// Token: 0x060170AA RID: 94378 RVA: 0x00711391 File Offset: 0x0070F791
	public virtual void OnUpdateImpactBySpeed(int deltaTime)
	{
	}

	// Token: 0x0401096B RID: 67947
	public CrypticInt32 level = 1;

	// Token: 0x0401096C RID: 67948
	public int mechianismID;

	// Token: 0x0401096D RID: 67949
	public bool canRemove = true;

	// Token: 0x0401096E RID: 67950
	public MechanismTable data;

	// Token: 0x04010970 RID: 67952
	public MechanismSourceType sourceType;

	// Token: 0x04010971 RID: 67953
	public BeBuff attachBuff;

	// Token: 0x04010972 RID: 67954
	public bool isRunning;

	// Token: 0x04010973 RID: 67955
	protected IBeEventHandle handleA;

	// Token: 0x04010974 RID: 67956
	protected IBeEventHandle handleB;

	// Token: 0x04010975 RID: 67957
	protected IBeEventHandle handleC;

	// Token: 0x04010976 RID: 67958
	protected IBeEventHandle handleD;

	// Token: 0x04010977 RID: 67959
	protected IBeEventHandle handleNewA;

	// Token: 0x04010978 RID: 67960
	protected IBeEventHandle sceneHandleA;

	// Token: 0x04010979 RID: 67961
	protected IBeEventHandle sceneHandleB;

	// Token: 0x0401097A RID: 67962
	protected IBeEventHandle SceneHandleNewA;

	// Token: 0x0401097B RID: 67963
	protected DelayCaller delayCaller = new DelayCaller();

	// Token: 0x0401097C RID: 67964
	protected int runningTime;

	// Token: 0x0401097D RID: 67965
	protected int duration;

	// Token: 0x0401097E RID: 67966
	private int curTimeAcc;

	// Token: 0x0401097F RID: 67967
	private int timeAcc;
}
