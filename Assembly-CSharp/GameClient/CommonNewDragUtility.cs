using System;

namespace GameClient
{
	// Token: 0x02000DFE RID: 3582
	public static class CommonNewDragUtility
	{
		// Token: 0x06008FAD RID: 36781 RVA: 0x001A8FF8 File Offset: 0x001A73F8
		public static void ResetFirstDragPointerId()
		{
			CommonNewDragUtility.FirstDragPointerId = int.MinValue;
		}

		// Token: 0x06008FAE RID: 36782 RVA: 0x001A9004 File Offset: 0x001A7404
		public static bool IsAlreadyOwnerFirstDraggingPointerId()
		{
			return CommonNewDragUtility.FirstDragPointerId != int.MinValue;
		}

		// Token: 0x06008FAF RID: 36783 RVA: 0x001A9018 File Offset: 0x001A7418
		public static void SetFirstDraggingPointerId(int pointerId)
		{
			CommonNewDragUtility.FirstDragPointerId = pointerId;
		}

		// Token: 0x06008FB0 RID: 36784 RVA: 0x001A9020 File Offset: 0x001A7420
		public static bool IsPointerIdIsFirstDraggingPointerId(int pointerId)
		{
			return CommonNewDragUtility.FirstDragPointerId != int.MinValue && pointerId == CommonNewDragUtility.FirstDragPointerId;
		}

		// Token: 0x0400474C RID: 18252
		public static int FirstDragPointerId = int.MinValue;
	}
}
