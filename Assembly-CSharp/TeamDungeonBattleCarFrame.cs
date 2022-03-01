using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020010E4 RID: 4324
public class TeamDungeonBattleCarFrame : ClientFrame
{
	// Token: 0x0600A3D1 RID: 41937 RVA: 0x00219BA4 File Offset: 0x00217FA4
	protected override void _bindExUI()
	{
		this.mBtn_AttackEvent = this.mBind.GetCom<TMButtonEvent>("Btn_AttackEvent");
		this.mNormalAttackJoystick = this.mBind.GetCom<HGJoyStick>("NormalAttackJoystick");
		this.mBtn_Skill1Event = this.mBind.GetCom<TMButtonEvent>("Btn_Skill1Event");
		this.mBtn_AttackEvent.onPointerDown.AddListener(new UnityAction<PointerEventData>(this._onBtn_AttackButtonPointerDown));
		this.mBtn_Skill1IconImage = this.mBind.GetCom<Image>("Btn_Skill1IconImage");
		this.mBtn_Skill1CDImage = this.mBind.GetCom<Image>("Btn_Skill1CDImage");
		this.mBtn_Skill1CDText = this.mBind.GetCom<Text>("Btn_Skill1CDText");
		this.mBtn_Skill1Event.onPointerDown.AddListener(new UnityAction<PointerEventData>(this._onBtn_Skill1ButtonPointerDown));
		this.mBtn_Skill1Event.onPointerUp.AddListener(new UnityAction<PointerEventData>(this._onBtn_Skill1ButtonPointerUp));
	}

	// Token: 0x0600A3D2 RID: 41938 RVA: 0x00219C8C File Offset: 0x0021808C
	protected override void _unbindExUI()
	{
		this.mNormalAttackJoystick = null;
		this.mBtn_AttackEvent.onPointerDown.RemoveListener(new UnityAction<PointerEventData>(this._onBtn_AttackButtonPointerDown));
		this.mBtn_AttackEvent = null;
		this.mBtn_Skill1IconImage = null;
		this.mBtn_Skill1CDImage = null;
		this.mBtn_Skill1CDText = null;
		this.mBtn_Skill1Event.onPointerDown.RemoveListener(new UnityAction<PointerEventData>(this._onBtn_Skill1ButtonPointerDown));
		this.mBtn_Skill1Event.onPointerUp.RemoveListener(new UnityAction<PointerEventData>(this._onBtn_Skill1ButtonPointerUp));
		this.mBtn_Skill1Event = null;
	}

	// Token: 0x0600A3D3 RID: 41939 RVA: 0x00219D17 File Offset: 0x00218117
	private void _onBtn_AttackButtonPointerDown(PointerEventData eventData)
	{
		InputManager.CreateSkillSynSightFrameCommand(this._normalAttackId, 3, 0);
		InputManager.CreateSkillSynSightFrameCommand(this._normalAttackId, 1, 0);
		this.mNormalAttackJoystick.CustomActive(true);
	}

	// Token: 0x0600A3D4 RID: 41940 RVA: 0x00219D3F File Offset: 0x0021813F
	private void _onBtn_Skill1ButtonPointerDown(PointerEventData eventData)
	{
		InputManager.instance.CreateSkillFrameCommand(this._skillId, 0);
	}

	// Token: 0x0600A3D5 RID: 41941 RVA: 0x00219D52 File Offset: 0x00218152
	private void _onBtn_Skill1ButtonPointerUp(PointerEventData eventData)
	{
		InputManager.instance.CreateSkillFrameCommand(this._skillId, 1);
	}

	// Token: 0x0600A3D6 RID: 41942 RVA: 0x00219D65 File Offset: 0x00218165
	public override string GetPrefabPath()
	{
		return "UIFlatten/Prefabs/BattleUI/TeamDungeonBattleCarFrame";
	}

	// Token: 0x0600A3D7 RID: 41943 RVA: 0x00219D6C File Offset: 0x0021816C
	protected override void _OnOpenFrame()
	{
		base._OnOpenFrame();
		this._InitNormalAttackJoystick();
		this._skillId = (int)this.userData;
		this._InitSkill();
		this._SetSkillIconSprite();
		this._RegisterEvent();
	}

	// Token: 0x0600A3D8 RID: 41944 RVA: 0x00219D9D File Offset: 0x0021819D
	protected override void _OnCloseFrame()
	{
		base._OnCloseFrame();
		this._DeInitNormalAttackJoystick();
		this._RemoveEvent();
	}

	// Token: 0x0600A3D9 RID: 41945 RVA: 0x00219DB1 File Offset: 0x002181B1
	protected override void _OnUpdate(float timeElapsed)
	{
		base._OnUpdate(timeElapsed);
		this._UpdateSkillCD(timeElapsed);
	}

	// Token: 0x0600A3DA RID: 41946 RVA: 0x00219DC1 File Offset: 0x002181C1
	public override bool IsNeedUpdate()
	{
		return true;
	}

	// Token: 0x0600A3DB RID: 41947 RVA: 0x00219DC4 File Offset: 0x002181C4
	private void _RegisterEvent()
	{
		this._localActor = BeUtility.GetLocalActor();
		if (this._localActor == null)
		{
			return;
		}
		if (this._localActor.CurrentBeScene == null)
		{
			return;
		}
		this._handleList.Add(this._localActor.CurrentBeScene.RegisterEventNew(BeEventSceneType.onEnterRepairStat, new BeEvent.BeEventHandleNew.Function(this._OnEnterRepairStat)));
		this._handleList.Add(this._localActor.CurrentBeScene.RegisterEventNew(BeEventSceneType.onLeaveRepairStat, new BeEvent.BeEventHandleNew.Function(this._OnLeaveRepairStat)));
	}

	// Token: 0x0600A3DC RID: 41948 RVA: 0x00219E4C File Offset: 0x0021824C
	private void _RemoveEvent()
	{
		for (int i = 0; i < this._handleList.Count; i++)
		{
			BeEvent.BeEventHandleNew beEventHandleNew = this._handleList[i];
			if (beEventHandleNew != null)
			{
				beEventHandleNew.Remove();
			}
		}
	}

	// Token: 0x0600A3DD RID: 41949 RVA: 0x00219E90 File Offset: 0x00218290
	private void _OnEnterRepairStat(BeEvent.BeEventParam param)
	{
		if (this._localActor == null)
		{
			return;
		}
		BeActor beActor = param.m_Obj as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (this._localActor.GetPID() != beActor.GetPID())
		{
			return;
		}
		InputManager.instance.SetMoveJoystickVisible(false);
		this.mBind.gameObject.CustomActive(false);
	}

	// Token: 0x0600A3DE RID: 41950 RVA: 0x00219EF0 File Offset: 0x002182F0
	private void _OnLeaveRepairStat(BeEvent.BeEventParam param)
	{
		if (this._localActor == null)
		{
			return;
		}
		BeActor beActor = param.m_Obj as BeActor;
		if (beActor == null)
		{
			return;
		}
		if (this._localActor.GetPID() != beActor.GetPID())
		{
			return;
		}
		InputManager.instance.SetMoveJoystickVisible(true);
		this.mBind.gameObject.CustomActive(true);
	}

	// Token: 0x0600A3DF RID: 41951 RVA: 0x00219F50 File Offset: 0x00218350
	public void _UpdateSkillCD(float timeElapsed)
	{
		if (this._skill != null && this._skill.isCooldown)
		{
			float num = (float)this._skill.CDLeftTime / 1000f;
			this.mBtn_Skill1CDText.text = num.ToString("f0");
			this.mBtn_Skill1CDImage.CustomActive(true);
			this.mBtn_Skill1CDText.CustomActive(true);
		}
		else
		{
			this.mBtn_Skill1CDImage.CustomActive(false);
			this.mBtn_Skill1CDText.CustomActive(false);
		}
	}

	// Token: 0x0600A3E0 RID: 41952 RVA: 0x00219FD8 File Offset: 0x002183D8
	private void _InitNormalAttackJoystick()
	{
		if (this.mNormalAttackJoystick == null)
		{
			return;
		}
		HGJoyStick hgjoyStick = this.mNormalAttackJoystick;
		hgjoyStick.onMove = (HGJoyStick.Del2)Delegate.Combine(hgjoyStick.onMove, new HGJoyStick.Del2(this._onJoystickMove));
		HGJoyStick hgjoyStick2 = this.mNormalAttackJoystick;
		hgjoyStick2.onRelease = (HGJoyStick.Del3)Delegate.Combine(hgjoyStick2.onRelease, new HGJoyStick.Del3(this._onJoystickRelease));
	}

	// Token: 0x0600A3E1 RID: 41953 RVA: 0x0021A045 File Offset: 0x00218445
	private void _onJoystickMove(int vx, int vy, int degree)
	{
		if (this._lastDegree == degree)
		{
			return;
		}
		this._lastDegree = degree;
		InputManager.CreateSkillSynSightFrameCommand(this._normalAttackId, 1, degree);
	}

	// Token: 0x0600A3E2 RID: 41954 RVA: 0x0021A068 File Offset: 0x00218468
	private void _onJoystickRelease(int degree, bool flag)
	{
		InputManager.CreateSkillSynSightFrameCommand(this._normalAttackId, 0, degree);
		if (this.mNormalAttackJoystick != null)
		{
			this.mNormalAttackJoystick.CustomActive(false);
		}
	}

	// Token: 0x0600A3E3 RID: 41955 RVA: 0x0021A094 File Offset: 0x00218494
	private void _DeInitNormalAttackJoystick()
	{
		if (this.mNormalAttackJoystick == null)
		{
			return;
		}
		this.mNormalAttackJoystick.CustomActive(false);
		HGJoyStick hgjoyStick = this.mNormalAttackJoystick;
		hgjoyStick.onMove = (HGJoyStick.Del2)Delegate.Remove(hgjoyStick.onMove, new HGJoyStick.Del2(this._onJoystickMove));
		HGJoyStick hgjoyStick2 = this.mNormalAttackJoystick;
		hgjoyStick2.onRelease = (HGJoyStick.Del3)Delegate.Remove(hgjoyStick2.onRelease, new HGJoyStick.Del3(this._onJoystickRelease));
	}

	// Token: 0x0600A3E4 RID: 41956 RVA: 0x0021A110 File Offset: 0x00218510
	private void _InitSkill()
	{
		BeActor localActor = BeUtility.GetLocalActor();
		if (localActor == null)
		{
			return;
		}
		BeSkill skill = localActor.GetSkill(this._skillId);
		if (skill == null)
		{
			return;
		}
		this._skill = skill;
	}

	// Token: 0x0600A3E5 RID: 41957 RVA: 0x0021A148 File Offset: 0x00218548
	private void _SetSkillIconSprite()
	{
		SkillTable tableItem = Singleton<TableManager>.instance.GetTableItem<SkillTable>(this._skillId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		if (tableItem.Icon == null || tableItem.Icon.Equals("-"))
		{
			return;
		}
		ETCImageLoader.LoadSprite(ref this.mBtn_Skill1IconImage, tableItem.Icon, true);
	}

	// Token: 0x04005B6D RID: 23405
	private TMButtonEvent mBtn_AttackEvent;

	// Token: 0x04005B6E RID: 23406
	private HGJoyStick mNormalAttackJoystick;

	// Token: 0x04005B6F RID: 23407
	private TMButtonEvent mBtn_Skill1Event;

	// Token: 0x04005B70 RID: 23408
	private Image mBtn_Skill1IconImage;

	// Token: 0x04005B71 RID: 23409
	private Image mBtn_Skill1CDImage;

	// Token: 0x04005B72 RID: 23410
	private Text mBtn_Skill1CDText;

	// Token: 0x04005B73 RID: 23411
	private int _lastDegree = -1;

	// Token: 0x04005B74 RID: 23412
	private int _normalAttackId = 21827;

	// Token: 0x04005B75 RID: 23413
	private int _skillId;

	// Token: 0x04005B76 RID: 23414
	private BeSkill _skill;

	// Token: 0x04005B77 RID: 23415
	private List<BeEvent.BeEventHandleNew> _handleList = new List<BeEvent.BeEventHandleNew>();

	// Token: 0x04005B78 RID: 23416
	private BeActor _localActor;

	// Token: 0x020010E5 RID: 4325
	// (Invoke) Token: 0x0600A3E7 RID: 41959
	private delegate void OnJoystickUpdate(int degree);
}
