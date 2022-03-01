using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02004620 RID: 17952
	public class RaycastObject : MonoBehaviour
	{
		// Token: 0x060193B6 RID: 103350 RVA: 0x007FB4F7 File Offset: 0x007F98F7
		public void Initialize(int iID, RaycastObject.RaycastObjectType eRaycastObjectType, object data)
		{
			this.iParam0 = iID;
			this.eRaycastObjectType = eRaycastObjectType;
			this.data = data;
		}

		// Token: 0x170020B7 RID: 8375
		// (get) Token: 0x060193B7 RID: 103351 RVA: 0x007FB50E File Offset: 0x007F990E
		public object Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x170020B8 RID: 8376
		// (get) Token: 0x060193B8 RID: 103352 RVA: 0x007FB516 File Offset: 0x007F9916
		public RaycastObject.RaycastObjectType ObjectType
		{
			get
			{
				return this.eRaycastObjectType;
			}
		}

		// Token: 0x170020B9 RID: 8377
		// (get) Token: 0x060193B9 RID: 103353 RVA: 0x007FB51E File Offset: 0x007F991E
		public int ID
		{
			get
			{
				return this.iParam0;
			}
		}

		// Token: 0x04012171 RID: 74097
		private int iParam0;

		// Token: 0x04012172 RID: 74098
		private RaycastObject.RaycastObjectType eRaycastObjectType;

		// Token: 0x04012173 RID: 74099
		private object data;

		// Token: 0x02004621 RID: 17953
		public enum RaycastObjectType
		{
			// Token: 0x04012175 RID: 74101
			ROT_INVALID,
			// Token: 0x04012176 RID: 74102
			ROT_NPC,
			// Token: 0x04012177 RID: 74103
			ROT_TOWNPLAYER
		}
	}
}
