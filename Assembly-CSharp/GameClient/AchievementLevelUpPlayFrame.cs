using System;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013CA RID: 5066
	public class AchievementLevelUpPlayFrame : ClientFrame
	{
		// Token: 0x0600C495 RID: 50325 RVA: 0x002F35C4 File Offset: 0x002F19C4
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ActiveGroup/AchievementLevelUpPlayFrame";
		}

		// Token: 0x0600C496 RID: 50326 RVA: 0x002F35CB File Offset: 0x002F19CB
		public static void CommandOpen(object argv)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AchievementLevelUpPlayFrame>(FrameLayer.Middle, argv, string.Empty);
		}

		// Token: 0x0600C497 RID: 50327 RVA: 0x002F35E0 File Offset: 0x002F19E0
		protected override void _OnOpenFrame()
		{
			this._Data = (this.userData as AchievementLevelUpPlayFrameData);
			if (this._Data == null)
			{
				this._Data = new AchievementLevelUpPlayFrameData();
			}
			base._AddButton("Close", delegate
			{
				this.frameMgr.CloseFrame<AchievementLevelUpPlayFrame>(this, false);
			});
			this._LoadImage();
		}

		// Token: 0x0600C498 RID: 50328 RVA: 0x002F3634 File Offset: 0x002F1A34
		private void _LoadImage()
		{
			AchievementLevelInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AchievementLevelInfoTable>(this._Data.iId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this._Image, tableItem.Icon, true);
			}
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this._TextIcon, tableItem.TextIcon, true);
			}
		}

		// Token: 0x0600C499 RID: 50329 RVA: 0x002F3693 File Offset: 0x002F1A93
		protected override void _OnCloseFrame()
		{
			this._Data = null;
		}

		// Token: 0x04006FEF RID: 28655
		private AchievementLevelUpPlayFrameData _Data;

		// Token: 0x04006FF0 RID: 28656
		[UIControl("custom_Image/ICON", typeof(Image), 0)]
		private Image _Image;

		// Token: 0x04006FF1 RID: 28657
		[UIControl("custom_Image/TextIcon", typeof(Image), 0)]
		private Image _TextIcon;
	}
}
