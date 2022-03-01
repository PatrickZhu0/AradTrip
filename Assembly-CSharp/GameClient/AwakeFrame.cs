using System;
using System.Collections;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020014A1 RID: 5281
	internal class AwakeFrame : ClientFrame
	{
		// Token: 0x0600CCC3 RID: 52419 RVA: 0x00324A76 File Offset: 0x00322E76
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/UpLeveljuexing";
		}

		// Token: 0x0600CCC4 RID: 52420 RVA: 0x00324A80 File Offset: 0x00322E80
		protected override void _OnOpenFrame()
		{
			DestroyDelay component = this.frame.GetComponent<DestroyDelay>();
			base.StartCoroutine(this.closeDelay(component.Delay));
			component.enabled = false;
			this.InitInterface();
		}

		// Token: 0x0600CCC5 RID: 52421 RVA: 0x00324ABC File Offset: 0x00322EBC
		private IEnumerator closeDelay(float time)
		{
			yield return new WaitForSeconds(time);
			base.Close(false);
			yield break;
		}

		// Token: 0x0600CCC6 RID: 52422 RVA: 0x00324ADE File Offset: 0x00322EDE
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600CCC7 RID: 52423 RVA: 0x00324AE6 File Offset: 0x00322EE6
		private void ClearData()
		{
			this.time = 0f;
		}

		// Token: 0x0600CCC8 RID: 52424 RVA: 0x00324AF3 File Offset: 0x00322EF3
		private void InitInterface()
		{
			DataManager<PlayerBaseData>.GetInstance().bNeedShowAwakeFrame = false;
		}

		// Token: 0x0600CCC9 RID: 52425 RVA: 0x00324B00 File Offset: 0x00322F00
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600CCCA RID: 52426 RVA: 0x00324B03 File Offset: 0x00322F03
		protected override void _OnUpdate(float timeElapsed)
		{
			this.time += timeElapsed;
			if (this.time >= 1f)
			{
				this.mEffectRoot.CustomActive(true);
			}
		}

		// Token: 0x0600CCCB RID: 52427 RVA: 0x00324B2F File Offset: 0x00322F2F
		protected override void _bindExUI()
		{
			this.mEffectRoot = this.mBind.GetGameObject("EffectRoot");
		}

		// Token: 0x0600CCCC RID: 52428 RVA: 0x00324B47 File Offset: 0x00322F47
		protected override void _unbindExUI()
		{
			this.mEffectRoot = null;
		}

		// Token: 0x0400773B RID: 30523
		private float time;

		// Token: 0x0400773C RID: 30524
		private GameObject mEffectRoot;
	}
}
