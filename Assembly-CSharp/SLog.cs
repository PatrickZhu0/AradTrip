using System;

// Token: 0x0200022C RID: 556
public class SLog
{
	// Token: 0x06001296 RID: 4758 RVA: 0x00063EEC File Offset: 0x000622EC
	public static void Close()
	{
		SLog.logObj.Close();
	}

	// Token: 0x06001297 RID: 4759 RVA: 0x00063EF8 File Offset: 0x000622F8
	public static void Flush()
	{
		SLog.logObj.Flush();
	}

	// Token: 0x06001298 RID: 4760 RVA: 0x00063F04 File Offset: 0x00062304
	public static void Log(string str)
	{
		SLog.logObj.Log(str);
	}

	// Token: 0x17000219 RID: 537
	// (get) Token: 0x06001299 RID: 4761 RVA: 0x00063F11 File Offset: 0x00062311
	// (set) Token: 0x0600129A RID: 4762 RVA: 0x00063F1D File Offset: 0x0006231D
	public static string TargetPath
	{
		get
		{
			return SLog.logObj.TargetPath;
		}
		set
		{
			SLog.logObj.TargetPath = value;
		}
	}

	// Token: 0x04000C4F RID: 3151
	private static SLogObj logObj = new SLogObj();
}
