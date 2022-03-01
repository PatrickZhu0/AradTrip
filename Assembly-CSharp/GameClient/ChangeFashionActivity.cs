using System;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200182C RID: 6188
	public sealed class ChangeFashionActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F397 RID: 62359 RVA: 0x0041D083 File Offset: 0x0041B483
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ChangeFashionActivity";
		}

		// Token: 0x0600F398 RID: 62360 RVA: 0x0041D08C File Offset: 0x0041B48C
		public override void Show(Transform root)
		{
			base.Show(root);
			ChangeFashionActivityView changeFashionActivityView = this.mView as ChangeFashionActivityView;
			if (changeFashionActivityView != null)
			{
				changeFashionActivityView.SetGoFashionCallBack(new ChangeFashionActivityView.GoFashionMergeCallBack(this.GoToFashionMergeFrame));
				changeFashionActivityView.SetLookUpCallBack(new ChangeFashionActivityView.LookUpCallBack(this.LookUpFashionMode));
			}
		}

		// Token: 0x0600F399 RID: 62361 RVA: 0x0041D0DC File Offset: 0x0041B4DC
		private void GoToFashionMergeFrame()
		{
			if (this.mDataModel == null)
			{
				return;
			}
			bool flag = this.mDataModel.State == OpActivityState.OAS_PREPARE;
			if (flag)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("activity_havenot_open_tips"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				FashionMergeNewFrame.OpenLinkFrame(string.Format("1|1|{0}|{1}|{2}", 10000, (int)DataManager<FashionMergeManager>.GetInstance().FashionPart, 0));
			}
		}

		// Token: 0x0600F39A RID: 62362 RVA: 0x0041D14E File Offset: 0x0041B54E
		private void LookUpFashionMode(int id)
		{
			this._ShowAvartar(id);
		}

		// Token: 0x0600F39B RID: 62363 RVA: 0x0041D158 File Offset: 0x0041B558
		private void _ShowAvartar(int id)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PlayerTryOnFrame>(null))
			{
				PlayerTryOnFrame playerTryOnFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PlayerTryOnFrame)) as PlayerTryOnFrame;
				if (playerTryOnFrame != null)
				{
					playerTryOnFrame.Reset(id);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, id, string.Empty);
			}
		}
	}
}
