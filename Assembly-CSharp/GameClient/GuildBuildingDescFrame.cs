using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015FA RID: 5626
	internal class GuildBuildingDescFrame : ClientFrame
	{
		// Token: 0x0600DC8A RID: 56458 RVA: 0x0037B957 File Offset: 0x00379D57
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/Guild/GuildBuildingDesc";
		}

		// Token: 0x0600DC8B RID: 56459 RVA: 0x0037B960 File Offset: 0x00379D60
		protected override void _OnOpenFrame()
		{
			this.m_objDescTemplate.SetActive(false);
			for (int i = 0; i < this.m_arrDescs.Length; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.m_objDescTemplate);
				gameObject.transform.SetParent(this.m_objDescRoot.transform, false);
				gameObject.SetActive(true);
				Utility.GetComponetInChild<Text>(gameObject, "Title").text = string.Format("{0}:", this.m_arrDescs[i].strName);
				Utility.GetComponetInChild<Text>(gameObject, "Text").text = this.m_arrDescs[i].strDesc;
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
		}

		// Token: 0x0600DC8C RID: 56460 RVA: 0x0037BA1B File Offset: 0x00379E1B
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildHasDismissed, new ClientEventSystem.UIEventHandler(this._OnGuildDismissed));
		}

		// Token: 0x0600DC8D RID: 56461 RVA: 0x0037BA38 File Offset: 0x00379E38
		private void _OnGuildDismissed(UIEvent a_event)
		{
			this.frameMgr.CloseFrame<GuildBuildingDescFrame>(this, false);
		}

		// Token: 0x0600DC8E RID: 56462 RVA: 0x0037BA47 File Offset: 0x00379E47
		[UIEventHandle("Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<GuildBuildingDescFrame>(this, false);
		}

		// Token: 0x0400821A RID: 33306
		[UIObject("Content/ScrollView/Viewport/Content/Desc")]
		private GameObject m_objDescTemplate;

		// Token: 0x0400821B RID: 33307
		[UIObject("Content/ScrollView/Viewport/Content")]
		private GameObject m_objDescRoot;

		// Token: 0x0400821C RID: 33308
		private GuildBuildingDescFrame.BuildingDesc[] m_arrDescs = new GuildBuildingDescFrame.BuildingDesc[]
		{
			new GuildBuildingDescFrame.BuildingDesc(TR.Value("guild_building_main"), TR.Value("guild_building_main_desc")),
			new GuildBuildingDescFrame.BuildingDesc(TR.Value("guild_building_welfare"), TR.Value("guild_building_welfare_desc")),
			new GuildBuildingDescFrame.BuildingDesc(TR.Value("guild_building_skill"), TR.Value("guild_building_skill_desc")),
			new GuildBuildingDescFrame.BuildingDesc(TR.Value("guild_building_shop"), TR.Value("guild_building_shop_desc")),
			new GuildBuildingDescFrame.BuildingDesc(TR.Value("guild_building_table"), TR.Value("guild_building_table_desc")),
			new GuildBuildingDescFrame.BuildingDesc(TR.Value("guild_building_dungeon"), TR.Value("guild_building_dungeon_desc")),
			new GuildBuildingDescFrame.BuildingDesc(TR.Value("guild_building_statue"), TR.Value("guild_building_statue_desc"))
		};

		// Token: 0x020015FB RID: 5627
		private class BuildingDesc
		{
			// Token: 0x0600DC8F RID: 56463 RVA: 0x0037BA56 File Offset: 0x00379E56
			public BuildingDesc(string a_strName, string a_strDesc)
			{
				this.strName = a_strName;
				this.strDesc = a_strDesc;
			}

			// Token: 0x0400821D RID: 33309
			public string strName;

			// Token: 0x0400821E RID: 33310
			public string strDesc;
		}
	}
}
