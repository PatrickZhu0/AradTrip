using System;
using System.Collections;

namespace GameClient
{
	// Token: 0x02000E35 RID: 3637
	public interface IEnumeratorManager
	{
		// Token: 0x06009139 RID: 37177
		IEnumerator AddEnumerator(IEnumerator iter, int priority = 2147483647);

		// Token: 0x0600913A RID: 37178
		IEnumerator AddEnumerator(IEnumerator iter, IEnumerator root = null);

		// Token: 0x0600913B RID: 37179
		void RemoveEnumerator(IEnumerator iter);

		// Token: 0x0600913C RID: 37180
		void ClearAllEnumerators();

		// Token: 0x0600913D RID: 37181
		bool IsEnumeratorError(IEnumerator iter);

		// Token: 0x0600913E RID: 37182
		bool IsEnumeratorRunning(IEnumerator iter);

		// Token: 0x0600913F RID: 37183
		object GetEnumeratorCurrent(IEnumerator iter);

		// Token: 0x06009140 RID: 37184
		string GetEnumeratorError(IEnumerator iter, bool isPopError = true);

		// Token: 0x06009141 RID: 37185
		eEnumError GetEnumeratorErrorType(IEnumerator iter, bool isPopError = false);

		// Token: 0x06009142 RID: 37186
		void DumpAllEnumeratorError();

		// Token: 0x06009143 RID: 37187
		void UpdateEnumerators();
	}
}
