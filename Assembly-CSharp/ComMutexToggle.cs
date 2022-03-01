using System;
using UnityEngine;

// Token: 0x02000046 RID: 70
public class ComMutexToggle : MonoBehaviour
{
	// Token: 0x060001AD RID: 429 RVA: 0x0000F349 File Offset: 0x0000D749
	private void Start()
	{
	}

	// Token: 0x060001AE RID: 430 RVA: 0x0000F34B File Offset: 0x0000D74B
	private void Update()
	{
	}

	// Token: 0x060001AF RID: 431 RVA: 0x0000F34D File Offset: 0x0000D74D
	public void SetMutexActive(bool b)
	{
		this.one.SetActive(b);
		this.two.SetActive(!b);
	}

	// Token: 0x04000199 RID: 409
	public GameObject one;

	// Token: 0x0400019A RID: 410
	public GameObject two;
}
