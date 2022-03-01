using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015B9 RID: 5561
	internal class SarahResultFrame : ClientFrame
	{
		// Token: 0x0600D95A RID: 55642 RVA: 0x0036764C File Offset: 0x00365A4C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/SarahResultFrame";
		}

		// Token: 0x0600D95B RID: 55643 RVA: 0x00367654 File Offset: 0x00365A54
		protected override void _OnOpenFrame()
		{
			this.m_goParent = Utility.FindChild(this.frame, "ok/common_black/ItemParent");
			this.m_kComItem = base.CreateComItem(this.m_goParent);
			MonoSingleton<AudioManager>.instance.PlaySound(12);
			this.SetData(this.userData as SarahResultFrame.SarahResultFrameData);
		}

		// Token: 0x0600D95C RID: 55644 RVA: 0x003676A7 File Offset: 0x00365AA7
		protected override void _OnCloseFrame()
		{
			this.m_kData = null;
		}

		// Token: 0x0600D95D RID: 55645 RVA: 0x003676B0 File Offset: 0x00365AB0
		[UIEventHandle("OK")]
		private void OnFunction()
		{
			this.frameMgr.CloseFrame<SarahResultFrame>(this, false);
		}

		// Token: 0x0600D95E RID: 55646 RVA: 0x003676BF File Offset: 0x00365ABF
		private void _OnClickCard(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600D95F RID: 55647 RVA: 0x003676D1 File Offset: 0x00365AD1
		private void _OnClickItem(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x0600D960 RID: 55648 RVA: 0x003676E4 File Offset: 0x00365AE4
		public void SetData(SarahResultFrame.SarahResultFrameData data)
		{
			this.m_kData = data;
			this.m_kComItem.Setup(this.m_kData.itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			if (this.m_kData.itemData != null)
			{
				this.m_kName.text = this.m_kData.itemData.GetColorName(string.Empty, false);
			}
			else
			{
				this.m_kName.text = "none";
			}
			if (this.m_kData.bMerge)
			{
				this.m_kAttributes.text = DataManager<BeadCardManager>.GetInstance().GetCondition(data.itemData.TableID);
				Text kAttributes = this.m_kAttributes;
				kAttributes.text += "\n";
				Text kAttributes2 = this.m_kAttributes;
				kAttributes2.text += DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(data.itemData.TableID, false);
				this.m_kTitle.text = TR.Value("magic_merge_ok");
			}
			else
			{
				int iID = 0;
				int num = 0;
				for (int i = 0; i < this.m_kData.itemData.PreciousBeadMountHole.Length; i++)
				{
					if (this.m_kData.itemData.PreciousBeadMountHole[i] != null)
					{
						if (this.m_kData.itemData.PreciousBeadMountHole[i].index == this.m_kData.iHoleIndex)
						{
							iID = this.m_kData.itemData.PreciousBeadMountHole[i].preciousBeadId;
							num = this.m_kData.itemData.PreciousBeadMountHole[i].randomBuffId;
						}
					}
				}
				this.m_kAttributes.text = string.Format("<color={0}>宝珠属性:</color>", "#0FCF6Aff");
				if (num > 0)
				{
					Text kAttributes3 = this.m_kAttributes;
					kAttributes3.text = kAttributes3.text + DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(iID, false) + "\n" + string.Format("附加属性:{0}", DataManager<BeadCardManager>.GetInstance().GetBeadRandomAttributesDesc(num));
				}
				else
				{
					Text kAttributes4 = this.m_kAttributes;
					kAttributes4.text += DataManager<BeadCardManager>.GetInstance().GetAttributesDesc(iID, false);
				}
				if (data.iTitleType == 1)
				{
					this.m_kTitle.text = TR.Value("inlay_ok");
				}
				else
				{
					this.m_kTitle.text = TR.Value("Replacement_Success");
				}
			}
		}

		// Token: 0x0600D961 RID: 55649 RVA: 0x0036794F File Offset: 0x00365D4F
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}

		// Token: 0x04007FD3 RID: 32723
		private SarahResultFrame.SarahResultFrameData m_kData;

		// Token: 0x04007FD4 RID: 32724
		private GameObject m_goParent;

		// Token: 0x04007FD5 RID: 32725
		private ComItem m_kComItem;

		// Token: 0x04007FD6 RID: 32726
		[UIControl("ok/common_black/itemname", null, 0)]
		private Text m_kName;

		// Token: 0x04007FD7 RID: 32727
		[UIControl("ScrollView/Viewport/content/Text", null, 0)]
		private Text m_kAttributes;

		// Token: 0x04007FD8 RID: 32728
		[UIControl("ok/common_black/Title", null, 0)]
		private Text m_kTitle;

		// Token: 0x020015BA RID: 5562
		public class SarahResultFrameData
		{
			// Token: 0x04007FD9 RID: 32729
			public bool bMerge;

			// Token: 0x04007FDA RID: 32730
			public ItemData itemData;

			// Token: 0x04007FDB RID: 32731
			public int iCardTableID;

			// Token: 0x04007FDC RID: 32732
			public int iHoleIndex;

			// Token: 0x04007FDD RID: 32733
			public int iTitleType;
		}
	}
}
