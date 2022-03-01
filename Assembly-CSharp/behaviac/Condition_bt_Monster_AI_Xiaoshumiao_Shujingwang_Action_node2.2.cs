using System;

namespace behaviac
{
	// Token: 0x02003E06 RID: 15878
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node28 : Condition
	{
		// Token: 0x06016395 RID: 91029 RVA: 0x006B80C5 File Offset: 0x006B64C5
		public Condition_bt_Monster_AI_Xiaoshumiao_Shujingwang_Action_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06016396 RID: 91030 RVA: 0x006B80D8 File Offset: 0x006B64D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBFD RID: 64509
		private float opl_p0;
	}
}
