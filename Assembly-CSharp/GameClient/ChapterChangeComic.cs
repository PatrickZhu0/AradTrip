using System;

namespace GameClient
{
	// Token: 0x02001020 RID: 4128
	public class ChapterChangeComic : NewbieGuideFinalShow
	{
		// Token: 0x06009C6D RID: 40045 RVA: 0x001E9434 File Offset: 0x001E7834
		public override string GetPrefabPath()
		{
			return this.userData as string;
		}
	}
}
