using System;
using GameClient;
using UnityEngine;

// Token: 0x020042B7 RID: 17079
public class Mechanism1129 : BeMechanism
{
	// Token: 0x06017A0F RID: 96783 RVA: 0x0074795E File Offset: 0x00745D5E
	public Mechanism1129(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017A10 RID: 96784 RVA: 0x00747980 File Offset: 0x00745D80
	public override void OnInit()
	{
		base.OnInit();
		this._addModelScale.x = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
		this._addModelScale.y = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
		this._addModelScale.z = (float)TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true) / 1000f;
		this._zPosOffset = (float)TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true) / 1000f;
	}

	// Token: 0x06017A11 RID: 96785 RVA: 0x00747A5E File Offset: 0x00745E5E
	public override void OnStart()
	{
		base.OnStart();
		base.owner.StopShock();
		this._InitRegisterEvent();
		if (base.owner.isLocalActor)
		{
			this.SetModelScale(false);
			this.SetModelPos(false);
			this.SetCamera(false);
		}
	}

	// Token: 0x06017A12 RID: 96786 RVA: 0x00747A9C File Offset: 0x00745E9C
	private void _InitRegisterEvent()
	{
		this.handleNewA = base.owner.RegisterEventNew(BeEventType.onChangeShock, new BeEvent.BeEventHandleNew.Function(this._OnChangeShock));
	}

	// Token: 0x06017A13 RID: 96787 RVA: 0x00747AC0 File Offset: 0x00745EC0
	private void _OnChangeShock(BeEvent.BeEventParam param)
	{
		param.m_Bool = false;
	}

	// Token: 0x06017A14 RID: 96788 RVA: 0x00747AC9 File Offset: 0x00745EC9
	public override void OnFinish()
	{
		base.OnFinish();
		if (base.owner.isLocalActor)
		{
			this.SetModelScale(true);
			this.SetModelPos(true);
			this.SetCamera(true);
		}
	}

	// Token: 0x06017A15 RID: 96789 RVA: 0x00747AF8 File Offset: 0x00745EF8
	private void SetModelScale(bool isRestore = false)
	{
		if (base.owner.m_pkGeActor == null)
		{
			return;
		}
		Vector3 actorNodeScale = base.owner.m_pkGeActor.GetActorNodeScale();
		if (!isRestore)
		{
			base.owner.m_pkGeActor.SetActorNodeScale(actorNodeScale + this._addModelScale);
		}
		else
		{
			base.owner.m_pkGeActor.SetActorNodeScale(actorNodeScale - this._addModelScale);
		}
	}

	// Token: 0x06017A16 RID: 96790 RVA: 0x00747B6C File Offset: 0x00745F6C
	private void SetModelPos(bool isRestore = false)
	{
		if (base.owner.m_pkGeActor == null)
		{
			return;
		}
		if (base.owner.m_pkGeActor.goFootInfo != null)
		{
			base.owner.m_pkGeActor.goFootInfo.CustomActive(isRestore);
		}
		if (base.owner.m_pkGeActor.goInfoBar != null)
		{
			base.owner.m_pkGeActor.goInfoBar.CustomActive(isRestore);
		}
		base.owner.m_pkGeActor.SetHeadInfoVisible(isRestore);
		if (!isRestore)
		{
			Vector3 zero = Vector3.zero;
			Vector3 position = base.owner.m_pkGeActor.GetPosition();
			Vector3 battlePosBySceneCenterPos = this.GetBattlePosBySceneCenterPos();
			zero.x = ((!base.owner.GetFace()) ? (battlePosBySceneCenterPos.x - position.x) : (position.x - battlePosBySceneCenterPos.x));
			zero.y = position.y;
			zero.z = this._zPosOffset - position.z;
			base.owner.m_pkGeActor.SetActorPosition(zero);
		}
		else
		{
			base.owner.m_pkGeActor.SetActorPosition(Vector3.zero);
		}
	}

	// Token: 0x06017A17 RID: 96791 RVA: 0x00747CAC File Offset: 0x007460AC
	private void SetCamera(bool isRestore = false)
	{
		if (base.owner.CurrentBeScene == null || base.owner.CurrentBeScene.currentGeScene == null || base.owner.CurrentBeScene.currentGeScene.GetCamera() == null)
		{
			return;
		}
		GeCameraControllerScroll controller = base.owner.CurrentBeScene.currentGeScene.GetCamera().GetController();
		if (controller == null)
		{
			return;
		}
		controller.SetPause(!isRestore);
		Vector3 cameraPosition = controller.GetCameraPosition();
		cameraPosition.z = -5f;
		controller.SetCameraPosition(cameraPosition);
	}

	// Token: 0x06017A18 RID: 96792 RVA: 0x00747D48 File Offset: 0x00746148
	private Vector3 GetBattlePosBySceneCenterPos()
	{
		if (Singleton<ClientSystemManager>.instance == null || Singleton<ClientSystemManager>.instance.UICamera == null)
		{
			return Vector3.zero;
		}
		Vector3 vector = Singleton<ClientSystemManager>.instance.UICamera.WorldToScreenPoint(Vector3.zero);
		return Camera.main.ScreenToWorldPoint(vector);
	}

	// Token: 0x04010FB0 RID: 69552
	private Vector3 _addModelScale = Vector3.zero;

	// Token: 0x04010FB1 RID: 69553
	private float _zPosOffset = 5f;
}
