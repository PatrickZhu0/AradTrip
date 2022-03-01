using System;

namespace GameClient
{
	// Token: 0x02000E2F RID: 3631
	public interface ICustomEnumError
	{
		// Token: 0x0600911A RID: 37146
		string GetErrorMsg();

		// Token: 0x0600911B RID: 37147
		void SetErrorMsg(string msg);

		// Token: 0x0600911C RID: 37148
		eEnumError GetErrorType();
	}
}
