using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020041E5 RID: 16869
	public class BeEvent
	{
		// Token: 0x020041E6 RID: 16870
		public class BeEventParam
		{
			// Token: 0x0601753C RID: 95548 RVA: 0x0072D5F0 File Offset: 0x0072B9F0
			public void Reset()
			{
				this.m_Int = 0;
				this.m_Int2 = 0;
				this.m_Int3 = 0;
				this.m_Bool = false;
				this.m_Percent = VPercent.zero;
				this.m_Rate = VRate.zero;
				this.m_Vint = VInt.zero;
				this.m_Vint3 = VInt3.zero;
				this.m_Vector = Vector3.zero;
				this.m_Obj = null;
				this.m_Obj2 = null;
				this.m_Obj3 = null;
				this.m_String = null;
			}

			// Token: 0x0601753D RID: 95549 RVA: 0x0072D66C File Offset: 0x0072BA6C
			public void FromStruct(EventParam param)
			{
				this.m_Int = param.m_Int;
				this.m_Int2 = param.m_Int2;
				this.m_Int3 = param.m_Int3;
				this.m_Bool = param.m_Bool;
				this.m_Percent = param.m_Percent;
				this.m_Rate = param.m_Rate;
				this.m_Vint = param.m_Vint;
				this.m_Vint3 = param.m_Vint3;
				this.m_Vector = param.m_Vector;
				this.m_Obj = param.m_Obj;
				this.m_Obj2 = param.m_Obj2;
				this.m_Obj3 = param.m_Obj3;
				this.m_String = param.m_String;
			}

			// Token: 0x0601753E RID: 95550 RVA: 0x0072D724 File Offset: 0x0072BB24
			public void ToStruct(out EventParam param)
			{
				param.m_Int = this.m_Int;
				param.m_Int2 = this.m_Int2;
				param.m_Int3 = this.m_Int3;
				param.m_Bool = this.m_Bool;
				param.m_Percent = this.m_Percent;
				param.m_Rate = this.m_Rate;
				param.m_Vint = this.m_Vint;
				param.m_Vint3 = this.m_Vint3;
				param.m_Vector = this.m_Vector;
				param.m_Obj = this.m_Obj;
				param.m_Obj2 = this.m_Obj2;
				param.m_Obj3 = this.m_Obj3;
				param.m_String = this.m_String;
			}

			// Token: 0x04010C34 RID: 68660
			public int m_Int;

			// Token: 0x04010C35 RID: 68661
			public int m_Int2;

			// Token: 0x04010C36 RID: 68662
			public int m_Int3;

			// Token: 0x04010C37 RID: 68663
			public bool m_Bool;

			// Token: 0x04010C38 RID: 68664
			public VPercent m_Percent;

			// Token: 0x04010C39 RID: 68665
			public VRate m_Rate;

			// Token: 0x04010C3A RID: 68666
			public VInt m_Vint;

			// Token: 0x04010C3B RID: 68667
			public VInt3 m_Vint3;

			// Token: 0x04010C3C RID: 68668
			public Vector3 m_Vector;

			// Token: 0x04010C3D RID: 68669
			public object m_Obj;

			// Token: 0x04010C3E RID: 68670
			public object m_Obj2;

			// Token: 0x04010C3F RID: 68671
			public object m_Obj3;

			// Token: 0x04010C40 RID: 68672
			public string m_String;
		}

		// Token: 0x020041E7 RID: 16871
		public class BeEventHandleNew : IBeEventHandle
		{
			// Token: 0x0601753F RID: 95551 RVA: 0x0072D7CD File Offset: 0x0072BBCD
			public BeEventHandleNew(int eventType, BeEvent.BeEventHandleNew.Function fn, BeEventManager mgr)
			{
				this.m_EventType = eventType;
				this.m_Fn = fn;
				this.m_owner = mgr;
				this.m_CanRemove = false;
				this.m_StackLevel = 0;
			}

			// Token: 0x06017540 RID: 95552 RVA: 0x0072D7F8 File Offset: 0x0072BBF8
			public void DoFunc(BeEvent.BeEventParam eventParam)
			{
				this.m_StackLevel++;
				if (this.m_StackLevel > Global.TriggerSingleEventStackLevelLimit && this.m_StackLevel <= Global.MaxStackLevelLogLimit)
				{
					Logger.LogErrorFormat("trigger new event id {0}  recurse out of stack level {1}", new object[]
					{
						this.m_EventType,
						this.m_StackLevel
					});
				}
				if (this.m_Fn != null)
				{
					this.m_Fn(eventParam);
				}
				this.m_StackLevel--;
			}

			// Token: 0x06017541 RID: 95553 RVA: 0x0072D884 File Offset: 0x0072BC84
			public void Remove()
			{
				this.m_CanRemove = true;
				if (this.m_owner != null)
				{
					this.m_owner.RemoveEvent(this.m_EventType);
				}
				this.m_owner = null;
			}

			// Token: 0x04010C41 RID: 68673
			public int m_EventType;

			// Token: 0x04010C42 RID: 68674
			public BeEvent.BeEventHandleNew.Function m_Fn;

			// Token: 0x04010C43 RID: 68675
			public bool m_CanRemove;

			// Token: 0x04010C44 RID: 68676
			private int m_StackLevel;

			// Token: 0x04010C45 RID: 68677
			private BeEventManager m_owner;

			// Token: 0x020041E8 RID: 16872
			// (Invoke) Token: 0x06017543 RID: 95555
			public delegate void Function(BeEvent.BeEventParam param);
		}
	}
}
