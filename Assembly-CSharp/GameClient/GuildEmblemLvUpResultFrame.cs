using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001620 RID: 5664
	public class GuildEmblemLvUpResultFrame : ClientFrame
	{
		// Token: 0x0600DE4E RID: 56910 RVA: 0x00387E3C File Offset: 0x0038623C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildEmblemLvUpResult";
		}

		// Token: 0x0600DE4F RID: 56911 RVA: 0x00387E43 File Offset: 0x00386243
		protected override void _OnOpenFrame()
		{
			this.fCreateTime = Time.realtimeSinceStartup;
			this.BindUIEvent();
			this.UpdateEmblemInfo();
		}

		// Token: 0x0600DE50 RID: 56912 RVA: 0x00387E5C File Offset: 0x0038625C
		protected override void _OnCloseFrame()
		{
			this.fCreateTime = 0f;
			this.UnBindUIEvent();
		}

		// Token: 0x0600DE51 RID: 56913 RVA: 0x00387E70 File Offset: 0x00386270
		protected override void _bindExUI()
		{
			this.close = this.mBind.GetCom<Button>("close");
			this.close.SafeAddOnClickListener(delegate
			{
				if (Time.realtimeSinceStartup - this.fCreateTime < 2f)
				{
					return;
				}
				this.frameMgr.CloseFrame<GuildEmblemLvUpResultFrame>(this, false);
			});
			this.icon = this.mBind.GetCom<Image>("icon");
			this.name = this.mBind.GetCom<Text>("name");
			this.Title = this.mBind.GetCom<Text>("Title");
			this.emblemName = this.mBind.GetCom<Image>("emblemName");
			this.emblemStageLv = this.mBind.GetCom<Image>("emblemStageLv");
			this.emblemLvNow = this.mBind.GetCom<GuildEmblemAttrItem>("emblemLvNow");
		}

		// Token: 0x0600DE52 RID: 56914 RVA: 0x00387F2E File Offset: 0x0038632E
		protected override void _unbindExUI()
		{
			this.close = null;
			this.icon = null;
			this.name = null;
			this.Title = null;
			this.emblemName = null;
			this.emblemStageLv = null;
			this.emblemLvNow = null;
		}

		// Token: 0x0600DE53 RID: 56915 RVA: 0x00387F61 File Offset: 0x00386361
		private void BindUIEvent()
		{
		}

		// Token: 0x0600DE54 RID: 56916 RVA: 0x00387F63 File Offset: 0x00386363
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600DE55 RID: 56917 RVA: 0x00387F65 File Offset: 0x00386365
		private string GetColorString(string text, string color)
		{
			return TR.Value("common_color_text", "#" + color, text);
		}

		// Token: 0x0600DE56 RID: 56918 RVA: 0x00387F80 File Offset: 0x00386380
		private void UpdateEmblemInfo()
		{
			int emblemLv = DataManager<GuildDataManager>.GetInstance().GetEmblemLv();
			GuildEmblemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildEmblemTable>(emblemLv, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.icon.SafeSetImage(tableItem.iconPath, false);
			this.name.SafeSetText(tableItem.name);
			if (emblemLv == 1)
			{
				this.Title.SafeSetText(TR.Value("emblem_active_success"));
			}
			else
			{
				this.Title.SafeSetText(TR.Value("emblem_lv_up_success"));
			}
			this.emblemName.SafeSetImage(tableItem.namePath, false);
			if (this.emblemName != null)
			{
				this.emblemName.SetNativeSize();
			}
			this.emblemStageLv.SafeSetImage(GuildEmblemAttrItem.GetStageLvPath(emblemLv), false);
			if (this.emblemStageLv != null)
			{
				this.emblemStageLv.SetNativeSize();
			}
			if (this.emblemLvNow != null)
			{
				this.emblemLvNow.SetUp(DataManager<GuildDataManager>.GetInstance().GetEmblemLv());
			}
		}

		// Token: 0x040083AD RID: 33709
		private Button close;

		// Token: 0x040083AE RID: 33710
		private Image icon;

		// Token: 0x040083AF RID: 33711
		private Text name;

		// Token: 0x040083B0 RID: 33712
		private Text Title;

		// Token: 0x040083B1 RID: 33713
		private Image emblemName;

		// Token: 0x040083B2 RID: 33714
		private Image emblemStageLv;

		// Token: 0x040083B3 RID: 33715
		private GuildEmblemAttrItem emblemLvNow;

		// Token: 0x040083B4 RID: 33716
		private float fCreateTime;

		// Token: 0x040083B5 RID: 33717
		private const float fDelayTime = 2f;
	}
}
