using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015D3 RID: 5587
	internal class GetAniValue : MonoBehaviour
	{
		// Token: 0x0600DB01 RID: 56065 RVA: 0x00372BC0 File Offset: 0x00370FC0
		private void Start()
		{
			if (this.animationCurves == null)
			{
				Keyframe[] array = new Keyframe[2];
				Keyframe[] array2 = array;
				int num = 0;
				Keyframe keyframe = new Keyframe(0f, 0f);
				keyframe.inTangent = 2f;
				keyframe.outTangent = 2f;
				array2[num] = keyframe;
				Keyframe[] array3 = array;
				int num2 = 1;
				keyframe = new Keyframe(1f, 1f);
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
				array3[num2] = keyframe;
				AnimationCurve animationCurve = new AnimationCurve(array);
				this.animationCurves = animationCurve;
			}
		}

		// Token: 0x0600DB02 RID: 56066 RVA: 0x00372C57 File Offset: 0x00371057
		public float GetValue(float key)
		{
			return this.animationCurves.Evaluate(key);
		}

		// Token: 0x040080E5 RID: 32997
		public AnimationCurve animationCurves;
	}
}
