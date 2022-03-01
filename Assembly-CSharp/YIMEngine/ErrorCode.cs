using System;

namespace YIMEngine
{
	// Token: 0x02004A55 RID: 19029
	public enum ErrorCode
	{
		// Token: 0x0401321C RID: 78364
		Success,
		// Token: 0x0401321D RID: 78365
		EngineNotInit,
		// Token: 0x0401321E RID: 78366
		NotLogin,
		// Token: 0x0401321F RID: 78367
		ParamInvalid,
		// Token: 0x04013220 RID: 78368
		TimeOut,
		// Token: 0x04013221 RID: 78369
		StatusError,
		// Token: 0x04013222 RID: 78370
		SDKInvalid,
		// Token: 0x04013223 RID: 78371
		AlreadyLogin,
		// Token: 0x04013224 RID: 78372
		ServerError,
		// Token: 0x04013225 RID: 78373
		NetError,
		// Token: 0x04013226 RID: 78374
		LoginSessionError,
		// Token: 0x04013227 RID: 78375
		NotStartUp,
		// Token: 0x04013228 RID: 78376
		FileNotExist,
		// Token: 0x04013229 RID: 78377
		SendFileError,
		// Token: 0x0401322A RID: 78378
		UploadFailed,
		// Token: 0x0401322B RID: 78379
		UsernamePasswordError,
		// Token: 0x0401322C RID: 78380
		UserStatusError,
		// Token: 0x0401322D RID: 78381
		MessageTooLong,
		// Token: 0x0401322E RID: 78382
		ReceiverTooLong,
		// Token: 0x0401322F RID: 78383
		InvalidChatType,
		// Token: 0x04013230 RID: 78384
		InvalidReceiver,
		// Token: 0x04013231 RID: 78385
		UnknowError,
		// Token: 0x04013232 RID: 78386
		InvalidAppkey,
		// Token: 0x04013233 RID: 78387
		ForbiddenSpeak,
		// Token: 0x04013234 RID: 78388
		CreateFileFailed,
		// Token: 0x04013235 RID: 78389
		UnsupportFormat,
		// Token: 0x04013236 RID: 78390
		ReceiverEmpty,
		// Token: 0x04013237 RID: 78391
		RoomIDTooLong,
		// Token: 0x04013238 RID: 78392
		ContentInvalid,
		// Token: 0x04013239 RID: 78393
		NoLocationAuthrize,
		// Token: 0x0401323A RID: 78394
		UnknowLocation,
		// Token: 0x0401323B RID: 78395
		Unsupport,
		// Token: 0x0401323C RID: 78396
		NoAudioDevice,
		// Token: 0x0401323D RID: 78397
		AudioDriver,
		// Token: 0x0401323E RID: 78398
		DeviceStatusInvalid,
		// Token: 0x0401323F RID: 78399
		ResolveFileError,
		// Token: 0x04013240 RID: 78400
		ReadWriteFileError,
		// Token: 0x04013241 RID: 78401
		NoLangCode,
		// Token: 0x04013242 RID: 78402
		TranslateUnable,
		// Token: 0x04013243 RID: 78403
		SpeechAccentInvalid,
		// Token: 0x04013244 RID: 78404
		SpeechLanguageInvalid,
		// Token: 0x04013245 RID: 78405
		HasIllegalText,
		// Token: 0x04013246 RID: 78406
		AdvertisementMessage,
		// Token: 0x04013247 RID: 78407
		AlreadyBlock,
		// Token: 0x04013248 RID: 78408
		NotBlock,
		// Token: 0x04013249 RID: 78409
		MessageBlocked,
		// Token: 0x0401324A RID: 78410
		LocationTimeout,
		// Token: 0x0401324B RID: 78411
		NotJoinRoom,
		// Token: 0x0401324C RID: 78412
		LoginTokenInvalid,
		// Token: 0x0401324D RID: 78413
		CreateDirectoryFailed,
		// Token: 0x0401324E RID: 78414
		InitFailed,
		// Token: 0x0401324F RID: 78415
		Disconnect,
		// Token: 0x04013250 RID: 78416
		TheSameParam,
		// Token: 0x04013251 RID: 78417
		QueryUserInfoFail,
		// Token: 0x04013252 RID: 78418
		SetUserInfoFail,
		// Token: 0x04013253 RID: 78419
		UpdateUserOnlineStateFail,
		// Token: 0x04013254 RID: 78420
		NickNameTooLong,
		// Token: 0x04013255 RID: 78421
		SignatureTooLong,
		// Token: 0x04013256 RID: 78422
		NeedFriendVerify,
		// Token: 0x04013257 RID: 78423
		BeRefuse,
		// Token: 0x04013258 RID: 78424
		HasNotRegisterUserInfo,
		// Token: 0x04013259 RID: 78425
		AlreadyFriend,
		// Token: 0x0401325A RID: 78426
		NotFriend,
		// Token: 0x0401325B RID: 78427
		NotBlack,
		// Token: 0x0401325C RID: 78428
		PhotoUrlTooLong,
		// Token: 0x0401325D RID: 78429
		PhotoSizeTooLarge,
		// Token: 0x0401325E RID: 78430
		ChannelMemberOverflow,
		// Token: 0x0401325F RID: 78431
		ALREADYFRIENDS = 1000,
		// Token: 0x04013260 RID: 78432
		LoginInvalid,
		// Token: 0x04013261 RID: 78433
		PTT_Start = 2000,
		// Token: 0x04013262 RID: 78434
		PTT_Fail,
		// Token: 0x04013263 RID: 78435
		PTT_DownloadFail,
		// Token: 0x04013264 RID: 78436
		PTT_GetUploadTokenFail,
		// Token: 0x04013265 RID: 78437
		PTT_UploadFail,
		// Token: 0x04013266 RID: 78438
		PTT_NotSpeech,
		// Token: 0x04013267 RID: 78439
		PTT_DeviceStatusError,
		// Token: 0x04013268 RID: 78440
		PTT_IsSpeeching,
		// Token: 0x04013269 RID: 78441
		PTT_FileNotExist,
		// Token: 0x0401326A RID: 78442
		PTT_ReachMaxDuration,
		// Token: 0x0401326B RID: 78443
		PTT_SpeechTooShort,
		// Token: 0x0401326C RID: 78444
		PTT_StartAudioRecordFailed,
		// Token: 0x0401326D RID: 78445
		PTT_SpeechTimeout,
		// Token: 0x0401326E RID: 78446
		PTT_IsPlaying,
		// Token: 0x0401326F RID: 78447
		PTT_NotStartPlay,
		// Token: 0x04013270 RID: 78448
		PTT_CancelPlay,
		// Token: 0x04013271 RID: 78449
		PTT_NotStartRecord,
		// Token: 0x04013272 RID: 78450
		PTT_NotInit,
		// Token: 0x04013273 RID: 78451
		PTT_InitFailed,
		// Token: 0x04013274 RID: 78452
		PTT_Authorize,
		// Token: 0x04013275 RID: 78453
		PTT_StartRecordFailed,
		// Token: 0x04013276 RID: 78454
		PTT_StopRecordFailed,
		// Token: 0x04013277 RID: 78455
		PTT_UnsupprtFormat,
		// Token: 0x04013278 RID: 78456
		PTT_ResolveFileError,
		// Token: 0x04013279 RID: 78457
		PTT_ReadWriteFileError,
		// Token: 0x0401327A RID: 78458
		PTT_ConvertFileFailed,
		// Token: 0x0401327B RID: 78459
		PTT_NoAudioDevice,
		// Token: 0x0401327C RID: 78460
		PTT_NoDriver,
		// Token: 0x0401327D RID: 78461
		PTT_StartPlayFailed,
		// Token: 0x0401327E RID: 78462
		PTT_StopPlayFailed,
		// Token: 0x0401327F RID: 78463
		PTT_RecognizeFailed,
		// Token: 0x04013280 RID: 78464
		Fail = 10000
	}
}
