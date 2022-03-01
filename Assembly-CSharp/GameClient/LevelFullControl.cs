using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200007B RID: 123
	public class LevelFullControl : MonoBehaviour
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00014133 File Offset: 0x00012533
		// (set) Token: 0x060002A1 RID: 673 RVA: 0x0001413B File Offset: 0x0001253B
		public int BindActiveID
		{
			get
			{
				return this.iBindActiveID;
			}
			set
			{
				this.iBindActiveID = value;
				this._Update();
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0001414A File Offset: 0x0001254A
		private void Start()
		{
			this._Register();
			this._Update();
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00014158 File Offset: 0x00012558
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			this._Update();
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00014160 File Offset: 0x00012560
		public void _Update()
		{
			int playerMaxLv = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			bool flag = (int)DataManager<PlayerBaseData>.GetInstance().Level >= playerMaxLv;
			if (flag)
			{
				ActiveManager.ActivityData childActiveData = DataManager<ActiveManager>.GetInstance().GetChildActiveData(this.iBindActiveID);
				if (childActiveData == null || childActiveData.activeItem.IsWorkWithFullLevel != 0 || childActiveData.status > 2)
				{
					flag = false;
				}
			}
			this.goTarget.CustomActive(flag);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x000141D0 File Offset: 0x000125D0
		private void OnDestroy()
		{
			this._UnRegister();
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x000141D8 File Offset: 0x000125D8
		private void _Register()
		{
			this._UnRegister();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00014206 File Offset: 0x00012606
		private void _UnRegister()
		{
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
		}

		// Token: 0x0400028B RID: 651
		public GameObject goTarget;

		// Token: 0x0400028C RID: 652
		public int iBindActiveID;

		// Token: 0x0400028D RID: 653
		private bool bMainActive;
	}
}
