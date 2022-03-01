using System;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;

namespace YouMe
{
	// Token: 0x02004AE3 RID: 19171
	public class YouMeVoiceAPI
	{
		// Token: 0x0601BDE4 RID: 114148 RVA: 0x00888A91 File Offset: 0x00886E91
		private YouMeVoiceAPI()
		{
			this.instance_youme_java = new AndroidJavaClass("com.youme.voiceengine.api");
		}

		// Token: 0x0601BDE5 RID: 114149
		[DllImport("youme_voice_engine")]
		private static extern int youme_init(string strAPPKey, string strAPPSecret, int serverRegionId, string strExtServerRegionName);

		// Token: 0x0601BDE6 RID: 114150
		[DllImport("youme_voice_engine")]
		private static extern int youme_unInit();

		// Token: 0x0601BDE7 RID: 114151
		[DllImport("youme_voice_engine")]
		private static extern IntPtr youme_getCbMessage();

		// Token: 0x0601BDE8 RID: 114152
		[DllImport("youme_voice_engine")]
		private static extern void youme_freeCbMessage(IntPtr pMsg);

		// Token: 0x0601BDE9 RID: 114153
		[DllImport("youme_voice_engine")]
		private static extern int youme_setOutputToSpeaker(bool bOutputToSpeaker);

		// Token: 0x0601BDEA RID: 114154
		[DllImport("youme_voice_engine")]
		private static extern void youme_setSpeakerMute(bool bOn);

		// Token: 0x0601BDEB RID: 114155
		[DllImport("youme_voice_engine")]
		private static extern bool youme_getSpeakerMute();

		// Token: 0x0601BDEC RID: 114156
		[DllImport("youme_voice_engine")]
		private static extern bool youme_getMicrophoneMute();

		// Token: 0x0601BDED RID: 114157
		[DllImport("youme_voice_engine")]
		private static extern void youme_setMicrophoneMute(bool mute);

		// Token: 0x0601BDEE RID: 114158
		[DllImport("youme_voice_engine")]
		private static extern void youme_setAutoSendStatus(bool bAutoSend);

		// Token: 0x0601BDEF RID: 114159
		[DllImport("youme_voice_engine")]
		private static extern int youme_getVolume();

		// Token: 0x0601BDF0 RID: 114160
		[DllImport("youme_voice_engine")]
		private static extern void youme_setVolume(uint uiVolume);

		// Token: 0x0601BDF1 RID: 114161
		[DllImport("youme_voice_engine")]
		private static extern bool youme_getUseMobileNetworkEnabled();

		// Token: 0x0601BDF2 RID: 114162
		[DllImport("youme_voice_engine")]
		private static extern void youme_setUseMobileNetworkEnabled(bool bEnabled);

		// Token: 0x0601BDF3 RID: 114163
		[DllImport("youme_voice_engine")]
		private static extern int youme_joinChannelSingleMode(string strUserID, string strChannelID, int userRole, bool bCheckRoomExist);

		// Token: 0x0601BDF4 RID: 114164
		[DllImport("youme_voice_engine")]
		private static extern int youme_joinChannelMultiMode(string strUserID, string strChannelID, int userRole, bool bCheckRoomExist);

		// Token: 0x0601BDF5 RID: 114165
		[DllImport("youme_voice_engine")]
		private static extern int youme_speakToChannel(string strChannelID);

		// Token: 0x0601BDF6 RID: 114166
		[DllImport("youme_voice_engine")]
		private static extern int youme_leaveChannelMultiMode(string strChannelID);

		// Token: 0x0601BDF7 RID: 114167
		[DllImport("youme_voice_engine")]
		private static extern int youme_leaveChannelAll();

		// Token: 0x0601BDF8 RID: 114168
		[DllImport("youme_voice_engine")]
		private static extern int youme_setPcmCallback(YouMeVoiceAPI.UnityPcmCallbackDelegate unityPcmCallback, bool bOutputToSpeaker);

		// Token: 0x0601BDF9 RID: 114169
		[DllImport("youme_voice_engine")]
		private static extern int youme_setOtherMicMute(string userID, bool mute);

		// Token: 0x0601BDFA RID: 114170
		[DllImport("youme_voice_engine")]
		private static extern int youme_setOtherSpeakerMute(string userID, bool mute);

		// Token: 0x0601BDFB RID: 114171
		[DllImport("youme_voice_engine")]
		private static extern int youme_setListenOtherVoice(string userID, bool isOn);

		// Token: 0x0601BDFC RID: 114172
		[DllImport("youme_voice_engine")]
		private static extern void youme_setServerRegion(int regionId, string strExtRegionId, bool bAppend);

		// Token: 0x0601BDFD RID: 114173
		[DllImport("youme_voice_engine")]
		private static extern int youme_playBackgroundMusic(string pFilePath, bool bRepeat);

		// Token: 0x0601BDFE RID: 114174
		[DllImport("youme_voice_engine")]
		private static extern int youme_pauseBackgroundMusic();

		// Token: 0x0601BDFF RID: 114175
		[DllImport("youme_voice_engine")]
		private static extern int youme_resumeBackgroundMusic();

		// Token: 0x0601BE00 RID: 114176
		[DllImport("youme_voice_engine")]
		private static extern int youme_stopBackgroundMusic();

		// Token: 0x0601BE01 RID: 114177
		[DllImport("youme_voice_engine")]
		private static extern int youme_setBackgroundMusicVolume(int volume);

		// Token: 0x0601BE02 RID: 114178
		[DllImport("youme_voice_engine")]
		private static extern int youme_setHeadsetMonitorOn(bool micEnabled, bool bgmEnabled);

		// Token: 0x0601BE03 RID: 114179
		[DllImport("youme_voice_engine")]
		private static extern int youme_setReverbEnabled(bool enabled);

		// Token: 0x0601BE04 RID: 114180
		[DllImport("youme_voice_engine")]
		private static extern int youme_setVadCallbackEnabled(bool enabled);

		// Token: 0x0601BE05 RID: 114181
		[DllImport("youme_voice_engine")]
		private static extern int youme_setMicLevelCallback(int maxLevel);

		// Token: 0x0601BE06 RID: 114182
		[DllImport("youme_voice_engine")]
		private static extern int youme_pauseChannel();

		// Token: 0x0601BE07 RID: 114183
		[DllImport("youme_voice_engine")]
		private static extern int youme_resumeChannel();

		// Token: 0x0601BE08 RID: 114184
		[DllImport("youme_voice_engine")]
		private static extern float youme_getSoundtouchPitchSemiTones();

		// Token: 0x0601BE09 RID: 114185
		[DllImport("youme_voice_engine")]
		private static extern int youme_setSoundtouchPitchSemiTones(float fPitchSemiTones);

		// Token: 0x0601BE0A RID: 114186
		[DllImport("youme_voice_engine")]
		private static extern void youme_setRecordingTimeMs(uint timeMs);

		// Token: 0x0601BE0B RID: 114187
		[DllImport("youme_voice_engine")]
		private static extern void youme_setPlayingTimeMs(uint timeMs);

		// Token: 0x0601BE0C RID: 114188
		[DllImport("youme_voice_engine")]
		private static extern int youme_getSDKVersion();

		// Token: 0x0601BE0D RID: 114189
		[DllImport("youme_voice_engine")]
		private static extern int youme_requestRestApi(string strCommand, string strQueryBody, ref int requestID);

		// Token: 0x0601BE0E RID: 114190
		[DllImport("youme_voice_engine")]
		private static extern int youme_getChannelUserList(string strChannelID, int maxCount, bool notifyMemChange);

		// Token: 0x0601BE0F RID: 114191
		[DllImport("youme_voice_engine")]
		private static extern int youme_setToken(string strToken);

		// Token: 0x0601BE10 RID: 114192
		[DllImport("youme_voice_engine")]
		private static extern int youme_setReleaseMicWhenMute(bool enabled);

		// Token: 0x0601BE11 RID: 114193
		[DllImport("youme_voice_engine")]
		private static extern int youme_setGrabMicOption(string pChannelID, int mode, int maxAllowCount, int maxTalkTime, uint voteTime);

		// Token: 0x0601BE12 RID: 114194
		[DllImport("youme_voice_engine")]
		private static extern int youme_startGrabMicAction(string pChannelID, string pContent);

		// Token: 0x0601BE13 RID: 114195
		[DllImport("youme_voice_engine")]
		private static extern int youme_stopGrabMicAction(string pChannelID, string pContent);

		// Token: 0x0601BE14 RID: 114196
		[DllImport("youme_voice_engine")]
		private static extern int youme_requestGrabMic(string pChannelID, int score, bool isAutoOpenMic, string pContent);

		// Token: 0x0601BE15 RID: 114197
		[DllImport("youme_voice_engine")]
		private static extern int youme_releaseGrabMic(string pChannelID);

		// Token: 0x0601BE16 RID: 114198
		[DllImport("youme_voice_engine")]
		private static extern int youme_setInviteMicOption(string pChannelID, int waitTimeout, int maxTalkTime);

		// Token: 0x0601BE17 RID: 114199
		[DllImport("youme_voice_engine")]
		private static extern int youme_requestInviteMic(string pChannelID, string pUserID, string pContent);

		// Token: 0x0601BE18 RID: 114200
		[DllImport("youme_voice_engine")]
		private static extern int youme_responseInviteMic(string pUserID, bool isAccept, string pContent);

		// Token: 0x0601BE19 RID: 114201
		[DllImport("youme_voice_engine")]
		private static extern int youme_stopInviteMic();

		// Token: 0x0601BE1A RID: 114202
		[DllImport("youme_voice_engine")]
		private static extern int youme_sendMessage(string pChannelID, string pContent, ref int requestID);

		// Token: 0x0601BE1B RID: 114203
		[DllImport("youme_voice_engine")]
		private static extern int youme_setWhiteUserList(string pChannelID, string pWhiteUserList);

		// Token: 0x0601BE1C RID: 114204
		[DllImport("youme_voice_engine")]
		private static extern int youme_kickOtherFromChannel(string pUserID, string pChannelID, int lastTime);

		// Token: 0x0601BE1D RID: 114205
		[DllImport("youme_voice_engine")]
		private static extern bool youme_releaseMicSync();

		// Token: 0x0601BE1E RID: 114206
		[DllImport("youme_voice_engine")]
		private static extern bool youme_resumeMicSync();

		// Token: 0x0601BE1F RID: 114207 RVA: 0x00888AAC File Offset: 0x00886EAC
		private void ParseJsonCallbackMessage(string strMessage)
		{
			string text = null;
			string text2 = null;
			JsonData jsonData = JsonMapper.ToObject(strMessage);
			switch ((int)jsonData["type"])
			{
			case 0:
			{
				text = "OnEvent";
				int num = (int)jsonData["event"];
				int num2 = (int)jsonData["error"];
				string text3 = (string)jsonData["channelid"];
				string text4 = (string)jsonData["param"];
				text2 = string.Concat(new object[]
				{
					string.Empty,
					num,
					",",
					num2,
					",",
					text3,
					",",
					text4
				});
				break;
			}
			case 1:
				text = "OnRequestRestApi";
				text2 = strMessage;
				break;
			case 2:
				text = "OnMemberChange";
				text2 = strMessage;
				break;
			case 3:
			{
				text = "OnBroadcast";
				int num3 = (int)jsonData["bc"];
				string text5 = (string)jsonData["channelid"];
				string text6 = (string)jsonData["param1"];
				string text7 = (string)jsonData["param2"];
				string text8 = (string)jsonData["content"];
				text2 = string.Concat(new object[]
				{
					string.Empty,
					num3,
					",",
					text5,
					",",
					text6,
					",",
					text7,
					",",
					text8
				});
				break;
			}
			}
			if (this.mCallbackObjName != null && text != null && text2 != null)
			{
				GameObject gameObject = GameObject.Find(this.mCallbackObjName);
				if (gameObject != null)
				{
					gameObject.SendMessage(text, text2);
				}
			}
		}

		// Token: 0x0601BE20 RID: 114208 RVA: 0x00888C9C File Offset: 0x0088709C
		[MonoPInvokeCallback(typeof(YouMeVoiceAPI.UnityPcmCallbackDelegate))]
		private static void UnityPcmCallBackFunc(IntPtr param)
		{
			YouMeVoiceAPI.UnityPcmCallbackData unityPcmCallbackData = (YouMeVoiceAPI.UnityPcmCallbackData)Marshal.PtrToStructure(param, typeof(YouMeVoiceAPI.UnityPcmCallbackData));
			if (YouMeVoiceAPI.mPcmCallback != null)
			{
				YouMeVoiceAPI.YoumePcmCallbackData obj = new YouMeVoiceAPI.YoumePcmCallbackData(unityPcmCallbackData.channelNum, unityPcmCallbackData.samplingRateHz, unityPcmCallbackData.bytesPerSample, unityPcmCallbackData.data, unityPcmCallbackData.dataSizeInByte);
				YouMeVoiceAPI.mPcmCallback(obj);
			}
		}

		// Token: 0x0601BE21 RID: 114209 RVA: 0x00888CFD File Offset: 0x008870FD
		public static YouMeVoiceAPI GetInstance()
		{
			if (YouMeVoiceAPI.mInstance == null)
			{
				YouMeVoiceAPI.mInstance = new YouMeVoiceAPI();
			}
			return YouMeVoiceAPI.mInstance;
		}

		// Token: 0x0601BE22 RID: 114210 RVA: 0x00888D18 File Offset: 0x00887118
		private void InitAndroidJava()
		{
			try
			{
				if (!this.mAndroidInited)
				{
					this.mAndroidInited = true;
					AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
					AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
					AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.youme.voiceengine.mgr.YouMeManager");
					this.mAndroidInitOK = androidJavaClass2.CallStatic<bool>("Init", new object[]
					{
						@static
					});
					if (this.mAndroidInitOK)
					{
						AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("com.youme.voiceengine.VoiceEngineService");
						AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.content.Intent", new object[]
						{
							@static,
							androidJavaClass3
						});
						@static.Call<AndroidJavaObject>("startService", new object[]
						{
							androidJavaObject
						});
					}
				}
			}
			catch
			{
				Debug.Log("android init exception!!!");
			}
		}

		// Token: 0x0601BE23 RID: 114211 RVA: 0x00888DE0 File Offset: 0x008871E0
		public void SetCallback(string strObjName)
		{
			this.InitAndroidJava();
			if (!this.mAndroidInitOK)
			{
				return;
			}
			this.mCallbackObjName = strObjName;
		}

		// Token: 0x0601BE24 RID: 114212 RVA: 0x00888DFC File Offset: 0x008871FC
		public YouMeErrorCode Init(string strAppKey, string strAPPSecret, YOUME_RTC_SERVER_REGION serverRegionId, string strExtServerRegionName)
		{
			this.InitAndroidJava();
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			GameObject gameObject = new GameObject("youme_update_once");
			Object.DontDestroyOnLoad(gameObject);
			gameObject.hideFlags = 1;
			gameObject.AddComponent<YouMeVoiceAPI.YoumeCallbackObject>();
			return (YouMeErrorCode)YouMeVoiceAPI.youme_init(strAppKey, strAPPSecret, (int)serverRegionId, strExtServerRegionName);
		}

		// Token: 0x0601BE25 RID: 114213 RVA: 0x00888E49 File Offset: 0x00887249
		public YouMeErrorCode UnInit()
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_unInit();
		}

		// Token: 0x0601BE26 RID: 114214 RVA: 0x00888E61 File Offset: 0x00887261
		public void SetServerRegion(YOUME_RTC_SERVER_REGION regionId, string strExtRegionName)
		{
			this.InitAndroidJava();
			if (!this.mAndroidInitOK)
			{
				return;
			}
			YouMeVoiceAPI.youme_setServerRegion((int)regionId, strExtRegionName, false);
		}

		// Token: 0x0601BE27 RID: 114215 RVA: 0x00888E80 File Offset: 0x00887280
		public void SetServerRegion(string[] regionNames)
		{
			this.InitAndroidJava();
			if (!this.mAndroidInitOK)
			{
				return;
			}
			if (regionNames != null && regionNames.Length > 0)
			{
				YouMeVoiceAPI.youme_setServerRegion(10000, regionNames[0], false);
			}
			for (int i = 1; i < regionNames.Length; i++)
			{
				YouMeVoiceAPI.youme_setServerRegion(10000, regionNames[i], true);
			}
		}

		// Token: 0x0601BE28 RID: 114216 RVA: 0x00888EDE File Offset: 0x008872DE
		public YouMeErrorCode SetOutputToSpeaker(bool bOutputToSpeaker)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setOutputToSpeaker(bOutputToSpeaker);
		}

		// Token: 0x0601BE29 RID: 114217 RVA: 0x00888EF7 File Offset: 0x008872F7
		public void SetSpeakerMute(bool bMute)
		{
			if (!this.mAndroidInitOK)
			{
				return;
			}
			YouMeVoiceAPI.youme_setSpeakerMute(bMute);
		}

		// Token: 0x0601BE2A RID: 114218 RVA: 0x00888F0B File Offset: 0x0088730B
		public bool GetSpeakerMute()
		{
			return this.mAndroidInitOK && YouMeVoiceAPI.youme_getSpeakerMute();
		}

		// Token: 0x0601BE2B RID: 114219 RVA: 0x00888F1F File Offset: 0x0088731F
		public void SetMicrophoneMute(bool mute)
		{
			if (!this.mAndroidInitOK)
			{
				return;
			}
			YouMeVoiceAPI.youme_setMicrophoneMute(mute);
		}

		// Token: 0x0601BE2C RID: 114220 RVA: 0x00888F33 File Offset: 0x00887333
		public bool GetMicrophoneMute()
		{
			return this.mAndroidInitOK && YouMeVoiceAPI.youme_getMicrophoneMute();
		}

		// Token: 0x0601BE2D RID: 114221 RVA: 0x00888F47 File Offset: 0x00887347
		public void SetAutoSendStatus(bool bAutoSend)
		{
			if (!this.mAndroidInitOK)
			{
				return;
			}
			YouMeVoiceAPI.youme_setAutoSendStatus(bAutoSend);
		}

		// Token: 0x0601BE2E RID: 114222 RVA: 0x00888F5B File Offset: 0x0088735B
		public void SetVolume(uint uiVolume)
		{
			if (!this.mAndroidInitOK)
			{
				return;
			}
			YouMeVoiceAPI.youme_setVolume(uiVolume);
		}

		// Token: 0x0601BE2F RID: 114223 RVA: 0x00888F6F File Offset: 0x0088736F
		public int GetVolume()
		{
			if (!this.mAndroidInitOK)
			{
				return 0;
			}
			return YouMeVoiceAPI.youme_getVolume();
		}

		// Token: 0x0601BE30 RID: 114224 RVA: 0x00888F83 File Offset: 0x00887383
		public void SetUseMobileNetworkEnabled(bool bEnabled)
		{
			if (!this.mAndroidInitOK)
			{
				return;
			}
			YouMeVoiceAPI.youme_setUseMobileNetworkEnabled(bEnabled);
		}

		// Token: 0x0601BE31 RID: 114225 RVA: 0x00888F97 File Offset: 0x00887397
		public bool GetUseMobileNetworkEnabled()
		{
			return this.mAndroidInitOK && YouMeVoiceAPI.youme_getUseMobileNetworkEnabled();
		}

		// Token: 0x0601BE32 RID: 114226 RVA: 0x00888FAB File Offset: 0x008873AB
		public YouMeErrorCode JoinChannelSingleMode(string strUserID, string strChannelID, YouMeUserRole userRole, bool bCheckRoomExist = false)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_joinChannelSingleMode(strUserID, strChannelID, (int)userRole, bCheckRoomExist);
		}

		// Token: 0x0601BE33 RID: 114227 RVA: 0x00888FC8 File Offset: 0x008873C8
		public YouMeErrorCode JoinChannelMultiMode(string strUserID, string strChannelID, YouMeUserRole userRole, bool bCheckRoomExist = false)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_joinChannelMultiMode(strUserID, strChannelID, (int)userRole, bCheckRoomExist);
		}

		// Token: 0x0601BE34 RID: 114228 RVA: 0x00888FE5 File Offset: 0x008873E5
		public YouMeErrorCode JoinChannelMultiMode(string strUserID, string strChannelID, bool bCheckRoomExist = false)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_joinChannelMultiMode(strUserID, strChannelID, 1, bCheckRoomExist);
		}

		// Token: 0x0601BE35 RID: 114229 RVA: 0x00889001 File Offset: 0x00887401
		public YouMeErrorCode SpeakToChannel(string strChannelID)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_speakToChannel(strChannelID);
		}

		// Token: 0x0601BE36 RID: 114230 RVA: 0x0088901A File Offset: 0x0088741A
		public YouMeErrorCode LeaveChannelMultiMode(string strChannelID)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_leaveChannelMultiMode(strChannelID);
		}

		// Token: 0x0601BE37 RID: 114231 RVA: 0x00889033 File Offset: 0x00887433
		public YouMeErrorCode LeaveChannelAll()
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_leaveChannelAll();
		}

		// Token: 0x0601BE38 RID: 114232 RVA: 0x0088904C File Offset: 0x0088744C
		public YouMeErrorCode SetPcmCallback(Action<YouMeVoiceAPI.YoumePcmCallbackData> callback, bool bOutputToSpeaker = true)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			YouMeVoiceAPI.mPcmCallback = callback;
			AndroidJavaObject androidJavaObject = new AndroidJavaClass("com.youme.voiceengine.api");
			androidJavaObject.CallStatic("setPcmCallbackForUnity3D", new object[]
			{
				new YouMeVoiceAPI.AndroidPluginCallback(),
				true
			});
			return YouMeErrorCode.YOUME_SUCCESS;
		}

		// Token: 0x0601BE39 RID: 114233 RVA: 0x0088909E File Offset: 0x0088749E
		public YouMeErrorCode SetOtherMicMute(string userID, bool mute)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setOtherMicMute(userID, mute);
		}

		// Token: 0x0601BE3A RID: 114234 RVA: 0x008890B8 File Offset: 0x008874B8
		public YouMeErrorCode SetOtherSpeakerMute(string userID, bool mute)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setOtherSpeakerMute(userID, mute);
		}

		// Token: 0x0601BE3B RID: 114235 RVA: 0x008890D2 File Offset: 0x008874D2
		public YouMeErrorCode SetListenOtherVoice(string userID, bool isOn)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setListenOtherVoice(userID, isOn);
		}

		// Token: 0x0601BE3C RID: 114236 RVA: 0x008890EC File Offset: 0x008874EC
		public YouMeErrorCode PlayBackgroundMusic(string strFilePath, bool bRepeat)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_playBackgroundMusic(strFilePath, bRepeat);
		}

		// Token: 0x0601BE3D RID: 114237 RVA: 0x00889106 File Offset: 0x00887506
		public YouMeErrorCode PauseBackgroundMusic()
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_pauseBackgroundMusic();
		}

		// Token: 0x0601BE3E RID: 114238 RVA: 0x0088911E File Offset: 0x0088751E
		public YouMeErrorCode ResumeBackgroundMusic()
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_resumeBackgroundMusic();
		}

		// Token: 0x0601BE3F RID: 114239 RVA: 0x00889136 File Offset: 0x00887536
		public YouMeErrorCode StopBackgroundMusic()
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_stopBackgroundMusic();
		}

		// Token: 0x0601BE40 RID: 114240 RVA: 0x0088914E File Offset: 0x0088754E
		public YouMeErrorCode SetBackgroundMusicVolume(int volume)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setBackgroundMusicVolume(volume);
		}

		// Token: 0x0601BE41 RID: 114241 RVA: 0x00889167 File Offset: 0x00887567
		public YouMeErrorCode SetHeadsetMonitorOn(bool micEnabled, bool bgmEnabled = true)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setHeadsetMonitorOn(micEnabled, bgmEnabled);
		}

		// Token: 0x0601BE42 RID: 114242 RVA: 0x00889181 File Offset: 0x00887581
		public YouMeErrorCode SetReverbEnabled(bool enabled)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setReverbEnabled(enabled);
		}

		// Token: 0x0601BE43 RID: 114243 RVA: 0x0088919A File Offset: 0x0088759A
		public YouMeErrorCode SetVadCallbackEnabled(bool enabled)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setVadCallbackEnabled(enabled);
		}

		// Token: 0x0601BE44 RID: 114244 RVA: 0x008891B3 File Offset: 0x008875B3
		public YouMeErrorCode SetMicLevelCallback(int maxMicLevel)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setMicLevelCallback(maxMicLevel);
		}

		// Token: 0x0601BE45 RID: 114245 RVA: 0x008891CC File Offset: 0x008875CC
		public YouMeErrorCode PauseChannel()
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_pauseChannel();
		}

		// Token: 0x0601BE46 RID: 114246 RVA: 0x008891E4 File Offset: 0x008875E4
		public YouMeErrorCode ResumeChannel()
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_resumeChannel();
		}

		// Token: 0x0601BE47 RID: 114247 RVA: 0x008891FC File Offset: 0x008875FC
		public float GetSoundtouchPitchSemiTones()
		{
			if (!this.mAndroidInitOK)
			{
				return 0f;
			}
			return YouMeVoiceAPI.youme_getSoundtouchPitchSemiTones();
		}

		// Token: 0x0601BE48 RID: 114248 RVA: 0x00889214 File Offset: 0x00887614
		public YouMeErrorCode SetSoundtouchPitchSemiTones(float fPitchSemiTones)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setSoundtouchPitchSemiTones(fPitchSemiTones);
		}

		// Token: 0x0601BE49 RID: 114249 RVA: 0x0088922D File Offset: 0x0088762D
		public void SetRecordingTimeMs(uint timeMs)
		{
			if (!this.mAndroidInitOK)
			{
				return;
			}
			YouMeVoiceAPI.youme_setRecordingTimeMs(timeMs);
		}

		// Token: 0x0601BE4A RID: 114250 RVA: 0x00889241 File Offset: 0x00887641
		public void SetPlayingTimeMs(uint timeMs)
		{
			if (!this.mAndroidInitOK)
			{
				return;
			}
			YouMeVoiceAPI.youme_setPlayingTimeMs(timeMs);
		}

		// Token: 0x0601BE4B RID: 114251 RVA: 0x00889255 File Offset: 0x00887655
		public int GetSDKVersion()
		{
			if (!this.mAndroidInitOK)
			{
				return 0;
			}
			return YouMeVoiceAPI.youme_getSDKVersion();
		}

		// Token: 0x0601BE4C RID: 114252 RVA: 0x00889269 File Offset: 0x00887669
		public YouMeErrorCode RequestRestApi(string command, string queryBody, ref int requestID)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_requestRestApi(command, queryBody, ref requestID);
		}

		// Token: 0x0601BE4D RID: 114253 RVA: 0x00889284 File Offset: 0x00887684
		public YouMeErrorCode GetChannelUserList(string channelID, int maxCount, bool notifyMemChange)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_getChannelUserList(channelID, maxCount, notifyMemChange);
		}

		// Token: 0x0601BE4E RID: 114254 RVA: 0x0088929F File Offset: 0x0088769F
		public void SetToken(string strToken)
		{
			if (!this.mAndroidInitOK)
			{
				return;
			}
			YouMeVoiceAPI.youme_setToken(strToken);
		}

		// Token: 0x0601BE4F RID: 114255 RVA: 0x008892B4 File Offset: 0x008876B4
		public YouMeErrorCode SetReleaseMicWhenMute(bool enabled)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setReleaseMicWhenMute(enabled);
		}

		// Token: 0x0601BE50 RID: 114256 RVA: 0x008892CD File Offset: 0x008876CD
		public YouMeErrorCode SetGrabMicOption(string pChannelID, int mode, int maxAllowCount, int maxTalkTime, uint voteTime)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setGrabMicOption(pChannelID, mode, maxAllowCount, maxTalkTime, voteTime);
		}

		// Token: 0x0601BE51 RID: 114257 RVA: 0x008892EC File Offset: 0x008876EC
		public YouMeErrorCode StartGrabMicAction(string pChannelID, string pContent)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_startGrabMicAction(pChannelID, pContent);
		}

		// Token: 0x0601BE52 RID: 114258 RVA: 0x00889306 File Offset: 0x00887706
		public YouMeErrorCode StopGrabMicAction(string pChannelID, string pContent)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_stopGrabMicAction(pChannelID, pContent);
		}

		// Token: 0x0601BE53 RID: 114259 RVA: 0x00889320 File Offset: 0x00887720
		public YouMeErrorCode requestGrabMic(string pChannelID, int score, bool isAutoOpenMic, string pContent)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_requestGrabMic(pChannelID, score, isAutoOpenMic, pContent);
		}

		// Token: 0x0601BE54 RID: 114260 RVA: 0x0088933D File Offset: 0x0088773D
		public YouMeErrorCode releaseGrabMic(string pChannelID)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_releaseGrabMic(pChannelID);
		}

		// Token: 0x0601BE55 RID: 114261 RVA: 0x00889356 File Offset: 0x00887756
		public YouMeErrorCode setInviteMicOption(string pChannelID, int waitTimeout, int maxTalkTime)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setInviteMicOption(pChannelID, waitTimeout, maxTalkTime);
		}

		// Token: 0x0601BE56 RID: 114262 RVA: 0x00889371 File Offset: 0x00887771
		public YouMeErrorCode requestInviteMic(string pChannelID, string pUserID, string pContent)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_requestInviteMic(pChannelID, pUserID, pContent);
		}

		// Token: 0x0601BE57 RID: 114263 RVA: 0x0088938C File Offset: 0x0088778C
		public YouMeErrorCode responseInviteMic(string pUserID, bool isAccept, string pContent)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_responseInviteMic(pUserID, isAccept, pContent);
		}

		// Token: 0x0601BE58 RID: 114264 RVA: 0x008893A7 File Offset: 0x008877A7
		public YouMeErrorCode stopInviteMic()
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_stopInviteMic();
		}

		// Token: 0x0601BE59 RID: 114265 RVA: 0x008893BF File Offset: 0x008877BF
		public YouMeErrorCode SendMessage(string channelID, string content, ref int requestID)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_sendMessage(channelID, content, ref requestID);
		}

		// Token: 0x0601BE5A RID: 114266 RVA: 0x008893DA File Offset: 0x008877DA
		public YouMeErrorCode SetWhiteUserList(string channelID, string whiteUserList)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_setWhiteUserList(channelID, whiteUserList);
		}

		// Token: 0x0601BE5B RID: 114267 RVA: 0x008893F4 File Offset: 0x008877F4
		private YouMeErrorCode KickOtherFromChannel(string userID, string channelID, int lastTime)
		{
			if (!this.mAndroidInitOK)
			{
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			return (YouMeErrorCode)YouMeVoiceAPI.youme_kickOtherFromChannel(userID, channelID, lastTime);
		}

		// Token: 0x0601BE5C RID: 114268 RVA: 0x0088940F File Offset: 0x0088780F
		public bool ReleaseMicSync()
		{
			return this.mAndroidInitOK && YouMeVoiceAPI.youme_releaseMicSync();
		}

		// Token: 0x0601BE5D RID: 114269 RVA: 0x00889423 File Offset: 0x00887823
		public bool ResumeMicSync()
		{
			return this.mAndroidInitOK && YouMeVoiceAPI.youme_resumeMicSync();
		}

		// Token: 0x0401371F RID: 79647
		private static YouMeVoiceAPI mInstance;

		// Token: 0x04013720 RID: 79648
		private string mCallbackObjName;

		// Token: 0x04013721 RID: 79649
		private static Action<YouMeVoiceAPI.YoumePcmCallbackData> mPcmCallback;

		// Token: 0x04013722 RID: 79650
		private bool mAndroidInited;

		// Token: 0x04013723 RID: 79651
		private bool mAndroidInitOK;

		// Token: 0x04013724 RID: 79652
		private AndroidJavaClass instance_youme_java;

		// Token: 0x02004AE4 RID: 19172
		private enum CallbackType
		{
			// Token: 0x04013726 RID: 79654
			CALLBACK_TYPE_EVENT,
			// Token: 0x04013727 RID: 79655
			CALLBACK_TYPE_REST_API_RESPONSE,
			// Token: 0x04013728 RID: 79656
			CALLBACK_TYPE_MEMBER_CHANGE,
			// Token: 0x04013729 RID: 79657
			CALLBACK_TYPE_BROADCAST
		}

		// Token: 0x02004AE5 RID: 19173
		private struct UnityPcmCallbackData
		{
			// Token: 0x0401372A RID: 79658
			public int channelNum;

			// Token: 0x0401372B RID: 79659
			public int samplingRateHz;

			// Token: 0x0401372C RID: 79660
			public int bytesPerSample;

			// Token: 0x0401372D RID: 79661
			public IntPtr data;

			// Token: 0x0401372E RID: 79662
			public int dataSizeInByte;
		}

		// Token: 0x02004AE6 RID: 19174
		public class YoumePcmCallbackData
		{
			// Token: 0x0601BE5F RID: 114271 RVA: 0x00889439 File Offset: 0x00887839
			public YoumePcmCallbackData(int channelNum, int samplingRateHz, int bytesPerSample, IntPtr data, int dataSizeInByte)
			{
				this.channelNum = channelNum;
				this.samplingRateHz = samplingRateHz;
				this.bytesPerSample = bytesPerSample;
				this.data = new byte[dataSizeInByte];
				Marshal.Copy(data, this.data, 0, dataSizeInByte);
			}

			// Token: 0x0601BE60 RID: 114272 RVA: 0x00889473 File Offset: 0x00887873
			public YoumePcmCallbackData(int channelNum, int samplingRateHz, int bytesPerSample, byte[] data)
			{
				this.channelNum = channelNum;
				this.samplingRateHz = samplingRateHz;
				this.bytesPerSample = bytesPerSample;
				this.data = data;
			}

			// Token: 0x0401372F RID: 79663
			public int channelNum;

			// Token: 0x04013730 RID: 79664
			public int samplingRateHz;

			// Token: 0x04013731 RID: 79665
			public int bytesPerSample;

			// Token: 0x04013732 RID: 79666
			public byte[] data;
		}

		// Token: 0x02004AE7 RID: 19175
		// (Invoke) Token: 0x0601BE62 RID: 114274
		private delegate void UnityPcmCallbackDelegate(IntPtr unityPcmCallbackData);

		// Token: 0x02004AE8 RID: 19176
		private class YoumeCallbackObject : MonoBehaviour
		{
			// Token: 0x0601BE66 RID: 114278 RVA: 0x008894A0 File Offset: 0x008878A0
			private void Start()
			{
				base.InvokeRepeating("YoumeCallback", 0.5f, 0.05f);
			}

			// Token: 0x0601BE67 RID: 114279 RVA: 0x008894B8 File Offset: 0x008878B8
			private void YoumeCallback()
			{
				IntPtr intPtr = YouMeVoiceAPI.youme_getCbMessage();
				if (intPtr == IntPtr.Zero)
				{
					return;
				}
				string text = Marshal.PtrToStringAuto(intPtr);
				if (text != null)
				{
					try
					{
						YouMeVoiceAPI.GetInstance().ParseJsonCallbackMessage(text);
					}
					catch (Exception ex)
					{
						Debug.LogError(ex.StackTrace);
					}
				}
				YouMeVoiceAPI.youme_freeCbMessage(intPtr);
				intPtr = IntPtr.Zero;
			}
		}

		// Token: 0x02004AE9 RID: 19177
		private class AndroidPluginCallback : AndroidJavaProxy
		{
			// Token: 0x0601BE68 RID: 114280 RVA: 0x00889528 File Offset: 0x00887928
			public AndroidPluginCallback() : base("com.youme.voiceengine.YouMeCallBackInterfacePcmForUnity")
			{
			}

			// Token: 0x0601BE69 RID: 114281 RVA: 0x00889538 File Offset: 0x00887938
			public void onPcmData(int channelNum, int samplingRateHz, int bytesPerSample, AndroidJavaObject javaByteData)
			{
				if (YouMeVoiceAPI.mPcmCallback != null)
				{
					AndroidJavaObject androidJavaObject = javaByteData.Get<AndroidJavaObject>("data");
					byte[] data = AndroidJNI.FromByteArray(androidJavaObject.GetRawObject());
					YouMeVoiceAPI.YoumePcmCallbackData obj = new YouMeVoiceAPI.YoumePcmCallbackData(channelNum, samplingRateHz, bytesPerSample, data);
					YouMeVoiceAPI.mPcmCallback(obj);
				}
			}
		}
	}
}
