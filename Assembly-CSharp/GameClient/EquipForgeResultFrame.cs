using System;
using System.Collections;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015BC RID: 5564
	internal class EquipForgeResultFrame : ClientFrame
	{
		// Token: 0x0600D98E RID: 55694 RVA: 0x00369C2B File Offset: 0x0036802B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/EquipForge/EquipForgeResult";
		}

		// Token: 0x0600D98F RID: 55695 RVA: 0x00369C32 File Offset: 0x00368032
		protected override void _OnOpenFrame()
		{
			this.m_nEquipID = (int)this.userData;
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600D990 RID: 55696 RVA: 0x00369C51 File Offset: 0x00368051
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600D991 RID: 55697 RVA: 0x00369C5F File Offset: 0x0036805F
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipForgeSuccess, new ClientEventSystem.UIEventHandler(this._OnEquipForgeSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.EquipForgeFail, new ClientEventSystem.UIEventHandler(this._OnEquipForgeFail));
		}

		// Token: 0x0600D992 RID: 55698 RVA: 0x00369C97 File Offset: 0x00368097
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipForgeSuccess, new ClientEventSystem.UIEventHandler(this._OnEquipForgeSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.EquipForgeFail, new ClientEventSystem.UIEventHandler(this._OnEquipForgeFail));
		}

		// Token: 0x0600D993 RID: 55699 RVA: 0x00369CD0 File Offset: 0x003680D0
		private void _InitUI()
		{
			this.m_toggleGroup.SetAllTogglesOff();
			this.m_toggleForging.onValueChanged.RemoveAllListeners();
			this.m_toggleForging.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					this._OnEnterForingState();
				}
				else
				{
					this._OnLeaveForingState();
				}
			});
			this.m_toggleFailed.onValueChanged.RemoveAllListeners();
			this.m_toggleFailed.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					this._OnEnterFailedState();
				}
				else
				{
					this._OnLeaveFailedState();
				}
			});
			this.m_toggleSuccessed.onValueChanged.RemoveAllListeners();
			this.m_toggleSuccessed.onValueChanged.AddListener(delegate(bool var)
			{
				if (var)
				{
					this._OnEnterSuccessedState();
				}
				else
				{
					this._OnLeaveSuccessedState();
				}
			});
			this._SetCurrentState(EquipForgeResultFrame.EState.Forgeing);
		}

		// Token: 0x0600D994 RID: 55700 RVA: 0x00369D73 File Offset: 0x00368173
		private void _ClearUI()
		{
			this.m_resultState = EquipForgeResultFrame.EState.Invalid;
			this.m_nEquipID = 0;
			this.m_uFailedCode = 0U;
		}

		// Token: 0x0600D995 RID: 55701 RVA: 0x00369D8C File Offset: 0x0036818C
		private void _SetCurrentState(EquipForgeResultFrame.EState a_state)
		{
			if (a_state == EquipForgeResultFrame.EState.Forgeing)
			{
				this.m_toggleForging.isOn = false;
				this.m_toggleForging.isOn = true;
			}
			else if (a_state == EquipForgeResultFrame.EState.Successed)
			{
				this.m_toggleSuccessed.isOn = false;
				this.m_toggleSuccessed.isOn = true;
				MonoSingleton<AudioManager>.instance.PlaySound(12);
			}
			else if (a_state == EquipForgeResultFrame.EState.Failed)
			{
				this.m_toggleFailed.isOn = false;
				this.m_toggleFailed.isOn = true;
				MonoSingleton<AudioManager>.instance.PlaySound(11);
			}
		}

		// Token: 0x0600D996 RID: 55702 RVA: 0x00369E1A File Offset: 0x0036821A
		private void _OnEnterForingState()
		{
			this.m_progress.StartCoroutine(this._StartForing());
		}

		// Token: 0x0600D997 RID: 55703 RVA: 0x00369E2E File Offset: 0x0036822E
		private void _OnLeaveForingState()
		{
		}

		// Token: 0x0600D998 RID: 55704 RVA: 0x00369E30 File Offset: 0x00368230
		private void _OnEnterFailedState()
		{
			this.m_labFailReason.text = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)this.m_uFailedCode, string.Empty, string.Empty).Descs;
		}

		// Token: 0x0600D999 RID: 55705 RVA: 0x00369E5C File Offset: 0x0036825C
		private void _OnLeaveFailedState()
		{
		}

		// Token: 0x0600D99A RID: 55706 RVA: 0x00369E60 File Offset: 0x00368260
		private void _OnEnterSuccessedState()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.m_nEquipID, 100, 0);
			ComItem comItem = this.m_objEquipRoot.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(this.m_objEquipRoot);
			}
			comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
			});
			this.m_labEquipName.text = itemData.GetColorName(string.Empty, false);
			this.m_labGotTip.text = TR.Value("equipforge_got_tip", itemData.GetColorName(string.Empty, false));
		}

		// Token: 0x0600D99B RID: 55707 RVA: 0x00369EFD File Offset: 0x003682FD
		private void _OnLeaveSuccessedState()
		{
		}

		// Token: 0x0600D99C RID: 55708 RVA: 0x00369F00 File Offset: 0x00368300
		private IEnumerator _StartForing()
		{
			this.m_progress.value = 0f;
			float fTime = 2.1f;
			float fRate = 1f / fTime;
			while (fTime > 0f)
			{
				yield return Yielders.EndOfFrame;
				fTime -= Time.deltaTime;
				if (fTime < 0f)
				{
					fTime = 0f;
				}
				this.m_progress.value = 1f - fTime * fRate;
			}
			this.m_progress.value = 1f;
			DataManager<EquipForgeDataManager>.GetInstance().ForgeEquip(this.m_nEquipID);
			while (this.m_resultState == EquipForgeResultFrame.EState.Invalid)
			{
				yield return Yielders.EndOfFrame;
			}
			bool bAnimCompleted = false;
			DOTweenAnimation anim = this.m_objForingEffect.GetComponent<DOTweenAnimation>();
			anim.onStepComplete.RemoveAllListeners();
			anim.onStepComplete.AddListener(delegate()
			{
				bAnimCompleted = true;
				anim.DOPause();
			});
			while (!bAnimCompleted)
			{
				yield return Yielders.EndOfFrame;
			}
			this._SetCurrentState(this.m_resultState);
			yield break;
		}

		// Token: 0x0600D99D RID: 55709 RVA: 0x00369F1B File Offset: 0x0036831B
		private void _OnEquipForgeSuccess(UIEvent a_event)
		{
			this.m_nEquipID = (int)a_event.Param1;
			this.m_resultState = EquipForgeResultFrame.EState.Successed;
		}

		// Token: 0x0600D99E RID: 55710 RVA: 0x00369F35 File Offset: 0x00368335
		private void _OnEquipForgeFail(UIEvent a_event)
		{
			this.m_uFailedCode = (uint)a_event.Param1;
			this.m_resultState = EquipForgeResultFrame.EState.Failed;
		}

		// Token: 0x0600D99F RID: 55711 RVA: 0x00369F4F File Offset: 0x0036834F
		[UIEventHandle("State/Forging/Group/Func")]
		private void _OnCancelForgingClicked()
		{
			this.m_progress.StopAllCoroutines();
			this.frameMgr.CloseFrame<EquipForgeResultFrame>(this, false);
		}

		// Token: 0x0600D9A0 RID: 55712 RVA: 0x00369F69 File Offset: 0x00368369
		[UIEventHandle("State/Failed/Group/Func")]
		private void _OnFailedReturnClicked()
		{
			this.frameMgr.CloseFrame<EquipForgeResultFrame>(this, false);
		}

		// Token: 0x0600D9A1 RID: 55713 RVA: 0x00369F78 File Offset: 0x00368378
		[UIEventHandle("State/Successed/Group/Func")]
		private void _OnSuccessedReturnClicked()
		{
			this.frameMgr.CloseFrame<EquipForgeResultFrame>(this, false);
		}

		// Token: 0x04007FFC RID: 32764
		[UIControl("State/Forging", null, 0)]
		private Toggle m_toggleForging;

		// Token: 0x04007FFD RID: 32765
		[UIControl("State/Failed", null, 0)]
		private Toggle m_toggleFailed;

		// Token: 0x04007FFE RID: 32766
		[UIControl("State/Successed", null, 0)]
		private Toggle m_toggleSuccessed;

		// Token: 0x04007FFF RID: 32767
		[UIControl("State", null, 0)]
		private ToggleGroup m_toggleGroup;

		// Token: 0x04008000 RID: 32768
		[UIControl("State/Forging/Group/Progress", null, 0)]
		private Slider m_progress;

		// Token: 0x04008001 RID: 32769
		[UIControl("State/Failed/Group/Reason", null, 0)]
		private Text m_labFailReason;

		// Token: 0x04008002 RID: 32770
		[UIObject("State/Successed/Group/EquipRoot")]
		private GameObject m_objEquipRoot;

		// Token: 0x04008003 RID: 32771
		[UIObject("Effect/Foring/Image_CZ")]
		private GameObject m_objForingEffect;

		// Token: 0x04008004 RID: 32772
		[UIControl("State/Successed/Group/EquipName", null, 0)]
		private Text m_labEquipName;

		// Token: 0x04008005 RID: 32773
		[UIControl("State/Successed/Group/GotTip", null, 0)]
		private Text m_labGotTip;

		// Token: 0x04008006 RID: 32774
		private EquipForgeResultFrame.EState m_resultState;

		// Token: 0x04008007 RID: 32775
		private int m_nEquipID;

		// Token: 0x04008008 RID: 32776
		private uint m_uFailedCode;

		// Token: 0x020015BD RID: 5565
		private enum EState
		{
			// Token: 0x0400800B RID: 32779
			Invalid,
			// Token: 0x0400800C RID: 32780
			Forgeing,
			// Token: 0x0400800D RID: 32781
			Failed,
			// Token: 0x0400800E RID: 32782
			Successed
		}
	}
}
