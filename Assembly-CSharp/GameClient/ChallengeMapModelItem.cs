using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014D0 RID: 5328
	public class ChallengeMapModelItem : MonoBehaviour
	{
		// Token: 0x0600CE87 RID: 52871 RVA: 0x0032E61E File Offset: 0x0032CA1E
		private void Awake()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600CE88 RID: 52872 RVA: 0x0032E65D File Offset: 0x0032CA5D
		private void ResetData()
		{
			this._isSelected = false;
			this._challengeMapModelDataModel = null;
			this._onChallengeMapToggleClick = null;
		}

		// Token: 0x0600CE89 RID: 52873 RVA: 0x0032E674 File Offset: 0x0032CA74
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x0600CE8A RID: 52874 RVA: 0x0032E6A0 File Offset: 0x0032CAA0
		public void Init(ChallengeMapModelDataModel mapModelDataModel, OnChallengeMapToggleClick onChallengeMapToggleClick, bool isSelected = false)
		{
			this.ResetData();
			this._challengeMapModelDataModel = mapModelDataModel;
			if (this._challengeMapModelDataModel == null)
			{
				return;
			}
			this._onChallengeMapToggleClick = onChallengeMapToggleClick;
			this.UpdateTabImage();
			if (!string.IsNullOrEmpty(this._challengeMapModelDataModel.ToggleName))
			{
				if (this.normalTabNameLabel != null)
				{
					this.normalTabNameLabel.text = this._challengeMapModelDataModel.ToggleName;
				}
				if (this.selectedTabNameLabel != null)
				{
					this.selectedTabNameLabel.text = this._challengeMapModelDataModel.ToggleName;
				}
			}
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = false;
				this.toggle.isOn = true;
			}
		}

		// Token: 0x0600CE8B RID: 52875 RVA: 0x0032E768 File Offset: 0x0032CB68
		private void UpdateTabImage()
		{
			if (this._challengeMapModelDataModel.ModelType != DungeonModelTable.eType.TeamDuplicationModel)
			{
				return;
			}
			Color color;
			ColorUtility.TryParseHtmlString("#eadba0", ref color);
			if (this.selectedTabNameLabel != null)
			{
				this.selectedTabNameLabel.color = color;
			}
			if (this.toggleItemRtf != null)
			{
				this.toggleItemRtf.sizeDelta = new Vector2(314f, 116f);
			}
			if (this.normalTabImage != null)
			{
				this.normalTabImage.type = 0;
				ETCImageLoader.LoadSprite(ref this.normalTabImage, "UI/Image/Packed/p_UI_Tuanben_02.png:UI_Tuanben_Tab_01", true);
				RectTransform rectTransform = this.normalTabImage.transform as RectTransform;
				if (rectTransform != null)
				{
					rectTransform.sizeDelta = new Vector2(314f, 116f);
				}
			}
			if (this.selectedTabImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.selectedTabImage, "UI/Image/Packed/p_UI_Tuanben_02.png:UI_Tuanben_Tab_02", true);
				RectTransform rectTransform2 = this.selectedTabImage.transform as RectTransform;
				if (rectTransform2 != null)
				{
					rectTransform2.sizeDelta = new Vector3(314f, 116f);
				}
			}
		}

		// Token: 0x0600CE8C RID: 52876 RVA: 0x0032E898 File Offset: 0x0032CC98
		private void OnTabClicked(bool value)
		{
			if (this._challengeMapModelDataModel == null)
			{
				return;
			}
			if (this._isSelected == value)
			{
				return;
			}
			this._isSelected = value;
			if (value && this._onChallengeMapToggleClick != null)
			{
				this._onChallengeMapToggleClick(this._challengeMapModelDataModel.ModelType);
			}
		}

		// Token: 0x040078A0 RID: 30880
		private const string teamDuplicationNormalTabImagePath = "UI/Image/Packed/p_UI_Tuanben_02.png:UI_Tuanben_Tab_01";

		// Token: 0x040078A1 RID: 30881
		private const string teamDuplicationSelectedTabImagePath = "UI/Image/Packed/p_UI_Tuanben_02.png:UI_Tuanben_Tab_02";

		// Token: 0x040078A2 RID: 30882
		private bool _isSelected;

		// Token: 0x040078A3 RID: 30883
		private ChallengeMapModelDataModel _challengeMapModelDataModel;

		// Token: 0x040078A4 RID: 30884
		private OnChallengeMapToggleClick _onChallengeMapToggleClick;

		// Token: 0x040078A5 RID: 30885
		[Space(10f)]
		[Header("TabName")]
		[Space(10f)]
		[SerializeField]
		private Text normalTabNameLabel;

		// Token: 0x040078A6 RID: 30886
		[SerializeField]
		private Text selectedTabNameLabel;

		// Token: 0x040078A7 RID: 30887
		[Space(10f)]
		[Header("ToggleName")]
		[Space(10f)]
		[SerializeField]
		private Toggle toggle;

		// Token: 0x040078A8 RID: 30888
		[SerializeField]
		private RectTransform toggleItemRtf;

		// Token: 0x040078A9 RID: 30889
		[SerializeField]
		private Image normalTabImage;

		// Token: 0x040078AA RID: 30890
		[SerializeField]
		private Image selectedTabImage;
	}
}
