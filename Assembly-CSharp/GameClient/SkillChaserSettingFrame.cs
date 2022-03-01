using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AAA RID: 6826
	public class SkillChaserSettingFrame : ClientFrame
	{
		// Token: 0x06010C12 RID: 68626 RVA: 0x004C132C File Offset: 0x004BF72C
		protected override void _bindExUI()
		{
			this.mPVPToggle5 = this.mBind.GetCom<Toggle>("PVPToggle5");
			this.mPVPToggle4 = this.mBind.GetCom<Toggle>("PVPToggle4");
			this.mPVPToggle3 = this.mBind.GetCom<Toggle>("PVPToggle3");
			this.mPVPToggle2 = this.mBind.GetCom<Toggle>("PVPToggle2");
			this.mPVPToggle1 = this.mBind.GetCom<Toggle>("PVPToggle1");
			this.mPVEToggle5 = this.mBind.GetCom<Toggle>("PVEToggle5");
			this.mPVEToggle4 = this.mBind.GetCom<Toggle>("PVEToggle4");
			this.mPVEToggle3 = this.mBind.GetCom<Toggle>("PVEToggle3");
			this.mPVEToggle2 = this.mBind.GetCom<Toggle>("PVEToggle2");
			this.mPVEToggle1 = this.mBind.GetCom<Toggle>("PVEToggle1");
			this.mSureBtn = this.mBind.GetCom<Button>("sureBtn");
			this.mSureBtn.onClick.AddListener(new UnityAction(this._onSureBtnButtonClick));
			this.mCloseBtn = this.mBind.GetCom<Button>("closeBtn");
			this.mCloseBtn.onClick.AddListener(new UnityAction(this._onCloseBtnButtonClick));
		}

		// Token: 0x06010C13 RID: 68627 RVA: 0x004C147C File Offset: 0x004BF87C
		protected override void _unbindExUI()
		{
			this.mPVPToggle5 = null;
			this.mPVPToggle4 = null;
			this.mPVPToggle3 = null;
			this.mPVPToggle2 = null;
			this.mPVPToggle1 = null;
			this.mPVEToggle5 = null;
			this.mPVEToggle4 = null;
			this.mPVEToggle3 = null;
			this.mPVEToggle2 = null;
			this.mPVEToggle1 = null;
			this.mSureBtn.onClick.RemoveListener(new UnityAction(this._onSureBtnButtonClick));
			this.mSureBtn = null;
			this.mCloseBtn.onClick.RemoveListener(new UnityAction(this._onCloseBtnButtonClick));
			this.mCloseBtn = null;
		}

		// Token: 0x06010C14 RID: 68628 RVA: 0x004C1515 File Offset: 0x004BF915
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Skill/SkillChaserSettingFrame";
		}

		// Token: 0x06010C15 RID: 68629 RVA: 0x004C151C File Offset: 0x004BF91C
		protected override void _OnOpenFrame()
		{
			this._InitUI();
		}

		// Token: 0x06010C16 RID: 68630 RVA: 0x004C1524 File Offset: 0x004BF924
		private void _InitUI()
		{
			bool[] array = this.DecodeToArray(Singleton<SettingManager>.GetInstance().GetChaserSetting("STR_CHASER_PVE"));
			this.mPVEToggle1.isOn = array[0];
			this.mPVEToggle2.isOn = array[1];
			this.mPVEToggle3.isOn = array[2];
			this.mPVEToggle4.isOn = array[3];
			this.mPVEToggle5.isOn = array[4];
			array = this.DecodeToArray(Singleton<SettingManager>.GetInstance().GetChaserSetting("STR_CHASER_PVP"));
			this.mPVPToggle1.isOn = array[0];
			this.mPVPToggle2.isOn = array[1];
			this.mPVPToggle3.isOn = array[2];
			this.mPVPToggle4.isOn = array[3];
			this.mPVPToggle5.isOn = array[4];
		}

		// Token: 0x06010C17 RID: 68631 RVA: 0x004C15EC File Offset: 0x004BF9EC
		private void _onSureBtnButtonClick()
		{
			bool[] array = new bool[]
			{
				this.mPVEToggle1.isOn,
				this.mPVEToggle2.isOn,
				this.mPVEToggle3.isOn,
				this.mPVEToggle4.isOn,
				this.mPVEToggle5.isOn
			};
			Singleton<SettingManager>.GetInstance().SetChaserSetting("STR_CHASER_PVE", this.EncodeToInt(array));
			array[0] = this.mPVPToggle1.isOn;
			array[1] = this.mPVPToggle2.isOn;
			array[2] = this.mPVPToggle3.isOn;
			array[3] = this.mPVPToggle4.isOn;
			array[4] = this.mPVPToggle5.isOn;
			Singleton<SettingManager>.GetInstance().SetChaserSetting("STR_CHASER_PVP", this.EncodeToInt(array));
			this.frameMgr.CloseFrame<SkillChaserSettingFrame>(this, false);
		}

		// Token: 0x06010C18 RID: 68632 RVA: 0x004C16C8 File Offset: 0x004BFAC8
		private int EncodeToInt(bool[] value)
		{
			int num = 0;
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i])
				{
					num |= 1 << i;
				}
			}
			return 31 - num;
		}

		// Token: 0x06010C19 RID: 68633 RVA: 0x004C1700 File Offset: 0x004BFB00
		private bool[] DecodeToArray(int code)
		{
			bool[] array = new bool[5];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ((code & 1 << i) == 0);
			}
			return array;
		}

		// Token: 0x06010C1A RID: 68634 RVA: 0x004C1737 File Offset: 0x004BFB37
		private void _onCloseBtnButtonClick()
		{
			this.frameMgr.CloseFrame<SkillChaserSettingFrame>(this, false);
		}

		// Token: 0x0400AB6B RID: 43883
		private Toggle mPVPToggle5;

		// Token: 0x0400AB6C RID: 43884
		private Toggle mPVPToggle4;

		// Token: 0x0400AB6D RID: 43885
		private Toggle mPVPToggle3;

		// Token: 0x0400AB6E RID: 43886
		private Toggle mPVPToggle2;

		// Token: 0x0400AB6F RID: 43887
		private Toggle mPVPToggle1;

		// Token: 0x0400AB70 RID: 43888
		private Toggle mPVEToggle5;

		// Token: 0x0400AB71 RID: 43889
		private Toggle mPVEToggle4;

		// Token: 0x0400AB72 RID: 43890
		private Toggle mPVEToggle3;

		// Token: 0x0400AB73 RID: 43891
		private Toggle mPVEToggle2;

		// Token: 0x0400AB74 RID: 43892
		private Toggle mPVEToggle1;

		// Token: 0x0400AB75 RID: 43893
		private Button mSureBtn;

		// Token: 0x0400AB76 RID: 43894
		private Button mCloseBtn;
	}
}
