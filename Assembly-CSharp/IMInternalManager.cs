using System;
using System.Collections.Generic;
using UnityEngine;
using YIMEngine;
using YouMe;

// Token: 0x02004AA9 RID: 19113
public class IMInternalManager : LoginListen, MessageListen, ChatRoomListen, DownloadListen, ContactListen, AudioPlayListen, LocationListen, NoticeListen, ReconnectListen
{
	// Token: 0x0601BBDB RID: 113627 RVA: 0x00882004 File Offset: 0x00880404
	private IMInternalManager()
	{
		GameObject gameObject = new GameObject("__YIMGameObjectV2__");
		Object.DontDestroyOnLoad(gameObject);
		gameObject.hideFlags = 52;
		gameObject.AddComponent<IMInternalManager.YIMBehaviour>();
		IMAPI.Instance().SetLoginListen(this);
		IMAPI.Instance().SetMessageListen(this);
		IMAPI.Instance().SetDownloadListen(this);
		IMAPI.Instance().SetChatRoomListen(this);
		IMAPI.Instance().SetContactListen(this);
		IMAPI.Instance().SetAudioPlayListen(this);
		IMAPI.Instance().SetLocationListen(this);
		IMAPI.Instance().SetNoticeListen(this);
		IMAPI.Instance().SetReconnectListen(this);
	}

	// Token: 0x17002562 RID: 9570
	// (get) Token: 0x0601BBDC RID: 113628 RVA: 0x008820CE File Offset: 0x008804CE
	public static IMInternalManager Instance
	{
		get
		{
			if (IMInternalManager._instance == null)
			{
				IMInternalManager._instance = new IMInternalManager();
			}
			return IMInternalManager._instance;
		}
	}

	// Token: 0x17002563 RID: 9571
	// (get) Token: 0x0601BBDD RID: 113629 RVA: 0x008820E9 File Offset: 0x008804E9
	public IMUser LastLoginUser
	{
		get
		{
			return this._lastLoginUser;
		}
	}

	// Token: 0x0601BBDE RID: 113630 RVA: 0x008820F1 File Offset: 0x008804F1
	public bool AddMessageCallback(ulong reqID, MessageCallbackObject callback)
	{
		if (!this.messageCallbackQueue.ContainsKey(reqID))
		{
			this.messageCallbackQueue.Add(reqID, callback);
			return true;
		}
		Log.e("message id is already in sending queue.");
		return false;
	}

	// Token: 0x0601BBDF RID: 113631 RVA: 0x00882123 File Offset: 0x00880523
	public bool AddDownloadCallback(ulong reqID, Action<StatusCode, IMMessage, string> callback)
	{
		if (!this.downloadCallbackQueue.ContainsKey(reqID))
		{
			this.downloadCallbackQueue.Add(reqID, callback);
			return true;
		}
		Log.e("file already in download queue.");
		return false;
	}

	// Token: 0x0601BBE0 RID: 113632 RVA: 0x00882155 File Offset: 0x00880555
	public bool AddUrlDownloadCallback(string downloadUrl, Action<StatusCode, string> callback)
	{
		if (!this.urlDownloadCallbackQueue.ContainsKey(downloadUrl))
		{
			this.urlDownloadCallbackQueue.Add(downloadUrl, callback);
			return true;
		}
		Log.e("file already in url download queue.");
		return false;
	}

	// Token: 0x0601BBE1 RID: 113633 RVA: 0x00882187 File Offset: 0x00880587
	public bool AddUploadCallback(ulong reqID, Action<StatusCode, SpeechInfo> callback)
	{
		if (!this.uploadCallbackQueue.ContainsKey(reqID))
		{
			this.uploadCallbackQueue.Add(reqID, callback);
			return true;
		}
		Log.e("file already in upload queue.");
		return false;
	}

	// Token: 0x0601BBE2 RID: 113634 RVA: 0x008821BC File Offset: 0x008805BC
	public void OnLogin(ErrorCode errorcode, string iYouMeID)
	{
		if (errorcode == ErrorCode.Success)
		{
			this._lastLoginUser = new IMUser(iYouMeID);
		}
		if (IMClient.Instance.ConnectListener != null)
		{
			IMConnectEvent obj = new IMConnectEvent(Conv.ErrorCodeConvert(errorcode), (errorcode != ErrorCode.Success) ? ConnectEventType.CONNECT_FAIL : ConnectEventType.CONNECTED, iYouMeID);
			IMClient.Instance.ConnectListener(obj);
		}
	}

	// Token: 0x0601BBE3 RID: 113635 RVA: 0x00882214 File Offset: 0x00880614
	public void OnLogout()
	{
		if (IMClient.Instance.ConnectListener != null)
		{
			IMConnectEvent obj = new IMConnectEvent(StatusCode.Success, ConnectEventType.DISCONNECTED, this._lastLoginUser.UserID);
			IMClient.Instance.ConnectListener(obj);
		}
	}

	// Token: 0x0601BBE4 RID: 113636 RVA: 0x00882254 File Offset: 0x00880654
	public void OnKickOff()
	{
		if (IMClient.Instance.ConnectListener != null)
		{
			IMConnectEvent obj = new IMConnectEvent(StatusCode.Success, ConnectEventType.KICKED, this._lastLoginUser.UserID);
			IMClient.Instance.ConnectListener(obj);
		}
	}

	// Token: 0x0601BBE5 RID: 113637 RVA: 0x00882294 File Offset: 0x00880694
	public void OnSendMessageStatus(ulong iRequestID, ErrorCode errorcode, uint sendTime, bool isForbidRoom, int reasonType, ulong forbidEndTime)
	{
		MessageCallbackObject messageCallbackObject = null;
		bool flag = this.messageCallbackQueue.TryGetValue(iRequestID, out messageCallbackObject);
		if (flag)
		{
			if (messageCallbackObject != null && messageCallbackObject.callback != null)
			{
				try
				{
					MessageBodyType msgType = messageCallbackObject.msgType;
					if (msgType != MessageBodyType.TXT)
					{
						if (msgType != MessageBodyType.CustomMesssage)
						{
							if (msgType != MessageBodyType.File)
							{
								if (msgType == MessageBodyType.Gift)
								{
									Action<StatusCode, global::GiftMessage> action = (Action<StatusCode, global::GiftMessage>)messageCallbackObject.callback;
									global::GiftMessage giftMessage = (global::GiftMessage)messageCallbackObject.message;
									giftMessage.SendTime = TimeUtil.ConvertToTimestamp(DateTime.Now);
									if (errorcode == ErrorCode.Success)
									{
										giftMessage.SendStatus = SendStatus.Sended;
									}
									else
									{
										giftMessage.SendStatus = SendStatus.Fail;
									}
									giftMessage.IsReceiveFromServer = false;
									action(Conv.ErrorCodeConvert(errorcode), giftMessage);
								}
							}
							else
							{
								Action<StatusCode, global::FileMessage> action2 = (Action<StatusCode, global::FileMessage>)messageCallbackObject.callback;
								global::FileMessage fileMessage = (global::FileMessage)messageCallbackObject.message;
								fileMessage.SendTime = TimeUtil.ConvertToTimestamp(DateTime.Now);
								if (errorcode == ErrorCode.Success)
								{
									fileMessage.SendStatus = SendStatus.Sended;
								}
								else
								{
									fileMessage.SendStatus = SendStatus.Fail;
								}
								fileMessage.IsReceiveFromServer = false;
								action2(Conv.ErrorCodeConvert(errorcode), fileMessage);
							}
						}
						else
						{
							Action<StatusCode, global::CustomMessage> action3 = (Action<StatusCode, global::CustomMessage>)messageCallbackObject.callback;
							global::CustomMessage customMessage = (global::CustomMessage)messageCallbackObject.message;
							customMessage.SendTime = TimeUtil.ConvertToTimestamp(DateTime.Now);
							if (errorcode == ErrorCode.Success)
							{
								customMessage.SendStatus = SendStatus.Sended;
							}
							else
							{
								customMessage.SendStatus = SendStatus.Fail;
							}
							customMessage.IsReceiveFromServer = false;
							action3(Conv.ErrorCodeConvert(errorcode), customMessage);
						}
					}
					else
					{
						Action<StatusCode, global::TextMessage> action4 = (Action<StatusCode, global::TextMessage>)messageCallbackObject.callback;
						global::TextMessage textMessage = (global::TextMessage)messageCallbackObject.message;
						textMessage.SendTime = TimeUtil.ConvertToTimestamp(DateTime.Now);
						if (errorcode == ErrorCode.Success)
						{
							textMessage.SendStatus = SendStatus.Sended;
						}
						else
						{
							textMessage.SendStatus = SendStatus.Fail;
						}
						textMessage.IsReceiveFromServer = false;
						action4(Conv.ErrorCodeConvert(errorcode), textMessage);
					}
				}
				catch (Exception ex)
				{
					Log.e(ex.ToString());
				}
			}
			this.messageCallbackQueue.Remove(iRequestID);
		}
	}

	// Token: 0x0601BBE6 RID: 113638 RVA: 0x008824C0 File Offset: 0x008808C0
	public bool ResolveMessage(MessageInfoBase message, out IMMessage messageObj)
	{
		messageObj = null;
		switch (message.MessageType)
		{
		case MessageBodyType.TXT:
		{
			YIMEngine.TextMessage textMessage = (YIMEngine.TextMessage)message;
			messageObj = new global::TextMessage(message.SenderID, message.RecvID, message.ChatType, textMessage.Content, true)
			{
				SendTime = (uint)message.CreateTime,
				SendStatus = SendStatus.Sended,
				Distance = message.Distance
			};
			goto IL_24E;
		}
		case MessageBodyType.CustomMesssage:
		{
			YIMEngine.CustomMessage customMessage = (YIMEngine.CustomMessage)message;
			messageObj = new global::CustomMessage(message.SenderID, message.RecvID, message.ChatType, customMessage.Content, true)
			{
				SendTime = (uint)message.CreateTime,
				SendStatus = SendStatus.Sended,
				Distance = message.Distance
			};
			goto IL_24E;
		}
		case MessageBodyType.Voice:
		{
			VoiceMessage voiceMessage = (VoiceMessage)message;
			messageObj = new AudioMessage(message.SenderID, message.RecvID, message.ChatType, voiceMessage.Param, true)
			{
				RecongnizeText = voiceMessage.Text,
				AudioDuration = voiceMessage.Duration,
				SendTime = (uint)message.CreateTime,
				SendStatus = SendStatus.Sended,
				Distance = message.Distance
			};
			goto IL_24E;
		}
		case MessageBodyType.File:
		{
			YIMEngine.FileMessage fileMessage = (YIMEngine.FileMessage)message;
			messageObj = new global::FileMessage(message.SenderID, message.RecvID, message.ChatType, fileMessage.ExtParam, fileMessage.FileType, true)
			{
				SendTime = (uint)message.CreateTime,
				FileName = fileMessage.FileName,
				FileSize = fileMessage.FileSize,
				Extension = fileMessage.FileExtension,
				SendStatus = SendStatus.Sended,
				Distance = message.Distance
			};
			goto IL_24E;
		}
		case MessageBodyType.Gift:
		{
			YIMEngine.GiftMessage giftMessage = (YIMEngine.GiftMessage)message;
			messageObj = new global::GiftMessage(message.SenderID, message.RecvID, giftMessage.GiftID, giftMessage.GiftCount, giftMessage.ExtParam, true)
			{
				SendTime = (uint)message.CreateTime,
				SendStatus = SendStatus.Sended,
				Distance = message.Distance
			};
			goto IL_24E;
		}
		}
		Log.e("unknown message type:" + message.MessageType.ToString());
		IL_24E:
		if (messageObj != null)
		{
			messageObj.RequestID = message.RequestID;
			return true;
		}
		return false;
	}

	// Token: 0x0601BBE7 RID: 113639 RVA: 0x00882734 File Offset: 0x00880B34
	public void OnRecvMessage(MessageInfoBase message)
	{
		if (IMClient.Instance.ReceiveMessageListener != null)
		{
			IMMessage obj = null;
			if (this.ResolveMessage(message, out obj))
			{
				IMClient.Instance.ReceiveMessageListener(obj);
			}
		}
	}

	// Token: 0x0601BBE8 RID: 113640 RVA: 0x00882770 File Offset: 0x00880B70
	public void OnRecvNewMessage(ChatType chatType, string targetID)
	{
		IMClient.Instance.RecvNewMessageListener(chatType, targetID);
	}

	// Token: 0x0601BBE9 RID: 113641 RVA: 0x00882783 File Offset: 0x00880B83
	public void OnStartSendAudioMessage(ulong iRequestID, ErrorCode errorcode, string strText, string strAudioPath, int iDuration)
	{
		this.OnSendAudioMessageStatusChange(iRequestID, errorcode, strText, strAudioPath, iDuration, false);
	}

	// Token: 0x0601BBEA RID: 113642 RVA: 0x00882793 File Offset: 0x00880B93
	public void OnSendAudioMessageStatus(ulong iRequestID, ErrorCode errorcode, string strText, string strAudioPath, int iDuration, uint sendTime, bool isForbidRoom, int reasonType, ulong forbidEndTime)
	{
		this.OnSendAudioMessageStatusChange(iRequestID, errorcode, strText, strAudioPath, iDuration, true);
	}

	// Token: 0x0601BBEB RID: 113643 RVA: 0x008827A4 File Offset: 0x00880BA4
	private void OnSendAudioMessageStatusChange(ulong iRequestID, ErrorCode errorcode, string strText, string strAudioPath, int iDuration, bool isFinish)
	{
		MessageCallbackObject messageCallbackObject = null;
		bool flag = this.messageCallbackQueue.TryGetValue(iRequestID, out messageCallbackObject);
		if (flag)
		{
			if (messageCallbackObject != null && messageCallbackObject.callback != null)
			{
				Action<StatusCode, AudioMessage> action = (Action<StatusCode, AudioMessage>)messageCallbackObject.callback;
				AudioMessage audioMessage = (AudioMessage)messageCallbackObject.message;
				audioMessage.RecongnizeText = strText;
				audioMessage.AudioFilePath = strAudioPath;
				audioMessage.AudioDuration = iDuration;
				if (!isFinish)
				{
					audioMessage.SendTime = TimeUtil.ConvertToTimestamp(DateTime.Now);
				}
				if (errorcode == ErrorCode.Success)
				{
					audioMessage.SendStatus = ((!isFinish) ? SendStatus.Sending : SendStatus.Sended);
					audioMessage.MessageDownloadStatus = MessageDownloadStatus.DOWNLOADING;
				}
				else
				{
					audioMessage.SendStatus = SendStatus.Fail;
				}
				audioMessage.IsReceiveFromServer = false;
				action(Conv.ErrorCodeConvert(errorcode), audioMessage);
			}
			if (isFinish)
			{
				this.messageCallbackQueue.Remove(iRequestID);
			}
		}
	}

	// Token: 0x0601BBEC RID: 113644 RVA: 0x00882874 File Offset: 0x00880C74
	public void OnQueryHistoryMessage(ErrorCode errorcode, string targetID, int remain, List<HistoryMsg> messageList)
	{
		for (int i = 0; i < messageList.Count; i++)
		{
			HistoryMsg historyMsg = messageList[i];
		}
		if (IMClient.Instance.QueryHistoryMesListener != null)
		{
			IMHistoryMessageInfo arg = new IMHistoryMessageInfo(targetID, remain, messageList);
			IMClient.Instance.QueryHistoryMesListener(Conv.ErrorCodeConvert(errorcode), arg);
		}
	}

	// Token: 0x0601BBED RID: 113645 RVA: 0x008828D4 File Offset: 0x00880CD4
	public void OnQueryRoomHistoryMessageFromServer(ErrorCode errorcode, string roomID, int remain, List<MessageInfoBase> messageList)
	{
		if (IMClient.Instance.QueryRoomHistoryMsgFromServerListener != null)
		{
			List<IMMessage> list = new List<IMMessage>();
			list.Clear();
			for (int i = 0; i < messageList.Count; i++)
			{
				MessageInfoBase message = messageList[i];
				IMMessage item = null;
				if (this.ResolveMessage(message, out item))
				{
					list.Add(item);
				}
			}
			IMClient.Instance.QueryRoomHistoryMsgFromServerListener(Conv.ErrorCodeConvert(errorcode), roomID, (uint)remain, list);
		}
	}

	// Token: 0x0601BBEE RID: 113646 RVA: 0x0088294C File Offset: 0x00880D4C
	public void OnStopAudioSpeechStatus(ErrorCode errorcode, ulong iRequestID, string strDownloadURL, int iDuraton, int iFileSize, string strLocalPath, string strText)
	{
		Action<StatusCode, SpeechInfo> action = null;
		bool flag = this.uploadCallbackQueue.TryGetValue(iRequestID, out action);
		if (flag)
		{
			if (action != null)
			{
				try
				{
					SpeechInfo speechInfo = new SpeechInfo(iRequestID);
					speechInfo.HasUpload = true;
					speechInfo.Duration = iDuraton;
					speechInfo.FileSize = iFileSize;
					speechInfo.DownloadURL = strDownloadURL;
					speechInfo.LocalPath = strLocalPath;
					speechInfo.Text = strText;
					action(Conv.ErrorCodeConvert(errorcode), speechInfo);
				}
				catch (Exception ex)
				{
					Log.e("OnStopAudioSpeechStatus error:" + ex.ToString());
				}
			}
			this.uploadCallbackQueue.Remove(iRequestID);
		}
	}

	// Token: 0x0601BBEF RID: 113647 RVA: 0x008829F8 File Offset: 0x00880DF8
	public void OnAccusationResultNotify(AccusationDealResult result, string userID, uint accusationTime)
	{
		if (IMClient.Instance.AccusationListener != null)
		{
			IMAccusationInfo arg = new IMAccusationInfo(result, userID, accusationTime);
			IMClient.Instance.AccusationListener(Conv.ErrorCodeConvert(ErrorCode.Success), arg);
		}
	}

	// Token: 0x0601BBF0 RID: 113648 RVA: 0x00882A33 File Offset: 0x00880E33
	public void OnGetForbiddenSpeakInfo(ErrorCode errorcode, List<ForbiddenSpeakInfo> forbiddenSpeakList)
	{
		if (IMClient.Instance.GetForbiddenSpeakInfoListener != null)
		{
			IMClient.Instance.GetForbiddenSpeakInfoListener(Conv.ErrorCodeConvert(errorcode), forbiddenSpeakList);
		}
	}

	// Token: 0x0601BBF1 RID: 113649 RVA: 0x00882A5A File Offset: 0x00880E5A
	public void OnGetRecognizeSpeechText(ulong iRequestID, ErrorCode errorcode, string text)
	{
		if (IMClient.Instance.GetRecognizeSpeechTextListener != null)
		{
			IMClient.Instance.GetRecognizeSpeechTextListener(Conv.ErrorCodeConvert(errorcode), iRequestID, text);
		}
	}

	// Token: 0x0601BBF2 RID: 113650 RVA: 0x00882A82 File Offset: 0x00880E82
	public void OnBlockUser(ErrorCode errorcode, string userID, bool block)
	{
		if (IMClient.Instance.BlockUserListener != null)
		{
			IMClient.Instance.BlockUserListener(Conv.ErrorCodeConvert(errorcode), block);
		}
	}

	// Token: 0x0601BBF3 RID: 113651 RVA: 0x00882AA9 File Offset: 0x00880EA9
	public void OnUnBlockAllUser(ErrorCode errorcode)
	{
		if (IMClient.Instance.UnblockAllUserListener != null)
		{
			IMClient.Instance.UnblockAllUserListener(Conv.ErrorCodeConvert(errorcode));
		}
	}

	// Token: 0x0601BBF4 RID: 113652 RVA: 0x00882ACF File Offset: 0x00880ECF
	public void OnGetBlockUsers(ErrorCode errorcode, List<string> userList)
	{
		if (IMClient.Instance.GetBlockUsersListener != null)
		{
			IMClient.Instance.GetBlockUsersListener(Conv.ErrorCodeConvert(errorcode), userList);
		}
	}

	// Token: 0x0601BBF5 RID: 113653 RVA: 0x00882AF6 File Offset: 0x00880EF6
	public void OnRecordVolumeChange(float volume)
	{
		if (IMClient.Instance.RecordVolumeListener != null)
		{
			IMClient.Instance.RecordVolumeListener(volume);
		}
	}

	// Token: 0x0601BBF6 RID: 113654 RVA: 0x00882B18 File Offset: 0x00880F18
	public void OnJoinRoom(ErrorCode errorcode, string strChatRoomID)
	{
		if (IMClient.Instance.ChannelEventListener != null)
		{
			ChannelEventType eType = (errorcode != ErrorCode.Success) ? ChannelEventType.JOIN_FAIL : ChannelEventType.JOIN_SUCCESS;
			IMClient.Instance.ChannelEventListener(new ChannelEvent(Conv.ErrorCodeConvert(errorcode), eType, strChatRoomID));
		}
	}

	// Token: 0x0601BBF7 RID: 113655 RVA: 0x00882B60 File Offset: 0x00880F60
	public void OnLeaveRoom(ErrorCode errorcode, string strChatRoomID)
	{
		if (IMClient.Instance.ChannelEventListener != null)
		{
			ChannelEventType eType = (errorcode != ErrorCode.Success) ? ChannelEventType.LEAVE_FAIL : ChannelEventType.LEAVE_SUCCESS;
			IMClient.Instance.ChannelEventListener(new ChannelEvent(Conv.ErrorCodeConvert(errorcode), eType, strChatRoomID));
		}
	}

	// Token: 0x0601BBF8 RID: 113656 RVA: 0x00882BA8 File Offset: 0x00880FA8
	public void OnLeaveAllRooms(ErrorCode errorcode)
	{
		if (IMClient.Instance.ChannelEventListener != null)
		{
			ChannelEventType eType = (errorcode != ErrorCode.Success) ? ChannelEventType.LEAVE_ALL_FAIL : ChannelEventType.LEAVE_ALL_SUCCESS;
			IMClient.Instance.ChannelEventListener(new ChannelEvent(Conv.ErrorCodeConvert(errorcode), eType, string.Empty));
		}
	}

	// Token: 0x0601BBF9 RID: 113657 RVA: 0x00882BF2 File Offset: 0x00880FF2
	public void OnUserJoinChatRoom(string strRoomID, string strUserID)
	{
		if (IMClient.Instance.OtherUserChannelEventListener != null)
		{
			IMClient.Instance.OtherUserChannelEventListener(new OtherUserChannelEvent(OtherUserChannelEventType.JOIN_CHANNEL, strRoomID, strUserID));
		}
	}

	// Token: 0x0601BBFA RID: 113658 RVA: 0x00882C1A File Offset: 0x0088101A
	public void OnUserLeaveChatRoom(string strRoomID, string strUserID)
	{
		if (IMClient.Instance.OtherUserChannelEventListener != null)
		{
			IMClient.Instance.OtherUserChannelEventListener(new OtherUserChannelEvent(OtherUserChannelEventType.LEAVE_CHANNEL, strRoomID, strUserID));
		}
	}

	// Token: 0x0601BBFB RID: 113659 RVA: 0x00882C42 File Offset: 0x00881042
	public void OnGetRoomMemberCount(ErrorCode errorcode, string strRoomID, uint count)
	{
		if (IMClient.Instance.GetRoomMemberCountListener != null)
		{
			IMClient.Instance.GetRoomMemberCountListener(Conv.ErrorCodeConvert(errorcode), strRoomID, count);
		}
	}

	// Token: 0x0601BBFC RID: 113660 RVA: 0x00882C6C File Offset: 0x0088106C
	public void OnDownload(ErrorCode errorcode, MessageInfoBase message, string strSavePath)
	{
		Action<StatusCode, IMMessage, string> action = null;
		bool flag = this.downloadCallbackQueue.TryGetValue(message.RequestID, out action);
		if (flag)
		{
			if (action != null)
			{
				try
				{
					IMMessage arg = null;
					if (this.ResolveMessage(message, out arg))
					{
						action(Conv.ErrorCodeConvert(errorcode), arg, strSavePath);
					}
				}
				catch (Exception ex)
				{
					Log.e("OnDownload error:" + ex.ToString());
				}
			}
			this.downloadCallbackQueue.Remove(message.RequestID);
		}
		if (IMClient.Instance.DownloadListener != null)
		{
			AudioMessage audioMessage = null;
			MessageBodyType messageType = message.MessageType;
			if (messageType == MessageBodyType.Voice)
			{
				VoiceMessage voiceMessage = (VoiceMessage)message;
				AudioMessage audioMessage2 = new AudioMessage(message.SenderID, message.RecvID, message.ChatType, voiceMessage.Param, true);
				audioMessage2.RecongnizeText = voiceMessage.Text;
				audioMessage2.AudioDuration = voiceMessage.Duration;
				audioMessage2.SendTime = (uint)message.CreateTime;
				audioMessage2.SendStatus = SendStatus.Sended;
				audioMessage2.AudioFilePath = strSavePath;
				if (errorcode == ErrorCode.Success)
				{
					audioMessage2.MessageDownloadStatus = MessageDownloadStatus.DOWNLOADED;
				}
				else
				{
					audioMessage2.MessageDownloadStatus = MessageDownloadStatus.DOWNLOAD_FAIL;
				}
				audioMessage = audioMessage2;
			}
			if (audioMessage != null)
			{
				try
				{
					IMClient.Instance.DownloadListener(Conv.ErrorCodeConvert(errorcode), audioMessage, strSavePath);
				}
				catch (Exception ex2)
				{
					Log.e("OnDownload error:" + ex2.ToString());
				}
			}
		}
	}

	// Token: 0x0601BBFD RID: 113661 RVA: 0x00882DFC File Offset: 0x008811FC
	public void OnDownloadByUrl(ErrorCode errorcode, string strFromUrl, string strSavePath)
	{
		Action<StatusCode, string> action = null;
		bool flag = this.urlDownloadCallbackQueue.TryGetValue(strFromUrl, out action);
		if (flag)
		{
			if (action != null)
			{
				try
				{
					action(Conv.ErrorCodeConvert(errorcode), strSavePath);
				}
				catch (Exception ex)
				{
					Log.e("OnDownloadByUrl error:" + ex.ToString());
				}
			}
			this.urlDownloadCallbackQueue.Remove(strFromUrl);
		}
	}

	// Token: 0x0601BBFE RID: 113662 RVA: 0x00882E70 File Offset: 0x00881270
	public void OnGetContact(List<ContactsSessionInfo> contactLists)
	{
		if (IMClient.Instance.GetContactListener != null)
		{
			IMClient.Instance.GetContactListener(Conv.ErrorCodeConvert(ErrorCode.Success), contactLists);
		}
	}

	// Token: 0x0601BBFF RID: 113663 RVA: 0x00882E97 File Offset: 0x00881297
	public void OnGetUserInfo(ErrorCode code, string userID, IMUserInfo userInfo)
	{
		if (IMClient.Instance.GetUserInfoListener != null)
		{
			IMClient.Instance.GetUserInfoListener(Conv.ErrorCodeConvert(code), userInfo);
		}
	}

	// Token: 0x0601BC00 RID: 113664 RVA: 0x00882EBE File Offset: 0x008812BE
	public void OnQueryUserStatus(ErrorCode code, string userID, UserStatus status)
	{
		if (IMClient.Instance.QueryUserStatusListener != null)
		{
			IMClient.Instance.QueryUserStatusListener(Conv.ErrorCodeConvert(code), (YIMUserStatus)status);
		}
	}

	// Token: 0x0601BC01 RID: 113665 RVA: 0x00882EE5 File Offset: 0x008812E5
	public void OnUpdateLocation(ErrorCode errorcode, GeographyLocation location)
	{
		if (IMClient.Instance.GetCurrentLocationListener != null)
		{
			IMClient.Instance.GetCurrentLocationListener(Conv.ErrorCodeConvert(errorcode), location);
		}
	}

	// Token: 0x0601BC02 RID: 113666 RVA: 0x00882F0C File Offset: 0x0088130C
	public void OnGetNearbyObjects(ErrorCode errorcode, List<RelativeLocation> neighbourList, uint startDistance, uint endDistance)
	{
		if (IMClient.Instance.GetNearbyObjectsListener != null)
		{
			IMNearbyObjectInfo arg = new IMNearbyObjectInfo(neighbourList, startDistance, endDistance);
			IMClient.Instance.GetNearbyObjectsListener(Conv.ErrorCodeConvert(errorcode), arg);
		}
	}

	// Token: 0x0601BC03 RID: 113667 RVA: 0x00882F48 File Offset: 0x00881348
	public void OnGetDistance(ErrorCode errorcode, string userID, uint distance)
	{
	}

	// Token: 0x0601BC04 RID: 113668 RVA: 0x00882F4A File Offset: 0x0088134A
	public void OnPlayCompletion(ErrorCode errorcode, string path)
	{
		if (IMClient.Instance.PlayListener != null)
		{
			IMClient.Instance.PlayListener(Conv.ErrorCodeConvert(errorcode), path);
		}
	}

	// Token: 0x0601BC05 RID: 113669 RVA: 0x00882F71 File Offset: 0x00881371
	public void OnGetMicrophoneStatus(AudioDeviceStatus status)
	{
		if (IMClient.Instance.GetMicrophoneStatusListener != null)
		{
			IMClient.Instance.GetMicrophoneStatusListener(Conv.ErrorCodeConvert(ErrorCode.Success), (IMAudioDeviceStatus)status);
		}
	}

	// Token: 0x0601BC06 RID: 113670 RVA: 0x00882F98 File Offset: 0x00881398
	public void OnRecvNotice(Notice notice)
	{
		if (IMClient.Instance.RecvNoticeListener != null)
		{
			IMClient.Instance.RecvNoticeListener(notice);
		}
	}

	// Token: 0x0601BC07 RID: 113671 RVA: 0x00882FB9 File Offset: 0x008813B9
	public void OnCancelNotice(ulong noticeID, string channelID)
	{
		if (IMClient.Instance.CancelNoticeListener != null)
		{
			IMClient.Instance.CancelNoticeListener(noticeID, channelID);
		}
	}

	// Token: 0x0601BC08 RID: 113672 RVA: 0x00882FDC File Offset: 0x008813DC
	public void OnStartReconnect()
	{
		if (IMClient.Instance.ReconnectListener != null)
		{
			IMClient.Instance.ReconnectListener(new IMReconnectEvent(ReconnectEventType.START_RECONNECT, ReconnectEventResult.RECONNECTRESULT_STARTING_RECONNECT));
		}
		if (IMClient.Instance.ConnectListener != null)
		{
			IMClient.Instance.ConnectListener(new IMConnectEvent(StatusCode.Disconnect, ConnectEventType.OFF_LINE, this._lastLoginUser.UserID));
		}
	}

	// Token: 0x0601BC09 RID: 113673 RVA: 0x0088303F File Offset: 0x0088143F
	public void OnRecvReconnectResult(ReconnectResult result)
	{
		if (IMClient.Instance.ReconnectListener != null)
		{
			IMClient.Instance.ReconnectListener(new IMReconnectEvent(ReconnectEventType.END_RECONNECT, (ReconnectEventResult)result));
		}
	}

	// Token: 0x04013588 RID: 79240
	private static IMInternalManager _instance;

	// Token: 0x04013589 RID: 79241
	private IMUser _lastLoginUser;

	// Token: 0x0401358A RID: 79242
	private Dictionary<ulong, MessageCallbackObject> messageCallbackQueue = new Dictionary<ulong, MessageCallbackObject>(10);

	// Token: 0x0401358B RID: 79243
	private Dictionary<ulong, Action<StatusCode, IMMessage, string>> downloadCallbackQueue = new Dictionary<ulong, Action<StatusCode, IMMessage, string>>(10);

	// Token: 0x0401358C RID: 79244
	private Dictionary<string, Action<StatusCode, string>> urlDownloadCallbackQueue = new Dictionary<string, Action<StatusCode, string>>(10);

	// Token: 0x0401358D RID: 79245
	private Dictionary<ulong, Action<StatusCode, SpeechInfo>> uploadCallbackQueue = new Dictionary<ulong, Action<StatusCode, SpeechInfo>>(10);

	// Token: 0x02004AAA RID: 19114
	private class YIMBehaviour : MonoBehaviour
	{
		// Token: 0x0601BC0B RID: 113675 RVA: 0x0088306E File Offset: 0x0088146E
		private void OnApplicationQuit()
		{
			IMAPI.Instance().Logout();
		}

		// Token: 0x0601BC0C RID: 113676 RVA: 0x0088307B File Offset: 0x0088147B
		private void OnApplicationPause(bool isPause)
		{
			if (isPause)
			{
				IMAPI.Instance().OnPause(false);
			}
			else
			{
				IMAPI.Instance().OnResume();
			}
		}
	}
}
