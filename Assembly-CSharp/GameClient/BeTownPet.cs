using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001190 RID: 4496
	internal class BeTownPet : BeBaseActor
	{
		// Token: 0x0600AC01 RID: 44033 RVA: 0x0024F560 File Offset: 0x0024D960
		public BeTownPet(BeTownPetData data, ClientSystemTown systemTown, bool needDialog = false) : base(data, systemTown)
		{
			data.MoveData.MoveSpeed = Vector3.zero;
			this.m_bNeedDialog = needDialog;
			BeTownPetData beTownPetData = base.ActorData as BeTownPetData;
			this.m_petTable = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(beTownPetData.PetID, string.Empty, string.Empty);
			if (this.m_petTable == null)
			{
				Logger.LogErrorFormat("宠物表 没有ID为 {0} 的条目", new object[]
				{
					beTownPetData.PetID
				});
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayActiveFeedPetAction, new ClientEventSystem.UIEventHandler(this._OnFeedSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FollowPetSatietyChanged, new ClientEventSystem.UIEventHandler(this._OnSatietyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TownSceneInited, new ClientEventSystem.UIEventHandler(this._OnSceneChanged));
			this.m_fRemainTime = Global.Settings.petDialogShowInterval;
			this.m_fSpecialIdleRemainTime = Global.Settings.petSpecialIdleInterval;
			this._ResetIdleAction();
		}

		// Token: 0x0600AC02 RID: 44034 RVA: 0x0024F6E0 File Offset: 0x0024DAE0
		public override void Dispose()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayActiveFeedPetAction, new ClientEventSystem.UIEventHandler(this._OnFeedSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FollowPetSatietyChanged, new ClientEventSystem.UIEventHandler(this._OnSatietyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TownSceneInited, new ClientEventSystem.UIEventHandler(this._OnSceneChanged));
			if (this.m_objDialogRoot != null)
			{
				Object.Destroy(this.m_objDialogRoot);
				this.m_objDialogRoot = null;
			}
			base.Dispose();
		}

		// Token: 0x0600AC03 RID: 44035 RVA: 0x0024F767 File Offset: 0x0024DB67
		public void SetDialogEnable(bool a_bDialogEnable)
		{
			this.m_bDialogEnable = a_bDialogEnable;
			if (!this.m_bDialogEnable)
			{
				this._HideDialog();
			}
			else
			{
				this._HideDialog();
				this.m_fRemainTime = Global.Settings.petDialogShowInterval;
			}
		}

		// Token: 0x0600AC04 RID: 44036 RVA: 0x0024F79C File Offset: 0x0024DB9C
		public void SetOwner(BeTownPlayer a_owner)
		{
			this.m_owner = a_owner;
			if (this.m_owner != null && this.m_owner.IsValid())
			{
				ActorMoveData moveData = this.m_owner.ActorData.MoveData;
				Vector3 position;
				if (moveData.FaceRight)
				{
					position = moveData.Position - this.m_vecPosOffset;
				}
				else
				{
					position = moveData.Position + this.m_vecPosOffset;
				}
				base.ActorData.MoveData.Position = position;
				base.ActorData.MoveData.FaceRight = moveData.FaceRight;
			}
		}

		// Token: 0x0600AC05 RID: 44037 RVA: 0x0024F838 File Offset: 0x0024DC38
		public override void Update(float timeElapsed)
		{
			if (this.m_petTable != null && this.m_bDialogEnable && this.m_objDialogRoot != null)
			{
				if (!this.m_objDialogRoot.activeSelf)
				{
					this.m_fRemainTime -= timeElapsed;
					if (this.m_fRemainTime <= 0f)
					{
						if (this._IsHungry())
						{
							this._ShowDialog(this.m_petTable.HungryDialogID);
						}
						else if (DataManager<PlayerBaseData>.GetInstance().Level > 20)
						{
							this._ShowDialog(this.m_petTable.HighLevelDialogID);
						}
						else
						{
							this._ShowDialog(this.m_petTable.LowLevelDialogID);
						}
						this.m_fRemainTime = Global.Settings.petDialogLife;
					}
				}
				else
				{
					this.m_fRemainTime -= timeElapsed;
					if (this.m_fRemainTime <= 0f)
					{
						this._HideDialog();
						this.m_fRemainTime = Global.Settings.petDialogShowInterval;
					}
				}
			}
			base.Update(timeElapsed);
		}

		// Token: 0x0600AC06 RID: 44038 RVA: 0x0024F944 File Offset: 0x0024DD44
		public override void UpdateMove(float timeElapsed)
		{
			if (this.m_owner != null && this.m_owner.IsValid())
			{
				ActorMoveData moveData = this.m_owner.ActorData.MoveData;
				ActorMoveData moveData2 = base.ActorData.MoveData;
				if (moveData.FaceRight)
				{
					moveData2.TargetPosition = moveData.Position - this.m_vecPosOffset;
				}
				else
				{
					moveData2.TargetPosition = moveData.Position + this.m_vecPosOffset;
				}
				if (base._CheckPosEqual(moveData2.TargetPosition, moveData2.Position))
				{
					if (moveData2.MoveType != EActorMoveType.Invalid)
					{
						moveData2.Position = moveData2.TargetPosition;
						moveData2.TargetPosition = Vector3.zero;
						moveData2.MoveSpeed = Vector3.zero;
						moveData2.FaceRight = moveData.FaceRight;
						moveData2.MoveType = EActorMoveType.Invalid;
						if (this._IsHungry())
						{
							this.DoActionHungryIdle();
						}
						else
						{
							this._ResetIdleAction();
						}
					}
					else if (this._IsHungry())
					{
						this.DoActionHungryIdle();
					}
					else
					{
						this._UpdateIdleAction(timeElapsed);
					}
					return;
				}
				moveData2.MoveType = EActorMoveType.TargetPos;
				Vector3 vector = moveData2.TargetPosition - moveData2.Position;
				if (vector.x > 0f)
				{
					moveData2.FaceRight = true;
				}
				else if (vector.x < 0f)
				{
					moveData2.FaceRight = false;
				}
				if (moveData.MoveType == EActorMoveType.Invalid)
				{
					float num = Mathf.Sqrt(moveData2.MoveSpeed.sqrMagnitude);
					if (num > 0f)
					{
						float num2 = num + this.m_fa * timeElapsed;
						float num3 = num2 / num;
						moveData2.MoveSpeed = this._GetSuitableSpeed(moveData2.MoveSpeed * num3, this.m_vecMinSpeed, moveData.MoveSpeed);
					}
					else
					{
						moveData2.MoveSpeed = this._GetSuitableSpeed(moveData2.MoveSpeed, this.m_vecMinSpeed, moveData.MoveSpeed);
					}
				}
				else
				{
					float num4 = moveData2.MoveSpeed.x + Mathf.Abs(vector.x) * this.m_vecCoefficient.x * timeElapsed;
					float num5 = moveData2.MoveSpeed.z + Mathf.Abs(vector.z) * this.m_vecCoefficient.z * timeElapsed;
					moveData2.MoveSpeed = this._GetSuitableSpeed(new Vector3(num4, 0f, num5), Vector3.zero, moveData.MoveSpeed);
				}
				if (vector.sqrMagnitude > this.m_fRunDist * this.m_fRunDist)
				{
					if (this._IsHungry())
					{
						this.DoActionHungryRun();
					}
					else
					{
						this.DoActionRun();
					}
				}
				else
				{
					moveData2.MoveSpeed = this.m_vecMinSpeed;
					if (this._IsHungry())
					{
						this.DoActionHungryWalk();
					}
					else
					{
						this.DoActionWalk();
					}
				}
				Vector3 vector2 = moveData2.TargetPosition - moveData2.Position;
				Vector3 normalized = vector2.normalized;
				normalized.x *= moveData2.MoveSpeed.x;
				normalized.y *= moveData2.MoveSpeed.y;
				normalized.z *= moveData2.MoveSpeed.z;
				Vector3 vector3 = moveData2.Position + normalized * timeElapsed;
				Vector3 vector4 = moveData2.TargetPosition - vector3;
				if (vector2.x * vector4.x <= 0f)
				{
					vector3.x = moveData2.TargetPosition.x;
				}
				vector3.y = 0f;
				if (vector2.z * vector4.z <= 0f)
				{
					vector3.z = moveData2.TargetPosition.z;
				}
				moveData2.Position = vector3;
			}
		}

		// Token: 0x0600AC07 RID: 44039 RVA: 0x0024FD20 File Offset: 0x0024E120
		public override void InitGeActor(GeSceneEx geScene)
		{
			this._geScene = geScene;
			if (geScene == null)
			{
				return;
			}
			if (this._geActor == null)
			{
				if (this.m_petTable == null)
				{
					return;
				}
				bool flag = false;
				if (this.m_owner != null && this.m_owner is BeTownPlayerMain)
				{
					flag = true;
				}
				ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(this.m_petTable.ModeID, string.Empty, string.Empty);
				if (tableItem != null && !flag && GeAvatarFallback.IsAvatarPartFallbackEnabled() && !GeAvatarFallback.IsAssetDependentAvaliable(tableItem.ModelPath))
				{
					return;
				}
				this._geActor = geScene.CreateActorAsyncEx(this.m_petTable.ModeID, 0, 0, false, false, true, new PosLoadGeActorEx(this._PostLoad));
				if (this._geActor == null)
				{
					Logger.LogErrorFormat("InitGeActor CreateGeActor failed {0}", new object[]
					{
						this.m_petTable.ModeID
					});
				}
				else
				{
					this._geActor.AddSimpleShadow(Vector3.one);
				}
			}
			base.InitGeActor(geScene);
		}

		// Token: 0x0600AC08 RID: 44040 RVA: 0x0024FE2A File Offset: 0x0024E22A
		private void _PostLoad(GeActorEx pet)
		{
			if (this.m_bNeedDialog)
			{
				this._InitGeDialog();
			}
			this.DoActionSpecialIdle();
			this.m_fSpecialIdleRemainTime = 0.01f;
			this.UpdateMove(0f);
		}

		// Token: 0x0600AC09 RID: 44041 RVA: 0x0024FE59 File Offset: 0x0024E259
		public override void UpdateGeActor(float timeElapsed)
		{
			this._UpdateGeDialog();
			base.UpdateGeActor(timeElapsed);
		}

		// Token: 0x0600AC0A RID: 44042 RVA: 0x0024FE68 File Offset: 0x0024E268
		public override void DoActionIdle()
		{
			base.ActorData.ActionData.ActionName = "Anim_Idle01";
			base.ActorData.ActionData.ActionSpeed = 1f;
			base.ActorData.ActionData.ActionLoop = true;
		}

		// Token: 0x0600AC0B RID: 44043 RVA: 0x0024FEA5 File Offset: 0x0024E2A5
		public void DoActionHungryIdle()
		{
			base.ActorData.ActionData.ActionName = "Anim_eIdle01";
			base.ActorData.ActionData.ActionSpeed = 1f;
		}

		// Token: 0x0600AC0C RID: 44044 RVA: 0x0024FED1 File Offset: 0x0024E2D1
		public void DoActionSpecialIdle()
		{
			base.ActorData.ActionData.ActionName = "Anim_Idle02";
			base.ActorData.ActionData.ActionSpeed = 1f;
		}

		// Token: 0x0600AC0D RID: 44045 RVA: 0x0024FF00 File Offset: 0x0024E300
		public override void DoActionWalk()
		{
			base.ActorData.ActionData.ActionName = "Anim_Walk";
			base.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x0600AC0E RID: 44046 RVA: 0x0024FF50 File Offset: 0x0024E350
		public void DoActionHungryWalk()
		{
			base.ActorData.ActionData.ActionName = "Anim_eWalk";
			base.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x0600AC0F RID: 44047 RVA: 0x0024FFA0 File Offset: 0x0024E3A0
		public void DoActionRun()
		{
			base.ActorData.ActionData.ActionName = "Anim_Run";
			base.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x0600AC10 RID: 44048 RVA: 0x0024FFF0 File Offset: 0x0024E3F0
		public void DoActionHungryRun()
		{
			base.ActorData.ActionData.ActionName = "Anim_eRun";
			base.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x0600AC11 RID: 44049 RVA: 0x00250040 File Offset: 0x0024E440
		private Vector3 _GetSuitableSpeed(Vector3 a_vecSourceSpeed, Vector3 a_vecMinSpeed, Vector3 a_vecMaxSpeed)
		{
			if (a_vecSourceSpeed.x > a_vecMaxSpeed.x)
			{
				a_vecSourceSpeed.x = a_vecMaxSpeed.x;
			}
			if (a_vecSourceSpeed.x < a_vecMinSpeed.x)
			{
				a_vecSourceSpeed.x = a_vecMinSpeed.x;
			}
			if (a_vecSourceSpeed.z > a_vecMaxSpeed.z)
			{
				a_vecSourceSpeed.z = a_vecMaxSpeed.z;
			}
			if (a_vecSourceSpeed.z < a_vecMinSpeed.z)
			{
				a_vecSourceSpeed.z = a_vecMinSpeed.z;
			}
			return new Vector3(a_vecSourceSpeed.x, 0f, a_vecSourceSpeed.z);
		}

		// Token: 0x0600AC12 RID: 44050 RVA: 0x002500EC File Offset: 0x0024E4EC
		private void _InitGeDialog()
		{
			if (this._geActor != null)
			{
				this.m_objDialogRoot = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/Pet/PetDialog", enResourceType.UIPrefab, 0U);
				GameObject sceneUILayer = Singleton<ClientSystemManager>.GetInstance().SceneUILayer;
				if (sceneUILayer != null)
				{
					this.m_rectDialogParent = sceneUILayer.GetComponent<RectTransform>();
				}
				if (this.m_objDialogRoot != null)
				{
					this.m_rectDialog = this.m_objDialogRoot.GetComponent<RectTransform>();
				}
				Camera uicamera = Singleton<ClientSystemManager>.GetInstance().UICamera;
				if (uicamera != null)
				{
					this.m_cameraUI = uicamera;
				}
				if (this._geScene != null)
				{
					GeCamera camera = this._geScene.GetCamera();
					if (camera != null)
					{
						Camera camera2 = camera.GetCamera();
						if (camera2 != null)
						{
							this.m_cameraScene = camera2;
						}
					}
				}
				if (this.m_rectDialog != null)
				{
					this.m_vecDialogOffset = this.m_rectDialog.anchoredPosition;
					if (this.m_rectDialogParent != null)
					{
						this.m_rectDialog.SetParent(this.m_rectDialogParent, false);
					}
				}
				if (this.m_objDialogRoot != null)
				{
					this.m_labDialog = Utility.GetComponetInChild<Text>(this.m_objDialogRoot, "Text");
					this.m_objDialogRoot.SetActive(false);
				}
			}
		}

		// Token: 0x0600AC13 RID: 44051 RVA: 0x00250230 File Offset: 0x0024E630
		private void SetDialogLocalPosition()
		{
			Vector3 vector = this.m_cameraScene.WorldToScreenPoint(base.ActorData.MoveData.GraphPosition + this._geActor.GetOverHeadPosition());
			Vector2 vector2;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.m_rectDialogParent, vector, this.m_cameraUI, ref vector2);
			if (base.ActorData.MoveData.FaceRight)
			{
				this.m_rectDialog.localScale = new Vector3(-1f, 1f, 1f);
				this.m_labDialog.transform.localScale = new Vector3(-1f, 1f, 1f);
				this.m_rectDialog.localPosition = vector2 + new Vector2(-this.m_vecDialogOffset.x, this.m_vecDialogOffset.y) + new Vector2(0f, (float)this.m_petTable.PetDialogLocation);
			}
			else
			{
				this.m_rectDialog.localScale = new Vector3(1f, 1f, 1f);
				this.m_labDialog.transform.localScale = new Vector3(1f, 1f, 1f);
				this.m_rectDialog.localPosition = vector2 + this.m_vecDialogOffset + new Vector2(0f, (float)this.m_petTable.PetDialogLocation);
			}
		}

		// Token: 0x0600AC14 RID: 44052 RVA: 0x002503A7 File Offset: 0x0024E7A7
		private void _UpdateGeDialog()
		{
			if (this._geActor != null && this.m_objDialogRoot != null && base.ActorData.MoveData.TransformDirty)
			{
				this.SetDialogLocalPosition();
			}
		}

		// Token: 0x0600AC15 RID: 44053 RVA: 0x002503E0 File Offset: 0x0024E7E0
		private void _ShowDialog(int a_nDialogBaseID)
		{
			if (this.m_objDialogRoot != null && this.m_labDialog != null)
			{
				PetDialogBaseTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetDialogBaseTable>(a_nDialogBaseID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.DialogIDs.Count > 0)
					{
						if (tableItem.FilterType == PetDialogBaseTable.eFilterType.Invalid)
						{
							MonsterSpeech tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MonsterSpeech>(tableItem.DialogIDs[0], string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								this.m_labDialog.text = tableItem2.Speech;
								this.SetDialogLocalPosition();
								this.m_objDialogRoot.CustomActive(true);
							}
							else
							{
								Logger.LogErrorFormat("speechTable == null in [_ShowDialog], a_nDialogBaseID = {0}, MonsterSpeech tablid = {1}", new object[]
								{
									a_nDialogBaseID,
									tableItem.DialogIDs[0]
								});
								this.m_objDialogRoot.CustomActive(false);
							}
						}
						else if (tableItem.FilterType == PetDialogBaseTable.eFilterType.Random)
						{
							int index = Random.Range(0, tableItem.DialogIDs.Count - 1);
							MonsterSpeech tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<MonsterSpeech>(tableItem.DialogIDs[index], string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								this.m_labDialog.text = tableItem3.Speech;
								this.SetDialogLocalPosition();
								this.m_objDialogRoot.CustomActive(true);
							}
							else
							{
								Logger.LogErrorFormat("speechTable == null in [_ShowDialog], a_nDialogBaseID = {0}, MonsterSpeech tablid = {1}", new object[]
								{
									a_nDialogBaseID,
									tableItem.DialogIDs[index]
								});
								this.m_objDialogRoot.CustomActive(false);
							}
						}
					}
					else
					{
						Logger.LogErrorFormat("petDialogBase.DialogIDs.Count == 0 in [_ShowDialog], a_nDialogBaseID = {0}", new object[]
						{
							a_nDialogBaseID
						});
						this.m_objDialogRoot.CustomActive(false);
					}
				}
				else
				{
					Logger.LogErrorFormat("petDialogBase == null in [_ShowDialog], a_nDialogBaseID = {0}", new object[]
					{
						a_nDialogBaseID
					});
					this.m_objDialogRoot.CustomActive(false);
				}
			}
		}

		// Token: 0x0600AC16 RID: 44054 RVA: 0x002505D0 File Offset: 0x0024E9D0
		private void _HideDialog()
		{
			if (this.m_objDialogRoot != null)
			{
				this.m_objDialogRoot.SetActive(false);
			}
		}

		// Token: 0x0600AC17 RID: 44055 RVA: 0x002505EF File Offset: 0x0024E9EF
		private bool _IsHungry()
		{
			return DataManager<PetDataManager>.GetInstance().IsFollowPetHungry();
		}

		// Token: 0x0600AC18 RID: 44056 RVA: 0x002505FC File Offset: 0x0024E9FC
		private void _UpdateIdleAction(float timeElapsed)
		{
			if (this.m_bPlaySpecialIdle)
			{
				this.m_fSpecialIdleRemainTime -= timeElapsed;
				if (this.m_fSpecialIdleRemainTime <= 0f)
				{
					this._ResetIdleAction();
				}
			}
			else
			{
				this.m_fSpecialIdleRemainTime -= timeElapsed;
				if (this.m_fSpecialIdleRemainTime <= 0f)
				{
					this.DoActionSpecialIdle();
					if (this._geActor != null)
					{
						float actionTimeLen = this._geActor.GetActionTimeLen("Anim_Idle02");
						if (actionTimeLen != 0f)
						{
							this.m_fSpecialIdleRemainTime = actionTimeLen;
							this.m_bPlaySpecialIdle = true;
						}
					}
				}
			}
		}

		// Token: 0x0600AC19 RID: 44057 RVA: 0x00250696 File Offset: 0x0024EA96
		private void _ResetIdleAction()
		{
			this.DoActionIdle();
			this.m_fSpecialIdleRemainTime = Global.Settings.petSpecialIdleInterval;
			this.m_bPlaySpecialIdle = false;
		}

		// Token: 0x0600AC1A RID: 44058 RVA: 0x002506B5 File Offset: 0x0024EAB5
		private void _OnFeedSuccess(UIEvent a_event)
		{
			if (this.m_petTable != null && this.m_bDialogEnable)
			{
				this._ShowDialog(this.m_petTable.FeedDialogID);
				this.m_fRemainTime = Global.Settings.petDialogLife;
			}
		}

		// Token: 0x0600AC1B RID: 44059 RVA: 0x002506F0 File Offset: 0x0024EAF0
		private void _OnSatietyChanged(UIEvent a_event)
		{
			if (this.m_petTable != null && this.m_bDialogEnable && this._IsHungry())
			{
				this._ShowDialog(this.m_petTable.HungryDialogID);
				this.m_fRemainTime = Global.Settings.petDialogLife;
			}
		}

		// Token: 0x0600AC1C RID: 44060 RVA: 0x00250744 File Offset: 0x0024EB44
		private void _OnSceneChanged(UIEvent a_event)
		{
			base.ActorData.MoveData.TransformDirty = true;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x04006077 RID: 24695
		private BeTownPlayer m_owner;

		// Token: 0x04006078 RID: 24696
		private Vector3 m_vecPosOffset = new Vector3(1f, 0f, 0f);

		// Token: 0x04006079 RID: 24697
		private Vector3 m_vecCoefficient = new Vector3(3f, 1f, 3f);

		// Token: 0x0400607A RID: 24698
		private float m_fRunDist = 1f;

		// Token: 0x0400607B RID: 24699
		private float m_fa = -5f;

		// Token: 0x0400607C RID: 24700
		private Vector3 m_vecMinSpeed = new Vector3(1.5f, 0f, 1.5f);

		// Token: 0x0400607D RID: 24701
		private float m_fSpecialIdleRemainTime = 100f;

		// Token: 0x0400607E RID: 24702
		private bool m_bPlaySpecialIdle;

		// Token: 0x0400607F RID: 24703
		private bool m_bDialogEnable;

		// Token: 0x04006080 RID: 24704
		private bool m_bNeedDialog;

		// Token: 0x04006081 RID: 24705
		private float m_fRemainTime = 5f;

		// Token: 0x04006082 RID: 24706
		private PetTable m_petTable;

		// Token: 0x04006083 RID: 24707
		private GameObject m_objDialogRoot;

		// Token: 0x04006084 RID: 24708
		private Text m_labDialog;

		// Token: 0x04006085 RID: 24709
		private RectTransform m_rectDialogParent;

		// Token: 0x04006086 RID: 24710
		private RectTransform m_rectDialog;

		// Token: 0x04006087 RID: 24711
		private Camera m_cameraScene;

		// Token: 0x04006088 RID: 24712
		private Camera m_cameraUI;

		// Token: 0x04006089 RID: 24713
		private Vector2 m_vecDialogOffset = Vector2.zero;
	}
}
