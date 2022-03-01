using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004238 RID: 16952
	public class ShowCountDownComponent : MonoBehaviour
	{
		// Token: 0x0601775F RID: 96095 RVA: 0x0073576C File Offset: 0x00733B6C
		public void Awake()
		{
			this.mBind = base.GetComponent<ComCommonBind>();
			this.mCountDownText = this.mBind.GetCom<Text>("CountDownText");
		}

		// Token: 0x06017760 RID: 96096 RVA: 0x00735790 File Offset: 0x00733B90
		public void InitData(int time)
		{
			this.m_Count_Time = time;
			this.mCountDownText.text = this.m_Count_Time.ToString();
			this.m_Coroutine_Count = base.StartCoroutine(this.CountDown());
		}

		// Token: 0x06017761 RID: 96097 RVA: 0x007357C8 File Offset: 0x00733BC8
		protected IEnumerator CountDown()
		{
			bool isDone = false;
			while (!isDone)
			{
				yield return Yielders.GetWaitForSeconds(1f);
				this.m_Count_Time--;
				this.mCountDownText.text = this.m_Count_Time.ToString();
				if (this.m_Count_Time <= 0)
				{
					isDone = true;
				}
			}
			Singleton<CGameObjectPool>.instance.RecycleGameObject(base.gameObject);
			yield break;
		}

		// Token: 0x06017762 RID: 96098 RVA: 0x007357E3 File Offset: 0x00733BE3
		private void OnDestroy()
		{
			this.mCountDownText = null;
			if (this.m_Coroutine_Count != null)
			{
				base.StopCoroutine(this.m_Coroutine_Count);
			}
		}

		// Token: 0x04010D7B RID: 68987
		public ComCommonBind mBind;

		// Token: 0x04010D7C RID: 68988
		protected int m_Count_Time;

		// Token: 0x04010D7D RID: 68989
		protected Coroutine m_Coroutine_Count;

		// Token: 0x04010D7E RID: 68990
		private Text mCountDownText;
	}
}
