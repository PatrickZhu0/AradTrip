using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000DCE RID: 3534
	public interface IClientFrameManager
	{
		// Token: 0x06008ECE RID: 36558
		IClientFrame OpenFrame<T>(FrameLayer layer, object userData = null, string name = "") where T : class, IClientFrame;

		// Token: 0x06008ECF RID: 36559
		IClientFrame OpenFrame(Type t, FrameLayer layer, object userData = null, string name = "");

		// Token: 0x06008ED0 RID: 36560
		IClientFrame OpenFrame<T>(GameObject root, object userData = null, string name = "") where T : class, IClientFrame;

		// Token: 0x06008ED1 RID: 36561
		IClientFrame OpenFrame(Type type, GameObject root, object userData = null, string name = "", FrameLayer layer = FrameLayer.Invalid);

		// Token: 0x06008ED2 RID: 36562
		void CloseFrame<T>(T frame = default(T), bool bImmediately = false) where T : class, IClientFrame;

		// Token: 0x06008ED3 RID: 36563
		void CloseFrameByType(Type type, bool bImmediately = false);

		// Token: 0x06008ED4 RID: 36564
		bool IsFrameOpen<T>(T frame = default(T)) where T : class, IClientFrame;

		// Token: 0x06008ED5 RID: 36565
		bool IsFrameOpen(Type type);

		// Token: 0x06008ED6 RID: 36566
		bool IsFrameHidden(Type type);

		// Token: 0x06008ED7 RID: 36567
		bool IsFrameOpen(string name);

		// Token: 0x06008ED8 RID: 36568
		IClientFrame GetFrame(string name);

		// Token: 0x06008ED9 RID: 36569
		IClientFrame GetFrame(Type type);

		// Token: 0x06008EDA RID: 36570
		void ShowFrame(Type targetFrameType, Type currentFrameType, bool bShow);

		// Token: 0x06008EDB RID: 36571
		void ShowAllFrame(Type currentFrameType, bool bShow);

		// Token: 0x06008EDC RID: 36572
		void OnFrameClose(IClientFrame frame, bool removeRef);
	}
}
