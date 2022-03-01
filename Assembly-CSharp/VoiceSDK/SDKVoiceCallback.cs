using System;
using System.Collections;
using System.Collections.Generic;
using GamePool;
using UnityEngine;
using XUPorterJSON;
using YouMe;

namespace VoiceSDK
{
	// Token: 0x0200466A RID: 18026
	public class SDKVoiceCallback : MonoSingleton<SDKVoiceCallback>
	{
		// Token: 0x06019698 RID: 104088 RVA: 0x008073F5 File Offset: 0x008057F5
		public void Start()
		{
			Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06019699 RID: 104089 RVA: 0x00807402 File Offset: 0x00805802
		public override void Init()
		{
		}

		// Token: 0x0601969A RID: 104090 RVA: 0x00807404 File Offset: 0x00805804
		public void OnApplicationPause(bool isPaused)
		{
			if (isPaused)
			{
				Singleton<SDKVoiceManager>.GetInstance().OnPause();
				Singleton<SDKVoiceManager>.GetInstance().PauseChannel();
			}
			else
			{
				Singleton<SDKVoiceManager>.GetInstance().OnResume();
				Singleton<SDKVoiceManager>.GetInstance().ResumeChannel();
			}
		}

		// Token: 0x0601969B RID: 104091 RVA: 0x00807439 File Offset: 0x00805839
		protected override void OnApplicationQuit()
		{
			this.OnYoumiVoiceDestroy();
			base.OnApplicationQuit();
		}

		// Token: 0x0601969C RID: 104092 RVA: 0x00807447 File Offset: 0x00805847
		protected override void OnDestroy()
		{
			this.OnYoumiVoiceDestroy();
			base.OnDestroy();
		}

		// Token: 0x0601969D RID: 104093 RVA: 0x00807455 File Offset: 0x00805855
		private void OnYoumiVoiceDestroy()
		{
			if (!SDKVoiceManager.isInit)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().LeaveVoiceSDK(true);
			Singleton<SDKVoiceManager>.GetInstance().UnInit();
		}

		// Token: 0x0601969E RID: 104094 RVA: 0x00807478 File Offset: 0x00805878
		public void OnEvent(string strParam)
		{
			string[] array = strParam.Split(new char[]
			{
				','
			}, 4);
			if (array == null)
			{
				Logger.LogError("SDKVoiceCallback onEvent strParams split is error");
				return;
			}
			YouMeEvent youMeEvent = YouMeEvent.YOUME_EVENT_INIT_FAILED;
			int num;
			if (int.TryParse(array[0], out num))
			{
				youMeEvent = (YouMeEvent)num;
			}
			YouMeErrorCode errorCode = YouMeErrorCode.YOUME_ERROR_NOT_INIT;
			int num2;
			if (int.TryParse(array[1], out num2))
			{
				errorCode = (YouMeErrorCode)num2;
			}
			string channelId = array[2];
			string text = array[3];
			switch (youMeEvent)
			{
			case YouMeEvent.YOUME_EVENT_INIT_OK:
				if (this.onRealVoiceInitHandler != null)
				{
					this.onRealVoiceInitHandler(true, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_INIT_FAILED:
				if (this.onRealVoiceInitHandler != null)
				{
					this.onRealVoiceInitHandler(false, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_JOIN_OK:
				if (this.onJoinChannelHandler != null)
				{
					this.onJoinChannelHandler(true, channelId, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_JOIN_FAILED:
				if (this.onJoinChannelHandler != null)
				{
					this.onJoinChannelHandler(false, channelId, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_LEAVED_ONE:
				if (this.onLeaveChannelHandler != null)
				{
					this.onLeaveChannelHandler(true, channelId, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_LEAVED_ALL:
				if (this.onLeaveAllChanenlHandler != null)
				{
					this.onLeaveAllChanenlHandler(true, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_PAUSED:
				if (this.onPauseChannelHandler != null)
				{
					this.onPauseChannelHandler(true, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_RESUMED:
				if (this.onPauseChannelHandler != null)
				{
					this.onPauseChannelHandler(false, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_SPEAK_SUCCESS:
				if (this.onSetSpeakChannel != null)
				{
					this.onSetSpeakChannel(true, channelId, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_SPEAK_FAILED:
				if (this.onSetSpeakChannel != null)
				{
					this.onSetSpeakChannel(false, channelId, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_REC_PERMISSION_STATUS:
				if (this.onVoiceTalkMicAuth != null)
				{
					this.onVoiceTalkMicAuth(errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_OTHERS_MIC_ON:
				if (this.onOtherControlMic != null)
				{
					this.onOtherControlMic(true, text, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_OTHERS_MIC_OFF:
				if (this.onOtherControlMic != null)
				{
					this.onOtherControlMic(false, text, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_OTHERS_VOICE_ON:
				if (this.onOtherSpeakInChannel != null)
				{
					this.onOtherSpeakInChannel(true, text, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_OTHERS_VOICE_OFF:
				if (this.onOtherSpeakInChannel != null)
				{
					this.onOtherSpeakInChannel(false, text, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_MIC_CTR_ON:
				if (this.onMicChangeByOther != null)
				{
					this.onMicChangeByOther(true, text, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_MIC_CTR_OFF:
				if (this.onMicChangeByOther != null)
				{
					this.onMicChangeByOther(false, text, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_LOCAL_MIC_ON:
				if (this.onRealVoiceMicHandler != null)
				{
					this.onRealVoiceMicHandler(true, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_LOCAL_MIC_OFF:
				if (this.onRealVoiceMicHandler != null)
				{
					this.onRealVoiceMicHandler(false, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_LOCAL_SPEAKER_ON:
				if (this.onRealVoicePlayerHandler != null)
				{
					this.onRealVoicePlayerHandler(true, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_LOCAL_SPEAKER_OFF:
				if (this.onRealVoicePlayerHandler != null)
				{
					this.onRealVoicePlayerHandler(false, errorCode);
				}
				break;
			case YouMeEvent.YOUME_EVENT_SEND_MESSAGE_RESULT:
			case YouMeEvent.YOUME_EVENT_MESSAGE_NOTIFY:
				if (this.onBroadcastMsg != null)
				{
					this.onBroadcastMsg(channelId, text, errorCode);
				}
				break;
			}
		}

		// Token: 0x0601969F RID: 104095 RVA: 0x008078C7 File Offset: 0x00805CC7
		public void OnRequestRestApi(string strParam)
		{
		}

		// Token: 0x060196A0 RID: 104096 RVA: 0x008078CC File Offset: 0x00805CCC
		public void OnMemberChange(string strParam)
		{
			if (string.IsNullOrEmpty(strParam))
			{
				return;
			}
			try
			{
				Hashtable hashtable = MiniJSON.jsonDecode(strParam) as Hashtable;
				string talkChannelId = string.Empty;
				if (hashtable != null && hashtable.ContainsKey("channelid"))
				{
					talkChannelId = (hashtable["channelid"] as string);
				}
				if (hashtable != null && hashtable.ContainsKey("memchange"))
				{
					ArrayList arrayList = hashtable["memchange"] as ArrayList;
					if (arrayList != null)
					{
						List<TalkChannelMemberInfo> list = ListPool<TalkChannelMemberInfo>.Get();
						for (int i = 0; i < arrayList.Count; i++)
						{
							Hashtable hashtable2 = arrayList[i] as Hashtable;
							if (hashtable2 != null)
							{
								TalkChannelMemberInfo item = default(TalkChannelMemberInfo);
								item.talkChannelId = talkChannelId;
								if (hashtable2.ContainsKey("isJoin"))
								{
									item.isJoined = (bool)hashtable2["isJoin"];
								}
								if (hashtable2.ContainsKey("userid"))
								{
									item.userId = (hashtable2["userid"] as string);
								}
								if (list != null && !list.Contains(item))
								{
									list.Add(item);
								}
							}
						}
						if (this.onChannelMemberChange != null)
						{
							this.onChannelMemberChange(list);
						}
						ListPool<TalkChannelMemberInfo>.Release(list);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("[SDKVoiceCallback] - OnMemberChange decode res json failed, json : {0}, error : {1}", new object[]
				{
					strParam,
					ex.ToString()
				});
			}
		}

		// Token: 0x04012315 RID: 74517
		public SDKVoiceCallback.OnRealVoiceInitHandler onRealVoiceInitHandler;

		// Token: 0x04012316 RID: 74518
		public SDKVoiceCallback.OnJoinChannelHandler onJoinChannelHandler;

		// Token: 0x04012317 RID: 74519
		public SDKVoiceCallback.OnLeaveChannelHandler onLeaveChannelHandler;

		// Token: 0x04012318 RID: 74520
		public SDKVoiceCallback.OnLeaveAllChannelHandler onLeaveAllChanenlHandler;

		// Token: 0x04012319 RID: 74521
		public SDKVoiceCallback.OnPauseChannelHanlder onPauseChannelHandler;

		// Token: 0x0401231A RID: 74522
		public SDKVoiceCallback.OnRealVoiceMicOnHandler onRealVoiceMicHandler;

		// Token: 0x0401231B RID: 74523
		public SDKVoiceCallback.OnRealVoicePlayerOnHandler onRealVoicePlayerHandler;

		// Token: 0x0401231C RID: 74524
		public SDKVoiceCallback.OnChannelMemberChangeHandler onChannelMemberChange;

		// Token: 0x0401231D RID: 74525
		public SDKVoiceCallback.OnMicChangeByOtherHandler onMicChangeByOther;

		// Token: 0x0401231E RID: 74526
		public SDKVoiceCallback.OnSetSpeackChannelHandler onSetSpeakChannel;

		// Token: 0x0401231F RID: 74527
		public SDKVoiceCallback.OnOtherSpeakInChannelHandler onOtherSpeakInChannel;

		// Token: 0x04012320 RID: 74528
		public SDKVoiceCallback.OnOtherControlMicHandler onOtherControlMic;

		// Token: 0x04012321 RID: 74529
		public SDKVoiceCallback.OnVoiceTalkMicAuth onVoiceTalkMicAuth;

		// Token: 0x04012322 RID: 74530
		public SDKVoiceCallback.OnBroadcastMsg onBroadcastMsg;

		// Token: 0x0200466B RID: 18027
		// (Invoke) Token: 0x060196A2 RID: 104098
		public delegate void OnRealVoiceInitHandler(bool isInited, YouMeErrorCode errorCode);

		// Token: 0x0200466C RID: 18028
		// (Invoke) Token: 0x060196A6 RID: 104102
		public delegate void OnJoinChannelHandler(bool success, string channelId, YouMeErrorCode errorCode);

		// Token: 0x0200466D RID: 18029
		// (Invoke) Token: 0x060196AA RID: 104106
		public delegate void OnLeaveChannelHandler(bool success, string channelId, YouMeErrorCode errorCode);

		// Token: 0x0200466E RID: 18030
		// (Invoke) Token: 0x060196AE RID: 104110
		public delegate void OnLeaveAllChannelHandler(bool success, YouMeErrorCode errorCode);

		// Token: 0x0200466F RID: 18031
		// (Invoke) Token: 0x060196B2 RID: 104114
		public delegate void OnPauseChannelHanlder(bool isPaused, YouMeErrorCode errorCode);

		// Token: 0x02004670 RID: 18032
		// (Invoke) Token: 0x060196B6 RID: 104118
		public delegate void OnRealVoiceMicOnHandler(bool isOn, YouMeErrorCode errorCode);

		// Token: 0x02004671 RID: 18033
		// (Invoke) Token: 0x060196BA RID: 104122
		public delegate void OnRealVoicePlayerOnHandler(bool isOn, YouMeErrorCode errorCode);

		// Token: 0x02004672 RID: 18034
		// (Invoke) Token: 0x060196BE RID: 104126
		public delegate void OnChannelMemberChangeHandler(IList<TalkChannelMemberInfo> talkChannelMembers);

		// Token: 0x02004673 RID: 18035
		// (Invoke) Token: 0x060196C2 RID: 104130
		public delegate void OnMicChangeByOtherHandler(bool isOn, string voicePlayerId, YouMeErrorCode errorCode);

		// Token: 0x02004674 RID: 18036
		// (Invoke) Token: 0x060196C6 RID: 104134
		public delegate void OnSetSpeackChannelHandler(bool success, string channelId, YouMeErrorCode errorCode);

		// Token: 0x02004675 RID: 18037
		// (Invoke) Token: 0x060196CA RID: 104138
		public delegate void OnOtherSpeakInChannelHandler(bool isSpeak, string voicePlayerId, YouMeErrorCode errorCode);

		// Token: 0x02004676 RID: 18038
		// (Invoke) Token: 0x060196CE RID: 104142
		public delegate void OnOtherControlMicHandler(bool isOn, string voicePlayerId, YouMeErrorCode errorCode);

		// Token: 0x02004677 RID: 18039
		// (Invoke) Token: 0x060196D2 RID: 104146
		public delegate void OnVoiceTalkMicAuth(YouMeErrorCode errorCode);

		// Token: 0x02004678 RID: 18040
		// (Invoke) Token: 0x060196D6 RID: 104150
		public delegate void OnBroadcastMsg(string channelId, string content, YouMeErrorCode errorCode);
	}
}
