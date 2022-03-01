using System;
using UnityEngine;

// Token: 0x02004315 RID: 17173
public class Mechanism141 : BeMechanism
{
	// Token: 0x06017C3C RID: 97340 RVA: 0x007559F9 File Offset: 0x00753DF9
	public Mechanism141(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017C3D RID: 97341 RVA: 0x00755A34 File Offset: 0x00753E34
	public override void OnInit()
	{
		base.OnInit();
		this.removeBuffId = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		if (this.data.ValueB.Count > 0)
		{
			this.xSpeed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true), GlobalLogic.VALUE_1000);
			this.zSpeed = VInt.NewVInt(TableManager.GetValueFromUnionCell(this.data.ValueB[1], this.level, true), GlobalLogic.VALUE_1000);
		}
		if (this.data.ValueC.Count > 0)
		{
			this.rotateSpeed = TableManager.GetValueFromUnionCell(this.data.ValueC[0], this.level, true);
		}
		if (this.data.ValueD.Count > 0)
		{
			this.mBlockHurtID = TableManager.GetValueFromUnionCell(this.data.ValueD[0], this.level, true);
		}
		if (this.data.ValueE.Count > 0)
		{
			this.mCanRotateOnControled = (TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true) != 0);
		}
	}

	// Token: 0x06017C3E RID: 97342 RVA: 0x00755BAC File Offset: 0x00753FAC
	public override void OnStart()
	{
		if (!this.CanRotate())
		{
			return;
		}
		this.reboundFlag = false;
		this.RecordModelInfo();
		this.handleA = base.owner.RegisterEvent(BeEventType.onXInBlock, delegate(object[] args)
		{
			this.Rebound();
		});
		this.handleB = base.owner.RegisterEvent(BeEventType.onTouchGround, delegate(object[] args)
		{
			this.TouchGround();
		});
		this.handleC = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			base.owner.buffController.RemoveBuff(this.removeBuffId, 0, 0);
		});
	}

	// Token: 0x06017C3F RID: 97343 RVA: 0x00755C2F File Offset: 0x0075402F
	public override void OnUpdate(int deltaTime)
	{
		if (!this.CanRotate())
		{
			return;
		}
		base.OnUpdate(deltaTime);
		this.Rotating(deltaTime);
	}

	// Token: 0x06017C40 RID: 97344 RVA: 0x00755C4B File Offset: 0x0075404B
	public override void OnFinish()
	{
		base.OnFinish();
		this.RestoreRotate();
	}

	// Token: 0x06017C41 RID: 97345 RVA: 0x00755C5C File Offset: 0x0075405C
	protected void RecordModelInfo()
	{
		if (base.owner.m_pkGeActor == null)
		{
			return;
		}
		if (this.rotate == null)
		{
			this.rotate = new GameObject();
			this.root = base.owner.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Charactor).transform;
			if (this.root != null)
			{
				this.rotate.transform.SetParent(this.root);
			}
			this.rotate.transform.localPosition = Vector3.up;
			this.rotate.transform.localRotation = Quaternion.identity;
			this.rotate.transform.localScale = Vector3.one;
		}
		this.shadowObj = base.owner.m_pkGeActor.GetShadowObj();
		if (this.shadowObj != null)
		{
			this.shadowStartPos = this.shadowObj.transform.localPosition;
		}
	}

	// Token: 0x06017C42 RID: 97346 RVA: 0x00755D58 File Offset: 0x00754158
	protected void Rotating(int deltaTime)
	{
		if (this.root != null && this.rotateSpeed != 0)
		{
			this.curRotateAngle = (this.curRotateAngle + this.rotateSpeed) % 360;
			this.root.RotateAround(this.rotate.transform.position, Vector3.forward, (float)this.curRotateAngle);
		}
	}

	// Token: 0x06017C43 RID: 97347 RVA: 0x00755DC4 File Offset: 0x007541C4
	protected void RestoreRotate()
	{
		if (this.root == null)
		{
			return;
		}
		if (this.rotate != null)
		{
			Object.Destroy(this.rotate);
			this.rotate = null;
		}
		this.root.localPosition = Vector3.zero;
		this.root.localEulerAngles = Vector3.zero;
		if (this.shadowObj != null)
		{
			this.shadowObj.transform.localPosition = this.shadowStartPos;
		}
		if (this.shadowObj != null)
		{
			this.shadowObj.CustomActive(true);
		}
	}

	// Token: 0x06017C44 RID: 97348 RVA: 0x00755E6C File Offset: 0x0075426C
	protected void Rebound()
	{
		if (this.reboundFlag)
		{
			return;
		}
		if (this.xSpeed == 0 && this.zSpeed == 0)
		{
			return;
		}
		if (this.mBlockHurtID > 0 && this.attachBuff != null && this.attachBuff.releaser != null)
		{
			VInt3 position = base.owner.GetPosition();
			position.z += VInt.one.i;
			this.attachBuff.releaser._onHurtEntity(base.owner, position, this.mBlockHurtID);
		}
		this.reboundFlag = true;
		VInt moveSpeedX = (!(base.owner.moveXSpeed > 0)) ? this.xSpeed : (-this.xSpeed);
		VInt moveSpeedZ = (!(base.owner.moveYSpeed > 0)) ? this.zSpeed : (-this.zSpeed);
		base.owner.SetMoveSpeedX(moveSpeedX);
		base.owner.SetMoveSpeedZ(moveSpeedZ);
		if (this.shadowObj != null)
		{
			this.shadowObj.CustomActive(false);
		}
	}

	// Token: 0x06017C45 RID: 97349 RVA: 0x00755FA9 File Offset: 0x007543A9
	protected void TouchGround()
	{
		base.owner.buffController.RemoveBuff(this.removeBuffId, 0, 0);
	}

	// Token: 0x06017C46 RID: 97350 RVA: 0x00755FC4 File Offset: 0x007543C4
	protected bool CanRotate()
	{
		if (this.mCanRotateOnControled)
		{
			if (base.owner.GetStateGraph().CurrentStateHasTag(4))
			{
				return false;
			}
		}
		else if (base.owner.GetStateGraph().CurrentStateHasTag(5))
		{
			return false;
		}
		return base.owner.stateController.CanBeFloat();
	}

	// Token: 0x0401116D RID: 69997
	protected int removeBuffId = 360802;

	// Token: 0x0401116E RID: 69998
	protected VInt xSpeed = 0;

	// Token: 0x0401116F RID: 69999
	protected VInt zSpeed = 0;

	// Token: 0x04011170 RID: 70000
	protected int rotateSpeed;

	// Token: 0x04011171 RID: 70001
	protected int mBlockHurtID;

	// Token: 0x04011172 RID: 70002
	private bool mCanRotateOnControled;

	// Token: 0x04011173 RID: 70003
	protected bool reboundFlag;

	// Token: 0x04011174 RID: 70004
	protected int curRotateAngle;

	// Token: 0x04011175 RID: 70005
	protected Transform root;

	// Token: 0x04011176 RID: 70006
	protected GameObject shadowObj;

	// Token: 0x04011177 RID: 70007
	protected Vector3 shadowStartPos = Vector3.zero;

	// Token: 0x04011178 RID: 70008
	private GameObject rotate;
}
