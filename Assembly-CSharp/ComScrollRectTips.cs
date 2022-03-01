using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000F14 RID: 3860
public class ComScrollRectTips : MonoBehaviour
{
	// Token: 0x060096A2 RID: 38562 RVA: 0x001CB188 File Offset: 0x001C9588
	private void Awake()
	{
		if (null != this.up)
		{
			this.up.onClick.AddListener(new UnityAction(this._onMoveUp));
		}
		if (null != this.down)
		{
			this.down.onClick.AddListener(new UnityAction(this._onMoveDown));
		}
		if (null != this.left)
		{
			this.left.onClick.AddListener(new UnityAction(this._onMoveLeft));
		}
		if (null != this.right)
		{
			this.right.onClick.AddListener(new UnityAction(this._onMoveRight));
		}
	}

	// Token: 0x060096A3 RID: 38563 RVA: 0x001CB24C File Offset: 0x001C964C
	private void OnDestroy()
	{
		if (null != this.up)
		{
			this.up.onClick.RemoveListener(new UnityAction(this._onMoveUp));
		}
		if (null != this.down)
		{
			this.down.onClick.RemoveListener(new UnityAction(this._onMoveDown));
		}
		if (null != this.left)
		{
			this.left.onClick.RemoveListener(new UnityAction(this._onMoveLeft));
		}
		if (null != this.right)
		{
			this.right.onClick.RemoveListener(new UnityAction(this._onMoveRight));
		}
	}

	// Token: 0x060096A4 RID: 38564 RVA: 0x001CB310 File Offset: 0x001C9710
	private void _onMoveUp()
	{
		Vector2 normalizedPosition = this.scroll.normalizedPosition;
		normalizedPosition.y += this.upDownStep.x;
		normalizedPosition.y = Mathf.Clamp01(normalizedPosition.y);
		this.scroll.normalizedPosition = normalizedPosition;
	}

	// Token: 0x060096A5 RID: 38565 RVA: 0x001CB364 File Offset: 0x001C9764
	private void _onMoveDown()
	{
		Vector2 normalizedPosition = this.scroll.normalizedPosition;
		normalizedPosition.y -= this.upDownStep.y;
		normalizedPosition.y = Mathf.Clamp01(normalizedPosition.y);
		this.scroll.normalizedPosition = normalizedPosition;
	}

	// Token: 0x060096A6 RID: 38566 RVA: 0x001CB3B8 File Offset: 0x001C97B8
	private void _onMoveLeft()
	{
		Vector2 normalizedPosition = this.scroll.normalizedPosition;
		normalizedPosition.x -= this.leftRightStep.x;
		normalizedPosition.x = Mathf.Clamp01(normalizedPosition.x);
		this.scroll.normalizedPosition = normalizedPosition;
	}

	// Token: 0x060096A7 RID: 38567 RVA: 0x001CB40C File Offset: 0x001C980C
	private void _onMoveRight()
	{
		Vector2 normalizedPosition = this.scroll.normalizedPosition;
		normalizedPosition.x += this.leftRightStep.x;
		normalizedPosition.x = Mathf.Clamp01(normalizedPosition.x);
		this.scroll.normalizedPosition = normalizedPosition;
	}

	// Token: 0x060096A8 RID: 38568 RVA: 0x001CB45D File Offset: 0x001C985D
	public void onPositionUpdate(Vector2 v)
	{
	}

	// Token: 0x04004D75 RID: 19829
	public Vector2 upDownStep = new Vector2(0.1f, 0.1f);

	// Token: 0x04004D76 RID: 19830
	public Vector2 leftRightStep = new Vector2(0.1f, 0.1f);

	// Token: 0x04004D77 RID: 19831
	public Button up;

	// Token: 0x04004D78 RID: 19832
	public Button down;

	// Token: 0x04004D79 RID: 19833
	public Button left;

	// Token: 0x04004D7A RID: 19834
	public Button right;

	// Token: 0x04004D7B RID: 19835
	public ScrollRect scroll;
}
