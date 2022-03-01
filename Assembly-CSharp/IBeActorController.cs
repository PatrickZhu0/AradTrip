using System;

// Token: 0x020041F2 RID: 16882
public interface IBeActorController
{
	// Token: 0x06017585 RID: 95621
	void SetOwner(BeActor actor);

	// Token: 0x06017586 RID: 95622
	void OnEnter();

	// Token: 0x06017587 RID: 95623
	void OnTick(int delta);

	// Token: 0x06017588 RID: 95624
	bool IsEnd();

	// Token: 0x06017589 RID: 95625
	bool AutoRemove();
}
