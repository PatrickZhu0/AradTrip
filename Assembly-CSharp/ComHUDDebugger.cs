using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

// Token: 0x020000E2 RID: 226
public class ComHUDDebugger : MonoBehaviour
{
	// Token: 0x060004CF RID: 1231 RVA: 0x0001FF05 File Offset: 0x0001E305
	private void Start()
	{
		if (this.AllowDebugging)
		{
			Application.logMessageReceived += new Application.LogCallback(this.LogHandler);
		}
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x0001FF24 File Offset: 0x0001E324
	private void Update()
	{
		if (this.AllowDebugging)
		{
			this._frameNumber++;
			float num = Time.realtimeSinceStartup - this._lastShowFPSTime;
			if (num >= 1f)
			{
				this._fps = (int)((float)this._frameNumber / num);
				this._frameNumber = 0;
				this._lastShowFPSTime = Time.realtimeSinceStartup;
			}
		}
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x0001FF84 File Offset: 0x0001E384
	private void OnDestory()
	{
		if (this.AllowDebugging)
		{
			Application.logMessageReceived -= new Application.LogCallback(this.LogHandler);
		}
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x0001FFA4 File Offset: 0x0001E3A4
	private void LogHandler(string condition, string stackTrace, LogType type)
	{
		ComHUDDebugger.LogData item = default(ComHUDDebugger.LogData);
		item.time = DateTime.Now.ToString("HH:mm:ss");
		item.message = condition;
		item.stackTrace = stackTrace;
		if (type == 1)
		{
			item.type = "Fatal";
			this._fatalLogCount++;
		}
		else if (type == 4 || type == null)
		{
			item.type = "Error";
			this._errorLogCount++;
		}
		else if (type == 2)
		{
			item.type = "Warning";
			this._warningLogCount++;
		}
		else if (type == 3)
		{
			item.type = "Info";
			this._infoLogCount++;
		}
		this._logInformations.Add(item);
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x00020088 File Offset: 0x0001E488
	private void OnGUI()
	{
		Matrix4x4 matrix = GUI.matrix;
		this._WindowScale = this._TouchScale(this._WindowScale);
		GUI.matrix = Matrix4x4.Scale(new Vector3(this._WindowScale, this._WindowScale, 1f));
		if (this._fps >= 18)
		{
			this._fpsColor = Color.Lerp(Color.yellow, Color.green, (float)(this._fps - 18) / 12f);
		}
		else if (this._fps >= 10)
		{
			this._fpsColor = Color.Lerp(Color.red, Color.yellow, (float)(this._fps - 10) / 8f);
		}
		else
		{
			this._fpsColor = Color.red;
		}
		if (this.AllowDebugging)
		{
			if (this._expansion)
			{
				this._windowRect = GUI.Window(0, this._windowRect, new GUI.WindowFunction(this.ExpansionGUIWindow), "DEBUGGER");
			}
			else
			{
				this._windowRect = GUI.Window(0, this._windowRect, new GUI.WindowFunction(this.ShrinkGUIWindow), "DEBUGGER");
			}
		}
		GUI.matrix = matrix;
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x000201B0 File Offset: 0x0001E5B0
	private void ExpansionGUIWindow(int windowId)
	{
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 40f));
		GUILayout.Space(20f);
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		GUI.contentColor = this._fpsColor;
		if (GUILayout.Button("FPS:" + this._fps, new GUILayoutOption[]
		{
			GUILayout.Height(30f)
		}))
		{
			this._expansion = false;
			this._windowRect.width = 100f;
			this._windowRect.height = 60f;
		}
		GUI.contentColor = ((this._debugType != ComHUDDebugger.DebugType.Console) ? Color.gray : Color.white);
		if (GUILayout.Button("Console", new GUILayoutOption[]
		{
			GUILayout.Height(30f)
		}))
		{
			this._debugType = ComHUDDebugger.DebugType.Console;
		}
		GUI.contentColor = ((this._debugType != ComHUDDebugger.DebugType.Memory) ? Color.gray : Color.white);
		if (GUILayout.Button("Memory", new GUILayoutOption[]
		{
			GUILayout.Height(30f)
		}))
		{
			this._debugType = ComHUDDebugger.DebugType.Memory;
		}
		GUI.contentColor = ((this._debugType != ComHUDDebugger.DebugType.System) ? Color.gray : Color.white);
		if (GUILayout.Button("System", new GUILayoutOption[]
		{
			GUILayout.Height(30f)
		}))
		{
			this._debugType = ComHUDDebugger.DebugType.System;
		}
		GUI.contentColor = ((this._debugType != ComHUDDebugger.DebugType.Screen) ? Color.gray : Color.white);
		if (GUILayout.Button("Screen", new GUILayoutOption[]
		{
			GUILayout.Height(30f)
		}))
		{
			this._debugType = ComHUDDebugger.DebugType.Screen;
		}
		GUI.contentColor = ((this._debugType != ComHUDDebugger.DebugType.Quality) ? Color.gray : Color.white);
		if (GUILayout.Button("Quality", new GUILayoutOption[]
		{
			GUILayout.Height(30f)
		}))
		{
			this._debugType = ComHUDDebugger.DebugType.Quality;
		}
		GUI.contentColor = ((this._debugType != ComHUDDebugger.DebugType.Environment) ? Color.gray : Color.white);
		if (GUILayout.Button("Environment", new GUILayoutOption[]
		{
			GUILayout.Height(30f)
		}))
		{
			this._debugType = ComHUDDebugger.DebugType.Environment;
		}
		GUI.contentColor = ((this._debugType != ComHUDDebugger.DebugType.Asset) ? Color.gray : Color.white);
		if (GUILayout.Button("Asset", new GUILayoutOption[]
		{
			GUILayout.Height(30f)
		}))
		{
			this._debugType = ComHUDDebugger.DebugType.Asset;
		}
		GUI.contentColor = ((this._debugType != ComHUDDebugger.DebugType.Asset) ? Color.gray : Color.white);
		if (EngineConfig.usePrewarmFrame)
		{
			if (GUILayout.Button("PreLoadUI ON", new GUILayoutOption[]
			{
				GUILayout.Height(40f)
			}))
			{
				EngineConfig.usePrewarmFrame = false;
			}
		}
		else if (GUILayout.Button("PreLoadUI OFF", new GUILayoutOption[]
		{
			GUILayout.Height(40f)
		}))
		{
			EngineConfig.usePrewarmFrame = true;
		}
		GUI.contentColor = Color.white;
		GUILayout.EndHorizontal();
		if (this._debugType == ComHUDDebugger.DebugType.Console)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("Clear", new GUILayoutOption[0]))
			{
				this._logInformations.Clear();
				this._fatalLogCount = 0;
				this._warningLogCount = 0;
				this._errorLogCount = 0;
				this._infoLogCount = 0;
				this._currentLogIndex = -1;
				this._fpsColor = Color.white;
			}
			GUI.contentColor = ((!this._showInfoLog) ? Color.gray : Color.white);
			this._showInfoLog = GUILayout.Toggle(this._showInfoLog, "Info [" + this._infoLogCount + "]", new GUILayoutOption[0]);
			GUI.contentColor = ((!this._showWarningLog) ? Color.gray : Color.white);
			this._showWarningLog = GUILayout.Toggle(this._showWarningLog, "Warning [" + this._warningLogCount + "]", new GUILayoutOption[0]);
			GUI.contentColor = ((!this._showErrorLog) ? Color.gray : Color.white);
			this._showErrorLog = GUILayout.Toggle(this._showErrorLog, "Error [" + this._errorLogCount + "]", new GUILayoutOption[0]);
			GUI.contentColor = ((!this._showFatalLog) ? Color.gray : Color.white);
			this._showFatalLog = GUILayout.Toggle(this._showFatalLog, "Fatal [" + this._fatalLogCount + "]", new GUILayoutOption[0]);
			GUI.contentColor = Color.white;
			GUILayout.EndHorizontal();
			GUI.SetNextControlName("_scrollLogView");
			this._scrollLogView = GUILayout.BeginScrollView(this._scrollLogView, "Box", new GUILayoutOption[]
			{
				GUILayout.Height(165f)
			});
			if ("_scrollLogView" == GUI.GetNameOfFocusedControl())
			{
				this._scrollLogView = this._TouchRoll(this._scrollLogView);
			}
			int i = 0;
			while (i < this._logInformations.Count)
			{
				bool flag = false;
				Color contentColor = Color.white;
				string type = this._logInformations[i].type;
				if (type != null)
				{
					if (!(type == "Fatal"))
					{
						if (!(type == "Error"))
						{
							if (!(type == "Info"))
							{
								if (type == "Warning")
								{
									flag = this._showWarningLog;
									contentColor = Color.yellow;
								}
							}
							else
							{
								flag = this._showInfoLog;
								contentColor = Color.white;
							}
						}
						else
						{
							flag = this._showErrorLog;
							contentColor = Color.red;
						}
					}
					else
					{
						flag = this._showFatalLog;
						contentColor = Color.red;
					}
				}
				IL_5F6:
				if (flag)
				{
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					if (GUILayout.Toggle(this._currentLogIndex == i, string.Empty, new GUILayoutOption[0]))
					{
						this._currentLogIndex = i;
					}
					GUI.contentColor = contentColor;
					GUILayout.Label("[" + this._logInformations[i].type + "] ", new GUILayoutOption[0]);
					GUILayout.Label("[" + this._logInformations[i].time + "] ", new GUILayoutOption[0]);
					GUILayout.Label(this._logInformations[i].message, new GUILayoutOption[0]);
					GUILayout.FlexibleSpace();
					GUI.contentColor = Color.white;
					GUILayout.EndHorizontal();
				}
				i++;
				continue;
				goto IL_5F6;
			}
			GUILayout.EndScrollView();
			GUI.SetNextControlName("_scrollCurrentLogView");
			this._scrollCurrentLogView = GUILayout.BeginScrollView(this._scrollCurrentLogView, "Box", new GUILayoutOption[]
			{
				GUILayout.Height(100f)
			});
			if ("_scrollCurrentLogView" == GUI.GetNameOfFocusedControl())
			{
				this._scrollCurrentLogView = this._TouchRoll(this._scrollCurrentLogView);
			}
			if (this._currentLogIndex != -1)
			{
				GUILayout.Label(this._logInformations[this._currentLogIndex].message + "\r\n\r\n" + this._logInformations[this._currentLogIndex].stackTrace, new GUILayoutOption[0]);
			}
			GUILayout.EndScrollView();
		}
		else if (this._debugType == ComHUDDebugger.DebugType.Memory)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Memory Information", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.BeginVertical("Box", new GUILayoutOption[0]);
			long num = 1048576L;
			GUILayout.Label("总内存：" + Profiler.GetTotalReservedMemoryLong() / num + "MB", new GUILayoutOption[0]);
			GUILayout.Label("已占用内存：" + Profiler.GetTotalAllocatedMemoryLong() / num + "MB", new GUILayoutOption[0]);
			GUILayout.Label("空闲中内存：" + Profiler.GetTotalUnusedReservedMemoryLong() / num + "MB", new GUILayoutOption[0]);
			GUILayout.Label("总Mono堆内存：" + Profiler.GetMonoHeapSizeLong() / num + "MB", new GUILayoutOption[0]);
			GUILayout.Label("已占用Mono堆内存：" + Profiler.GetMonoUsedSizeLong() / num + "MB", new GUILayoutOption[0]);
			GUILayout.EndVertical();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("卸载未使用的资源", new GUILayoutOption[0]))
			{
				Resources.UnloadUnusedAssets();
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("使用GC垃圾回收", new GUILayoutOption[0]))
			{
				GC.Collect();
			}
			GUILayout.EndHorizontal();
		}
		else if (this._debugType == ComHUDDebugger.DebugType.System)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("System Information", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			this._scrollSystemView = GUILayout.BeginScrollView(this._scrollSystemView, "Box");
			GUILayout.Label("操作系统：" + SystemInfo.operatingSystem, new GUILayoutOption[0]);
			GUILayout.Label("系统内存：" + SystemInfo.systemMemorySize + "MB", new GUILayoutOption[0]);
			GUILayout.Label("处理器：" + SystemInfo.processorType, new GUILayoutOption[0]);
			GUILayout.Label("处理器数量：" + SystemInfo.processorCount, new GUILayoutOption[0]);
			GUILayout.Label("显卡：" + SystemInfo.graphicsDeviceName, new GUILayoutOption[0]);
			GUILayout.Label("显卡类型：" + SystemInfo.graphicsDeviceType, new GUILayoutOption[0]);
			GUILayout.Label("显存：" + SystemInfo.graphicsMemorySize + "MB", new GUILayoutOption[0]);
			GUILayout.Label("显卡标识：" + SystemInfo.graphicsDeviceID, new GUILayoutOption[0]);
			GUILayout.Label("显卡供应商：" + SystemInfo.graphicsDeviceVendor, new GUILayoutOption[0]);
			GUILayout.Label("显卡供应商标识码：" + SystemInfo.graphicsDeviceVendorID, new GUILayoutOption[0]);
			GUILayout.Label("设备模式：" + SystemInfo.deviceModel, new GUILayoutOption[0]);
			GUILayout.Label("设备名称：" + SystemInfo.deviceName, new GUILayoutOption[0]);
			GUILayout.Label("设备类型：" + SystemInfo.deviceType, new GUILayoutOption[0]);
			GUILayout.Label("设备标识：" + SystemInfo.deviceUniqueIdentifier, new GUILayoutOption[0]);
			GUILayout.EndScrollView();
		}
		else if (this._debugType == ComHUDDebugger.DebugType.Screen)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Screen Information", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.BeginVertical("Box", new GUILayoutOption[0]);
			GUILayout.Label("DPI：" + Screen.dpi, new GUILayoutOption[0]);
			GUILayout.Label("分辨率：" + Screen.currentResolution.ToString(), new GUILayoutOption[0]);
			GUILayout.EndVertical();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("全屏", new GUILayoutOption[0]))
			{
				Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, !Screen.fullScreen);
			}
			GUILayout.EndHorizontal();
		}
		else if (this._debugType == ComHUDDebugger.DebugType.Quality)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Quality Information", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.BeginVertical("Box", new GUILayoutOption[0]);
			string str = string.Empty;
			if (QualitySettings.GetQualityLevel() == 0)
			{
				str = " [最低]";
			}
			else if (QualitySettings.GetQualityLevel() == QualitySettings.names.Length - 1)
			{
				str = " [最高]";
			}
			GUILayout.Label("图形质量：" + QualitySettings.names[QualitySettings.GetQualityLevel()] + str, new GUILayoutOption[0]);
			GUILayout.EndVertical();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("降低一级图形质量", new GUILayoutOption[0]))
			{
				QualitySettings.DecreaseLevel();
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("提升一级图形质量", new GUILayoutOption[0]))
			{
				QualitySettings.IncreaseLevel();
			}
			GUILayout.EndHorizontal();
		}
		else if (this._debugType == ComHUDDebugger.DebugType.Environment)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Environment Information", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.BeginVertical("Box", new GUILayoutOption[0]);
			GUILayout.Label("项目名称：" + Application.productName, new GUILayoutOption[0]);
			GUILayout.Label("项目ID：" + Application.identifier, new GUILayoutOption[0]);
			GUILayout.Label("项目版本：" + Application.version, new GUILayoutOption[0]);
			GUILayout.Label("Unity版本：" + Application.unityVersion, new GUILayoutOption[0]);
			GUILayout.Label("公司名称：" + Application.companyName, new GUILayoutOption[0]);
			GUILayout.EndVertical();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("退出程序", new GUILayoutOption[0]))
			{
				Application.Quit();
			}
			if (GUILayout.Button("隐藏UI", new GUILayoutOption[0]))
			{
				if (null == this._UIRoot)
				{
					this._UIRoot = GameObject.Find("UIRoot");
				}
				if (null != this._UIRoot)
				{
					this._UIRoot.SetActive(!this._UIRoot.activeSelf);
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("隐藏角色", new GUILayoutOption[0]))
			{
				if (null == this._ActorRoot)
				{
					this._ActorRoot = GameObject.Find("ActorRoot");
				}
				if (null != this._ActorRoot)
				{
					this._ActorRoot.SetActive(!this._ActorRoot.activeSelf);
				}
			}
			if (GUILayout.Button("隐藏场景", new GUILayoutOption[0]))
			{
				if (null == this._SceneRoot)
				{
					this._SceneRoot = GameObject.Find("SceneRoot");
				}
				if (null != this._SceneRoot)
				{
					this._SceneRoot.SetActive(!this._SceneRoot.activeSelf);
				}
			}
			GUILayout.EndHorizontal();
		}
		else if (this._debugType == ComHUDDebugger.DebugType.Asset)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label(string.Format("当前代理数量：{0}", this._RunningTaskLimit), new GUILayoutOption[0]);
			if (GUILayout.Button("增加代理数量", new GUILayoutOption[0]))
			{
				this._RunningTaskLimit++;
				Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.RunningTaskLimit = this._RunningTaskLimit;
				Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.RunningTaskLimit = this._RunningTaskLimit;
				Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.RunningTaskLimit = this._RunningTaskLimit;
				this._RunningTaskLimit = Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.RunningTaskLimit;
			}
			if (GUILayout.Button("减少代理数量", new GUILayoutOption[0]))
			{
				this._RunningTaskLimit--;
				Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.RunningTaskLimit = this._RunningTaskLimit;
				Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.RunningTaskLimit = this._RunningTaskLimit;
				Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.RunningTaskLimit = this._RunningTaskLimit;
				this._RunningTaskLimit = Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.RunningTaskLimit;
			}
			if (GUILayout.Button("Snap Asset Usage", new GUILayoutOption[0]))
			{
				Singleton<AssetLoader>.instance.DumpAssetInfo(ref this._AssetList);
				Singleton<AssetPackageManager>.instance.DumpAssetPackageInfo(ref this._AssetPackageList);
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label(string.Format("已加载资源数量：{0}", this._AssetList.Count), new GUILayoutOption[0]);
			GUILayout.Label(string.Format("已加载资源包数量：{0}", this._AssetPackageList.Count), new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			int num2 = Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.LoadingTaskCount + Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.LoadingTaskCount;
			int num3 = Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.RunningTaskCount + Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.RunningTaskCount;
			int loadingTaskCount = Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.LoadingTaskCount;
			int runningTaskCount = Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.RunningTaskCount;
			int num4 = Singleton<AsyncLoadTaskAllocator<ResourceRequestWrapper, Object>>.instance.CompleteTaskCount + Singleton<AsyncLoadTaskAllocator<AssetBundleResquestWrapper, Object>>.instance.CompleteTaskCount;
			int completeTaskCount = Singleton<AsyncLoadTaskAllocator<AssetBundleCreateRequestWrapper, AssetBundle>>.instance.CompleteTaskCount;
			int loadingTaskCount2 = Singleton<CGameObjectPool>.instance.LoadingTaskCount;
			int completeTaskCount2 = Singleton<CGameObjectPool>.instance.CompleteTaskCount;
			int loadingTaskCount3 = Singleton<AssetLoader>.instance.LoadingTaskCount;
			int loadingTaskCount4 = Singleton<AssetLoader>.instance.LoadingTaskCount;
			GUILayout.Label(string.Format("Asset:{0} ({2}) [{1}]", num2, num4, num3), new GUILayoutOption[0]);
			GUILayout.Label(string.Format("AssetBundle:{0} ({2}) [{1}]", loadingTaskCount, completeTaskCount, runningTaskCount), new GUILayoutOption[0]);
			GUILayout.Label(string.Format("GameObjPool:{0} [{1}]", loadingTaskCount2, completeTaskCount2), new GUILayoutOption[0]);
			GUILayout.Label(string.Format("AssetLoader:{0} [{1}]", loadingTaskCount3, loadingTaskCount4), new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUI.SetNextControlName("_scrollAssetView");
			this._scrollAssetView = GUILayout.BeginScrollView(this._scrollAssetView, "Box", new GUILayoutOption[]
			{
				GUILayout.Height(100f)
			});
			if ("_scrollAssetView" == GUI.GetNameOfFocusedControl())
			{
				this._scrollAssetView = this._TouchRoll(this._scrollAssetView);
			}
			for (int j = 0; j < this._AssetList.Count; j++)
			{
				GUI.contentColor = Color.yellow;
				GUILayout.Label(this._AssetList[j], new GUILayoutOption[0]);
				GUILayout.FlexibleSpace();
				GUI.contentColor = Color.white;
			}
			GUILayout.EndScrollView();
			GUI.SetNextControlName("_scrollAssetPackageView");
			this._scrollAssetPackageView = GUILayout.BeginScrollView(this._scrollAssetPackageView, "Box", new GUILayoutOption[]
			{
				GUILayout.Height(100f)
			});
			if ("_scrollAssetPackageView" == GUI.GetNameOfFocusedControl())
			{
				this._scrollAssetPackageView = this._TouchRoll(this._scrollAssetPackageView);
			}
			for (int k = 0; k < this._AssetPackageList.Count; k++)
			{
				GUI.contentColor = Color.yellow;
				GUILayout.Label(this._AssetPackageList[k], new GUILayoutOption[0]);
				GUILayout.FlexibleSpace();
				GUI.contentColor = Color.white;
			}
			GUILayout.EndScrollView();
		}
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x000214EC File Offset: 0x0001F8EC
	private void ShrinkGUIWindow(int windowId)
	{
		GUI.DragWindow(new Rect(0f, 0f, 10000f, 20f));
		GUI.contentColor = this._fpsColor;
		if (GUILayout.Button("FPS:" + this._fps, new GUILayoutOption[]
		{
			GUILayout.Width(80f),
			GUILayout.Height(30f)
		}))
		{
			this._expansion = true;
			this._windowRect.width = 600f;
			this._windowRect.height = 360f;
		}
		GUI.contentColor = Color.white;
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x00021594 File Offset: 0x0001F994
	private Vector2 _TouchRoll(Vector2 input)
	{
		Vector2 vector = input;
		if (Input.touchCount == 2)
		{
			vector += (Input.touches[0].deltaPosition + Input.touches[1].deltaPosition) * 0.5f;
		}
		return vector;
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x000215E8 File Offset: 0x0001F9E8
	private float _TouchScale(float origin)
	{
		if (Input.touchCount == 2)
		{
			float num = origin + Mathf.Sqrt(Vector2.SqrMagnitude(Input.touches[0].deltaPosition - Input.touches[1].deltaPosition));
		}
		return origin;
	}

	// Token: 0x04000436 RID: 1078
	public bool AllowDebugging = true;

	// Token: 0x04000437 RID: 1079
	private ComHUDDebugger.DebugType _debugType;

	// Token: 0x04000438 RID: 1080
	private List<ComHUDDebugger.LogData> _logInformations = new List<ComHUDDebugger.LogData>();

	// Token: 0x04000439 RID: 1081
	private int _currentLogIndex = -1;

	// Token: 0x0400043A RID: 1082
	private int _infoLogCount;

	// Token: 0x0400043B RID: 1083
	private int _warningLogCount;

	// Token: 0x0400043C RID: 1084
	private int _errorLogCount;

	// Token: 0x0400043D RID: 1085
	private int _fatalLogCount;

	// Token: 0x0400043E RID: 1086
	private bool _showInfoLog = true;

	// Token: 0x0400043F RID: 1087
	private bool _showWarningLog = true;

	// Token: 0x04000440 RID: 1088
	private bool _showErrorLog = true;

	// Token: 0x04000441 RID: 1089
	private bool _showFatalLog = true;

	// Token: 0x04000442 RID: 1090
	private Vector2 _scrollLogView = Vector2.zero;

	// Token: 0x04000443 RID: 1091
	private Vector2 _scrollCurrentLogView = Vector2.zero;

	// Token: 0x04000444 RID: 1092
	private Vector2 _scrollSystemView = Vector2.zero;

	// Token: 0x04000445 RID: 1093
	private Vector2 _scrollAssetView = Vector2.zero;

	// Token: 0x04000446 RID: 1094
	private Vector2 _scrollAssetPackageView = Vector2.zero;

	// Token: 0x04000447 RID: 1095
	private bool _expansion;

	// Token: 0x04000448 RID: 1096
	private Rect _windowRect = new Rect(500f, 0f, 100f, 60f);

	// Token: 0x04000449 RID: 1097
	private int _fps;

	// Token: 0x0400044A RID: 1098
	private Color _fpsColor = Color.white;

	// Token: 0x0400044B RID: 1099
	private int _frameNumber;

	// Token: 0x0400044C RID: 1100
	private float _lastShowFPSTime;

	// Token: 0x0400044D RID: 1101
	private int _RunningTaskLimit = 2;

	// Token: 0x0400044E RID: 1102
	private float _WindowScale = 2f;

	// Token: 0x0400044F RID: 1103
	private List<string> _AssetList = new List<string>();

	// Token: 0x04000450 RID: 1104
	private List<string> _AssetPackageList = new List<string>();

	// Token: 0x04000451 RID: 1105
	private GameObject _UIRoot;

	// Token: 0x04000452 RID: 1106
	private GameObject _ActorRoot;

	// Token: 0x04000453 RID: 1107
	private GameObject _SceneRoot;

	// Token: 0x020000E3 RID: 227
	public struct LogData
	{
		// Token: 0x04000454 RID: 1108
		public string time;

		// Token: 0x04000455 RID: 1109
		public string type;

		// Token: 0x04000456 RID: 1110
		public string message;

		// Token: 0x04000457 RID: 1111
		public string stackTrace;
	}

	// Token: 0x020000E4 RID: 228
	public enum DebugType
	{
		// Token: 0x04000459 RID: 1113
		Console,
		// Token: 0x0400045A RID: 1114
		Memory,
		// Token: 0x0400045B RID: 1115
		System,
		// Token: 0x0400045C RID: 1116
		Screen,
		// Token: 0x0400045D RID: 1117
		Quality,
		// Token: 0x0400045E RID: 1118
		Environment,
		// Token: 0x0400045F RID: 1119
		Asset
	}
}
