using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200168B RID: 5771
	public class HorseGamblingMapZone : MonoBehaviour, IDisposable
	{
		// Token: 0x17001C71 RID: 7281
		// (get) Token: 0x0600E2CA RID: 58058 RVA: 0x003A3DFF File Offset: 0x003A21FF
		public int Id
		{
			get
			{
				return this.mZoneId;
			}
		}

		// Token: 0x0600E2CB RID: 58059 RVA: 0x003A3E08 File Offset: 0x003A2208
		public void Init(UnityAction<HorseGamblingMapShooter> onShooterClick, Transform shooterRoot, Transform terrainRoot, Transform lineRoot, bool isShowShooter, bool isShowBattleEffect)
		{
			this.Dispose();
			this.mOnShooterClick = onShooterClick;
			for (int i = 0; i < this.mShooterGOList.Count; i++)
			{
				UIPrefabWrapper component = this.mShooterGOList[i].GetComponent<UIPrefabWrapper>();
				if (!(component == null))
				{
					HorseGamblingMapShooter.EPosition intParam = (HorseGamblingMapShooter.EPosition)component.IntParam;
					this.mShooterGOList[i] = component.LoadUIPrefab(this.mShooterGOList[i].transform);
					HorseGamblingMapShooter component2 = this.mShooterGOList[i].GetComponent<HorseGamblingMapShooter>();
					if (!(component2 == null))
					{
						component2.Position = intParam;
						this.mShooterList.Add(component2);
						component2.CustomActive(isShowShooter);
						component2.Init(this.mIsRight);
					}
				}
			}
			this.mTopWinLine.transform.SetParent(lineRoot);
			this.mBottomWinLine.transform.SetParent(lineRoot);
			this.mImageTerrain.transform.SetParent(terrainRoot);
			this.mBattleAnim.transform.SetParent(shooterRoot);
			this.mBattleAnim.CustomActive(isShowBattleEffect);
			if (isShowBattleEffect)
			{
				this.mBattleAnim.Stop();
			}
		}

		// Token: 0x0600E2CC RID: 58060 RVA: 0x003A3F3A File Offset: 0x003A233A
		public void HideBattleAnimation()
		{
			this.mBattleAnim.CustomActive(false);
		}

		// Token: 0x0600E2CD RID: 58061 RVA: 0x003A3F48 File Offset: 0x003A2348
		public void SetData(IHorseGamblingMapZoneModel model, bool isShowShooter, bool isAutoSelect = false, bool isShowWinLine = false)
		{
			if (model == null)
			{
				return;
			}
			this.mModel = model;
			if (!string.IsNullOrEmpty(model.TerrainPath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageTerrain, model.TerrainPath, true);
			}
			this.Phase = model.Phase;
			if (model.Shooters != null)
			{
				Dictionary<int, HorseGamblingMapShooterModel>.ValueCollection.Enumerator enumerator = model.Shooters.Values.GetEnumerator();
				enumerator.MoveNext();
				for (int i = 0; i < this.mShooterList.Count; i++)
				{
					HorseGamblingMapShooter horseGamblingMapShooter = this.mShooterList[i];
					if (i < model.Shooters.Count)
					{
						if (enumerator.Current != null)
						{
							horseGamblingMapShooter.SetData(enumerator.Current, this.mOnShooterClick, this.Phase == 1, this.mIsRight);
							if (isAutoSelect)
							{
								this.mOnShooterClick.Invoke(horseGamblingMapShooter);
								isAutoSelect = false;
							}
							horseGamblingMapShooter.CustomActive(isShowShooter);
							if (isShowWinLine && enumerator.Current.BattleState == EHorseGamblingBattleResult.Win)
							{
								this.ShowWinLine(horseGamblingMapShooter);
							}
							enumerator.MoveNext();
						}
					}
					else
					{
						horseGamblingMapShooter.Reset();
					}
				}
			}
		}

		// Token: 0x0600E2CE RID: 58062 RVA: 0x003A4074 File Offset: 0x003A2474
		public void ShowUnBattle(IHorseGamblingMapZoneModel model)
		{
			Dictionary<int, HorseGamblingMapShooterModel>.ValueCollection.Enumerator enumerator = model.Shooters.Values.GetEnumerator();
			this.Phase = model.Phase;
			enumerator.MoveNext();
			for (int i = 0; i < this.mShooterList.Count; i++)
			{
				HorseGamblingMapShooter horseGamblingMapShooter = this.mShooterList[i];
				if (model.Shooters != null && i < model.Shooters.Count)
				{
					if (enumerator.Current != null)
					{
						horseGamblingMapShooter.CustomActive(true);
						horseGamblingMapShooter.ShowUnBattleData(enumerator.Current, this.mOnShooterClick);
						enumerator.MoveNext();
					}
				}
				else
				{
					horseGamblingMapShooter.Reset();
				}
			}
			this.mBattleAnim.CustomActive(true);
			this.mBattleAnim.Play();
		}

		// Token: 0x0600E2CF RID: 58063 RVA: 0x003A413C File Offset: 0x003A253C
		private void ShowWinLine(HorseGamblingMapShooter shooter)
		{
			HorseGamblingMapShooter.EPosition position = shooter.Position;
			if (position != HorseGamblingMapShooter.EPosition.None)
			{
				if (position != HorseGamblingMapShooter.EPosition.Top)
				{
					if (position == HorseGamblingMapShooter.EPosition.Bottom)
					{
						this.mTopWinLine.CustomActive(false);
						this.mBottomWinLine.CustomActive(true);
					}
				}
				else
				{
					this.mTopWinLine.CustomActive(true);
					this.mBottomWinLine.CustomActive(false);
				}
			}
			else
			{
				this.mTopWinLine.CustomActive(false);
				this.mBottomWinLine.CustomActive(false);
			}
		}

		// Token: 0x0600E2D0 RID: 58064 RVA: 0x003A41C0 File Offset: 0x003A25C0
		public void ShowBattleResult(IHorseGamblingMapZoneModel model)
		{
			this.mBattleAnim.CustomActive(false);
			for (int i = 0; i < this.mShooterList.Count; i++)
			{
				HorseGamblingMapShooter horseGamblingMapShooter = this.mShooterList[i];
				if (model.Shooters != null && model.Shooters.ContainsKey(this.mShooterList[i].Id))
				{
					if (model.Shooters[this.mShooterList[i].Id].BattleState == EHorseGamblingBattleResult.Win)
					{
						this.ShowWinLine(this.mShooterList[i]);
					}
					horseGamblingMapShooter.CustomActive(true);
					horseGamblingMapShooter.ShowBattleResult(model.Shooters[this.mShooterList[i].Id]);
				}
			}
		}

		// Token: 0x0600E2D1 RID: 58065 RVA: 0x003A4290 File Offset: 0x003A2690
		public void RandomShooter()
		{
			for (int i = 0; i < this.mShooterList.Count; i++)
			{
				this.mShooterList[i].RandomShooter();
			}
		}

		// Token: 0x0600E2D2 RID: 58066 RVA: 0x003A42CC File Offset: 0x003A26CC
		public void StopRandomShooter()
		{
			for (int i = 0; i < this.mShooterList.Count; i++)
			{
				this.mShooterList[i].StopRamdom();
			}
		}

		// Token: 0x0600E2D3 RID: 58067 RVA: 0x003A4308 File Offset: 0x003A2708
		public void UpdateData(IHorseGamblingMapZoneModel model)
		{
			if (model == null || model.Shooters == null || model.Shooters.Count <= 0)
			{
				return;
			}
			this.Phase = model.Phase;
			this.mZoneId = model.Id;
			for (int i = 0; i < this.mShooterList.Count; i++)
			{
				if (model.Shooters.ContainsKey(this.mShooterList[i].Id))
				{
					this.mShooterList[i].CustomActive(true);
					this.mShooterList[i].SetData(model.Shooters[this.mShooterList[i].Id], this.mOnShooterClick, this.mIsRight, false);
				}
				else
				{
					this.mShooterList[i].CustomActive(false);
				}
			}
		}

		// Token: 0x0600E2D4 RID: 58068 RVA: 0x003A43F0 File Offset: 0x003A27F0
		public void UpdateOdds(IHorseGamblingMapZoneModel model)
		{
			for (int i = 0; i < this.mShooterList.Count; i++)
			{
				if (model.Shooters.ContainsKey(this.mShooterList[i].Id))
				{
					this.mShooterList[i].UpdateOdds(model.Shooters[this.mShooterList[i].Id]);
				}
			}
		}

		// Token: 0x0600E2D5 RID: 58069 RVA: 0x003A4468 File Offset: 0x003A2868
		public void Reset(bool isShowBattleAnim)
		{
			for (int i = 0; i < this.mShooterList.Count; i++)
			{
				this.mShooterList[i].Reset();
				if (this.Phase != 1)
				{
					this.mShooterList[i].CustomActive(false);
				}
			}
			this.mBattleAnim.CustomActive(isShowBattleAnim);
			if (isShowBattleAnim)
			{
				this.mBattleAnim.Stop();
			}
			this.mTopWinLine.CustomActive(false);
			this.mBottomWinLine.CustomActive(false);
		}

		// Token: 0x0600E2D6 RID: 58070 RVA: 0x003A44F8 File Offset: 0x003A28F8
		public void Dispose()
		{
			if (this.mShooterList != null)
			{
				for (int i = 0; i < this.mShooterList.Count; i++)
				{
					this.mShooterList[i].Dispose();
				}
				this.mShooterList.Clear();
			}
		}

		// Token: 0x0600E2D7 RID: 58071 RVA: 0x003A4548 File Offset: 0x003A2948
		public void PlayBattleAnimation()
		{
		}

		// Token: 0x040087B9 RID: 34745
		[SerializeField]
		private List<GameObject> mShooterGOList;

		// Token: 0x040087BA RID: 34746
		[SerializeField]
		private int mZoneId;

		// Token: 0x040087BB RID: 34747
		[SerializeField]
		private Image mImageTerrain;

		// Token: 0x040087BC RID: 34748
		[SerializeField]
		private bool mIsRight;

		// Token: 0x040087BD RID: 34749
		[SerializeField]
		private GameObject mTopWinLine;

		// Token: 0x040087BE RID: 34750
		[SerializeField]
		private GameObject mBottomWinLine;

		// Token: 0x040087BF RID: 34751
		[SerializeField]
		private HorseGamblingBattleAnim mBattleAnim;

		// Token: 0x040087C0 RID: 34752
		public int Phase;

		// Token: 0x040087C1 RID: 34753
		private readonly List<HorseGamblingMapShooter> mShooterList = new List<HorseGamblingMapShooter>();

		// Token: 0x040087C2 RID: 34754
		private UnityAction<HorseGamblingMapShooter> mOnShooterClick;

		// Token: 0x040087C3 RID: 34755
		private IHorseGamblingMapZoneModel mModel;

		// Token: 0x040087C4 RID: 34756
		[SerializeField]
		private int mFinalZoneId = 7;
	}
}
