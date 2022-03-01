using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02004A43 RID: 19011
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct UniWebViewMessage
{
	// Token: 0x0601B77F RID: 112511 RVA: 0x00877778 File Offset: 0x00875B78
	public UniWebViewMessage(string rawMessage)
	{
		this = default(UniWebViewMessage);
		UniWebViewLogger.Instance.Debug("Try to parse raw message: " + rawMessage);
		this.RawMessage = WWW.UnEscapeURL(rawMessage);
		string[] array = rawMessage.Split(new string[]
		{
			"://"
		}, StringSplitOptions.None);
		if (array.Length >= 2)
		{
			this.Scheme = array[0];
			UniWebViewLogger.Instance.Debug("Get scheme: " + this.Scheme);
			string text = string.Empty;
			for (int i = 1; i < array.Length; i++)
			{
				text += array[i];
			}
			UniWebViewLogger.Instance.Verbose("Build path and args string: " + text);
			string[] array2 = text.Split(new char[]
			{
				"?"[0]
			});
			this.Path = WWW.UnEscapeURL(array2[0].TrimEnd(new char[]
			{
				'/'
			}));
			this.Args = new Dictionary<string, string>();
			if (array2.Length > 1)
			{
				foreach (string text2 in array2[1].Split(new char[]
				{
					"&"[0]
				}))
				{
					string[] array4 = text2.Split(new char[]
					{
						"="[0]
					});
					if (array4.Length > 1)
					{
						string text3 = WWW.UnEscapeURL(array4[0]);
						if (this.Args.ContainsKey(text3))
						{
							string str = this.Args[text3];
							this.Args[text3] = str + "," + WWW.UnEscapeURL(array4[1]);
						}
						else
						{
							this.Args[text3] = WWW.UnEscapeURL(array4[1]);
						}
						UniWebViewLogger.Instance.Debug("Get arg, key: " + text3 + " value: " + this.Args[text3]);
					}
				}
			}
		}
		else
		{
			UniWebViewLogger.Instance.Critical("Bad url scheme. Can not be parsed to UniWebViewMessage: " + rawMessage);
		}
	}

	// Token: 0x17002463 RID: 9315
	// (get) Token: 0x0601B780 RID: 112512 RVA: 0x00877985 File Offset: 0x00875D85
	// (set) Token: 0x0601B781 RID: 112513 RVA: 0x0087798D File Offset: 0x00875D8D
	public string RawMessage { get; private set; }

	// Token: 0x17002464 RID: 9316
	// (get) Token: 0x0601B782 RID: 112514 RVA: 0x00877996 File Offset: 0x00875D96
	// (set) Token: 0x0601B783 RID: 112515 RVA: 0x0087799E File Offset: 0x00875D9E
	public string Scheme { get; private set; }

	// Token: 0x17002465 RID: 9317
	// (get) Token: 0x0601B784 RID: 112516 RVA: 0x008779A7 File Offset: 0x00875DA7
	// (set) Token: 0x0601B785 RID: 112517 RVA: 0x008779AF File Offset: 0x00875DAF
	public string Path { get; private set; }

	// Token: 0x17002466 RID: 9318
	// (get) Token: 0x0601B786 RID: 112518 RVA: 0x008779B8 File Offset: 0x00875DB8
	// (set) Token: 0x0601B787 RID: 112519 RVA: 0x008779C0 File Offset: 0x00875DC0
	public Dictionary<string, string> Args { get; private set; }
}
