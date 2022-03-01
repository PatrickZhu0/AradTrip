using System;
using UnityEngine;

// Token: 0x020000CF RID: 207
public class AsyncLoadTask
{
	// Token: 0x06000450 RID: 1104 RVA: 0x0001E8F4 File Offset: 0x0001CCF4
	public AsyncLoadTask(string _tag, uint _handle, string _path, uint _waithandle, PostLoadGameObject _load, bool _isPooled)
	{
		this.tag = _tag;
		this.handle = _handle;
		this.waithandle = _waithandle;
		this.load = _load;
		this.isPooled = _isPooled;
		this.status = eAsyncLoadTaskStatus.onNone;
		this.path = _path;
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x06000451 RID: 1105 RVA: 0x0001E930 File Offset: 0x0001CD30
	// (set) Token: 0x06000452 RID: 1106 RVA: 0x0001E938 File Offset: 0x0001CD38
	public uint handle { get; private set; }

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x06000453 RID: 1107 RVA: 0x0001E941 File Offset: 0x0001CD41
	// (set) Token: 0x06000454 RID: 1108 RVA: 0x0001E949 File Offset: 0x0001CD49
	public uint waithandle { get; private set; }

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x06000455 RID: 1109 RVA: 0x0001E952 File Offset: 0x0001CD52
	// (set) Token: 0x06000456 RID: 1110 RVA: 0x0001E95A File Offset: 0x0001CD5A
	public bool isPooled { get; private set; }

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x06000457 RID: 1111 RVA: 0x0001E963 File Offset: 0x0001CD63
	// (set) Token: 0x06000458 RID: 1112 RVA: 0x0001E96B File Offset: 0x0001CD6B
	public string tag { get; private set; }

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x06000459 RID: 1113 RVA: 0x0001E974 File Offset: 0x0001CD74
	// (set) Token: 0x0600045A RID: 1114 RVA: 0x0001E97C File Offset: 0x0001CD7C
	public PostLoadGameObject load { get; private set; }

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x0600045B RID: 1115 RVA: 0x0001E985 File Offset: 0x0001CD85
	// (set) Token: 0x0600045C RID: 1116 RVA: 0x0001E98D File Offset: 0x0001CD8D
	public eAsyncLoadTaskStatus status { get; set; }

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x0600045D RID: 1117 RVA: 0x0001E996 File Offset: 0x0001CD96
	public bool isFinish
	{
		get
		{
			return eAsyncLoadTaskStatus.onFinish == this.status;
		}
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x0600045E RID: 1118 RVA: 0x0001E9A1 File Offset: 0x0001CDA1
	public bool isLoaded
	{
		get
		{
			return this.status == eAsyncLoadTaskStatus.onFinish || eAsyncLoadTaskStatus.onCondition == this.status;
		}
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x0600045F RID: 1119 RVA: 0x0001E9BB File Offset: 0x0001CDBB
	// (set) Token: 0x06000460 RID: 1120 RVA: 0x0001E9C3 File Offset: 0x0001CDC3
	public string path { get; private set; }

	// Token: 0x06000461 RID: 1121 RVA: 0x0001E9CC File Offset: 0x0001CDCC
	public void OnObjectLoaded(GameObject go)
	{
		this.m_Target = go;
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x0001E9D5 File Offset: 0x0001CDD5
	public bool IsObjectLoaded()
	{
		return null != this.m_Target;
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x0001E9E4 File Offset: 0x0001CDE4
	public GameObject ExtractObject()
	{
		GameObject target = this.m_Target;
		this.m_Target = null;
		return target;
	}

	// Token: 0x040003FD RID: 1021
	private GameObject m_Target;
}
