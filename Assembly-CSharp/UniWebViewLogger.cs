using System;
using UnityEngine;

// Token: 0x02004A41 RID: 19009
public class UniWebViewLogger
{
	// Token: 0x0601B776 RID: 112502 RVA: 0x008776BA File Offset: 0x00875ABA
	private UniWebViewLogger(UniWebViewLogger.Level level)
	{
		this.level = level;
	}

	// Token: 0x17002461 RID: 9313
	// (get) Token: 0x0601B777 RID: 112503 RVA: 0x008776C9 File Offset: 0x00875AC9
	// (set) Token: 0x0601B778 RID: 112504 RVA: 0x008776D1 File Offset: 0x00875AD1
	public UniWebViewLogger.Level LogLevel
	{
		get
		{
			return this.level;
		}
		set
		{
			this.Log(UniWebViewLogger.Level.Off, "Setting UniWebView logger level to: " + value);
			this.level = value;
			UniWebViewInterface.SetLogLevel((int)value);
		}
	}

	// Token: 0x17002462 RID: 9314
	// (get) Token: 0x0601B779 RID: 112505 RVA: 0x008776F8 File Offset: 0x00875AF8
	public static UniWebViewLogger Instance
	{
		get
		{
			if (UniWebViewLogger.instance == null)
			{
				UniWebViewLogger.instance = new UniWebViewLogger(UniWebViewLogger.Level.Critical);
			}
			return UniWebViewLogger.instance;
		}
	}

	// Token: 0x0601B77A RID: 112506 RVA: 0x00877715 File Offset: 0x00875B15
	public void Verbose(string message)
	{
		this.Log(UniWebViewLogger.Level.Verbose, message);
	}

	// Token: 0x0601B77B RID: 112507 RVA: 0x0087771F File Offset: 0x00875B1F
	public void Debug(string message)
	{
		this.Log(UniWebViewLogger.Level.Debug, message);
	}

	// Token: 0x0601B77C RID: 112508 RVA: 0x0087772A File Offset: 0x00875B2A
	public void Info(string message)
	{
		this.Log(UniWebViewLogger.Level.Info, message);
	}

	// Token: 0x0601B77D RID: 112509 RVA: 0x00877735 File Offset: 0x00875B35
	public void Critical(string message)
	{
		this.Log(UniWebViewLogger.Level.Critical, message);
	}

	// Token: 0x0601B77E RID: 112510 RVA: 0x00877740 File Offset: 0x00875B40
	private void Log(UniWebViewLogger.Level level, string message)
	{
		if (level >= this.LogLevel)
		{
			string text = "<UniWebView> " + message;
			if (level == UniWebViewLogger.Level.Critical)
			{
				UnityEngine.Debug.LogError(text);
			}
		}
	}

	// Token: 0x040131B8 RID: 78264
	private static UniWebViewLogger instance;

	// Token: 0x040131B9 RID: 78265
	private UniWebViewLogger.Level level;

	// Token: 0x02004A42 RID: 19010
	public enum Level
	{
		// Token: 0x040131BB RID: 78267
		Verbose,
		// Token: 0x040131BC RID: 78268
		Debug = 10,
		// Token: 0x040131BD RID: 78269
		Info = 20,
		// Token: 0x040131BE RID: 78270
		Critical = 80,
		// Token: 0x040131BF RID: 78271
		Off = 99
	}
}
