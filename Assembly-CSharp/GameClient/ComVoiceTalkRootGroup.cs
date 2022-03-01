using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001571 RID: 5489
	public class ComVoiceTalkRootGroup : MonoBehaviour
	{
		// Token: 0x0600D674 RID: 54900 RVA: 0x00359534 File Offset: 0x00357934
		public GameObject GetTalkRootByTalkType(ComVoiceTalk.ComVoiceTalkType talkType)
		{
			if (this.mTalkRootList == null)
			{
				return null;
			}
			for (int i = 0; i < this.mTalkRootList.Count; i++)
			{
				ComVoiceTalkRootGroup.ComVoiceTalkRootParam comVoiceTalkRootParam = this.mTalkRootList[i];
				if (comVoiceTalkRootParam != null)
				{
					if (comVoiceTalkRootParam.talkType == talkType)
					{
						return comVoiceTalkRootParam.talkRoot;
					}
				}
			}
			return null;
		}

		// Token: 0x04007DEA RID: 32234
		[SerializeField]
		private List<ComVoiceTalkRootGroup.ComVoiceTalkRootParam> mTalkRootList;

		// Token: 0x02001572 RID: 5490
		[Serializable]
		public class ComVoiceTalkRootParam
		{
			// Token: 0x04007DEB RID: 32235
			public ComVoiceTalk.ComVoiceTalkType talkType;

			// Token: 0x04007DEC RID: 32236
			public GameObject talkRoot;
		}
	}
}
