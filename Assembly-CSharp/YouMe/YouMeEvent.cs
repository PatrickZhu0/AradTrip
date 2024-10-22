﻿using System;

namespace YouMe
{
	// Token: 0x02004ADE RID: 19166
	public enum YouMeEvent
	{
		// Token: 0x0401369A RID: 79514
		YOUME_EVENT_INIT_OK,
		// Token: 0x0401369B RID: 79515
		YOUME_EVENT_INIT_FAILED,
		// Token: 0x0401369C RID: 79516
		YOUME_EVENT_JOIN_OK,
		// Token: 0x0401369D RID: 79517
		YOUME_EVENT_JOIN_FAILED,
		// Token: 0x0401369E RID: 79518
		YOUME_EVENT_LEAVED_ONE,
		// Token: 0x0401369F RID: 79519
		YOUME_EVENT_LEAVED_ALL,
		// Token: 0x040136A0 RID: 79520
		YOUME_EVENT_PAUSED,
		// Token: 0x040136A1 RID: 79521
		YOUME_EVENT_RESUMED,
		// Token: 0x040136A2 RID: 79522
		YOUME_EVENT_SPEAK_SUCCESS,
		// Token: 0x040136A3 RID: 79523
		YOUME_EVENT_SPEAK_FAILED,
		// Token: 0x040136A4 RID: 79524
		YOUME_EVENT_RECONNECTING,
		// Token: 0x040136A5 RID: 79525
		YOUME_EVENT_RECONNECTED,
		// Token: 0x040136A6 RID: 79526
		YOUME_EVENT_REC_PERMISSION_STATUS,
		// Token: 0x040136A7 RID: 79527
		YOUME_EVENT_BGM_STOPPED,
		// Token: 0x040136A8 RID: 79528
		YOUME_EVENT_BGM_FAILED,
		// Token: 0x040136A9 RID: 79529
		YOUME_EVENT_OTHERS_MIC_ON = 16,
		// Token: 0x040136AA RID: 79530
		YOUME_EVENT_OTHERS_MIC_OFF,
		// Token: 0x040136AB RID: 79531
		YOUME_EVENT_OTHERS_SPEAKER_ON,
		// Token: 0x040136AC RID: 79532
		YOUME_EVENT_OTHERS_SPEAKER_OFF,
		// Token: 0x040136AD RID: 79533
		YOUME_EVENT_OTHERS_VOICE_ON,
		// Token: 0x040136AE RID: 79534
		YOUME_EVENT_OTHERS_VOICE_OFF,
		// Token: 0x040136AF RID: 79535
		YOUME_EVENT_MY_MIC_LEVEL,
		// Token: 0x040136B0 RID: 79536
		YOUME_EVENT_MIC_CTR_ON,
		// Token: 0x040136B1 RID: 79537
		YOUME_EVENT_MIC_CTR_OFF,
		// Token: 0x040136B2 RID: 79538
		YOUME_EVENT_SPEAKER_CTR_ON,
		// Token: 0x040136B3 RID: 79539
		YOUME_EVENT_SPEAKER_CTR_OFF,
		// Token: 0x040136B4 RID: 79540
		YOUME_EVENT_LISTEN_OTHER_ON,
		// Token: 0x040136B5 RID: 79541
		YOUME_EVENT_LISTEN_OTHER_OFF,
		// Token: 0x040136B6 RID: 79542
		YOUME_EVENT_LOCAL_MIC_ON,
		// Token: 0x040136B7 RID: 79543
		YOUME_EVENT_LOCAL_MIC_OFF,
		// Token: 0x040136B8 RID: 79544
		YOUME_EVENT_LOCAL_SPEAKER_ON,
		// Token: 0x040136B9 RID: 79545
		YOUME_EVENT_LOCAL_SPEAKER_OFF,
		// Token: 0x040136BA RID: 79546
		YOUME_EVENT_GRABMIC_START_OK,
		// Token: 0x040136BB RID: 79547
		YOUME_EVENT_GRABMIC_START_FAILED,
		// Token: 0x040136BC RID: 79548
		YOUME_EVENT_GRABMIC_STOP_OK,
		// Token: 0x040136BD RID: 79549
		YOUME_EVENT_GRABMIC_STOP_FAILED,
		// Token: 0x040136BE RID: 79550
		YOUME_EVENT_GRABMIC_REQUEST_OK,
		// Token: 0x040136BF RID: 79551
		YOUME_EVENT_GRABMIC_REQUEST_FAILED,
		// Token: 0x040136C0 RID: 79552
		YOUME_EVENT_GRABMIC_REQUEST_WAIT,
		// Token: 0x040136C1 RID: 79553
		YOUME_EVENT_GRABMIC_RELEASE_OK,
		// Token: 0x040136C2 RID: 79554
		YOUME_EVENT_GRABMIC_RELEASE_FAILED,
		// Token: 0x040136C3 RID: 79555
		YOUME_EVENT_GRABMIC_ENDMIC,
		// Token: 0x040136C4 RID: 79556
		YOUME_EVENT_GRABMIC_NOTIFY_START,
		// Token: 0x040136C5 RID: 79557
		YOUME_EVENT_GRABMIC_NOTIFY_STOP,
		// Token: 0x040136C6 RID: 79558
		YOUME_EVENT_GRABMIC_NOTIFY_HASMIC,
		// Token: 0x040136C7 RID: 79559
		YOUME_EVENT_GRABMIC_NOTIFY_NOMIC,
		// Token: 0x040136C8 RID: 79560
		YOUME_EVENT_INVITEMIC_SETOPT_OK,
		// Token: 0x040136C9 RID: 79561
		YOUME_EVENT_INVITEMIC_SETOPT_FAILED,
		// Token: 0x040136CA RID: 79562
		YOUME_EVENT_INVITEMIC_REQUEST_OK,
		// Token: 0x040136CB RID: 79563
		YOUME_EVENT_INVITEMIC_REQUEST_FAILED,
		// Token: 0x040136CC RID: 79564
		YOUME_EVENT_INVITEMIC_RESPONSE_OK,
		// Token: 0x040136CD RID: 79565
		YOUME_EVENT_INVITEMIC_RESPONSE_FAILED,
		// Token: 0x040136CE RID: 79566
		YOUME_EVENT_INVITEMIC_STOP_OK,
		// Token: 0x040136CF RID: 79567
		YOUME_EVENT_INVITEMIC_STOP_FAILED,
		// Token: 0x040136D0 RID: 79568
		YOUME_EVENT_INVITEMIC_CAN_TALK,
		// Token: 0x040136D1 RID: 79569
		YOUME_EVENT_INVITEMIC_CANNOT_TALK,
		// Token: 0x040136D2 RID: 79570
		YOUME_EVENT_INVITEMIC_NOTIFY_CALL,
		// Token: 0x040136D3 RID: 79571
		YOUME_EVENT_INVITEMIC_NOTIFY_ANSWER,
		// Token: 0x040136D4 RID: 79572
		YOUME_EVENT_INVITEMIC_NOTIFY_CANCEL,
		// Token: 0x040136D5 RID: 79573
		YOUME_EVENT_SEND_MESSAGE_RESULT,
		// Token: 0x040136D6 RID: 79574
		YOUME_EVENT_MESSAGE_NOTIFY,
		// Token: 0x040136D7 RID: 79575
		YOUME_EVENT_SET_WHITE_USER_LIST_OK,
		// Token: 0x040136D8 RID: 79576
		YOUME_EVENT_SET_WHITE_USER_LIST_FAILED,
		// Token: 0x040136D9 RID: 79577
		YOUME_EVENT_KICK_RESULT,
		// Token: 0x040136DA RID: 79578
		YOUME_EVENT_KICK_NOTIFY,
		// Token: 0x040136DB RID: 79579
		YOUME_EVENT_EOF = 1000
	}
}
