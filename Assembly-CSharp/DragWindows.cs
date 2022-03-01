using System;
using GameClient;
using UnityEngine;

// Token: 0x0200006F RID: 111
public class DragWindows : MonoBehaviour
{
	// Token: 0x0600026A RID: 618 RVA: 0x00012AD4 File Offset: 0x00010ED4
	private void OnGUI()
	{
		if (Event.current.type == null)
		{
			this.currentVector = DragWindows.slideVector.nullVector;
			this.touchFirst = Event.current.mousePosition;
		}
		if (Event.current.type == 3)
		{
			this.touchSecond = Event.current.mousePosition;
			this.timer += Time.deltaTime;
			if (this.timer > this.offsetTime)
			{
				this.touchSecond = Event.current.mousePosition;
				Vector2 vector = this.touchFirst - this.touchSecond;
				float x = vector.x;
				float y = vector.y;
				if (y + this.SlidingDistance < x && y > -x - this.SlidingDistance)
				{
					if (this.currentVector == DragWindows.slideVector.left)
					{
						return;
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RightSlip, null, null, null, null);
					this.currentVector = DragWindows.slideVector.left;
				}
				else if (y > x + this.SlidingDistance && y < -x - this.SlidingDistance)
				{
					if (this.currentVector == DragWindows.slideVector.right)
					{
						return;
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.LeftSlip, null, null, null, null);
					this.currentVector = DragWindows.slideVector.right;
				}
				else if (y > x + this.SlidingDistance && y - this.SlidingDistance > -x)
				{
					if (this.currentVector == DragWindows.slideVector.up)
					{
						return;
					}
					this.currentVector = DragWindows.slideVector.up;
				}
				else if (y + this.SlidingDistance < x && y < -x - this.SlidingDistance)
				{
					if (this.currentVector == DragWindows.slideVector.down)
					{
						return;
					}
					this.currentVector = DragWindows.slideVector.down;
				}
				this.timer = 0f;
				this.touchFirst = this.touchSecond;
			}
		}
	}

	// Token: 0x0400025E RID: 606
	private Vector2 touchFirst = Vector2.zero;

	// Token: 0x0400025F RID: 607
	private Vector2 touchSecond = Vector2.zero;

	// Token: 0x04000260 RID: 608
	private DragWindows.slideVector currentVector;

	// Token: 0x04000261 RID: 609
	private float timer;

	// Token: 0x04000262 RID: 610
	public float offsetTime = 0.2f;

	// Token: 0x04000263 RID: 611
	public float SlidingDistance = 100f;

	// Token: 0x02000070 RID: 112
	private enum slideVector
	{
		// Token: 0x04000265 RID: 613
		nullVector,
		// Token: 0x04000266 RID: 614
		up,
		// Token: 0x04000267 RID: 615
		down,
		// Token: 0x04000268 RID: 616
		left,
		// Token: 0x04000269 RID: 617
		right
	}
}
