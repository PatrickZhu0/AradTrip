using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x020048FE RID: 18686
	[Serializable]
	public class ECamera
	{
		// Token: 0x0601ADDB RID: 110043 RVA: 0x00843C44 File Offset: 0x00842044
		public ECamera(Camera cam, bool gui)
		{
			this.camera = cam;
			this.guiCamera = gui;
		}

		// Token: 0x04012B5A RID: 76634
		public Camera camera;

		// Token: 0x04012B5B RID: 76635
		public bool guiCamera;
	}
}
