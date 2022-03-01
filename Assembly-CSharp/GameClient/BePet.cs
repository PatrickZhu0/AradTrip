using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001154 RID: 4436
	public sealed class BePet : BeBaseFighter
	{
		// Token: 0x0600A93E RID: 43326 RVA: 0x0023B638 File Offset: 0x00239A38
		public BePet(BePetData data, ClientSystemGameBattle systemTown) : base(data, systemTown)
		{
			data.MoveData.MoveSpeed = Vector3.zero;
			BePetData bePetData = base.ActorData as BePetData;
			this.m_petTable = Singleton<TableManager>.GetInstance().GetTableItem<PetTable>(bePetData.PetID, string.Empty, string.Empty);
			if (this.m_petTable == null)
			{
				if (bePetData.FollowId == 0)
				{
					Logger.LogErrorFormat("宠物表 没有ID为 {0} 的条目", new object[]
					{
						bePetData.PetID
					});
				}
				else
				{
					this.followData = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(bePetData.FollowId, string.Empty, string.Empty);
					if (this.followData == null)
					{
						Logger.LogErrorFormat("怪物表 没有ID为 {0} 的条目", new object[]
						{
							bePetData.FollowId
						});
					}
				}
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayActiveFeedPetAction, new ClientEventSystem.UIEventHandler(this._OnFeedSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FollowPetSatietyChanged, new ClientEventSystem.UIEventHandler(this._OnSatietyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TownSceneInited, new ClientEventSystem.UIEventHandler(this._OnSceneChanged));
			this.m_fRemainTime = Global.Settings.petDialogShowInterval;
			this.m_fSpecialIdleRemainTime = Global.Settings.petSpecialIdleInterval;
			this._ResetIdleAction();
		}

		// Token: 0x0600A93F RID: 43327 RVA: 0x0023B808 File Offset: 0x00239C08
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

		// Token: 0x0600A940 RID: 43328 RVA: 0x0023B88F File Offset: 0x00239C8F
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

		// Token: 0x0600A941 RID: 43329 RVA: 0x0023B8C4 File Offset: 0x00239CC4
		public void SetOwner(BeFighter a_owner)
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

		// Token: 0x0600A942 RID: 43330 RVA: 0x0023B960 File Offset: 0x00239D60
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

		// Token: 0x0600A943 RID: 43331 RVA: 0x0023BA6C File Offset: 0x00239E6C
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

		// Token: 0x0600A944 RID: 43332 RVA: 0x0023BE48 File Offset: 0x0023A248
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
				this._geActor = geScene.CreateActorAsyncEx(this.m_petTable.ModeID, 0, 0, false, false, true, new PosLoadGeActorEx(this._PostLoad));
				this._geActor.AddSimpleShadow(Vector3.one);
			}
			base.InitGeActor(geScene);
		}

		// Token: 0x0600A945 RID: 43333 RVA: 0x0023BEB9 File Offset: 0x0023A2B9
		private void _PostLoad(GeActorEx pet)
		{
			this._InitGeDialog();
			this.DoActionSpecialIdle();
			this.m_fSpecialIdleRemainTime = 0.01f;
			this.UpdateMove(0f);
		}

		// Token: 0x0600A946 RID: 43334 RVA: 0x0023BEDD File Offset: 0x0023A2DD
		public override void UpdateGeActor(float timeElapsed)
		{
			this._UpdateGeDialog();
			base.UpdateGeActor(timeElapsed);
		}

		// Token: 0x0600A947 RID: 43335 RVA: 0x0023BEEC File Offset: 0x0023A2EC
		public override void DoActionIdle()
		{
			base.ActorData.ActionData.ActionName = "Anim_Idle01";
			base.ActorData.ActionData.ActionSpeed = 1f;
			base.ActorData.ActionData.ActionLoop = true;
		}

		// Token: 0x0600A948 RID: 43336 RVA: 0x0023BF29 File Offset: 0x0023A329
		public void DoActionHungryIdle()
		{
			base.ActorData.ActionData.ActionName = "Anim_eIdle01";
			base.ActorData.ActionData.ActionSpeed = 1f;
		}

		// Token: 0x0600A949 RID: 43337 RVA: 0x0023BF55 File Offset: 0x0023A355
		public void DoActionSpecialIdle()
		{
			base.ActorData.ActionData.ActionName = "Anim_Idle02";
			base.ActorData.ActionData.ActionSpeed = 1f;
		}

		// Token: 0x0600A94A RID: 43338 RVA: 0x0023BF84 File Offset: 0x0023A384
		public override void DoActionWalk()
		{
			base.ActorData.ActionData.ActionName = "Anim_Walk";
			base.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x0600A94B RID: 43339 RVA: 0x0023BFD4 File Offset: 0x0023A3D4
		public void DoActionHungryWalk()
		{
			base.ActorData.ActionData.ActionName = "Anim_eWalk";
			base.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x0600A94C RID: 43340 RVA: 0x0023C024 File Offset: 0x0023A424
		public void DoActionRun()
		{
			base.ActorData.ActionData.ActionName = "Anim_Run";
			base.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x0600A94D RID: 43341 RVA: 0x0023C074 File Offset: 0x0023A474
		public void DoActionHungryRun()
		{
			base.ActorData.ActionData.ActionName = "Anim_eRun";
			base.ActorData.ActionData.ActionSpeed = Global.Settings.townActionSpeed;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x0600A94E RID: 43342 RVA: 0x0023C0C4 File Offset: 0x0023A4C4
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

		// Token: 0x0600A94F RID: 43343 RVA: 0x0023C170 File Offset: 0x0023A570
		private void _InitGeDialog()
		{
			if (this._geActor != null)
			{
				this.m_objDialogRoot = Singleton<CGameObjectPool>.instance.GetGameObject("UIFlatten/Prefabs/Pet/PetDialog", enResourceType.UIPrefab, 2U);
				if (Singleton<ClientSystemManager>.GetInstance() != null)
				{
					if (Singleton<ClientSystemManager>.GetInstance().SceneUILayer != null)
					{
						this.m_rectDialogParent = Singleton<ClientSystemManager>.GetInstance().SceneUILayer.GetComponent<RectTransform>();
					}
					this.m_cameraUI = Singleton<ClientSystemManager>.GetInstance().UICamera;
				}
				if (this.m_objDialogRoot != null)
				{
					this.m_rectDialog = this.m_objDialogRoot.GetComponent<RectTransform>();
				}
				if (this._geScene != null && this._geScene.GetCamera() != null)
				{
					this.m_cameraScene = this._geScene.GetCamera().GetCamera();
				}
				if (this.m_rectDialog != null)
				{
					this.m_vecDialogOffset = this.m_rectDialog.anchoredPosition;
				}
				if (this.m_rectDialogParent != null)
				{
					this.m_rectDialog.SetParent(this.m_rectDialogParent, false);
				}
				if (this.m_objDialogRoot != null)
				{
					this.m_labDialog = Utility.GetComponetInChild<Text>(this.m_objDialogRoot, "Text");
					this.m_objDialogRoot.SetActive(false);
				}
			}
		}

		// Token: 0x0600A950 RID: 43344 RVA: 0x0023C2B0 File Offset: 0x0023A6B0
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

		// Token: 0x0600A951 RID: 43345 RVA: 0x0023C427 File Offset: 0x0023A827
		private void _UpdateGeDialog()
		{
			if (this._geActor != null && this.m_objDialogRoot != null && base.ActorData.MoveData.TransformDirty)
			{
				this.SetDialogLocalPosition();
			}
		}

		// Token: 0x0600A952 RID: 43346 RVA: 0x0023C460 File Offset: 0x0023A860
		private void _ShowDialog(int a_nDialogBaseID)
		{
			if (this.m_objDialogRoot != null && this.m_labDialog != null)
			{
				PetDialogBaseTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PetDialogBaseTable>(a_nDialogBaseID, string.Empty, string.Empty);
				if (tableItem.FilterType == PetDialogBaseTable.eFilterType.Invalid)
				{
					MonsterSpeech tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MonsterSpeech>(tableItem.DialogIDs[0], string.Empty, string.Empty);
					this.m_labDialog.text = tableItem2.Speech;
				}
				else if (tableItem.FilterType == PetDialogBaseTable.eFilterType.Random)
				{
					int index = Random.Range(0, tableItem.DialogIDs.Count - 1);
					MonsterSpeech tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<MonsterSpeech>(tableItem.DialogIDs[index], string.Empty, string.Empty);
					this.m_labDialog.text = tableItem3.Speech;
				}
				this.SetDialogLocalPosition();
				this.m_objDialogRoot.SetActive(true);
			}
		}

		// Token: 0x0600A953 RID: 43347 RVA: 0x0023C54B File Offset: 0x0023A94B
		private void _HideDialog()
		{
			if (this.m_objDialogRoot != null)
			{
				this.m_objDialogRoot.SetActive(false);
			}
		}

		// Token: 0x0600A954 RID: 43348 RVA: 0x0023C56A File Offset: 0x0023A96A
		private bool _IsHungry()
		{
			return DataManager<PetDataManager>.GetInstance().IsFollowPetHungry();
		}

		// Token: 0x0600A955 RID: 43349 RVA: 0x0023C578 File Offset: 0x0023A978
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

		// Token: 0x0600A956 RID: 43350 RVA: 0x0023C612 File Offset: 0x0023AA12
		private void _ResetIdleAction()
		{
			this.DoActionIdle();
			this.m_fSpecialIdleRemainTime = Global.Settings.petSpecialIdleInterval;
			this.m_bPlaySpecialIdle = false;
		}

		// Token: 0x0600A957 RID: 43351 RVA: 0x0023C631 File Offset: 0x0023AA31
		private void _OnFeedSuccess(UIEvent a_event)
		{
			if (this.m_petTable != null && this.m_bDialogEnable)
			{
				this._ShowDialog(this.m_petTable.FeedDialogID);
				this.m_fRemainTime = Global.Settings.petDialogLife;
			}
		}

		// Token: 0x0600A958 RID: 43352 RVA: 0x0023C66C File Offset: 0x0023AA6C
		private void _OnSatietyChanged(UIEvent a_event)
		{
			if (this.m_petTable != null && this.m_bDialogEnable && this._IsHungry())
			{
				this._ShowDialog(this.m_petTable.HungryDialogID);
				this.m_fRemainTime = Global.Settings.petDialogLife;
			}
		}

		// Token: 0x0600A959 RID: 43353 RVA: 0x0023C6C0 File Offset: 0x0023AAC0
		private void _OnSceneChanged(UIEvent a_event)
		{
			base.ActorData.MoveData.TransformDirty = true;
			base.ActorData.ActionData.isDirty = true;
		}

		// Token: 0x04005E83 RID: 24195
		private BeFighter m_owner;

		// Token: 0x04005E84 RID: 24196
		private Vector3 m_vecPosOffset = new Vector3(1f, 0f, 0f);

		// Token: 0x04005E85 RID: 24197
		private Vector3 m_vecCoefficient = new Vector3(3f, 1f, 3f);

		// Token: 0x04005E86 RID: 24198
		private float m_fRunDist = 1f;

		// Token: 0x04005E87 RID: 24199
		private float m_fa = -5f;

		// Token: 0x04005E88 RID: 24200
		private Vector3 m_vecMinSpeed = new Vector3(1.5f, 0f, 1.5f);

		// Token: 0x04005E89 RID: 24201
		private float m_fSpecialIdleRemainTime = 100f;

		// Token: 0x04005E8A RID: 24202
		private bool m_bPlaySpecialIdle;

		// Token: 0x04005E8B RID: 24203
		private bool m_bDialogEnable;

		// Token: 0x04005E8C RID: 24204
		private float m_fRemainTime = 5f;

		// Token: 0x04005E8D RID: 24205
		private PetTable m_petTable;

		// Token: 0x04005E8E RID: 24206
		protected UnitTable followData;

		// Token: 0x04005E8F RID: 24207
		private GameObject m_objDialogRoot;

		// Token: 0x04005E90 RID: 24208
		private Text m_labDialog;

		// Token: 0x04005E91 RID: 24209
		private RectTransform m_rectDialogParent;

		// Token: 0x04005E92 RID: 24210
		private RectTransform m_rectDialog;

		// Token: 0x04005E93 RID: 24211
		private Camera m_cameraScene;

		// Token: 0x04005E94 RID: 24212
		private Camera m_cameraUI;

		// Token: 0x04005E95 RID: 24213
		private Vector2 m_vecDialogOffset = Vector2.zero;
	}
}
