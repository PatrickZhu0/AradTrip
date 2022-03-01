using System;

namespace YouMe
{
	// Token: 0x02004A9C RID: 19100
	public enum StatusCode
	{
		// Token: 0x040134DC RID: 79068
		Success,
		// Token: 0x040134DD RID: 79069
		EngineNotInit,
		// Token: 0x040134DE RID: 79070
		NotLogin,
		// Token: 0x040134DF RID: 79071
		ParamInvalid,
		// Token: 0x040134E0 RID: 79072
		TimeOut,
		// Token: 0x040134E1 RID: 79073
		StatusError,
		// Token: 0x040134E2 RID: 79074
		SDKInvalid,
		// Token: 0x040134E3 RID: 79075
		AlreadyLogin,
		// Token: 0x040134E4 RID: 79076
		ServerError,
		// Token: 0x040134E5 RID: 79077
		NetError,
		// Token: 0x040134E6 RID: 79078
		LoginSessionError,
		// Token: 0x040134E7 RID: 79079
		NotStartUp,
		// Token: 0x040134E8 RID: 79080
		FileNotExist,
		// Token: 0x040134E9 RID: 79081
		SendFileError,
		// Token: 0x040134EA RID: 79082
		UploadFailed,
		// Token: 0x040134EB RID: 79083
		UsernamePasswordError,
		// Token: 0x040134EC RID: 79084
		UserStatusError,
		// Token: 0x040134ED RID: 79085
		MessageTooLong,
		// Token: 0x040134EE RID: 79086
		ReceiverTooLong,
		// Token: 0x040134EF RID: 79087
		InvalidChatType,
		// Token: 0x040134F0 RID: 79088
		InvalidReceiver,
		// Token: 0x040134F1 RID: 79089
		UnknowError,
		// Token: 0x040134F2 RID: 79090
		InvalidAppkey,
		// Token: 0x040134F3 RID: 79091
		ForbiddenSpeak,
		// Token: 0x040134F4 RID: 79092
		CreateFileFailed,
		// Token: 0x040134F5 RID: 79093
		UnsupportFormat,
		// Token: 0x040134F6 RID: 79094
		ReceiverEmpty,
		// Token: 0x040134F7 RID: 79095
		RoomIDTooLong,
		// Token: 0x040134F8 RID: 79096
		ContentInvalid,
		// Token: 0x040134F9 RID: 79097
		NoLocationAuthrize,
		// Token: 0x040134FA RID: 79098
		UnknowLocation,
		// Token: 0x040134FB RID: 79099
		Unsupport,
		// Token: 0x040134FC RID: 79100
		NoAudioDevice,
		// Token: 0x040134FD RID: 79101
		AudioDriver,
		// Token: 0x040134FE RID: 79102
		DeviceStatusInvalid,
		// Token: 0x040134FF RID: 79103
		ResolveFileError,
		// Token: 0x04013500 RID: 79104
		ReadWriteFileError,
		// Token: 0x04013501 RID: 79105
		NoLangCode,
		// Token: 0x04013502 RID: 79106
		TranslateUnable,
		// Token: 0x04013503 RID: 79107
		SpeechAccentInvalid,
		// Token: 0x04013504 RID: 79108
		SpeechLanguageInvalid,
		// Token: 0x04013505 RID: 79109
		HasIllegalText,
		// Token: 0x04013506 RID: 79110
		AdvertisementMessage,
		// Token: 0x04013507 RID: 79111
		AlreadyBlock,
		// Token: 0x04013508 RID: 79112
		NotBlock,
		// Token: 0x04013509 RID: 79113
		MessageBlocked,
		// Token: 0x0401350A RID: 79114
		LocationTimeout,
		// Token: 0x0401350B RID: 79115
		NotJoinRoom,
		// Token: 0x0401350C RID: 79116
		LoginTokenInvalid,
		// Token: 0x0401350D RID: 79117
		CreateDirectoryFailed,
		// Token: 0x0401350E RID: 79118
		InitFailed,
		// Token: 0x0401350F RID: 79119
		Disconnect,
		// Token: 0x04013510 RID: 79120
		ALREADYFRIENDS = 1000,
		// Token: 0x04013511 RID: 79121
		LoginInvalid,
		// Token: 0x04013512 RID: 79122
		PTT_Start = 2000,
		// Token: 0x04013513 RID: 79123
		PTT_Fail,
		// Token: 0x04013514 RID: 79124
		PTT_DownloadFail,
		// Token: 0x04013515 RID: 79125
		PTT_GetUploadTokenFail,
		// Token: 0x04013516 RID: 79126
		PTT_UploadFail,
		// Token: 0x04013517 RID: 79127
		PTT_NotSpeech,
		// Token: 0x04013518 RID: 79128
		PTT_DeviceStatusError,
		// Token: 0x04013519 RID: 79129
		PTT_IsSpeeching,
		// Token: 0x0401351A RID: 79130
		PTT_FileNotExist,
		// Token: 0x0401351B RID: 79131
		PTT_ReachMaxDuration,
		// Token: 0x0401351C RID: 79132
		PTT_SpeechTooShort,
		// Token: 0x0401351D RID: 79133
		PTT_StartAudioRecordFailed,
		// Token: 0x0401351E RID: 79134
		PTT_SpeechTimeout,
		// Token: 0x0401351F RID: 79135
		PTT_IsPlaying,
		// Token: 0x04013520 RID: 79136
		PTT_NotStartPlay,
		// Token: 0x04013521 RID: 79137
		PTT_CancelPlay,
		// Token: 0x04013522 RID: 79138
		PTT_NotStartRecord,
		// Token: 0x04013523 RID: 79139
		PTT_NotInit,
		// Token: 0x04013524 RID: 79140
		PTT_InitFailed,
		// Token: 0x04013525 RID: 79141
		PTT_Authorize,
		// Token: 0x04013526 RID: 79142
		PTT_StartRecordFailed,
		// Token: 0x04013527 RID: 79143
		PTT_StopRecordFailed,
		// Token: 0x04013528 RID: 79144
		PTT_UnsupprtFormat,
		// Token: 0x04013529 RID: 79145
		PTT_ResolveFileError,
		// Token: 0x0401352A RID: 79146
		PTT_ReadWriteFileError,
		// Token: 0x0401352B RID: 79147
		PTT_ConvertFileFailed,
		// Token: 0x0401352C RID: 79148
		PTT_NoAudioDevice,
		// Token: 0x0401352D RID: 79149
		PTT_NoDriver,
		// Token: 0x0401352E RID: 79150
		PTT_StartPlayFailed,
		// Token: 0x0401352F RID: 79151
		PTT_StopPlayFailed,
		// Token: 0x04013530 RID: 79152
		Fail = 10000,
		// Token: 0x04013531 RID: 79153
		Start_Download_Fail = 20001,
		// Token: 0x04013532 RID: 79154
		Is_Waiting_Download,
		// Token: 0x04013533 RID: 79155
		Is_Waiting_Upload,
		// Token: 0x04013534 RID: 79156
		Is_Waiting_Send,
		// Token: 0x04013535 RID: 79157
		Query_Records_Fail,
		// Token: 0x04013536 RID: 79158
		Get_Contacts_Fail,
		// Token: 0x04013537 RID: 79159
		Get_User_Info_Fail,
		// Token: 0x04013538 RID: 79160
		Query_User_Status_Fail,
		// Token: 0x04013539 RID: 79161
		Start_Play_Fail,
		// Token: 0x0401353A RID: 79162
		StopPlay_Fail_Before_Start,
		// Token: 0x0401353B RID: 79163
		Get_Current_Location_Fail,
		// Token: 0x0401353C RID: 79164
		Get_Nearby_Objects_Fail,
		// Token: 0x0401353D RID: 79165
		Get_Microphone_Status_Fail,
		// Token: 0x0401353E RID: 79166
		Get_Forbidden_SpeakInfo_Fail = 20015,
		// Token: 0x0401353F RID: 79167
		Block_User_Fail,
		// Token: 0x04013540 RID: 79168
		Unblock_All_User_Fail,
		// Token: 0x04013541 RID: 79169
		Get_Block_Users_Fail,
		// Token: 0x04013542 RID: 79170
		Has_No_Microphone_Authority
	}
}
