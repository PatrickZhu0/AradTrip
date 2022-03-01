using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001023 RID: 4131
	public class NewbieGuideImageTips : ClientFrame
	{
		// Token: 0x06009C79 RID: 40057 RVA: 0x001E9449 File Offset: 0x001E7849
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/NewbieGuide/NewbieGuideImageTips";
		}

		// Token: 0x06009C7A RID: 40058 RVA: 0x001E9450 File Offset: 0x001E7850
		protected override void _OnOpenFrame()
		{
			if (null != this.mBind)
			{
				Button com = this.mBind.GetCom<Button>("button");
				if (null != com)
				{
					com.onClick.AddListener(delegate()
					{
						Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuideImageTips>(this, false);
					});
				}
			}
		}

		// Token: 0x06009C7B RID: 40059 RVA: 0x001E94A4 File Offset: 0x001E78A4
		protected override void _OnCloseFrame()
		{
			if (null != this.mBind)
			{
				Button com = this.mBind.GetCom<Button>("button");
				if (null != com)
				{
					com.onClick.RemoveAllListeners();
				}
			}
		}

		// Token: 0x06009C7C RID: 40060 RVA: 0x001E94EC File Offset: 0x001E78EC
		public void SetSprite(string path)
		{
			if (null != this.mBind)
			{
				Image com = this.mBind.GetCom<Image>("image");
				ETCImageLoader.LoadSprite(ref com, path, true);
				if (null != com.sprite)
				{
					com.SetNativeSize();
				}
			}
		}
	}
}
