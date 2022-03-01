using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020019EB RID: 6635
	internal class FriendSecondMenu
	{
		// Token: 0x0601043B RID: 66619 RVA: 0x0048E7AB File Offset: 0x0048CBAB
		public FriendSecondMenu(ulong uid, string name, ushort lv, byte occu)
		{
			this.m_friendSecPrefab = Singleton<AssetLoader>.instance.LoadResAsGameObject("UI/Prefabs/FriendSecondInfo", true, 0U);
			this.m_friendSecPrefab.SetActive(true);
		}

		// Token: 0x0400A4B7 RID: 42167
		public GameObject m_friendSecPrefab;

		// Token: 0x0400A4B8 RID: 42168
		public ulong m_uid;

		// Token: 0x0400A4B9 RID: 42169
		public string m_name;

		// Token: 0x0400A4BA RID: 42170
		public ushort m_level;

		// Token: 0x0400A4BB RID: 42171
		public byte m_occu;
	}
}
