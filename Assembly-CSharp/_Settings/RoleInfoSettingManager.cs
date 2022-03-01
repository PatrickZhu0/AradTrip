using System;
using GameClient;

namespace _Settings
{
	// Token: 0x02001A28 RID: 6696
	public class RoleInfoSettingManager : DataManager<RoleInfoSettingManager>
	{
		// Token: 0x17001D46 RID: 7494
		// (get) Token: 0x06010703 RID: 67331 RVA: 0x004A0206 File Offset: 0x0049E606
		// (set) Token: 0x06010704 RID: 67332 RVA: 0x004A020E File Offset: 0x0049E60E
		public RoleInfoSettingsData ActorShowData
		{
			get
			{
				return this.actorShowData;
			}
			set
			{
				this.actorShowData = value;
			}
		}

		// Token: 0x06010705 RID: 67333 RVA: 0x004A0217 File Offset: 0x0049E617
		public override void Initialize()
		{
		}

		// Token: 0x06010706 RID: 67334 RVA: 0x004A0219 File Offset: 0x0049E619
		public override void Clear()
		{
			this.actorShowData = null;
		}

		// Token: 0x0400A723 RID: 42787
		private RoleInfoSettingsData actorShowData;
	}
}
