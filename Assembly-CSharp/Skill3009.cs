using System;
using System.Collections.Generic;
using Battle;
using GameClient;
using UnityEngine;

// Token: 0x020044B5 RID: 17589
public class Skill3009 : BeSkill
{
	// Token: 0x06018771 RID: 100209 RVA: 0x007A3069 File Offset: 0x007A1469
	public Skill3009(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018772 RID: 100210 RVA: 0x007A3089 File Offset: 0x007A1489
	public override void OnInit()
	{
	}

	// Token: 0x06018773 RID: 100211 RVA: 0x007A308C File Offset: 0x007A148C
	public override void OnStart()
	{
		this.m_GeGrapObj = null;
		this.m_GeGrapParentObj = null;
		this.m_attachToFlag = false;
		base.owner.IsSuplexGrap = true;
		this.m_ReplaceSkillHandle = base.owner.RegisterEvent(BeEventType.onPreSetSkillAction, delegate(object[] args)
		{
			if (base.owner.HasSkill(3108))
			{
				int[] array = (int[])args[0];
				int num = array[0];
				if (num == this.m_BeiShuaiId)
				{
					array[0] = this.m_RaySkillId;
				}
			}
		});
	}

	// Token: 0x06018774 RID: 100212 RVA: 0x007A30DC File Offset: 0x007A14DC
	public override void OnUpdate(int iDeltime)
	{
		List<BeActor> grapedActorList = base.owner.GrapedActorList;
		if (grapedActorList.Count > 0)
		{
			this.m_grapActor = grapedActorList[0];
			if (this.m_grapActor != null && !this.m_attachToFlag)
			{
				this.m_attachToFlag = true;
				if (this.m_grapActor.aiManager != null)
				{
					this.m_grapActor.aiManager.Stop();
				}
				if (this.m_grapActor.m_pkGeActor != null && !this.m_grapActor.m_pkGeActor.charactorRootIsNull)
				{
					try
					{
						if (this.m_grapActor != null && this.m_grapActor.m_pkGeActor != null)
						{
							this.m_grapActor.m_pkGeActor.charactorRootIsNull = true;
						}
						float y = this.m_grapActor.m_pkGeActor.GetOverHeadPosition().y;
						this.m_GeGrapObj = this.m_grapActor.m_pkGeActor.GetEntityNode(GeEntity.GeEntityNodeType.Charactor);
						this.m_GeGrapParentObj = this.m_GeGrapObj.transform.parent.gameObject;
						GameObject attachNode = base.owner.m_pkGeActor.GetAttachNode("[actor]RWeapon");
						GeUtility.AttachTo(this.m_GeGrapObj, attachNode, false);
						attachNode.transform.localRotation = Quaternion.Euler(new Vector3(-90f, -90f, -90f));
						base.owner.delayCaller.DelayCall(5, delegate
						{
							try
							{
								if (this.m_GeGrapObj != null)
								{
									Vector3 localScale = this.m_GeGrapObj.transform.localScale;
									if (base.owner.GetFace())
									{
										localScale.x *= -1f;
									}
									this.m_GeGrapObj.transform.localScale = localScale;
								}
							}
							catch (Exception ex2)
							{
								Logger.LogError(ex2.Message);
							}
						}, 0, 0, false);
						this.m_GeGrapObj.transform.localPosition = new Vector3(0f, -y / 2f, 0f);
					}
					catch (Exception ex)
					{
						Logger.LogError(ex.Message);
					}
				}
				this.SetStartGrapLogicPos();
				base.owner.delayCaller.DelayCall(700, delegate
				{
					this.ChangeGrapedLogicPos();
				}, 0, 0, false);
			}
		}
	}

	// Token: 0x06018775 RID: 100213 RVA: 0x007A32D8 File Offset: 0x007A16D8
	protected void SetStartGrapLogicPos()
	{
		if (this.m_grapActor == null)
		{
			return;
		}
		VInt3 position = base.owner.GetPosition();
		int x = (!base.owner.GetFace()) ? (position.x + VInt.Float2VIntValue(0.3f)) : (position.x - VInt.Float2VIntValue(0.3f));
		this.SetNewPos(this.m_grapActor, new VInt3(x, position.y, position.z));
	}

	// Token: 0x06018776 RID: 100214 RVA: 0x007A3358 File Offset: 0x007A1758
	protected void ChangeGrapedLogicPos()
	{
		if (this.m_grapActor == null)
		{
			return;
		}
		bool face = base.owner.GetFace();
		VInt3 position = base.owner.GetPosition();
		int x = (!face) ? (position.x - VInt.Float2VIntValue(0.6f)) : (position.x + VInt.Float2VIntValue(0.6f));
		this.SetNewPos(this.m_grapActor, new VInt3(x, position.y, position.z));
	}

	// Token: 0x06018777 RID: 100215 RVA: 0x007A33D9 File Offset: 0x007A17D9
	public override void OnCancel()
	{
		this.RestoreGrapedPos(true);
		this.Remove();
	}

	// Token: 0x06018778 RID: 100216 RVA: 0x007A33E8 File Offset: 0x007A17E8
	public override void OnFinish()
	{
		this.RestoreGrapedPos(false);
		this.Remove();
	}

	// Token: 0x06018779 RID: 100217 RVA: 0x007A33F8 File Offset: 0x007A17F8
	protected void RestoreGrapedPos(bool interput = false)
	{
		if (this.m_attachToFlag && this.m_grapActor != null)
		{
			if (interput)
			{
				this.m_grapActor.Locomote(new BeStateData(9, 0, 0, VInt.one.i, 0, GlobalLogic.VALUE_300, false), true);
			}
			if (this.m_grapActor.aiManager != null)
			{
				this.m_grapActor.aiManager.Start();
			}
		}
		if (this.m_GeGrapObj != null)
		{
			if (this.m_grapActor != null && this.m_grapActor.m_pkGeActor != null)
			{
				this.m_grapActor.m_pkGeActor.charactorRootIsNull = false;
			}
			if (base.owner.m_pkGeActor != null)
			{
				GameObject attachNode = base.owner.m_pkGeActor.GetAttachNode("[actor]RWeapon");
				if (attachNode != null)
				{
					attachNode.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, -90f));
				}
				else
				{
					int num = (base.owner.GetEntityData() == null) ? 0 : base.owner.GetEntityData().professtion;
					int num2 = (base.owner.GetEntityData() == null) ? 0 : base.owner.GetEntityData().monsterID;
					string text = (base.owner.GetEntityData() == null) ? string.Empty : base.owner.GetEntityData().name;
					Logger.LogErrorFormat("RestoreGrapedPos ID {0} parent is invalid {1} {2} {3} {4}", new object[]
					{
						this.skillID,
						num,
						num2,
						text,
						base.owner.m_pkGeActor.GetResName()
					});
				}
			}
			else
			{
				int num3 = (base.owner.GetEntityData() == null) ? 0 : base.owner.GetEntityData().professtion;
				int num4 = (base.owner.GetEntityData() == null) ? 0 : base.owner.GetEntityData().monsterID;
				string text2 = (base.owner.GetEntityData() == null) ? string.Empty : base.owner.GetEntityData().name;
				Logger.LogErrorFormat("RestoreGrapedPos ID {0} GeActor is invalid {1} {2} {3}", new object[]
				{
					this.skillID,
					num3,
					num4,
					text2
				});
			}
			this.m_GeGrapObj.transform.localPosition = Vector3.zero;
			this.m_GeGrapObj.transform.localRotation = Quaternion.Euler(Vector3.zero);
			if (base.owner.CurrentBeBattle != null && base.owner.CurrentBeBattle.FunctionIsOpen(BattleFlagType.BeiShuaiCannotAttach))
			{
				GeUtility.AttachTo(this.m_GeGrapObj, this.m_GeGrapParentObj, false);
			}
			else if (this.m_GeGrapParentObj == null)
			{
				if (this.m_grapActor != null && this.m_grapActor.IsDeadOrRemoved())
				{
					Object.Destroy(this.m_GeGrapObj);
				}
			}
			else
			{
				GeUtility.AttachTo(this.m_GeGrapObj, this.m_GeGrapParentObj, false);
			}
			this.m_GeGrapObj = null;
			this.m_GeGrapParentObj = null;
		}
	}

	// Token: 0x0601877A RID: 100218 RVA: 0x007A3748 File Offset: 0x007A1B48
	protected void SetNewPos(BeActor actor, VInt3 newPos)
	{
		if (actor == null || actor.IsDead())
		{
			return;
		}
		if (actor.CurrentBeScene.IsInBlockPlayer(newPos))
		{
			VInt3 rkPos = BeAIManager.FindStandPositionNew(newPos, actor.CurrentBeScene, false, false, 12);
			actor.SetPosition(rkPos, false, true, false);
		}
		else
		{
			actor.SetPosition(newPos, false, true, false);
		}
	}

	// Token: 0x0601877B RID: 100219 RVA: 0x007A37A2 File Offset: 0x007A1BA2
	protected void Remove()
	{
		this.m_attachToFlag = false;
		base.owner.IsSuplexGrap = false;
		if (this.m_ReplaceSkillHandle != null)
		{
			this.m_ReplaceSkillHandle.Remove();
			this.m_ReplaceSkillHandle = null;
		}
	}

	// Token: 0x04011A81 RID: 72321
	protected BeActor m_grapActor;

	// Token: 0x04011A82 RID: 72322
	protected bool m_attachToFlag;

	// Token: 0x04011A83 RID: 72323
	protected GameObject m_GeGrapObj;

	// Token: 0x04011A84 RID: 72324
	protected GameObject m_GeGrapParentObj;

	// Token: 0x04011A85 RID: 72325
	protected int m_BeiShuaiId = 30092;

	// Token: 0x04011A86 RID: 72326
	protected int m_RaySkillId = 30093;

	// Token: 0x04011A87 RID: 72327
	private BeEventHandle m_ReplaceSkillHandle;
}
