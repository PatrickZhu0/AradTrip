using System;
using System.Text;
using LitJson;
using UnityEngine;

// Token: 0x0200011D RID: 285
public class EngineConfig : Singleton<EngineConfig>
{
	// Token: 0x1700007F RID: 127
	// (get) Token: 0x06000668 RID: 1640 RVA: 0x000263AD File Offset: 0x000247AD
	public static bool asyncPackageLoad
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000080 RID: 128
	// (get) Token: 0x06000669 RID: 1641 RVA: 0x000263B0 File Offset: 0x000247B0
	public static bool useTMEngine
	{
		get
		{
			return Singleton<EngineConfig>.instance.m_EngineConfigData.useTMEngine;
		}
	}

	// Token: 0x17000081 RID: 129
	// (get) Token: 0x0600066A RID: 1642 RVA: 0x000263C1 File Offset: 0x000247C1
	public static int logLevel
	{
		get
		{
			return Singleton<EngineConfig>.instance.m_EngineConfigData.logLevel;
		}
	}

	// Token: 0x17000082 RID: 130
	// (get) Token: 0x0600066B RID: 1643 RVA: 0x000263D2 File Offset: 0x000247D2
	// (set) Token: 0x0600066C RID: 1644 RVA: 0x000263DE File Offset: 0x000247DE
	public static bool asyncLoadAnimRuntimeSwitch
	{
		get
		{
			return Singleton<EngineConfig>.instance.useAsyncLoadAnimRuntimeSwitch;
		}
		set
		{
			Singleton<EngineConfig>.instance.useAsyncLoadAnimRuntimeSwitch = value;
		}
	}

	// Token: 0x17000083 RID: 131
	// (get) Token: 0x0600066D RID: 1645 RVA: 0x000263EB File Offset: 0x000247EB
	public static bool useAsyncLoadAnim
	{
		get
		{
			return Singleton<EngineConfig>.instance.m_EngineConfigData.useAsyncLoadAnim && Singleton<EngineConfig>.instance.useAsyncLoadAnimRuntimeSwitch;
		}
	}

	// Token: 0x17000084 RID: 132
	// (get) Token: 0x0600066E RID: 1646 RVA: 0x0002640E File Offset: 0x0002480E
	public static bool enableAvatarPartFallback
	{
		get
		{
			return Singleton<EngineConfig>.instance.m_EngineConfigData.enableAvatarPartFallback;
		}
	}

	// Token: 0x17000085 RID: 133
	// (get) Token: 0x0600066F RID: 1647 RVA: 0x0002641F File Offset: 0x0002481F
	public static bool useNewHitText
	{
		get
		{
			return Singleton<EngineConfig>.instance.m_EngineConfigData.useNewHitText;
		}
	}

	// Token: 0x17000086 RID: 134
	// (get) Token: 0x06000670 RID: 1648 RVA: 0x00026430 File Offset: 0x00024830
	// (set) Token: 0x06000671 RID: 1649 RVA: 0x00026441 File Offset: 0x00024841
	public static bool usePrewarmFrame
	{
		get
		{
			return Singleton<EngineConfig>.instance.m_EngineConfigData.usePrewarmFrame;
		}
		set
		{
			Singleton<EngineConfig>.instance.m_EngineConfigData.usePrewarmFrame = value;
		}
	}

	// Token: 0x17000087 RID: 135
	// (get) Token: 0x06000672 RID: 1650 RVA: 0x00026453 File Offset: 0x00024853
	public static bool usePackageAsyncLoad
	{
		get
		{
			return Singleton<EngineConfig>.instance.m_EngineConfigData.usePackageAsyncLoad;
		}
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x00026464 File Offset: 0x00024864
	public static int GetAgentCountByGraphicLevel(int graphicLevel)
	{
		if (graphicLevel < Singleton<EngineConfig>.instance.graphicLevelAgentCount.Length)
		{
			return Singleton<EngineConfig>.instance.graphicLevelAgentCount[graphicLevel];
		}
		return 8;
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x00026486 File Offset: 0x00024886
	public sealed override void Init()
	{
		this.LoadConfig();
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x00026490 File Offset: 0x00024890
	public void LoadConfig()
	{
		try
		{
			byte[] array = this._loadData();
			if (array != null)
			{
				string @string = Encoding.Default.GetString(array);
				this.m_EngineConfigData = JsonMapper.ToObject<EngineConfig.EngineConfigData>(@string);
			}
			else
			{
				Debug.LogFormat("Engine config load failed!", new object[0]);
			}
		}
		catch (Exception ex)
		{
			Debug.LogFormat("Engine config load failed with exception:{0}!", new object[]
			{
				ex.Message
			});
		}
		Debug.LogFormat("EngineConfig:[asyncPackageLoad:{0}] ", new object[]
		{
			this.m_EngineConfigData.asyncPackageLoad
		});
		Debug.LogFormat("EngineConfig:[useTMEngine:{0}] ", new object[]
		{
			this.m_EngineConfigData.useTMEngine
		});
		Debug.LogFormat("EngineConfig:[useNewHitText:{0}] ", new object[]
		{
			this.m_EngineConfigData.useNewHitText
		});
		Debug.LogFormat("EngineConfig:[useAsyncLoadAnim:{0}] ", new object[]
		{
			this.m_EngineConfigData.useAsyncLoadAnim
		});
		Debug.LogFormat("EngineConfig:[usePrewarmFrame:{0}] ", new object[]
		{
			this.m_EngineConfigData.usePrewarmFrame
		});
		Debug.LogFormat("EngineConfig:[usePackageAsyncLoad:{0}] ", new object[]
		{
			this.m_EngineConfigData.usePackageAsyncLoad
		});
		Debug.LogFormat("EngineConfig:[logLevel:{0}] ", new object[]
		{
			this.m_EngineConfigData.logLevel
		});
		Debug.LogFormat("EngineConfig:[enableAvatarPartFallback:{0}] ", new object[]
		{
			this.m_EngineConfigData.enableAvatarPartFallback
		});
		Debug.LogFormat("EngineConfig:[lowLevelAgentCount:{0}] ", new object[]
		{
			this.m_EngineConfigData.lowLevelAgentCount
		});
		Debug.LogFormat("EngineConfig:[mediumLevelAgentCount:{0}] ", new object[]
		{
			this.m_EngineConfigData.mediumLevelAgentCount
		});
		Debug.LogFormat("EngineConfig:[highLevelAgentCount:{0}] ", new object[]
		{
			this.m_EngineConfigData.highLevelAgentCount
		});
		if (this.graphicLevelAgentCount.Length >= 3)
		{
			this.graphicLevelAgentCount[0] = this.m_EngineConfigData.highLevelAgentCount;
			this.graphicLevelAgentCount[1] = this.m_EngineConfigData.mediumLevelAgentCount;
			this.graphicLevelAgentCount[2] = this.m_EngineConfigData.lowLevelAgentCount;
		}
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x000266D4 File Offset: 0x00024AD4
	private byte[] _loadData()
	{
		byte[] result = null;
		try
		{
			if (!FileArchiveAccessor.LoadFileInPersistentFileArchive("engineconfig.json", out result))
			{
				Debug.LogError("Load engine config file from persistent path has failed!");
				if (!FileArchiveAccessor.LoadFileInLocalFileArchive("engineconfig.json", out result))
				{
					Debug.LogError("Load engine config file from streaming path has failed!");
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("Load engine config file exception:{0}!", new object[]
			{
				ex.Message
			});
		}
		return result;
	}

	// Token: 0x04000535 RID: 1333
	private EngineConfig.EngineConfigData m_EngineConfigData = new EngineConfig.EngineConfigData();

	// Token: 0x04000536 RID: 1334
	private const string kConfigFileName = "engineconfig.json";

	// Token: 0x04000537 RID: 1335
	private bool useAsyncLoadAnimRuntimeSwitch;

	// Token: 0x04000538 RID: 1336
	private readonly int[] graphicLevelAgentCount = new int[3];

	// Token: 0x0200011E RID: 286
	public class EngineConfigData
	{
		// Token: 0x04000539 RID: 1337
		public bool asyncPackageLoad;

		// Token: 0x0400053A RID: 1338
		public bool useTMEngine = true;

		// Token: 0x0400053B RID: 1339
		public bool useNewHitText = true;

		// Token: 0x0400053C RID: 1340
		public bool useAsyncLoadAnim = true;

		// Token: 0x0400053D RID: 1341
		public bool usePrewarmFrame = true;

		// Token: 0x0400053E RID: 1342
		public bool usePackageAsyncLoad = true;

		// Token: 0x0400053F RID: 1343
		public int logLevel = 3;

		// Token: 0x04000540 RID: 1344
		public bool enableAvatarPartFallback = true;

		// Token: 0x04000541 RID: 1345
		public int lowLevelAgentCount = 8;

		// Token: 0x04000542 RID: 1346
		public int mediumLevelAgentCount = 8;

		// Token: 0x04000543 RID: 1347
		public int highLevelAgentCount = 8;
	}
}
