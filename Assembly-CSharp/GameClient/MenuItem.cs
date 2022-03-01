using System;

namespace GameClient
{
	// Token: 0x020013F6 RID: 5110
	internal class MenuItem
	{
		// Token: 0x0400718E RID: 29070
		public string name;

		// Token: 0x0400718F RID: 29071
		public MenuItem.MenuItemCallBack callback;

		// Token: 0x04007190 RID: 29072
		public bool bEnableDefault = true;

		// Token: 0x020013F7 RID: 5111
		// (Invoke) Token: 0x0600C61B RID: 50715
		public delegate void MenuItemCallBack();
	}
}
