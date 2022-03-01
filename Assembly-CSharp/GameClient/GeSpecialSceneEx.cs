using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000D91 RID: 3473
	public class GeSpecialSceneEx
	{
		// Token: 0x06008CD1 RID: 36049 RVA: 0x001A2191 File Offset: 0x001A0591
		public void Init(GameObject go)
		{
			this.m_SceneObject = go;
			this.OnInit();
		}

		// Token: 0x06008CD2 RID: 36050 RVA: 0x001A21A0 File Offset: 0x001A05A0
		public void Update(int delta)
		{
			this.OnUpdate(delta);
		}

		// Token: 0x06008CD3 RID: 36051 RVA: 0x001A21A9 File Offset: 0x001A05A9
		protected virtual void OnInit()
		{
		}

		// Token: 0x06008CD4 RID: 36052 RVA: 0x001A21AB File Offset: 0x001A05AB
		protected virtual void OnUpdate(int delta)
		{
		}

		// Token: 0x06008CD5 RID: 36053 RVA: 0x001A21AD File Offset: 0x001A05AD
		protected virtual void OnDeInit()
		{
		}

		// Token: 0x040045A9 RID: 17833
		protected GameObject m_SceneObject;
	}
}
