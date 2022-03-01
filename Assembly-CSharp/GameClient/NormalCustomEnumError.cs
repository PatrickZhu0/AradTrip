using System;

namespace GameClient
{
	// Token: 0x02000E31 RID: 3633
	public class NormalCustomEnumError : ICustomEnumError
	{
		// Token: 0x0600911D RID: 37149 RVA: 0x001ADA9D File Offset: 0x001ABE9D
		public NormalCustomEnumError(string error, eEnumError type = eEnumError.ProcessError)
		{
			this.mErrorMsg = error;
			this.mErrorType = type;
		}

		// Token: 0x0600911E RID: 37150 RVA: 0x001ADAB3 File Offset: 0x001ABEB3
		public string GetErrorMsg()
		{
			return this.mErrorMsg;
		}

		// Token: 0x0600911F RID: 37151 RVA: 0x001ADABB File Offset: 0x001ABEBB
		public void SetErrorMsg(string msg)
		{
			this.mErrorMsg = msg;
		}

		// Token: 0x06009120 RID: 37152 RVA: 0x001ADAC4 File Offset: 0x001ABEC4
		public eEnumError GetErrorType()
		{
			return this.mErrorType;
		}

		// Token: 0x04004872 RID: 18546
		private string mErrorMsg;

		// Token: 0x04004873 RID: 18547
		private eEnumError mErrorType;
	}
}
