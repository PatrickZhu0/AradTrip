using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010CB RID: 4299
	public class DungeonNorthFinishFrame : ClientFrame, IDungeonFinish
	{
		// Token: 0x0600A28E RID: 41614 RVA: 0x00212EAA File Offset: 0x002112AA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Finish/DungeonNorthFinish";
		}

		// Token: 0x0600A28F RID: 41615 RVA: 0x00212EB4 File Offset: 0x002112B4
		protected override void _bindExUI()
		{
			this.mGotListRoot = this.mBind.GetGameObject("GotListRoot");
			this.mGotListRoot2 = this.mBind.GetGameObject("GotListRoot2");
			this.mComItems = this.mBind.GetCom<ComItemList>("ComItems");
			this.mComItems2 = this.mBind.GetCom<ComItemList>("ComItems2");
			this.mBack = this.mBind.GetCom<Button>("Back");
			this.mBack.onClick.AddListener(new UnityAction(this._onBackButtonClick));
			this.mExpBar = this.mBind.GetCom<ComExpBar>("ExpBar");
			this.mExpValue = this.mBind.GetCom<Text>("ExpValue");
			this.mName = this.mBind.GetCom<Text>("Name");
		}

		// Token: 0x0600A290 RID: 41616 RVA: 0x00212F90 File Offset: 0x00211390
		protected override void _unbindExUI()
		{
			this.mGotListRoot = null;
			this.mGotListRoot2 = null;
			this.mComItems = null;
			this.mComItems2 = null;
			this.mBack.onClick.RemoveListener(new UnityAction(this._onBackButtonClick));
			this.mBack = null;
			this.mExpBar = null;
			this.mExpValue = null;
			this.mName = null;
		}

		// Token: 0x0600A291 RID: 41617 RVA: 0x00212FF1 File Offset: 0x002113F1
		private void _onBackButtonClick()
		{
			this._onClose();
		}

		// Token: 0x0600A292 RID: 41618 RVA: 0x00212FF9 File Offset: 0x002113F9
		private void _onExpUpdate(UIEvent ui)
		{
			this._setExp(DataManager<PlayerBaseData>.GetInstance().Exp, false);
		}

		// Token: 0x0600A293 RID: 41619 RVA: 0x0021300C File Offset: 0x0021140C
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._onExpUpdate));
			this._setExp(DataManager<BattleDataManager>.GetInstance().originExp, true);
		}

		// Token: 0x0600A294 RID: 41620 RVA: 0x00213037 File Offset: 0x00211437
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ExpChanged, new ClientEventSystem.UIEventHandler(this._onExpUpdate));
		}

		// Token: 0x0600A295 RID: 41621 RVA: 0x00213051 File Offset: 0x00211451
		private void _setExp(ulong val, bool force)
		{
			if (null != this.mExpBar)
			{
				this.mExpBar.SetExp(val, force, (ulong exp) => Singleton<TableManager>.instance.GetCurRoleExp(exp));
			}
		}

		// Token: 0x0600A296 RID: 41622 RVA: 0x0021308E File Offset: 0x0021148E
		public void SetName(string name)
		{
			this.mName.text = name;
		}

		// Token: 0x0600A297 RID: 41623 RVA: 0x0021309C File Offset: 0x0021149C
		public void SetBestTime(int time)
		{
		}

		// Token: 0x0600A298 RID: 41624 RVA: 0x0021309E File Offset: 0x0021149E
		public void SetCurrentTime(int time)
		{
		}

		// Token: 0x0600A299 RID: 41625 RVA: 0x002130A0 File Offset: 0x002114A0
		public void SetDiff(int diff)
		{
		}

		// Token: 0x0600A29A RID: 41626 RVA: 0x002130A4 File Offset: 0x002114A4
		public void SetDrops(ComItemList.Items[] items)
		{
			List<ComItemList.Items> list = new List<ComItemList.Items>(items);
			this.mComItems.SetItems(list.ToArray());
			if (ChapterNorthFrame.sMuti > 1)
			{
				for (int i = 0; i < list.Count; i++)
				{
					list[i].count *= (uint)(ChapterNorthFrame.sMuti - 1);
				}
				this.mComItems2.SetItems(list.ToArray());
				this.mGotListRoot2.SetActive(true);
			}
		}

		// Token: 0x0600A29B RID: 41627 RVA: 0x00213122 File Offset: 0x00211522
		public void SetExp(ulong exp)
		{
			this.mExpValue.text = exp.ToString();
			this._onExpUpdate(null);
		}

		// Token: 0x0600A29C RID: 41628 RVA: 0x00213143 File Offset: 0x00211543
		public void SetFinish(bool isFinish)
		{
		}

		// Token: 0x0600A29D RID: 41629 RVA: 0x00213145 File Offset: 0x00211545
		public void SetLevel(int lvl)
		{
		}

		// Token: 0x0600A29E RID: 41630 RVA: 0x00213147 File Offset: 0x00211547
		private void _onClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<DungeonNorthFinishFrame>(this, false);
			Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
		}

		// Token: 0x04005AA9 RID: 23209
		private GameObject mGotListRoot;

		// Token: 0x04005AAA RID: 23210
		private GameObject mGotListRoot2;

		// Token: 0x04005AAB RID: 23211
		private ComItemList mComItems;

		// Token: 0x04005AAC RID: 23212
		private ComItemList mComItems2;

		// Token: 0x04005AAD RID: 23213
		private Button mBack;

		// Token: 0x04005AAE RID: 23214
		private ComExpBar mExpBar;

		// Token: 0x04005AAF RID: 23215
		private Text mExpValue;

		// Token: 0x04005AB0 RID: 23216
		private Text mName;
	}
}
