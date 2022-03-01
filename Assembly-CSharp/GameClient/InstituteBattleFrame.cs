using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010D3 RID: 4307
	public class InstituteBattleFrame : ClientFrame
	{
		// Token: 0x0600A2EA RID: 41706 RVA: 0x002150D5 File Offset: 0x002134D5
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/InstituteBattleFrame";
		}

		// Token: 0x0600A2EB RID: 41707 RVA: 0x002150DC File Offset: 0x002134DC
		protected override void _bindExUI()
		{
			base._bindExUI();
		}

		// Token: 0x0600A2EC RID: 41708 RVA: 0x002150E4 File Offset: 0x002134E4
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			List<InstituteTable> jobInstituteData = Singleton<TableManager>.instance.GetJobInstituteData((int)BattleMain.instance.GetLocalPlayer(0UL).playerInfo.occupation);
			InstituteTable data = jobInstituteData.Find((InstituteTable x) => x.ID == InstituteFrame.id);
			this.hasPassed = (DataManager<MissionManager>.GetInstance().GetState(data) == 1);
		}

		// Token: 0x0600A2ED RID: 41709 RVA: 0x00215150 File Offset: 0x00213550
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
		}

		// Token: 0x0600A2EE RID: 41710 RVA: 0x00215158 File Offset: 0x00213558
		public void SetBtnState(bool flag)
		{
			if (this.resetBtn != null)
			{
				this.resetBtn.CustomActive(flag);
			}
			if (this.returnTeachBtn != null)
			{
				this.returnTeachBtn.CustomActive(flag);
			}
		}

		// Token: 0x0600A2EF RID: 41711 RVA: 0x00215194 File Offset: 0x00213594
		public void SetBtnEnable(bool flag)
		{
			if (!base.IsOpen())
			{
				return;
			}
			if (this.returnBtn != null)
			{
				this.returnBtn.GetComponent<Button>().interactable = flag;
			}
			if (this.resetBtn != null)
			{
				this.resetBtn.GetComponent<Button>().interactable = flag;
			}
			if (this.returnTeachBtn != null)
			{
				this.returnTeachBtn.GetComponent<Button>().interactable = flag;
			}
		}

		// Token: 0x0600A2F0 RID: 41712 RVA: 0x00215214 File Offset: 0x00213614
		public void SetTitle(int phase)
		{
			if (this.phase == null)
			{
				return;
			}
			if (phase == 0)
			{
				this.phase.GetComponent<Text>().text = "自动演示";
			}
			else
			{
				this.phase.GetComponent<Text>().text = "自由挑战";
			}
		}

		// Token: 0x0600A2F1 RID: 41713 RVA: 0x00215268 File Offset: 0x00213668
		[UIEventHandle("GameObject/returnBtn")]
		private void OpenSettingFrame()
		{
			this.settingFrame.CustomActive(true);
		}

		// Token: 0x0600A2F2 RID: 41714 RVA: 0x00215276 File Offset: 0x00213676
		public void SetEffectState(bool flag)
		{
			if (this.effect != null)
			{
				this.effect.CustomActive(flag);
			}
		}

		// Token: 0x0600A2F3 RID: 41715 RVA: 0x00215298 File Offset: 0x00213698
		[UIEventHandle("GameObject/returnTeachBtn")]
		private void ReturnTeach()
		{
			Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(1000, delegate
			{
				this.canClick = true;
			}, 0, 0, false);
			if (this.canClick)
			{
				this.canClick = false;
				Singleton<SkillComboControl>.instance.RestartTeachFight();
			}
		}

		// Token: 0x0600A2F4 RID: 41716 RVA: 0x002152E8 File Offset: 0x002136E8
		[UIEventHandle("GameObject/resetBtn")]
		private void ResetTrain()
		{
			Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(1000, delegate
			{
				this.canClick = true;
			}, 0, 0, false);
			if (this.canClick)
			{
				this.canClick = false;
				Singleton<SkillComboControl>.instance.RestartPracticeFight();
			}
		}

		// Token: 0x0600A2F5 RID: 41717 RVA: 0x00215335 File Offset: 0x00213735
		[UIEventHandle("settingPanel/cancel")]
		private void ReturnTrain()
		{
			this.settingFrame.CustomActive(false);
		}

		// Token: 0x0600A2F6 RID: 41718 RVA: 0x00215343 File Offset: 0x00213743
		[UIEventHandle("settingPanel/ok")]
		private void ReturnCaterlog()
		{
			BeUtility.ResetCamera();
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x0600A2F7 RID: 41719 RVA: 0x00215357 File Offset: 0x00213757
		[UIEventHandle("controlContainer/playbtn")]
		private void Play()
		{
			Time.timeScale = this.timeScale;
			this.pauseBtn.CustomActive(true);
			this.playbtn.CustomActive(false);
		}

		// Token: 0x0600A2F8 RID: 41720 RVA: 0x0021537C File Offset: 0x0021377C
		[UIEventHandle("controlContainer/accBtn")]
		private void Acc()
		{
			this.timeScale += 0.2f;
			this.timeScale = Mathf.Clamp(this.timeScale, 0f, 1f);
			this.SetTimeScale();
		}

		// Token: 0x0600A2F9 RID: 41721 RVA: 0x002153B1 File Offset: 0x002137B1
		[UIEventHandle("controlContainer/pauseBtn")]
		private void Pause()
		{
			Time.timeScale = 0f;
			this.pauseBtn.CustomActive(false);
			this.playbtn.CustomActive(true);
		}

		// Token: 0x0600A2FA RID: 41722 RVA: 0x002153D5 File Offset: 0x002137D5
		[UIEventHandle("controlContainer/backBtn")]
		private void Back()
		{
			this.timeScale -= 0.2f;
			this.timeScale = Mathf.Clamp(this.timeScale, 0f, 1f);
			this.SetTimeScale();
		}

		// Token: 0x0600A2FB RID: 41723 RVA: 0x0021540C File Offset: 0x0021380C
		private void SetTimeScale()
		{
			Time.timeScale = this.timeScale;
			if (this.rate != null)
			{
				this.rate.GetComponent<Text>().text = string.Format("{0}x", string.Format("{0:N1}", Time.timeScale));
			}
		}

		// Token: 0x0600A2FC RID: 41724 RVA: 0x00215463 File Offset: 0x00213863
		public void SetControlContainer(bool flag)
		{
			if (this.controlContainer != null)
			{
				this.controlContainer.CustomActive(flag);
			}
		}

		// Token: 0x0600A2FD RID: 41725 RVA: 0x00215482 File Offset: 0x00213882
		public void ResetTimeScale()
		{
			this.timeScale = 1f;
			this.SetTimeScale();
		}

		// Token: 0x04005ACE RID: 23246
		[UIObject("settingPanel")]
		private GameObject settingFrame;

		// Token: 0x04005ACF RID: 23247
		[UIObject("controlContainer")]
		private GameObject controlContainer;

		// Token: 0x04005AD0 RID: 23248
		[UIObject("controlContainer/playbtn")]
		private GameObject playbtn;

		// Token: 0x04005AD1 RID: 23249
		[UIObject("controlContainer/pauseBtn")]
		private GameObject pauseBtn;

		// Token: 0x04005AD2 RID: 23250
		[UIObject("controlContainer/rate")]
		private GameObject rate;

		// Token: 0x04005AD3 RID: 23251
		[UIObject("GameObject/resetBtn/EffUI_lianzhaoxitong_anniu")]
		private GameObject effect;

		// Token: 0x04005AD4 RID: 23252
		[UIObject("GameObject/custom_Image/phase")]
		private GameObject phase;

		// Token: 0x04005AD5 RID: 23253
		[UIObject("GameObject/resetBtn")]
		private GameObject resetBtn;

		// Token: 0x04005AD6 RID: 23254
		[UIObject("GameObject/returnBtn")]
		private GameObject returnBtn;

		// Token: 0x04005AD7 RID: 23255
		[UIObject("GameObject/returnTeachBtn")]
		private GameObject returnTeachBtn;

		// Token: 0x04005AD8 RID: 23256
		public bool hasPassed;

		// Token: 0x04005AD9 RID: 23257
		private bool canClick = true;

		// Token: 0x04005ADA RID: 23258
		private float timeScale = 1f;
	}
}
