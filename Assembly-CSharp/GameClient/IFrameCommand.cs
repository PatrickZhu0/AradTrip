using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02004512 RID: 17682
	public interface IFrameCommand
	{
		// Token: 0x06018984 RID: 100740
		FrameCommandID GetID();

		// Token: 0x06018985 RID: 100741
		uint GetFrame();

		// Token: 0x06018986 RID: 100742
		byte GetSeat();

		// Token: 0x06018987 RID: 100743
		uint GetSendTime();

		// Token: 0x06018988 RID: 100744
		void ExecCommand();

		// Token: 0x06018989 RID: 100745
		_inputData GetInputData();

		// Token: 0x0601898A RID: 100746
		void SetValue(uint frame, byte seat, _inputData data);

		// Token: 0x0601898B RID: 100747
		string GetString();

		// Token: 0x0601898C RID: 100748
		void Reset();
	}
}
