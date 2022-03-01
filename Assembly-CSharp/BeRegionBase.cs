using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

// Token: 0x020041A6 RID: 16806
public class BeRegionBase
{
	// Token: 0x17001F7D RID: 8061
	// (get) Token: 0x06017151 RID: 94545 RVA: 0x007148F1 File Offset: 0x00712CF1
	public int resID
	{
		get
		{
			return this.mResID;
		}
	}

	// Token: 0x17001F7E RID: 8062
	// (get) Token: 0x06017152 RID: 94546 RVA: 0x007148F9 File Offset: 0x00712CF9
	public GeActorEx geActor
	{
		get
		{
			return this.mGeActor;
		}
	}

	// Token: 0x17001F7F RID: 8063
	// (get) Token: 0x06017153 RID: 94547 RVA: 0x00714901 File Offset: 0x00712D01
	public VInt3 position
	{
		get
		{
			return this.mPosition;
		}
	}

	// Token: 0x06017154 RID: 94548 RVA: 0x00714909 File Offset: 0x00712D09
	public void SetScale(VInt scale)
	{
		this.mScale = scale;
		if (this.mGeActor != null)
		{
			this.mGeActor.SetScale(scale.scalar);
		}
	}

	// Token: 0x06017155 RID: 94549 RVA: 0x0071492F File Offset: 0x00712D2F
	public void SetPosition(VInt3 vec)
	{
		this.mPosition = vec;
		if (this.mGeActor != null)
		{
			this.mGeActor.SetPosition(vec.vector3);
		}
	}

	// Token: 0x17001F80 RID: 8064
	// (get) Token: 0x06017156 RID: 94550 RVA: 0x00714955 File Offset: 0x00712D55
	// (set) Token: 0x06017157 RID: 94551 RVA: 0x0071495D File Offset: 0x00712D5D
	public bool active
	{
		get
		{
			return this.mActive;
		}
		set
		{
			if (value != this.mActive)
			{
				this.mActive = value;
			}
		}
	}

	// Token: 0x17001F81 RID: 8065
	// (get) Token: 0x06017158 RID: 94552 RVA: 0x00714972 File Offset: 0x00712D72
	// (set) Token: 0x06017159 RID: 94553 RVA: 0x0071497A File Offset: 0x00712D7A
	public bool activeEffect
	{
		get
		{
			return this.mIsActiveEffect;
		}
		set
		{
			if (value != this.mIsActiveEffect)
			{
				this.mIsActiveEffect = value;
				if (this.mIsActiveEffect)
				{
					this._unloadActivedEffect();
					this._loadActivedEffect();
				}
				else
				{
					this._unloadActivedEffect();
				}
			}
		}
	}

	// Token: 0x17001F82 RID: 8066
	// (get) Token: 0x0601715A RID: 94554 RVA: 0x007149B1 File Offset: 0x00712DB1
	public bool canRemove
	{
		get
		{
			return this.mCanRemove;
		}
	}

	// Token: 0x17001F83 RID: 8067
	// (get) Token: 0x0601715C RID: 94556 RVA: 0x007149C2 File Offset: 0x00712DC2
	// (set) Token: 0x0601715B RID: 94555 RVA: 0x007149B9 File Offset: 0x00712DB9
	public ISceneRegionInfoData regionInfo
	{
		get
		{
			return this.mRegionInfo;
		}
		private set
		{
			this.mRegionInfo = value;
		}
	}

	// Token: 0x17001F84 RID: 8068
	// (set) Token: 0x0601715D RID: 94557 RVA: 0x007149CA File Offset: 0x00712DCA
	public BeRegionBase.TriggerRegion triggerRegion
	{
		set
		{
			this.mTriggerRegion = value;
		}
	}

	// Token: 0x17001F85 RID: 8069
	// (set) Token: 0x0601715E RID: 94558 RVA: 0x007149D3 File Offset: 0x00712DD3
	public BeRegionBase.TriggerRegion triggerRegionOut
	{
		set
		{
			this.mTriggerRegionOut = value;
		}
	}

	// Token: 0x17001F86 RID: 8070
	// (set) Token: 0x0601715F RID: 94559 RVA: 0x007149DC File Offset: 0x00712DDC
	public BeRegionBase.TriggerTarget triggerTarget
	{
		set
		{
			this.mTriggerTargetList = value;
		}
	}

	// Token: 0x17001F87 RID: 8071
	// (get) Token: 0x06017160 RID: 94560 RVA: 0x007149E5 File Offset: 0x00712DE5
	public BeScene currentBeScene
	{
		get
		{
			if (this.mCurrentBeScene == null)
			{
				Logger.LogError("currentBeScene is nil");
			}
			return this.mCurrentBeScene;
		}
	}

	// Token: 0x06017161 RID: 94561 RVA: 0x00714A02 File Offset: 0x00712E02
	public void SetBeScene(BeScene scene)
	{
		this.mCurrentBeScene = scene;
	}

	// Token: 0x06017162 RID: 94562 RVA: 0x00714A0C File Offset: 0x00712E0C
	private void _loadData(int id)
	{
		this.mRegionTable = Singleton<TableManager>.GetInstance().GetTableItem<SceneRegionTable>(id, string.Empty, string.Empty);
		if (this.mRegionTable == null)
		{
			Logger.LogErrorFormat("sceneregion table not contain the item with id {0}", new object[]
			{
				id
			});
		}
	}

	// Token: 0x06017163 RID: 94563 RVA: 0x00714A58 File Offset: 0x00712E58
	protected void _loadEffect()
	{
		this.mResID = this.mRegionTable.ResID;
		if (this.mIsBoss && this.mRegionTable.ReplaceResID > 0)
		{
			this.mResID = this.mRegionTable.ReplaceResID;
		}
		this.mGeActor = this.currentBeScene.currentGeScene.CreateActor(this.mResID, 0, 0, true, false, true, false);
		if (this.mGeActor == null)
		{
			Logger.LogErrorFormat("create actor is nil with res id {0} current room:{1}", new object[]
			{
				this.mResID,
				BattleMain.instance.GetDungeonManager().GetDungeonDataManager().CurrentScenePath()
			});
		}
		this._onLoadActorFinishCB();
	}

	// Token: 0x06017164 RID: 94564 RVA: 0x00714B0B File Offset: 0x00712F0B
	private void _onLoadActorFinishCB()
	{
		this._onLoadActorFinish();
	}

	// Token: 0x06017165 RID: 94565 RVA: 0x00714B13 File Offset: 0x00712F13
	protected virtual void _onLoadActorFinish()
	{
	}

	// Token: 0x06017166 RID: 94566 RVA: 0x00714B15 File Offset: 0x00712F15
	protected virtual void _unloadEffect()
	{
		if (this.mGeActor != null)
		{
			this.currentBeScene.currentGeScene.DestroyActor(this.mGeActor);
			this.mGeActor = null;
		}
	}

	// Token: 0x06017167 RID: 94567 RVA: 0x00714B40 File Offset: 0x00712F40
	protected virtual void _loadActivedEffect()
	{
		DAssetObject effectRes = default(DAssetObject);
		effectRes.m_AssetPath = this.mRegionTable.ActivedEffect;
		EffectsFrames effectsFrames = new EffectsFrames();
		effectsFrames.attachname = "[actor]Origin";
		this.mActiveEffect = this.mGeActor.CreateEffect(effectRes, effectsFrames, 0f, this.mPosition.vec3, 1f, 1f, true, false, false);
	}

	// Token: 0x06017168 RID: 94568 RVA: 0x00714BA8 File Offset: 0x00712FA8
	protected virtual void _unloadActivedEffect()
	{
		if (this.mActiveEffect != null)
		{
			this.mGeActor.DestroyEffect(this.mActiveEffect);
			this.mActiveEffect = null;
		}
	}

	// Token: 0x06017169 RID: 94569 RVA: 0x00714BCD File Offset: 0x00712FCD
	public void Create(ISceneRegionInfoData info, bool isReplace = false)
	{
		this.regionInfo = info;
		this.mIsBoss = isReplace;
		this._loadData(this.regionInfo.GetEntityInfo().GetResid());
		this._loadEffect();
		this._onCreate();
	}

	// Token: 0x0601716A RID: 94570 RVA: 0x00714BFF File Offset: 0x00712FFF
	public void Remove()
	{
		this._unloadActivedEffect();
		this._unloadEffect();
		this.mCurrentBeScene = null;
	}

	// Token: 0x0601716B RID: 94571 RVA: 0x00714C14 File Offset: 0x00713014
	public virtual VInt3 GetRegionPos()
	{
		return this.mPosition;
	}

	// Token: 0x0601716C RID: 94572 RVA: 0x00714C1C File Offset: 0x0071301C
	protected virtual bool _isInRegion(BeRegionTarget regionTarget)
	{
		if (regionTarget == null || regionTarget.target == null)
		{
			return false;
		}
		VInt3 position = regionTarget.target.GetPosition();
		VInt3 regionPos = this.GetRegionPos();
		int offset = 0;
		return this._isPointInRegion(position, regionPos, this.mRegionInfo, offset);
	}

	// Token: 0x0601716D RID: 94573 RVA: 0x00714C60 File Offset: 0x00713060
	private bool _isPointInRegion(VInt3 point, VInt3 regionPos, ISceneRegionInfoData regionInfo, int offset = 0)
	{
		if (regionInfo == null)
		{
			return false;
		}
		if (this.mRegionInfo.GetRegiontype() == DRegionInfo.RegionType.Circle)
		{
			VInt2 a = new VInt2(regionPos.x, regionPos.y);
			VInt2 b = new VInt2(point.x, point.y);
			int magnitude = (a - b).magnitude;
			return magnitude <= VInt.Float2VIntValue(this.mRegionInfo.GetRadius()) + offset;
		}
		if (this.mRegionInfo.GetRegiontype() == DRegionInfo.RegionType.Rectangle)
		{
			VInt2 vint = new VInt2(regionPos.x - (VInt.Float2VIntValue(this.mRegionInfo.GetRect().x) + offset) / 2, regionPos.y - (VInt.Float2VIntValue(this.mRegionInfo.GetRect().y) + offset) / 2);
			VInt2 vint2 = new VInt2(regionPos.x + (VInt.Float2VIntValue(this.mRegionInfo.GetRect().x) + offset) / 2, regionPos.y + (VInt.Float2VIntValue(this.mRegionInfo.GetRect().y) + offset) / 2);
			return point.x >= vint.x && point.z >= vint.y && point.x <= vint2.x && point.z <= vint2.y;
		}
		return false;
	}

	// Token: 0x0601716E RID: 94574 RVA: 0x00714DE8 File Offset: 0x007131E8
	private bool _isOverRegion(BeRegionTarget regionTarget)
	{
		return regionTarget != null && regionTarget.target != null && regionTarget.target.GetPosition().z > 0;
	}

	// Token: 0x0601716F RID: 94575 RVA: 0x00714E1E File Offset: 0x0071321E
	protected virtual void _onUpdate(int delta)
	{
	}

	// Token: 0x06017170 RID: 94576 RVA: 0x00714E20 File Offset: 0x00713220
	protected virtual bool _canTriggerIn(BeRegionTarget target)
	{
		return target.isStateChanged && target.state == BeRegionState.In;
	}

	// Token: 0x06017171 RID: 94577 RVA: 0x00714E3C File Offset: 0x0071323C
	protected virtual bool _canTriggerOut(BeRegionTarget target)
	{
		return target.isStateChanged && target.state == BeRegionState.Out;
	}

	// Token: 0x06017172 RID: 94578 RVA: 0x00714E58 File Offset: 0x00713258
	private void _triggerIn(BeRegionTarget target)
	{
		if (this.mTriggerRegion != null)
		{
			try
			{
				this.mTriggerRegion(this.mRegionInfo, target);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("mTriggerRegion Out -> In with error {0}", new object[]
				{
					ex.ToString()
				});
			}
		}
	}

	// Token: 0x06017173 RID: 94579 RVA: 0x00714EB8 File Offset: 0x007132B8
	private void _triggerOut(BeRegionTarget target)
	{
		if (this.mTriggerRegionOut != null)
		{
			try
			{
				this.mTriggerRegionOut(this.mRegionInfo, target);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("mTriggerRegion In -> Out with error {0}", new object[]
				{
					ex.ToString()
				});
			}
		}
	}

	// Token: 0x06017174 RID: 94580 RVA: 0x00714F18 File Offset: 0x00713318
	protected virtual void _tryTriggerIn()
	{
	}

	// Token: 0x06017175 RID: 94581 RVA: 0x00714F1A File Offset: 0x0071331A
	private bool checkCanRemoveRegionTarget(BeRegionTarget x)
	{
		return x.removed;
	}

	// Token: 0x06017176 RID: 94582 RVA: 0x00714F24 File Offset: 0x00713324
	private void _updateTargetList()
	{
		if (this.mTriggerTargetList != null)
		{
			try
			{
				List<BattlePlayer> list = this.mTriggerTargetList();
				if (list != null)
				{
					for (int i = 0; i < this.mTargetList.Count; i++)
					{
						this.mTargetList[i].removed = true;
					}
					for (int j = 0; j < list.Count; j++)
					{
						BattlePlayer battlePlayer = list[j];
						if (battlePlayer != null)
						{
							bool flag = true;
							for (int k = 0; k < this.mTargetList.Count; k++)
							{
								if (this.mTargetList[k].battlePlayer.playerInfo.seat == battlePlayer.playerInfo.seat)
								{
									this.mTargetList[k].battlePlayer = battlePlayer;
									this.mTargetList[k].target = battlePlayer.playerActor;
									this.mTargetList[k].removed = false;
									flag = false;
									break;
								}
							}
							if (flag)
							{
								BeRegionTarget beRegionTarget = new BeRegionTarget
								{
									state = BeRegionState.None,
									battlePlayer = battlePlayer,
									target = battlePlayer.playerActor,
									removed = false,
									type = this.mRegionTable.Type
								};
								this.mTargetList.Add(beRegionTarget);
								if (this._isInRegion(beRegionTarget))
								{
									beRegionTarget.state = BeRegionState.In;
									beRegionTarget.state = BeRegionState.In;
								}
								else
								{
									beRegionTarget.state = BeRegionState.Out;
									beRegionTarget.state = BeRegionState.Out;
								}
							}
						}
					}
					for (int l = this.mTargetList.Count - 1; l >= 0; l--)
					{
						if (this.checkCanRemoveRegionTarget(this.mTargetList[l]))
						{
							this.mTargetList.RemoveAt(l);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("tirgger target list error with {0}", new object[]
				{
					ex.ToString()
				});
			}
		}
	}

	// Token: 0x06017177 RID: 94583 RVA: 0x0071514C File Offset: 0x0071354C
	public void Update(int deltaTime)
	{
		if (this.mGeActor != null)
		{
			this.mGeActor.Update(deltaTime, 63, 0f, 0);
		}
		if (this.mCanRemove)
		{
			return;
		}
		if (!this.mActive)
		{
			return;
		}
		this._updateTargetList();
		if (this.mTargetList == null)
		{
			return;
		}
		for (int i = 0; i < this.mTargetList.Count; i++)
		{
			BeRegionTarget beRegionTarget = this.mTargetList[i];
			switch (beRegionTarget.state)
			{
			case BeRegionState.In:
				if (!this._isInRegion(beRegionTarget))
				{
					beRegionTarget.state = BeRegionState.Out;
					this._onExitEffect(beRegionTarget);
					if (this._canTriggerOut(beRegionTarget))
					{
						this._triggerOut(beRegionTarget);
					}
				}
				else if (this._isOverRegion(beRegionTarget))
				{
					beRegionTarget.state = BeRegionState.Over;
				}
				break;
			case BeRegionState.Out:
				if (this._isInRegion(beRegionTarget))
				{
					beRegionTarget.state = BeRegionState.In;
					for (int j = 0; j < this.mTargetList.Count; j++)
					{
						this._onEnterEffect(this.mTargetList[j]);
					}
					if (this._canTriggerIn(beRegionTarget))
					{
						this._triggerIn(beRegionTarget);
					}
					if (this.mCanRemove)
					{
						this.Remove();
						this._onRemove();
					}
				}
				break;
			case BeRegionState.Over:
				if (!this._isOverRegion(beRegionTarget))
				{
					beRegionTarget.state = BeRegionState.In;
				}
				break;
			}
		}
		this._onUpdate(deltaTime);
		this._tryTriggerIn();
	}

	// Token: 0x06017178 RID: 94584 RVA: 0x007152DD File Offset: 0x007136DD
	protected virtual void _onCreate()
	{
	}

	// Token: 0x06017179 RID: 94585 RVA: 0x007152DF File Offset: 0x007136DF
	protected virtual void _onEnterEffect(BeRegionTarget target)
	{
	}

	// Token: 0x0601717A RID: 94586 RVA: 0x007152E1 File Offset: 0x007136E1
	protected virtual void _onExitEffect(BeRegionTarget target)
	{
	}

	// Token: 0x0601717B RID: 94587 RVA: 0x007152E3 File Offset: 0x007136E3
	protected virtual void _onRemove()
	{
	}

	// Token: 0x04010A13 RID: 68115
	protected BeRegionBase.TriggerRegion mTriggerRegion;

	// Token: 0x04010A14 RID: 68116
	protected BeRegionBase.TriggerRegion mTriggerRegionOut;

	// Token: 0x04010A15 RID: 68117
	private BeRegionBase.TriggerTarget mTriggerTargetList;

	// Token: 0x04010A16 RID: 68118
	protected List<BeRegionTarget> mTargetList = new List<BeRegionTarget>();

	// Token: 0x04010A17 RID: 68119
	protected VInt3 mPosition;

	// Token: 0x04010A18 RID: 68120
	protected VInt mScale = VInt.one;

	// Token: 0x04010A19 RID: 68121
	protected bool mActive;

	// Token: 0x04010A1A RID: 68122
	protected bool mIsActiveEffect;

	// Token: 0x04010A1B RID: 68123
	protected bool mCanRemove;

	// Token: 0x04010A1C RID: 68124
	protected ISceneRegionInfoData mRegionInfo;

	// Token: 0x04010A1D RID: 68125
	protected BeScene mCurrentBeScene;

	// Token: 0x04010A1E RID: 68126
	protected GeActorEx mGeActor;

	// Token: 0x04010A1F RID: 68127
	protected GeEffectEx mActiveEffect;

	// Token: 0x04010A20 RID: 68128
	protected GameObject mTrailEff;

	// Token: 0x04010A21 RID: 68129
	protected SceneRegionTable mRegionTable;

	// Token: 0x04010A22 RID: 68130
	protected bool mIsBoss;

	// Token: 0x04010A23 RID: 68131
	private int mResID;

	// Token: 0x020041A7 RID: 16807
	// (Invoke) Token: 0x0601717D RID: 94589
	public delegate bool TriggerRegion(ISceneRegionInfoData info, BeRegionTarget target);

	// Token: 0x020041A8 RID: 16808
	// (Invoke) Token: 0x06017181 RID: 94593
	public delegate List<BattlePlayer> TriggerTarget();
}
