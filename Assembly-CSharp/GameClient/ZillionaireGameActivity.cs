using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001934 RID: 6452
	public class ZillionaireGameActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600FAEF RID: 64239 RVA: 0x0044C011 File Offset: 0x0044A411
		public override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600FAF0 RID: 64240 RVA: 0x0044C026 File Offset: 0x0044A426
		public override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600FAF1 RID: 64241 RVA: 0x0044C036 File Offset: 0x0044A436
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/ZillionaireGame/ZillionaireGameActivity";
		}
	}
}
