﻿using System;

namespace YouMe
{
	// Token: 0x02004AE1 RID: 19169
	public enum YouMeErrorCode
	{
		// Token: 0x040136E6 RID: 79590
		YOUME_SUCCESS,
		// Token: 0x040136E7 RID: 79591
		YOUME_ERROR_API_NOT_SUPPORTED = -1,
		// Token: 0x040136E8 RID: 79592
		YOUME_ERROR_INVALID_PARAM = -2,
		// Token: 0x040136E9 RID: 79593
		YOUME_ERROR_ALREADY_INIT = -3,
		// Token: 0x040136EA RID: 79594
		YOUME_ERROR_NOT_INIT = -4,
		// Token: 0x040136EB RID: 79595
		YOUME_ERROR_CHANNEL_EXIST = -5,
		// Token: 0x040136EC RID: 79596
		YOUME_ERROR_CHANNEL_NOT_EXIST = -6,
		// Token: 0x040136ED RID: 79597
		YOUME_ERROR_WRONG_STATE = -7,
		// Token: 0x040136EE RID: 79598
		YOUME_ERROR_NOT_ALLOWED_MOBILE_NETWROK = -8,
		// Token: 0x040136EF RID: 79599
		YOUME_ERROR_WRONG_CHANNEL_MODE = -9,
		// Token: 0x040136F0 RID: 79600
		YOUME_ERROR_TOO_MANY_CHANNELS = -10,
		// Token: 0x040136F1 RID: 79601
		YOUME_ERROR_TOKEN_ERROR = -11,
		// Token: 0x040136F2 RID: 79602
		YOUME_ERROR_NOT_IN_CHANNEL = -12,
		// Token: 0x040136F3 RID: 79603
		YOUME_ERROR_BE_KICK = -13,
		// Token: 0x040136F4 RID: 79604
		YOUME_ERROR_MEMORY_OUT = -100,
		// Token: 0x040136F5 RID: 79605
		YOUME_ERROR_START_FAILED = -101,
		// Token: 0x040136F6 RID: 79606
		YOUME_ERROR_STOP_FAILED = -102,
		// Token: 0x040136F7 RID: 79607
		YOUME_ERROR_ILLEGAL_SDK = -103,
		// Token: 0x040136F8 RID: 79608
		YOUME_ERROR_SERVER_INVALID = -104,
		// Token: 0x040136F9 RID: 79609
		YOUME_ERROR_NETWORK_ERROR = -105,
		// Token: 0x040136FA RID: 79610
		YOUME_ERROR_SERVER_INTER_ERROR = -106,
		// Token: 0x040136FB RID: 79611
		YOUME_ERROR_QUERY_RESTAPI_FAIL = -107,
		// Token: 0x040136FC RID: 79612
		YOUME_ERROR_USER_ABORT = -108,
		// Token: 0x040136FD RID: 79613
		YOUME_ERROR_SEND_MESSAGE_FAIL = -109,
		// Token: 0x040136FE RID: 79614
		YOUME_ERROR_REC_INIT_FAILED = -201,
		// Token: 0x040136FF RID: 79615
		YOUME_ERROR_REC_NO_PERMISSION = -202,
		// Token: 0x04013700 RID: 79616
		YOUME_ERROR_REC_NO_DATA = -203,
		// Token: 0x04013701 RID: 79617
		YOUME_ERROR_REC_OTHERS = -204,
		// Token: 0x04013702 RID: 79618
		YOUME_ERROR_REC_PERMISSION_UNDEFINED = -205,
		// Token: 0x04013703 RID: 79619
		YOUME_ERROR_GRABMIC_FULL = -301,
		// Token: 0x04013704 RID: 79620
		YOUME_ERROR_GRABMIC_HASEND = -302,
		// Token: 0x04013705 RID: 79621
		YOUME_ERROR_INVITEMIC_NOUSER = -401,
		// Token: 0x04013706 RID: 79622
		YOUME_ERROR_INVITEMIC_OFFLINE = -402,
		// Token: 0x04013707 RID: 79623
		YOUME_ERROR_INVITEMIC_REJECT = -403,
		// Token: 0x04013708 RID: 79624
		YOUME_ERROR_INVITEMIC_TIMEOUT = -404,
		// Token: 0x04013709 RID: 79625
		YOUME_ERROR_WHITE_SOMEUSER_ABNORMAL = -501,
		// Token: 0x0401370A RID: 79626
		YOUME_ERROR_UNKNOWN = -1000
	}
}