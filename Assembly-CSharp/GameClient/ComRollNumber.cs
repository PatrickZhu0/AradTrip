using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02000052 RID: 82
	public class ComRollNumber : MonoBehaviour
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x0001031F File Offset: 0x0000E71F
		public void SetEditorValue()
		{
			this.RollValue = this.iEditorValue;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x0001032D File Offset: 0x0000E72D
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x00010338 File Offset: 0x0000E738
		public int RollValue
		{
			get
			{
				return this.iValue;
			}
			set
			{
				if (this.bRoll)
				{
					this.iTargetValue = value;
					this.bDirty = true;
				}
				else
				{
					int num = this.iValue;
					this.iValue = value;
					this.bDirty = false;
					this.setValues(ref this.orgValues, num);
					this.setValues(ref this.curValues, this.iValue);
					this.StartRoll();
				}
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x000103A0 File Offset: 0x0000E7A0
		private void setValues(ref int[] Values, int iValue)
		{
			if (Values.Length < this.scrollItems.Length)
			{
				Values = new int[this.scrollItems.Length];
			}
			for (int i = 0; i < Values.Length; i++)
			{
				Values[i] = 0;
			}
			int num = Values.Length - 1;
			while (num >= 0 && iValue > 0)
			{
				Values[Values.Length - 1 - num] = iValue % 10;
				iValue /= 10;
				num--;
			}
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x0001041C File Offset: 0x0000E81C
		public void StartRoll()
		{
			if (this.bRoll)
			{
				return;
			}
			this.bRoll = true;
			this.refCount = this.scrollItems.Length;
			for (int i = 0; i < this.scrollItems.Length; i++)
			{
				this.scrollItems[i].Run(this.orgValues[i], this.curValues[i]);
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00010480 File Offset: 0x0000E880
		private void Start()
		{
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00010484 File Offset: 0x0000E884
		private void Awake()
		{
			for (int i = 0; i < this.scrollItems.Length; i++)
			{
				this.scrollItems[i].onActionEnd.AddListener(new UnityAction(this._OnActionEnd));
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x000104C8 File Offset: 0x0000E8C8
		private void OnDestroy()
		{
			for (int i = 0; i < this.scrollItems.Length; i++)
			{
				if (null != this.scrollItems[i])
				{
					this.scrollItems[i].onActionEnd.RemoveListener(new UnityAction(this._OnActionEnd));
				}
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0001051F File Offset: 0x0000E91F
		private void _OnActionEnd()
		{
			this.refCount--;
			if (this.refCount == 0)
			{
				this.bRoll = false;
				if (this.bDirty)
				{
					this.bDirty = false;
					this.RollValue = this.iTargetValue;
				}
			}
		}

		// Token: 0x040001D9 RID: 473
		public ComScrollNumber[] scrollItems = new ComScrollNumber[0];

		// Token: 0x040001DA RID: 474
		private bool bRoll;

		// Token: 0x040001DB RID: 475
		private bool bDirty;

		// Token: 0x040001DC RID: 476
		private int iValue;

		// Token: 0x040001DD RID: 477
		private int iTargetValue;

		// Token: 0x040001DE RID: 478
		public int iEditorValue;

		// Token: 0x040001DF RID: 479
		private int[] orgValues = new int[0];

		// Token: 0x040001E0 RID: 480
		private int[] curValues = new int[0];

		// Token: 0x040001E1 RID: 481
		private int refCount;
	}
}
