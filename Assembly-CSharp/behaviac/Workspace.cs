using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading;
using MiniXml;
using UnityEngine;

namespace behaviac
{
	// Token: 0x020048BC RID: 18620
	public class Workspace : IDisposable
	{
		// Token: 0x0601AC69 RID: 109673 RVA: 0x0083C890 File Offset: 0x0083AC90
		public Workspace()
		{
			Workspace.ms_instance = this;
		}

		// Token: 0x0601AC6A RID: 109674 RVA: 0x0083C8FA File Offset: 0x0083ACFA
		public void Dispose()
		{
			Workspace.ms_instance = null;
		}

		// Token: 0x170022AB RID: 8875
		// (get) Token: 0x0601AC6B RID: 109675 RVA: 0x0083C904 File Offset: 0x0083AD04
		public static Workspace Instance
		{
			get
			{
				if (Workspace.ms_instance == null)
				{
					Workspace workspace = new Workspace();
				}
				return Workspace.ms_instance;
			}
		}

		// Token: 0x170022AC RID: 8876
		// (get) Token: 0x0601AC6C RID: 109676 RVA: 0x0083C926 File Offset: 0x0083AD26
		// (set) Token: 0x0601AC6D RID: 109677 RVA: 0x0083C92E File Offset: 0x0083AD2E
		public Workspace.EFileFormat FileFormat
		{
			get
			{
				return this.fileFormat_;
			}
			set
			{
				this.fileFormat_ = value;
			}
		}

		// Token: 0x0601AC6E RID: 109678 RVA: 0x0083C938 File Offset: 0x0083AD38
		private static string GetDefaultFilePath()
		{
			string result = string.Empty;
			string str = "/Resources/behaviac/exported";
			if (Application.platform == 7)
			{
				result = Application.dataPath + str;
			}
			else if (Application.platform == 2)
			{
				result = Application.dataPath + str;
			}
			else
			{
				result = "Assets" + str;
			}
			return result;
		}

		// Token: 0x170022AD RID: 8877
		// (get) Token: 0x0601AC6F RID: 109679 RVA: 0x0083C996 File Offset: 0x0083AD96
		// (set) Token: 0x0601AC70 RID: 109680 RVA: 0x0083C9B9 File Offset: 0x0083ADB9
		public string FilePath
		{
			get
			{
				if (string.IsNullOrEmpty(this.m_filePath))
				{
					this.m_filePath = Workspace.GetDefaultFilePath();
				}
				return this.m_filePath;
			}
			set
			{
				this.m_filePath = value;
			}
		}

		// Token: 0x170022AE RID: 8878
		// (get) Token: 0x0601AC71 RID: 109681 RVA: 0x0083C9C2 File Offset: 0x0083ADC2
		// (set) Token: 0x0601AC72 RID: 109682 RVA: 0x0083C9CA File Offset: 0x0083ADCA
		public string MetaFile
		{
			get
			{
				return this.m_metaFile;
			}
			set
			{
				this.m_metaFile = value;
			}
		}

		// Token: 0x170022AF RID: 8879
		// (get) Token: 0x0601AC73 RID: 109683 RVA: 0x0083C9D3 File Offset: 0x0083ADD3
		// (set) Token: 0x0601AC74 RID: 109684 RVA: 0x0083C9F1 File Offset: 0x0083ADF1
		public virtual int FrameSinceStartup
		{
			get
			{
				return (this.m_frameSinceStartup >= 0) ? this.m_frameSinceStartup : Time.frameCount;
			}
			set
			{
				this.m_frameSinceStartup = value;
			}
		}

		// Token: 0x170022B0 RID: 8880
		// (get) Token: 0x0601AC75 RID: 109685 RVA: 0x0083C9FA File Offset: 0x0083ADFA
		// (set) Token: 0x0601AC76 RID: 109686 RVA: 0x0083CA02 File Offset: 0x0083AE02
		public bool UseIntValue
		{
			get
			{
				return this._useIntValue;
			}
			set
			{
				this._useIntValue = value;
			}
		}

		// Token: 0x170022B1 RID: 8881
		// (get) Token: 0x0601AC77 RID: 109687 RVA: 0x0083CA0B File Offset: 0x0083AE0B
		// (set) Token: 0x0601AC78 RID: 109688 RVA: 0x0083CA38 File Offset: 0x0083AE38
		public virtual double TimeSinceStartup
		{
			get
			{
				if (this.m_doubleValueSinceStartup >= 0.0)
				{
					return this.m_doubleValueSinceStartup * 0.001;
				}
				return (double)Time.realtimeSinceStartup;
			}
			set
			{
				this.m_doubleValueSinceStartup = value * 1000.0;
			}
		}

		// Token: 0x170022B2 RID: 8882
		// (get) Token: 0x0601AC79 RID: 109689 RVA: 0x0083CA4B File Offset: 0x0083AE4B
		// (set) Token: 0x0601AC7A RID: 109690 RVA: 0x0083CA74 File Offset: 0x0083AE74
		public virtual double DoubleValueSinceStartup
		{
			get
			{
				if (this.m_doubleValueSinceStartup >= 0.0)
				{
					return this.m_doubleValueSinceStartup;
				}
				return (double)(Time.realtimeSinceStartup * 1000f);
			}
			set
			{
				this.m_doubleValueSinceStartup = value;
			}
		}

		// Token: 0x170022B3 RID: 8883
		// (get) Token: 0x0601AC7B RID: 109691 RVA: 0x0083CA7D File Offset: 0x0083AE7D
		// (set) Token: 0x0601AC7C RID: 109692 RVA: 0x0083CA9F File Offset: 0x0083AE9F
		public virtual long IntValueSinceStartup
		{
			get
			{
				if (this.m_intValueSinceStartup >= 0L)
				{
					return this.m_intValueSinceStartup;
				}
				return (long)(Time.realtimeSinceStartup * 1000f);
			}
			set
			{
				this.m_intValueSinceStartup = value;
			}
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x0601AC7D RID: 109693 RVA: 0x0083CAA8 File Offset: 0x0083AEA8
		// (remove) Token: 0x0601AC7E RID: 109694 RVA: 0x0083CAE0 File Offset: 0x0083AEE0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private event Workspace.BehaviorNodeLoader BehaviorNodeLoaded;

		// Token: 0x0601AC7F RID: 109695 RVA: 0x0083CB16 File Offset: 0x0083AF16
		public void OnBehaviorNodeLoaded(string nodeType, List<property_t> properties)
		{
			if (this.BehaviorNodeLoaded != null)
			{
				this.BehaviorNodeLoaded(nodeType, properties);
			}
		}

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x0601AC80 RID: 109696 RVA: 0x0083CB30 File Offset: 0x0083AF30
		// (remove) Token: 0x0601AC81 RID: 109697 RVA: 0x0083CB68 File Offset: 0x0083AF68
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Workspace.DRespondToBreakHandler RespondToBreakHandler;

		// Token: 0x0601AC82 RID: 109698 RVA: 0x0083CB9E File Offset: 0x0083AF9E
		public void RespondToBreak(string msg, string title)
		{
			if (this.RespondToBreakHandler != null)
			{
				this.RespondToBreakHandler(msg, title);
				return;
			}
			this.WaitforContinue();
			Thread.Sleep(500);
		}

		// Token: 0x170022B4 RID: 8884
		// (get) Token: 0x0601AC83 RID: 109699 RVA: 0x0083CBC9 File Offset: 0x0083AFC9
		internal bool IsInited
		{
			get
			{
				return this.m_bInited;
			}
		}

		// Token: 0x0601AC84 RID: 109700 RVA: 0x0083CBD4 File Offset: 0x0083AFD4
		public bool TryInit()
		{
			if (this.m_bInited)
			{
				return true;
			}
			this.m_bInited = true;
			ComparerRegister.Init();
			ComputerRegister.Init();
			Workspace.Instance.RegisterStuff();
			Config.LogInfo();
			if (string.IsNullOrEmpty(this.FilePath))
			{
				return false;
			}
			this.m_frameSinceStartup = -1;
			if (Config.IsSocketing)
			{
				bool isSocketBlocking = Config.IsSocketBlocking;
				ushort socketPort = Config.SocketPort;
				SocketUtils.SetupConnection(isSocketBlocking, socketPort);
			}
			return true;
		}

		// Token: 0x0601AC85 RID: 109701 RVA: 0x0083CC46 File Offset: 0x0083B046
		public void Cleanup()
		{
			if (Config.IsSocketing)
			{
				SocketUtils.ShutdownConnection();
			}
			this.UnLoadAll();
			ComparerRegister.Cleanup();
			ComputerRegister.Cleanup();
			this.UnRegisterStuff();
			Context.Cleanup(-1);
			LogManager.Instance.Close();
			this.m_bInited = false;
		}

		// Token: 0x0601AC86 RID: 109702 RVA: 0x0083CC84 File Offset: 0x0083B084
		internal void RegisterStuff()
		{
			if (!this.m_bRegistered)
			{
				this.m_bRegistered = true;
				AgentMeta.Register();
			}
		}

		// Token: 0x0601AC87 RID: 109703 RVA: 0x0083CC9D File Offset: 0x0083B09D
		private void UnRegisterStuff()
		{
			this.UnRegisterBehaviorNode();
			AgentMeta.UnRegister();
			this.m_bRegistered = false;
		}

		// Token: 0x0601AC88 RID: 109704 RVA: 0x0083CCB4 File Offset: 0x0083B0B4
		public void LogWorkspaceInfo()
		{
			OperatingSystem osversion = Environment.OSVersion;
			string arg = osversion.Platform.ToString();
			string format = string.Format("[platform] {0}\n", arg);
			LogManager.Instance.LogWorkspace(format, new object[0]);
			Workspace.EFileFormat fileFormat = this.FileFormat;
			string arg2 = (fileFormat != Workspace.EFileFormat.EFF_bson) ? ((fileFormat != Workspace.EFileFormat.EFF_cs) ? "xml" : "cs") : "bson.bytes";
			format = string.Format("[workspace] {0} \"{1}\"\n", arg2, string.Empty);
			LogManager.Instance.LogWorkspace(format, new object[0]);
		}

		// Token: 0x0601AC89 RID: 109705 RVA: 0x0083CD50 File Offset: 0x0083B150
		private bool LoadWorkspaceSetting(string file, string ext, ref string workspaceFile)
		{
			try
			{
				byte[] array = this.ReadFileToBuffer(file, ext);
				if (array != null)
				{
					string @string = Encoding.UTF8.GetString(array);
					SecurityParser securityParser = new SecurityParser();
					securityParser.LoadXml(@string);
					SecurityElement securityElement = securityParser.ToXml();
					if (securityElement.Tag == "workspace")
					{
						workspaceFile = securityElement.Attribute("path");
						return true;
					}
				}
			}
			catch (Exception ex)
			{
				string text = string.Format("Load Workspace {0} Error : {1}", file, ex.Message);
			}
			return false;
		}

		// Token: 0x0601AC8A RID: 109706 RVA: 0x0083CDEC File Offset: 0x0083B1EC
		public void SetAutoHotReload(bool enable)
		{
		}

		// Token: 0x0601AC8B RID: 109707 RVA: 0x0083CDEE File Offset: 0x0083B1EE
		public bool GetAutoHotReload()
		{
			return false;
		}

		// Token: 0x0601AC8C RID: 109708 RVA: 0x0083CDF1 File Offset: 0x0083B1F1
		public void HotReload()
		{
		}

		// Token: 0x0601AC8D RID: 109709 RVA: 0x0083CDF4 File Offset: 0x0083B1F4
		private void ParseBreakpoint(string[] tokens)
		{
			Workspace.BreakpointInfo_t breakpointInfo_t = new Workspace.BreakpointInfo_t();
			bool flag = false;
			bool flag2 = false;
			if (tokens[1] == "add")
			{
				flag = true;
			}
			else if (tokens[1] == "remove")
			{
				flag2 = true;
			}
			breakpointInfo_t.btname = tokens[2];
			if (!(tokens[3] == "all"))
			{
				if (tokens[3] == "success")
				{
					breakpointInfo_t.action_result = EActionResult.EAR_success;
				}
				else if (tokens[3] == "failure")
				{
					breakpointInfo_t.action_result = EActionResult.EAR_failure;
				}
			}
			int num = tokens[4].IndexOf("Hit=");
			if (num != -1)
			{
				num = tokens[4].IndexOf('=');
				int num2 = tokens[4].IndexOf('\n');
				int length;
				if (num2 != -1)
				{
					length = num2 - num - 1;
				}
				else
				{
					length = tokens[4].Length - num - 1;
				}
				string s = tokens[4].Substring(num + 1, length);
				breakpointInfo_t.hit_config = ushort.Parse(s);
			}
			uint key = Utils.MakeVariableId(breakpointInfo_t.btname);
			if (flag)
			{
				this.m_breakpoints[key] = breakpointInfo_t;
			}
			else if (flag2)
			{
				this.m_breakpoints.Remove(key);
			}
		}

		// Token: 0x0601AC8E RID: 109710 RVA: 0x0083CF41 File Offset: 0x0083B341
		private void ParseProfiling(string[] tokens)
		{
			if (tokens[1] == "true")
			{
				Config.IsProfiling = true;
			}
			else if (tokens[1] == "false")
			{
				Config.IsProfiling = false;
			}
		}

		// Token: 0x0601AC8F RID: 109711 RVA: 0x0083CF7D File Offset: 0x0083B37D
		private void ParseAppLogFilter(string[] tokens)
		{
		}

		// Token: 0x0601AC90 RID: 109712 RVA: 0x0083CF7F File Offset: 0x0083B37F
		private void ParseProperty(string[] tokens)
		{
		}

		// Token: 0x0601AC91 RID: 109713 RVA: 0x0083CF81 File Offset: 0x0083B381
		protected void LogFrames()
		{
		}

		// Token: 0x0601AC92 RID: 109714 RVA: 0x0083CF83 File Offset: 0x0083B383
		protected void WaitforContinue()
		{
		}

		// Token: 0x0601AC93 RID: 109715 RVA: 0x0083CF88 File Offset: 0x0083B388
		protected bool HandleRequests()
		{
			return false;
		}

		// Token: 0x170022B5 RID: 8885
		// (get) Token: 0x0601AC94 RID: 109716 RVA: 0x0083CF98 File Offset: 0x0083B398
		// (set) Token: 0x0601AC95 RID: 109717 RVA: 0x0083CFA0 File Offset: 0x0083B3A0
		public bool IsExecAgents
		{
			get
			{
				return this.m_bExecAgents;
			}
			set
			{
				this.m_bExecAgents = value;
			}
		}

		// Token: 0x0601AC96 RID: 109718 RVA: 0x0083CFA9 File Offset: 0x0083B3A9
		public void DebugUpdate()
		{
			this.LogFrames();
			this.HandleRequests();
			if (Config.IsHotReload)
			{
				this.HotReload();
			}
		}

		// Token: 0x0601AC97 RID: 109719 RVA: 0x0083CFC8 File Offset: 0x0083B3C8
		public void Update()
		{
			this.DebugUpdate();
			if (this.m_bExecAgents)
			{
				int contextId = -1;
				Context.execAgents(contextId);
			}
		}

		// Token: 0x0601AC98 RID: 109720 RVA: 0x0083CFF0 File Offset: 0x0083B3F0
		public void LogCurrentStates()
		{
			int contextId = -1;
			Context.LogCurrentStates(contextId);
		}

		// Token: 0x0601AC99 RID: 109721 RVA: 0x0083D005 File Offset: 0x0083B405
		public bool CheckBreakpoint(Agent pAgent, BehaviorNode b, string action, EActionResult actionResult)
		{
			return false;
		}

		// Token: 0x0601AC9A RID: 109722 RVA: 0x0083D008 File Offset: 0x0083B408
		public bool CheckAppLogFilter(string filter)
		{
			return false;
		}

		// Token: 0x0601AC9B RID: 109723 RVA: 0x0083D00C File Offset: 0x0083B40C
		public int UpdateActionCount(string actionString)
		{
			object actions_count = this.m_actions_count;
			int result;
			lock (actions_count)
			{
				int num = 1;
				CStringID key = new CStringID(actionString);
				if (!this.m_actions_count.ContainsKey(key))
				{
					this.m_actions_count[key] = num;
				}
				else
				{
					num = this.m_actions_count[key];
					num++;
					this.m_actions_count[key] = num;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x0601AC9C RID: 109724 RVA: 0x0083D090 File Offset: 0x0083B490
		public int GetActionCount(string actionString)
		{
			object actions_count = this.m_actions_count;
			int result;
			lock (actions_count)
			{
				int num = 0;
				CStringID key = new CStringID(actionString);
				if (this.m_actions_count.ContainsKey(key))
				{
					num = this.m_actions_count[key];
				}
				result = num;
			}
			return result;
		}

		// Token: 0x170022B6 RID: 8886
		// (get) Token: 0x0601AC9D RID: 109725 RVA: 0x0083D0F4 File Offset: 0x0083B4F4
		private Dictionary<string, BehaviorTree> BehaviorTrees
		{
			get
			{
				if (this.m_behaviortrees == null)
				{
					this.m_behaviortrees = new Dictionary<string, BehaviorTree>();
				}
				return this.m_behaviortrees;
			}
		}

		// Token: 0x170022B7 RID: 8887
		// (get) Token: 0x0601AC9E RID: 109726 RVA: 0x0083D112 File Offset: 0x0083B512
		private Dictionary<string, MethodInfo> BTCreators
		{
			get
			{
				if (this.m_btCreators == null)
				{
					this.m_btCreators = new Dictionary<string, MethodInfo>();
				}
				return this.m_btCreators;
			}
		}

		// Token: 0x0601AC9F RID: 109727 RVA: 0x0083D130 File Offset: 0x0083B530
		public void RecordBTAgentMapping(string relativePath, Agent agent)
		{
			if (this.m_allBehaviorTreeTasks == null)
			{
				this.m_allBehaviorTreeTasks = new Dictionary<string, Workspace.BTItem_t>();
			}
			if (!this.m_allBehaviorTreeTasks.ContainsKey(relativePath))
			{
				this.m_allBehaviorTreeTasks[relativePath] = new Workspace.BTItem_t();
			}
			Workspace.BTItem_t btitem_t = this.m_allBehaviorTreeTasks[relativePath];
			if (btitem_t.agents.IndexOf(agent) == -1)
			{
				btitem_t.agents.Add(agent);
			}
		}

		// Token: 0x0601ACA0 RID: 109728 RVA: 0x0083D1A0 File Offset: 0x0083B5A0
		public void UnLoad(string relativePath)
		{
			if (this.BehaviorTrees.ContainsKey(relativePath))
			{
				this.BehaviorTrees.Remove(relativePath);
			}
		}

		// Token: 0x0601ACA1 RID: 109729 RVA: 0x0083D1C0 File Offset: 0x0083B5C0
		public void UnLoadAll()
		{
			this.m_allBehaviorTreeTasks.Clear();
			this.BehaviorTrees.Clear();
			this.BTCreators.Clear();
		}

		// Token: 0x0601ACA2 RID: 109730 RVA: 0x0083D1E4 File Offset: 0x0083B5E4
		public byte[] ReadFileToBuffer(string file, string ext)
		{
			return FileManager.Instance.FileOpen(file, ext);
		}

		// Token: 0x0601ACA3 RID: 109731 RVA: 0x0083D1FF File Offset: 0x0083B5FF
		public void PopFileFromBuffer(string file, string ext, byte[] pBuffer)
		{
			FileManager.Instance.FileClose(file, ext, pBuffer);
		}

		// Token: 0x0601ACA4 RID: 109732 RVA: 0x0083D20E File Offset: 0x0083B60E
		private string getValidFilename(string filename)
		{
			filename = filename.Replace("/", "_");
			filename = filename.Replace("-", "_");
			return filename;
		}

		// Token: 0x0601ACA5 RID: 109733 RVA: 0x0083D238 File Offset: 0x0083B638
		public bool Load(string relativePath, bool bForce)
		{
			this.TryInit();
			BehaviorTree behaviorTree = null;
			if (this.BehaviorTrees.ContainsKey(relativePath))
			{
				if (!bForce)
				{
					return true;
				}
				behaviorTree = this.BehaviorTrees[relativePath];
			}
			string text = Path.Combine(this.FilePath, relativePath);
			text = text.Replace('\\', '/');
			string empty = string.Empty;
			Workspace.EFileFormat fileFormat = this.FileFormat;
			this.HandleFileFormat(text, ref empty, ref fileFormat);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (behaviorTree == null)
			{
				flag3 = true;
				behaviorTree = new BehaviorTree();
				this.BehaviorTrees[relativePath] = behaviorTree;
			}
			if (fileFormat == Workspace.EFileFormat.EFF_xml || fileFormat == Workspace.EFileFormat.EFF_bson)
			{
				byte[] array = this.ReadFileToBuffer(text, empty);
				if (array != null)
				{
					if (!flag3)
					{
						flag2 = true;
						behaviorTree.Clear();
					}
					if (fileFormat == Workspace.EFileFormat.EFF_xml)
					{
						flag = behaviorTree.load_xml(array);
					}
					else
					{
						flag = behaviorTree.load_bson(array);
					}
					this.PopFileFromBuffer(text, empty, array);
				}
			}
			else if (fileFormat == Workspace.EFileFormat.EFF_cs)
			{
				if (!flag3)
				{
					flag2 = true;
					behaviorTree.Clear();
				}
				try
				{
					MethodInfo methodInfo = null;
					if (this.BTCreators.ContainsKey(relativePath))
					{
						methodInfo = this.BTCreators[relativePath];
					}
					else
					{
						string typeName = "behaviac.bt_" + this.getValidFilename(relativePath);
						Type type = Utils.GetType(typeName);
						if (type != null)
						{
							methodInfo = type.GetMethod("build_behavior_tree", BindingFlags.Static | BindingFlags.Public);
							if (methodInfo != null)
							{
								this.BTCreators[relativePath] = methodInfo;
							}
						}
					}
					if (methodInfo != null)
					{
						object[] parameters = new object[]
						{
							behaviorTree
						};
						flag = (bool)methodInfo.Invoke(null, parameters);
					}
				}
				catch (Exception ex)
				{
					string text2 = string.Format("The behavior {0} failed to be loaded : {1}", relativePath, ex.Message);
				}
			}
			if (flag)
			{
				if (!flag3)
				{
				}
			}
			else if (flag3)
			{
				bool flag4 = this.BehaviorTrees.Remove(relativePath);
			}
			else if (flag2)
			{
				this.BehaviorTrees.Remove(relativePath);
			}
			return flag;
		}

		// Token: 0x0601ACA6 RID: 109734 RVA: 0x0083D454 File Offset: 0x0083B854
		public void HandleFileFormat(string fullPath, ref string ext, ref Workspace.EFileFormat f)
		{
			if (f == Workspace.EFileFormat.EFF_default)
			{
				ext = ".xml";
				if (FileManager.Instance.FileExist(fullPath, ext))
				{
					f = Workspace.EFileFormat.EFF_xml;
				}
				else
				{
					ext = ".bson";
					if (FileManager.Instance.FileExist(fullPath, ext))
					{
						f = Workspace.EFileFormat.EFF_bson;
					}
					else
					{
						f = Workspace.EFileFormat.EFF_cs;
					}
				}
			}
			else if (f == Workspace.EFileFormat.EFF_xml || f == Workspace.EFileFormat.EFF_cs)
			{
				ext = ".xml";
			}
			else if (f == Workspace.EFileFormat.EFF_bson)
			{
				ext = ".bson";
			}
		}

		// Token: 0x0601ACA7 RID: 109735 RVA: 0x0083D4DE File Offset: 0x0083B8DE
		public bool Load(string relativePath)
		{
			return this.Load(relativePath, false);
		}

		// Token: 0x0601ACA8 RID: 109736 RVA: 0x0083D4E8 File Offset: 0x0083B8E8
		public BehaviorTree LoadBehaviorTree(string relativePath)
		{
			if (this.BehaviorTrees.ContainsKey(relativePath))
			{
				return this.BehaviorTrees[relativePath];
			}
			bool flag = this.Load(relativePath, true);
			if (flag)
			{
				return this.BehaviorTrees[relativePath];
			}
			return null;
		}

		// Token: 0x0601ACA9 RID: 109737 RVA: 0x0083D530 File Offset: 0x0083B930
		public bool IsValidPath(string relativePath)
		{
			return (relativePath[0] != '.' || (relativePath[1] != '/' && relativePath[1] != '\\')) && relativePath[0] != '/' && relativePath[0] != '\\';
		}

		// Token: 0x0601ACAA RID: 109738 RVA: 0x0083D588 File Offset: 0x0083B988
		public BehaviorTreeTask CreateBehaviorTreeTask(string relativePath)
		{
			BehaviorTree behaviorTree = null;
			if (this.BehaviorTrees.ContainsKey(relativePath))
			{
				behaviorTree = this.BehaviorTrees[relativePath];
			}
			else
			{
				bool flag = this.Load(relativePath);
				if (flag)
				{
					behaviorTree = this.BehaviorTrees[relativePath];
				}
			}
			if (behaviorTree != null)
			{
				BehaviorTask behaviorTask = behaviorTree.CreateAndInitTask();
				BehaviorTreeTask behaviorTreeTask = behaviorTask as BehaviorTreeTask;
				if (!this.m_allBehaviorTreeTasks.ContainsKey(relativePath))
				{
					this.m_allBehaviorTreeTasks[relativePath] = new Workspace.BTItem_t();
				}
				Workspace.BTItem_t btitem_t = this.m_allBehaviorTreeTasks[relativePath];
				if (!btitem_t.bts.Contains(behaviorTreeTask))
				{
					btitem_t.bts.Add(behaviorTreeTask);
				}
				return behaviorTreeTask;
			}
			return null;
		}

		// Token: 0x0601ACAB RID: 109739 RVA: 0x0083D63C File Offset: 0x0083BA3C
		public void DestroyBehaviorTreeTask(BehaviorTreeTask behaviorTreeTask, Agent agent)
		{
			if (behaviorTreeTask != null)
			{
				if (this.m_allBehaviorTreeTasks.ContainsKey(behaviorTreeTask.GetName()))
				{
					Workspace.BTItem_t btitem_t = this.m_allBehaviorTreeTasks[behaviorTreeTask.GetName()];
					btitem_t.bts.Remove(behaviorTreeTask);
					if (!object.ReferenceEquals(agent, null))
					{
						btitem_t.agents.Remove(agent);
					}
				}
				BehaviorTask.DestroyTask(behaviorTreeTask);
			}
		}

		// Token: 0x0601ACAC RID: 109740 RVA: 0x0083D6A3 File Offset: 0x0083BAA3
		public Dictionary<string, BehaviorTree> GetBehaviorTrees()
		{
			return this.m_behaviortrees;
		}

		// Token: 0x0601ACAD RID: 109741 RVA: 0x0083D6AB File Offset: 0x0083BAAB
		private void UnRegisterBehaviorNode()
		{
			this.m_behaviorNodeTypes.Clear();
		}

		// Token: 0x0601ACAE RID: 109742 RVA: 0x0083D6B8 File Offset: 0x0083BAB8
		public BehaviorNode CreateBehaviorNode(string className)
		{
			Type type;
			if (this.m_behaviorNodeTypes.ContainsKey(className))
			{
				type = this.m_behaviorNodeTypes[className];
			}
			else
			{
				string name = "behaviac." + className.Replace("::", ".");
				type = this.CallingAssembly.GetType(name, false);
				if (type == null)
				{
					type = this.CallingAssembly.GetType(className, false);
				}
				if (type != null)
				{
					this.m_behaviorNodeTypes[className] = type;
				}
			}
			if (type != null)
			{
				object obj = Activator.CreateInstance(type);
				return obj as BehaviorNode;
			}
			return null;
		}

		// Token: 0x170022B8 RID: 8888
		// (get) Token: 0x0601ACAF RID: 109743 RVA: 0x0083D74F File Offset: 0x0083BB4F
		private Assembly CallingAssembly
		{
			get
			{
				if (this.m_callingAssembly == null)
				{
					this.m_callingAssembly = Assembly.GetCallingAssembly();
				}
				return this.m_callingAssembly;
			}
		}

		// Token: 0x0601ACB0 RID: 109744 RVA: 0x0083D76D File Offset: 0x0083BB6D
		public bool ExportMetas(string xmlMetaFilePath, bool onlyExportPublicMembers)
		{
			return false;
		}

		// Token: 0x0601ACB1 RID: 109745 RVA: 0x0083D770 File Offset: 0x0083BB70
		public bool ExportMetas(string exportPathRelativeToWorkspace)
		{
			return this.ExportMetas(exportPathRelativeToWorkspace, false);
		}

		// Token: 0x04012A34 RID: 76340
		private static Workspace ms_instance;

		// Token: 0x04012A35 RID: 76341
		private Workspace.EFileFormat fileFormat_ = Workspace.EFileFormat.EFF_xml;

		// Token: 0x04012A36 RID: 76342
		private string m_filePath;

		// Token: 0x04012A37 RID: 76343
		private string m_metaFile;

		// Token: 0x04012A38 RID: 76344
		private int m_frameSinceStartup = -1;

		// Token: 0x04012A39 RID: 76345
		private bool _useIntValue;

		// Token: 0x04012A3A RID: 76346
		private double m_doubleValueSinceStartup = -1.0;

		// Token: 0x04012A3B RID: 76347
		private long m_intValueSinceStartup = -1L;

		// Token: 0x04012A3E RID: 76350
		private bool m_bRegistered;

		// Token: 0x04012A3F RID: 76351
		private bool m_bInited;

		// Token: 0x04012A40 RID: 76352
		private Dictionary<uint, Workspace.BreakpointInfo_t> m_breakpoints = new Dictionary<uint, Workspace.BreakpointInfo_t>();

		// Token: 0x04012A41 RID: 76353
		private Dictionary<CStringID, int> m_actions_count = new Dictionary<CStringID, int>();

		// Token: 0x04012A42 RID: 76354
		private int m_frame;

		// Token: 0x04012A43 RID: 76355
		private bool m_bExecAgents;

		// Token: 0x04012A44 RID: 76356
		private Dictionary<string, BehaviorTree> m_behaviortrees;

		// Token: 0x04012A45 RID: 76357
		private Dictionary<string, MethodInfo> m_btCreators;

		// Token: 0x04012A46 RID: 76358
		private Dictionary<string, Workspace.BTItem_t> m_allBehaviorTreeTasks = new Dictionary<string, Workspace.BTItem_t>();

		// Token: 0x04012A47 RID: 76359
		private Dictionary<string, Type> m_behaviorNodeTypes = new Dictionary<string, Type>();

		// Token: 0x04012A48 RID: 76360
		private Assembly m_callingAssembly;

		// Token: 0x020048BD RID: 18621
		[Flags]
		public enum EFileFormat
		{
			// Token: 0x04012A4A RID: 76362
			EFF_xml = 1,
			// Token: 0x04012A4B RID: 76363
			EFF_bson = 2,
			// Token: 0x04012A4C RID: 76364
			EFF_cs = 4,
			// Token: 0x04012A4D RID: 76365
			EFF_default = 7
		}

		// Token: 0x020048BE RID: 18622
		// (Invoke) Token: 0x0601ACB4 RID: 109748
		public delegate void BehaviorNodeLoader(string nodeType, List<property_t> properties);

		// Token: 0x020048BF RID: 18623
		// (Invoke) Token: 0x0601ACB8 RID: 109752
		public delegate void DRespondToBreakHandler(string msg, string title);

		// Token: 0x020048C0 RID: 18624
		private class BreakpointInfo_t
		{
			// Token: 0x0601ACBB RID: 109755 RVA: 0x0083D77C File Offset: 0x0083BB7C
			public BreakpointInfo_t()
			{
				this.hit_config = 0;
				this.action_result = EActionResult.EAR_all;
			}

			// Token: 0x04012A4E RID: 76366
			public string btname;

			// Token: 0x04012A4F RID: 76367
			public ushort hit_config;

			// Token: 0x04012A50 RID: 76368
			public EActionResult action_result;
		}

		// Token: 0x020048C1 RID: 18625
		private class BTItem_t
		{
			// Token: 0x04012A51 RID: 76369
			public List<BehaviorTreeTask> bts = new List<BehaviorTreeTask>();

			// Token: 0x04012A52 RID: 76370
			public List<Agent> agents = new List<Agent>();
		}
	}
}
