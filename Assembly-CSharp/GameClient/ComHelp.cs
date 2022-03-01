using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000037 RID: 55
	internal class ComHelp : MonoBehaviour
	{
		// Token: 0x0600016D RID: 365 RVA: 0x0000D7CC File Offset: 0x0000BBCC
		public void SetType(uint type)
		{
			if ((ulong)type >= (ulong)((long)this.contents.Length))
			{
				return;
			}
			Text component = this.textObj.GetComponent<Text>();
			component.text = this.contents[(int)((UIntPtr)type)].Replace("\\n", "\n");
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000D814 File Offset: 0x0000BC14
		public void SetExtraTypeContent(uint type)
		{
			if (this.extraContents == null || this.extraContents.Length == 0)
			{
				return;
			}
			HelpExtraContent helpExtraContent = null;
			for (int i = 0; i < this.extraContents.Length; i++)
			{
				HelpExtraContent helpExtraContent2 = this.extraContents[i];
				if (helpExtraContent2 != null)
				{
					if ((long)helpExtraContent2.helpType == (long)((ulong)type))
					{
						helpExtraContent = helpExtraContent2;
						break;
					}
				}
			}
			if (helpExtraContent != null && !string.IsNullOrEmpty(helpExtraContent.extraContent))
			{
				Text component = this.textObj.GetComponent<Text>();
				if (component)
				{
					component.text = helpExtraContent.extraContent.Replace("\\n", "\n");
				}
			}
			else
			{
				this.SetType(type);
			}
		}

		// Token: 0x04000149 RID: 329
		public string[] contents;

		// Token: 0x0400014A RID: 330
		public GameObject textObj;

		// Token: 0x0400014B RID: 331
		[Space(10f)]
		[Header("对应类型的替换内容")]
		[SerializeField]
		private HelpExtraContent[] extraContents;
	}
}
