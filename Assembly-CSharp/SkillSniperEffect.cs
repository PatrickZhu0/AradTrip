using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02004455 RID: 17493
public class SkillSniperEffect
{
	// Token: 0x060184AC RID: 99500 RVA: 0x007906AC File Offset: 0x0078EAAC
	public SkillSniperEffect(Skill1310 skill, BeActor skillOwner)
	{
		this.skill1310 = skill;
		this.owner = skillOwner;
	}

	// Token: 0x060184AD RID: 99501 RVA: 0x007906F9 File Offset: 0x0078EAF9
	public void InitFrame()
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (this.owner.isLocalActor)
		{
			this.InitSniperFrame();
		}
		else
		{
			this.InitSniperOtherFrame();
		}
	}

	// Token: 0x060184AE RID: 99502 RVA: 0x0079072C File Offset: 0x0078EB2C
	public void SetAttackButtonEnable(bool flag)
	{
		if (this.owner.isLocalActor)
		{
			return;
		}
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (this.attackButton == null && InputManager.instance != null && InputManager.instance.SkillButtons.Count > 0 && InputManager.instance.SkillButtons[0] != null)
		{
			this.attackButton = InputManager.instance.SkillButtons[0].GetComponent<ETCButton>();
		}
		if (this.attackButton != null)
		{
			if (!flag)
			{
				this.attackButton.SetDark(true, 0.5f);
			}
			else
			{
				this.attackButton.SetDark(false, 1f);
			}
		}
	}

	// Token: 0x060184AF RID: 99503 RVA: 0x00790800 File Offset: 0x0078EC00
	protected void InitSniperFrame()
	{
		this.m_SnipertFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<SkillSniperFrame>(FrameLayer.Bottom, null, string.Empty) as SkillSniperFrame);
		if (this.m_SnipertFrame != null)
		{
			if (BattleMain.IsModePvP(this.skill1310.battleType))
			{
				this.m_SnipertFrame.m_MoveXOffset = (float)this.skill1310.m_PvpMoveXOffset / 1000f;
			}
			this.m_SnipertFrame.InitZiDan(this.skill1310.mCurMaxBullet);
			this.m_SnipertFrame.m_Owner = this.owner;
			this.m_SnipertFrame.gameObject.transform.SetAsFirstSibling();
			this.m_Rect = this.m_SnipertFrame.GetTargetParent();
		}
	}

	// Token: 0x060184B0 RID: 99504 RVA: 0x007908B4 File Offset: 0x0078ECB4
	protected void InitSniperOtherFrame()
	{
		if (!BattleMain.IsModePvP(this.skill1310.battleType))
		{
			return;
		}
		this.m_SniperOtherFrame = (Singleton<ClientSystemManager>.instance.OpenFrame<SkillSniperOtherFrame>(FrameLayer.Bottom, null, string.Empty) as SkillSniperOtherFrame);
		if (this.m_SniperOtherFrame != null)
		{
			this.m_SniperOtherFrame.gameObject.transform.SetAsFirstSibling();
			this.m_Rect = this.m_SniperOtherFrame.GetTargetParent();
		}
	}

	// Token: 0x060184B1 RID: 99505 RVA: 0x00790924 File Offset: 0x0078ED24
	public void AttackPhaseStartEffect()
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (!this.owner.isLocalActor)
		{
			return;
		}
		if (this.m_SnipertFrame != null)
		{
			this.m_SnipertFrame.InitCenterPos();
		}
		this.mCurSyncSightAcc = 0;
		if (InputManager.instance != null)
		{
			InputManager.instance.SetButtonStateActive(0);
		}
		this.InitJoystick();
		this.SetCameraUpdatePause(true);
	}

	// Token: 0x060184B2 RID: 99506 RVA: 0x00790994 File Offset: 0x0078ED94
	public void CreateAttackFrame(int curBullet, int curMaxBullet)
	{
		if (!this.owner.isLocalActor)
		{
			return;
		}
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		int audioId = 4327;
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetInCircleMonster(list);
		for (int i = 0; i < list.Count; i++)
		{
			BeActor beActor = list[i];
			if (beActor != null && !beActor.IsDead())
			{
				audioId = 4326;
				InputManager.CreateSkillDoattackFrameCommand(this.skill1310.skillID, curBullet, beActor.GetPID());
			}
		}
		InputManager.CreateSkillDoattackFrameCommand(this.skill1310.skillID, curBullet, 0);
		ListPool<BeActor>.Release(list);
		this.ShowAttackEffect(curBullet, curMaxBullet);
		this.PlayAudio(audioId);
		this.SetAttackButtonEnable(false);
	}

	// Token: 0x060184B3 RID: 99507 RVA: 0x00790A50 File Offset: 0x0078EE50
	public void ShowAttackEffect(int curBullet, int maxBullet)
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (this.m_SnipertFrame != null)
		{
			this.m_SnipertFrame.Attack(curBullet - 1);
			if (curBullet >= maxBullet)
			{
				this.m_SnipertFrame.CloseProgress();
			}
		}
	}

	// Token: 0x060184B4 RID: 99508 RVA: 0x00790A8D File Offset: 0x0078EE8D
	public void ShowOtherAttackEffect()
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (this.owner.isLocalActor || this.m_SniperOtherFrame == null)
		{
			return;
		}
		this.m_SniperOtherFrame.Attack();
	}

	// Token: 0x060184B5 RID: 99509 RVA: 0x00790AC8 File Offset: 0x0078EEC8
	public void RefreshCd(int clickTimeAcc, int currTimeAcc)
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (!this.owner.isLocalActor)
		{
			return;
		}
		if (this.m_SnipertFrame != null)
		{
			VFactor vfactor = new VFactor((long)(clickTimeAcc - currTimeAcc), (long)clickTimeAcc);
			this.m_SnipertFrame.RefreshProgress(vfactor.single);
		}
	}

	// Token: 0x060184B6 RID: 99510 RVA: 0x00790B20 File Offset: 0x0078EF20
	public void UpdateSkillTime(int iDeltime)
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (!this.owner.isLocalActor)
		{
			return;
		}
		if (this.m_SnipertFrame == null)
		{
			return;
		}
		this.SyncSight(iDeltime);
		this.m_SkillTotalTime -= iDeltime;
		if (this.m_SkillTotalTime < 0)
		{
			this.m_SkillTotalTime = 0;
		}
		this.m_SnipertFrame.ShowSkillTime(this.m_SkillTotalTime);
	}

	// Token: 0x060184B7 RID: 99511 RVA: 0x00790B94 File Offset: 0x0078EF94
	protected void SyncSight(int iDeltime)
	{
		if (!BattleMain.IsModePvP(this.skill1310.battleType))
		{
			return;
		}
		if (this.mCurSyncSightAcc < this.mSyncSightAcc)
		{
			this.mCurSyncSightAcc += iDeltime;
		}
		else
		{
			this.mCurSyncSightAcc = 0;
			Vector3 centerScenePos = this.m_SnipertFrame.GetCenterScenePos(this.m_SnipertFrame.GetWorldCenterPoint());
			InputManager.CreateSkillSynSightFrameCommand(this.skill1310.skillID, (int)((centerScenePos.x + 50f) * 100f), (int)((centerScenePos.z + 50f) * 100f));
		}
	}

	// Token: 0x060184B8 RID: 99512 RVA: 0x00790C31 File Offset: 0x0078F031
	protected void PlayAudio(int audioId)
	{
		MonoSingleton<AudioManager>.instance.PlaySound(audioId);
	}

	// Token: 0x060184B9 RID: 99513 RVA: 0x00790C40 File Offset: 0x0078F040
	public void AttackPhaseEnd()
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (this.owner.isLocalActor)
		{
			if (InputManager.instance != null)
			{
				InputManager.instance.ResetButtonState();
			}
			if (this.m_SnipertFrame != null)
			{
				this.m_SnipertFrame.PlayCloseAni();
			}
			this.RemoveJoystick();
			this.SetCameraUpdatePause(false);
		}
	}

	// Token: 0x060184BA RID: 99514 RVA: 0x00790CA4 File Offset: 0x0078F0A4
	public void DoSyncSight(int x, int z)
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (this.owner.isLocalActor)
		{
			return;
		}
		if (this.m_SniperOtherFrame == null)
		{
			return;
		}
		float num = (float)x / 100f - 50f;
		float num2 = 0f;
		float num3 = (float)z / 100f - 50f;
		Vector3 vector = Camera.main.WorldToScreenPoint(new Vector3(num, num2, num3));
		Vector2 localPosFromScreenPos = this.GetLocalPosFromScreenPos(vector);
		this.m_SniperOtherFrame.QiangkouMove(localPosFromScreenPos);
	}

	// Token: 0x060184BB RID: 99515 RVA: 0x00790D38 File Offset: 0x0078F138
	public void CloseFrame()
	{
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			return;
		}
		if (this.owner.isLocalActor)
		{
			if (this.m_SnipertFrame != null)
			{
				this.m_SnipertFrame.Close(false);
				this.m_SnipertFrame = null;
			}
		}
		else if (this.m_SniperOtherFrame != null)
		{
			this.m_SniperOtherFrame.PlayCloseAni();
			this.m_SniperOtherFrame.Close(false);
			this.m_SniperOtherFrame = null;
		}
	}

	// Token: 0x060184BC RID: 99516 RVA: 0x00790DB1 File Offset: 0x0078F1B1
	protected void SetCameraUpdatePause(bool flag)
	{
		this.owner.CurrentBeScene.currentGeScene.GetCamera().GetController().SetPause(flag);
	}

	// Token: 0x060184BD RID: 99517 RVA: 0x00790DD4 File Offset: 0x0078F1D4
	protected void GetInCircleMonster(List<BeActor> targetList)
	{
		if (targetList == null)
		{
			return;
		}
		targetList.Clear();
		List<BeActor> list = ListPool<BeActor>.Get();
		this.skill1310.owner.CurrentBeScene.FindTargets(list, this.owner, VInt.Float2VIntValue(100f), false, null);
		for (int i = 0; i < list.Count; i++)
		{
			Vector3 vector = list[i].GetPosition().vector3;
			Vector3 vector2 = Camera.main.WorldToScreenPoint(vector);
			Vector3 vector3 = Camera.main.WorldToScreenPoint(new Vector3(vector.x, vector.y + 1.5f, vector.z));
			Vector3 vector4 = (vector2 + vector3) / 2f;
			Vector2 localPosFromScreenPos = this.GetLocalPosFromScreenPos(vector2);
			Vector2 localPosFromScreenPos2 = this.GetLocalPosFromScreenPos(vector3);
			Vector2 localPosFromScreenPos3 = this.GetLocalPosFromScreenPos(vector4);
			if (this.LineInterCircle(localPosFromScreenPos, localPosFromScreenPos2, localPosFromScreenPos3, this.m_SnipertFrame.GetCenterPoint()) && !targetList.Contains(list[i]))
			{
				targetList.Add(list[i]);
			}
		}
		ListPool<BeActor>.Release(list);
	}

	// Token: 0x060184BE RID: 99518 RVA: 0x00790F0C File Offset: 0x0078F30C
	protected Vector2 GetLocalPosFromScreenPos(Vector2 screenPos)
	{
		Vector2 result;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(this.m_Rect, screenPos, Singleton<ClientSystemManager>.GetInstance().UICamera, ref result);
		return result;
	}

	// Token: 0x060184BF RID: 99519 RVA: 0x00790F34 File Offset: 0x0078F334
	protected bool LineInterCircle(Vector2 start, Vector2 end, Vector2 center, Vector2 point)
	{
		float num = Vector2.Distance(start, point);
		float num2 = Vector2.Distance(end, point);
		float num3 = Vector2.Distance(center, point);
		return num <= this.m_Radius || num2 <= this.m_Radius || num3 <= this.m_Radius;
	}

	// Token: 0x060184C0 RID: 99520 RVA: 0x00790F83 File Offset: 0x0078F383
	protected void InitJoystick()
	{
		if (InputManager.instance == null)
		{
			return;
		}
		InputManager.instance.SetJoyStickMoveCallback(new UnityAction<Vector2>(this.OnJoyStickMove));
	}

	// Token: 0x060184C1 RID: 99521 RVA: 0x00790FA6 File Offset: 0x0078F3A6
	protected void RemoveJoystick()
	{
		if (InputManager.instance == null)
		{
			return;
		}
		InputManager.instance.ReleaseJoyStickMoveCallback(new UnityAction<Vector2>(this.OnJoyStickMove));
	}

	// Token: 0x060184C2 RID: 99522 RVA: 0x00790FC9 File Offset: 0x0078F3C9
	protected void OnJoyStickMove(Vector2 offset)
	{
		if (this.m_SnipertFrame == null || !this.owner.isLocalActor)
		{
			return;
		}
		this.m_SnipertFrame._OnJoyStickMove(offset);
	}

	// Token: 0x0401187A RID: 71802
	protected SkillSniperFrame m_SnipertFrame;

	// Token: 0x0401187B RID: 71803
	protected SkillSniperOtherFrame m_SniperOtherFrame;

	// Token: 0x0401187C RID: 71804
	protected RectTransform m_Rect;

	// Token: 0x0401187D RID: 71805
	protected float m_Radius = 270f;

	// Token: 0x0401187E RID: 71806
	protected Skill1310 skill1310;

	// Token: 0x0401187F RID: 71807
	protected BeActor owner;

	// Token: 0x04011880 RID: 71808
	public int m_SkillTotalTime = 9910;

	// Token: 0x04011881 RID: 71809
	protected Vector3 m_LastCenterWorldPoint = Vector3.zero;

	// Token: 0x04011882 RID: 71810
	protected ETCButton attackButton;

	// Token: 0x04011883 RID: 71811
	protected int mSyncSightAcc = 250;

	// Token: 0x04011884 RID: 71812
	protected int mCurSyncSightAcc;
}
