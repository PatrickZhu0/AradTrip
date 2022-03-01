using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001091 RID: 4241
	public class ComDungeonBuffGroup : MonoBehaviour
	{
		// Token: 0x06009FD3 RID: 40915 RVA: 0x00200C0A File Offset: 0x001FF00A
		private void Awake()
		{
			this._bindExUI();
			this._bindEvents();
		}

		// Token: 0x06009FD4 RID: 40916 RVA: 0x00200C18 File Offset: 0x001FF018
		private void Update()
		{
			this.mCountTime += Time.deltaTime;
			if (this.mCountTime > 0.2f)
			{
				this.UpdateBattleBuff(this.mCountTime);
				this.mCountTime = 0f;
			}
		}

		// Token: 0x06009FD5 RID: 40917 RVA: 0x00200C53 File Offset: 0x001FF053
		private void OnDestroy()
		{
			this._unBindExUI();
			this._unBindEvents();
			this.ClearEventHandle();
		}

		// Token: 0x06009FD6 RID: 40918 RVA: 0x00200C67 File Offset: 0x001FF067
		protected void _bindExUI()
		{
			if (null != this.mBuffTipBtn)
			{
				this.mBuffTipBtn.onClick.AddListener(new UnityAction(this._onBuffTipBtnButtonClick));
			}
		}

		// Token: 0x06009FD7 RID: 40919 RVA: 0x00200C96 File Offset: 0x001FF096
		protected void _unBindExUI()
		{
			this.mBuffContent = null;
			if (null != this.mBuffTipBtn)
			{
				this.mBuffTipBtn.onClick.RemoveListener(new UnityAction(this._onBuffTipBtnButtonClick));
			}
			this.mBuffTipBtn = null;
		}

		// Token: 0x06009FD8 RID: 40920 RVA: 0x00200CD3 File Offset: 0x001FF0D3
		private void _bindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattleBuffAdded, new ClientEventSystem.UIEventHandler(this._addBuffEvent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattleBuffCancel, new ClientEventSystem.UIEventHandler(this._removeBuffEvent));
		}

		// Token: 0x06009FD9 RID: 40921 RVA: 0x00200D0B File Offset: 0x001FF10B
		private void _unBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattleBuffAdded, new ClientEventSystem.UIEventHandler(this._addBuffEvent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattleBuffCancel, new ClientEventSystem.UIEventHandler(this._removeBuffEvent));
		}

		// Token: 0x06009FDA RID: 40922 RVA: 0x00200D43 File Offset: 0x001FF143
		private void _onBuffTipBtnButtonClick()
		{
			this.OpenBattleTips();
		}

		// Token: 0x06009FDB RID: 40923 RVA: 0x00200D4B File Offset: 0x001FF14B
		private void ClearEventHandle()
		{
			if (this.onBuffStartEventHandle != null)
			{
				this.onBuffStartEventHandle.Remove();
				this.onBuffStartEventHandle = null;
			}
			if (this.onBuffCancelEventHandle != null)
			{
				this.onBuffCancelEventHandle.Remove();
				this.onBuffCancelEventHandle = null;
			}
		}

		// Token: 0x06009FDC RID: 40924 RVA: 0x00200D88 File Offset: 0x001FF188
		public void InitBattleBuff(BeActor actor)
		{
			if (actor == null)
			{
				return;
			}
			this.buffActor = actor;
			this.buffDisplayFrame.Init(this.mBuffContent, actor);
			this.onBuffStartEventHandle = actor.RegisterEvent(BeEventType.onAddBuff, delegate(object[] args)
			{
				BeBuff beBuff = args[0] as BeBuff;
				if (beBuff != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleBuffAdded, beBuff.buffID, actor, null, null);
				}
			});
			this.onBuffCancelEventHandle = actor.RegisterEvent(BeEventType.onBuffCancel, delegate(object[] args)
			{
				int num = (int)args[0];
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleBuffCancel, num, actor, null, null);
			});
			List<BeBuff> buffList = actor.buffController.GetBuffList();
			for (int i = 0; i < buffList.Count; i++)
			{
				if (this.buffDisplayFrame.IsInited)
				{
					this.buffDisplayFrame._addBuff(buffList[i].buffID);
				}
			}
		}

		// Token: 0x06009FDD RID: 40925 RVA: 0x00200E64 File Offset: 0x001FF264
		private void _addBuffEvent(UIEvent ui)
		{
			int infoTableId = (int)ui.Param1;
			BeActor beActor = ui.Param2 as BeActor;
			if (beActor == null || this.buffActor == null)
			{
				return;
			}
			if (beActor.GetPID() != this.buffActor.GetPID())
			{
				return;
			}
			if (this.buffDisplayFrame.IsInited)
			{
				this.buffDisplayFrame._addBuff(infoTableId);
			}
		}

		// Token: 0x06009FDE RID: 40926 RVA: 0x00200ED0 File Offset: 0x001FF2D0
		private void _removeBuffEvent(UIEvent ui)
		{
			int buffId = (int)ui.Param1;
			BeActor beActor = ui.Param2 as BeActor;
			if (beActor == null || this.buffActor == null)
			{
				return;
			}
			if (beActor.GetPID() != this.buffActor.GetPID())
			{
				return;
			}
			if (this.buffDisplayFrame.IsInited)
			{
				this.buffDisplayFrame._removeBuff(buffId);
			}
		}

		// Token: 0x06009FDF RID: 40927 RVA: 0x00200F3A File Offset: 0x001FF33A
		private void UpdateBattleBuff(float timeElapsed)
		{
			if (this.buffDisplayFrame.IsInited)
			{
				this.buffDisplayFrame._updateBuff(timeElapsed);
			}
		}

		// Token: 0x06009FE0 RID: 40928 RVA: 0x00200F58 File Offset: 0x001FF358
		private void OpenBattleTips()
		{
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<BattleBuffTipsFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<BattleBuffTipsFrame>(null, false);
			}
			else if (this.buffDisplayFrame.GetValidBuffCount() > 0)
			{
				Vector3 position = this.mBuffTipBtn.transform.position;
				position.x -= 39f;
				if (this.mType == ComDungeonBuffGroup.BuffGroupType.Right)
				{
					position.x = position.x - 225f + 78f;
				}
				this.buffDisplayFrame.SetBuffTipListUpdate();
				Singleton<ClientSystemManager>.instance.OpenFrame<BattleBuffTipsFrame>(FrameLayer.Bottom, new object[]
				{
					this.buffDisplayFrame,
					position
				}, string.Empty);
			}
		}

		// Token: 0x04005885 RID: 22661
		[SerializeField]
		private GameObject mBuffContent;

		// Token: 0x04005886 RID: 22662
		[SerializeField]
		private Button mBuffTipBtn;

		// Token: 0x04005887 RID: 22663
		[SerializeField]
		private ComDungeonBuffGroup.BuffGroupType mType;

		// Token: 0x04005888 RID: 22664
		private float mCountTime;

		// Token: 0x04005889 RID: 22665
		private DungeonBuffDisplayFrame buffDisplayFrame = new DungeonBuffDisplayFrame();

		// Token: 0x0400588A RID: 22666
		private BeActor buffActor;

		// Token: 0x0400588B RID: 22667
		private BeEventHandle onBuffStartEventHandle;

		// Token: 0x0400588C RID: 22668
		private BeEventHandle onBuffCancelEventHandle;

		// Token: 0x02001092 RID: 4242
		private enum BuffGroupType
		{
			// Token: 0x0400588E RID: 22670
			LEFT,
			// Token: 0x0400588F RID: 22671
			Right
		}
	}
}
