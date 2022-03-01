using System;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x02004729 RID: 18217
	public abstract class TMModuleComponent : MonoBehaviour
	{
		// Token: 0x0601A294 RID: 107156 RVA: 0x00820B96 File Offset: 0x0081EF96
		protected virtual void Awake()
		{
			TMModuleComponentManager.RegisterComponent(this);
		}
	}
}
