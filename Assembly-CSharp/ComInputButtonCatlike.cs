using System;
using UnityEngine;

// Token: 0x02000EF2 RID: 3826
[ExecuteInEditMode]
public class ComInputButtonCatlike : MonoBehaviour
{
	// Token: 0x060095B9 RID: 38329 RVA: 0x001C4464 File Offset: 0x001C2864
	private void _swithETCButtons(ETCButton srcButton, ETCButton dstButton)
	{
		float width = srcButton.rectTransform().rect.width;
		float width2 = dstButton.rectTransform().rect.width;
		srcButton.rectTransform().SetSizeWithCurrentAnchors(0, width2);
		srcButton.rectTransform().SetSizeWithCurrentAnchors(1, width2);
		dstButton.rectTransform().SetSizeWithCurrentAnchors(0, width);
		dstButton.rectTransform().SetSizeWithCurrentAnchors(1, width);
		Vector2 anchorOffet;
		anchorOffet..ctor(srcButton.anchorOffet.x, srcButton.anchorOffet.y);
		Vector2 anchorOffet2;
		anchorOffet2..ctor(dstButton.anchorOffet.x, dstButton.anchorOffet.y);
		srcButton.anchorOffet = anchorOffet2;
		dstButton.anchorOffet = anchorOffet;
	}

	// Token: 0x060095BA RID: 38330 RVA: 0x001C4528 File Offset: 0x001C2928
	public void Switch()
	{
		int num = this.mButtonGroupUse.Length;
		int num2 = this.mButtonGroupTip.Length;
		if (num != num2)
		{
			Logger.LogErrorFormat("the swap array mButtonGroupUse & mButtonGroupTips has different size", new object[0]);
			return;
		}
		for (int i = 0; i < num; i++)
		{
			this._swithETCButtons(this.mButtonGroupTip[i], this.mButtonGroupUse[i]);
			this.mButtonGroupTip[i].activated = this.mSwitchStatus;
			this.mButtonGroupUse[i].activated = !this.mSwitchStatus;
		}
		this.mSwitchStatus = !this.mSwitchStatus;
	}

	// Token: 0x060095BB RID: 38331 RVA: 0x001C45BF File Offset: 0x001C29BF
	private void Start()
	{
		this.mSwitchStatus = true;
		this.Switch();
		this.Switch();
	}

	// Token: 0x060095BC RID: 38332 RVA: 0x001C45D4 File Offset: 0x001C29D4
	private void Update()
	{
	}

	// Token: 0x04004CA0 RID: 19616
	public ETCButton[] mButtonGroupUse = new ETCButton[0];

	// Token: 0x04004CA1 RID: 19617
	public ETCButton[] mButtonGroupTip = new ETCButton[0];

	// Token: 0x04004CA2 RID: 19618
	private bool mSwitchStatus = true;
}
