using System;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x02004732 RID: 18226
	public class TMUnityGameObjectComponent : MonoBehaviour
	{
		// Token: 0x17002243 RID: 8771
		// (get) Token: 0x0601A2BF RID: 107199 RVA: 0x008217A9 File Offset: 0x0081FBA9
		// (set) Token: 0x0601A2C0 RID: 107200 RVA: 0x008217B1 File Offset: 0x0081FBB1
		public Vector3 DefaultScale
		{
			get
			{
				return this.m_DefaultScale;
			}
			internal set
			{
				this.m_DefaultScale = value;
			}
		}

		// Token: 0x17002244 RID: 8772
		// (get) Token: 0x0601A2C1 RID: 107201 RVA: 0x008217BA File Offset: 0x0081FBBA
		// (set) Token: 0x0601A2C2 RID: 107202 RVA: 0x008217C2 File Offset: 0x0081FBC2
		public bool IsInit
		{
			get
			{
				return this.m_IsInit;
			}
			internal set
			{
				this.m_IsInit = value;
			}
		}

		// Token: 0x17002245 RID: 8773
		// (get) Token: 0x0601A2C3 RID: 107203 RVA: 0x008217CB File Offset: 0x0081FBCB
		// (set) Token: 0x0601A2C4 RID: 107204 RVA: 0x008217D3 File Offset: 0x0081FBD3
		public string PrefabKey
		{
			get
			{
				return this.m_PrefabKey;
			}
			internal set
			{
				this.m_PrefabKey = value;
			}
		}

		// Token: 0x17002246 RID: 8774
		// (get) Token: 0x0601A2C5 RID: 107205 RVA: 0x008217DC File Offset: 0x0081FBDC
		// (set) Token: 0x0601A2C6 RID: 107206 RVA: 0x008217E4 File Offset: 0x0081FBE4
		public bool IsOriginInVisible
		{
			get
			{
				return this.m_IsOriginInVisible;
			}
			internal set
			{
				this.m_IsOriginInVisible = value;
			}
		}

		// Token: 0x17002247 RID: 8775
		// (get) Token: 0x0601A2C7 RID: 107207 RVA: 0x008217ED File Offset: 0x0081FBED
		// (set) Token: 0x0601A2C8 RID: 107208 RVA: 0x008217F5 File Offset: 0x0081FBF5
		public bool IsRecycled
		{
			get
			{
				return this.m_IsRecycled;
			}
			internal set
			{
				this.m_IsRecycled = value;
			}
		}

		// Token: 0x04012630 RID: 75312
		[SerializeField]
		private Vector3 m_DefaultScale;

		// Token: 0x04012631 RID: 75313
		[SerializeField]
		private bool m_IsInit;

		// Token: 0x04012632 RID: 75314
		[SerializeField]
		private string m_PrefabKey;

		// Token: 0x04012633 RID: 75315
		[SerializeField]
		private bool m_IsOriginInVisible;

		// Token: 0x04012634 RID: 75316
		[NonSerialized]
		private bool m_IsRecycled;
	}
}
