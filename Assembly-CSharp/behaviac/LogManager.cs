using System;
using System.IO;

namespace behaviac
{
	// Token: 0x02004763 RID: 18275
	public class LogManager : IDisposable
	{
		// Token: 0x0601A445 RID: 107589 RVA: 0x0082674C File Offset: 0x00824B4C
		public LogManager()
		{
			LogManager.ms_instance = this;
		}

		// Token: 0x0601A446 RID: 107590 RVA: 0x0082675A File Offset: 0x00824B5A
		public void Dispose()
		{
			LogManager.ms_instance = null;
		}

		// Token: 0x1700226C RID: 8812
		// (get) Token: 0x0601A447 RID: 107591 RVA: 0x00826764 File Offset: 0x00824B64
		public static LogManager Instance
		{
			get
			{
				if (LogManager.ms_instance == null)
				{
					LogManager logManager = new LogManager();
				}
				return LogManager.ms_instance;
			}
		}

		// Token: 0x0601A448 RID: 107592 RVA: 0x00826786 File Offset: 0x00824B86
		public void SetLogFilePath(string logFilePath)
		{
		}

		// Token: 0x0601A449 RID: 107593 RVA: 0x00826788 File Offset: 0x00824B88
		public void Log(Agent pAgent, string btMsg, EActionResult actionResult, LogMode mode)
		{
		}

		// Token: 0x0601A44A RID: 107594 RVA: 0x0082678A File Offset: 0x00824B8A
		public void PLanningClearCache()
		{
		}

		// Token: 0x0601A44B RID: 107595 RVA: 0x0082678C File Offset: 0x00824B8C
		public void Log(Agent pAgent, string typeName, string varName, string value)
		{
		}

		// Token: 0x0601A44C RID: 107596 RVA: 0x0082678E File Offset: 0x00824B8E
		public void Log(Agent pAgent, string btMsg, long time)
		{
		}

		// Token: 0x0601A44D RID: 107597 RVA: 0x00826790 File Offset: 0x00824B90
		public void Log(LogMode mode, string filterString, string format, params object[] args)
		{
		}

		// Token: 0x0601A44E RID: 107598 RVA: 0x00826792 File Offset: 0x00824B92
		public void Log(string format, params object[] args)
		{
		}

		// Token: 0x0601A44F RID: 107599 RVA: 0x00826794 File Offset: 0x00824B94
		public void LogWorkspace(string format, params object[] args)
		{
		}

		// Token: 0x0601A450 RID: 107600 RVA: 0x00826796 File Offset: 0x00824B96
		public void LogVarValue(Agent pAgent, string name, object value)
		{
		}

		// Token: 0x0601A451 RID: 107601 RVA: 0x00826798 File Offset: 0x00824B98
		public void Warning(string format, params object[] args)
		{
			this.Log(LogMode.ELM_log, "warning", format, args);
		}

		// Token: 0x0601A452 RID: 107602 RVA: 0x008267A8 File Offset: 0x00824BA8
		public void Error(string format, params object[] args)
		{
			this.Log(LogMode.ELM_log, "error", format, args);
		}

		// Token: 0x0601A453 RID: 107603 RVA: 0x008267B8 File Offset: 0x00824BB8
		public void Flush(Agent pAgent)
		{
		}

		// Token: 0x0601A454 RID: 107604 RVA: 0x008267BA File Offset: 0x00824BBA
		public void Close()
		{
		}

		// Token: 0x0601A455 RID: 107605 RVA: 0x008267BC File Offset: 0x00824BBC
		protected virtual StreamWriter GetFile(Agent pAgent)
		{
			return null;
		}

		// Token: 0x0601A456 RID: 107606 RVA: 0x008267BF File Offset: 0x00824BBF
		private void Output(Agent pAgent, string msg)
		{
		}

		// Token: 0x0401270B RID: 75531
		private static LogManager ms_instance;
	}
}
