using System;
using System.Collections;

// Token: 0x020041F3 RID: 16883
public interface IDungeonEnumeratorManager
{
	// Token: 0x0601758A RID: 95626
	IEnumerator AddEnumerator(IEnumerator iter, int priority = 2147483647);

	// Token: 0x0601758B RID: 95627
	void RemoveEnumerator(IEnumerator iter);

	// Token: 0x0601758C RID: 95628
	void ClearAllEnumerators();
}
