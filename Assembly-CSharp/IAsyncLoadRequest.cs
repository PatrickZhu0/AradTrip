using System;

// Token: 0x020000D0 RID: 208
public interface IAsyncLoadRequest<T> where T : class
{
	// Token: 0x06000464 RID: 1124
	bool IsDone();

	// Token: 0x06000465 RID: 1125
	T Extract();

	// Token: 0x06000466 RID: 1126
	string GetLoadPath();

	// Token: 0x06000467 RID: 1127
	void Abort();

	// Token: 0x06000468 RID: 1128
	bool IsValid();

	// Token: 0x06000469 RID: 1129
	bool IsAbort();
}
