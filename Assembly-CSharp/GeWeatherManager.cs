using System;
using UnityEngine;

// Token: 0x02000D09 RID: 3337
public class GeWeatherManager : Singleton<GeWeatherManager>
{
	// Token: 0x0600882D RID: 34861 RVA: 0x0018407C File Offset: 0x0018247C
	public override void Init()
	{
		if (null == this.m_WeatherNode)
		{
			GameObject gameObject = GameObject.Find("Environment");
			if (null != gameObject)
			{
				this.m_WeatherNode = new GameObject("Weather");
				this.m_WeatherNode.transform.SetParent(gameObject.transform);
			}
		}
		int num = 4;
		for (int i = 0; i < num; i++)
		{
			if (i == 0)
			{
				this.m_WeatherEffNodeTbl[i] = null;
			}
			else
			{
				this.m_WeatherEffNodeTbl[i] = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.m_WeatherResTable[i], false, 0U);
				if (!(null == this.m_WeatherEffNodeTbl[i]))
				{
					Singleton<GeMeshRenderManager>.instance.AddMeshObject(this.m_WeatherEffNodeTbl[i]);
					this.m_WeatherEffNodeTbl[i].SetActive(false);
					if (null != this.m_WeatherNode)
					{
						this.m_WeatherEffNodeTbl[i].transform.SetParent(this.m_WeatherNode.transform);
					}
				}
			}
		}
	}

	// Token: 0x0600882E RID: 34862 RVA: 0x00184184 File Offset: 0x00182584
	public void Deinit()
	{
		int num = 4;
		for (int i = 0; i < num; i++)
		{
			Object.Destroy(this.m_WeatherEffNodeTbl[i]);
		}
	}

	// Token: 0x0600882F RID: 34863 RVA: 0x001841B4 File Offset: 0x001825B4
	public void ChangeWeather(EWeatherMode weatherMode)
	{
		if (null != this.m_CurEffNode)
		{
			this.m_CurEffNode.SetActive(false);
		}
		if (weatherMode < EWeatherMode.MaxModeNum)
		{
			this.m_CurEffNode = this.m_WeatherEffNodeTbl[(int)weatherMode];
		}
		if (null != this.m_CurEffNode)
		{
			this.m_CurEffNode.SetActive(true);
		}
	}

	// Token: 0x04004208 RID: 16904
	protected readonly string[] m_WeatherResTable = new string[]
	{
		string.Empty,
		"Effects/Scene_effects/Weather/Rain/FX_Rain",
		"Effects/Scene_effects/Weather/Wind/FX_Wind",
		"Effects/Scene_effects/Weather/Snow/FX_Snow"
	};

	// Token: 0x04004209 RID: 16905
	protected GameObject m_WeatherNode;

	// Token: 0x0400420A RID: 16906
	protected GameObject m_CurEffNode;

	// Token: 0x0400420B RID: 16907
	protected GameObject[] m_WeatherEffNodeTbl = new GameObject[4];
}
