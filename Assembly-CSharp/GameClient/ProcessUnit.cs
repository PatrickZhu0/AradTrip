using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045C3 RID: 17859
	public class ProcessUnit
	{
		// Token: 0x06019111 RID: 102673 RVA: 0x007E8752 File Offset: 0x007E6B52
		public ProcessUnit Append(IEnumerator it)
		{
			this.mItors.Add(it);
			return this;
		}

		// Token: 0x06019112 RID: 102674 RVA: 0x007E8764 File Offset: 0x007E6B64
		public IEnumerator Parallel()
		{
			ProcessUnit.sDeep++;
			for (int i = 0; i < this.mItors.Count; i++)
			{
				this.mCoroutines.Add(MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.mItors[i]));
			}
			bool isEnd = false;
			bool[] itorsFlag = new bool[this.mItors.Count];
			while (!isEnd)
			{
				isEnd = true;
				yield return Yielders.EndOfFrame;
				for (int j = 0; j < this.mItors.Count; j++)
				{
					if (this.mItors[j].Current != null)
					{
						isEnd = false;
						break;
					}
					if (!itorsFlag[j])
					{
						itorsFlag[j] = true;
					}
				}
			}
			this.mItors.Clear();
			ProcessUnit.sDeep--;
			for (int k = 0; k < this.mCoroutines.Count; k++)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCoroutines[k]);
			}
			this.mCoroutines.Clear();
			yield break;
		}

		// Token: 0x06019113 RID: 102675 RVA: 0x007E8780 File Offset: 0x007E6B80
		public IEnumerator Sequence()
		{
			for (int i = 0; i < this.mItors.Count; i++)
			{
				ProcessUnit.sDeep++;
				yield return this.mItors[i];
				ProcessUnit.sDeep--;
			}
			this.mItors.Clear();
			yield return null;
			yield break;
		}

		// Token: 0x04011FBA RID: 73658
		private static int sDeep;

		// Token: 0x04011FBB RID: 73659
		private List<IEnumerator> mItors = new List<IEnumerator>();

		// Token: 0x04011FBC RID: 73660
		private List<Coroutine> mCoroutines = new List<Coroutine>();
	}
}
