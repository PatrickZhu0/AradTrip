using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200192C RID: 6444
	public class BlessingCardExchangeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600FAAA RID: 64170 RVA: 0x0044A906 File Offset: 0x00448D06
		public override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600FAAB RID: 64171 RVA: 0x0044A91B File Offset: 0x00448D1B
		public override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600FAAC RID: 64172 RVA: 0x0044A92B File Offset: 0x00448D2B
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/ZillionaireGame/BlessingCardExchangeActivity";
		}
	}
}
