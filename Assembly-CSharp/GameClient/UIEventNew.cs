using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000FCD RID: 4045
	public class UIEventNew
	{
		// Token: 0x02000FCE RID: 4046
		public class UIEventParamNew
		{
			// Token: 0x06009AF5 RID: 39669 RVA: 0x001DF5E8 File Offset: 0x001DD9E8
			public void Reset()
			{
				this.m_Int = 0;
				this.m_Int2 = 0;
				this.m_Bool = false;
				this.m_Vector = Vector3.zero;
				this.m_Obj = null;
				this.m_Obj2 = null;
				this.m_Obj3 = null;
				this.m_String = string.Empty;
				this.m_Vector = Vector3.zero;
			}

			// Token: 0x06009AF6 RID: 39670 RVA: 0x001DF640 File Offset: 0x001DDA40
			public void FromStruct(UIEventParam param)
			{
				this.m_Int = param.m_Int;
				this.m_Int2 = param.m_Int2;
				this.m_Bool = param.m_Bool;
				this.m_Vector = param.m_Vector;
				this.m_Obj = param.m_Obj;
				this.m_Obj2 = param.m_Obj2;
				this.m_Obj3 = param.m_Obj3;
				this.m_String = param.m_String;
			}

			// Token: 0x06009AF7 RID: 39671 RVA: 0x001DF6B8 File Offset: 0x001DDAB8
			public void ToStruct(out UIEventParam param)
			{
				param.m_Int = this.m_Int;
				param.m_Int2 = this.m_Int2;
				param.m_Bool = this.m_Bool;
				param.m_Vector = this.m_Vector;
				param.m_Obj = this.m_Obj;
				param.m_Obj2 = this.m_Obj2;
				param.m_Obj3 = this.m_Obj3;
				param.m_String = this.m_String;
			}

			// Token: 0x0400548E RID: 21646
			public int m_Int;

			// Token: 0x0400548F RID: 21647
			public int m_Int2;

			// Token: 0x04005490 RID: 21648
			public bool m_Bool;

			// Token: 0x04005491 RID: 21649
			public Vector3 m_Vector;

			// Token: 0x04005492 RID: 21650
			public object m_Obj;

			// Token: 0x04005493 RID: 21651
			public object m_Obj2;

			// Token: 0x04005494 RID: 21652
			public object m_Obj3;

			// Token: 0x04005495 RID: 21653
			public string m_String;
		}

		// Token: 0x02000FCF RID: 4047
		public class UIEventHandleNew
		{
			// Token: 0x06009AF8 RID: 39672 RVA: 0x001DF725 File Offset: 0x001DDB25
			public UIEventHandleNew(int eventType, UIEventNew.UIEventHandleNew.Function fn)
			{
				this.m_EventType = eventType;
				this.m_Fn = fn;
				this.m_stackLevel = 0;
			}

			// Token: 0x06009AF9 RID: 39673 RVA: 0x001DF744 File Offset: 0x001DDB44
			public void DoFunc(UIEventNew.UIEventParamNew param)
			{
				this.m_stackLevel++;
				if (this.m_stackLevel > Global.TriggerSingleEventStackLevelLimit && this.m_stackLevel <= Global.MaxStackLevelLogLimit)
				{
					Logger.LogErrorFormat("UIEventHandleNew id {0} DoFunc out of Recurse stack Level {1}", new object[]
					{
						this.m_EventType,
						this.m_stackLevel
					});
				}
				if (this.m_Fn != null)
				{
					this.m_Fn(param);
				}
				this.m_stackLevel--;
			}

			// Token: 0x06009AFA RID: 39674 RVA: 0x001DF7D0 File Offset: 0x001DDBD0
			public void Remove()
			{
				this.m_Fn = null;
			}

			// Token: 0x04005496 RID: 21654
			public int m_EventType;

			// Token: 0x04005497 RID: 21655
			public UIEventNew.UIEventHandleNew.Function m_Fn;

			// Token: 0x04005498 RID: 21656
			private int m_stackLevel;

			// Token: 0x02000FD0 RID: 4048
			// (Invoke) Token: 0x06009AFC RID: 39676
			public delegate void Function(UIEventNew.UIEventParamNew param);
		}
	}
}
