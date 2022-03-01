using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001110 RID: 4368
	public class ChijiMapFrame : ClientFrame
	{
		// Token: 0x0600A59B RID: 42395 RVA: 0x0022429D File Offset: 0x0022269D
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiMapFrame";
		}

		// Token: 0x0600A59C RID: 42396 RVA: 0x002242A4 File Offset: 0x002226A4
		protected sealed override void _OnOpenFrame()
		{
			this._BindUIEvent();
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				Logger.LogError("ChijiMapFrame must open in Chiji Scene!!");
				return;
			}
			if (this.userData != null)
			{
				this.mapState = (ChijiMapState)this.userData;
			}
			if (this.mTouchMoveCamera2D != null)
			{
				this.mTouchMoveCamera2D.enabled = (this.mapState == ChijiMapState.Full_Map);
			}
			if (this.mMapScene != null)
			{
				this.mMapScene.Initialize();
				this.mMapScene.btnScene.onMouseClick.RemoveAllListeners();
				this.mMapScene.btnScene.onMouseClick.AddListener(new UnityAction<PointerEventData>(this._OnClickMapPos));
			}
			if (this.mPlayer_main != null)
			{
				this.mPlayer_main.Initialize();
				if (this.mMapScene != null)
				{
					if (clientSystemGameBattle.MainPlayer != null)
					{
						this.mPlayer_main.Setup(clientSystemGameBattle.MainPlayer, this.mMapScene);
					}
					else
					{
						SystemNotifyManager.SysNotifyMsgBoxOK("吃鸡小地图[_OnOpenFrame],systemTown.MainPlayer == null", null, string.Empty, false);
					}
				}
				else
				{
					SystemNotifyManager.SysNotifyMsgBoxOK("吃鸡小地图[_OnOpenFrame],mMapScene == null", null, string.Empty, false);
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("吃鸡小地图[_OnOpenFrame],mPlayer_main == null", null, string.Empty, false);
			}
			BeTownPlayerMain.OnAutoMoveSuccess.AddListener(new UnityAction(this._OnAutoMoveEnd));
			BeTownPlayerMain.OnAutoMoveFail.AddListener(new UnityAction(this._OnAutoMoveEnd));
			if (this.mTouchMoveCamera2D != null)
			{
				if (this.mPlayer_main != null)
				{
					this.mTouchMoveCamera2D.PlayerTransform = this.mPlayer_main.gameObject.transform;
				}
				else
				{
					SystemNotifyManager.SysNotifyMsgBoxOK("吃鸡小地图[_OnOpenFrame]，mPlayer_main == null，mTouchMoveCamera2D.PlayerTransform没有被赋值", null, string.Empty, false);
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("吃鸡小地图[_OnOpenFrame],mTouchMoveCamera2D == null", null, string.Empty, false);
			}
		}

		// Token: 0x0600A59D RID: 42397 RVA: 0x00224491 File Offset: 0x00222891
		protected sealed override void _OnCloseFrame()
		{
			this._UnBindUIEvent();
			BeTownPlayerMain.OnAutoMoveSuccess.RemoveListener(new UnityAction(this._OnAutoMoveEnd));
			BeTownPlayerMain.OnAutoMoveFail.RemoveListener(new UnityAction(this._OnAutoMoveEnd));
			this._ClearData();
		}

		// Token: 0x0600A59E RID: 42398 RVA: 0x002244CB File Offset: 0x002228CB
		private void _ClearData()
		{
			this.mapState = ChijiMapState.Mini_Map;
			this.fLineTimeIntrval = 0f;
			this.centerpos = Vector2.zero;
			this.WhiteRadius = 0f;
		}

		// Token: 0x0600A59F RID: 42399 RVA: 0x002244F5 File Offset: 0x002228F5
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this._OnUpdateComMapPlayerJobID));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PoisonNextStage, new ClientEventSystem.UIEventHandler(this._OnPoisonNextStage));
		}

		// Token: 0x0600A5A0 RID: 42400 RVA: 0x0022452A File Offset: 0x0022292A
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.JobIDReset, new ClientEventSystem.UIEventHandler(this._OnUpdateComMapPlayerJobID));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PoisonNextStage, new ClientEventSystem.UIEventHandler(this._OnPoisonNextStage));
		}

		// Token: 0x0600A5A1 RID: 42401 RVA: 0x0022455F File Offset: 0x0022295F
		private void _OnPoisonNextStage(UIEvent iEvent)
		{
			this.SetWhiteCircle(DataManager<ChijiDataManager>.GetInstance().PoisonRing.nextStageCenter, DataManager<ChijiDataManager>.GetInstance().PoisonRing.nextStageRadius);
		}

		// Token: 0x0600A5A2 RID: 42402 RVA: 0x00224588 File Offset: 0x00222988
		private void _OnUpdateComMapPlayerJobID(UIEvent iEvent)
		{
			if (this.mapState == ChijiMapState.Mini_Map)
			{
				ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
				if (clientSystemGameBattle != null)
				{
					if (this.mPlayer_main != null && this.mMapScene != null)
					{
						if (clientSystemGameBattle.MainPlayer != null)
						{
							this.mPlayer_main.Setup(clientSystemGameBattle.MainPlayer, this.mMapScene);
						}
						else
						{
							SystemNotifyManager.SysNotifyMsgBoxOK("吃鸡小地图[_OnUpdateComMapPlayerJobID],systemChiji.MainPlayer == null,角色尚未创建", null, string.Empty, false);
						}
					}
					else
					{
						SystemNotifyManager.SysNotifyMsgBoxOK("吃鸡小地图[_OnUpdateComMapPlayerJobID],mPlayer_main == null 或者 mMapScene == null", null, string.Empty, false);
					}
				}
				else
				{
					SystemNotifyManager.SysNotifyMsgBoxOK("吃鸡小地图[_OnUpdateComMapPlayerJobID],ClientSystemGameBattle == null", null, string.Empty, false);
				}
			}
		}

		// Token: 0x0600A5A3 RID: 42403 RVA: 0x0022463C File Offset: 0x00222A3C
		private void _OnAutoMoveEnd()
		{
			this.mTargetPos.SetActive(false);
		}

		// Token: 0x0600A5A4 RID: 42404 RVA: 0x0022464C File Offset: 0x00222A4C
		private void _OnClickMapPos(PointerEventData pointEventData)
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle == null)
			{
				return;
			}
			if (clientSystemGameBattle.MainPlayer == null)
			{
				return;
			}
			Vector2 zero = Vector2.zero;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.mMapScene.GetComponent<RectTransform>(), pointEventData.pressPosition, pointEventData.enterEventCamera, ref zero);
			Vector3 vector;
			vector..ctor(zero.x / this.mMapScene.XRate, 0f, zero.y / this.mMapScene.ZRate);
			Vector3 a_vecPos = vector + this.mMapScene.offset;
			clientSystemGameBattle.MainPlayer.CommandMoveToScene(this.mMapScene.SceneID, a_vecPos);
			if (this.mTargetPos != null)
			{
				this.mTargetPos.transform.SetParent(this.mMapScene.transform, false);
				this.mTargetPos.transform.localPosition = new Vector3(zero.x, zero.y, 0f);
				this.mTargetPos.SetActive(true);
			}
		}

		// Token: 0x0600A5A5 RID: 42405 RVA: 0x0022475D File Offset: 0x00222B5D
		public void SetScale(Vector2 scale)
		{
			this.frame.GetComponent<RectTransform>().localScale = new Vector3(scale.x, scale.y, 1f);
		}

		// Token: 0x0600A5A6 RID: 42406 RVA: 0x00224788 File Offset: 0x00222B88
		public Vector2 GetSize()
		{
			Vector2 size = this.frame.GetComponent<RectTransform>().rect.size;
			Vector3 localScale = this.frame.GetComponent<RectTransform>().localScale;
			return new Vector2(size.x * localScale.x, size.y * localScale.y);
		}

		// Token: 0x0600A5A7 RID: 42407 RVA: 0x002247E4 File Offset: 0x00222BE4
		public Vector2 GetPlayerMainPos()
		{
			if (this.mPlayer_main == null)
			{
				return Vector2.zero;
			}
			Vector3 vector = this.mPlayer_main.transform.localPosition + this.mPlayer_main.transform.parent.localPosition;
			Vector3 localScale = this.frame.GetComponent<RectTransform>().localScale;
			return new Vector2(vector.x * localScale.x, vector.y * localScale.y);
		}

		// Token: 0x0600A5A8 RID: 42408 RVA: 0x00224867 File Offset: 0x00222C67
		public void SetBlueCircle(Vector2 center, float radius, float durTime, float totalTime)
		{
			if (this.mBlueCircle != null)
			{
				this.mBlueCircle.Setup(center, radius, durTime, totalTime, this.mMapScene);
			}
		}

		// Token: 0x0600A5A9 RID: 42409 RVA: 0x00224890 File Offset: 0x00222C90
		public void SetWhiteCircle(Vector2 center, float radius)
		{
			this.centerpos = center;
			this.WhiteRadius = radius;
			if (this.mWhiteCircle != null)
			{
				this.mWhiteCircle.Setup(center, radius, this.mMapScene);
			}
		}

		// Token: 0x0600A5AA RID: 42410 RVA: 0x002248C4 File Offset: 0x00222CC4
		public void ResetSourceCircle(Vector2 srcPos, float srcRadius)
		{
			if (this.mBlueCircle != null)
			{
				this.mBlueCircle.ResetSource(srcRadius, srcPos);
			}
		}

		// Token: 0x0600A5AB RID: 42411 RVA: 0x002248E4 File Offset: 0x00222CE4
		private void _UpdateDashesLine()
		{
			if (this.mPlayer_main == null || this.WhiteRadius < 1f)
			{
				this.mLine.CustomActive(false);
				return;
			}
			float num = Mathf.Sqrt(Mathf.Pow(this.mPlayer_main.ServerPos.x - this.centerpos.x, 2f) + Mathf.Pow(this.mPlayer_main.ServerPos.y - this.centerpos.y, 2f));
			if (num <= this.WhiteRadius)
			{
				this.mLine.CustomActive(false);
				return;
			}
			Vector3 vector = this.mPlayerMain.rectTransform.anchoredPosition + this.mPlayerMain.rectTransform.parent.GetComponent<RectTransform>().anchoredPosition;
			Vector3 vector2 = this.mWhiteCircleCenter.rectTransform.anchoredPosition;
			Vector2 sizeDelta = this.mLine.rectTransform.sizeDelta;
			sizeDelta.x = Mathf.Sqrt(Mathf.Pow(vector2.x - vector.x, 2f) + Mathf.Pow(vector2.y - vector.y, 2f));
			this.mLine.rectTransform.sizeDelta = sizeDelta;
			Vector3 vector3 = this.mLine.rectTransform.anchoredPosition;
			vector3.x = (vector2.x + vector.x) / 2f;
			vector3.y = (vector2.y + vector.y) / 2f;
			this.mLine.rectTransform.anchoredPosition = vector3;
			float num2 = Mathf.Acos((vector.x - vector2.x) / sizeDelta.x);
			Quaternion localRotation = Quaternion.Euler(0f, 0f, num2 / 3.1415927f * 180f);
			if (vector.y < vector2.y)
			{
				localRotation = Quaternion.Euler(0f, 0f, num2 / -3.1415927f * 180f);
			}
			this.mLine.rectTransform.localRotation = localRotation;
			this.mLine.CustomActive(true);
		}

		// Token: 0x0600A5AC RID: 42412 RVA: 0x00224B33 File Offset: 0x00222F33
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A5AD RID: 42413 RVA: 0x00224B36 File Offset: 0x00222F36
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fLineTimeIntrval += timeElapsed;
			if (this.fLineTimeIntrval >= 0.2f)
			{
				this.fLineTimeIntrval = 0f;
				this._UpdateDashesLine();
			}
		}

		// Token: 0x0600A5AE RID: 42414 RVA: 0x00224B68 File Offset: 0x00222F68
		protected override void _bindExUI()
		{
			this.mTouchMoveCamera2D = this.mBind.GetCom<TouchMoveCamera2D>("TouchMoveCamera2D");
			this.mPlayer_main = this.mBind.GetCom<ComMapPlayer>("player_main");
			this.mBlueCircle = this.mBind.GetCom<ComBlueCircle>("blueCircle");
			this.mWhiteCircle = this.mBind.GetCom<ComWhiteCircle>("whiteCircle");
			this.mTargetPos = this.mBind.GetGameObject("targetPos");
			this.mMapScene = this.mBind.GetCom<ComMapScene>("mapScene");
			this.mLine = this.mBind.GetCom<Image>("line");
			this.mWhiteCircleCenter = this.mBind.GetCom<Image>("whiteCircleCenter");
			this.mPlayerMain = this.mBind.GetCom<Image>("playerMain");
		}

		// Token: 0x0600A5AF RID: 42415 RVA: 0x00224C3C File Offset: 0x0022303C
		protected override void _unbindExUI()
		{
			this.mTouchMoveCamera2D = null;
			this.mPlayer_main = null;
			this.mTargetPos = null;
			this.mMapScene = null;
			this.mBlueCircle = null;
			this.mWhiteCircle = null;
			this.mLine = null;
			this.mWhiteCircleCenter = null;
			this.mPlayerMain = null;
		}

		// Token: 0x04005C90 RID: 23696
		private ChijiMapState mapState;

		// Token: 0x04005C91 RID: 23697
		private float fLineTimeIntrval;

		// Token: 0x04005C92 RID: 23698
		private Vector2 centerpos = Vector2.zero;

		// Token: 0x04005C93 RID: 23699
		private float WhiteRadius;

		// Token: 0x04005C94 RID: 23700
		private TouchMoveCamera2D mTouchMoveCamera2D;

		// Token: 0x04005C95 RID: 23701
		private ComMapPlayer mPlayer_main;

		// Token: 0x04005C96 RID: 23702
		private ComBlueCircle mBlueCircle;

		// Token: 0x04005C97 RID: 23703
		private ComWhiteCircle mWhiteCircle;

		// Token: 0x04005C98 RID: 23704
		private GameObject mTargetPos;

		// Token: 0x04005C99 RID: 23705
		private ComMapScene mMapScene;

		// Token: 0x04005C9A RID: 23706
		private Image mLine;

		// Token: 0x04005C9B RID: 23707
		private Image mWhiteCircleCenter;

		// Token: 0x04005C9C RID: 23708
		private Image mPlayerMain;
	}
}
