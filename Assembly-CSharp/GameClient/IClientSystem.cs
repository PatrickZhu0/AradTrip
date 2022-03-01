using System;

namespace GameClient
{
	// Token: 0x02000DD3 RID: 3539
	public interface IClientSystem
	{
		// Token: 0x06008EFD RID: 36605
		bool IsSystem<T>() where T : IClientSystem;

		// Token: 0x06008EFE RID: 36606
		string GetName();

		// Token: 0x06008EFF RID: 36607
		void SetName(string name);

		// Token: 0x06008F00 RID: 36608
		void GetExitCoroutine(AddCoroutine exit);

		// Token: 0x06008F01 RID: 36609
		void GetEnterCoroutine(AddCoroutine enter);

		// Token: 0x06008F02 RID: 36610
		void OnEnter();

		// Token: 0x06008F03 RID: 36611
		void OnExit();

		// Token: 0x06008F04 RID: 36612
		void OnStart(SystemContent systemContent);

		// Token: 0x06008F05 RID: 36613
		void Update(float timeElapsed);

		// Token: 0x06008F06 RID: 36614
		ClientSystem.eClientSystemState GetState();

		// Token: 0x06008F07 RID: 36615
		void BeforeEnter();
	}
}
