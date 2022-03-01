using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200168C RID: 5772
	public class HorseGamblingMapZoneChampionComponent : MonoBehaviour, IDisposable
	{
		// Token: 0x0600E2D9 RID: 58073 RVA: 0x003A4554 File Offset: 0x003A2954
		public void Init(Transform shooterRoot)
		{
			UIPrefabWrapper component = this.mShooterGO.GetComponent<UIPrefabWrapper>();
			if (component == null)
			{
				return;
			}
			HorseGamblingMapShooter.EPosition intParam = (HorseGamblingMapShooter.EPosition)component.IntParam;
			this.mShooterGO = component.LoadUIPrefab(this.mShooterGO.transform);
			this.mShooter = this.mShooterGO.GetComponent<HorseGamblingMapShooter>();
			if (this.mShooter != null)
			{
				this.mShooter.Position = intParam;
				this.mShooter.transform.SetParent(shooterRoot);
				this.Reset();
			}
		}

		// Token: 0x0600E2DA RID: 58074 RVA: 0x003A45DD File Offset: 0x003A29DD
		public void ShowChampion(int shooterId, UnityAction<HorseGamblingMapShooter> onShooterClick)
		{
			this.mEffect.CustomActive(true);
			if (this.mShooter != null)
			{
				this.mShooter.ShowChampion(onShooterClick, shooterId);
			}
			this.mBattleEffect.CustomActive(false);
		}

		// Token: 0x0600E2DB RID: 58075 RVA: 0x003A4615 File Offset: 0x003A2A15
		public void Reset()
		{
			if (this.mShooter != null)
			{
				this.mShooter.Reset();
			}
			this.mEffect.CustomActive(false);
			this.mBattleEffect.CustomActive(false);
		}

		// Token: 0x0600E2DC RID: 58076 RVA: 0x003A464B File Offset: 0x003A2A4B
		public void Dispose()
		{
			if (this.mShooter != null)
			{
				this.mShooter.Dispose();
			}
		}

		// Token: 0x040087C5 RID: 34757
		[SerializeField]
		private GameObject mShooterGO;

		// Token: 0x040087C6 RID: 34758
		[SerializeField]
		private GameObject mEffect;

		// Token: 0x040087C7 RID: 34759
		[SerializeField]
		private GameObject mBattleEffect;

		// Token: 0x040087C8 RID: 34760
		private HorseGamblingMapShooter mShooter;
	}
}
