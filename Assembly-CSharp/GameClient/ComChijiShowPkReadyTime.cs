using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001129 RID: 4393
	public class ComChijiShowPkReadyTime : MonoBehaviour
	{
		// Token: 0x0600A6E2 RID: 42722 RVA: 0x0022BF6B File Offset: 0x0022A36B
		private void Start()
		{
			this._BindUIEvent();
		}

		// Token: 0x0600A6E3 RID: 42723 RVA: 0x0022BF73 File Offset: 0x0022A373
		private void OnDestroy()
		{
			this._UnBindUIEvent();
			this._Clear();
		}

		// Token: 0x0600A6E4 RID: 42724 RVA: 0x0022BF81 File Offset: 0x0022A381
		private void _Clear()
		{
			this.bIsInReadyState = false;
			this.TimeIntrval = 0f;
			this.StartTime = 0U;
		}

		// Token: 0x0600A6E5 RID: 42725 RVA: 0x0022BF9C File Offset: 0x0022A39C
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiPkReady, new ClientEventSystem.UIEventHandler(this._OnChijiPkReady));
		}

		// Token: 0x0600A6E6 RID: 42726 RVA: 0x0022BFB9 File Offset: 0x0022A3B9
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiPkReady, new ClientEventSystem.UIEventHandler(this._OnChijiPkReady));
		}

		// Token: 0x0600A6E7 RID: 42727 RVA: 0x0022BFD6 File Offset: 0x0022A3D6
		private void _OnChijiPkReady(UIEvent iEvent)
		{
			this.StartTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			this.bIsInReadyState = true;
			this.root.CustomActive(true);
		}

		// Token: 0x0600A6E8 RID: 42728 RVA: 0x0022BFFC File Offset: 0x0022A3FC
		private void Update()
		{
			if (this.bIsInReadyState)
			{
				this.TimeIntrval += Time.deltaTime;
				if (this.TimeIntrval > 0.2f)
				{
					this.TimeIntrval = 0f;
					int num = (int)(DataManager<TimeManager>.GetInstance().GetServerTime() - this.StartTime);
					if (this.LastTime >= num)
					{
						if (this.ShowTime != null)
						{
							this.ShowTime.text = (this.LastTime - num).ToString();
						}
					}
					else
					{
						this.root.CustomActive(false);
						this.StartTime = 0U;
						this.bIsInReadyState = false;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiPkReadyFinish, null, null, null, null);
					}
				}
			}
		}

		// Token: 0x04005D6B RID: 23915
		public GameObject root;

		// Token: 0x04005D6C RID: 23916
		public Text ShowTime;

		// Token: 0x04005D6D RID: 23917
		public int LastTime = 3;

		// Token: 0x04005D6E RID: 23918
		private bool bIsInReadyState;

		// Token: 0x04005D6F RID: 23919
		private float TimeIntrval;

		// Token: 0x04005D70 RID: 23920
		private uint StartTime;
	}
}
