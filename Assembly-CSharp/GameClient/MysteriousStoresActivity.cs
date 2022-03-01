using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001859 RID: 6233
	public class MysteriousStoresActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F49F RID: 62623 RVA: 0x00420989 File Offset: 0x0041ED89
		public override void Show(Transform root)
		{
			base.Show(root);
			this.mCheckComponent.Checked(this);
		}

		// Token: 0x0600F4A0 RID: 62624 RVA: 0x0042099E File Offset: 0x0041ED9E
		public override bool IsHaveRedPoint()
		{
			return !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F4A1 RID: 62625 RVA: 0x004209AE File Offset: 0x0041EDAE
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/MysteriousStoresActivity";
		}
	}
}
