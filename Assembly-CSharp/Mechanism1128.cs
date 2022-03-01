using System;
using GameClient;
using UnityEngine;

// Token: 0x020042B6 RID: 17078
public class Mechanism1128 : BeMechanism
{
	// Token: 0x06017A01 RID: 96769 RVA: 0x007474F6 File Offset: 0x007458F6
	public Mechanism1128(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A02 RID: 96770 RVA: 0x00747514 File Offset: 0x00745914
	public override void OnInit()
	{
		base.OnInit();
		this._cameraDesc.IsOrthographic = false;
		this._cameraDesc.FOV = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
		this._cameraDesc.NearPlane = (float)TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) / 1000f;
		this._cameraDesc.FarPlane = (float)TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true) / 1000f;
	}

	// Token: 0x06017A03 RID: 96771 RVA: 0x007475D0 File Offset: 0x007459D0
	public override void OnStart()
	{
		base.OnStart();
		if (base.owner.isLocalActor)
		{
			this.RecordCameraDesc();
			this.RecordCameraControlYOffset();
			this.SetCameraControlOffset(false);
			this.SetCameraDesc(this._cameraDesc);
			this.SetCameraCullingMask(1 << this._3DUIModel);
			this.RecordActorNodeLayer();
			this.SetOwnerModelLayer(this._3DUIModel);
		}
		this.RegisterBattleeExit();
	}

	// Token: 0x06017A04 RID: 96772 RVA: 0x0074763B File Offset: 0x00745A3B
	public override void OnFinish()
	{
		base.OnFinish();
		this.ResetData();
	}

	// Token: 0x06017A05 RID: 96773 RVA: 0x00747649 File Offset: 0x00745A49
	private void RegisterBattleeExit()
	{
		if (base.owner.CurrentBeScene != null)
		{
			this.SceneHandleNewA = base.owner.CurrentBeScene.RegisterEventNew(BeEventSceneType.onBattleExit, new BeEvent.BeEventHandleNew.Function(this.OnBattleExit));
		}
	}

	// Token: 0x06017A06 RID: 96774 RVA: 0x0074767F File Offset: 0x00745A7F
	private void OnBattleExit(BeEvent.BeEventParam param)
	{
		this.ResetData();
	}

	// Token: 0x06017A07 RID: 96775 RVA: 0x00747687 File Offset: 0x00745A87
	private void ResetData()
	{
		if (!base.owner.isLocalActor)
		{
			return;
		}
		this.SetCameraControlOffset(true);
		this.SetCameraDesc(this._cameraDescBackUp);
		this.SetCameraCullingMask(this._cameraCullingMask);
		this.SetOwnerModelLayer(this._actorNodeLayerBackUp);
	}

	// Token: 0x06017A08 RID: 96776 RVA: 0x007476C8 File Offset: 0x00745AC8
	private void RecordCameraDesc()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.currentGeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.currentGeScene.GetCamera() == null)
		{
			return;
		}
		this._cameraDescBackUp = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetCameraDesc();
		this._cameraCullingMask = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetCullingMask();
	}

	// Token: 0x06017A09 RID: 96777 RVA: 0x00747758 File Offset: 0x00745B58
	private void SetCameraDesc(GeCameraDesc desc)
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.currentGeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.currentGeScene.GetCamera() == null)
		{
			return;
		}
		base.owner.CurrentBeScene.currentGeScene.GetCamera().SetCameraDesc(desc);
	}

	// Token: 0x06017A0A RID: 96778 RVA: 0x007477C4 File Offset: 0x00745BC4
	private void RecordCameraControlYOffset()
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.currentGeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController() == null)
		{
			return;
		}
		this._cameraControlOffsetBackUp = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().GetCameraPosition();
	}

	// Token: 0x06017A0B RID: 96779 RVA: 0x00747844 File Offset: 0x00745C44
	private void SetCameraControlOffset(bool isStore = false)
	{
		if (base.owner.CurrentBeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.currentGeScene == null)
		{
			return;
		}
		if (base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController() == null)
		{
			return;
		}
		GeCameraControllerScroll controller = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController();
		controller.SetPause(!isStore);
		if (isStore)
		{
			controller.SetCameraPos(this._cameraControlOffsetBackUp);
		}
		else
		{
			Vector3 cameraControlOffsetBackUp = this._cameraControlOffsetBackUp;
			cameraControlOffsetBackUp.y = 4.42f;
			controller.SetCameraPos(cameraControlOffsetBackUp);
		}
	}

	// Token: 0x06017A0C RID: 96780 RVA: 0x007478F4 File Offset: 0x00745CF4
	private void SetCameraCullingMask(int mask)
	{
		base.owner.CurrentBeScene.currentGeScene.GetCamera().SetCullingMask(mask);
	}

	// Token: 0x06017A0D RID: 96781 RVA: 0x00747911 File Offset: 0x00745D11
	private void RecordActorNodeLayer()
	{
		if (base.owner.m_pkGeActor == null)
		{
			return;
		}
		this._actorNodeLayerBackUp = base.owner.m_pkGeActor.GetActorNodeLayer();
	}

	// Token: 0x06017A0E RID: 96782 RVA: 0x0074793A File Offset: 0x00745D3A
	private void SetOwnerModelLayer(int layer)
	{
		if (base.owner.m_pkGeActor == null)
		{
			return;
		}
		base.owner.m_pkGeActor.SetActorNodeLayer(layer);
	}

	// Token: 0x04010FAA RID: 69546
	private GeCameraDesc _cameraDesc;

	// Token: 0x04010FAB RID: 69547
	private GeCameraDesc _cameraDescBackUp;

	// Token: 0x04010FAC RID: 69548
	private Vector3 _cameraControlOffsetBackUp = Vector3.zero;

	// Token: 0x04010FAD RID: 69549
	private int _cameraCullingMask;

	// Token: 0x04010FAE RID: 69550
	private int _3DUIModel = 14;

	// Token: 0x04010FAF RID: 69551
	private int _actorNodeLayerBackUp;
}
