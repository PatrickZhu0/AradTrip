using System;
using System.Collections;

namespace GameClient
{
	// Token: 0x020010AE RID: 4270
	public class DungeonPreTips : ClientFrame
	{
		// Token: 0x0600A114 RID: 41236 RVA: 0x0020A095 File Offset: 0x00208495
		public override string GetPrefabPath()
		{
			return "UI/Prefabs/Chapter/DungeonPreTips";
		}

		// Token: 0x0600A115 RID: 41237 RVA: 0x0020A09C File Offset: 0x0020849C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			for (int i = 0; i < this.mMoutips.Length; i++)
			{
				this.mMoutips[i].SetMonsterNumber();
			}
			base.StartCoroutine(this._delayClose(2));
		}

		// Token: 0x0600A116 RID: 41238 RVA: 0x0020A0E4 File Offset: 0x002084E4
		private IEnumerator _delayClose(int s)
		{
			yield return Yielders.GetWaitForSeconds((float)s);
			this._onHandle();
			yield break;
		}

		// Token: 0x0600A117 RID: 41239 RVA: 0x0020A106 File Offset: 0x00208506
		[UIEventHandle("Background")]
		private void _onHandle()
		{
			base.Close(false);
		}

		// Token: 0x0400599C RID: 22940
		[UIControl("Root/Board/Item{0}", typeof(ComMouCountTips), 0)]
		private ComMouCountTips[] mMoutips = new ComMouCountTips[3];
	}
}
