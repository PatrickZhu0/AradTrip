using System;
using System.Collections;
using UnityEngine;

// Token: 0x020045E2 RID: 17890
public class AntActiveChild : MonoBehaviour
{
	// Token: 0x060192A0 RID: 103072 RVA: 0x007F4B9B File Offset: 0x007F2F9B
	private void Start()
	{
		this.Active();
	}

	// Token: 0x060192A1 RID: 103073 RVA: 0x007F4BA4 File Offset: 0x007F2FA4
	private void Active()
	{
		IEnumerator enumerator = base.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				transform.gameObject.SetActive(this.bActiveChild);
			}
		}
		finally
		{
			IDisposable disposable;
			if ((disposable = (enumerator as IDisposable)) != null)
			{
				disposable.Dispose();
			}
		}
	}

	// Token: 0x060192A2 RID: 103074 RVA: 0x007F4C14 File Offset: 0x007F3014
	public void AntActive()
	{
		this.bActiveChild = !this.bActiveChild;
		this.Active();
		if (this.onStatusChanged != null)
		{
			this.onStatusChanged(this, this.bActiveChild);
		}
	}

	// Token: 0x04012064 RID: 73828
	public bool bActiveChild;

	// Token: 0x04012065 RID: 73829
	public AntActiveChild.DelegateOnStatusChanged onStatusChanged;

	// Token: 0x020045E3 RID: 17891
	// (Invoke) Token: 0x060192A4 RID: 103076
	public delegate void DelegateOnStatusChanged(AntActiveChild child, bool bActive);
}
