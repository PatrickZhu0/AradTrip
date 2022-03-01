using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F5C RID: 3932
	internal class GuildContributionConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098B7 RID: 39095 RVA: 0x001D5A89 File Offset: 0x001D3E89
		public GuildContributionConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.PlayerDataGuildUpdated
			};
		}

		// Token: 0x060098B8 RID: 39096 RVA: 0x001D5AA3 File Offset: 0x001D3EA3
		public void OnChange()
		{
			base.cnt = (ulong)((long)DataManager<PlayerBaseData>.GetInstance().guildContribution);
		}

		// Token: 0x060098B9 RID: 39097 RVA: 0x001D5AB8 File Offset: 0x001D3EB8
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GuildContri), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
