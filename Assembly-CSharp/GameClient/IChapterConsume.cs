using System;

namespace GameClient
{
	// Token: 0x02000EA0 RID: 3744
	public interface IChapterConsume
	{
		// Token: 0x060093D9 RID: 37849
		void SetFatigueConsume(int value, bool isLimit, int dungonID);

		// Token: 0x060093DA RID: 37850
		void SetHellConsume(string name, int value, string spritePath, bool ishell);
	}
}
