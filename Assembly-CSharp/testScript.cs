using System;
using UnityEngine;

// Token: 0x020015D6 RID: 5590
public class testScript : MonoBehaviour
{
	// Token: 0x0600DB0F RID: 56079 RVA: 0x00373400 File Offset: 0x00371800
	private void Start()
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
		this.anim = new AnimationCurve(array);
	}

	// Token: 0x0600DB10 RID: 56080 RVA: 0x0037348C File Offset: 0x0037188C
	private void Update()
	{
		base.transform.position = new Vector3(Time.time, this.anim.Evaluate(Time.time), 0f);
		Logger.LogErrorFormat("anim.Evaluate(Time.time) = {0}", new object[]
		{
			this.anim.Evaluate(Time.time)
		});
	}

	// Token: 0x04008101 RID: 33025
	public AnimationCurve anim = new AnimationCurve();
}
