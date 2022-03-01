using System;
using Battle;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020041A9 RID: 16809
public class BeRegion : BeRegionBase
{
	// Token: 0x06017184 RID: 94596 RVA: 0x007152E5 File Offset: 0x007136E5
	public BeRegion()
	{
		this.mCanRemove = false;
		this.mActive = true;
	}

	// Token: 0x17001F88 RID: 8072
	// (get) Token: 0x06017185 RID: 94597 RVA: 0x00715306 File Offset: 0x00713706
	public int rate
	{
		get
		{
			return this.mRate;
		}
	}

	// Token: 0x17001F89 RID: 8073
	// (set) Token: 0x06017186 RID: 94598 RVA: 0x0071530E File Offset: 0x0071370E
	public BeActor regionTarget
	{
		set
		{
			this.mRegionTarget.target = value;
			this.mIsFlow = true;
		}
	}

	// Token: 0x06017187 RID: 94599 RVA: 0x00715324 File Offset: 0x00713724
	protected override void _onCreate()
	{
		if (this.mRegionTable.Type == SceneRegionTable.eType.BUFF)
		{
			GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/Battle_Digit/SpritiBuffText", enResourceType.BattleScene, 2U);
			if (gameObject != null)
			{
				GeUtility.AttachTo(gameObject, this.mGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Root), false);
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component != null)
				{
					Text com = component.GetCom<Text>("txtDesc");
					if (com != null)
					{
						com.text = this.mRegionTable.Desc;
					}
				}
				this.objDesc = gameObject;
			}
		}
	}

	// Token: 0x06017188 RID: 94600 RVA: 0x007153B8 File Offset: 0x007137B8
	private void _takeEffect(BeRegionTarget target)
	{
		if (target != null && target.target != null)
		{
			for (int i = 0; i < this.mRegionTable.EffectID.Count; i++)
			{
				int hurtid = this.mRegionTable.EffectID[i];
				target.target.DealEffectFrame(null, hurtid, 0, false, true, false, false);
			}
		}
	}

	// Token: 0x06017189 RID: 94601 RVA: 0x0071541C File Offset: 0x0071381C
	private void _untakeEffect(BeRegionTarget target)
	{
		if (target != null && target.target != null && target.target.buffController != null)
		{
			for (int i = 0; i < this.mRegionTable.EffectID.Count; i++)
			{
				int id = this.mRegionTable.EffectID[i];
				EffectTable tableItem = Singleton<TableManager>.instance.GetTableItem<EffectTable>(id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					BeBuff beBuff = target.target.buffController.HasBuffByID(tableItem.BuffID);
					if (beBuff != null)
					{
						beBuff.Finish();
					}
				}
			}
		}
	}

	// Token: 0x0601718A RID: 94602 RVA: 0x007154BC File Offset: 0x007138BC
	protected override void _onEnterEffect(BeRegionTarget target)
	{
		switch (this.mRegionTable.Type)
		{
		case SceneRegionTable.eType.BUFF:
			this._takeEffect(target);
			this.mCanRemove = true;
			MonoSingleton<AudioManager>.instance.PlaySound(1012);
			break;
		case SceneRegionTable.eType.TRAP:
			this._takeEffect(target);
			break;
		case SceneRegionTable.eType.RIDE:
			this.mCanRemove = true;
			break;
		}
	}

	// Token: 0x0601718B RID: 94603 RVA: 0x00715540 File Offset: 0x00713940
	protected override void _onExitEffect(BeRegionTarget target)
	{
		SceneRegionTable.eType type = this.mRegionTable.Type;
		if (type == SceneRegionTable.eType.TRAP)
		{
			this._untakeEffect(target);
		}
	}

	// Token: 0x0601718C RID: 94604 RVA: 0x00715571 File Offset: 0x00713971
	protected override void _onRemove()
	{
		if (this.objDesc != null)
		{
			Singleton<CGameObjectPool>.instance.RecycleGameObject(this.objDesc);
			this.objDesc = null;
		}
	}

	// Token: 0x0601718D RID: 94605 RVA: 0x0071559C File Offset: 0x0071399C
	protected override void _onUpdate(int delta)
	{
		if (this.mRegionTable.Type == SceneRegionTable.eType.LOOP)
		{
			if (this.mIsFlow && this.mRegionTarget.target != null)
			{
				if (this.mRegionTarget.target.GetLifeState() == 4)
				{
					this.mCanRemove = true;
					base.Remove();
					return;
				}
				VInt3 position = this.mRegionTarget.target.GetPosition();
				position.z = this.mPosition.z;
				base.SetPosition(position);
			}
			for (int i = 0; i < this.mTargetList.Count; i++)
			{
				BeRegionTarget beRegionTarget = this.mTargetList[i];
				if (beRegionTarget.state == BeRegionState.In)
				{
					this.mRate += delta / GlobalLogic.VALUE_10;
					this.mRate = Mathf.Min(GlobalLogic.VALUE_1000, this.mRate);
					if (this.mRate >= GlobalLogic.VALUE_1000)
					{
						this.mRate = 0;
						this._takeEffect(beRegionTarget);
					}
				}
				else
				{
					this.mRate -= delta / GlobalLogic.VALUE_10;
					this.mRate = Mathf.Max(0, this.mRate);
				}
				ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle != null)
				{
					clientSystemBattle.SetTipsPercent((float)this.mRate / (float)GlobalLogic.VALUE_1000);
				}
			}
		}
	}

	// Token: 0x04010A24 RID: 68132
	protected BeRegionTarget mRegionTarget = new BeRegionTarget();

	// Token: 0x04010A25 RID: 68133
	protected bool mIsFlow;

	// Token: 0x04010A26 RID: 68134
	protected int mRate;

	// Token: 0x04010A27 RID: 68135
	private const float kRateOver = 0.1f;

	// Token: 0x04010A28 RID: 68136
	private GameObject objDesc;

	// Token: 0x04010A29 RID: 68137
	private int mDealTime;
}
