using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200153C RID: 5436
	public class ChapterTempTipsFrame : ClientFrame
	{
		// Token: 0x0600D429 RID: 54313 RVA: 0x0034E2CC File Offset: 0x0034C6CC
		public static void Show(int id)
		{
			ChapterTempTipsFrame chapterTempTipsFrame = Singleton<ClientSystemManager>.instance.OpenFrame<ChapterTempTipsFrame>(FrameLayer.Middle, null, string.Empty) as ChapterTempTipsFrame;
			if (chapterTempTipsFrame != null)
			{
				chapterTempTipsFrame.SetID(id);
			}
		}

		// Token: 0x0600D42A RID: 54314 RVA: 0x0034E300 File Offset: 0x0034C700
		protected override void _bindExUI()
		{
			this.mIcon = this.mBind.GetCom<Image>("icon");
			this.mName = this.mBind.GetCom<Text>("name");
			this.mDesc = this.mBind.GetCom<Text>("desc");
			this.mColor = this.mBind.GetCom<Text>("color");
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mIconBg = this.mBind.GetCom<Image>("iconBg");
			this.mBg = this.mBind.GetCom<Image>("bg");
			this.mMaybeDropTxt = this.mBind.GetCom<Text>("MaybeDropTxt");
		}

		// Token: 0x0600D42B RID: 54315 RVA: 0x0034E3DC File Offset: 0x0034C7DC
		protected override void _unbindExUI()
		{
			this.mIcon = null;
			this.mName = null;
			this.mDesc = null;
			this.mColor = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mIconBg = null;
			this.mBg = null;
			this.mMaybeDropTxt = null;
		}

		// Token: 0x0600D42C RID: 54316 RVA: 0x0034E43D File Offset: 0x0034C83D
		private void _onCloseButtonClick()
		{
			this._onClose();
		}

		// Token: 0x0600D42D RID: 54317 RVA: 0x0034E445 File Offset: 0x0034C845
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/Normal/ChapterCollectTipsContent";
		}

		// Token: 0x0600D42E RID: 54318 RVA: 0x0034E44C File Offset: 0x0034C84C
		protected override void _OnOpenFrame()
		{
		}

		// Token: 0x0600D42F RID: 54319 RVA: 0x0034E44E File Offset: 0x0034C84E
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600D430 RID: 54320 RVA: 0x0034E450 File Offset: 0x0034C850
		public void SetID(int id)
		{
			ItemCollectionTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemCollectionTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				string empty = string.Empty;
				string text = string.Empty;
				List<int> list = new List<int>(tableItem.Color);
				list.Sort();
				ItemData.QualityInfo qualityInfo = null;
				ItemData.QualityInfo qualityInfo2 = null;
				if (list.Count > 0)
				{
					try
					{
						qualityInfo = ItemData.GetQualityInfo((ItemTable.eColor)list[list.Count - 1], tableItem.Color2);
						qualityInfo2 = ItemData.GetQualityInfo((ItemTable.eColor)list[0], tableItem.Color2);
					}
					catch
					{
						qualityInfo = ItemData.GetQualityInfo(ItemTable.eColor.WHITE, false, false);
						qualityInfo2 = ItemData.GetQualityInfo(ItemTable.eColor.WHITE, false, false);
					}
					string background = qualityInfo.Background;
					if (qualityInfo == qualityInfo2 || qualityInfo.Quality == qualityInfo2.Quality)
					{
						text = string.Format("{0}", this._getColorString(qualityInfo.ColStr, qualityInfo.Desc));
					}
					else
					{
						text = string.Format("{0}-{1}", this._getColorString(qualityInfo2.ColStr, qualityInfo2.Desc), this._getColorString(qualityInfo.ColStr, qualityInfo.Desc));
					}
					ETCImageLoader.LoadSprite(ref this.mIconBg, background, true);
					if (qualityInfo.Quality == ItemTable.eColor.WHITE)
					{
						this.mBg.color = Color.clear;
					}
					else
					{
						ETCImageLoader.LoadSprite(ref this.mBg, qualityInfo.TitleBG2, true);
					}
				}
				ETCImageLoader.LoadSprite(ref this.mIcon, tableItem.Icon, true);
				this.mColor.text = text;
				this.mName.text = tableItem.Name;
				this.mDesc.text = tableItem.Desc;
			}
			if (this.mTunBenBuffid == id)
			{
				this.mMaybeDropTxt.SafeSetText(string.Empty);
			}
		}

		// Token: 0x0600D431 RID: 54321 RVA: 0x0034E628 File Offset: 0x0034CA28
		private string _getColorString(string color, string name)
		{
			return string.Format("<color={0}>{1}</color>", color, name);
		}

		// Token: 0x0600D432 RID: 54322 RVA: 0x0034E636 File Offset: 0x0034CA36
		private void _onClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<ChapterTempTipsFrame>(this, false);
		}

		// Token: 0x04007C7A RID: 31866
		private int mTunBenBuffid = 55003;

		// Token: 0x04007C7B RID: 31867
		private Image mIcon;

		// Token: 0x04007C7C RID: 31868
		private Text mName;

		// Token: 0x04007C7D RID: 31869
		private Text mDesc;

		// Token: 0x04007C7E RID: 31870
		private Text mColor;

		// Token: 0x04007C7F RID: 31871
		private Button mClose;

		// Token: 0x04007C80 RID: 31872
		private Image mIconBg;

		// Token: 0x04007C81 RID: 31873
		private Image mBg;

		// Token: 0x04007C82 RID: 31874
		private Text mMaybeDropTxt;
	}
}
