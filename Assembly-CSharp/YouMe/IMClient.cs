using System;
using System.Collections.Generic;
using YIMEngine;

namespace YouMe
{
	// Token: 0x02004AA8 RID: 19112
	public class IMClient : IClient
	{
		// Token: 0x0601BB58 RID: 113496 RVA: 0x00880D84 File Offset: 0x0087F184
		private IMClient()
		{
			this.IMManager = IMInternalManager.Instance;
			this.ConnectListener = new Action<IMConnectEvent>(this.OnConnect);
			this.ChannelEventListener = new Action<ChannelEvent>(this.OnChannelEvent);
		}

		// Token: 0x17002547 RID: 9543
		// (get) Token: 0x0601BB59 RID: 113497 RVA: 0x00880DD1 File Offset: 0x0087F1D1
		public static IMClient Instance
		{
			get
			{
				if (IMClient._ins == null)
				{
					IMClient._ins = new IMClient();
				}
				return IMClient._ins;
			}
		}

		// Token: 0x0601BB5A RID: 113498 RVA: 0x00880DEC File Offset: 0x0087F1EC
		~IMClient()
		{
			this._downloadDirPath = string.Empty;
		}

		// Token: 0x17002548 RID: 9544
		// (get) Token: 0x0601BB5C RID: 113500 RVA: 0x00880E29 File Offset: 0x0087F229
		// (set) Token: 0x0601BB5B RID: 113499 RVA: 0x00880E20 File Offset: 0x0087F220
		public Action<IMConnectEvent> ConnectListener { get; set; }

		// Token: 0x17002549 RID: 9545
		// (get) Token: 0x0601BB5E RID: 113502 RVA: 0x00880E3A File Offset: 0x0087F23A
		// (set) Token: 0x0601BB5D RID: 113501 RVA: 0x00880E31 File Offset: 0x0087F231
		public Action<ChannelEvent> ChannelEventListener { get; set; }

		// Token: 0x1700254A RID: 9546
		// (get) Token: 0x0601BB60 RID: 113504 RVA: 0x00880E4B File Offset: 0x0087F24B
		// (set) Token: 0x0601BB5F RID: 113503 RVA: 0x00880E42 File Offset: 0x0087F242
		public Action<IMReconnectEvent> ReconnectListener { get; set; }

		// Token: 0x1700254B RID: 9547
		// (get) Token: 0x0601BB62 RID: 113506 RVA: 0x00880E5C File Offset: 0x0087F25C
		// (set) Token: 0x0601BB61 RID: 113505 RVA: 0x00880E53 File Offset: 0x0087F253
		public Action<OtherUserChannelEvent> OtherUserChannelEventListener { get; set; }

		// Token: 0x1700254C RID: 9548
		// (get) Token: 0x0601BB64 RID: 113508 RVA: 0x00880E6D File Offset: 0x0087F26D
		// (set) Token: 0x0601BB63 RID: 113507 RVA: 0x00880E64 File Offset: 0x0087F264
		public Action<IMMessage> ReceiveMessageListener { get; set; }

		// Token: 0x1700254D RID: 9549
		// (get) Token: 0x0601BB66 RID: 113510 RVA: 0x00880E7E File Offset: 0x0087F27E
		// (set) Token: 0x0601BB65 RID: 113509 RVA: 0x00880E75 File Offset: 0x0087F275
		public Action<StatusCode, string> PlayListener { get; set; }

		// Token: 0x1700254E RID: 9550
		// (get) Token: 0x0601BB68 RID: 113512 RVA: 0x00880E8F File Offset: 0x0087F28F
		// (set) Token: 0x0601BB67 RID: 113511 RVA: 0x00880E86 File Offset: 0x0087F286
		public Action<StatusCode, string, uint> GetRoomMemberCountListener { get; set; }

		// Token: 0x1700254F RID: 9551
		// (get) Token: 0x0601BB6A RID: 113514 RVA: 0x00880EA0 File Offset: 0x0087F2A0
		// (set) Token: 0x0601BB69 RID: 113513 RVA: 0x00880E97 File Offset: 0x0087F297
		public Action<StatusCode, IMHistoryMessageInfo> QueryHistoryMesListener { get; set; }

		// Token: 0x17002550 RID: 9552
		// (get) Token: 0x0601BB6C RID: 113516 RVA: 0x00880EB1 File Offset: 0x0087F2B1
		// (set) Token: 0x0601BB6B RID: 113515 RVA: 0x00880EA8 File Offset: 0x0087F2A8
		public Action<StatusCode, string, uint, List<IMMessage>> QueryRoomHistoryMsgFromServerListener { get; set; }

		// Token: 0x17002551 RID: 9553
		// (get) Token: 0x0601BB6E RID: 113518 RVA: 0x00880EC2 File Offset: 0x0087F2C2
		// (set) Token: 0x0601BB6D RID: 113517 RVA: 0x00880EB9 File Offset: 0x0087F2B9
		public Action<StatusCode, List<ContactsSessionInfo>> GetContactListener { get; set; }

		// Token: 0x17002552 RID: 9554
		// (get) Token: 0x0601BB70 RID: 113520 RVA: 0x00880ED3 File Offset: 0x0087F2D3
		// (set) Token: 0x0601BB6F RID: 113519 RVA: 0x00880ECA File Offset: 0x0087F2CA
		public Action<StatusCode, IMUserInfo> GetUserInfoListener { get; set; }

		// Token: 0x17002553 RID: 9555
		// (get) Token: 0x0601BB72 RID: 113522 RVA: 0x00880EE4 File Offset: 0x0087F2E4
		// (set) Token: 0x0601BB71 RID: 113521 RVA: 0x00880EDB File Offset: 0x0087F2DB
		public Action<StatusCode, YIMUserStatus> QueryUserStatusListener { get; set; }

		// Token: 0x17002554 RID: 9556
		// (get) Token: 0x0601BB74 RID: 113524 RVA: 0x00880EF5 File Offset: 0x0087F2F5
		// (set) Token: 0x0601BB73 RID: 113523 RVA: 0x00880EEC File Offset: 0x0087F2EC
		public Action<StatusCode, IMNearbyObjectInfo> GetNearbyObjectsListener { get; set; }

		// Token: 0x17002555 RID: 9557
		// (get) Token: 0x0601BB76 RID: 113526 RVA: 0x00880F06 File Offset: 0x0087F306
		// (set) Token: 0x0601BB75 RID: 113525 RVA: 0x00880EFD File Offset: 0x0087F2FD
		public Action<StatusCode, IMAudioDeviceStatus> GetMicrophoneStatusListener { get; set; }

		// Token: 0x17002556 RID: 9558
		// (get) Token: 0x0601BB78 RID: 113528 RVA: 0x00880F17 File Offset: 0x0087F317
		// (set) Token: 0x0601BB77 RID: 113527 RVA: 0x00880F0E File Offset: 0x0087F30E
		public Action<StatusCode, List<ForbiddenSpeakInfo>> GetForbiddenSpeakInfoListener { get; set; }

		// Token: 0x17002557 RID: 9559
		// (get) Token: 0x0601BB7A RID: 113530 RVA: 0x00880F28 File Offset: 0x0087F328
		// (set) Token: 0x0601BB79 RID: 113529 RVA: 0x00880F1F File Offset: 0x0087F31F
		public Action<StatusCode, bool> BlockUserListener { get; set; }

		// Token: 0x17002558 RID: 9560
		// (get) Token: 0x0601BB7C RID: 113532 RVA: 0x00880F39 File Offset: 0x0087F339
		// (set) Token: 0x0601BB7B RID: 113531 RVA: 0x00880F30 File Offset: 0x0087F330
		public Action<StatusCode> UnblockAllUserListener { get; set; }

		// Token: 0x17002559 RID: 9561
		// (get) Token: 0x0601BB7E RID: 113534 RVA: 0x00880F4A File Offset: 0x0087F34A
		// (set) Token: 0x0601BB7D RID: 113533 RVA: 0x00880F41 File Offset: 0x0087F341
		public Action<StatusCode, List<string>> GetBlockUsersListener { get; set; }

		// Token: 0x1700255A RID: 9562
		// (get) Token: 0x0601BB80 RID: 113536 RVA: 0x00880F5B File Offset: 0x0087F35B
		// (set) Token: 0x0601BB7F RID: 113535 RVA: 0x00880F52 File Offset: 0x0087F352
		public Action<StatusCode, GeographyLocation> GetCurrentLocationListener { get; set; }

		// Token: 0x1700255B RID: 9563
		// (get) Token: 0x0601BB82 RID: 113538 RVA: 0x00880F6C File Offset: 0x0087F36C
		// (set) Token: 0x0601BB81 RID: 113537 RVA: 0x00880F63 File Offset: 0x0087F363
		public Action<StatusCode, ulong, string> GetRecognizeSpeechTextListener { get; set; }

		// Token: 0x1700255C RID: 9564
		// (get) Token: 0x0601BB84 RID: 113540 RVA: 0x00880F7D File Offset: 0x0087F37D
		// (set) Token: 0x0601BB83 RID: 113539 RVA: 0x00880F74 File Offset: 0x0087F374
		public Action<Notice> RecvNoticeListener { get; set; }

		// Token: 0x1700255D RID: 9565
		// (get) Token: 0x0601BB86 RID: 113542 RVA: 0x00880F8E File Offset: 0x0087F38E
		// (set) Token: 0x0601BB85 RID: 113541 RVA: 0x00880F85 File Offset: 0x0087F385
		public Action<ulong, string> CancelNoticeListener { get; set; }

		// Token: 0x1700255E RID: 9566
		// (get) Token: 0x0601BB88 RID: 113544 RVA: 0x00880F9F File Offset: 0x0087F39F
		// (set) Token: 0x0601BB87 RID: 113543 RVA: 0x00880F96 File Offset: 0x0087F396
		public Action<float> RecordVolumeListener { get; set; }

		// Token: 0x1700255F RID: 9567
		// (get) Token: 0x0601BB8A RID: 113546 RVA: 0x00880FB0 File Offset: 0x0087F3B0
		// (set) Token: 0x0601BB89 RID: 113545 RVA: 0x00880FA7 File Offset: 0x0087F3A7
		public Action<ChatType, string> RecvNewMessageListener { get; set; }

		// Token: 0x17002560 RID: 9568
		// (get) Token: 0x0601BB8C RID: 113548 RVA: 0x00880FC1 File Offset: 0x0087F3C1
		// (set) Token: 0x0601BB8B RID: 113547 RVA: 0x00880FB8 File Offset: 0x0087F3B8
		public Action<StatusCode, AudioMessage, string> DownloadListener { get; set; }

		// Token: 0x17002561 RID: 9569
		// (get) Token: 0x0601BB8E RID: 113550 RVA: 0x00880FD2 File Offset: 0x0087F3D2
		// (set) Token: 0x0601BB8D RID: 113549 RVA: 0x00880FC9 File Offset: 0x0087F3C9
		public Action<StatusCode, IMAccusationInfo> AccusationListener { get; set; }

		// Token: 0x0601BB8F RID: 113551 RVA: 0x00880FDC File Offset: 0x0087F3DC
		public StatusCode Initialize(string appKey, string secretKey, Config config)
		{
			return (StatusCode)IMAPI.Instance().Init(appKey, secretKey, (config == null) ? ServerZone.China : config.ServerZone);
		}

		// Token: 0x0601BB90 RID: 113552 RVA: 0x0088100C File Offset: 0x0087F40C
		public void Login(string userID, string token, Action<LoginEvent> callback)
		{
			this.loginCallback = callback;
			ErrorCode errorCode = IMAPI.Instance().Login(userID, IMClient.FAKE_PAPSSWORD, token);
			if (errorCode != ErrorCode.Success && this.ConnectListener != null)
			{
				IMConnectEvent obj = new IMConnectEvent(Conv.ErrorCodeConvert(errorCode), ConnectEventType.CONNECT_FAIL, userID);
				this.ConnectListener(obj);
			}
		}

		// Token: 0x0601BB91 RID: 113553 RVA: 0x00881060 File Offset: 0x0087F460
		public void Logout(Action<LogoutEvent> callback)
		{
			this.logoutCallback = callback;
			ErrorCode errorCode = IMAPI.Instance().Logout();
			if (errorCode != ErrorCode.Success && this.ConnectListener != null)
			{
				IMConnectEvent obj = new IMConnectEvent(Conv.ErrorCodeConvert(errorCode), ConnectEventType.DISCONNECTED, this.GetCurrentUserID().UserID);
				this.ConnectListener(obj);
			}
		}

		// Token: 0x0601BB92 RID: 113554 RVA: 0x008810B4 File Offset: 0x0087F4B4
		public IUser GetCurrentUserID()
		{
			return this.IMManager.LastLoginUser;
		}

		// Token: 0x0601BB93 RID: 113555 RVA: 0x008810C4 File Offset: 0x0087F4C4
		public void JoinChannel(IMChannel channel, Action<ChannelEvent> callback)
		{
			this.joinChannelCallback = callback;
			ErrorCode errorCode = IMAPI.Instance().JoinChatRoom(channel.ChannelID);
			if (errorCode != ErrorCode.Success && this.ChannelEventListener != null)
			{
				this.ChannelEventListener(new ChannelEvent(Conv.ErrorCodeConvert(errorCode), ChannelEventType.JOIN_FAIL, channel.ChannelID));
			}
		}

		// Token: 0x0601BB94 RID: 113556 RVA: 0x00881118 File Offset: 0x0087F518
		public void JoinMultiChannel(IMChannel[] channels, Action<ChannelEvent> callback)
		{
			this.joinChannelCallback = callback;
			for (int i = 0; i < channels.Length; i++)
			{
				ErrorCode errorCode = IMAPI.Instance().JoinChatRoom(channels[i].ChannelID);
				if (errorCode != ErrorCode.Success && this.ChannelEventListener != null)
				{
					this.ChannelEventListener(new ChannelEvent(Conv.ErrorCodeConvert(errorCode), ChannelEventType.JOIN_FAIL, channels[i].ChannelID));
				}
			}
		}

		// Token: 0x0601BB95 RID: 113557 RVA: 0x00881184 File Offset: 0x0087F584
		public void LeaveChannel(IMChannel channel, Action<ChannelEvent> callback)
		{
			this.leaveChannelCallback = callback;
			ErrorCode errorCode = IMAPI.Instance().LeaveChatRoom(channel.ChannelID);
			if (errorCode != ErrorCode.Success && this.ChannelEventListener != null)
			{
				this.ChannelEventListener(new ChannelEvent(Conv.ErrorCodeConvert(errorCode), ChannelEventType.LEAVE_FAIL, channel.ChannelID));
			}
		}

		// Token: 0x0601BB96 RID: 113558 RVA: 0x008811D8 File Offset: 0x0087F5D8
		public void LeaveAllChannels(Action<ChannelEvent> callback)
		{
			this.leaveChannelCallback = callback;
			ErrorCode errorCode = IMAPI.Instance().LeaveAllChatRooms();
			if (errorCode != ErrorCode.Success && this.ChannelEventListener != null)
			{
				this.ChannelEventListener(new ChannelEvent(Conv.ErrorCodeConvert(errorCode), ChannelEventType.LEAVE_ALL_FAIL, string.Empty));
			}
		}

		// Token: 0x0601BB97 RID: 113559 RVA: 0x00881224 File Offset: 0x0087F624
		public void SwitchToChannels(IMChannel[] channel, Action<ChannelEvent> leaveCallback, Action<ChannelEvent> joinCallback)
		{
			this.LeaveAllChannels(leaveCallback);
			this.JoinMultiChannel(channel, joinCallback);
		}

		// Token: 0x0601BB98 RID: 113560 RVA: 0x00881238 File Offset: 0x0087F638
		public void GetRoomMemberCount(IMChannel channel, Action<StatusCode, string, uint> callback)
		{
			this.GetRoomMemberCountListener = callback;
			ErrorCode roomMemberCount = IMAPI.Instance().GetRoomMemberCount(channel.ChannelID);
			if (roomMemberCount != ErrorCode.Success && callback != null)
			{
				callback(Conv.ErrorCodeConvert(roomMemberCount), channel.ChannelID, 0U);
			}
		}

		// Token: 0x0601BB99 RID: 113561 RVA: 0x00881280 File Offset: 0x0087F680
		public global::TextMessage SendTextMessage(string reciverID, ChatType chatType, string msgContent, string extraParam, Action<StatusCode, global::TextMessage> OnSendCallBack)
		{
			ulong num = 0UL;
			ErrorCode errorCode = IMAPI.Instance().SendTextMessage(reciverID, chatType, msgContent, extraParam, ref num);
			global::TextMessage textMessage = new global::TextMessage(this.GetCurrentUserID().UserID, reciverID, chatType, msgContent, false);
			if (errorCode == ErrorCode.Success)
			{
				textMessage.SendStatus = SendStatus.Sending;
				textMessage.RequestID = num;
				MessageCallbackObject callback = new MessageCallbackObject(textMessage, MessageBodyType.TXT, OnSendCallBack);
				if (!IMInternalManager.Instance.AddMessageCallback(num, callback) && OnSendCallBack != null)
				{
					OnSendCallBack(StatusCode.Is_Waiting_Send, textMessage);
				}
			}
			else
			{
				textMessage.SendStatus = SendStatus.Fail;
				if (OnSendCallBack != null)
				{
					OnSendCallBack(Conv.ErrorCodeConvert(errorCode), textMessage);
				}
			}
			return textMessage;
		}

		// Token: 0x0601BB9A RID: 113562 RVA: 0x00881320 File Offset: 0x0087F720
		public StatusCode MultiSendTextMessage(List<string> recvLists, string strText)
		{
			return (StatusCode)IMAPI.Instance().MultiSendTextMessage(recvLists, strText);
		}

		// Token: 0x0601BB9B RID: 113563 RVA: 0x0088133C File Offset: 0x0087F73C
		public void SendGift(string anchorID, IMChannel channel, int giftID, int giftCount, ExtraGifParam extParam, Action<StatusCode, global::GiftMessage> OnSendCallBack)
		{
			ulong num = 0UL;
			ErrorCode errorCode = IMAPI.Instance().SendGift(anchorID, channel.ChannelID, giftID, giftCount, extParam, ref num);
			global::GiftMessage giftMessage = new global::GiftMessage(this.GetCurrentUserID().UserID, anchorID, giftID, giftCount, extParam, false);
			if (errorCode == ErrorCode.Success)
			{
				giftMessage.SendStatus = SendStatus.Sending;
				giftMessage.RequestID = num;
				MessageCallbackObject callback = new MessageCallbackObject(giftMessage, MessageBodyType.Gift, OnSendCallBack);
				if (!IMInternalManager.Instance.AddMessageCallback(num, callback) && OnSendCallBack != null)
				{
					OnSendCallBack(StatusCode.Is_Waiting_Send, giftMessage);
				}
			}
			else
			{
				giftMessage.SendStatus = SendStatus.Fail;
				if (OnSendCallBack != null)
				{
					OnSendCallBack(Conv.ErrorCodeConvert(errorCode), giftMessage);
				}
			}
		}

		// Token: 0x0601BB9C RID: 113564 RVA: 0x008813E8 File Offset: 0x0087F7E8
		public void SendCustomMessage(string reciverID, ChatType chatType, byte[] customMsg, Action<StatusCode, global::CustomMessage> OnSendCallBack)
		{
			ulong num = 0UL;
			ErrorCode errorCode = IMAPI.Instance().SendCustomMessage(reciverID, chatType, customMsg, ref num);
			global::CustomMessage customMessage = new global::CustomMessage(this.GetCurrentUserID().UserID, reciverID, chatType, customMsg, false);
			if (errorCode == ErrorCode.Success)
			{
				customMessage.SendStatus = SendStatus.Sending;
				customMessage.RequestID = num;
				MessageCallbackObject callback = new MessageCallbackObject(customMessage, MessageBodyType.CustomMesssage, OnSendCallBack);
				if (!IMInternalManager.Instance.AddMessageCallback(num, callback) && OnSendCallBack != null)
				{
					OnSendCallBack(StatusCode.Is_Waiting_Send, customMessage);
				}
			}
			else
			{
				customMessage.SendStatus = SendStatus.Fail;
				if (OnSendCallBack != null)
				{
					OnSendCallBack(Conv.ErrorCodeConvert(errorCode), customMessage);
				}
			}
		}

		// Token: 0x0601BB9D RID: 113565 RVA: 0x00881488 File Offset: 0x0087F888
		public void SendFile(string reciverID, ChatType chatType, string filePath, string extParam, FileType fileType, Action<StatusCode, global::FileMessage> OnSendCallBack)
		{
			ulong num = 0UL;
			ErrorCode errorCode = IMAPI.Instance().SendFile(reciverID, chatType, filePath, extParam, fileType, ref num);
			global::FileMessage fileMessage = new global::FileMessage(this.GetCurrentUserID().UserID, reciverID, chatType, extParam, fileType, false);
			if (errorCode == ErrorCode.Success)
			{
				fileMessage.SendStatus = SendStatus.Sending;
				fileMessage.RequestID = num;
				MessageCallbackObject callback = new MessageCallbackObject(fileMessage, MessageBodyType.File, OnSendCallBack);
				if (!IMInternalManager.Instance.AddMessageCallback(num, callback) && OnSendCallBack != null)
				{
					OnSendCallBack(StatusCode.Is_Waiting_Send, fileMessage);
				}
			}
			else
			{
				fileMessage.SendStatus = SendStatus.Fail;
				if (OnSendCallBack != null)
				{
					OnSendCallBack(Conv.ErrorCodeConvert(errorCode), fileMessage);
				}
			}
		}

		// Token: 0x0601BB9E RID: 113566 RVA: 0x0088152C File Offset: 0x0087F92C
		public StatusCode SetAutoDownloadAudioMessage(bool download)
		{
			return (StatusCode)IMAPI.Instance().SetDownloadAudioMessageSwitch(download);
		}

		// Token: 0x0601BB9F RID: 113567 RVA: 0x00881548 File Offset: 0x0087F948
		public StatusCode StartRecordAudio(string reciverID, ChatType chatType, string extraMsg, bool recognizeText, bool IsOpenOnlyRecognizeText = false)
		{
			ulong requestID = 0UL;
			ErrorCode errorCode;
			if (recognizeText)
			{
				if (IsOpenOnlyRecognizeText)
				{
					IMAPI.Instance().SetOnlyRecognizeSpeechText(true);
				}
				else
				{
					IMAPI.Instance().SetOnlyRecognizeSpeechText(false);
				}
				errorCode = IMAPI.Instance().SendAudioMessage(reciverID, chatType, ref requestID);
			}
			else
			{
				errorCode = IMAPI.Instance().SendOnlyAudioMessage(reciverID, chatType, ref requestID);
			}
			AudioMessage audioMessage = new AudioMessage(this.GetCurrentUserID().UserID, reciverID, chatType, extraMsg, false);
			if (errorCode == ErrorCode.Success)
			{
				audioMessage.RequestID = requestID;
				audioMessage.SendStatus = SendStatus.NotStartSend;
				this.lastRecordAudioMessage = audioMessage;
				return StatusCode.Success;
			}
			audioMessage.SendStatus = SendStatus.Fail;
			Log.e("Start Record Fail! code:" + errorCode.ToString());
			return (StatusCode)errorCode;
		}

		// Token: 0x0601BBA0 RID: 113568 RVA: 0x00881600 File Offset: 0x0087FA00
		public void StopRecordAndSendAudio(Action<StatusCode, AudioMessage> callback)
		{
			StatusCode arg = StatusCode.PTT_NotStartRecord;
			if (this.lastRecordAudioMessage == null)
			{
				Log.e("Has no start record!");
				callback(arg, null);
				return;
			}
			AudioMessage audioMessage = this.lastRecordAudioMessage;
			ErrorCode errorCode = IMAPI.Instance().StopAudioMessage(audioMessage.ExtraParam);
			this.lastRecordAudioMessage = null;
			if (errorCode == ErrorCode.Success)
			{
				MessageCallbackObject callback2 = new MessageCallbackObject(audioMessage, MessageBodyType.Voice, callback);
				if (!IMInternalManager.Instance.AddMessageCallback(audioMessage.RequestID, callback2) && callback != null)
				{
					callback(StatusCode.Is_Waiting_Send, audioMessage);
				}
			}
			else
			{
				audioMessage.SendStatus = SendStatus.Fail;
				arg = Conv.ErrorCodeConvert(errorCode);
				if (callback != null)
				{
					callback(arg, audioMessage);
				}
			}
		}

		// Token: 0x0601BBA1 RID: 113569 RVA: 0x008816AC File Offset: 0x0087FAAC
		public StatusCode CancleRecordAudio()
		{
			return (StatusCode)IMAPI.Instance().CancleAudioMessage();
		}

		// Token: 0x0601BBA2 RID: 113570 RVA: 0x008816C8 File Offset: 0x0087FAC8
		public void DownloadFile(ulong requestID, string targetFilePath, Action<StatusCode, IMMessage, string> downloadCallback)
		{
			if (IMAPI.Instance().DownloadAudioFile(requestID, targetFilePath) == ErrorCode.Success)
			{
				if (!IMInternalManager.Instance.AddDownloadCallback(requestID, downloadCallback) && downloadCallback != null)
				{
					downloadCallback(StatusCode.Is_Waiting_Download, null, string.Empty);
				}
			}
			else if (downloadCallback != null)
			{
				downloadCallback(StatusCode.Start_Download_Fail, null, string.Empty);
			}
		}

		// Token: 0x0601BBA3 RID: 113571 RVA: 0x0088172E File Offset: 0x0087FB2E
		private void SetVolume(float volume)
		{
			IMAPI.Instance().SetVolume(volume);
		}

		// Token: 0x0601BBA4 RID: 113572 RVA: 0x0088173C File Offset: 0x0087FB3C
		public void StartPlayAudio(string audioPath, Action<StatusCode, string> playCallback, float volume = 1f)
		{
			this.PlayListener = playCallback;
			bool flag = IMAPI.Instance().IsPlaying();
			if (flag)
			{
				StatusCode statusCode = this.StopPlayAudio();
				if (statusCode != StatusCode.Success && playCallback != null)
				{
					playCallback(StatusCode.StopPlay_Fail_Before_Start, string.Empty);
					return;
				}
			}
			if (volume != 1f)
			{
				IMAPI.Instance().SetVolume(volume);
			}
			ErrorCode errorCode = IMAPI.Instance().StartPlayAudio(audioPath);
			if (errorCode != ErrorCode.Success && playCallback != null)
			{
				playCallback(StatusCode.Start_Play_Fail, string.Empty);
			}
		}

		// Token: 0x0601BBA5 RID: 113573 RVA: 0x008817C4 File Offset: 0x0087FBC4
		public StatusCode StopPlayAudio()
		{
			bool flag = IMAPI.Instance().IsPlaying();
			if (flag)
			{
				return (StatusCode)IMAPI.Instance().StopPlayAudio();
			}
			return StatusCode.Success;
		}

		// Token: 0x0601BBA6 RID: 113574 RVA: 0x008817F0 File Offset: 0x0087FBF0
		public void DownloadFileByUrl(string downloadUrl, string savePath, Action<StatusCode, string> downloadCallback)
		{
			if (IMAPI.Instance().DownloadFileByUrl(downloadUrl, savePath) == ErrorCode.Success)
			{
				if (!IMInternalManager.Instance.AddUrlDownloadCallback(downloadUrl, downloadCallback) && downloadCallback != null)
				{
					downloadCallback(StatusCode.Is_Waiting_Download, string.Empty);
				}
			}
			else if (downloadCallback != null)
			{
				downloadCallback(StatusCode.Start_Download_Fail, string.Empty);
			}
		}

		// Token: 0x0601BBA7 RID: 113575 RVA: 0x00881854 File Offset: 0x0087FC54
		public string GetAudioCachePath()
		{
			return IMAPI.Instance().GetAudioCachePath();
		}

		// Token: 0x0601BBA8 RID: 113576 RVA: 0x00881860 File Offset: 0x0087FC60
		public bool ClearAudioCachePath()
		{
			return IMAPI.Instance().ClearAudioCachePath();
		}

		// Token: 0x0601BBA9 RID: 113577 RVA: 0x0088186C File Offset: 0x0087FC6C
		public StatusCode SetDownloadDir(string path)
		{
			ErrorCode errorCode = IMAPI.Instance().SetDownloadDir(path);
			if (errorCode == ErrorCode.Success)
			{
				this._downloadDirPath = path;
			}
			return (StatusCode)errorCode;
		}

		// Token: 0x0601BBAA RID: 113578 RVA: 0x00881894 File Offset: 0x0087FC94
		public StatusCode StartAudioSpeech(bool translate)
		{
			ulong requestID = 0UL;
			ErrorCode errorCode = IMAPI.Instance().StartAudioSpeech(ref requestID, translate);
			if (errorCode == ErrorCode.Success)
			{
				this.lastRecordSpeechMessage = new SpeechInfo(requestID)
				{
					HasUpload = false
				};
			}
			return (StatusCode)errorCode;
		}

		// Token: 0x0601BBAB RID: 113579 RVA: 0x008818D0 File Offset: 0x0087FCD0
		public void StopAudioSpeech(Action<StatusCode, SpeechInfo> callback)
		{
			StatusCode arg = StatusCode.PTT_NotStartRecord;
			if (this.lastRecordSpeechMessage == null && callback != null)
			{
				Log.e("Has no start record!");
				callback(arg, null);
				return;
			}
			SpeechInfo speechInfo = this.lastRecordSpeechMessage;
			ErrorCode errorCode = IMAPI.Instance().StopAudioSpeech();
			this.lastRecordSpeechMessage = null;
			if (errorCode == ErrorCode.Success)
			{
				if (!IMInternalManager.Instance.AddUploadCallback(speechInfo.RequestID, callback) && callback != null)
				{
					callback(StatusCode.Is_Waiting_Upload, speechInfo);
				}
			}
			else if (callback != null)
			{
				callback(StatusCode.PTT_UploadFail, speechInfo);
			}
		}

		// Token: 0x0601BBAC RID: 113580 RVA: 0x00881968 File Offset: 0x0087FD68
		public void GetMicrophoneStatus(Action<StatusCode, IMAudioDeviceStatus> callback)
		{
			this.GetMicrophoneStatusListener = callback;
			ErrorCode microphoneStatus = IMAPI.Instance().GetMicrophoneStatus();
			if (microphoneStatus != ErrorCode.Success && callback != null)
			{
				callback(StatusCode.Get_Microphone_Status_Fail, IMAudioDeviceStatus.UNKNOWN);
			}
		}

		// Token: 0x0601BBAD RID: 113581 RVA: 0x0088199F File Offset: 0x0087FD9F
		public void TranslateText(string text, LanguageCode destLangCode, LanguageCode srcLangCode, Action<StatusCode, string, LanguageCode, LanguageCode> callback)
		{
			this.SetTranslateListener(new Action<ErrorCode, string, LanguageCode, LanguageCode>(this.OnTranslateCompelete));
			this.translateCallback = callback;
			IMAPI.Instance().TranslateText(text, destLangCode, srcLangCode, this.TranslateListener);
		}

		// Token: 0x0601BBAE RID: 113582 RVA: 0x008819D0 File Offset: 0x0087FDD0
		public StatusCode SetSpeechRecognizeLanguage(SpeechLanguage language)
		{
			return (StatusCode)IMAPI.Instance().SetSpeechRecognizeLanguage(language);
		}

		// Token: 0x0601BBAF RID: 113583 RVA: 0x008819EC File Offset: 0x0087FDEC
		public void GetHistoryContact(Action<StatusCode, List<ContactsSessionInfo>> callback)
		{
			this.GetContactListener = callback;
			ErrorCode historyContact = IMAPI.Instance().GetHistoryContact();
			if (historyContact != ErrorCode.Success && callback != null)
			{
				callback(StatusCode.Get_Contacts_Fail, null);
			}
		}

		// Token: 0x0601BBB0 RID: 113584 RVA: 0x00881A24 File Offset: 0x0087FE24
		public void GetUserInfo(string userID, Action<StatusCode, IMUserInfo> callback)
		{
			this.GetUserInfoListener = callback;
			ErrorCode userInfo = IMAPI.Instance().GetUserInfo(userID);
			if (userInfo != ErrorCode.Success && callback != null)
			{
				callback(StatusCode.Get_User_Info_Fail, null);
			}
		}

		// Token: 0x0601BBB1 RID: 113585 RVA: 0x00881A5C File Offset: 0x0087FE5C
		public StatusCode SetUserInfo(IMUserInfo userInfo)
		{
			return (StatusCode)IMAPI.Instance().SetUserInfo(userInfo);
		}

		// Token: 0x0601BBB2 RID: 113586 RVA: 0x00881A78 File Offset: 0x0087FE78
		public void QueryUserStatus(string userID, Action<StatusCode, YIMUserStatus> callback)
		{
			this.QueryUserStatusListener = callback;
			ErrorCode errorCode = IMAPI.Instance().QueryUserStatus(userID);
			if (errorCode != ErrorCode.Success && callback != null)
			{
				callback(StatusCode.Query_User_Status_Fail, YIMUserStatus.UNKNOWN);
			}
		}

		// Token: 0x0601BBB3 RID: 113587 RVA: 0x00881AB0 File Offset: 0x0087FEB0
		public void BlockUser(string userID, bool block, Action<StatusCode, bool> callback)
		{
			this.BlockUserListener = callback;
			ErrorCode errorCode = IMAPI.Instance().BlockUser(userID, block);
			if (errorCode != ErrorCode.Success && callback != null)
			{
				callback(StatusCode.Block_User_Fail, false);
			}
		}

		// Token: 0x0601BBB4 RID: 113588 RVA: 0x00881AEC File Offset: 0x0087FEEC
		public void UnBlockAllUser(Action<StatusCode> callback)
		{
			this.UnblockAllUserListener = callback;
			ErrorCode errorCode = IMAPI.Instance().UnBlockAllUser();
			if (errorCode != ErrorCode.Success && callback != null)
			{
				callback(StatusCode.Unblock_All_User_Fail);
			}
		}

		// Token: 0x0601BBB5 RID: 113589 RVA: 0x00881B24 File Offset: 0x0087FF24
		public void GetBlockUsers(Action<StatusCode, List<string>> callback)
		{
			this.GetBlockUsersListener = callback;
			ErrorCode blockUsers = IMAPI.Instance().GetBlockUsers();
			if (blockUsers != ErrorCode.Success && callback != null)
			{
				callback(StatusCode.Get_Block_Users_Fail, null);
			}
		}

		// Token: 0x0601BBB6 RID: 113590 RVA: 0x00881B5C File Offset: 0x0087FF5C
		public void GetForbiddenSpeakInfo(Action<StatusCode, List<ForbiddenSpeakInfo>> callback)
		{
			this.GetForbiddenSpeakInfoListener = callback;
			ErrorCode forbiddenSpeakInfo = IMAPI.Instance().GetForbiddenSpeakInfo();
			if (forbiddenSpeakInfo != ErrorCode.Success && callback != null)
			{
				callback(StatusCode.Get_Forbidden_SpeakInfo_Fail, null);
			}
		}

		// Token: 0x0601BBB7 RID: 113591 RVA: 0x00881B94 File Offset: 0x0087FF94
		public StatusCode SetMessageRead(ulong messageID, bool read)
		{
			return (StatusCode)IMAPI.Instance().SetMessageRead(messageID, read);
		}

		// Token: 0x0601BBB8 RID: 113592 RVA: 0x00881BB0 File Offset: 0x0087FFB0
		public StatusCode SetAutoRecvMsg(List<string> targets, bool bAutoRecv)
		{
			return (StatusCode)IMAPI.Instance().SetAutoRecvMsg(targets, bAutoRecv);
		}

		// Token: 0x0601BBB9 RID: 113593 RVA: 0x00881BCC File Offset: 0x0087FFCC
		public StatusCode GetNewMessage(List<string> targets)
		{
			return (StatusCode)IMAPI.Instance().GetNewMessage(targets);
		}

		// Token: 0x0601BBBA RID: 113594 RVA: 0x00881BE8 File Offset: 0x0087FFE8
		public static string GetFilterText(string strSource, int level = 0)
		{
			int num = 0;
			if (level != 0)
			{
				num = level;
			}
			return IMAPI.GetFilterText(strSource, ref num);
		}

		// Token: 0x0601BBBB RID: 113595 RVA: 0x00881C08 File Offset: 0x00880008
		public void QueryRoomHistoryMessageFromServer(string channelID, int count, int direction, Action<StatusCode, string, uint, List<IMMessage>> callback)
		{
			this.QueryRoomHistoryMsgFromServerListener = callback;
			ErrorCode errorCode = IMAPI.Instance().QueryRoomHistoryMessageFromServer(channelID, count, direction);
			if (errorCode != ErrorCode.Success && callback != null)
			{
				callback(StatusCode.Query_Records_Fail, channelID, 0U, null);
			}
		}

		// Token: 0x0601BBBC RID: 113596 RVA: 0x00881C47 File Offset: 0x00880047
		public void SetRoomHistoryMessageSwitch(List<string> channelIDs, bool save)
		{
			IMAPI.Instance().SetRoomHistoryMessageSwitch(channelIDs, save);
		}

		// Token: 0x0601BBBD RID: 113597 RVA: 0x00881C58 File Offset: 0x00880058
		public void QueryHistoryMessage(string targetID, ChatType chatType, ulong startMessageID, int count, int direction, Action<StatusCode, IMHistoryMessageInfo> callback)
		{
			this.QueryHistoryMesListener = callback;
			ErrorCode errorCode = IMAPI.Instance().QueryHistoryMessage(targetID, chatType, startMessageID, count, direction);
			if (errorCode != ErrorCode.Success && callback != null)
			{
				IMHistoryMessageInfo arg = new IMHistoryMessageInfo(targetID, 0, null);
				callback(StatusCode.Query_Records_Fail, arg);
			}
		}

		// Token: 0x0601BBBE RID: 113598 RVA: 0x00881CA4 File Offset: 0x008800A4
		public StatusCode DeleteHistoryMessage(ChatType chatType, ulong time)
		{
			return (StatusCode)IMAPI.Instance().DeleteHistoryMessage(chatType, time);
		}

		// Token: 0x0601BBBF RID: 113599 RVA: 0x00881CC0 File Offset: 0x008800C0
		public StatusCode DeleteHistoryMessageByID(ulong messageID)
		{
			return (StatusCode)IMAPI.Instance().DeleteHistoryMessageByID(messageID);
		}

		// Token: 0x0601BBC0 RID: 113600 RVA: 0x00881CDC File Offset: 0x008800DC
		public StatusCode DeleteSpecifiedHistoryMessage(string targetID, ChatType chatType, ulong[] excludeMesList)
		{
			return (StatusCode)IMAPI.Instance().DeleteSpecifiedHistoryMessage(targetID, chatType, excludeMesList);
		}

		// Token: 0x0601BBC1 RID: 113601 RVA: 0x00881CF8 File Offset: 0x008800F8
		public StatusCode DeleteHistoryMessageByTarget(string targetID, ChatType chatType, ulong startMessageID, uint count)
		{
			return (StatusCode)IMAPI.Instance().DeleteHistoryMessageByTarget(targetID, chatType, startMessageID, count);
		}

		// Token: 0x0601BBC2 RID: 113602 RVA: 0x00881D16 File Offset: 0x00880116
		public void OnResume()
		{
			IMAPI.Instance().OnResume();
		}

		// Token: 0x0601BBC3 RID: 113603 RVA: 0x00881D22 File Offset: 0x00880122
		public void OnPause(bool pauseReceiveMessage)
		{
			IMAPI.Instance().OnPause(pauseReceiveMessage);
		}

		// Token: 0x0601BBC4 RID: 113604 RVA: 0x00881D30 File Offset: 0x00880130
		public StatusCode QueryNotice()
		{
			return (StatusCode)IMAPI.Instance().QueryNotice();
		}

		// Token: 0x0601BBC5 RID: 113605 RVA: 0x00881D4C File Offset: 0x0088014C
		public StatusCode Accusation(string userID, ChatType chatType, int reason, string description, string extraParam)
		{
			return (StatusCode)IMAPI.Instance().Accusation(userID, chatType, reason, description, extraParam);
		}

		// Token: 0x0601BBC6 RID: 113606 RVA: 0x00881D6C File Offset: 0x0088016C
		public StatusCode GetCurrentLocation()
		{
			return (StatusCode)IMAPI.Instance().GetCurrentLocation();
		}

		// Token: 0x0601BBC7 RID: 113607 RVA: 0x00881D85 File Offset: 0x00880185
		public void SetUpdateInterval(uint interval)
		{
			IMAPI.Instance().SetUpdateInterval(interval);
		}

		// Token: 0x0601BBC8 RID: 113608 RVA: 0x00881D94 File Offset: 0x00880194
		public void GetNearbyObjects(int count, string serverAreaID, Action<StatusCode, IMNearbyObjectInfo> callback, DistrictLevel districtlevel = DistrictLevel.DISTRICT_UNKNOW, bool resetStartDistance = false)
		{
			this.GetNearbyObjectsListener = callback;
			ErrorCode nearbyObjects = IMAPI.Instance().GetNearbyObjects(count, serverAreaID, districtlevel, resetStartDistance);
			if (nearbyObjects != ErrorCode.Success && callback != null)
			{
				IMNearbyObjectInfo arg = new IMNearbyObjectInfo(null, 0U, 0U);
				callback(StatusCode.Get_Nearby_Objects_Fail, arg);
			}
		}

		// Token: 0x0601BBC9 RID: 113609 RVA: 0x00881DDA File Offset: 0x008801DA
		public void SetReconnectListener(Action<IMReconnectEvent> listener)
		{
			this.ReconnectListener = listener;
		}

		// Token: 0x0601BBCA RID: 113610 RVA: 0x00881DE3 File Offset: 0x008801E3
		public void SetOtherUserChannelEventListener(Action<OtherUserChannelEvent> listener)
		{
			this.OtherUserChannelEventListener = listener;
		}

		// Token: 0x0601BBCB RID: 113611 RVA: 0x00881DEC File Offset: 0x008801EC
		public void SetReceiveMessageListener(Action<IMMessage> listener)
		{
			this.ReceiveMessageListener = listener;
		}

		// Token: 0x0601BBCC RID: 113612 RVA: 0x00881DF5 File Offset: 0x008801F5
		public void SetRecvNoticeListener(Action<Notice> listener)
		{
			this.RecvNoticeListener = listener;
		}

		// Token: 0x0601BBCD RID: 113613 RVA: 0x00881DFE File Offset: 0x008801FE
		public void SetCancelNoticeListener(Action<ulong, string> listener)
		{
			this.CancelNoticeListener = listener;
		}

		// Token: 0x0601BBCE RID: 113614 RVA: 0x00881E07 File Offset: 0x00880207
		public void SetRecvRecordVolumeListener(Action<float> listener)
		{
			this.RecordVolumeListener = listener;
		}

		// Token: 0x0601BBCF RID: 113615 RVA: 0x00881E10 File Offset: 0x00880210
		public void SetGetCurrentLocationListener(Action<StatusCode, GeographyLocation> listener)
		{
			this.GetCurrentLocationListener = listener;
		}

		// Token: 0x0601BBD0 RID: 113616 RVA: 0x00881E19 File Offset: 0x00880219
		public void SetGetRecognizeSpeechTextListener(Action<StatusCode, ulong, string> listener)
		{
			this.GetRecognizeSpeechTextListener = listener;
		}

		// Token: 0x0601BBD1 RID: 113617 RVA: 0x00881E22 File Offset: 0x00880222
		public void SetRecvNewMessageListener(Action<ChatType, string> listener)
		{
			this.RecvNewMessageListener = listener;
		}

		// Token: 0x0601BBD2 RID: 113618 RVA: 0x00881E2B File Offset: 0x0088022B
		public void SetDownloadListener(Action<StatusCode, AudioMessage, string> listener)
		{
			this.DownloadListener = listener;
		}

		// Token: 0x0601BBD3 RID: 113619 RVA: 0x00881E34 File Offset: 0x00880234
		public void SetAccusationListener(Action<StatusCode, IMAccusationInfo> listener)
		{
			this.AccusationListener = listener;
		}

		// Token: 0x0601BBD4 RID: 113620 RVA: 0x00881E3D File Offset: 0x0088023D
		private void SetTranslateListener(Action<ErrorCode, string, LanguageCode, LanguageCode> listener)
		{
			this.TranslateListener = listener;
		}

		// Token: 0x0601BBD5 RID: 113621 RVA: 0x00881E46 File Offset: 0x00880246
		private void OnTranslateCompelete(ErrorCode code, string text, LanguageCode srcCode, LanguageCode destCode)
		{
			this.translateCallback(Conv.ErrorCodeConvert(code), text, srcCode, destCode);
		}

		// Token: 0x0601BBD6 RID: 113622 RVA: 0x00881E5D File Offset: 0x0088025D
		public void SetKickOffListener(Action<KickOffEvent> listener)
		{
			this.kickOffCallback = listener;
		}

		// Token: 0x0601BBD7 RID: 113623 RVA: 0x00881E66 File Offset: 0x00880266
		public void SetDisconnectListener(Action<DisconnectEvent> listener)
		{
			this.disconnectCallback = listener;
		}

		// Token: 0x0601BBD8 RID: 113624 RVA: 0x00881E70 File Offset: 0x00880270
		private void OnConnect(IMConnectEvent connectEvent)
		{
			switch (connectEvent.EventType)
			{
			case ConnectEventType.CONNECTED:
				if (this.loginCallback != null)
				{
					this.loginCallback(new LoginEvent(connectEvent.Code, connectEvent.UserID));
				}
				break;
			case ConnectEventType.DISCONNECTED:
				if (this.logoutCallback != null)
				{
					this.logoutCallback(new LogoutEvent(connectEvent.Code, connectEvent.UserID));
				}
				break;
			case ConnectEventType.CONNECT_FAIL:
				if (this.loginCallback != null)
				{
					this.loginCallback(new LoginEvent(connectEvent.Code, connectEvent.UserID));
				}
				break;
			case ConnectEventType.KICKED:
				if (this.kickOffCallback != null)
				{
					this.kickOffCallback(new KickOffEvent(connectEvent.Code, connectEvent.UserID));
				}
				break;
			case ConnectEventType.OFF_LINE:
				if (this.disconnectCallback != null)
				{
					this.disconnectCallback(new DisconnectEvent(connectEvent.Code, connectEvent.UserID));
				}
				break;
			}
		}

		// Token: 0x0601BBD9 RID: 113625 RVA: 0x00881F84 File Offset: 0x00880384
		private void OnChannelEvent(ChannelEvent channelEvent)
		{
			switch (channelEvent.EventType)
			{
			case ChannelEventType.JOIN_SUCCESS:
				this.joinChannelCallback(channelEvent);
				break;
			case ChannelEventType.LEAVE_SUCCESS:
				this.leaveChannelCallback(channelEvent);
				break;
			case ChannelEventType.JOIN_FAIL:
				this.joinChannelCallback(channelEvent);
				break;
			case ChannelEventType.LEAVE_FAIL:
				this.leaveChannelCallback(channelEvent);
				break;
			}
		}

		// Token: 0x04013560 RID: 79200
		private static IMClient _ins;

		// Token: 0x04013561 RID: 79201
		public static string FAKE_PAPSSWORD = "123456";

		// Token: 0x04013562 RID: 79202
		public string _downloadDirPath = string.Empty;

		// Token: 0x04013563 RID: 79203
		public IMInternalManager IMManager;

		// Token: 0x0401357E RID: 79230
		private Action<LoginEvent> loginCallback;

		// Token: 0x0401357F RID: 79231
		private Action<LogoutEvent> logoutCallback;

		// Token: 0x04013580 RID: 79232
		private Action<KickOffEvent> kickOffCallback;

		// Token: 0x04013581 RID: 79233
		private Action<DisconnectEvent> disconnectCallback;

		// Token: 0x04013582 RID: 79234
		private Action<ChannelEvent> joinChannelCallback;

		// Token: 0x04013583 RID: 79235
		private Action<ChannelEvent> leaveChannelCallback;

		// Token: 0x04013584 RID: 79236
		private Action<ErrorCode, string, LanguageCode, LanguageCode> TranslateListener;

		// Token: 0x04013585 RID: 79237
		private Action<StatusCode, string, LanguageCode, LanguageCode> translateCallback;

		// Token: 0x04013586 RID: 79238
		private AudioMessage lastRecordAudioMessage;

		// Token: 0x04013587 RID: 79239
		private SpeechInfo lastRecordSpeechMessage;
	}
}
