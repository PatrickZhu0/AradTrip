using System;

// Token: 0x020000D8 RID: 216
public interface IAsyncLoadWrapper<T> where T : class
{
	// Token: 0x0600049E RID: 1182
	bool IsReady();

	// Token: 0x0600049F RID: 1183
	void Prepare(string loadPath, AsyncLoadData asyncLoadData);

	// Token: 0x060004A0 RID: 1184
	void DoLoad();

	// Token: 0x060004A1 RID: 1185
	bool IsDone();

	// Token: 0x060004A2 RID: 1186
	T Extract();

	// Token: 0x060004A3 RID: 1187
	bool InLoading();

	// Token: 0x060004A4 RID: 1188
	void OnAbort();

	// Token: 0x060004A5 RID: 1189
	void Reset();
}
