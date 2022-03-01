using System;
using System.Collections;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DD1 RID: 3537
	public interface IClientFrame
	{
		// Token: 0x06008EDD RID: 36573
		void Init();

		// Token: 0x06008EDE RID: 36574
		void Clear();

		// Token: 0x06008EDF RID: 36575
		void Open(GameObject root, object userData = null, FrameLayer layer = FrameLayer.Invalid);

		// Token: 0x06008EE0 RID: 36576
		void Close(bool bCloseImmediately = false);

		// Token: 0x06008EE1 RID: 36577
		void Update(float timeElapsed);

		// Token: 0x06008EE2 RID: 36578
		void Show(bool isShow, Type type = null);

		// Token: 0x06008EE3 RID: 36579
		bool IsOpen();

		// Token: 0x06008EE4 RID: 36580
		bool IsHidden();

		// Token: 0x06008EE5 RID: 36581
		bool IsNeedUpdate();

		// Token: 0x06008EE6 RID: 36582
		bool IsGlobal();

		// Token: 0x06008EE7 RID: 36583
		void SetManager(IClientFrameManager mgr);

		// Token: 0x06008EE8 RID: 36584
		EFrameState GetState();

		// Token: 0x06008EE9 RID: 36585
		void UpdateRoot();

		// Token: 0x06008EEA RID: 36586
		string GetFrameName();

		// Token: 0x06008EEB RID: 36587
		void SetFrameName(string name);

		// Token: 0x06008EEC RID: 36588
		void SetGlobal(bool isGlobal);

		// Token: 0x06008EED RID: 36589
		string GetGroupTag();

		// Token: 0x06008EEE RID: 36590
		FrameLayer GetLayer();

		// Token: 0x06008EEF RID: 36591
		bool NeedMutex();

		// Token: 0x06008EF0 RID: 36592
		bool IsNeedClearWhenChangeScene();

		// Token: 0x06008EF1 RID: 36593
		bool IsFullScreenFrameNeedBeClose();

		// Token: 0x06008EF2 RID: 36594
		IEnumerator LoadingOpenPost();

		// Token: 0x06008EF3 RID: 36595
		int GetSiblingIndex();

		// Token: 0x06008EF4 RID: 36596
		void SetSiblingIndex(int index);

		// Token: 0x06008EF5 RID: 36597
		GameObject GetFrame();

		// Token: 0x06008EF6 RID: 36598
		eFrameType GetFrameType();
	}
}
