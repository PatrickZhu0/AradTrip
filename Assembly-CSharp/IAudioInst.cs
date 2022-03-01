using System;

// Token: 0x020000F4 RID: 244
public interface IAudioInst
{
	// Token: 0x06000506 RID: 1286
	void Pause();

	// Token: 0x06000507 RID: 1287
	void Resume();

	// Token: 0x06000508 RID: 1288
	void Stop();

	// Token: 0x06000509 RID: 1289
	bool IsEnd();

	// Token: 0x0600050A RID: 1290
	int GetLength();

	// Token: 0x0600050B RID: 1291
	void SetPitch(float pitch);
}
