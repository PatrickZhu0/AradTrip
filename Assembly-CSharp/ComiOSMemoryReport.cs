using System;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

// Token: 0x02000068 RID: 104
public class ComiOSMemoryReport : MonoBehaviour
{
	// Token: 0x06000244 RID: 580 RVA: 0x00011F3C File Offset: 0x0001033C
	private void Update()
	{
		this.mTickTime += Time.unscaledDeltaTime;
		if (this.mTickTime > this.time2Update)
		{
			this.mTickTime -= this.time2Update;
			this.curMemoryInMB.text = this._getMemorySize();
		}
	}

	// Token: 0x06000245 RID: 581 RVA: 0x00011F90 File Offset: 0x00010390
	private string _getMemorySize()
	{
		uint num = Profiler.GetMonoUsedSize() / 1024U / 1024U;
		uint num2 = Profiler.GetMonoHeapSize() / 1024U / 1024U;
		return string.Format("mono:{0}/{1} package:{2} pool:{3} fps:{4} lastFps:{5} promot:{6}", new object[]
		{
			num,
			num2,
			Singleton<AssetPackageManager>.instance.GetLoadedAssetPackageCount(),
			Singleton<CGameObjectPool>.instance.GetPooledGameObjectNum(),
			MonoSingleton<ComponentFPS>.instance.GetFPS(),
			MonoSingleton<ComponentFPS>.instance.GetLastAverageFPS(),
			Singleton<GeGraphicSetting>.instance.needPromoted
		});
	}

	// Token: 0x0400023A RID: 570
	public Text curMemoryInMB;

	// Token: 0x0400023B RID: 571
	public float time2Update = 1f;

	// Token: 0x0400023C RID: 572
	private float mTickTime;
}
