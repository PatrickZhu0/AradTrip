using System;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;

// Token: 0x02001561 RID: 5473
public class VoiceDataHelper
{
	// Token: 0x0600D5B3 RID: 54707 RVA: 0x003567D4 File Offset: 0x00354BD4
	public static void SaveVoiceInfoTemp(ChatVoiceSendInfo voiceInfo)
	{
		if (voiceInfo == null)
		{
			return;
		}
		if (string.IsNullOrEmpty(voiceInfo.VoicePath) || string.IsNullOrEmpty(voiceInfo.VoiceKey))
		{
			return;
		}
		try
		{
			if (VoiceDataHelper.VoiceCacheInfo.Count > 20)
			{
				VoiceDataHelper.VoiceCacheInfo.RemoveAt(0);
			}
			ChatVoiceCacheInfo chatVoiceCacheInfo = new ChatVoiceCacheInfo();
			chatVoiceCacheInfo.VoiceKey = voiceInfo.VoiceKey;
			chatVoiceCacheInfo.VoicePath = voiceInfo.VoicePath;
			VoiceDataHelper.VoiceCacheInfo.Add(chatVoiceCacheInfo);
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("[Error Save Voice] - {0}", new object[]
			{
				ex.ToString()
			});
		}
	}

	// Token: 0x0600D5B4 RID: 54708 RVA: 0x00356884 File Offset: 0x00354C84
	public static string GetVoicePathWithKey(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return string.Empty;
		}
		for (int i = 0; i < VoiceDataHelper.VoiceCacheInfo.Count; i++)
		{
			if (VoiceDataHelper.VoiceCacheInfo[i].VoiceKey == key)
			{
				return VoiceDataHelper.VoiceCacheInfo[i].VoicePath;
			}
		}
		return string.Empty;
	}

	// Token: 0x0600D5B5 RID: 54709 RVA: 0x003568F0 File Offset: 0x00354CF0
	public static void DeleteAllVoiceInfoTemp()
	{
		string path = Path.Combine(VoiceDataHelper.saveLocalPath, VoiceDataHelper.voiceTempJson);
		if (Directory.Exists(VoiceDataHelper.saveLocalPath))
		{
			Directory.Delete(VoiceDataHelper.saveLocalPath, true);
			Directory.CreateDirectory(VoiceDataHelper.saveLocalPath);
		}
		if (File.Exists(path))
		{
			File.Delete(path);
		}
	}

	// Token: 0x0600D5B6 RID: 54710 RVA: 0x00356944 File Offset: 0x00354D44
	private static ChatVoiceSendInfo TraverseFindVoiceData(List<string> jsons, string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return null;
		}
		if (jsons != null)
		{
			for (int i = jsons.Count - 1; i >= 0; i--)
			{
				if (!(jsons[i] == string.Empty))
				{
					JsonData jsonData = JsonMapper.ToObject(jsons[i]);
					if (string.Compare(jsonData["key"].ToString(), key) == 0)
					{
						return new ChatVoiceSendInfo
						{
							VoiceKey = jsonData["key"].ToString(),
							VoicePath = jsonData["filepath"].ToString()
						};
					}
				}
			}
		}
		return null;
	}

	// Token: 0x0600D5B7 RID: 54711 RVA: 0x003569F7 File Offset: 0x00354DF7
	public static string Base64Encode(byte[] bytes)
	{
		return Convert.ToBase64String(bytes);
	}

	// Token: 0x0600D5B8 RID: 54712 RVA: 0x003569FF File Offset: 0x00354DFF
	public static byte[] Base64DecodeToBytes(string base64EncodeDate)
	{
		return Convert.FromBase64String(base64EncodeDate);
	}

	// Token: 0x0600D5B9 RID: 54713 RVA: 0x00356A08 File Offset: 0x00354E08
	public static byte GetByteVoiceDuration(int duration)
	{
		float num = (float)(duration / 1000);
		float num2 = num + 0.5f;
		int num3 = (int)Mathf.Floor(num2);
		return (byte)num3;
	}

	// Token: 0x0600D5BA RID: 54714 RVA: 0x00356A30 File Offset: 0x00354E30
	public static int GetIntVoiceDuration(byte duration)
	{
		return (int)duration * 1000;
	}

	// Token: 0x0600D5BB RID: 54715 RVA: 0x00356A48 File Offset: 0x00354E48
	public static string RecoginizeTextLengthLimit(string text)
	{
		int length = text.Length;
		int num = 33;
		if (int.TryParse(TR.Value("voice_sdk_chat_fontcount"), out num) && length > num)
		{
			string str = text.Substring(0, num);
			return str + "...";
		}
		return text;
	}

	// Token: 0x04007D77 RID: 32119
	public static float CheckRecoginizeTimeout = 5f;

	// Token: 0x04007D78 RID: 32120
	public static float VoiceInputBtnMoveupThreshold = (float)Screen.height * 0.05f;

	// Token: 0x04007D79 RID: 32121
	public static float VoiuceInputBtnMoveDownThreshold = VoiceDataHelper.VoiceInputBtnMoveupThreshold * 0.5f;

	// Token: 0x04007D7A RID: 32122
	public static int HttpRequesetTimeout = 5000;

	// Token: 0x04007D7B RID: 32123
	public static readonly float VoiceInputBtnOffset = 132f;

	// Token: 0x04007D7C RID: 32124
	public static float VoicePlayBtnTexDuration = 0.5f;

	// Token: 0x04007D7D RID: 32125
	public static float VoiceRecordTexDuration = 0.25f;

	// Token: 0x04007D7E RID: 32126
	public static List<ChatVoiceCacheInfo> VoiceCacheInfo = new List<ChatVoiceCacheInfo>();

	// Token: 0x04007D7F RID: 32127
	public static readonly string currDateTime = string.Format("{0:yyyy-MM-dd-HH_mm_ss_ffff}", DateTime.Now);

	// Token: 0x04007D80 RID: 32128
	public static readonly string currDateTime_less = string.Format("{0:yyyy-MM-dd}", DateTime.Now);

	// Token: 0x04007D81 RID: 32129
	public static readonly string saveLocalPath = Application.persistentDataPath + "/recordVoiceCache/";

	// Token: 0x04007D82 RID: 32130
	public static readonly string voiceTempJson = "voiceTemp.json";
}
