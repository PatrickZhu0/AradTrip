using System;

namespace GameClient
{
	// Token: 0x02001CCF RID: 7375
	internal class WrappedTestFrame : WrappedClientFrame
	{
		// Token: 0x0601215A RID: 74074 RVA: 0x0054B959 File Offset: 0x00549D59
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/ActiveFrame/TestFrame";
		}

		// Token: 0x0601215B RID: 74075 RVA: 0x0054B960 File Offset: 0x00549D60
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
		}

		// Token: 0x0601215C RID: 74076 RVA: 0x0054B968 File Offset: 0x00549D68
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
		}

		// Token: 0x02001CD0 RID: 7376
		public class TestData : WrappedClientFrame.WrappedData
		{
		}
	}
}
