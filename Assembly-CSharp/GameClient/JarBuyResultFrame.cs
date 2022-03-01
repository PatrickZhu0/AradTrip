using System;
using System.Collections;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016ED RID: 5869
	internal class JarBuyResultFrame : ClientFrame
	{
		// Token: 0x0600E5EB RID: 58859 RVA: 0x003BEE05 File Offset: 0x003BD205
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Jar/JarBuyResult";
		}

		// Token: 0x0600E5EC RID: 58860 RVA: 0x003BEE0C File Offset: 0x003BD20C
		protected override void _OnOpenFrame()
		{
			if (!(this.userData is ShowItemsFrameData))
			{
				Logger.LogError("open ShowItemsFrame frame data is null");
				return;
			}
			this.m_togCanNotify.onValueChanged.RemoveAllListeners();
			this.m_togCanNotify.isOn = !DataManager<JarDataManager>.GetInstance().isNotify;
			this.m_togCanNotify.onValueChanged.AddListener(delegate(bool var)
			{
				DataManager<JarDataManager>.GetInstance().isNotify = !var;
			});
			this.m_coroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._SetupContent());
		}

		// Token: 0x0600E5ED RID: 58861 RVA: 0x003BEEA1 File Offset: 0x003BD2A1
		protected override void _OnCloseFrame()
		{
			if (this.m_coroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_coroutine);
				this.m_coroutine = null;
			}
		}

		// Token: 0x0600E5EE RID: 58862 RVA: 0x003BEEC8 File Offset: 0x003BD2C8
		private IEnumerator _SetupContent()
		{
			bool needThisFrame = true;
			ShowItemsFrameData data = this.userData as ShowItemsFrameData;
			if (data.data.eType == JarBonus.eType.EqrecoJar)
			{
				needThisFrame = false;
			}
			if (DataManager<JarDataManager>.GetInstance().isNotify && needThisFrame)
			{
				for (int i = 5; i > 0; i--)
				{
					if (data.buyInfo == null)
					{
						this.m_labContent.text = TR.Value("jar_use_result", data.items[0].item.Name, data.items[0].item.Count, i);
					}
					else if (data.items.Count > 0)
					{
						this.m_labContent.text = TR.Value("jar_buy_result", data.items[0].item.Name, data.items[0].item.Count, data.buyInfo.nBuyCount, i);
					}
					else
					{
						this.m_labContent.text = string.Empty;
					}
					yield return Yielders.GetWaitForSeconds(1f);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShowItemsFrame>(FrameLayer.Middle, this.userData, string.Empty);
				this.m_coroutine = null;
				this.frameMgr.CloseFrame<JarBuyResultFrame>(this, false);
			}
			else
			{
				this.frame.CustomActive(false);
				yield return Yielders.GetWaitForSeconds(0f);
				this._OnOkClicked();
			}
			yield break;
		}

		// Token: 0x0600E5EF RID: 58863 RVA: 0x003BEEE3 File Offset: 0x003BD2E3
		[UIEventHandle("OK")]
		private void _OnOkClicked()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShowItemsFrame>(FrameLayer.Middle, this.userData, string.Empty);
			this.frameMgr.CloseFrame<JarBuyResultFrame>(this, false);
		}

		// Token: 0x04008B3C RID: 35644
		[UIControl("Text", null, 0)]
		private Text m_labContent;

		// Token: 0x04008B3D RID: 35645
		[UIControl("CanNotify", null, 0)]
		private Toggle m_togCanNotify;

		// Token: 0x04008B3E RID: 35646
		private Coroutine m_coroutine;
	}
}
