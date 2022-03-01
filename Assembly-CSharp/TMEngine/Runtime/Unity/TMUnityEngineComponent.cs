using System;
using UnityEngine;

namespace TMEngine.Runtime.Unity
{
	// Token: 0x02004731 RID: 18225
	[DisallowMultipleComponent]
	[AddComponentMenu("TMEngine/EngineRoot")]
	public class TMUnityEngineComponent : TMModuleComponent
	{
		// Token: 0x0601A2BB RID: 107195 RVA: 0x0082171F File Offset: 0x0081FB1F
		protected sealed override void Awake()
		{
			base.Awake();
			Object.DontDestroyOnLoad(base.gameObject);
			FileArchiveAccessor.SetFileArchivePath(Application.dataPath, Application.streamingAssetsPath, Application.persistentDataPath);
			TMDebug.SetEngineLogLevel((DebugLevel)EngineConfig.logLevel);
		}

		// Token: 0x0601A2BC RID: 107196 RVA: 0x00821750 File Offset: 0x0081FB50
		private void Start()
		{
			int graphicLevel = Singleton<GeGraphicSetting>.instance.GetGraphicLevel();
			int agentCountByGraphicLevel = EngineConfig.GetAgentCountByGraphicLevel(graphicLevel);
			TMAssetModuleComponent componentInChildren = base.gameObject.GetComponentInChildren<TMAssetModuleComponent>();
			if (null != componentInChildren)
			{
				componentInChildren.SetAssetLoadAgentCount(agentCountByGraphicLevel);
			}
		}

		// Token: 0x0601A2BD RID: 107197 RVA: 0x00821790 File Offset: 0x0081FB90
		private void Update()
		{
			ModuleManager.Update(Time.deltaTime, Time.unscaledDeltaTime);
		}
	}
}
