using System;
using Network;
using UnityEngine;

// Token: 0x020001D2 RID: 466
public class TestNetWork : MonoBehaviour
{
	// Token: 0x06000EEF RID: 3823 RVA: 0x0004C8CD File Offset: 0x0004ACCD
	private void Start()
	{
		NetManager.Instance().Init();
		NetManager.Instance().ConnectToAdmainServer("192.168.0.222", 843, 0U);
	}

	// Token: 0x06000EF0 RID: 3824 RVA: 0x0004C8EF File Offset: 0x0004ACEF
	private void Update()
	{
	}
}
