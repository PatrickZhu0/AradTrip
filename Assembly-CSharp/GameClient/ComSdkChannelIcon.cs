using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001758 RID: 5976
	public class ComSdkChannelIcon : MonoBehaviour
	{
		// Token: 0x0600EBE1 RID: 60385 RVA: 0x003EDDCF File Offset: 0x003EC1CF
		private void Start()
		{
			if (this.m_IcomGo)
			{
				this.m_IcomGo.CustomActive(this.bShow);
			}
		}

		// Token: 0x0600EBE2 RID: 60386 RVA: 0x003EDDF2 File Offset: 0x003EC1F2
		private void OnDestroy()
		{
			this.bShow = false;
		}

		// Token: 0x0600EBE3 RID: 60387 RVA: 0x003EDDFC File Offset: 0x003EC1FC
		public void UpdateShow()
		{
			if (SDKInterface.instance.IsOppoPlatform())
			{
				if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_OPPO_COMMUNITY))
				{
					return;
				}
			}
			else if (SDKInterface.instance.IsVivoPlatForm() && DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_VIVO_COMMUNITY))
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<SDKClientResTable>();
			if (table == null)
			{
				Logger.LogError("[ComSdkChannelIcon] - can not find SDKClientResTable");
				return;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				SDKClientResTable sdkclientResTable = keyValuePair.Value as SDKClientResTable;
				if (sdkclientResTable != null)
				{
					if (sdkclientResTable.SDK.ToString().Equals(SDKInterface.instance.GetCurrentSDKChannel().ToString()) && sdkclientResTable.Open)
					{
						this.bShow = true;
						if (this.m_IcomGo)
						{
							this.m_IcomGo.CustomActive(this.bShow);
						}
						if (this.m_IcomImg)
						{
							ETCImageLoader.LoadSprite(ref this.m_IcomImg, sdkclientResTable.IconImgPath, true);
						}
						if (this.m_IcomText)
						{
							this.m_IcomText.text = sdkclientResTable.IconDesc;
						}
						break;
					}
				}
			}
		}

		// Token: 0x04008F2E RID: 36654
		private bool bShow;

		// Token: 0x04008F2F RID: 36655
		[SerializeField]
		private Image m_IcomImg;

		// Token: 0x04008F30 RID: 36656
		[SerializeField]
		private Text m_IcomText;

		// Token: 0x04008F31 RID: 36657
		[SerializeField]
		private GameObject m_IcomGo;
	}
}
