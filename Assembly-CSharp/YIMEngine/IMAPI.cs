using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace YIMEngine
{
	// Token: 0x02004A4D RID: 19021
	public class IMAPI
	{
		// Token: 0x0601B81C RID: 112668 RVA: 0x008789D6 File Offset: 0x00876DD6
		private IMAPI()
		{
		}

		// Token: 0x0601B81D RID: 112669
		[DllImport("yim")]
		private static extern int IM_Init([MarshalAs(UnmanagedType.LPTStr)] string strAppKey, [MarshalAs(UnmanagedType.LPTStr)] string strAppSecrect);

		// Token: 0x0601B81E RID: 112670
		[DllImport("yim")]
		private static extern int IM_Login([MarshalAs(UnmanagedType.LPTStr)] string strYouMeID, [MarshalAs(UnmanagedType.LPTStr)] string strPasswd, [MarshalAs(UnmanagedType.LPTStr)] string strToken);

		// Token: 0x0601B81F RID: 112671
		[DllImport("yim")]
		private static extern int IM_Logout();

		// Token: 0x0601B820 RID: 112672
		[DllImport("yim")]
		private static extern int IM_SendTextMessage([MarshalAs(UnmanagedType.LPTStr)] string strRecvID, int iChatType, [MarshalAs(UnmanagedType.LPTStr)] string strContent, [MarshalAs(UnmanagedType.LPTStr)] string strAttachParam, ref ulong iRequestID);

		// Token: 0x0601B821 RID: 112673
		[DllImport("yim")]
		private static extern int IM_SendCustomMessage([MarshalAs(UnmanagedType.LPTStr)] string strRecvID, int iChatType, [MarshalAs(UnmanagedType.LPArray)] byte[] buffer, int bufferLen, ref ulong iRequestID);

		// Token: 0x0601B822 RID: 112674
		[DllImport("yim")]
		private static extern int IM_SendAudioMessage([MarshalAs(UnmanagedType.LPTStr)] string strRecvID, int iChatType, ref ulong iRequestID);

		// Token: 0x0601B823 RID: 112675
		[DllImport("yim")]
		private static extern int IM_SendOnlyAudioMessage([MarshalAs(UnmanagedType.LPTStr)] string strRecvID, int iChatType, ref ulong iRequestID);

		// Token: 0x0601B824 RID: 112676
		[DllImport("yim")]
		private static extern int IM_SendFile([MarshalAs(UnmanagedType.LPTStr)] string strRecvID, int iChatType, [MarshalAs(UnmanagedType.LPTStr)] string strFilePath, [MarshalAs(UnmanagedType.LPTStr)] string strExtParam, int iFileType, ref ulong iRequestID);

		// Token: 0x0601B825 RID: 112677
		[DllImport("yim")]
		private static extern int IM_StopAudioMessage([MarshalAs(UnmanagedType.LPTStr)] string strParam);

		// Token: 0x0601B826 RID: 112678
		[DllImport("yim")]
		private static extern int IM_CancleAudioMessage();

		// Token: 0x0601B827 RID: 112679
		[DllImport("yim")]
		private static extern int IM_DownloadFile(ulong iSerial, [MarshalAs(UnmanagedType.LPTStr)] string strSavePath);

		// Token: 0x0601B828 RID: 112680
		[DllImport("yim")]
		private static extern int IM_DownloadFileByURL([MarshalAs(UnmanagedType.LPTStr)] string strFromUrl, [MarshalAs(UnmanagedType.LPTStr)] string strSavePath);

		// Token: 0x0601B829 RID: 112681
		[DllImport("yim")]
		private static extern int IM_JoinChatRoom([MarshalAs(UnmanagedType.LPTStr)] string strChatRoomID);

		// Token: 0x0601B82A RID: 112682
		[DllImport("yim")]
		private static extern int IM_LeaveChatRoom([MarshalAs(UnmanagedType.LPTStr)] string strChatRoomID);

		// Token: 0x0601B82B RID: 112683
		[DllImport("yim")]
		private static extern int IM_LeaveAllChatRooms();

		// Token: 0x0601B82C RID: 112684
		[DllImport("yim")]
		private static extern int IM_GetRoomMemberCount([MarshalAs(UnmanagedType.LPTStr)] string strChatRoomID);

		// Token: 0x0601B82D RID: 112685
		[DllImport("yim")]
		private static extern int IM_StartAudioSpeech(ref ulong iRequestID, bool translate);

		// Token: 0x0601B82E RID: 112686
		[DllImport("yim")]
		private static extern int IM_StopAudioSpeech();

		// Token: 0x0601B82F RID: 112687
		[DllImport("yim")]
		private static extern int IM_QueryHistoryMessage([MarshalAs(UnmanagedType.LPTStr)] string targetID, int chatType, ulong MessageID, int count, int directioin);

		// Token: 0x0601B830 RID: 112688
		[DllImport("yim")]
		private static extern int IM_DeleteHistoryMessage(ChatType chatType, ulong time);

		// Token: 0x0601B831 RID: 112689
		[DllImport("yim")]
		private static extern int IM_DeleteHistoryMessageByID(ulong messageID);

		// Token: 0x0601B832 RID: 112690
		[DllImport("yim")]
		private static extern int IM_DeleteSpecifiedHistoryMessage([MarshalAs(UnmanagedType.LPTStr)] string targetID, ChatType chatType, ulong[] excludeMesList, int num);

		// Token: 0x0601B833 RID: 112691
		[DllImport("yim")]
		private static extern int IM_DeleteHistoryMessageByTarget([MarshalAs(UnmanagedType.LPTStr)] string targetID, ChatType chatType, ulong startMessageID, uint count);

		// Token: 0x0601B834 RID: 112692
		[DllImport("yim")]
		private static extern int IM_QueryRoomHistoryMessageFromServer([MarshalAs(UnmanagedType.LPTStr)] string roomID, int count, int direction);

		// Token: 0x0601B835 RID: 112693
		[DllImport("yim")]
		private static extern int IM_ConvertAMRToWav([MarshalAs(UnmanagedType.LPTStr)] string strSrcPath, [MarshalAs(UnmanagedType.LPTStr)] string strSrcDestPath);

		// Token: 0x0601B836 RID: 112694
		[DllImport("yim")]
		private static extern int IM_SendGift([MarshalAs(UnmanagedType.LPTStr)] string strRecvID, [MarshalAs(UnmanagedType.LPTStr)] string strChannel, int iGiftID, int iGiftCount, [MarshalAs(UnmanagedType.LPStr)] string strExtParam, ref ulong iRequestID);

		// Token: 0x0601B837 RID: 112695
		[DllImport("yim")]
		private static extern int IM_GetSDKVer();

		// Token: 0x0601B838 RID: 112696
		[DllImport("yim")]
		private static extern IntPtr IM_GetMessage();

		// Token: 0x0601B839 RID: 112697
		[DllImport("yim")]
		private static extern IntPtr IM_GetMessage2();

		// Token: 0x0601B83A RID: 112698
		[DllImport("yim")]
		private static extern void IM_PopMessage(IntPtr pBuffer);

		// Token: 0x0601B83B RID: 112699
		[DllImport("yim")]
		private static extern IntPtr IM_GetFilterText([MarshalAs(UnmanagedType.LPTStr)] string strSource, ref int level);

		// Token: 0x0601B83C RID: 112700
		[DllImport("yim")]
		private static extern void IM_SetAudioCacheDir([MarshalAs(UnmanagedType.LPTStr)] string cachePath);

		// Token: 0x0601B83D RID: 112701
		[DllImport("yim")]
		private static extern void IM_DestroyFilterText(IntPtr pBuffer);

		// Token: 0x0601B83E RID: 112702
		[DllImport("yim")]
		private static extern void IM_SetMode(int iMode);

		// Token: 0x0601B83F RID: 112703
		[DllImport("yim")]
		private static extern void IM_SetServerZone(int zone);

		// Token: 0x0601B840 RID: 112704
		[DllImport("yim")]
		private static extern void IM_OnPause(bool pauseReceiveMessage);

		// Token: 0x0601B841 RID: 112705
		[DllImport("yim")]
		private static extern void IM_OnResume();

		// Token: 0x0601B842 RID: 112706
		[DllImport("yim")]
		private static extern int IM_MultiSendTextMessage([MarshalAs(UnmanagedType.LPStr)] string strReceives, [MarshalAs(UnmanagedType.LPTStr)] string strText);

		// Token: 0x0601B843 RID: 112707
		[DllImport("yim")]
		private static extern int IM_SetDownloadAudioMessageSwitch(bool download);

		// Token: 0x0601B844 RID: 112708
		[DllImport("yim")]
		private static extern int IM_SetReceiveMessageSwitch([MarshalAs(UnmanagedType.LPTStr)] string targets, bool bAutoRecv);

		// Token: 0x0601B845 RID: 112709
		[DllImport("yim")]
		private static extern int IM_GetNewMessage([MarshalAs(UnmanagedType.LPTStr)] string targets);

		// Token: 0x0601B846 RID: 112710
		[DllImport("yim")]
		private static extern int IM_TranslateText(ref uint requestID, [MarshalAs(UnmanagedType.LPTStr)] string text, LanguageCode destLangCode, LanguageCode srcLangCode);

		// Token: 0x0601B847 RID: 112711
		[DllImport("yim")]
		private static extern int IM_GetRecentContacts();

		// Token: 0x0601B848 RID: 112712
		[DllImport("yim")]
		private static extern int IM_SetUserInfo([MarshalAs(UnmanagedType.LPTStr)] string userInfo);

		// Token: 0x0601B849 RID: 112713
		[DllImport("yim")]
		private static extern int IM_GetUserInfo([MarshalAs(UnmanagedType.LPTStr)] string userID);

		// Token: 0x0601B84A RID: 112714
		[DllImport("yim")]
		private static extern int IM_QueryUserStatus([MarshalAs(UnmanagedType.LPTStr)] string userID);

		// Token: 0x0601B84B RID: 112715
		[DllImport("yim")]
		private static extern void IM_SetVolume(float volume);

		// Token: 0x0601B84C RID: 112716
		[DllImport("yim")]
		private static extern int IM_StartPlayAudio([MarshalAs(UnmanagedType.LPTStr)] string path);

		// Token: 0x0601B84D RID: 112717
		[DllImport("yim")]
		private static extern int IM_StopPlayAudio();

		// Token: 0x0601B84E RID: 112718
		[DllImport("yim")]
		private static extern bool IM_IsPlaying();

		// Token: 0x0601B84F RID: 112719
		[DllImport("yim")]
		private static extern int IM_SetRoomHistoryMessageSwitch([MarshalAs(UnmanagedType.LPTStr)] string roomID, bool save);

		// Token: 0x0601B850 RID: 112720
		[DllImport("yim")]
		private static extern IntPtr IM_GetAudioCachePath();

		// Token: 0x0601B851 RID: 112721
		[DllImport("yim")]
		private static extern void IM_DestroyAudioCachePath(IntPtr pBuffer);

		// Token: 0x0601B852 RID: 112722
		[DllImport("yim")]
		private static extern bool IM_ClearAudioCachePath();

		// Token: 0x0601B853 RID: 112723
		[DllImport("yim")]
		private static extern int IM_GetCurrentLocation();

		// Token: 0x0601B854 RID: 112724
		[DllImport("yim")]
		private static extern int IM_GetNearbyObjects(int count, [MarshalAs(UnmanagedType.LPTStr)] string serverAreaID, DistrictLevel districtlevel, bool resetStartDistance);

		// Token: 0x0601B855 RID: 112725
		[DllImport("yim")]
		private static extern int IM_GetDistance([MarshalAs(UnmanagedType.LPTStr)] string userID);

		// Token: 0x0601B856 RID: 112726
		[DllImport("yim")]
		private static extern void IM_SetUpdateInterval(uint interval);

		// Token: 0x0601B857 RID: 112727
		[DllImport("yim")]
		private static extern void IM_SetKeepRecordModel(bool keep);

		// Token: 0x0601B858 RID: 112728
		[DllImport("yim")]
		private static extern int IM_SetSpeechRecognizeLanguage(SpeechLanguage accent);

		// Token: 0x0601B859 RID: 112729
		[DllImport("yim")]
		private static extern int IM_SetOnlyRecognizeSpeechText(bool recognition);

		// Token: 0x0601B85A RID: 112730
		[DllImport("yim")]
		private static extern int IM_GetMicrophoneStatus();

		// Token: 0x0601B85B RID: 112731
		[DllImport("yim")]
		private static extern int IM_Accusation([MarshalAs(UnmanagedType.LPTStr)] string userID, ChatType source, int reason, [MarshalAs(UnmanagedType.LPTStr)] string description, [MarshalAs(UnmanagedType.LPTStr)] string extraParam);

		// Token: 0x0601B85C RID: 112732
		[DllImport("yim")]
		private static extern int IM_QueryNotice();

		// Token: 0x0601B85D RID: 112733
		[DllImport("yim")]
		private static extern int IM_SetMessageRead(ulong messageID, bool read);

		// Token: 0x0601B85E RID: 112734
		[DllImport("yim")]
		private static extern int IM_GetForbiddenSpeakInfo();

		// Token: 0x0601B85F RID: 112735
		[DllImport("yim")]
		private static extern int IM_BlockUser([MarshalAs(UnmanagedType.LPTStr)] string userID, bool block);

		// Token: 0x0601B860 RID: 112736
		[DllImport("yim")]
		private static extern int IM_UnBlockAllUser();

		// Token: 0x0601B861 RID: 112737
		[DllImport("yim")]
		private static extern int IM_GetBlockUsers();

		// Token: 0x0601B862 RID: 112738
		[DllImport("yim")]
		private static extern int IM_SetDownloadDir([MarshalAs(UnmanagedType.LPTStr)] string strPath);

		// Token: 0x0601B863 RID: 112739
		[DllImport("yim")]
		private static extern int IM_FindUser(int findType, [MarshalAs(UnmanagedType.LPTStr)] string target);

		// Token: 0x0601B864 RID: 112740
		[DllImport("yim")]
		private static extern int IM_RequestAddFriend([MarshalAs(UnmanagedType.LPTStr)] string users, [MarshalAs(UnmanagedType.LPTStr)] string comments);

		// Token: 0x0601B865 RID: 112741
		[DllImport("yim")]
		private static extern int IM_DealAddFriend([MarshalAs(UnmanagedType.LPTStr)] string userID, int dealResult);

		// Token: 0x0601B866 RID: 112742
		[DllImport("yim")]
		private static extern int IM_DeleteFriend([MarshalAs(UnmanagedType.LPTStr)] string users, int deleteType);

		// Token: 0x0601B867 RID: 112743
		[DllImport("yim")]
		private static extern int IM_BlackFriend(int type, [MarshalAs(UnmanagedType.LPTStr)] string users);

		// Token: 0x0601B868 RID: 112744
		[DllImport("yim")]
		private static extern int IM_QueryFriends(int type, int startIndex, int count);

		// Token: 0x0601B869 RID: 112745
		[DllImport("yim")]
		private static extern int IM_QueryFriendRequestList(int startIndex, int count);

		// Token: 0x0601B86A RID: 112746
		[DllImport("yim")]
		private static extern int IM_SetUserProfileInfo([MarshalAs(UnmanagedType.LPTStr)] string profileInfo);

		// Token: 0x0601B86B RID: 112747
		[DllImport("yim")]
		private static extern int IM_SetUserProfilePhoto([MarshalAs(UnmanagedType.LPTStr)] string photoPath);

		// Token: 0x0601B86C RID: 112748
		[DllImport("yim")]
		private static extern int IM_GetUserProfileInfo([MarshalAs(UnmanagedType.LPTStr)] string userID);

		// Token: 0x0601B86D RID: 112749
		[DllImport("yim")]
		private static extern int IM_SwitchUserStatus([MarshalAs(UnmanagedType.LPTStr)] string userID, UserStatus userStatus);

		// Token: 0x0601B86E RID: 112750
		[DllImport("yim")]
		private static extern int IM_SetAddPermission(bool beFound, IMUserBeAddPermission beAddPermission);

		// Token: 0x0601B86F RID: 112751 RVA: 0x008789E9 File Offset: 0x00876DE9
		public static IMAPI Instance()
		{
			if (IMAPI.s_Instance == null)
			{
				IMAPI.s_Instance = new IMAPI();
			}
			return IMAPI.s_Instance;
		}

		// Token: 0x0601B870 RID: 112752 RVA: 0x00878A04 File Offset: 0x00876E04
		public static int GetSDKVer()
		{
			return IMAPI.IM_GetSDKVer();
		}

		// Token: 0x0601B871 RID: 112753 RVA: 0x00878A0B File Offset: 0x00876E0B
		public void SetLoginListen(LoginListen listen)
		{
			this.m_loginListen = listen;
		}

		// Token: 0x0601B872 RID: 112754 RVA: 0x00878A14 File Offset: 0x00876E14
		public void SetMessageListen(MessageListen listen)
		{
			this.m_messageListen = listen;
		}

		// Token: 0x0601B873 RID: 112755 RVA: 0x00878A1D File Offset: 0x00876E1D
		public void SetChatRoomListen(ChatRoomListen listen)
		{
			this.m_groupListen = listen;
		}

		// Token: 0x0601B874 RID: 112756 RVA: 0x00878A26 File Offset: 0x00876E26
		public void SetDownloadListen(DownloadListen listen)
		{
			this.m_downloadListen = listen;
		}

		// Token: 0x0601B875 RID: 112757 RVA: 0x00878A2F File Offset: 0x00876E2F
		public void SetContactListen(ContactListen listen)
		{
			this.m_contactListen = listen;
		}

		// Token: 0x0601B876 RID: 112758 RVA: 0x00878A38 File Offset: 0x00876E38
		public void SetAudioPlayListen(AudioPlayListen listen)
		{
			this.m_audioPlayListen = listen;
		}

		// Token: 0x0601B877 RID: 112759 RVA: 0x00878A41 File Offset: 0x00876E41
		public void SetLocationListen(LocationListen listen)
		{
			this.m_locationListen = listen;
		}

		// Token: 0x0601B878 RID: 112760 RVA: 0x00878A4A File Offset: 0x00876E4A
		public void SetNoticeListen(NoticeListen listen)
		{
			this.m_noticeListen = listen;
		}

		// Token: 0x0601B879 RID: 112761 RVA: 0x00878A53 File Offset: 0x00876E53
		public void SetReconnectListen(ReconnectListen listen)
		{
			this.m_reconnectListen = listen;
		}

		// Token: 0x0601B87A RID: 112762 RVA: 0x00878A5C File Offset: 0x00876E5C
		public void SetFriendListen(FriendListen listen)
		{
			this.m_friendListen = listen;
		}

		// Token: 0x0601B87B RID: 112763 RVA: 0x00878A65 File Offset: 0x00876E65
		public void SetUserProfileListen(UserProfileListen listen)
		{
			this.m_userProfileListen = listen;
		}

		// Token: 0x0601B87C RID: 112764 RVA: 0x00878A70 File Offset: 0x00876E70
		public ErrorCode Init(string strAppKey, string strSecrect, ServerZone serverZone)
		{
			if (!IMAPI.inited)
			{
				IMAPI.inited = true;
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
				AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.youme.im.IMEngine");
				androidJavaClass2.CallStatic<int>("init", new object[]
				{
					@static
				});
			}
			Debug.Log("start init");
			IMAPI.IM_SetServerZone((int)serverZone);
			ErrorCode errorCode = (ErrorCode)IMAPI.IM_Init(strAppKey, strSecrect);
			if (errorCode == ErrorCode.Success)
			{
				GameObject gameObject = new GameObject("youme_update_once");
				Object.DontDestroyOnLoad(gameObject);
				gameObject.hideFlags = 1;
				gameObject.AddComponent<IMAPI.YIMUpdateObject>();
			}
			return errorCode;
		}

		// Token: 0x0601B87D RID: 112765 RVA: 0x00878B07 File Offset: 0x00876F07
		public ErrorCode SetDownloadAudioMessageSwitch(bool download)
		{
			return (ErrorCode)IMAPI.IM_SetDownloadAudioMessageSwitch(download);
		}

		// Token: 0x0601B87E RID: 112766 RVA: 0x00878B10 File Offset: 0x00876F10
		public int SetAutoRecvMsg(List<string> targets, bool bAutoRecv)
		{
			JsonData jsonData = new JsonData();
			for (int i = 0; i < targets.Count; i++)
			{
				jsonData.Add(targets[i]);
			}
			return IMAPI.IM_SetReceiveMessageSwitch(jsonData.ToJson(), bAutoRecv);
		}

		// Token: 0x0601B87F RID: 112767 RVA: 0x00878B54 File Offset: 0x00876F54
		public void SetRoomHistoryMessageSwitch(List<string> roomIDs, bool save)
		{
			JsonData jsonData = new JsonData();
			for (int i = 0; i < roomIDs.Count; i++)
			{
				jsonData.Add(roomIDs[i]);
			}
			IMAPI.IM_SetRoomHistoryMessageSwitch(jsonData.ToJson(), save);
		}

		// Token: 0x0601B880 RID: 112768 RVA: 0x00878B9C File Offset: 0x00876F9C
		public ErrorCode GetNewMessage(List<string> targets)
		{
			JsonData jsonData = new JsonData();
			for (int i = 0; i < targets.Count; i++)
			{
				jsonData.Add(targets[i]);
			}
			return (ErrorCode)IMAPI.IM_GetNewMessage(jsonData.ToJson());
		}

		// Token: 0x0601B881 RID: 112769 RVA: 0x00878BE0 File Offset: 0x00876FE0
		public static string GetFilterText(string strSource, ref int level)
		{
			IntPtr intPtr = IMAPI.IM_GetFilterText(strSource, ref level);
			if (intPtr == IntPtr.Zero)
			{
				return strSource;
			}
			string result = Marshal.PtrToStringAuto(intPtr);
			IMAPI.IM_DestroyFilterText(intPtr);
			return result;
		}

		// Token: 0x0601B882 RID: 112770 RVA: 0x00878C15 File Offset: 0x00877015
		public static void AllowThrowCallbackException(bool allow)
		{
			IMAPI.throwException = allow;
		}

		// Token: 0x0601B883 RID: 112771 RVA: 0x00878C20 File Offset: 0x00877020
		public static string GetFilterText(string strSource)
		{
			int num = 0;
			IntPtr intPtr = IMAPI.IM_GetFilterText(strSource, ref num);
			if (intPtr == IntPtr.Zero)
			{
				return strSource;
			}
			string result = Marshal.PtrToStringAuto(intPtr);
			IMAPI.IM_DestroyFilterText(intPtr);
			return result;
		}

		// Token: 0x0601B884 RID: 112772 RVA: 0x00878C58 File Offset: 0x00877058
		private void ParseJsonMessageCallback(string strMessage)
		{
			JsonData jsonData = JsonMapper.ToObject(strMessage);
			Command command = (Command)((int)jsonData["Command"]);
			ErrorCode errorCode = (ErrorCode)((int)jsonData["Errorcode"]);
			switch (command)
			{
			case Command.CMD_DOWNLOAD:
				if (this.m_downloadListen != null)
				{
					string strSavePath = (string)jsonData["SavePath"];
					MessageBodyType messageBodyType = (MessageBodyType)((int)jsonData["MessageType"]);
					if (messageBodyType == MessageBodyType.Voice)
					{
						VoiceMessage voiceMessage = new VoiceMessage();
						voiceMessage.ChatType = (ChatType)((int)jsonData["ChatType"]);
						voiceMessage.RequestID = ulong.Parse(jsonData["Serial"].ToString());
						voiceMessage.MessageType = messageBodyType;
						voiceMessage.RecvID = (string)jsonData["ReceiveID"];
						voiceMessage.SenderID = (string)jsonData["SenderID"];
						voiceMessage.Text = (string)jsonData["Text"];
						voiceMessage.Param = (string)jsonData["Param"];
						voiceMessage.Duration = (int)jsonData["Duration"];
						voiceMessage.CreateTime = (int)jsonData["CreateTime"];
						if (jsonData.Keys.Contains("Distance"))
						{
							voiceMessage.Distance = (uint)((int)jsonData["Distance"]);
						}
						if (jsonData.Keys.Contains("IsRead"))
						{
							voiceMessage.IsRead = ((int)jsonData["IsRead"] == 1);
						}
						this.m_downloadListen.OnDownload(errorCode, voiceMessage, strSavePath);
					}
					else if (messageBodyType == MessageBodyType.File)
					{
						FileMessage fileMessage = new FileMessage();
						fileMessage.ChatType = (ChatType)((int)jsonData["ChatType"]);
						fileMessage.RequestID = ulong.Parse(jsonData["Serial"].ToString());
						fileMessage.MessageType = messageBodyType;
						fileMessage.RecvID = (string)jsonData["ReceiveID"];
						fileMessage.SenderID = (string)jsonData["SenderID"];
						fileMessage.FileName = (string)jsonData["FileName"];
						fileMessage.FileSize = (int)jsonData["FileSize"];
						fileMessage.FileType = (FileType)((int)jsonData["FileType"]);
						fileMessage.FileExtension = (string)jsonData["FileExtension"];
						fileMessage.ExtParam = (string)jsonData["ExtraParam"];
						fileMessage.CreateTime = (int)jsonData["CreateTime"];
						if (jsonData.Keys.Contains("Distance"))
						{
							fileMessage.Distance = (uint)((int)jsonData["Distance"]);
						}
						if (jsonData.Keys.Contains("IsRead"))
						{
							fileMessage.IsRead = ((int)jsonData["IsRead"] == 1);
						}
						this.m_downloadListen.OnDownload(errorCode, fileMessage, strSavePath);
					}
				}
				break;
			case Command.CMD_SEND_MESSAGE_STATUS:
				if (this.m_messageListen != null)
				{
					this.m_messageListen.OnSendMessageStatus(ulong.Parse(jsonData["RequestID"].ToString()), errorCode, (uint)((int)jsonData["SendTime"]), (int)jsonData["IsForbidRoom"] != 0, (int)jsonData["reasonType"], ulong.Parse(jsonData["forbidEndTime"].ToString()));
				}
				break;
			case Command.CMD_RECV_MESSAGE:
				if (this.m_messageListen != null)
				{
					MessageInfoBase message = this.GetMessage(jsonData);
					if (message != null)
					{
						this.m_messageListen.OnRecvMessage(message);
					}
				}
				break;
			case Command.CMD_STOP_AUDIOSPEECH:
			{
				string strDownloadURL = (string)jsonData["DownloadURL"];
				int iDuration = (int)jsonData["Duration"];
				int iFileSize = (int)jsonData["FileSize"];
				string strLocalPath = (string)jsonData["LocalPath"];
				string s = (string)jsonData["RequestID"];
				string strText = (string)jsonData["Text"];
				if (this.m_messageListen != null)
				{
					this.m_messageListen.OnStopAudioSpeechStatus(errorCode, ulong.Parse(s), strDownloadURL, iDuration, iFileSize, strLocalPath, strText);
				}
				break;
			}
			case Command.CMD_QUERY_HISTORY_MESSAGE:
			{
				int remain = (int)jsonData["Remain"];
				string targetID = (string)jsonData["TargetID"];
				JsonData jsonData2 = jsonData["messageList"];
				List<HistoryMsg> list = new List<HistoryMsg>();
				for (int i = 0; i < jsonData2.Count; i++)
				{
					HistoryMsg historyMsg = new HistoryMsg();
					JsonData jsonData3 = jsonData2[i];
					historyMsg.ChatType = (ChatType)((int)jsonData3["ChatType"]);
					historyMsg.MessageType = (MessageBodyType)((int)jsonData3["MessageType"]);
					historyMsg.ReceiveID = (string)jsonData3["ReceiveID"];
					historyMsg.SenderID = (string)jsonData3["SenderID"];
					historyMsg.MessageID = ulong.Parse(jsonData3["Serial"].ToString());
					historyMsg.CreateTime = (int)jsonData3["CreateTime"];
					if (jsonData3.Keys.Contains("IsRead"))
					{
						historyMsg.IsRead = ((int)jsonData3["IsRead"] == 1);
					}
					if (historyMsg.MessageType == MessageBodyType.TXT)
					{
						historyMsg.Text = (string)jsonData3["Content"];
						historyMsg.Param = (string)jsonData3["Param"];
					}
					else if (historyMsg.MessageType == MessageBodyType.CustomMesssage)
					{
						historyMsg.Text = (string)jsonData3["Content"];
					}
					else if (historyMsg.MessageType == MessageBodyType.Voice)
					{
						historyMsg.Text = (string)jsonData3["Text"];
						historyMsg.LocalPath = (string)jsonData3["LocalPath"];
						historyMsg.Duration = (int)jsonData3["Duration"];
						historyMsg.Param = (string)jsonData3["Param"];
					}
					else if (historyMsg.MessageType == MessageBodyType.File)
					{
						historyMsg.LocalPath = (string)jsonData3["LocalPath"];
						historyMsg.Param = (string)jsonData3["Param"];
					}
					list.Add(historyMsg);
				}
				if (this.m_messageListen != null)
				{
					this.m_messageListen.OnQueryHistoryMessage(errorCode, targetID, remain, list);
				}
				break;
			}
			case Command.CMD_GET_RENCENT_CONTACTS:
			{
				List<ContactsSessionInfo> list2 = new List<ContactsSessionInfo>();
				JsonData jsonData4 = jsonData["contacts"];
				for (int j = 0; j < jsonData4.Count; j++)
				{
					JsonData jsonData5 = jsonData4[j];
					list2.Add(new ContactsSessionInfo
					{
						ContactID = (string)jsonData5["ContactID"],
						MessageType = (MessageBodyType)((int)jsonData5["MessageType"]),
						MessageContent = (string)jsonData5["MessageContent"],
						CreateTime = (int)jsonData5["CreateTime"],
						NotReadMsgNum = (uint)((int)jsonData5["NotReadMsgNum"])
					});
				}
				if (this.m_contactListen != null)
				{
					this.m_contactListen.OnGetContact(list2);
				}
				break;
			}
			case Command.CMD_RECEIVE_MESSAGE_NITIFY:
				if (this.m_messageListen != null)
				{
					ChatType chatType = (ChatType)((int)jsonData["ChatType"]);
					string targetID2 = (string)jsonData["TargetID"];
					this.m_messageListen.OnRecvNewMessage(chatType, targetID2);
				}
				break;
			case Command.CMD_QUERY_USER_STATUS:
				if (this.m_contactListen != null)
				{
					string userID = (string)jsonData["UserID"];
					UserStatus status = (UserStatus)((int)jsonData["Status"]);
					this.m_contactListen.OnQueryUserStatus(errorCode, userID, status);
				}
				break;
			case Command.CMD_AUDIO_PLAY_COMPLETE:
				if (this.m_audioPlayListen != null)
				{
					string path = (string)jsonData["Path"];
					this.m_audioPlayListen.OnPlayCompletion(errorCode, path);
				}
				break;
			case Command.CMD_STOP_SEND_AUDIO:
				if (this.m_messageListen != null)
				{
					string strText2 = (string)jsonData["Text"];
					string strAudioPath = (string)jsonData["LocalPath"];
					int iDuration2 = (int)jsonData["Duration"];
					this.m_messageListen.OnStartSendAudioMessage(ulong.Parse(jsonData["RequestID"].ToString()), errorCode, strText2, strAudioPath, iDuration2);
				}
				break;
			case Command.CMD_TRANSLATE_COMPLETE:
				if (this.m_messageListen != null)
				{
					uint key = (uint)((int)jsonData["RequestID"]);
					string arg = (string)jsonData["Text"];
					LanguageCode arg2 = (LanguageCode)((int)jsonData["SrcLangCode"]);
					LanguageCode arg3 = (LanguageCode)((int)jsonData["DestLangCode"]);
					Action<ErrorCode, string, LanguageCode, LanguageCode> action = null;
					bool flag = this.tranlateCallbackQuen.TryGetValue(key, out action);
					if (flag)
					{
						this.tranlateCallbackQuen.Remove(key);
						if (action != null)
						{
							action(errorCode, arg, arg2, arg3);
						}
					}
				}
				break;
			case Command.CMD_DOWNLOAD_URL:
				if (this.m_downloadListen != null)
				{
					string strFromUrl = (string)jsonData["FromUrl"];
					string strSavePath2 = (string)jsonData["SavePath"];
					this.m_downloadListen.OnDownloadByUrl(errorCode, strFromUrl, strSavePath2);
				}
				break;
			case Command.CMD_GET_MICROPHONE_STATUS:
				if (this.m_audioPlayListen != null)
				{
					AudioDeviceStatus status2 = (AudioDeviceStatus)((int)jsonData["Status"]);
					this.m_audioPlayListen.OnGetMicrophoneStatus(status2);
				}
				break;
			case Command.CMD_USER_ENTER_ROOM:
			{
				string strRoomID = (string)jsonData["ChannelID"];
				string strUserID = (string)jsonData["UserID"];
				this.m_groupListen.OnUserJoinChatRoom(strRoomID, strUserID);
				break;
			}
			case Command.CMD_USER_LEAVE_ROOM:
			{
				string strRoomID2 = (string)jsonData["ChannelID"];
				string strUserID2 = (string)jsonData["UserID"];
				this.m_groupListen.OnUserLeaveChatRoom(strRoomID2, strUserID2);
				break;
			}
			case Command.CMD_RECV_NOTICE:
				if (this.m_noticeListen != null)
				{
					Notice notice = new Notice();
					notice.NoticeID = ulong.Parse(jsonData["NoticeID"].ToString());
					notice.ChannelID = (string)jsonData["ChannelID"];
					notice.NoticeType = (int)jsonData["NoticeType"];
					notice.Content = (string)jsonData["NoticeContent"];
					notice.LinkText = (string)jsonData["LinkText"];
					notice.LinkAddr = (string)jsonData["LinkAddress"];
					notice.BeginTime = (uint)((int)jsonData["BeginTime"]);
					notice.EndTime = (uint)((int)jsonData["EndTime"]);
					this.m_noticeListen.OnRecvNotice(notice);
				}
				break;
			case Command.CMD_CANCEL_NOTICE:
				if (this.m_noticeListen != null)
				{
					ulong noticeID = ulong.Parse(jsonData["NoticeID"].ToString());
					string channelID = (string)jsonData["ChannelID"];
					this.m_noticeListen.OnCancelNotice(noticeID, channelID);
				}
				break;
			case Command.CMD_GET_SPEECH_TEXT:
				if (this.m_messageListen != null)
				{
					ulong iRequestID = ulong.Parse(jsonData["RequestID"].ToString());
					string text = (string)jsonData["Text"];
					this.m_messageListen.OnGetRecognizeSpeechText(iRequestID, errorCode, text);
				}
				break;
			case Command.CMD_GET_RECONNECT_RESULT:
				if (this.m_reconnectListen != null)
				{
					ReconnectResult result = (ReconnectResult)((int)jsonData["Result"]);
					this.m_reconnectListen.OnRecvReconnectResult(result);
				}
				break;
			case Command.CMD_START_RECONNECT:
				if (this.m_reconnectListen != null)
				{
					this.m_reconnectListen.OnStartReconnect();
				}
				break;
			case Command.CMD_RECORD_VOLUME:
				if (this.m_messageListen != null)
				{
					double num = (double)jsonData["Volume"];
					this.m_messageListen.OnRecordVolumeChange((float)num);
				}
				break;
			case Command.CMD_GET_DISTANCE:
			{
				string userID2 = (string)jsonData["UserID"];
				uint distance = (uint)((int)jsonData["Distance"]);
				if (this.m_locationListen != null)
				{
					this.m_locationListen.OnGetDistance(errorCode, userID2, distance);
				}
				break;
			}
			case Command.CMD_REQUEST_ADD_FRIEND_NOTIFY:
				if (this.m_friendListen != null)
				{
					string userID3 = (string)jsonData["UserID"];
					string comments = (string)jsonData["Comments"];
					this.m_friendListen.OnBeRequestAddFriendNotify(userID3, comments);
				}
				break;
			case Command.CMD_ADD_FRIENT_RESULT_NOTIFY:
				if (this.m_friendListen != null)
				{
					string userID4 = (string)jsonData["UserID"];
					string comments2 = (string)jsonData["Comments"];
					int dealResult = (int)jsonData["DealResult"];
					this.m_friendListen.OnRequestAddFriendResultNotify(userID4, comments2, dealResult);
				}
				break;
			case Command.CMD_BE_ADD_FRIENT:
				if (this.m_friendListen != null)
				{
					string userID5 = (string)jsonData["UserID"];
					string comments3 = (string)jsonData["Comments"];
					this.m_friendListen.OnBeAddFriendNotify(userID5, comments3);
				}
				break;
			case Command.CMD_BE_DELETE_FRIEND_NOTIFY:
				if (this.m_friendListen != null)
				{
					string userID6 = (string)jsonData["UserID"];
					this.m_friendListen.OnBeDeleteFriendNotify(userID6);
				}
				break;
			default:
				switch (command)
				{
				case Command.CMD_GET_ROOM_HISTORY_MSG:
				{
					int remain2 = (int)jsonData["Remain"];
					string roomID = (string)jsonData["RoomID"];
					JsonData jsonData6 = jsonData["MessageList"];
					List<MessageInfoBase> list3 = new List<MessageInfoBase>();
					for (int k = 0; k < jsonData6.Count; k++)
					{
						MessageInfoBase message2 = this.GetMessage(jsonData6[k]);
						if (message2 != null)
						{
							list3.Add(message2);
						}
					}
					if (this.m_messageListen != null)
					{
						this.m_messageListen.OnQueryRoomHistoryMessageFromServer(errorCode, roomID, remain2, list3);
					}
					break;
				}
				case Command.CMD_GET_USR_INFO:
					if (this.m_contactListen != null)
					{
						string userID7 = (string)jsonData["UserID"];
						string jsonStr = (string)jsonData["UserInfo"];
						this.m_contactListen.OnGetUserInfo(errorCode, userID7, new IMUserInfo().ParseFromJsonString(jsonStr));
					}
					break;
				default:
					switch (command)
					{
					case Command.CMD_FIND_FRIEND_BY_ID:
						if (this.m_friendListen != null)
						{
							JsonData jsonData7 = jsonData["UserList"];
							List<UserBriefInfo> list4 = new List<UserBriefInfo>();
							for (int l = 0; l < jsonData7.Count; l++)
							{
								JsonData jsonData8 = jsonData7[l];
								list4.Add(new UserBriefInfo
								{
									UserID = (string)jsonData8["UserID"],
									Nickname = (string)jsonData8["Nickname"],
									Status = (UserStatus)((int)jsonData8["Status"])
								});
							}
							this.m_friendListen.OnFindUser(errorCode, list4);
						}
						break;
					default:
						switch (command)
						{
						case Command.CMD_LOGIN:
							if (this.m_loginListen != null)
							{
								this.m_loginListen.OnLogin(errorCode, (string)jsonData["UserID"]);
							}
							break;
						default:
							if (command == Command.CMD_HXR_USER_INFO_CHANGE_NOTIFY)
							{
								if (this.m_userProfileListen != null)
								{
									string userID8 = (string)jsonData["UserID"];
									this.m_userProfileListen.OnUserInfoChangeNotify(userID8);
								}
							}
							break;
						case Command.CMD_LOGOUT:
							if (this.m_loginListen != null)
							{
								this.m_loginListen.OnLogout();
							}
							break;
						case Command.CMD_ENTER_ROOM:
							if (this.m_groupListen != null)
							{
								string strChatRoomID = (string)jsonData["GroupID"];
								this.m_groupListen.OnJoinRoom(errorCode, strChatRoomID);
							}
							break;
						case Command.CMD_LEAVE_ROOM:
							if (this.m_groupListen != null)
							{
								string strChatRoomID2 = (string)jsonData["GroupID"];
								this.m_groupListen.OnLeaveRoom(errorCode, strChatRoomID2);
							}
							break;
						case Command.CMD_SND_VOICE_MSG:
							if (this.m_messageListen != null)
							{
								string strText3 = (string)jsonData["Text"];
								string strAudioPath2 = (string)jsonData["LocalPath"];
								int iDuration3 = (int)jsonData["Duration"];
								this.m_messageListen.OnSendAudioMessageStatus(ulong.Parse(jsonData["RequestID"].ToString()), errorCode, strText3, strAudioPath2, iDuration3, (uint)((int)jsonData["SendTime"]), (int)jsonData["IsForbidRoom"] != 0, (int)jsonData["reasonType"], ulong.Parse(jsonData["forbidEndTime"].ToString()));
							}
							break;
						case Command.CMD_KICK_OFF:
							if (this.m_loginListen != null)
							{
								this.m_loginListen.OnKickOff();
							}
							break;
						}
						break;
					case Command.CMD_REQUEST_ADD_FRIEND:
						if (this.m_friendListen != null)
						{
							string userID9 = (string)jsonData["UserID"];
							this.m_friendListen.OnRequestAddFriend(errorCode, userID9);
						}
						break;
					case Command.CMD_DELETE_FRIEND:
						if (this.m_friendListen != null)
						{
							string userID10 = (string)jsonData["UserID"];
							this.m_friendListen.OnDeleteFriend(errorCode, userID10);
						}
						break;
					case Command.CMD_BLACK_FRIEND:
						if (this.m_friendListen != null)
						{
							int type = (int)jsonData["Type"];
							string userID11 = (string)jsonData["UserID"];
							this.m_friendListen.OnBlackFriend(errorCode, type, userID11);
						}
						break;
					case Command.CMD_DEAL_ADD_FRIEND:
						if (this.m_friendListen != null)
						{
							string userID12 = (string)jsonData["UserID"];
							string comments4 = (string)jsonData["Comments"];
							int dealResult2 = (int)jsonData["DealResult"];
							this.m_friendListen.OnDealBeRequestAddFriend(errorCode, userID12, comments4, dealResult2);
						}
						break;
					case Command.CMD_QUERY_FRIEND_LIST:
						if (this.m_friendListen != null)
						{
							int type2 = (int)jsonData["Type"];
							int startIndex = (int)jsonData["StartIndex"];
							JsonData jsonData9 = jsonData["UserList"];
							List<UserBriefInfo> list5 = new List<UserBriefInfo>();
							for (int m = 0; m < jsonData9.Count; m++)
							{
								JsonData jsonData10 = jsonData9[m];
								list5.Add(new UserBriefInfo
								{
									UserID = (string)jsonData10["UserID"],
									Nickname = (string)jsonData10["Nickname"],
									Status = (UserStatus)((int)jsonData10["Status"])
								});
							}
							this.m_friendListen.OnQueryFriends(errorCode, type2, startIndex, list5);
						}
						break;
					case Command.CMD_QUERY_FRIEND_REQUEST_LIST:
						if (this.m_friendListen != null)
						{
							int startIndex2 = (int)jsonData["StartIndex"];
							JsonData jsonData11 = jsonData["UserList"];
							List<FriendRequestInfo> list6 = new List<FriendRequestInfo>();
							for (int n = 0; n < jsonData11.Count; n++)
							{
								JsonData jsonData12 = jsonData11[n];
								list6.Add(new FriendRequestInfo
								{
									AskerID = (string)jsonData12["AskerID"],
									AskerNickname = (string)jsonData12["AskerNickname"],
									InviteeID = (string)jsonData12["InviteeID"],
									InviteeNickname = (string)jsonData12["InviteeNickname"],
									ValidateInfo = (string)jsonData12["ValidateInfo"],
									Status = (AddFriendStatus)((int)jsonData12["Status"]),
									CreateTime = (uint)((int)jsonData12["CreateTime"])
								});
							}
							this.m_friendListen.OnQueryFriendRequestList(errorCode, startIndex2, list6);
						}
						break;
					}
					break;
				case Command.CMD_GET_TIPOFF_MSG:
					if (this.m_messageListen != null)
					{
						AccusationDealResult result2 = (AccusationDealResult)((int)jsonData["Result"]);
						string userID13 = (string)jsonData["UserID"];
						uint accusationTime = (uint)((int)jsonData["AccusationTime"]);
						this.m_messageListen.OnAccusationResultNotify(result2, userID13, accusationTime);
					}
					break;
				case Command.CMD_GET_DISTRICT:
					if (this.m_locationListen != null)
					{
						GeographyLocation geographyLocation = new GeographyLocation();
						geographyLocation.DistrictCode = (uint)((int)jsonData["DistrictCode"]);
						geographyLocation.Country = (string)jsonData["Country"];
						geographyLocation.Province = (string)jsonData["Province"];
						geographyLocation.City = (string)jsonData["City"];
						geographyLocation.DistrictCounty = (string)jsonData["DistrictCounty"];
						geographyLocation.Street = (string)jsonData["Street"];
						geographyLocation.Longitude = (double)jsonData["Longitude"];
						geographyLocation.Latitude = (double)jsonData["Latitude"];
						this.m_locationListen.OnUpdateLocation(errorCode, geographyLocation);
					}
					break;
				case Command.CMD_GET_PEOPLE_NEARBY:
				{
					uint startDistance = (uint)((int)jsonData["StartDistance"]);
					uint endDistance = (uint)((int)jsonData["EndDistance"]);
					JsonData jsonData13 = jsonData["NeighbourList"];
					List<RelativeLocation> list7 = new List<RelativeLocation>();
					for (int num2 = 0; num2 < jsonData13.Count; num2++)
					{
						RelativeLocation relativeLocation = new RelativeLocation();
						JsonData jsonData14 = jsonData13[num2];
						relativeLocation.Distance = (uint)((int)jsonData14["Distance"]);
						relativeLocation.UserID = (string)jsonData14["UserID"];
						relativeLocation.Longitude = (double)jsonData14["Longitude"];
						relativeLocation.Latitude = (double)jsonData14["Latitude"];
						relativeLocation.Country = (string)jsonData14["Country"];
						relativeLocation.Province = (string)jsonData14["Province"];
						relativeLocation.City = (string)jsonData14["City"];
						relativeLocation.DistrictCounty = (string)jsonData14["DistrictCounty"];
						relativeLocation.Street = (string)jsonData14["Street"];
						list7.Add(relativeLocation);
					}
					if (this.m_locationListen != null)
					{
						this.m_locationListen.OnGetNearbyObjects(errorCode, list7, startDistance, endDistance);
					}
					break;
				}
				case Command.CMD_SET_MASK_USER_MSG:
					if (this.m_messageListen != null)
					{
						string userID14 = (string)jsonData["UserID"];
						bool block = (int)jsonData["Block"] == 1;
						this.m_messageListen.OnBlockUser(errorCode, userID14, block);
					}
					break;
				case Command.CMD_GET_MASK_USER_MSG:
					if (this.m_messageListen != null)
					{
						List<string> list8 = new List<string>();
						JsonData jsonData15 = jsonData["UserList"];
						for (int num3 = 0; num3 < jsonData15.Count; num3++)
						{
							string item = (string)jsonData15[num3];
							list8.Add(item);
						}
						this.m_messageListen.OnGetBlockUsers(errorCode, list8);
					}
					break;
				case Command.CMD_CLEAN_MASK_USER_MSG:
					if (this.m_messageListen != null)
					{
						this.m_messageListen.OnUnBlockAllUser(errorCode);
					}
					break;
				case Command.CMD_GET_ROOM_INFO:
					if (this.m_messageListen != null)
					{
						string strRoomID3 = (string)jsonData["RoomID"];
						uint count = (uint)((int)jsonData["Count"]);
						this.m_groupListen.OnGetRoomMemberCount(errorCode, strRoomID3, count);
					}
					break;
				case Command.CMD_LEAVE_ALL_ROOM:
					if (this.m_groupListen != null)
					{
						this.m_groupListen.OnLeaveAllRooms(errorCode);
					}
					break;
				case Command.CMD_GET_FORBID_RECORD:
					if (this.m_messageListen != null)
					{
						JsonData jsonData16 = jsonData["ForbiddenSpeakList"];
						List<ForbiddenSpeakInfo> list9 = new List<ForbiddenSpeakInfo>();
						for (int num4 = 0; num4 < jsonData16.Count; num4++)
						{
							ForbiddenSpeakInfo forbiddenSpeakInfo = new ForbiddenSpeakInfo();
							JsonData jsonData17 = jsonData16[num4];
							forbiddenSpeakInfo.ChannelID = (string)jsonData17["ChannelID"];
							forbiddenSpeakInfo.IsForbidRoom = ((int)jsonData17["IsForbidRoom"] != 0);
							forbiddenSpeakInfo.ReasonType = (int)jsonData17["reasonType"];
							forbiddenSpeakInfo.EndTime = ulong.Parse(jsonData17["forbidEndTime"].ToString());
							list9.Add(forbiddenSpeakInfo);
						}
						this.m_messageListen.OnGetForbiddenSpeakInfo(errorCode, list9);
					}
					break;
				}
				break;
			case Command.CMD_GET_USER_PROFILE:
				if (this.m_userProfileListen != null)
				{
					IMUserProfileInfo imuserProfileInfo = new IMUserProfileInfo();
					imuserProfileInfo.UserID = (string)jsonData["UserID"];
					imuserProfileInfo.PhotoURL = (string)jsonData["PhotoUrl"];
					imuserProfileInfo.OnlineState = (UserStatus)((int)jsonData["OnlineState"]);
					imuserProfileInfo.BeAddPermission = (IMUserBeAddPermission)((int)jsonData["BeAddPermission"]);
					imuserProfileInfo.FoundPermission = (IMUserFoundPermission)((int)jsonData["FoundPermission"]);
					imuserProfileInfo.NickName = (string)jsonData["NickName"];
					imuserProfileInfo.Sex = (IMUserSex)((int)jsonData["Sex"]);
					imuserProfileInfo.Signature = (string)jsonData["Signature"];
					imuserProfileInfo.Country = (string)jsonData["Country"];
					imuserProfileInfo.Province = (string)jsonData["Province"];
					imuserProfileInfo.City = (string)jsonData["City"];
					imuserProfileInfo.ExtraInfo = (string)jsonData["ExtraInfo"];
					this.m_userProfileListen.OnQueryUserInfo(errorCode, imuserProfileInfo);
				}
				break;
			case Command.CMD_SET_USER_PROFILE:
				if (this.m_userProfileListen != null)
				{
					this.m_userProfileListen.OnSetUserInfo(errorCode);
				}
				break;
			case Command.CMD_SET_USER_PHOTO:
				if (this.m_userProfileListen != null)
				{
					string photoUrl = (string)jsonData["PhotoUrl"];
					this.m_userProfileListen.OnSetPhotoUrl(errorCode, photoUrl);
				}
				break;
			case Command.CMD_SWITCH_USER_STATE:
				if (this.m_userProfileListen != null)
				{
					this.m_userProfileListen.OnSwitchUserOnlineState(errorCode);
				}
				break;
			}
		}

		// Token: 0x0601B885 RID: 112773 RVA: 0x0087A7B8 File Offset: 0x00878BB8
		public MessageInfoBase GetMessage(JsonData jsonMessage)
		{
			MessageBodyType messageBodyType = (MessageBodyType)((int)jsonMessage["MessageType"]);
			if (messageBodyType == MessageBodyType.TXT)
			{
				TextMessage textMessage = new TextMessage();
				textMessage.ChatType = (ChatType)((int)jsonMessage["ChatType"]);
				textMessage.RequestID = ulong.Parse(jsonMessage["Serial"].ToString());
				textMessage.MessageType = messageBodyType;
				textMessage.RecvID = (string)jsonMessage["ReceiveID"];
				textMessage.SenderID = (string)jsonMessage["SenderID"];
				textMessage.Content = (string)jsonMessage["Content"];
				textMessage.AttachParam = (string)jsonMessage["AttachParam"];
				textMessage.CreateTime = (int)jsonMessage["CreateTime"];
				if (jsonMessage.Keys.Contains("Distance"))
				{
					textMessage.Distance = (uint)((int)jsonMessage["Distance"]);
				}
				if (jsonMessage.Keys.Contains("IsRead"))
				{
					textMessage.IsRead = ((int)jsonMessage["IsRead"] == 1);
				}
				return textMessage;
			}
			if (messageBodyType == MessageBodyType.CustomMesssage)
			{
				CustomMessage customMessage = new CustomMessage();
				customMessage.ChatType = (ChatType)((int)jsonMessage["ChatType"]);
				customMessage.RequestID = ulong.Parse(jsonMessage["Serial"].ToString());
				customMessage.MessageType = messageBodyType;
				customMessage.RecvID = (string)jsonMessage["ReceiveID"];
				customMessage.SenderID = (string)jsonMessage["SenderID"];
				string s = (string)jsonMessage["Content"];
				customMessage.Content = Convert.FromBase64String(s);
				customMessage.CreateTime = (int)jsonMessage["CreateTime"];
				if (jsonMessage.Keys.Contains("Distance"))
				{
					customMessage.Distance = (uint)((int)jsonMessage["Distance"]);
				}
				if (jsonMessage.Keys.Contains("IsRead"))
				{
					customMessage.IsRead = ((int)jsonMessage["IsRead"] == 1);
				}
				return customMessage;
			}
			if (messageBodyType == MessageBodyType.Voice)
			{
				VoiceMessage voiceMessage = new VoiceMessage();
				voiceMessage.ChatType = (ChatType)((int)jsonMessage["ChatType"]);
				voiceMessage.RequestID = ulong.Parse(jsonMessage["Serial"].ToString());
				voiceMessage.MessageType = messageBodyType;
				voiceMessage.RecvID = (string)jsonMessage["ReceiveID"];
				voiceMessage.SenderID = (string)jsonMessage["SenderID"];
				voiceMessage.Text = (string)jsonMessage["Text"];
				voiceMessage.Param = (string)jsonMessage["Param"];
				voiceMessage.Duration = (int)jsonMessage["Duration"];
				voiceMessage.CreateTime = (int)jsonMessage["CreateTime"];
				if (jsonMessage.Keys.Contains("Distance"))
				{
					voiceMessage.Distance = (uint)((int)jsonMessage["Distance"]);
				}
				if (jsonMessage.Keys.Contains("IsRead"))
				{
					voiceMessage.IsRead = ((int)jsonMessage["IsRead"] == 1);
				}
				return voiceMessage;
			}
			if (messageBodyType == MessageBodyType.Gift)
			{
				GiftMessage giftMessage = new GiftMessage();
				giftMessage.ChatType = (ChatType)((int)jsonMessage["ChatType"]);
				giftMessage.RequestID = ulong.Parse(jsonMessage["Serial"].ToString());
				giftMessage.MessageType = messageBodyType;
				giftMessage.RecvID = (string)jsonMessage["ReceiveID"];
				giftMessage.SenderID = (string)jsonMessage["SenderID"];
				giftMessage.CreateTime = (int)jsonMessage["CreateTime"];
				if (jsonMessage.Keys.Contains("Distance"))
				{
					giftMessage.Distance = (uint)((int)jsonMessage["Distance"]);
				}
				if (jsonMessage.Keys.Contains("IsRead"))
				{
					giftMessage.IsRead = ((int)jsonMessage["IsRead"] == 1);
				}
				giftMessage.ExtParam = new ExtraGifParam().ParseFromJsonString((string)jsonMessage["Param"]);
				giftMessage.GiftID = (int)jsonMessage["GiftID"];
				giftMessage.GiftCount = (int)jsonMessage["GiftCount"];
				giftMessage.Anchor = (string)jsonMessage["Anchor"];
				return giftMessage;
			}
			if (messageBodyType == MessageBodyType.File)
			{
				FileMessage fileMessage = new FileMessage();
				fileMessage.ChatType = (ChatType)((int)jsonMessage["ChatType"]);
				fileMessage.RequestID = ulong.Parse(jsonMessage["Serial"].ToString());
				fileMessage.MessageType = messageBodyType;
				fileMessage.RecvID = (string)jsonMessage["ReceiveID"];
				fileMessage.SenderID = (string)jsonMessage["SenderID"];
				fileMessage.FileName = (string)jsonMessage["FileName"];
				fileMessage.FileSize = (int)jsonMessage["FileSize"];
				fileMessage.FileType = (FileType)((int)jsonMessage["FileType"]);
				fileMessage.FileExtension = (string)jsonMessage["FileExtension"];
				fileMessage.ExtParam = (string)jsonMessage["ExtraParam"];
				fileMessage.CreateTime = (int)jsonMessage["CreateTime"];
				if (jsonMessage.Keys.Contains("Distance"))
				{
					fileMessage.Distance = (uint)((int)jsonMessage["Distance"]);
				}
				if (jsonMessage.Keys.Contains("IsRead"))
				{
					fileMessage.IsRead = ((int)jsonMessage["IsRead"] == 1);
				}
				return fileMessage;
			}
			return null;
		}

		// Token: 0x0601B886 RID: 112774 RVA: 0x0087ADC6 File Offset: 0x008791C6
		public ErrorCode Login(string strYouMeID, string strPasswd, string strToken = "")
		{
			return (ErrorCode)IMAPI.IM_Login(strYouMeID, strPasswd, strToken);
		}

		// Token: 0x0601B887 RID: 112775 RVA: 0x0087ADD0 File Offset: 0x008791D0
		public ErrorCode Logout()
		{
			return (ErrorCode)IMAPI.IM_Logout();
		}

		// Token: 0x0601B888 RID: 112776 RVA: 0x0087ADD7 File Offset: 0x008791D7
		public ErrorCode SendTextMessage(string strRecvID, ChatType chatType, string strContent, string strAttachParam, ref ulong iRequestID)
		{
			return (ErrorCode)IMAPI.IM_SendTextMessage(strRecvID, (int)chatType, strContent, strAttachParam, ref iRequestID);
		}

		// Token: 0x0601B889 RID: 112777 RVA: 0x0087ADE5 File Offset: 0x008791E5
		public ErrorCode SendFile(string strRecvID, ChatType chatType, string strFilePath, string strExtParam, FileType fileType, ref ulong iRequestID)
		{
			return (ErrorCode)IMAPI.IM_SendFile(strRecvID, (int)chatType, strFilePath, strExtParam, (int)fileType, ref iRequestID);
		}

		// Token: 0x0601B88A RID: 112778 RVA: 0x0087ADF5 File Offset: 0x008791F5
		public ErrorCode SendAudioMessage(string strRecvID, ChatType chatType, ref ulong iRequestID)
		{
			return (ErrorCode)IMAPI.IM_SendAudioMessage(strRecvID, (int)chatType, ref iRequestID);
		}

		// Token: 0x0601B88B RID: 112779 RVA: 0x0087ADFF File Offset: 0x008791FF
		public ErrorCode SendOnlyAudioMessage(string strRecvID, ChatType chatType, ref ulong iRequestID)
		{
			return (ErrorCode)IMAPI.IM_SendOnlyAudioMessage(strRecvID, (int)chatType, ref iRequestID);
		}

		// Token: 0x0601B88C RID: 112780 RVA: 0x0087AE09 File Offset: 0x00879209
		public ErrorCode StopAudioMessage(string strParam)
		{
			return (ErrorCode)IMAPI.IM_StopAudioMessage(strParam);
		}

		// Token: 0x0601B88D RID: 112781 RVA: 0x0087AE11 File Offset: 0x00879211
		public ErrorCode CancleAudioMessage()
		{
			return (ErrorCode)IMAPI.IM_CancleAudioMessage();
		}

		// Token: 0x0601B88E RID: 112782 RVA: 0x0087AE18 File Offset: 0x00879218
		public ErrorCode DownloadAudioFile(ulong iRequestID, string strSavePath)
		{
			return (ErrorCode)IMAPI.IM_DownloadFile(iRequestID, strSavePath);
		}

		// Token: 0x0601B88F RID: 112783 RVA: 0x0087AE21 File Offset: 0x00879221
		public ErrorCode DownloadFileByUrl(string strFromUrl, string strSavePath)
		{
			return (ErrorCode)IMAPI.IM_DownloadFileByURL(strFromUrl, strSavePath);
		}

		// Token: 0x0601B890 RID: 112784 RVA: 0x0087AE2A File Offset: 0x0087922A
		public ErrorCode SendCustomMessage(string strRecvID, ChatType chatTpye, byte[] customMsg, ref ulong iRequestID)
		{
			return (ErrorCode)IMAPI.IM_SendCustomMessage(strRecvID, (int)chatTpye, customMsg, customMsg.Length, ref iRequestID);
		}

		// Token: 0x0601B891 RID: 112785 RVA: 0x0087AE39 File Offset: 0x00879239
		public ErrorCode JoinChatRoom(string strChatRoomID)
		{
			return (ErrorCode)IMAPI.IM_JoinChatRoom(strChatRoomID);
		}

		// Token: 0x0601B892 RID: 112786 RVA: 0x0087AE41 File Offset: 0x00879241
		public ErrorCode LeaveChatRoom(string strChatRoomID)
		{
			return (ErrorCode)IMAPI.IM_LeaveChatRoom(strChatRoomID);
		}

		// Token: 0x0601B893 RID: 112787 RVA: 0x0087AE49 File Offset: 0x00879249
		public ErrorCode LeaveAllChatRooms()
		{
			return (ErrorCode)IMAPI.IM_LeaveAllChatRooms();
		}

		// Token: 0x0601B894 RID: 112788 RVA: 0x0087AE50 File Offset: 0x00879250
		public ErrorCode GetRoomMemberCount(string strChatRoomID)
		{
			return (ErrorCode)IMAPI.IM_GetRoomMemberCount(strChatRoomID);
		}

		// Token: 0x0601B895 RID: 112789 RVA: 0x0087AE58 File Offset: 0x00879258
		public void SetAudioCachePath(string cachePath)
		{
			IMAPI.IM_SetAudioCacheDir(cachePath);
		}

		// Token: 0x0601B896 RID: 112790 RVA: 0x0087AE60 File Offset: 0x00879260
		public ErrorCode QueryHistoryMessage(string targetID, ChatType chatType, ulong startMessageID, int count, int direction)
		{
			return (ErrorCode)IMAPI.IM_QueryHistoryMessage(targetID, (int)chatType, startMessageID, count, direction);
		}

		// Token: 0x0601B897 RID: 112791 RVA: 0x0087AE6E File Offset: 0x0087926E
		public ErrorCode DeleteHistoryMessage(ChatType chatType, ulong time)
		{
			return (ErrorCode)IMAPI.IM_DeleteHistoryMessage(chatType, time);
		}

		// Token: 0x0601B898 RID: 112792 RVA: 0x0087AE77 File Offset: 0x00879277
		public ErrorCode DeleteHistoryMessageByID(ulong messageID)
		{
			return (ErrorCode)IMAPI.IM_DeleteHistoryMessageByID(messageID);
		}

		// Token: 0x0601B899 RID: 112793 RVA: 0x0087AE80 File Offset: 0x00879280
		public ErrorCode DeleteSpecifiedHistoryMessage(string targetID, ChatType chatType, ulong[] excludeMesList)
		{
			int num = excludeMesList.Length;
			return (ErrorCode)IMAPI.IM_DeleteSpecifiedHistoryMessage(targetID, chatType, excludeMesList, num);
		}

		// Token: 0x0601B89A RID: 112794 RVA: 0x0087AE9A File Offset: 0x0087929A
		public ErrorCode DeleteHistoryMessageByTarget(string targetID, ChatType chatType, ulong startMessageID, uint count)
		{
			return (ErrorCode)IMAPI.IM_DeleteHistoryMessageByTarget(targetID, chatType, startMessageID, count);
		}

		// Token: 0x0601B89B RID: 112795 RVA: 0x0087AEA6 File Offset: 0x008792A6
		public ErrorCode SetMessageRead(ulong messageID, bool read)
		{
			return (ErrorCode)IMAPI.IM_SetMessageRead(messageID, read);
		}

		// Token: 0x0601B89C RID: 112796 RVA: 0x0087AEAF File Offset: 0x008792AF
		public ErrorCode QueryRoomHistoryMessageFromServer(string roomID, int count, int direction)
		{
			return (ErrorCode)IMAPI.IM_QueryRoomHistoryMessageFromServer(roomID, count, direction);
		}

		// Token: 0x0601B89D RID: 112797 RVA: 0x0087AEB9 File Offset: 0x008792B9
		public ErrorCode StartAudioSpeech(ref ulong requestID, bool translate)
		{
			return (ErrorCode)IMAPI.IM_StartAudioSpeech(ref requestID, translate);
		}

		// Token: 0x0601B89E RID: 112798 RVA: 0x0087AEC2 File Offset: 0x008792C2
		public ErrorCode StopAudioSpeech()
		{
			return (ErrorCode)IMAPI.IM_StopAudioSpeech();
		}

		// Token: 0x0601B89F RID: 112799 RVA: 0x0087AEC9 File Offset: 0x008792C9
		public ErrorCode ConvertAMRToWav(string amrFilePath, string wavFielPath)
		{
			return (ErrorCode)IMAPI.IM_ConvertAMRToWav(amrFilePath, wavFielPath);
		}

		// Token: 0x0601B8A0 RID: 112800 RVA: 0x0087AED2 File Offset: 0x008792D2
		public void OnResume()
		{
			IMAPI.IM_OnResume();
		}

		// Token: 0x0601B8A1 RID: 112801 RVA: 0x0087AED9 File Offset: 0x008792D9
		public void OnPause(bool pauseReceiveMessage)
		{
			IMAPI.IM_OnPause(pauseReceiveMessage);
		}

		// Token: 0x0601B8A2 RID: 112802 RVA: 0x0087AEE1 File Offset: 0x008792E1
		public ErrorCode SendGift(string strAnchorId, string strChannel, int iGiftID, int iGiftCount, ExtraGifParam extParam, ref ulong serial)
		{
			return (ErrorCode)IMAPI.IM_SendGift(strAnchorId, strChannel, iGiftID, iGiftCount, extParam.ToJsonString(), ref serial);
		}

		// Token: 0x0601B8A3 RID: 112803 RVA: 0x0087AEF8 File Offset: 0x008792F8
		public ErrorCode MultiSendTextMessage(List<string> recvLists, string strText)
		{
			JsonData jsonData = new JsonData();
			for (int i = 0; i < recvLists.Count; i++)
			{
				jsonData.Add(recvLists[i]);
			}
			return (ErrorCode)IMAPI.IM_MultiSendTextMessage(jsonData.ToJson(), strText);
		}

		// Token: 0x0601B8A4 RID: 112804 RVA: 0x0087AF3C File Offset: 0x0087933C
		public ErrorCode GetHistoryContact()
		{
			return (ErrorCode)IMAPI.IM_GetRecentContacts();
		}

		// Token: 0x0601B8A5 RID: 112805 RVA: 0x0087AF43 File Offset: 0x00879343
		public ErrorCode GetUserInfo(string userID)
		{
			return (ErrorCode)IMAPI.IM_GetUserInfo(userID);
		}

		// Token: 0x0601B8A6 RID: 112806 RVA: 0x0087AF4B File Offset: 0x0087934B
		public ErrorCode SetUserInfo(IMUserInfo userInfo)
		{
			return (ErrorCode)IMAPI.IM_SetUserInfo(userInfo.ToJsonString());
		}

		// Token: 0x0601B8A7 RID: 112807 RVA: 0x0087AF58 File Offset: 0x00879358
		public ErrorCode QueryUserStatus(string userID)
		{
			return (ErrorCode)IMAPI.IM_QueryUserStatus(userID);
		}

		// Token: 0x0601B8A8 RID: 112808 RVA: 0x0087AF60 File Offset: 0x00879360
		public void SetVolume(float volume)
		{
			IMAPI.IM_SetVolume(volume);
		}

		// Token: 0x0601B8A9 RID: 112809 RVA: 0x0087AF68 File Offset: 0x00879368
		public ErrorCode StartPlayAudio(string path)
		{
			return (ErrorCode)IMAPI.IM_StartPlayAudio(path);
		}

		// Token: 0x0601B8AA RID: 112810 RVA: 0x0087AF70 File Offset: 0x00879370
		public ErrorCode StopPlayAudio()
		{
			return (ErrorCode)IMAPI.IM_StopPlayAudio();
		}

		// Token: 0x0601B8AB RID: 112811 RVA: 0x0087AF77 File Offset: 0x00879377
		public bool IsPlaying()
		{
			return IMAPI.IM_IsPlaying();
		}

		// Token: 0x0601B8AC RID: 112812 RVA: 0x0087AF80 File Offset: 0x00879380
		public string GetAudioCachePath()
		{
			string result = string.Empty;
			IntPtr intPtr = IMAPI.IM_GetAudioCachePath();
			if (intPtr == IntPtr.Zero)
			{
				return result;
			}
			result = Marshal.PtrToStringAuto(intPtr);
			IMAPI.IM_DestroyAudioCachePath(intPtr);
			return result;
		}

		// Token: 0x0601B8AD RID: 112813 RVA: 0x0087AFB9 File Offset: 0x008793B9
		public bool ClearAudioCachePath()
		{
			return IMAPI.IM_ClearAudioCachePath();
		}

		// Token: 0x0601B8AE RID: 112814 RVA: 0x0087AFC0 File Offset: 0x008793C0
		public void TranslateText(string text, LanguageCode destLangCode, LanguageCode srcLangCode, Action<ErrorCode, string, LanguageCode, LanguageCode> callback)
		{
			uint key = 0U;
			ErrorCode errorCode = (ErrorCode)IMAPI.IM_TranslateText(ref key, text, destLangCode, srcLangCode);
			if (errorCode == ErrorCode.Success)
			{
				this.tranlateCallbackQuen.Add(key, callback);
			}
			else
			{
				callback(errorCode, string.Empty, srcLangCode, destLangCode);
			}
		}

		// Token: 0x0601B8AF RID: 112815 RVA: 0x0087B002 File Offset: 0x00879402
		public ErrorCode GetCurrentLocation()
		{
			return (ErrorCode)IMAPI.IM_GetCurrentLocation();
		}

		// Token: 0x0601B8B0 RID: 112816 RVA: 0x0087B009 File Offset: 0x00879409
		public ErrorCode GetNearbyObjects(int count, string serverAreaID, DistrictLevel districtlevel = DistrictLevel.DISTRICT_UNKNOW, bool resetStartDistance = false)
		{
			return (ErrorCode)IMAPI.IM_GetNearbyObjects(count, serverAreaID, districtlevel, resetStartDistance);
		}

		// Token: 0x0601B8B1 RID: 112817 RVA: 0x0087B015 File Offset: 0x00879415
		public ErrorCode GetDistance(string userID)
		{
			return (ErrorCode)IMAPI.IM_GetDistance(userID);
		}

		// Token: 0x0601B8B2 RID: 112818 RVA: 0x0087B01D File Offset: 0x0087941D
		public void SetUpdateInterval(uint interval)
		{
			IMAPI.IM_SetUpdateInterval(interval);
		}

		// Token: 0x0601B8B3 RID: 112819 RVA: 0x0087B025 File Offset: 0x00879425
		public void SetKeepRecordModel(bool keep)
		{
			IMAPI.IM_SetKeepRecordModel(keep);
		}

		// Token: 0x0601B8B4 RID: 112820 RVA: 0x0087B02D File Offset: 0x0087942D
		public ErrorCode SetSpeechRecognizeLanguage(SpeechLanguage language)
		{
			return (ErrorCode)IMAPI.IM_SetSpeechRecognizeLanguage(language);
		}

		// Token: 0x0601B8B5 RID: 112821 RVA: 0x0087B035 File Offset: 0x00879435
		public ErrorCode SetOnlyRecognizeSpeechText(bool recognition)
		{
			return (ErrorCode)IMAPI.IM_SetOnlyRecognizeSpeechText(recognition);
		}

		// Token: 0x0601B8B6 RID: 112822 RVA: 0x0087B03D File Offset: 0x0087943D
		public ErrorCode GetMicrophoneStatus()
		{
			return (ErrorCode)IMAPI.IM_GetMicrophoneStatus();
		}

		// Token: 0x0601B8B7 RID: 112823 RVA: 0x0087B044 File Offset: 0x00879444
		public ErrorCode Accusation(string userID, ChatType source, int reason, string description, string extraParam)
		{
			return (ErrorCode)IMAPI.IM_Accusation(userID, source, reason, description, extraParam);
		}

		// Token: 0x0601B8B8 RID: 112824 RVA: 0x0087B052 File Offset: 0x00879452
		public ErrorCode QueryNotice()
		{
			return (ErrorCode)IMAPI.IM_QueryNotice();
		}

		// Token: 0x0601B8B9 RID: 112825 RVA: 0x0087B059 File Offset: 0x00879459
		public ErrorCode GetForbiddenSpeakInfo()
		{
			return (ErrorCode)IMAPI.IM_GetForbiddenSpeakInfo();
		}

		// Token: 0x0601B8BA RID: 112826 RVA: 0x0087B060 File Offset: 0x00879460
		public ErrorCode BlockUser(string userID, bool block)
		{
			return (ErrorCode)IMAPI.IM_BlockUser(userID, block);
		}

		// Token: 0x0601B8BB RID: 112827 RVA: 0x0087B069 File Offset: 0x00879469
		public ErrorCode UnBlockAllUser()
		{
			return (ErrorCode)IMAPI.IM_UnBlockAllUser();
		}

		// Token: 0x0601B8BC RID: 112828 RVA: 0x0087B070 File Offset: 0x00879470
		public ErrorCode GetBlockUsers()
		{
			return (ErrorCode)IMAPI.IM_GetBlockUsers();
		}

		// Token: 0x0601B8BD RID: 112829 RVA: 0x0087B077 File Offset: 0x00879477
		public ErrorCode SetDownloadDir(string path)
		{
			return (ErrorCode)IMAPI.IM_SetDownloadDir(path);
		}

		// Token: 0x0601B8BE RID: 112830 RVA: 0x0087B07F File Offset: 0x0087947F
		public ErrorCode FindUser(int findType, string target)
		{
			return (ErrorCode)IMAPI.IM_FindUser(findType, target);
		}

		// Token: 0x0601B8BF RID: 112831 RVA: 0x0087B088 File Offset: 0x00879488
		private ErrorCode RequestAddFriend(List<string> users, string comments)
		{
			JsonData jsonData = new JsonData();
			for (int i = 0; i < users.Count; i++)
			{
				jsonData.Add(users[i]);
			}
			return (ErrorCode)IMAPI.IM_RequestAddFriend(jsonData.ToJson(), comments);
		}

		// Token: 0x0601B8C0 RID: 112832 RVA: 0x0087B0CC File Offset: 0x008794CC
		public ErrorCode DealAddFriend(string userID, int dealResult)
		{
			return (ErrorCode)IMAPI.IM_DealAddFriend(userID, dealResult);
		}

		// Token: 0x0601B8C1 RID: 112833 RVA: 0x0087B0D8 File Offset: 0x008794D8
		public ErrorCode DeleteFriend(List<string> users, int deleteType = 1)
		{
			JsonData jsonData = new JsonData();
			for (int i = 0; i < users.Count; i++)
			{
				jsonData.Add(users[i]);
			}
			return (ErrorCode)IMAPI.IM_DeleteFriend(jsonData.ToJson(), deleteType);
		}

		// Token: 0x0601B8C2 RID: 112834 RVA: 0x0087B11C File Offset: 0x0087951C
		public ErrorCode BlackFriend(int type, List<string> users)
		{
			JsonData jsonData = new JsonData();
			for (int i = 0; i < users.Count; i++)
			{
				jsonData.Add(users[i]);
			}
			return (ErrorCode)IMAPI.IM_BlackFriend(type, jsonData.ToJson());
		}

		// Token: 0x0601B8C3 RID: 112835 RVA: 0x0087B160 File Offset: 0x00879560
		public ErrorCode QueryFriends(int type = 0, int startIndex = 0, int count = 50)
		{
			return (ErrorCode)IMAPI.IM_QueryFriends(type, startIndex, count);
		}

		// Token: 0x0601B8C4 RID: 112836 RVA: 0x0087B16A File Offset: 0x0087956A
		public ErrorCode QueryFriendRequestList(int startIndex = 0, int count = 20)
		{
			return (ErrorCode)IMAPI.IM_QueryFriendRequestList(startIndex, count);
		}

		// Token: 0x0601B8C5 RID: 112837 RVA: 0x0087B174 File Offset: 0x00879574
		public ErrorCode SetUserProfileInfo(IMUserSettingInfo settingInfo)
		{
			return (ErrorCode)IMAPI.IM_SetUserProfileInfo(JsonMapper.ToJson(new Dictionary<string, string>
			{
				{
					"NickName",
					settingInfo.NickName
				},
				{
					"Sex",
					((int)settingInfo.Sex).ToString()
				},
				{
					"Signature",
					settingInfo.Signature
				},
				{
					"Country",
					settingInfo.Country
				},
				{
					"Province",
					settingInfo.Province
				},
				{
					"City",
					settingInfo.City
				},
				{
					"ExtraInfo",
					settingInfo.ExtraInfo
				}
			}));
		}

		// Token: 0x0601B8C6 RID: 112838 RVA: 0x0087B217 File Offset: 0x00879617
		public ErrorCode GetUserProfileInfo(string userID = "")
		{
			return (ErrorCode)IMAPI.IM_GetUserProfileInfo(userID);
		}

		// Token: 0x0601B8C7 RID: 112839 RVA: 0x0087B21F File Offset: 0x0087961F
		public ErrorCode SetUserProfilePhoto(string photoPath)
		{
			return (ErrorCode)IMAPI.IM_SetUserProfilePhoto(photoPath);
		}

		// Token: 0x0601B8C8 RID: 112840 RVA: 0x0087B227 File Offset: 0x00879627
		public ErrorCode SwitchUserStatus(string userID, UserStatus userStatus)
		{
			return (ErrorCode)IMAPI.IM_SwitchUserStatus(userID, userStatus);
		}

		// Token: 0x0601B8C9 RID: 112841 RVA: 0x0087B230 File Offset: 0x00879630
		public ErrorCode SetAddPermission(bool beFound, IMUserBeAddPermission beAddPermission)
		{
			return (ErrorCode)IMAPI.IM_SetAddPermission(beFound, beAddPermission);
		}

		// Token: 0x040131F5 RID: 78325
		private static IMAPI s_Instance;

		// Token: 0x040131F6 RID: 78326
		private LoginListen m_loginListen;

		// Token: 0x040131F7 RID: 78327
		private MessageListen m_messageListen;

		// Token: 0x040131F8 RID: 78328
		private ChatRoomListen m_groupListen;

		// Token: 0x040131F9 RID: 78329
		private DownloadListen m_downloadListen;

		// Token: 0x040131FA RID: 78330
		private ContactListen m_contactListen;

		// Token: 0x040131FB RID: 78331
		private AudioPlayListen m_audioPlayListen;

		// Token: 0x040131FC RID: 78332
		private LocationListen m_locationListen;

		// Token: 0x040131FD RID: 78333
		private NoticeListen m_noticeListen;

		// Token: 0x040131FE RID: 78334
		private ReconnectListen m_reconnectListen;

		// Token: 0x040131FF RID: 78335
		private FriendListen m_friendListen;

		// Token: 0x04013200 RID: 78336
		private UserProfileListen m_userProfileListen;

		// Token: 0x04013201 RID: 78337
		private Dictionary<uint, Action<ErrorCode, string, LanguageCode, LanguageCode>> tranlateCallbackQuen = new Dictionary<uint, Action<ErrorCode, string, LanguageCode, LanguageCode>>();

		// Token: 0x04013202 RID: 78338
		public static bool inited;

		// Token: 0x04013203 RID: 78339
		public static bool throwException;

		// Token: 0x02004A4E RID: 19022
		private class YIMUpdateObject : MonoBehaviour
		{
			// Token: 0x0601B8CC RID: 112844 RVA: 0x0087B243 File Offset: 0x00879643
			private void Start()
			{
				base.InvokeRepeating("YIMUpdate", 0.5f, 0.05f);
			}

			// Token: 0x0601B8CD RID: 112845 RVA: 0x0087B25C File Offset: 0x0087965C
			private void YIMUpdate()
			{
				IntPtr intPtr = IMAPI.IM_GetMessage2();
				if (intPtr == IntPtr.Zero)
				{
					return;
				}
				string text = Marshal.PtrToStringAuto(intPtr);
				if (text != null)
				{
					if (IMAPI.throwException)
					{
						IMAPI.Instance().ParseJsonMessageCallback(text);
					}
					else
					{
						try
						{
							IMAPI.Instance().ParseJsonMessageCallback(text);
						}
						catch (Exception ex)
						{
							Debug.LogError(ex.Message);
						}
					}
				}
				IMAPI.IM_PopMessage(intPtr);
			}
		}
	}
}
