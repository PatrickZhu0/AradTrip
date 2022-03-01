using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200143D RID: 5181
	public class ArtifactJarToggleView : MonoBehaviour
	{
		// Token: 0x0600C91A RID: 51482 RVA: 0x0030E954 File Offset: 0x0030CD54
		public void Init(ArtifactJarBuy jarData)
		{
			this.mCurJarData = jarData;
			JarBonus jarBonusData = Singleton<TableManager>.GetInstance().GetTableItem<JarBonus>((int)jarData.jarId, string.Empty, string.Empty);
			if (jarBonusData != null)
			{
				this.mName.text = jarBonusData.Name;
			}
			if (this.canPreviewJar())
			{
				this.mGrayBtn.CustomActive(false);
			}
			else
			{
				this.mGrayBtn.CustomActive(true);
			}
			this.mGrayBtn.onClick.RemoveAllListeners();
			this.mGrayBtn.onClick.AddListener(delegate()
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("artifact_jar_toggle_tips", jarBonusData.Filter[0]), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			});
			this.mToggle.onValueChanged.RemoveAllListeners();
			this.mToggle.onValueChanged.AddListener(delegate(bool flag)
			{
				if (flag)
				{
					if (this.canPreviewJar())
					{
						this.mSelect.CustomActive(true);
						if (this.mCallback != null)
						{
							this.mCallback(jarData);
						}
					}
					else
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("artifact_jar_toggle_tips", jarBonusData.Filter[0]), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
				}
				else
				{
					this.mSelect.CustomActive(false);
				}
			});
		}

		// Token: 0x0600C91B RID: 51483 RVA: 0x0030EA47 File Offset: 0x0030CE47
		public void Dispose()
		{
		}

		// Token: 0x0600C91C RID: 51484 RVA: 0x0030EA49 File Offset: 0x0030CE49
		public void SetCallback(ArtifactJarToggleView.Callback mCallback)
		{
			if (mCallback != null)
			{
				this.mCallback = mCallback;
			}
		}

		// Token: 0x0600C91D RID: 51485 RVA: 0x0030EA58 File Offset: 0x0030CE58
		public void SetToggleIsOn(bool flag)
		{
			if (flag)
			{
				if (this.mToggle.isOn)
				{
					this.mToggle.isOn = false;
				}
				this.mToggle.isOn = true;
			}
			else
			{
				this.mToggle.isOn = false;
			}
		}

		// Token: 0x0600C91E RID: 51486 RVA: 0x0030EAA4 File Offset: 0x0030CEA4
		public bool canPreviewJar()
		{
			JarBonus tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JarBonus>((int)this.mCurJarData.jarId, string.Empty, string.Empty);
			return tableItem != null && tableItem.Filter[0] <= (int)DataManager<PlayerBaseData>.GetInstance().Level;
		}

		// Token: 0x04007410 RID: 29712
		[SerializeField]
		private Toggle mToggle;

		// Token: 0x04007411 RID: 29713
		[SerializeField]
		private Text mName;

		// Token: 0x04007412 RID: 29714
		[SerializeField]
		private GameObject mSelect;

		// Token: 0x04007413 RID: 29715
		[SerializeField]
		private Button mGrayBtn;

		// Token: 0x04007414 RID: 29716
		private ArtifactJarToggleView.Callback mCallback;

		// Token: 0x04007415 RID: 29717
		private ArtifactJarBuy mCurJarData;

		// Token: 0x04007416 RID: 29718
		private List<ArtifactJarBuy> allJarData = new List<ArtifactJarBuy>();

		// Token: 0x0200143E RID: 5182
		// (Invoke) Token: 0x0600C920 RID: 51488
		public delegate void Callback(ArtifactJarBuy jarData);
	}
}
